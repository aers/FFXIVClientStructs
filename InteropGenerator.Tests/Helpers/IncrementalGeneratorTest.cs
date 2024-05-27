using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;

namespace InteropGenerator.Tests.Helpers;

internal sealed class IncrementalGeneratorTest<TIncrementalGenerator> : CSharpSourceGeneratorTest<EmptySourceGeneratorProvider, DefaultVerifier>
    where TIncrementalGenerator : IIncrementalGenerator, new() {

    private readonly LanguageVersion _languageVersion = LanguageVersion.Default;

    protected override CompilationOptions CreateCompilationOptions() {
        CompilationOptions compilationOptions = base.CreateCompilationOptions();
        return compilationOptions.WithSpecificDiagnosticOptions(
            compilationOptions.SpecificDiagnosticOptions
                .SetItems(VerifierHelper.NullableWarnings));
    }

    protected override ParseOptions CreateParseOptions() => ((CSharpParseOptions)base.CreateParseOptions()).WithLanguageVersion(_languageVersion);

    protected override IEnumerable<Type> GetSourceGenerators() {
        yield return typeof(TIncrementalGenerator);
    }
}
