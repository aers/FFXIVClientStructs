using System.Diagnostics;
using System.Text;
using FFXIVClientStructs.InteropGenerator;
using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropSourceGenerators;

[Generator]
public class VersionGenerator : ISourceGenerator {
    private uint version;

    private string GitCommand(GeneratorExecutionContext context, string command) {
        var mainSyntaxTree = context.Compilation.SyntaxTrees.First(x => x.HasCompilationUnitRoot);
        var directory = Path.GetDirectoryName(mainSyntaxTree.FilePath);

        var gitProcess = new Process() {
            StartInfo = new ProcessStartInfo() {
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = "git",
                Arguments = command,
                WorkingDirectory = directory
            }
        };

        var output = new StringBuilder();

        gitProcess.OutputDataReceived += (_, e) => {
            output.Append(e.Data);
        };

        gitProcess.Start();
        gitProcess.BeginOutputReadLine();
        gitProcess.WaitForExit();
        gitProcess.CancelOutputRead();
        return output.ToString();
    }
    public void Initialize(GeneratorInitializationContext context) { }
    public void Execute(GeneratorExecutionContext context) {
        var hash = GitCommand(context, "show -s --format=%H");
        var count = GitCommand(context, $"rev-list --count {hash}");
        if (!uint.TryParse(count, out version)) version = 0;

        var builder = new IndentedStringBuilder();
        builder.AppendLine("using System.Reflection;");
        builder.AppendLine($"[assembly: AssemblyVersion(\"1.0.0.{version}\")]");
        builder.AppendLine($"[assembly: AssemblyFileVersion(\"1.0.0.{version}\")]");
        builder.AppendLine($"[assembly: AssemblyInformationalVersion(\"1.0.0.{version}\")]");

        builder.AppendLine("namespace FFXIVClientStructs.Interop;");
        builder.AppendLine("public partial class Resolver {");
        using (builder.Indent()) {
            builder.AppendLine($"public static readonly uint Version = {version};");
        }

        builder.AppendLine("}");
        context.AddSource("FFXIVClientStructs.Interop.Resolver.Version.g.cs", builder.ToString());
    }
}
