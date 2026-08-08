using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Common.Configuration;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ConfigModule
// For updating offsets:
//    16 * (v6 + ConfigOptionCount * a6) + a1 + {ValuesFieldOffset}
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xED10)]
public unsafe partial struct ConfigModule {
    public static ConfigModule* Instance() {
        var uiModule = UI.UIModule.Instance();
        return uiModule == null ? null : uiModule->GetConfigModule();
    }

    public const int ConfigOptionCount = 746;
    [FieldOffset(0x28)] public UIModule* UIModule;
    [FieldOffset(0x300), FixedSizeArray] internal FixedSizeArray746<Option> _options;

    [FieldOffset(0x6040), FixedSizeArray] internal FixedSizeArray2238<OptionValue> _values;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct Option {
        [FieldOffset(0x00)] public ConfigOption ConfigOptionId;
        [FieldOffset(0x04)] public uint CategoryMask;
        [FieldOffset(0x08)] public uint MaxValueIndex;
        [FieldOffset(0x0C)] public byte BitIndex;
        [FieldOffset(0x0D)] public bool InvertValue;
        [FieldOffset(0x0E)] private ushort Padding0E;
        [FieldOffset(0x10)] private void* ValueChangeCallback;
        [Obsolete("Incorrect offset. Use ConfigOptionId.")]
        [FieldOffset(0x10)] public ConfigOption OptionId;
        [FieldOffset(0x18)] private uint ValueChangeCallbackParamOffset;

        public string GetName() {
            if ((short)ConfigOptionId < 0) return string.Empty;
            var framework = Framework.Instance();
            if (framework == null) return string.Empty;
            var entry = ((ConfigBase*)&framework->SystemConfig)->GetConfigOption((uint)ConfigOptionId);
            return entry == null || entry->Type == 0 || !entry->Name.HasValue ? string.Empty : entry->Name.ToString();
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public struct OptionValue;
}
