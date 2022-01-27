using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System.Runtime.InteropServices;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent
{
    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct AgentContext
    {
        public static AgentContext* Instance() => (AgentContext*)System.Framework.Framework.Instance()->GetUiModule()->GetAgentModule()->GetAgentByInternalId(AgentId.Context);

        [FieldOffset(0x0)] public AgentInterface AgentInterface;
        [FieldOffset(0x0)] public AgentContextInterface AgentContextInterface;
        [FieldOffset(0xD18)] public unsafe AgentContextMenuItems* Items;
        [FieldOffset(0xE08)] public Utf8String GameObjectName;
        [FieldOffset(0xEE0)] public ulong GameObjectContentId;
        [FieldOffset(0xEF0)] public uint GameObjectId;
        [FieldOffset(0xF00)] public ushort GameObjectWorldId;
    }
}
