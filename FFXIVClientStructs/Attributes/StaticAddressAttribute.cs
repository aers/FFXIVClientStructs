using System;

namespace FFXIVClientStructs.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class StaticAddressAttribute : Attribute
{
    public StaticAddressAttribute(string sig, int offset = 0, bool isPointer = false)
    {
        Signature = sig;
        Offset = offset;
        IsPointer = isPointer;
    }

    public string Signature { get; }
    public int Offset { get; }
    public bool IsPointer { get; }
}