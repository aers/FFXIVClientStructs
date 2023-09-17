using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.Attributes;

[AttributeUsage(AttributeTargets.Struct)]
public class InfoProxyAttribute : Attribute {
    public InfoProxyAttribute(InfoProxyId infoProxyID) {
        ID = infoProxyID;
    }

    public InfoProxyId ID { get; }
}
