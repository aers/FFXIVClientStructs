using System;
using System.IO;
using System.Linq;

namespace CExporter;

public class Program {
    public static void Main(string[] _) {
        var dir = new DirectoryInfo(Environment.CurrentDirectory);
        while (dir.FullName.Contains("ida") && !dir.FullName.EndsWith("ida")) {
            dir = dir.Parent!;
        }
        while (!dir.FullName.Contains("ida") && !dir.FullName.EndsWith("ida")) {
            dir = dir.GetDirectories("ida/CExporter", SearchOption.AllDirectories).First().Parent!;
        }

        Exporter.ProcessTypes();

        Exporter.VerifyNoFieldOverlap();

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
        new FileInfo(Path.Combine(dir.FullName, "errors.txt")).WriteFile(string.Join("\n", ExporterStatics.ErrorList));
#endif

        Exporter.Write(dir);
    }
}
