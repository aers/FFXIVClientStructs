using System.Collections.Generic;

namespace FFXIVClientStructs.Generators.StaticAddressGenerator
{
    internal class Struct
    {
        public string Namespace;
        public string Name;
        public List<StaticAddress> Addresses;
    }

    internal class StaticAddress
    {
        public string Name;
        public string Type;
        public string Signature;
        public int Offset;
        public bool IsPointer;
    }
}