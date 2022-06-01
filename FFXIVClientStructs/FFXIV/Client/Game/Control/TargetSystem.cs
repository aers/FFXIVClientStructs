using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;
// Client::Game::Control::TargetSystem

[StructLayout(LayoutKind.Explicit, Size = 0x3D50)]
public unsafe partial struct TargetSystem
{
    [FieldOffset(0x80)] public GameObject* Target;
    [FieldOffset(0x88)] public GameObject* SoftTarget;
    [FieldOffset(0x98)] public GameObject* GPoseTarget;
    [FieldOffset(0xD0)] public GameObject* MouseOverTarget;
    [FieldOffset(0xE0)] public GameObject* MouseOverNameplateTarget;
    [FieldOffset(0xF8)] public GameObject* FocusTarget;
    [FieldOffset(0x110)] public GameObject* PreviousTarget;
    [FieldOffset(0x140)] public uint TargetObjectId;

    [FieldOffset(0x148)] public GameObjectArray ObjectFilterArray0;

    [FieldOffset(0x14B0)] public GameObjectArray ObjectFilterArray1;
    [FieldOffset(0x2208)] public GameObjectArray ObjectFilterArray2;
    [FieldOffset(0x2F60)] public GameObjectArray ObjectFilterArray3;

    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 3B C6 0F 95 C0")]
    public static partial TargetSystem* Instance();

    [MemberFunction("E8 ?? ?? ?? ?? 48 3B D8 74 51")]
    public partial uint GetCurrentTargetID();

    [MemberFunction("E8 ?? ?? ?? ?? 48 3B C6 0F 94 C0")]
    public partial GameObject* GetCurrentTarget();

    [MemberFunction("48 85 D2 74 2C 4C 63 89")]
    public partial bool IsObjectInViewRange(GameObject* obj);

    [MemberFunction("E9 ?? ?? ?? ?? 48 8B 01 FF 50 08")]
    public partial ulong InteractWithObject(GameObject* obj, bool checkLineOfSight = true);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 48 85 DB 74 ?? 48 8B CB")]
    public partial GameObject* GetMouseOverObject(int x, int y, GameObjectArray* objectArray, Camera* camera);

    public GameObject* GetMouseOverObject(int x, int y)
    {
        var camera = Control.Instance()->CameraManager.Camera;
        var localPlayer = Control.Instance()->LocalPlayer;
        if (camera == null || localPlayer == null || ObjectFilterArray1.Length <= 0)
            return null;
        fixed (GameObjectArray* arrayPtr = &ObjectFilterArray1)
            return GetMouseOverObject(x, y, arrayPtr, camera);
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0xD58)]
public unsafe struct GameObjectArray
{
    [FieldOffset(0x00)] public int Length;
    [FieldOffset(0x08)] public fixed long Objects[426];

    public GameObject* this[int index]
    {
        get
        {
            if (Length <= 0 || index < 0 || index > Length)
                return null;
            return (GameObject*)Objects[index];
        }
    }
}