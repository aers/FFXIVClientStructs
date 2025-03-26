using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Environment;

// Client::Graphics::Environment::EnvManager
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xC10)]
public unsafe partial struct EnvManager {
    [StaticAddress("0F 28 F2 48 8B 05", 6, isPointer: true)]
    public static partial EnvManager* Instance();

    [FieldOffset(0x08)] public EnvScene* EnvScene;
    [FieldOffset(0x10)] public float DayTimeSeconds;
    [FieldOffset(0x14)] public float ActiveTransitionTime;
    [FieldOffset(0x18)] public float CurrentTransitionTime;
    [FieldOffset(0x1C)] public float TransitionProgress;

    [FieldOffset(0x27)] public byte ActiveWeather;
    [FieldOffset(0x28)] public float TransitionTime;

    [FieldOffset(0x38)] public EnvSpace* EnvSpace;

    [FieldOffset(0x58)] public EnvState EnvState;

    [FieldOffset(0x468)] public EnvSoundState EnvSoundState;
    [FieldOffset(0x4E0)] public EnvSimulator EnvSimulator;

    [FieldOffset(0x8E0)] public ShadowCamera ShadowCamera;

    // [FieldOffset(0x8F4)] public uint UnkFlags;
}
