using System;

namespace FFXIVClientStructs.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class MemberFunctionAttribute : Attribute
{
    public MemberFunctionAttribute(string sig)
    {
        Signature = sig;
    }

    public string Signature { get; }
    public bool IsStatic { get; set; } = false;
    public bool IsPrivate { get; set; } = false;
}