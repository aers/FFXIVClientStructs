namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct BaseInstanceObject {
    [VirtualFunction(13)] public partial Graphics.Scene.Object* GetGraphics();
}
