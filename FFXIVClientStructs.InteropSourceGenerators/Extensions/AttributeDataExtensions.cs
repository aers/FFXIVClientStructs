using System.Collections.Immutable;
using LanguageExt;
using Microsoft.CodeAnalysis;
using static LanguageExt.Prelude;

namespace FFXIVClientStructs.InteropSourceGenerators.Extensions;

internal static class AttributeDataExtensions
{
    public static Option<T> GetAttributeArgument<T>(this AttributeData attributeData, string argumentName,
        int argumentIndex)
    {
        // [Attribute("??")]
        // [Attribute(name: "??")]
        if (attributeData.ConstructorArguments.Any())
        {
            if (argumentIndex > attributeData.ConstructorArguments.Length)
                return None;

            ImmutableArray<TypedConstant> args = attributeData.ConstructorArguments;

            return args[argumentIndex].IsNull ? None : Some((T)args[argumentIndex].Value!);
        }

        // [Attribute(argumentName = "??")]
        if (attributeData.NamedArguments.Any())
            foreach (KeyValuePair<string, TypedConstant> namedArgument in attributeData.NamedArguments)
                if (namedArgument.Key == argumentName)
                    return namedArgument.Value.IsNull ? None : Some((T)namedArgument.Value.Value!);

        return None;
    }
}