using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Common.Configuration;
using FFXIVClientStructs.FFXIV.Component.GUI;
using FFXIVClientStructs.FFXIV.Component.Text;
using AtkEventInterface = FFXIVClientStructs.FFXIV.Component.GUI.AtkModuleInterface.AtkEventInterface;
using ChangeEventInterface = FFXIVClientStructs.FFXIV.Common.Configuration.ConfigBase.ChangeEventInterface;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::ConfigModule
//   Component::GUI::AtkModuleInterface::AtkEventInterface
//   Common::Configuration::ConfigBase::ChangeEventInterface
// For updating offsets:
//    16 * (v6 + ConfigOptionCount * a6) + a1 + {ValuesFieldOffset}
[GenerateInterop]
[Inherits<AtkEventInterface>, Inherits<ChangeEventInterface>(parentOffset: 0x10)]
[StructLayout(LayoutKind.Explicit, Size = 0xED10)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 01 48 8B F9 4C 89 79 20 48 8D 05 ?? ?? ?? ?? 48 89 41 10 48 89 51 28", 3, 3)]
public unsafe partial struct ConfigModule {
    public static ConfigModule* Instance() {
        var uiModule = UI.UIModule.Instance();
        return uiModule == null ? null : uiModule->GetConfigModule();
    }

    public const int ConfigOptionCount = 746;
    [FieldOffset(0x28)] public UIModule* UIModule;

    [FieldOffset(0x88)] public Utf8String CharacterName;
    [FieldOffset(0xF0)] public Utf8String WorldName;
    [FieldOffset(0x158)] public uint CurrentClassJobLevel;
    [FieldOffset(0x15C)] public uint CurrentClassJobId;
    [FieldOffset(0x160)] public uint PlaceName;
    [FieldOffset(0x168)] public StdDeque<TextParameter> CharacterInfoParameters;
    [FieldOffset(0x190)] public Utf8String CharacterInfo;

    [FieldOffset(0x2F0)] public ConfigEventInterface* ConfigEventListeners;
    [FieldOffset(0x2F8)] public bool IsApplyingConfigChange;
    [FieldOffset(0x2F9)] public bool HasClientSelectDataConfigFlags;
    [FieldOffset(0x300), FixedSizeArray] internal FixedSizeArray746<Option> _options;

    [Obsolete("Use ValueSets")]
    [FieldOffset(0x6040), FixedSizeArray] internal FixedSizeArray2238<OptionValue> _values;
    [FieldOffset(0x6040), FixedSizeArray] internal FixedSizeArray3<ValueSet> _valueSets;

    [MemberFunction("48 8B 81 ?? ?? ?? ?? 4C 8B C1 48 3B C2")]
    public partial void RegisterConfigEvent(ConfigEventInterface* configEventInterface);

    [MemberFunction("48 8B 81 ?? ?? ?? ?? 48 3B C2 75 ?? 48 8B 42")]
    public partial void UnregisterConfigEvent(ConfigEventInterface* configEventInterface);

    [MemberFunction("E8 ?? ?? ?? ?? 4C 69 C7")]
    public partial bool SetValueByIndex(int optionIndex, int value, int valueSetIndex, bool apply, bool notifyListeners);

    [MemberFunction("E8 ?? ?? ?? ?? 33 DB 83 E7")]
    public partial int GetValueByIndex(int optionIndex, int valueSetIndex);

    [MemberFunction("48 89 5C 24 ?? 48 89 6C 24 ?? 48 89 74 24 ?? 41 54 41 56 41 57 48 83 EC ?? 45 33 E4")]
    public partial void ResetOptionsByCategoryMask(uint categoryMask, int valueSetIndex);

    [MemberFunction("48 89 6C 24 ?? 48 89 74 24 ?? 41 56 48 83 EC ?? 45 32 F6")]
    public partial bool IsValueChanged(int optionIndex, int valueSetIndex);

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

    // Client::UI::Misc::ConfigModule::ConfigEventInterface
    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public unsafe partial struct ConfigEventInterface {
        [FieldOffset(0x08)] public ConfigEventInterface* NextInterface;
        [FieldOffset(0x10)] public ConfigModule* Owner;

        [VirtualFunction(0)]
        public partial void OnConfigChange(int valueSetIndex, bool hasClientSelectDataConfigFlags);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x10), Obsolete("Use AtkValue")]
    public struct OptionValue;
}
