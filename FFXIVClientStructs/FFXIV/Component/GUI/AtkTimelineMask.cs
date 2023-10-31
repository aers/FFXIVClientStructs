namespace FFXIVClientStructs.FFXIV.Component.GUI;

[Flags]
public enum AtkTimelineMask : byte {
    Position = 1 << 0,
    Rotation = 1 << 1,
    Scale = 1 << 2,
    Alpha = 1 << 3,
    NodeTint = 1 << 4,
    VendorSpecific1 = 1 << 5,
    VendorSpecific2 = 1 << 6,
    ActiveLabel = 1 << 7,
}
