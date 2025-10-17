using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Framework;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ConfigModule
// For updating offsets:
//    16 * (v6 + ConfigOptionCount * a6) + a1 + {ValuesFieldOffset}
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xECC0)]
public unsafe partial struct ConfigModule {
    public static ConfigModule* Instance() {
        var uiModule = UI.UIModule.Instance();
        return uiModule == null ? null : uiModule->GetConfigModule();
    }

    public const int ConfigOptionCount = 715;
    [FieldOffset(0x28)] public UIModule* UIModule;
    [FieldOffset(0x2C8), FixedSizeArray] internal FixedSizeArray715<Option> _options;

    [FieldOffset(0x5C38), FixedSizeArray] internal FixedSizeArray715<OptionValue> _values;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct Option {
        [FieldOffset(0x00)] public void* Unk00;
        [FieldOffset(0x08)] public ulong Unk08;
        [FieldOffset(0x10)] public ConfigOption OptionId;
        [FieldOffset(0x14)] public uint Unk14;
        [FieldOffset(0x18)] public uint Unk18;
        [FieldOffset(0x1C)] public ushort Unk1C;

        public string GetName() {
            if ((short)OptionId < 0) return string.Empty;
            var framework = Framework.Instance();
            if (framework == null) return string.Empty;
            var sysConfig = framework->SystemConfig;
            var id = (uint)OptionId;
            byte* namePtr = null;
            if (sysConfig.ConfigCount > id) namePtr = (sysConfig.ConfigEntry + id)->Name;
            if (namePtr == null && sysConfig.ConfigCount > id) namePtr = (sysConfig.ConfigEntry + id)->Name;
            if (namePtr == null && sysConfig.ConfigCount > id) namePtr = (sysConfig.ConfigEntry + id)->Name;
            if (namePtr == null) return string.Empty;
            var l = 0;
            while (namePtr[l] != 0) l++;
            return l == 0 ? string.Empty : $"{Encoding.UTF8.GetString(namePtr, l)}";
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct OptionValue;
}
