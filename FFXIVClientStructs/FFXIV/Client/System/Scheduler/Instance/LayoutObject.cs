using FFXIVClientStructs.FFXIV.Client.LayoutEngine;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

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

[GenerateInterop(isInherited: true)]
[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public unsafe partial struct LayoutObjectBase {
    [VirtualFunction(47)] public partial ILayoutInstance* GetLayoutInstance1();
    [VirtualFunction(48)] public partial ILayoutInstance* GetLayoutInstance2();
    [VirtualFunction(49)] public partial SharedGroupLayoutInstance* GetParentInstance1();
    [VirtualFunction(50)] public partial SharedGroupLayoutInstance* GetParentInstance2();
}

[GenerateInterop]
[Inherits<LayoutObjectBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA0)]
public unsafe partial struct LayoutObjectGroup {
    [FieldOffset(0x80)] public SharedGroupLayoutInstance* Instance;
    [FieldOffset(0x88)] public StdMap<uint, Pointer<LayoutObjectBase>> SubIdToInstance;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 6B 10")]
    public partial void InsertObject(ILayoutInstance* inst);
}

[GenerateInterop]
[Inherits<LayoutObjectBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x90)]
public unsafe partial struct LayoutObjectSingle {
    [FieldOffset(0x80)] public BgPartsLayoutInstance* Instance;
    [FieldOffset(0x88)] public SharedGroupLayoutInstance* Parent;
}

[GenerateInterop]
[Inherits<SchedulerInstanceObject>]
[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public partial struct CharacterObject {
    [FieldOffset(0x80)] public int Index;
    [FieldOffset(0x84)] public int SpawnIndex;

    [FieldOffset(0xAC)] public int Race;
    [FieldOffset(0xB0)] public int Tribe;
}
