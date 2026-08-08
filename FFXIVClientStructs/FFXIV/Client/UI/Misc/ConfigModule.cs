using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Common.Configuration;
using FFXIVClientStructs.FFXIV.Component.GUI;

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

    [Obsolete("Use ValueSets")]
    [FieldOffset(0x6040), FixedSizeArray] internal FixedSizeArray2238<OptionValue> _values;
    [FieldOffset(0x6040), FixedSizeArray] internal FixedSizeArray3<ValueSet> _valueSets;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct Option {
        [FieldOffset(0x00)] public ConfigOption OptionId;
        [FieldOffset(0x04)] public uint CategoryMask;
        [FieldOffset(0x08)] public uint MaxValueIndex;
        [FieldOffset(0x0C)] public byte BitIndex;
        [FieldOffset(0x0D)] public bool InvertValue;
        [FieldOffset(0x10)] public OptionHandler Handler;

        public ConfigEntry* GetConfigEntry() {
            if (OptionId <= ConfigOption.None) return null;
            return Framework.Instance()->SystemConfig.GetConfigOption(OptionId);
        }

        public string GetName() {
            var entry = GetConfigEntry();
            return entry == null || entry->Type == 0 || !entry->Name.HasValue ? string.Empty : entry->Name.ToString();
        }

        [StructLayout(LayoutKind.Explicit, Size = 0x10)]
        public struct OptionHandler { // similar to how UIModuleHandler works
            [FieldOffset(0x00)] public delegate* unmanaged<void*, int, Option*, int, int, int, int> FunctionPtr; // used by SetValueByIndex/GetValueByIndex to save/provide custom values
            [FieldOffset(0x08)] public uint ConfigModuleOffset;

            public delegate int FunctionDelegate(void* thisPtr, int optionIndex, Option* option, int mode, int newValue, int valueSetIndex);
        }
    }

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = ConfigOptionCount * AtkValue.StructSize)]
    public partial struct ValueSet {
        [FieldOffset(0), FixedSizeArray] internal FixedSizeArray746<AtkValue> _values;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10), Obsolete("Use AtkValue")]
    public struct OptionValue;
}
