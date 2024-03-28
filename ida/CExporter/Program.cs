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

        Console.WriteLine("::group::Processing Structs");
        Exporter.ProcessTypes();
        Console.WriteLine("::endgroup::");

        foreach (var warning in ExporterStatics.WarningList) {
            Console.WriteLine(warning);
        }

        foreach (var error in ExporterStatics.ErrorList) {
            Console.Error.WriteLine(error);
        }
        if (ExporterStatics.ErrorList.Count > 0) {
            Environment.Exit(1);
        }

        Console.WriteLine("::group::Writing Files");
        Exporter.WriteIDA(dir);

        Console.WriteLine("::endgroup::");
    }
}
