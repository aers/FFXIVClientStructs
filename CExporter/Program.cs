using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;

namespace CExporter;

public class Program {
    public static void Main(string[] args) {
        var quiet = args.Contains("--quiet");
        var noWrite = args.Contains("--no-write");
        var timeStart = DateTime.Now;
        var dir = new DirectoryInfo(Environment.CurrentDirectory);
        while (dir.FullName.Contains("ida") && !dir.FullName.EndsWith("ida")) {
            dir = dir.Parent!;
        }
        while (!dir.FullName.Contains("ida") && !dir.FullName.EndsWith("ida")) {
            dir = dir.GetDirectories("ida", SearchOption.AllDirectories).FirstOrDefault() ?? dir.Parent!;
        }

        Exporter.ProcessTypes(quiet);
        Exporter.ProcessStaticFunctions(quiet);

        Exporter.VerifyNoOverlap();

        var dataPath = Path.Combine(dir.FullName, "data.yml");

        var data = new DeserializerBuilder()
            .IgnoreUnmatchedProperties()
            .Build()
            .Deserialize<DataDefinition>(File.ReadAllText(dataPath));
        var dataCheck = data.classes.SelectMany(t => t.Value is { funcs: not null } ? t.Value.funcs.Values.Select(f => new KeyValuePair<string, string>(t.Key, f)) : new List<KeyValuePair<string, string>>())
            .Concat(data.classes.SelectMany(t => t.Value is { vfuncs: not null } ? t.Value.vfuncs.Values.Select(f => new KeyValuePair<string, string>(t.Key, f)) : new List<KeyValuePair<string, string>>()))
            .GroupBy(t => t.Key).ToDictionary(t => t.Key, t => t.Select(f => f.Value).ToList());

        Exporter.VerifyNoNameOverlap(dataCheck);
        Exporter.ProcessDefinedVTables(data);

        if (!quiet) Console.WriteLine($"Processed all types in: {DateTime.Now - timeStart}");
        timeStart = DateTime.Now;

        foreach (var warning in ExporterStatics.WarningList) {
            Console.WriteLine(warning);
        }

        foreach (var error in ExporterStatics.ErrorList) {
            Console.Error.WriteLine(error);
        }
#if DEBUG
        if (ExporterStatics.ErrorList.Count > 0) {
            Environment.Exit(1);
        }
#else
        if (!noWrite) {
            if (ExporterStatics.ErrorList.Count > 20) {
                var sb = new StringBuilder();
                sb.AppendLine("<details>");
                sb.AppendLine();
                foreach (var error in ExporterStatics.ErrorList) {
                    sb.AppendLine($"{error}");
                }
                sb.Append("</details>");
                new FileInfo(Path.Combine(dir.FullName, "errors.txt")).WriteFile(sb.ToString());
            }
            else
                new FileInfo(Path.Combine(dir.FullName, "errors.txt")).WriteFile(string.Join("\n", ExporterStatics.ErrorList));
        }
#endif
        if (!noWrite) {
            Exporter.Write(dir);
            if (!quiet) Console.WriteLine($"Files written in: {DateTime.Now - timeStart}");
        }
    }
}
