namespace InteropGenerator.Models;

internal sealed record InheritanceInfo(
    string FullInheritedTypeName,
    string InheritedTypeName,
    int ParentOffset,
    SignatureInfo? StaticVirtualTableSignature);
