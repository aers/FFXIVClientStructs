using InteropGenerator.Helpers;

namespace InteropGenerator.Models;

internal sealed record ExtraInheritedStructInfo(
    EquatableArray<FieldInfo> PublicFields,
    EquatableArray<MethodInfo> PublicMethods,
    EquatableArray<PropertyInfo> PublicProperties);
