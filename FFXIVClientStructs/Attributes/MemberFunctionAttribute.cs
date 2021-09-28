using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MemberFunctionAttribute : Attribute
    {
        public string Signature { get; }
        public bool IsStatic { get; set; } = false;

        public MemberFunctionAttribute(string sig)
        {
            this.Signature = sig;
        }
    }
}
