using System.Collections.Generic;

namespace FFXIVClientStructs.Generators
{
    internal class Struct
    {
        public string Namespace;
        public string Name;
        public List<Function> MemberFunctions;
        public List<Function> VirtualFunctions;
    }

    internal class Function
    {
        public string Name;
        public bool HasReturn;
        public string ReturnType;
        public bool HasParams;
        public string ParamList;
        public string ParamTypeList;
        public string ParamNameList;
        public string Signature;
        public int VirtualOffset;
        public bool IsStatic;
    }
}
