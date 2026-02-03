using InteropGenerator.Helpers;

namespace InteropGenerator.Models; 

internal record BitFieldInfo(
    string FieldName,
    string Name, 
    string Type,
    string BackingType,
    int Index,
    int Length,
    bool IsPartial,
    bool HasGetter,
    bool HasSetter,
    EquatableArray<string> InheritableAttributes
);
