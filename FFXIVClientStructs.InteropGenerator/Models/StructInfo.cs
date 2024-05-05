using FFXIVClientStructs.InteropGenerator.Helpers;

namespace FFXIVClientStructs.InteropGenerator.Models;

internal sealed record StructInfo(
    string FullyQualifiedMetadataName,
    string Namespace,
    EquatableArray<string> Hierarchy);
