using System.Text.RegularExpressions;

namespace FFXIVClientStructs.MetadataGenerator;

public static class NameHelpers {
    public static string FixTypeName(Type type) {
        var typeMappings = new Dictionary<Type, string> {
            { typeof(void), "void" },
            { typeof(bool), "bool" },
            { typeof(char), "char" },
            { typeof(byte), "byte" },
            { typeof(sbyte), "sbyte" },
            { typeof(short), "short" },
            { typeof(ushort), "ushort" },
            { typeof(int), "int" },
            { typeof(uint), "uint" },
            { typeof(long), "long" },
            { typeof(ulong), "ulong" },
            { typeof(float), "float" },
            { typeof(double), "double" },
            { typeof(nint), "nint" }
        };

        if (typeMappings.TryGetValue(type, out var mappedName)) return mappedName;

        var name = type.FullName!;
        if (type.IsPointer) {
            var pointerCount = 1;
            var pointedTo = type.GetElementType()!;

            while (pointedTo.IsPointer) {
                pointedTo = pointedTo.GetElementType()!;
                pointerCount++;
            }

            if (typeMappings.TryGetValue(pointedTo, out mappedName)) return mappedName + new string('*', pointerCount);
            if (pointedTo.IsGenericType) name = pointedTo.Name.Substring(0, pointedTo.Name.IndexOf('`'));
        }

        if (type.IsGenericType) {
            name = name.Substring(0, name.IndexOf('`'));
        }

        // No source generator, so we have to map these manually
        var mappings = new Dictionary<string, string> {
            { "System.Numerics.Vector3", "Common::Math::Vector3" },
            { "System.Drawing.Point", "Common::Math::Vector2" }
        };
        if (mappings.TryGetValue(name, out var typeName)) return typeName;

        var prefixesToStrip = new[] {
            "FFXIVClientStructs.FFXIV.",
            "FFXIVClientStructs.STD.",
            "FFXIVClientStructs.Interop.",
            "FFXIVClientStructs.Havok."
        };

        foreach (var prefix in prefixesToStrip) {
            if (name.StartsWith(prefix)) name = name.Substring(prefix.Length);
        }

        // Cut off generics
        while (name.Contains('<')) {
            var regex = new Regex(@"<.*>");
            name = regex.Replace(name, "");
        }

        return name
            .Replace(".", "::")
            .Replace("+", "::");
    }
}
