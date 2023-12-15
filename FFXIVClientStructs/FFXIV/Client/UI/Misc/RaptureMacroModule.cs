using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureMacroModule
//   Client::UI::Misc::UserFileManager::UserFileEvent
// ctor "E8 ?? ?? ?? ?? 48 8D B7 ?? ?? ?? ?? 4C 8B C7"
[StructLayout(LayoutKind.Explicit, Size = 0x51AA8)]
public unsafe partial struct RaptureMacroModule {
    public static RaptureMacroModule* Instance() => UIModule.Instance()->GetRaptureMacroModule();

    [FieldOffset(0)] public UserFileEvent UserFileEvent;
    [FieldOffset(0x40)] public RaptureTextModule* RaptureTextModule;
    //[FieldOffset(0x48)] public TextChecker* TextChecker;

    [FixedSizeArray<Macro>(100)]
    [FieldOffset(0x58)] public fixed byte Individual[100 * 0x688];
    [FixedSizeArray<Macro>(100)]
    [FieldOffset(0x28D78)] public fixed byte Shared[100 * 0x688];

    [MemberFunction("E8 ?? ?? ?? ?? 32 DB 83 C6 F9")]
    public partial Macro* GetMacro(uint set, uint index);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 44 8B 83 ?? ?? ?? ??")]
    public partial void ReplaceMacroLines(Macro* macro, Utf8String* lines);

    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 87 ?? ?? ?? ?? B2 01")]
    public partial void AppendMacroLines(Macro* macro, Utf8String* lines);

    [MemberFunction("E8 ?? ?? ?? ?? 83 F8 0F B9 ?? ?? ?? ??")]
    public partial uint GetLineCount(Macro* macro);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? E8 ?? ?? ?? ?? 48 8D 8C 24 ?? ?? ?? ?? E8 ?? ?? ?? ?? 41 FE C7")]
    public partial void SetMacroLines(Macro* macro, int lineStartIndex, Utf8String* lines);

    /// <summary>
    /// Sets a flag to mark the macro file as needing a save. Fires on any macro update, generally prior to saving.
    /// </summary>
    /// <param name="needsSave">A boolean denoting if the specified set needs to be saved.</param>
    /// <param name="set">The macro page ID that needs saving.</param>
    [MemberFunction("45 85 C0 75 04 88 51 3D")]
    public partial void SetSavePendingFlag(bool needsSave, uint set);

    [StructLayout(LayoutKind.Explicit, Size = 0x688)]
    public partial struct Macro {
        [FieldOffset(0)] public uint IconId;
        [FieldOffset(0x4)] public uint MacroIconRowId; // offset by +1
        [FieldOffset(0x8)] public Utf8String Name;
        [FixedSizeArray<Utf8String>(15)]
        [FieldOffset(0x70)] public fixed byte Lines[15 * 0x68];

        /// <summary>
        /// Set the Icon of this Macro and also sets the correct MacroIconRowId
        /// </summary>
        /// <param name="iconId">The icon ID that this macro should now use </param>
        [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 8B FA 89 11")]
        public partial void SetIcon(uint iconId);

        [MemberFunction("E8 ?? ?? ?? ?? 49 8B CE E8 ?? ?? ?? ?? 48 8B 4D")]
        public partial Macro* Copy(Macro* other);

        [MemberFunction("E8 ?? ?? ?? ?? 48 63 96 ?? ?? ?? ?? 83 FA")]
        public partial void Clear();

        [MemberFunction("E8 ?? ?? ?? ?? 48 8B 4F ?? 84 C0 48 8B 01 75")]
        public partial bool IsEmpty();
    }
}
