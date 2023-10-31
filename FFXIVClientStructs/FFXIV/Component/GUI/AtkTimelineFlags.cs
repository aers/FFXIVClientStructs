namespace FFXIVClientStructs.FFXIV.Component.GUI;

[Flags]
public enum AtkTimelineFlags : byte {
    IsAnimated = 1 << 6, // 0x4000 relative to Mask
    UnknownFlag = 1 << 7, // 0x8000 relative to Mask; unsure what this does, but it exists
}
