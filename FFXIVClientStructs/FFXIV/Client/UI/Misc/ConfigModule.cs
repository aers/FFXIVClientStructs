using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;
using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc {
    // Client::UI::Misc::ConfigModule
    // ctor E8 ?? ?? ?? ?? 48 8B 97 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 4C 8B CF
    [StructLayout(LayoutKind.Explicit, Size = 0xD678)]
    public unsafe partial struct ConfigModule {
        public const int ConfigOptionCount = 674;
        [FieldOffset(0x28)] public UIModule* UIModule;
        [FieldOffset(0x2C8)] private fixed byte options[Option.Size * ConfigOptionCount];
        [FieldOffset(0xAB60)] private fixed byte values[OptionValue.Size * ConfigOptionCount];

        public static ConfigModule* Instance() => Framework.Instance()->GetUiModule()->GetConfigModule();

        [MemberFunction("E8 ?? ?? ?? ?? C6 47 4D 00")]
        public partial bool SetOption(uint index, int value, int a4, bool a5, bool a6);

        public Option* GetOption(uint index) {
            fixed (byte* p = options) {
                var o = (Option*)p;
                return o + index;
            }
        }

        public Option* GetOptionById(short optionId) {
            for (uint i = 0; i < ConfigOptionCount; i++) {
                var o = GetOption(i);
                if (o->OptionID == optionId) return o;
            }

            return null;
        }

        public OptionValue* GetValue(uint index) {
            fixed (byte* p = values) {
                var v = (OptionValue*)p;
                return v + index;
            }
        }

        public OptionValue* GetValueById(short optionId) {
            for (uint i = 0; i < ConfigOptionCount; i++) {
                var o = GetOption(i);
                if (o->OptionID == optionId) return GetValue(i);
            }

            return null;
        }

        [StructLayout(LayoutKind.Explicit, Size = Size)]
        public struct Option {
            public const int Size = 0x20;
            [FieldOffset(0x00)] public void* Unk00;
            [FieldOffset(0x08)] public ulong Unk08;
            [FieldOffset(0x10)] public short OptionID;
            [FieldOffset(0x14)] public uint Unk14;
            [FieldOffset(0x18)] public uint Unk18;
            [FieldOffset(0x1C)] public ushort Unk1C;
        }

        [StructLayout(LayoutKind.Explicit, Size = Size)]
        public struct OptionValue {
            public const int Size = 0x10;
            [FieldOffset(0x00)] public ulong Value;
            [FieldOffset(0x08)] public ulong Unk08;
        }
    }
}
