using FFXIVClientStructs.FFXIV.Client.UI.Info;

namespace FFXIVClientStructs.Attributes;

[AttributeUsage(AttributeTargets.Struct)]
public class InfoProxyAttribute(InfoProxyId infoProxyId) : Attribute {

    public InfoProxyId InfoProxyId { get; } = infoProxyId;
}
