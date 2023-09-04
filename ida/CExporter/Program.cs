using System;
using System.IO;

namespace CExporter;

public class Program {
    public static void Main(string[] _) {
        const string outputBase = "../../../../";

        ExporterBase exporter = new ExporterIDA();

        File.WriteAllText($"{outputBase}ffxiv_client_structs.h", exporter.Export(GapStrategy.FullSize));
        File.WriteAllText($"{outputBase}ffxiv_client_structs_arrays.h", exporter.Export(GapStrategy.ByteArray));

        exporter = new ExporterGhidra();

        File.WriteAllText($"{outputBase}ffxiv_client_structs_ghidra.h", exporter.Export(GapStrategy.FullSize));
        File.WriteAllText($"{outputBase}ffxiv_client_structs_arrays_ghidra.h", exporter.Export(GapStrategy.ByteArray));

        Console.Clear();
        Console.SetCursorPosition(0, 0);

        if (exporter.Errored) {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            foreach (var (_, value) in ExporterStatics.ErrorListDictionary)
                Console.WriteLine(value);
            throw new Exception("Exporter failed to export all types some error happened");
        }

        // ReSharper disable once InvertIf
        if (ExporterStatics.WarningListDictionary.Count > 0)
            foreach (var (_, value) in ExporterStatics.WarningListDictionary)
                Console.WriteLine(value);
    }
}
