namespace ExcelGenerator;

internal static class Program {
    private static void Main(string[] args) {
        var gamePath = args.Length >= 1 ? args[0] : @"C:\Steam\steamapps\common\FINAL FANTASY XIV Online\";
        var outputPath = args.Length >= 2 ? args[1] : @"..\..\..\FFXIVClientStructs\FFXIV\Component\Exd\Sheets\";
        var schemaPath = args.Length >= 3 ? args[2] : null;

        var nameSpace = "FFXIVClientStructs.FFXIV.Component.Exd.Sheets";

        if (string.IsNullOrWhiteSpace(schemaPath)) {
            schemaPath = Updater.TryUpdate("Definitions");
            if (schemaPath == null) {
                Console.WriteLine("Update Failed. Using Existing Schema...");
                schemaPath = Path.Combine("Definitions", "EXDSchema-latest");
            }
        }

        if (string.IsNullOrWhiteSpace(schemaPath) || !Directory.Exists(schemaPath))
            throw new DirectoryNotFoundException("No Schema Directory Available");

        Console.WriteLine($"Using Schema in: {schemaPath}");

        var gameDataPath = (string.IsNullOrEmpty(gamePath) || !Directory.Exists(gamePath)) ? null : Path.Combine(gamePath, "game", "sqpack");

        Console.WriteLine($"Using Column Data from: {gameDataPath ?? schemaPath}");

        using var generator = new Generator(gameDataPath, schemaPath);

        foreach (var path in Directory.EnumerateFiles(schemaPath, "*.yml", SearchOption.TopDirectoryOnly)) {
            var sheetName = Path.GetFileNameWithoutExtension(path);
            var outputFile = Path.Combine(outputPath, $"{sheetName}.cs");

            Console.WriteLine($"Processing: {sheetName,-30} -> {outputFile}");

            var source = generator.ProcessDefinition(path, sheetName, sheetName, nameSpace);

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
