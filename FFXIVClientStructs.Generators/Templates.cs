using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.Generators
{
    internal static class Templates
    {
        internal static string MemberFunctions = @"
using System;

namespace {{ struct.namespace }} {
    public unsafe partial struct {{ struct.name }} {
        {{ for mf in struct.member_functions }}
        public static delegate* unmanaged[Stdcall] <{{ struct.name }}*,{{ if mf.has_params }}{{ mf.param_type_list }},{{ end }}{{ mf.return_type }}> fp{{ mf.name }} { internal set; get; }

        public partial {{ mf.return_type }} {{ mf.name }}({{ mf.param_list }})
        {
            if (fp{{ mf.name }} is null)
            {
                throw new InvalidOperationException(""Function pointer for {{ struct.name }}::{{ mf.name }} is null."");
            }
            fixed({{ struct.name }}* thisPtr = &this)
            {
                {{ if mf.has_return }}return {{ end }}fp{{ mf.name }}(thisPtr{{ if mf.has_params }}, {{ mf.param_name_list }}{{ end }});
            }
        }{{ end }}
    }       
}";

        internal static string InitializeMemberFunctions = @"
using System.Collections.Generic;

using Serilog;

namespace FFXIVClientStructs {
    public unsafe static partial class Resolver {
        private static void InitializeMemberFunctions(SigScanner s)
        {
            {{ for struct in structs }}
            {{ for mf in struct.member_functions }}
            try {
                var address{{ struct.name }}{{ mf.name }} = s.ScanText(""{{ mf.signature }}"");
                {{ struct.namespace }}.{{ struct.name }}.fp{{ mf.name }} = (delegate* unmanaged[Stdcall] <{{ struct.namespace }}.{{ struct.name }}*,{{ if mf.has_params }}{{ mf.param_type_list }},{{ end }}{{ mf.return_type }}>) address{{ struct.name }}{{ mf.name }};
            } catch (KeyNotFoundException) {
                Log.Warning($""[FFXIVClientStructs] function {{ struct.name }}::{{ mf.name }} failed to match signature {{ mf.signature }} and is unavailable"");
            }
            {{ end }}
            {{ end }}
        }
    }
}";

        internal static string VirtualFunctions = @"
using System;
using System.Runtime.InteropServices;

namespace {{ struct.namespace }} {
    public unsafe partial struct {{ struct.name }} {
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct {{ struct.name }}VTable {
            {{ for vf in struct.virtual_functions }}
            [FieldOffset({{ vf.virtual_offset * 8 }})] public delegate* unmanaged[Stdcall] <{{ struct.name }}*,{{ if vf.has_params }}{{ vf.param_type_list }},{{ end }}{{ vf.return_type }}> {{ vf.name }};
            {{ end }}
        }

        [FieldOffset(0x0)] public {{ struct.name }}VTable* VTable;

        {{ for vf in struct.virtual_functions }}
        public partial {{ vf.return_type }} {{ vf.name}}({{ vf.param_list }})
        {
            fixed({{ struct.name }}* thisPtr = &this)
            {
                {{ if vf.has_return }}return {{ end }}VTable->{{ vf.name }}(thisPtr{{ if vf.has_params }}, {{ vf.param_name_list }}{{ end }});
            }
        }
        {{ end }}
    }
}";
    }
}
