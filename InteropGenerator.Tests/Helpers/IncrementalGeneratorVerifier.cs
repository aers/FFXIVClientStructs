using System.Text;
using InteropGenerator.Runtime.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;

namespace InteropGenerator.Tests.Helpers;

internal static class IncrementalGeneratorVerifier<TIncrementalGenerator>
    where TIncrementalGenerator : IIncrementalGenerator, new() {
    public static async Task VerifyGeneratorAsync(string source, (string filename, string content) generatedSource)
        => await VerifyGeneratorAsync(source, new[] { generatedSource });

    public static async Task VerifyGeneratorAsync(string source, params (string filename, string content)[] generatedSources) {
        var test = new IncrementalGeneratorTest<TIncrementalGenerator> {
            TestState = {
                Sources = { 
                    GlobalUsings.GetSource,
                    source },
                ReferenceAssemblies = ReferenceAssemblies.Net.Net80,
                AdditionalReferences = { MetadataReference.CreateFromFile(typeof(GenerateInteropAttribute).Assembly.Location) }
            }
        };

        foreach ((string filename, string content) in generatedSources) {
            test.TestState.GeneratedSources.Add((typeof(TIncrementalGenerator), filename, SourceText.From(content, Encoding.UTF8)));
        }

        await test.RunAsync(CancellationToken.None);
    }
}
