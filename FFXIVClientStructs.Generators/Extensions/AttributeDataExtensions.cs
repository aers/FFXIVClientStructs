using System.Diagnostics.CodeAnalysis;
using Microsoft.CodeAnalysis;

namespace FFXIVClientStructs.Generators.Extensions;

internal static class AttributeDataExtensions {
    /// <summary>
    ///     Tries to get a constructor argument at a given index from the input <see cref="AttributeData" /> instance.
    /// </summary>
    /// <typeparam name="T">The type of constructor argument to retrieve.</typeparam>
    /// <param name="attributeData">The target <see cref="AttributeData" /> instance to get the argument from.</param>
    /// <param name="index">The index of the argument to try to retrieve.</param>
    /// <param name="result">The resulting argument, if it was found.</param>
    /// <returns>Whether or not an argument of type <typeparamref name="T" /> at position <paramref name="index" /> was found.</returns>
    public static bool TryGetConstructorArgument<T>(this AttributeData attributeData, int index, [NotNullWhen(true)] out T? result) {
        if (attributeData.ConstructorArguments.Length > index &&
            attributeData.ConstructorArguments[index].Value is T argument) {
            result = argument;

            return true;
        }

        result = default;

        return false;
    }
}
