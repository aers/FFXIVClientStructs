namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::EventObject
//   Client::Game::Object::GameObject
[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
public partial struct EventObject {
    [FieldOffset(0x1A0), CExporterExcel("EObj")] public nint EObjRowPtr;
    [FieldOffset(0x1A8), CExporterExcel("ExportedSG")] public nint ExportedSGRowPtr;
    [FieldOffset(0x1B2)] public ushort SharedTimelineState; // ActorControl category 0x199 (SetSharedTimelineState) sets this field
    [FieldOffset(0x1B8)] public byte Flags;

    /// <summary> Plays or switches an EObj animation/effect slot. </summary>
    /// <param name="sharedTimelineState"> Similar to MapEffect's a2. Does not appear to affect the actual visible animation directly. </param>
    /// <param name="bitMask"> Similar to MapEffect's a3. Each bit represents one animation (e.g. show, fadeout). Appears to use only single-bit values. </param>
    /// <remarks>
    /// EObjAnimation is highly similar to MapEffect; MapEffect appears to be a wrapped form of this mechanism.
    /// Different scene-bound resources attached to an EObj are roughly equivalent to MapEffect's a1.
    /// </remarks>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 4D 85 F6 0F 84 ?? ?? ?? ?? 8B 44 24 70 BE ?? ?? ?? ??")]
    public partial void PlayAnimation(ushort sharedTimelineState, ushort bitMask, ulong context = 0);
}
