using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace FFXIVClientStructs.InteropGenerator;

internal static class EmbeddedSources
{
    private static readonly Assembly ThisAssembly = typeof(EmbeddedSources).Assembly;
    private static readonly string EmbeddedSourcePath = "FFXIVClientStructs.InteropGenerator.EmbeddedSource";

    internal static readonly string AttributeNamespace = "FFXIVClientStructs.GeneratedAttributes";

    internal static class MemberFunctionAttribute
    {
        internal static readonly string Name = "MemberFunctionAttribute";
        internal static readonly string FullName = $"{AttributeNamespace}.{Name}";

        internal static readonly string Source = LoadEmbeddedResource($"{EmbeddedSourcePath}.{Name}.cs");
    }

    internal static class VirtualFunctionAttribute
    {
        internal static readonly string Name = "VirtualFunctionAttribute";
        internal static readonly string FullName = $"{AttributeNamespace}.{Name}";

        internal static readonly string Source = LoadEmbeddedResource($"{EmbeddedSourcePath}.{Name}.cs");
    }

    private static string LoadEmbeddedResource(string resourceName)
    {
        var resourceStream = ThisAssembly.GetManifestResourceStream(resourceName);
        if (resourceStream is null)
        {
            var existingResources = ThisAssembly.GetManifestResourceNames();
            throw new ArgumentException($"Could not find embedded resource {resourceName}. Available names: {string.Join(", ", existingResources)}");
        }

        using var reader = new StreamReader(resourceStream, Encoding.UTF8);

        return reader.ReadToEnd();
    }
}