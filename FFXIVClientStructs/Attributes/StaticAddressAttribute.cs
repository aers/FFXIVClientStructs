using System;

namespace FFXIVClientStructs.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class StaticAddressAttribute : Attribute
    {
        public string Signature { get; }
        public int Offset { get;  } 
        public bool IsPointer { get; }

        public StaticAddressAttribute(string sig, int offset = 0, bool isPointer = false)
        {
            this.Signature = sig;
            this.Offset = offset;
            this.IsPointer = isPointer;
        }

    }
}