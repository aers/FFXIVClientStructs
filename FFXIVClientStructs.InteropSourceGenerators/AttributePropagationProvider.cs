using System.Collections.Immutable;
using System.Text;
using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.InteropSourceGenerators;

public class AttributePropagationProvider(ISymbol symbol) {

    private static readonly ImmutableArray<string> AttributesToPropagate = ImmutableArray.Create(["global::System.ObsoleteAttribute"]);
    
    public string Output => Build();

    private string Build() {
        StringBuilder output = new StringBuilder();
        
        foreach (var attribute in symbol.GetAttributes()) {
            if(attribute.AttributeClass is null) continue;
            string attributeText = attribute.AttributeClass.ToDisplayString(SymbolDisplayFormat.MinimallyQualifiedFormat)[..^9];
            string fullyClassifiedTypeNAme = attribute.AttributeClass.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
            if(!AttributesToPropagate.Contains(fullyClassifiedTypeNAme)) continue;
            output.Append($"[{attributeText}");
            bool hasArguments = attribute.ConstructorArguments.Any() || attribute.NamedArguments.Any();
            if (hasArguments) output.Append("(");
            if (attribute.ConstructorArguments.Any()) {
                output.Append(string.Join(", ",attribute.ConstructorArguments.Map(FormatArgument)));
                if (attribute.NamedArguments.Any())
                    output.Append(", ");
            }
            if (attribute.NamedArguments.Any()) {
                output.Append(string.Join(", ", attribute.NamedArguments.Map(arg => $"{arg.Key} = {FormatArgument(arg.Value)}")));
            }
            if (hasArguments) output.Append(")");
            output.Append("]");
        }
        
        return output.ToString();
    }
    private static string FormatArgument(TypedConstant arg) => arg.Type?.Name switch {
        "String"  => $"\"{arg.Value}\"",
        _ => $"{arg.Value}"
    };
}
