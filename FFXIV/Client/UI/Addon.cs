using System;
using System.Collections.Generic;

namespace FFXIVClientStructs.FFXIV.Client.UI {
    public class Addon : Attribute {
        
        public IEnumerable<string> AddonIdentifiers { get; }
        
        public Addon(params string[] addonIdentifiers) {
            AddonIdentifiers = addonIdentifiers;
        }
    }
}
