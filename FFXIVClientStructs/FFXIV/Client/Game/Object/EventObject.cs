namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::EventObject
//   Client::Game::Object::GameObject
[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
public partial struct EventObject {
    [FieldOffset(0x1A0), CExporterExcel("EObj")] public nint EObjRowPtr;
    [FieldOffset(0x1A8), CExporterExcel("ExportedSG")] public nint ExportedSGRowPtr;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 4D 85 F6 0F 84 ?? ?? ?? ?? 8B 44 24 70 BE ?? ?? ?? ??")]
    public partial void PlayAnimation(uint entityId, uint actionId, ulong unknown);
}
