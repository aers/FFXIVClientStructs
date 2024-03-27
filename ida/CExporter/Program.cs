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

        foreach (var warning in ExporterStatics.WarningList) {
            Console.WriteLine(warning);
        }
    }
}
