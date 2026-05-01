using InteropGenerator.Helpers;
using Microsoft.CodeAnalysis;

namespace InteropGenerator.Models;

internal record BitFieldInfo(
    string FieldName,
    string Name,
    string Type,
    string BackingType,
    int Index,
    int Length,
    Accessibility Accessibility,
    bool IsPartial,
    bool HasGetter,
    bool HasSetter,
    EquatableArray<string> InheritableAttributes
);
