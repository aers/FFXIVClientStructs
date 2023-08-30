using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ConfigModule
// ctor "E8 ?? ?? ?? ?? 48 8B 97 ?? ?? ?? ?? 48 8D 8F ?? ?? ?? ?? 4C 8B CF"
// For updating offsets:
//  "48 8B CB E8 ?? ?? ?? ?? 48 8B 7C 24 ?? 33 C0 48 8B 5C 24"
//    16 * (v6 + ConfigOptionCount * a6) + a1 + {ValuesFieldOffset}
[StructLayout(LayoutKind.Explicit, Size = 0xE5C8)]
public unsafe partial struct ConfigModule {
    public static ConfigModule* Instance() => Framework.Instance()->GetUiModule()->GetConfigModule();

    public const int ConfigOptionCount = 715;
    [FieldOffset(0x28)] public UIModule* UIModule;
    [FieldOffset(0x2C8)] private fixed byte options[Option.Size * ConfigOptionCount];

    [FieldOffset(0x5C38)] private fixed byte values[0x10 * ConfigOptionCount];

    [StructLayout(LayoutKind.Explicit, Size = Size)]
    public struct Option {
        public const int Size = 0x20;
        [FieldOffset(0x00)] public void* Unk00;
        [FieldOffset(0x08)] public ulong Unk08;
        [FieldOffset(0x10)] public ConfigOption OptionID;
        [FieldOffset(0x14)] public uint Unk14;
        [FieldOffset(0x18)] public uint Unk18;
        [FieldOffset(0x1C)] public ushort Unk1C;

        public string GetName() {
            if ((short)OptionID < 0) return string.Empty;
            var sysConfig = Framework.Instance()->SystemConfig;
            var id = (uint)OptionID;
            byte* namePtr = null;
            if (sysConfig.CommonSystemConfig.ConfigBase.ConfigCount > id) namePtr = (sysConfig.CommonSystemConfig.ConfigBase.ConfigEntry + id)->Name;
            if (namePtr == null && sysConfig.CommonSystemConfig.UiConfig.ConfigCount > id) namePtr = (sysConfig.CommonSystemConfig.UiConfig.ConfigEntry + id)->Name;
            if (namePtr == null && sysConfig.CommonSystemConfig.UiControlConfig.ConfigCount > id) namePtr = (sysConfig.CommonSystemConfig.UiControlConfig.ConfigEntry + id)->Name;
            if (namePtr == null) return string.Empty;
            var l = 0;
            while (namePtr[l] != 0) l++;
            return l == 0 ? string.Empty : $"{Encoding.UTF8.GetString(namePtr, l)}";
        }
    }
}
