using InteropGenerator.Helpers;

namespace InteropGenerator.Models;

internal sealed record ExtraInheritedStructInfo(
    int Size,
    EquatableArray<FieldInfo> PublicFields,
    EquatableArray<MethodInfo> PublicMethods);
