using System;
using System.Collections.Generic;

namespace FFXIVClientStructs.Attributes
{
    public class Addon : Attribute
    {
        public Addon(params string[] addonIdentifiers)
        {
            AddonIdentifiers = addonIdentifiers;
        }

        public IEnumerable<string> AddonIdentifiers { get; }
    }
}