using System.Text;
using InteropGenerator.Runtime.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;

namespace InteropGenerator.Tests.Helpers;

internal static class IncrementalGeneratorVerifier<TIncrementalGenerator>
    where TIncrementalGenerator : IIncrementalGenerator, new() {
    public static async Task VerifyGeneratorAsync(string source, (string filename, string content) generatedSource)
        => await VerifyGeneratorAsync(source, [generatedSource]);

    public static async Task VerifyGeneratorAsync(string source, params (string filename, string content)[] generatedSources) {
        // usually passed as an MSBuild property we're passing it as an EditorConfig style option in the tests
        const string config = """
                              build_property.InteropGenerator_InteropNamespace = InteropGeneratorTesting
                              """;

        var test = new IncrementalGeneratorTest<TIncrementalGenerator> {
            TestState = {
                Sources = {
                    GlobalUsings.GetSource,
                    source
                },
                AnalyzerConfigFiles = { ("/.globalconfig", config) },
                ReferenceAssemblies = ReferenceAssemblies.Net.Net90,
                AdditionalReferences = { MetadataReference.CreateFromFile(typeof(GenerateInteropAttribute).Assembly.Location) }
            }
        };

        foreach ((string filename, string content) in generatedSources) {
            test.TestState.GeneratedSources.Add((typeof(TIncrementalGenerator), filename, SourceText.From(content, Encoding.UTF8)));
        }

        await test.RunAsync(CancellationToken.None);
    }
}
