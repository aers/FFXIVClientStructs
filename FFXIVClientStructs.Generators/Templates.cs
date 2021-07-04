using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.Generators
{
    internal static class Templates
    {
        internal static string MemberFunctions = @"
namespace {{ struct.namespace }} {
    public unsafe partial struct {{ struct.name }} {
        {{ for mf in struct.member_functions }}
        public static delegate* unmanaged[Fastcall] <{{ struct.name }}*,{{ mf.param_type_list }},{{ mf.return_type }}> fp{{ mf.name }} { internal set; get; }

        public partial {{ mf.return_type }} {{ mf.name }}({{ mf.param_list }})
        {
            fixed({{ struct.name }}* thisPtr = &this)
            {
                {{ if mf.has_return }}return {{ end }}fp{{ mf.name }}(thisPtr, {{ mf.param_name_list }});
            }
        }{{ end }}
    }       
}";
    }
}
