using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.Common
{
    [AttributeUsage(AttributeTargets.Method)]
    public class MemberFunctionAttribute : Attribute
    {
        public string Signature { get; }

        public MemberFunctionAttribute(string sig)
        {
            this.Signature = sig;
        }
    }
}
