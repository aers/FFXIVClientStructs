using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class VirtualFunctionAttribute : Attribute
    {
        public int Offset { get; }

        public VirtualFunctionAttribute(int offset)
        {
            this.Offset = offset;
        }
    }
}
