using FFXIVClientStructs.FFXIV.Client.LayoutEngine;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

[GenerateInterop(isInherited: true)]
[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct LayoutObject {
    [VirtualFunction(48)] public partial ILayoutInstance* GetLayoutObject();

    [FieldOffset(0x80)] public ILayoutInstance* LayoutInstance;
}

[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct VfxObject {
    [FieldOffset(0x80)] public Graphics.Scene.Object* Graphics;
}

[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct BgObject {
    [FieldOffset(0x80)] public Graphics.Scene.Object* Graphics;
}

[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xB0)]
public unsafe partial struct LightObject {
    [FieldOffset(0xA8)] public Graphics.Scene.Object* Graphics;
}

[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xD0)]
public unsafe partial struct WeaponObject {
    [FieldOffset(0x80)] public Graphics.Scene.Object* Graphics;
}
