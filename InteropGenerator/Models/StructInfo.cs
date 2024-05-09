using InteropGenerator.Helpers;

namespace InteropGenerator.Models;

internal sealed record StructInfo(
    string FullyQualifiedMetadataName,
    string Namespace,
    EquatableArray<string> Hierarchy,
    EquatableArray<MemberFunctionInfo> MemberFunctions,
    EquatableArray<StaticAddressInfo> StaticAddresses) {
    public bool HasSignatures() => !MemberFunctions.IsEmpty || !StaticAddresses.IsEmpty;
    public string Name => Hierarchy[0];
}
