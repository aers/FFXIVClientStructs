namespace FFXIVClientStructs.Attributes;

[AttributeUsage(AttributeTargets.Struct)]
public class AddonAttribute(params string[] addonIdentifiers) : Attribute {
    public IEnumerable<string> AddonIdentifiers { get; } = addonIdentifiers;
}
