using FFXIVClientStructs.Havok.Animation.Playback.Control.Default;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Animation;

// All the game's Animation classes insist on measuring things in integral frames, where each frame is 1/30th of a second--except for easing times, which are in floating point seconds.
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public unsafe struct PlayAnimationParams {
    [FieldOffset(0x00)] internal uint Unk0; // Definitely used, might just be a 1 or a 0?
    [FieldOffset(0x04)] public float EaseTime;
    [FieldOffset(0x08)] public IAnimationControllerListener* ControlListener; // Optional
    [FieldOffset(0x10)] public short MaxCycles; // How many times the animation should loop for, or -1 for infinite
    [FieldOffset(0x12)] public short StartTimeFrames; // Which frame the animation should start and loop from.
    [FieldOffset(0x14)] public short EndTimeFrames; // Which frame the animation should end on, or 0 to use the full animation duration.
    [FieldOffset(0x16)] internal byte Unk16;
}
