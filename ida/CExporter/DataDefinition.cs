using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CExporter;
public class DataDefinition {
    public string version;
    public Dictionary<ulong, string> globals;
    public Dictionary<ulong, string> functions;
    public Dictionary<string, DataClassDefinition> classes;
}

public class DataClassDefinition {
    public List<DataVTblDefinition> vtbls;
    public Dictionary<ulong, string> vfuncs;
    public Dictionary<ulong, string>? funcs;
}

public class DataVTblDefinition {
    public ulong ea;
    public string @base;
}
