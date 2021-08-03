using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FFXIVClientStructs.Generators.StaticAddressGenerator
{
    internal class StaticAddressSyntaxContextReceiver : ISyntaxContextReceiver
    {
        public List<Struct> Structs { get; } = new();

        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if (context.Node is not StructDeclarationSyntax sds) return;
            var methods = sds.ChildNodes().OfType<MethodDeclarationSyntax>().Where(m =>
            {
                var sm = (IMethodSymbol) context.SemanticModel.GetDeclaredSymbol(m);
                return sm != null && sm.GetAttributes()
                    .Any(a => a.AttributeClass?.Name is "StaticAddressAttribute");
            }).ToList();

            if (methods.Count <= 0) return;

            if (context.SemanticModel.GetDeclaredSymbol(sds) is not INamedTypeSymbol structType) return;

            var structObj = new Struct
            {
                Name = structType.Name, Namespace = structType.ContainingNamespace.ToDisplayString(),
                Addresses = new List<StaticAddress>()
            };

            foreach (var m in methods)
            {
                if (context.SemanticModel.GetDeclaredSymbol(m) is not IMethodSymbol ms) continue;
                var format = new SymbolDisplayFormat(
                    typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,
                    miscellaneousOptions: SymbolDisplayMiscellaneousOptions.UseSpecialTypes);
                var addressObj = new StaticAddress
                {
                    Name = ms.Name,
                    Type = ms.ReturnType.ToDisplayString(format)
                };
                if (ms.GetAttributes().FirstOrDefault(a => a.AttributeClass?.Name == "StaticAddressAttribute") is
                    { } staticAddressAttr)
                {
                    addressObj.Signature = (string)staticAddressAttr.ConstructorArguments[0].Value;
                    addressObj.Offset = (int)staticAddressAttr.ConstructorArguments[1].Value;
                    addressObj.IsPointer = (bool)staticAddressAttr.ConstructorArguments[2].Value;
                    structObj.Addresses.Add(addressObj);
                }
            }
            
            Structs.Add(structObj);
        }
    }
}