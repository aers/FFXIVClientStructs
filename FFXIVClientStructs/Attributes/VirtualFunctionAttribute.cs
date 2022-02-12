using System;

namespace FFXIVClientStructs.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class VirtualFunctionAttribute : Attribute
{
    public VirtualFunctionAttribute(int offset)
    {
        Offset = offset;
    }

    public int Offset { get; }
}