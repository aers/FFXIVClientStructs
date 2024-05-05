using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

namespace FFXIVClientStructs.InteropGenerator.Tests.Helpers;

internal sealed class AnalyzerTest<TAnalyzer> : CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> where TAnalyzer : DiagnosticAnalyzer, new() {
    private readonly LanguageVersion _languageVersion  = LanguageVersion.Default;

    protected override ParseOptions CreateParseOptions() {
        return ((CSharpParseOptions)base.CreateParseOptions()).WithLanguageVersion(_languageVersion).WithDocumentationMode(DocumentationMode.Diagnose);
    }
}
