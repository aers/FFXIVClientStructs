namespace FFXIVClientStructs.Interop.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class MemberFunctionAttribute : Attribute
{
    public MemberFunctionAttribute(string signature)
    {
        this.Signature = signature;
    }

    public string Signature { get; }
}