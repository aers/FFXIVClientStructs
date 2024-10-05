using FFXIVClientStructs.FFXIV.Client.Game.Object;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

/// <summary>
/// Singleton that manages selecting one of the multiple event handlers (eg. one of the several shops provided by a single vendor).
/// </summary>
[GenerateInterop]
[Inherits<AtkModuleInterface.AtkEventInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x428)]
public unsafe partial struct EventHandlerSelector {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 48 63 C2 48 C1 E0 05", 3)]
    public static partial EventHandlerSelector* Instance();

    [FieldOffset(0x010)] public GameObject* Target; // object corresponding to the active selection, null if selection is not active
    [FieldOffset(0x018), FixedSizeArray] internal FixedSizeArray32<Option> _options;
    [FieldOffset(0x418)] public int OptionsCount; // num valid elements in Options array

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public unsafe partial struct Option {
        [FieldOffset(0x00)] public int GlobalIndex; // index in Options array
        [FieldOffset(0x08)] public EventHandler* Handler;
        [FieldOffset(0x18)] public ushort IconId;
        [FieldOffset(0x1C)] public int LocalIndex; // sequence index for a single fill invocation, not sure what this is exactly
    }
}
