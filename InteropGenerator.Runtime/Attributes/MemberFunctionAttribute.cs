namespace InteropGenerator.Runtime.Attributes;

/// <summary>
/// Marks a method as a stub for a native class member function.
/// </summary>
[AttributeUsage(AttributeTargets.Method)]
public sealed class MemberFunctionAttribute(string signature) : Attribute {
    public string Signature { get; } = signature;
}
