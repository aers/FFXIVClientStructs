using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;

namespace CompatChecker;

class Program {
    static void Main(string[] args) {
        if (args.Length == 0)
            throw new ArgumentException("Provide a left and right dll to compare");

        var dir = new DirectoryInfo(Environment.CurrentDirectory);
        while (dir.FullName.Contains("ida") && !dir.FullName.EndsWith("ida")) {
            dir = dir.Parent!;
        }
        while (!dir.FullName.Contains("ida") && !dir.FullName.EndsWith("ida")) {
            dir = dir.GetDirectories("ida", SearchOption.AllDirectories).FirstOrDefault() ?? dir.Parent!;
        }

        var left = args[0];
        var right = args[1];

        var p = new Process();
        p.StartInfo.FileName = "apicompat";
        p.StartInfo.Arguments = $"-l \"{left}\" -r \"{right}\"";
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.RedirectStandardError = true;
        p.Start();
        var error = p.StandardError.ReadToEnd();
        var output = p.StandardOutput.ReadToEnd();
        p.WaitForExit();
        var isError = string.IsNullOrWhiteSpace(output);

        if (!isError) 
            return;

        var sb = new StringBuilder();
        var errors = error.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)[1..^1]
            .Select(Parse.ParseBreakingChange)
            .Where(t => t != null)
            .Cast<ChangeType>()
            .Where(t => t.Change.Main?.IsCompat() ?? true)
            .OrderBy(t => t.Code)
            .GroupBy(t => t.Code)
            .Select(t => (
                t.Key,
                t.GroupBy(f => f.Change.Main?.Namespace)
                    .Select(f => (
                            f.Key,
                            f.GroupBy(k => k.Change.Main?.Class)
                                .Select(k => (
                                    k.Key,
                                    k.ToList()))
                                .ToList()
                        )
                    )
                    .ToList())
            )
            .ToList();
        foreach (var (code, count) in errors) {
            // get Description attribute from enum value if it exists
            var description = code.GetType().GetField(code.ToString())?.GetCustomAttribute<DescriptionAttribute>()?.Description;
            sb.AppendLine('#' + (string.IsNullOrWhiteSpace(description) ? code.ToString() : description));
            foreach (var (ns, classes) in count) {
                if (ns != null)
                    sb.AppendLine($"##{ns}: {classes.Count}");
                foreach (var (@class, changes) in classes) {
                    sb.AppendLine($"##{(ns != null ? "#" : "")}{@class ?? "Global"}: {changes.Count}");
                    foreach (var change in changes) {
                        sb.AppendLine($"###{(ns != null ? "#" : "")}{change.Change}");
                    }
                }
            }
        }
        Console.WriteLine(sb);
#if DEBUG
        Environment.Exit(isError ? 1 : 0);
#else
        new FileInfo(Path.Combine(dir.FullName, "errors.txt")).WriteFile(sb.ToString());
#endif


    }
}
