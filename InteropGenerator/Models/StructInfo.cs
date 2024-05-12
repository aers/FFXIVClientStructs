using InteropGenerator.Helpers;

namespace InteropGenerator.Models;

internal sealed record StructInfo(
    string FullyQualifiedMetadataName,
    string Namespace,
    EquatableArray<string> Hierarchy,
    EquatableArray<MemberFunctionInfo> MemberFunctions,
    EquatableArray<VirtualFunctionInfo> VirtualFunctions,
    EquatableArray<StaticAddressInfo> StaticAddresses) {
    public string Name => Hierarchy[0];
    public bool HasSignatures() => !MemberFunctions.IsEmpty || !StaticAddresses.IsEmpty;
    public bool HasVirtualTable() => !VirtualFunctions.IsEmpty;
}
