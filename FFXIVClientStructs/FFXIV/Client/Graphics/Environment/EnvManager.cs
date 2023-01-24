namespace FFXIVClientStructs.FFXIV.Client.Graphics.Environment;

[StructLayout(LayoutKind.Explicit, Size = 0x122)]
public unsafe partial struct EnvManager
{
    [StaticAddress("48 8B 35 ?? ?? ?? ?? 80 BE 73 03 00 00 80", 3, isPointer: true)]
    public static partial EnvManager* Instance();

    [FieldOffset(0x27)]
    public byte ActiveWeather;

    [FieldOffset(0x28)]
    public float TransitionTime;
}
