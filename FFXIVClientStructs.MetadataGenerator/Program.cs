using System.Reflection;
using System.Text.Json;
using FFXIVClientStructs.MetadataGenerator;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;

MSBuildLocator.RegisterDefaults();

var workspace = MSBuildWorkspace.Create();
var solution = await workspace.OpenSolutionAsync("../FFXIVClientStructs.sln");
var project = solution.Projects.First(p => p.Name == "FFXIVClientStructs");
var compilation = await project.GetCompilationAsync();

var cs = Assembly.Load("FFXIVClientStructs");

var structs = new List<MetadataStruct>();
var enums = new List<MetadataEnum>();
var unions = new List<MetadataUnion>();
var functions = new List<MetadataFunction>();
var globals = new List<MetadataStaticAddressInfo>();

foreach (var document in project.Documents) {
    var syntaxTree = await document.GetSyntaxTreeAsync();
    var root = await syntaxTree!.GetRootAsync();
    var model = compilation!.GetSemanticModel(syntaxTree);

    var walker = new ClientStructsSyntaxWalker(model, cs);
    walker.Visit(root);

    structs.AddRange(walker.Structs);
    enums.AddRange(walker.Enums);
    unions.AddRange(walker.Unions);
    functions.AddRange(walker.Functions);
    globals.AddRange(walker.Globals);
}

var output = new MetadataOutput {
    Structs = structs,
    Enums = enums,
    Unions = unions,
    Functions = functions,
    Globals = globals
};

Console.WriteLine($"{structs.Count} structs, {enums.Count} enums, {unions.Count} unions, {functions.Count} functions, {globals.Count} globals");

var options = new JsonSerializerOptions { WriteIndented = true };
var outputStr = JsonSerializer.Serialize(output, options);
File.WriteAllText("../scripts/metadata.json", outputStr);
