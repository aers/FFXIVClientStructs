namespace FFXIVClientStructs.Generators.FunctionGenerator
{
    internal static class Templates
    {
        internal const string MemberFunctions = @"using System;
{{ if struct.has_ctor }}using FFXIVClientStructs.FFXIV.Client.System.Memory;{{ end }}

namespace {{ struct.namespace }} {
    public unsafe partial struct {{ struct.name }} {{ if struct.has_ctor }}: ICreatable {{ end }}{
        {{~ for mf in struct.member_functions ~}}
        public static delegate* unmanaged[Stdcall] <{{ if !mf.is_static }}{{ struct.name }}*,{{ end }}{{ if mf.has_params }}{{ mf.param_type_list }},{{ end }}{{ if mf.has_bool_return }}byte{{ else }}{{ mf.return_type }}{{ end }}> fp{{ mf.name }} { internal set; get; }

        public{{ if mf.is_static }} static{{ end }} partial {{ mf.return_type }} {{ mf.name }}({{ mf.param_list }})
        {
            if (fp{{ mf.name }} is null)
            {
                throw new InvalidOperationException(""Function pointer for {{ struct.name }}::{{ mf.name }} is null. Did you forget to call Resolver.Initialize?"");
            }
{{ if !mf.is_static }}
            fixed({{ struct.name }}* thisPtr = &this)
            {
{{ end }}
                {{ if mf.has_return }}return {{ end }}fp{{ mf.name }}({{ if !mf.is_static }}thisPtr{{ end }}{{ if mf.has_params }}{{ if !mf.is_static }}, {{ end }}{{ mf.param_name_list }}{{ end }}){{ if mf.has_bool_return }} != 0{{ end }};
{{ if !mf.is_static }}
            }
{{ end }}
        }
        {{~ end ~}}
    }       
}";

        internal const string InitializeMemberFunctions = @"using System.Collections.Generic;

using Serilog;

namespace FFXIVClientStructs {
    public unsafe static partial class Resolver {
        private static void InitializeMemberFunctions(SigScanner s)
        {
            {{~ for struct in structs ~}}
            {{~ for mf in struct.member_functions ~}}
            try {
                var address{{ struct.name }}{{ mf.name }} = s.ScanText(""{{ mf.signature }}"");
                {{ struct.namespace }}.{{ struct.name }}.fp{{ mf.name }} = (delegate* unmanaged[Stdcall] <{{ if !mf.is_static }}{{ struct.namespace }}.{{ struct.name }}*,{{ end }}{{ if mf.has_params }}{{ mf.param_type_list }},{{ end }}{{ if mf.has_bool_return }}byte{{ else }}{{ mf.return_type }}{{ end }}>) address{{ struct.name }}{{ mf.name }};
            } catch (KeyNotFoundException) {
                Log.Warning($""[FFXIVClientStructs] function {{ struct.name }}::{{ mf.name }} failed to match signature {{ mf.signature }} and is unavailable"");
            }
            {{~ end ~}}
            {{~ end ~}}
        }
    }
}";

        internal const string VirtualFunctions = @"using System;
using System.Runtime.InteropServices;

namespace {{ struct.namespace }} {
    public unsafe partial struct {{ struct.name }} {
        [StructLayout(LayoutKind.Explicit)]
        public unsafe struct {{ struct.name }}VTable {
            {{~ for vf in struct.virtual_functions ~}}
            [FieldOffset({{ vf.virtual_offset * 8 }})] public delegate* unmanaged[Stdcall] <{{ struct.name }}*,{{ if vf.has_params }}{{ vf.param_type_list }},{{ end }}{{ if vf.has_bool_return }}byte{{ else }}{{ vf.return_type }}{{ end }}> {{ vf.name }};
            {{~ end ~}}
        }

        [FieldOffset(0x0)] public {{ struct.name }}VTable* VTable;

        {{~ for vf in struct.virtual_functions ~}}
        public partial {{ vf.return_type }} {{ vf.name}}({{ vf.param_list }})
        {
            fixed({{ struct.name }}* thisPtr = &this)
            {
                {{ if vf.has_return }}return {{ end }}VTable->{{ vf.name }}(thisPtr{{ if vf.has_params }}, {{ vf.param_name_list }}{{ end }}){{ if vf.has_bool_return }} != 0{{ end }};
            }
        }
        {{~ end ~}}
    }
}";

    }
}
