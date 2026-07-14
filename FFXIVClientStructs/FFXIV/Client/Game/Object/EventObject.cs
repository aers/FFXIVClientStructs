using EventHandler = FFXIVClientStructs.FFXIV.Client.Game.Event.EventHandler;

namespace FFXIVClientStructs.FFXIV.Client.Game.Object;

// Client::Game::Object::EventObject
//   Client::Game::Object::GameObject
[GenerateInterop]
[Inherits<GameObject>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C0)]
public unsafe partial struct EventObject {
    [FieldOffset(0x1A0), CExporterExcel("EObj")] public nint EObjRowPtr;
    [FieldOffset(0x1A8), CExporterExcel("ExportedSG")] public nint ExportedSGRowPtr;
    [FieldOffset(0x1B2)] public ushort SharedTimelineState; // ActorControl category 0x199 (SetSharedTimelineState) sets this field and it can also be set when spawned by SpawnObjectPacket.
    /// <summary>Arbritrary value set in SpawnObjectPacket. How it's used depends on GameObject.SubKind.</summary>
    [FieldOffset(0x1B4)] public uint Arg;
    [FieldOffset(0x1B8)] public byte Flags;

    /// <summary>Changes the currently playing timelines based on a bitmask.</summary>
    /// <param name="sharedTimelineState">Only sets SharedTimelineState, does not have any other effect in this function.</param>
    /// <param name="bitmask">Each bit represents a timeline index in the SharedGroup. Setting a bit means play, an unset bit means stop.</param>
    /// <param name="unknown">Unused, can be left as zero.</param>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 4D 85 F6 0F 84 ?? ?? ?? ?? 8B 44 24 70 BE ?? ?? ?? ??")]
    public partial void PlayAnimation(uint sharedTimelineState, uint bitmask, ulong unknown);

    /// <summary>Changes the currently playing timelines based on a bitmask.</summary>
    /// <param name="sharedTimelineState">The new SharedTimelineState value.</param>
    /// <param name="bitmask">The new timeline bitmask.</param>
    [MemberFunction("48 89 5C 24 ?? 41 56 48 83 EC ?? 48 89 6C 24 ?? 44 0F B7 F2")]
    public partial void UpdateTimelinesByBitmask(ushort sharedTimelineState, uint bitmask);

    /// <param name="outHandlers">Should point to array that can fit up to 32 pointers.</param>
    /// <returns>Num elements filled.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 4D 85 F6 0F 84 ?? ?? ?? ?? 8B 44 24 70 BE ?? ?? ?? ??")]
    public partial int GetEventHandlers(EventHandler** outHandlers);

    /// <summary>Changes the currently playing timelines based on the difference between oldSharedTimelineState and newSharedTimelineState.</summary>
    /// <param name="sharedTimelineState">The new SharedTimelineState value.</param>
    /// <param name="checkIfLayoutReady">If we should check if the layout is ready before continuing.</param>
    /// <param name="unused">Unused and can be left empty.</param>
    [MemberFunction("E8 ?? ?? ?? ?? 49 8B 06 44 0F B6 C5")]
    public partial void SetSharedTimelineState(ushort sharedTimelineState, bool checkIfLayoutReady, ulong unused);
}
