using EventHandler = FFXIVClientStructs.FFXIV.Client.Game.Event.EventHandler;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::EventObject
//   Client::Game::Object::GameObject
[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
public unsafe partial struct EventObject {
    [FieldOffset(0x1A0), CExporterExcel("EObj")] public nint EObjRowPtr;
    [FieldOffset(0x1A8), CExporterExcel("ExportedSG")] public nint ExportedSGRowPtr;
    [FieldOffset(0x1B2)] public ushort SharedTimelineState; // ActorControl category 0x199 (SetSharedTimelineState) sets this field
    [FieldOffset(0x1B8)] public byte Flags;

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 4D 85 F6 0F 84 ?? ?? ?? ?? 8B 44 24 70 BE ?? ?? ?? ??")]
    public partial void PlayAnimation(uint entityId, uint actionId, ulong unknown);

    /// <param name="outHandlers">Should point to array that can fit up to 32 pointers.</param>
    /// <returns>Num elements filled.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 4D 85 F6 0F 84 ?? ?? ?? ?? 8B 44 24 70 BE ?? ?? ?? ??")]
    public partial int GetEventHandlers(EventHandler** outHandlers);
}
