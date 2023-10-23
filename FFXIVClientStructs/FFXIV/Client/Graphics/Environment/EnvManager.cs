using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Environment;

[StructLayout(LayoutKind.Explicit, Size = 0x910)]
public unsafe partial struct EnvManager {
    [FieldOffset(0x08)] public EnvScene* EnvScene;
    [FieldOffset(0x10)] public float DayTimeSeconds;
    [FieldOffset(0x14)] public float ActiveTransitionTime;
    [FieldOffset(0x18)] public float CurrentTransitionTime;
    [FieldOffset(0x1C)] public float TransitionProgress;

    [FieldOffset(0x27)] public byte ActiveWeather;
    [FieldOffset(0x28)] public float TransitionTime;

    [FieldOffset(0x30)] public EnvSpace* EnvSpace;

    [FieldOffset(0x50)] public EnvState EnvState;
    [FieldOffset(0x388)] public EnvSoundState EnvSoundState;
    [FieldOffset(0x400)] public EnvSimulator EnvSimulator;
    [FieldOffset(0x750)] public ShadowCamera ShadowCamera;

    [FieldOffset(0x8F4)] public uint UnkFlags;

    [StaticAddress("48 8B 35 ?? ?? ?? ?? 80 BE 7B 03 00 00 80", 3, isPointer: true)]
    public static partial EnvManager* Instance();
}
