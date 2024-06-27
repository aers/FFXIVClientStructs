using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureMacroModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D B7 ?? ?? ?? ?? 4C 8B C7"
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x51AA8)]
public unsafe partial struct RaptureMacroModule {
    public static RaptureMacroModule* Instance() => UIModule.Instance()->GetRaptureMacroModule();

    [FieldOffset(0x40)] public RaptureTextModule* RaptureTextModule;
    //[FieldOffset(0x48)] public TextChecker* TextChecker;

    [FieldOffset(0x58), FixedSizeArray] internal FixedSizeArray100<Macro> _individual;
    [FieldOffset(0x28D78), FixedSizeArray] internal FixedSizeArray100<Macro> _shared;

    [MemberFunction("E8 ?? ?? ?? ?? 32 DB 83 C6 F9")]
    public partial Macro* GetMacro(uint set, uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 44 8B 83 ?? ?? ?? ?? B2 01")]
    public partial void ReplaceMacroLines(Macro* macro, Utf8String* lines);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 83 ?? ?? ?? ?? B2 01 49 8B CE")]
    public partial void AppendMacroLines(Macro* macro, Utf8String* lines);

    [MemberFunction("E8 ?? ?? ?? ?? 8B F8 85 C0 7E 35")]
    public partial uint GetLineCount(Macro* macro);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 8C 24 ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8C 24 ?? ?? ?? ?? E8 ?? ?? ?? ?? 41 FE C5")]
    public partial void SetMacroLines(Macro* macro, int lineStartIndex, Utf8String* lines);

    /// <summary>
    /// Sets a flag to mark the macro file as needing a save. Fires on any macro update, generally prior to saving.
    /// </summary>
    /// <param name="needsSave">A boolean denoting if the specified set needs to be saved.</param>
    /// <param name="set">The macro page ID that needs saving.</param>
    [MemberFunction("45 85 C0 75 04 88 51 3D")]
    public partial void SetSavePendingFlag(bool needsSave, uint set);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x688)]
    public partial struct Macro {
        [FieldOffset(0)] public uint IconId;
        [FieldOffset(0x4)] public uint MacroIconRowId; // offset by +1
        [FieldOffset(0x8)] public Utf8String Name;
        [FieldOffset(0x70), FixedSizeArray] internal FixedSizeArray15<Utf8String> _lines;

        /// <summary>
        /// Set the Icon of this Macro and also sets the correct MacroIconRowId
        /// </summary>
        /// <param name="iconId">The icon ID that this macro should now use </param>
        [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 8B FA 89 11")]
        public partial void SetIcon(uint iconId);

        [MemberFunction("E8 ?? ?? ?? ?? 45 84 ED 48 8D 8B ?? ?? ?? ??")]
        public partial Macro* Copy(Macro* other);

        [MemberFunction("E8 ?? ?? ?? ?? 49 63 97 ?? ?? ?? ?? 83 FA 11")]
        public partial void Clear();

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4D 10 0F B6 9D ?? ?? ?? ??")]
        public partial bool IsEmpty();
    }
}
