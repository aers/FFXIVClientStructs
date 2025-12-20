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

    [FieldOffset(0x50)] public bool IsLoaded;
    [FieldOffset(0x58)] public AddonConfigDataSet* ActiveDataSet;
    [FieldOffset(0x58), Obsolete("Use ActiveDataSet", true)] public AddonConfigDataSet* ModuleData;
    [FieldOffset(0x60)] public StdList<Pointer<AddonConfigDataSet>> DataSets;

    /// <summary>
    /// Switches <see cref="ActiveDataSet"/> to the named <see cref="AddonConfigDataSet"/>, creating it if needed.
    /// </summary>
    [MemberFunction("40 53 48 83 EC ?? 48 8B D9 E8 ?? ?? ?? ?? 48 89 43")]
    public partial void SwitchToDataSet(Utf8String* name);

    /// <summary>
    /// Switches <see cref="ActiveDataSet"/> to the "Default" <see cref="AddonConfigDataSet"/>.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 84 DB 74 ?? 48 85 F6")]
    public partial void SwitchToDefaultSet();

    [MemberFunction("48 89 5C 24 ?? 48 89 74 24 ?? 57 48 83 EC ?? 48 8B 41 ?? 48 8B F2 48 8B F9 ?? ?? ?? 48 3B D8 74 ?? 48 8B 4B ?? 48 8B D6")]
    public partial bool ContainsDataSet(Utf8String* name);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8D 4C 24 ?? 49 89 47")]
    public partial AddonConfigDataSet* GetOrCreateDataSet(Utf8String* name);

    [MemberFunction("48 89 5C 24 ?? 55 56 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 41 0F B6 E8")]
    public partial bool CopyDefaultDataSet(Utf8String* name, CopyDirection direction);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 ?? C6 40 ?? ?? 40 38 78"), GenerateStringOverloads]
    public partial AddonConfigEntry* GetConfigEntryByAddonName(CStringPointer addonName);

    /// <summary>
    /// Changes the current HUD Layout to the specific value
    /// </summary>
    /// <param name="layoutIndex">HUD Layout Index, 0-based</param>
    /// <param name="unk1">Unknown, generally False</param>
    /// <param name="unk2">Unknown, generally True</param>
    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 EB 12")]
    public partial void ChangeHudLayout(uint layoutIndex, bool unk1 = false, bool unk2 = true);

    /// <summary>
    /// Applies the current HUD Layout
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 7C 24 ?? 41 C6 46 ?? ??")]
    public partial void ApplyHudLayout();

    public enum CopyDirection : byte {
        FromDefault = 0,
        ToDefault = 1,
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xD4B8)]
public unsafe partial struct AddonConfigDataSet {
    [FieldOffset(0x00)] public Utf8String Name;
    [FieldOffset(0x00), Obsolete("Renamed to Name", true)] public Utf8String DefaultString;
    [FieldOffset(0x68)] public StdList<Pointer<AddonConfigEntry>> UsedAddonConfigEntries;
    [FieldOffset(0x78)] public StdList<Pointer<AddonConfigEntry>> UnusedAddonConfigEntries;
    [FieldOffset(0x88), FixedSizeArray] internal FixedSizeArray1053<AddonConfigEntry> _configEntries; // 111 (Default HudLayout?) + 942 (the amount of addons in RaptureAtkModule)
    [FieldOffset(0x94A0), FixedSizeArray] internal FixedSizeArray4<Utf8String> _hudLayoutNames; // unused?!
    [FieldOffset(0x9640), FixedSizeArray] internal FixedSizeArray444<AddonConfigEntry> _hudLayoutConfigEntries; // 4 HudLayouts * 111 entries
    [FieldOffset(0xD4B0)] public int CurrentHudLayout;
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

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe partial struct HudLayoutAddon {
    [FieldOffset(0x00)] public CStringPointer AddonName;
    [FieldOffset(0x08)] public uint HudRowId;
    [FieldOffset(0x0C)] public uint Flags;

    [StaticAddress("4C 8D 0D ?? ?? ?? ?? 4C 8D 1D ?? ?? ?? ?? 90", 3)]
    public static partial HudLayoutAddon* GetArrayPointer();

    [MemberFunction("E8 ?? ?? ?? ?? 33 ED 44 8B F8 85 C0 0F 84")]
    public static partial int GetLength();

    public static Span<HudLayoutAddon> GetSpan() => new(GetArrayPointer(), GetLength());
}
