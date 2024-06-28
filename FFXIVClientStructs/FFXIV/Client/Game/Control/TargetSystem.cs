using FFXIVClientStructs.FFXIV.Client.Game.Object;

namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::TargetSystem
// ctor "E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 33 C0"
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x5730)]
public unsafe partial struct TargetSystem {
    [FieldOffset(0x80)] public GameObject* Target;
    [FieldOffset(0x88)] public GameObject* SoftTarget;
    [FieldOffset(0x98)] public GameObject* GPoseTarget;
    [FieldOffset(0xD0)] public GameObject* MouseOverTarget;
    [FieldOffset(0xE0)] public GameObject* MouseOverNameplateTarget;
    [FieldOffset(0xF8)] public GameObject* FocusTarget;
    [FieldOffset(0x110)] public GameObject* PreviousTarget;
    [FieldOffset(0x140)] public GameObjectId TargetObjectId;
    [FieldOffset(0x148)] public GameObjectArray ObjectFilterArray0;

    [FieldOffset(0x1B88)] public GameObjectArray ObjectFilterArray1;
    [FieldOffset(0x2F38)] public GameObjectArray ObjectFilterArray2;
    [FieldOffset(0x42E8)] public GameObjectArray ObjectFilterArray3;

    // Names might be inaccurate, these seem to be used to control what the player can interact with at any given time
    // For example, when interacting with the aethernet menu, these values change presumable to limit your ability to select an object other than the aetheryte.
    [FieldOffset(0x56A0), FixedSizeArray] internal FixedSizeArray8<uint> _targetModes;
    [FieldOffset(0x56C0)] public uint TargetModeIndex;

    [StaticAddress("48 8D 0D ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 3B C6 0F 95 C0", 3)]
    public static partial TargetSystem* Instance();

    /// <summary>
    /// Method to get the player's current target's ObjectId. Will resolve the hard and soft targets, in
    /// that order, returning the first one that's set.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 4C 8B F0 33 ED EB 16")]
    public partial GameObjectId GetTargetObjectId();

    [Obsolete($"Renamed to {nameof(GetTargetObjectId)}", true)]
    public GameObjectId GetCurrentTargetId() => GetTargetObjectId();

    /// <summary>
    /// Method to get the player's current target GameObject. Will resolve the hard and soft targets, in
    /// that order, returning the first one that's set.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 49 3B C7 41 8B C4")]
    public partial GameObject* GetTargetObject();

    [Obsolete($"Renamed to {nameof(GetTargetObject)}", true)]
    public GameObject* GetCurrentTarget() => GetTargetObject();

    [MemberFunction("48 85 D2 74 2C 4C 63 89")]
    public partial bool IsObjectInViewRange(GameObject* obj);

    [MemberFunction("E8 ?? ?? ?? ?? 3C 01 75 1E")]
    public partial bool IsObjectOnScreen(GameObject* obj);

    [MemberFunction("E9 ?? ?? ?? ?? 48 8B 01 FF 50 08")]
    public partial ulong InteractWithObject(GameObject* obj, bool checkLineOfSight = true);

    [MemberFunction("E9 ?? ?? ?? ?? 8B C0 48 8D 0D")]
    public partial void OpenObjectInteraction(GameObject* obj);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 74 50 48 8B CB")]
    public partial GameObject* GetMouseOverObject(int x, int y, GameObjectArray* objectArray, Camera* camera);

    public GameObject* GetMouseOverObject(int x, int y) {
        var camera = Control.Instance()->CameraManager.Camera;
        var localPlayer = Control.Instance()->LocalPlayer;
        if (camera == null || localPlayer == null || ObjectFilterArray1.Length <= 0)
            return null;
        fixed (GameObjectArray* arrayPtr = &ObjectFilterArray1)
            return GetMouseOverObject(x, y, arrayPtr, camera);
    }
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x13B0)]
public unsafe partial struct GameObjectArray {
    [FieldOffset(0x00)] public int Length;
    [FieldOffset(0x08), FixedSizeArray] internal FixedSizeArray629<Pointer<GameObject>> _objects;

    public GameObject* this[int index] {
        get {
            if (Length <= 0 || index < 0 || index > Length)
                return null;
            return Objects[index];
        }
    }
}
