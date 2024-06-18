namespace ExcelGenerator;

internal static class Program {
    private static void Main(string[] args) {
        var gamePath = args.Length >= 1 ? args[0] : @"C:\Steam\steamapps\common\FINAL FANTASY XIV Online\";
        var outputPath = args.Length >= 2 ? args[1] : @"..\..\..\FFXIVClientStructs\FFXIV\Component\Excel\Sheets\";
        var schemaPath = args.Length >= 3 ? args[2] : null;

        var nameSpace = "FFXIVClientStructs.FFXIV.Component.Excel.Sheets";

        if (!Directory.Exists(gamePath))
            throw new DirectoryNotFoundException("GamePath not Found.");

        if (string.IsNullOrWhiteSpace(schemaPath)) {
            using var update = new Updater(gamePath, "Definitions");
            schemaPath = update.TryUpdate();
            if (schemaPath == null) {
                Console.WriteLine("Update Failed. Using Existing Schema...");
                schemaPath = update.GetLatesLocalDirectory();
            }
        }

        if (string.IsNullOrWhiteSpace(schemaPath))
            throw new DirectoryNotFoundException("No Schema Directory Available");

        Console.WriteLine($"Using Schema in: {schemaPath}");

        using var generator = new Generator(Path.Combine(gamePath, "game", "sqpack"));

        foreach (var path in Directory.EnumerateFiles(schemaPath, "*.yml")) {
            var sheetName = Path.GetFileNameWithoutExtension(path);
            var structName = sheetName;
            var outputFile = Path.Combine(outputPath, $"{structName}.cs");

            Console.WriteLine($"Processing: {sheetName,-30} -> {outputFile}");

            var source = generator.ProcessDefinition(path, sheetName, structName, nameSpace);

            if (string.IsNullOrWhiteSpace(source)) {
                Console.WriteLine($" -> Failed to Generate Source for '{sheetName} ({path})'");
                continue;
            }

            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);
            File.WriteAllText(outputFile, source);
        }
    }
}
