namespace FFXIVClientStructs.Generators.StaticAddressGenerator
{
    internal static class Templates
    {
        internal const string StaticAddresses = @"using System;

namespace {{ struct.namespace }} {
    public unsafe partial struct {{ struct.name }} {
        {{~ for sa in struct.addresses ~}}
        public static {{ sa.type }} p{{ sa.name }} { internal set; get; }

        public static partial {{ sa.type }} {{ sa.name }}()
        {
            if (p{{ sa.name }} is null)
            {
                throw new InvalidOperationException(""Static pointer for {{ struct.name }}::{{ sa.name }} is null. Did you forget to call Resolver.Initialize?"");
            }
            
            return p{{ sa.name }};
        }
    {{~ end ~}}
    }
}";

        internal const string InitializeStaticAddresses = @"using System.Collections.Generic;
using Serilog;

namespace FFXIVClientStructs {
    public unsafe static partial class Resolver {
        private static void InitializeStaticAddresses(SigScanner s)
        {
            {{~ for struct in structs ~}}
            {{~ for sa in struct.addresses ~}}
            try {
                var address{{ struct.name }}{{ sa.name }} = s.GetStaticAddressFromSig(""{{ sa.signature }}"", {{ sa.offset }});
                {{ struct.namespace }}.{{ struct.name }}.p{{ sa.name }} = {{ if sa.is_pointer }}*{{ end }}({{ sa.type }}{{ if sa.is_pointer }}*{{ end }})address{{ struct.name }}{{ sa.name }};
            } catch (KeyNotFoundException) {
                Log.Warning($""[FFXIVClientStructs] static address {{ struct.name }}::{{ sa.name }} failed to match signature {{ sa.signature }} and is unavailable"");
            }
            {{~ end ~}}
            {{~ end ~}}
        }
    }
}";
    }
}