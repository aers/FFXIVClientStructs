using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;

namespace FFXIVClientStructs.InteropGenerator.Tests.Helpers;

internal sealed class IncrementalGeneratorTest<TIncrementalGenerator> : CSharpSourceGeneratorTest<EmptySourceGeneratorProvider, XUnitVerifier>
    where TIncrementalGenerator : IIncrementalGenerator, new() {
    
    public LanguageVersion LanguageVersion { get; set; } = LanguageVersion.Default;
    
    protected override CompilationOptions CreateCompilationOptions()
    {
        var compilationOptions = base.CreateCompilationOptions();
        return compilationOptions.WithSpecificDiagnosticOptions(
            compilationOptions.SpecificDiagnosticOptions
                .SetItems(VerifierHelper.NullableWarnings));
    }

    protected override ParseOptions CreateParseOptions()
    {
        return ((CSharpParseOptions)base.CreateParseOptions()).WithLanguageVersion(LanguageVersion);
    }
    
    protected override IEnumerable<Type> GetSourceGenerators()
    {
        yield return typeof(TIncrementalGenerator);
    }
}
