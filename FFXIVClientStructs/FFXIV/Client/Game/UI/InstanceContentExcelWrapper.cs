namespace FFXIVClientStructs.FFXIV.Client.Game.UI;

// Client::Game::UI::InstanceContentExcelWrapper
//   Client::Game::UI::ContentFinderConditionInterface
//     Client::Game::UI::ContentInterface
[GenerateInterop(isInherited: true)]
[Inherits<ContentFinderConditionInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x18)]
public partial struct InstanceContentExcelWrapper {
    [FieldOffset(0x10)] public uint InstanceContentId;
}
