using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::RaptureMacroModule
// ctor E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 4C 8B C7 49 8B D5 E8 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 4C 8B C7
[StructLayout(LayoutKind.Explicit, Size = 0x51AA8)]
public unsafe partial struct RaptureMacroModule
{
    public static RaptureMacroModule* Instance => Framework.Instance()->GetUiModule()->GetRaptureMacroModule();

    [StructLayout(LayoutKind.Sequential, Size = 0x688)]
    public struct Macro
    {
        public uint IconId;
        public uint Unk; // MacroIcon, exclusive of /micon or similar. Oddly, off by one from Lumina's table.
        public Utf8String Name;
        public Lines Line;

        [StructLayout(LayoutKind.Sequential, Size = 0x618)]
        public struct Lines
        {
            private fixed byte data[0x618];

            public Utf8String* this[int i]
            {
                get
                {
                    if (i < 0 || i > 14) return null;
                    fixed (byte* p = data)
                    {
                        return (Utf8String*) (p + sizeof(Utf8String) * i);
                    }
                }
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 0x28D20)]
    public struct MacroPage
    {
        private fixed byte data[0x28D20];

        public Macro* this[int i]
        {
            get
            {
                if (i < 0 || i > 99) return null;
                Macro* a;
                fixed (byte* p = data)
                {
                    a = (Macro*) (p + 0x688 * i);
                }

                return a;
            }
        }
    }

    [FieldOffset(0x58)] public MacroPage Individual;
    [FieldOffset(0x28D78)] public MacroPage Shared;

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
}