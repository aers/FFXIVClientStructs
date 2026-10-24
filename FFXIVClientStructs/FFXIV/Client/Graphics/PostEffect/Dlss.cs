using FFXIVClientStructs.STD;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.PostEffect;

// Client::Graphics::PostEffect::Dlss
/// <summary> NGX state and the render sizes of the DLSS quality modes. </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x188)]
public unsafe partial struct Dlss {
    /// <summary> Indexed by NGX PerfQualityValue: Performance, Balanced, Quality, Ultra Performance, Ultra Quality, DLAA. </summary>
    [FieldOffset(0x00), FixedSizeArray] internal FixedSizeArray6<QualityMode> _qualityModes;

    /// <summary> Render sizes by <see cref="QualityMode.Value"/> for the output size of the last query. </summary>
    [FieldOffset(0x90)] public StdMap<int, RenderSettings> RenderSettingsByMode;

    /// <summary> Settings for the next evaluation. </summary>
    [FieldOffset(0xA0)] public Settings Requested;

    /// <summary> Settings the feature was created with. It is released when <see cref="Requested"/> differs. </summary>
    [FieldOffset(0xCC)] public Settings Applied;

    /// <summary> Output size of the last query. Both are 0xFFFFFFFF when there is none. </summary>
    [FieldOffset(0x150)] public uint QueriedOutputWidth;
    [FieldOffset(0x154)] public uint QueriedOutputHeight;

    [FieldOffset(0x158)] public void* NgxParameters; // NVSDK_NGX_Parameter*
    [FieldOffset(0x160)] public void* NgxFeature; // NVSDK_NGX_Handle*

    [FieldOffset(0x181)] public DlssFlags Flags;

    [MemberFunction("E8 ?? ?? ?? ?? EB 03 49 8B C7 48 89 87 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ??")]
    public partial void Ctor();

    /// <summary> Releases the NGX feature and parameters and shuts NGX down. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 32 C0 48 83 C4 38 41 5E 5F")]
    public partial void Shutdown();

    /// <summary> Fills <see cref="Requested"/> for <paramref name="outputSize"/> (width, height) from <see cref="Render.GraphicsConfig.DlssQuality"/>. </summary>
    /// <returns> False when NGX is unavailable or the mode is not supported. </returns>
    [MemberFunction("40 57 41 56 48 83 EC 38 F6 81 ?? ?? ?? ?? ??")]
    public partial bool UpdateSettings(uint* outputSize, bool unk);

    /// <summary> Queries NGX for the render sizes of every mode at <paramref name="outputSize"/> (width, height). </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B 05 ?? ?? ?? ?? 45 33 E4")]
    public partial void QueryRenderSettings(uint* outputSize);

    /// <summary> Releases the NGX feature. The next evaluation creates it again. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 87 ?? ?? ?? ?? 0F 10 06")]
    public partial void ReleaseFeature();

    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public struct QualityMode {
        /// <summary> NGX PerfQualityValue. </summary>
        [FieldOffset(0x00)] public int Value;
        [FieldOffset(0x08)] public byte* Name; // "Performance", "Balanced", ...
        [FieldOffset(0x10)] public QualityModeFlags Flags;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
    public struct RenderSettings {
        [FieldOffset(0x00)] public uint OptimalWidth;
        [FieldOffset(0x04)] public uint OptimalHeight;
        [FieldOffset(0x08)] public uint MinWidth;
        [FieldOffset(0x0C)] public uint MinHeight;
        [FieldOffset(0x10)] public uint MaxWidth;
        [FieldOffset(0x14)] public uint MaxHeight;
        [FieldOffset(0x18)] public float Sharpness;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x2C)]
    public struct Settings {
        [FieldOffset(0x00)] public uint OutputWidth;
        [FieldOffset(0x04)] public uint OutputHeight;
        [FieldOffset(0x08)] public uint OptimalWidth;
        [FieldOffset(0x0C)] public uint OptimalHeight;
        [FieldOffset(0x10)] public uint MinWidth;
        [FieldOffset(0x14)] public uint MinHeight;
        [FieldOffset(0x18)] public uint MaxWidth;
        [FieldOffset(0x1C)] public uint MaxHeight;
        /// <summary> <see cref="QualityMode.Value"/> of the mode. </summary>
        [FieldOffset(0x20)] public int Mode;
    }

    [Flags]
    public enum QualityModeFlags : byte {
        None = 0,
        Supported = 1 << 0,
        /// <summary> Minimum and maximum render size differ. </summary>
        DynamicResolution = 1 << 1,
    }
}

[Flags]
public enum DlssFlags : byte {
    None = 0,
    NgxInitialized = 1 << 0,
    FeatureCreated = 1 << 1,
}
