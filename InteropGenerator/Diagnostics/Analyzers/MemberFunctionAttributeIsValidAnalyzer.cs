using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace InteropGenerator.Diagnostics.Analyzers;

[DiagnosticAnalyzer(LanguageNames.CSharp)]
public sealed class MemberFunctionAttributeIsValidAnalyzer() : MethodAttributeIsValidAnalyzerBase(AttributeNames.MemberFunctionAttribute, ImmutableArray<DiagnosticDescriptor>.Empty) {

    protected override void ValidateSpecific(SymbolAnalysisContext context, IMethodSymbol methodSymbol, MethodDeclarationSyntax methodSyntax) { }
}
