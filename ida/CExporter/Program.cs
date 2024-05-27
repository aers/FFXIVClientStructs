using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using YamlDotNet.Serialization;

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
