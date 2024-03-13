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

        ExporterBase exporter = new ExporterIDA();

        new FileInfo(Path.Combine(dir.FullName, "ffxiv_client_structs.h")).WriteFile(exporter.Export(GapStrategy.FullSize));
        new FileInfo(Path.Combine(dir.FullName, "ffxiv_client_structs_arrays.h")).WriteFile(exporter.Export(GapStrategy.ByteArray));

        exporter = new ExporterGhidra();

        new FileInfo(Path.Combine(dir.FullName, "ffxiv_client_structs_ghidra.h")).WriteFile(exporter.Export(GapStrategy.FullSize));
        new FileInfo(Path.Combine(dir.FullName, "ffxiv_client_structs_arrays_ghidra.h")).WriteFile(exporter.Export(GapStrategy.ByteArray));
#if DEBUG
        Console.Clear();
        Console.SetCursorPosition(0, 0);
#endif
        var sw = new StreamWriter(File.OpenWrite(Path.Combine(dir.FullName, "errors.txt")));

        if (exporter.Errored) {
            foreach (var (_, value) in ExporterStatics.ErrorListDictionary) {
                sw.WriteLine(value);
                Console.WriteLine(value);
            }
            sw.Close();
            Console.WriteLine("Exporter failed to export all types some error happened");
            return;
        }
        sw.Close();

        // ReSharper disable once InvertIf
        if (ExporterStatics.WarningListDictionary.Count > 0)
            foreach (var (_, value) in ExporterStatics.WarningListDictionary)
                Console.WriteLine(value);
    }
}
