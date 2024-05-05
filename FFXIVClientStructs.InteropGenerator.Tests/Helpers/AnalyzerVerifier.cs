using FFXIVClientStructs.InteropGenerator.Runtime.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

namespace FFXIVClientStructs.InteropGenerator.Tests.Helpers;

internal static class AnalyzerVerifier<TAnalyzer> where TAnalyzer : DiagnosticAnalyzer, new() {
    public static async Task VerifyAnalyzerAsync(string source) {
        AnalyzerTest<TAnalyzer> test = new() {
            TestCode = source,
            TestState = {
                ReferenceAssemblies = ReferenceAssemblies.Net.Net80,
                AdditionalReferences = { MetadataReference.CreateFromFile(typeof(GenerateInteropAttribute).Assembly.Location) }
            }
        };

        await test.RunAsync(CancellationToken.None);
    }
}
