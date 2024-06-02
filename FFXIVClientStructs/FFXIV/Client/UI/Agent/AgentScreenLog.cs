using FFXIVClientStructs.FFXIV.Client.Game.Character;
using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentScreenLog
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.ScreenLog)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x3F0)]
public unsafe partial struct AgentScreenLog {

    [FieldOffset(0x350)] public StdDeque<BalloonInfo> BalloonQueue;

    [FieldOffset(0x378)]
    public byte BalloonsHaveUpdate; // bool used to know if any balloons have been added/changed since last frame update

    [FieldOffset(0x37C)]
    public int BalloonCounter; // count of all balloons since game launch, used as unique balloon ID

    [FieldOffset(0x390), FixedSizeArray] internal FixedSizeArray10<BalloonSlot> _balloonSlots;
}

[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public unsafe struct BalloonInfo {
    [FieldOffset(0x0)] public Utf8String FormattedText; // Contains breaks for newlines
    [FieldOffset(0x68)] public Utf8String OriginalText;
    [FieldOffset(0xD0)] public GameObjectId ObjectId;

    [FieldOffset(0xD8)]
    public Character*
        Character; // this keeps getting changed between null and the character pointer so isn't entirely reliable

    [FieldOffset(0xE0)] public float CameraDistance;
    [FieldOffset(0xE4)] public int BalloonId; // matches BalloonCounter when the balloon is made
    [FieldOffset(0xE8)] public ushort ParentBone;
    [FieldOffset(0xE9), CExportIgnore] public byte Slot; // Does not exist at current offset or was removed
}

// not sure how this maps to the addon yet, might just be in order though
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public struct BalloonSlot {
    [FieldOffset(0x0)] public int Id;
    [FieldOffset(0x4)] public byte Available; // bool
}
