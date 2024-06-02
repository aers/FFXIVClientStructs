namespace FFXIVClientStructs.FFXIV.Application.Network.WorkDefinitions;

// Application::Network::WorkDefinitions::EnterContentInfo
//   Application::Network::WorkDefinitions::Base
[GenerateInterop]
[Inherits<Base>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public partial struct EnterContentInfo {
    // [FieldOffset(0x00)] public byte NotifyType; // TODO: is this part of Application::Network::WorkDefinitions::Base?

    /// <summary>
    /// The ID of the ContentFinderCondition EXD that has popped.
    /// </summary>
    [FieldOffset(0x1C)] public ushort ContentFinderConditionId;
}
