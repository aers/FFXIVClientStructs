namespace FFXIVClientStructs.ResolverTester;

public class Data {
    public string Version { get; set; }
    public Dictionary<string, string> Globals { get; set; }
    public Dictionary<string, string> Functions { get; set; }
    public Dictionary<string, Class> Classes { get; set; }
}

public class Class {
    public Dictionary<string, string> Funcs { get; set; }
    public Dictionary<string, string> Vfuncs { get; set; }
    public List<Instance> Instances { get; set; }
    public List<Vtbl> Vtbls { get; set; }
}

public class Instance {
    public string Ea { get; set; }
    public string Name { get; set; }
    public bool Pointer { get; set; }
}

public class Vtbl {
    public string Ea { get; set; }
    public string Base { get; set; }
}
