namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x1E0)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 01 33 D2 89 51 18", 3)]
public partial struct CharacterLookAtControlParam {
    [FieldOffset(0x10)] public CharacterLookAtTargetParam TargetParam;
}
