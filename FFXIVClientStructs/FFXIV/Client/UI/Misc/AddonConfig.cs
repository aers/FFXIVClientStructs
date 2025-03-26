using FFXIVClientStructs.FFXIV.Client.System.String;
using UserFileEvent = FFXIVClientStructs.FFXIV.Client.UI.Misc.UserFileManager.UserFileEvent;

namespace FFXIVClientStructs.FFXIV.Client.UI.Misc;

// Client::UI::Misc::AddonConfig
//   Client::UI::Misc::UserFileManager::UserFileEvent
[GenerateInterop]
[Inherits<UserFileEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct AddonConfig {
    public static AddonConfig* Instance() {
        var uiModule = UIModule.Instance();
        return uiModule == null ? null : uiModule->GetAddonConfig();
    }

    [FieldOffset(0x58)] public AddonConfigData* ModuleData;

    /// <summary>
    /// Changes the current HUD Layout to the specific value
    /// </summary>
    /// <param name="layoutIndex">HUD Layout Index, 0-based</param>
    /// <param name="unk1">Unknown, generally False</param>
    /// <param name="unk2">Unknown, generally True</param>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 EB 12")]
    public partial void ChangeHudLayout(uint layoutIndex, bool unk1 = false, bool unk2 = true);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xD080)]
public unsafe partial struct AddonConfigData {
    [FieldOffset(0x00)] public Utf8String DefaultString; // Literally says "Default"
    // [FieldOffset(0x68)] public StdList<[SomeStruct Size 48]> SomeList; // Contains 574 elements
    // [FieldOffset(0x78)] public StdList<[SomeStruct size 16]> SomeList; // Contains 424 elements
    [FieldOffset(0x88), FixedSizeArray] internal FixedSizeArray1027<AddonConfigEntry> _configEntries; // 110 (Default HudLayout?) + 917 (the amount of addons in RaptureAtkModule)
    [FieldOffset(0x90F8), FixedSizeArray] internal FixedSizeArray4<Utf8String> _hudLayoutNames; // unused?!
    [FieldOffset(0x9298), FixedSizeArray] internal FixedSizeArray440<AddonConfigEntry> _hudLayoutConfigEntries; // 4 HudLayouts * 110 entries
    [FieldOffset(0xD078)] public int CurrentHudLayout;
}

[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public struct AddonConfigEntry {
    /// <remarks> CRC32 hash of "%s_a" where %s is the addons name. </remarks>
    [FieldOffset(0x00)] public uint AddonNameHash;
    // technically these are just FloatValue1, FloatValue2 and so on, but we can name some of them
    [FieldOffset(0x04)] public float X; // percentage-based position relative to the middle of screen?
    [FieldOffset(0x08)] public float Y; // percentage-based position relative to the middle of screen?
    [FieldOffset(0x0C)] public float Scale;
    [FieldOffset(0x10)] public uint ElementFlags; // Job Guage Simple Mode, the shape of ActionBars...
    [FieldOffset(0x14)] public ushort Width;
    [FieldOffset(0x16)] public ushort Height;
    [FieldOffset(0x18)] public byte ByteValue1; // Visibility flag?
    [FieldOffset(0x19)] public byte ByteValue2; // Enable flag?
    [FieldOffset(0x1A)] public byte ByteValue3;
    [FieldOffset(0x1B)] public byte Alpha;

    [FieldOffset(0x20)] public bool HasValue;
    [FieldOffset(0x21)] public bool IsOpen;
}
