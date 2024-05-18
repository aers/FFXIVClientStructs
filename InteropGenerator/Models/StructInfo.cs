using InteropGenerator.Helpers;

namespace InteropGenerator.Models;

internal sealed record StructInfo(
    string FullyQualifiedMetadataName,
    string Namespace,
    EquatableArray<string> Hierarchy,
    EquatableArray<MemberFunctionInfo> MemberFunctions,
    EquatableArray<VirtualFunctionInfo> VirtualFunctions,
    EquatableArray<StaticAddressInfo> StaticAddresses,
    SignatureInfo? StaticVirtualTableSignature,
    EquatableArray<FixedSizeArrayInfo> FixedSizeArrays) {
    public string Name => Hierarchy[0];
    public bool HasSignatures() => !MemberFunctions.IsEmpty || !StaticAddresses.IsEmpty || StaticVirtualTableSignature is not null;
    public bool HasVirtualTable() => !VirtualFunctions.IsEmpty || StaticVirtualTableSignature is not null;
}
