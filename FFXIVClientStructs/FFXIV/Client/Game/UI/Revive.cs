using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public struct Revive
{
    [FieldOffset(0x00)] public AtkEventInterface AtkEventInterface;

    //[FieldOffset(0x10)] public byte Stage;
    [FieldOffset(0x14)] public float Timer;
    [FieldOffset(0x24)] public byte ReviveState;
}