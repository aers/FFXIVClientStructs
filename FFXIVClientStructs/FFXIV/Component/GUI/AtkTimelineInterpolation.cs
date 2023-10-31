namespace FFXIVClientStructs.FFXIV.Component.GUI;

public enum AtkTimelineInterpolation : byte {
    // Some animated properties cannot be interpolated
    None,
    Linear,
    // Speed coefficients dictate the interpolation, but only when smooth.
    Smooth,
}
