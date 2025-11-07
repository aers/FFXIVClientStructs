using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Base;

namespace FFXIVClientStructs.FFXIV.Client.System.Scheduler.Clip;

[GenerateInterop(isInherited: true)]
[Inherits<SchedulerState>]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct BaseClip {
    [VirtualFunction(62)]
    public partial void Unk62();

    [FieldOffset(0x5C)] public float Float_5C;
    [FieldOffset(0x60)] public float Float_60;
    [FieldOffset(0x68)] public float Float_68;
    [FieldOffset(0x6C)] public float Float_6C;
    [FieldOffset(0x70)] public float Float_70;
    [FieldOffset(0x88)] public ushort UnkFlags_88;
}

[Inherits<SchedulerState>]
[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe partial struct BaseClipField28 {
    [StructLayout(LayoutKind.Explicit, Size = 0x10)]
    public partial struct Sub1 {
        [FieldOffset(0x8)] public GameObjectReference Ref;
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x7E0)]
public unsafe partial struct BaseClipField40 {
    [VirtualFunction(3)] public partial bool Unk3();
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 8)]
public unsafe partial struct GameObjectReference {
    // if 1st bit set, contains a pointer (maybe to a gameobject, but it's a reference to something with a vtable, so it could be a container); low 3 bits are zeroed before deref
    // if 3 bit set, contains a spawn index (shifted left by 3 bits)
    [FieldOffset(0), CExporterUnion("Value")] public byte Flags;
    [FieldOffset(0), CExporterUnion("Value")] public GameObject* Object;
    [FieldOffset(0), CExporterUnion("Value")] public uint SpawnIndex;

    public GameObject* Resolve() {
        if ((Flags & 1) != 0)
            return (GameObject*)((ulong)Object & 0xFFFFFFFFFFFFFFFDul);

        if ((Flags & 4) != 0) {
            var ix = SpawnIndex >> 3;
            if (ix <= 0x332)
                return GameObjectManager.Instance()->Objects.IndexSorted[(int)ix];
        }

        return null;
    }
}
