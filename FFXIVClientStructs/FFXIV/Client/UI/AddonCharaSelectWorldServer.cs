using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonCharaSelectWorldServer
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("_CharaSelectWorldServer")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x298)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 89 06 33 C0 48 89 86 ?? ?? ?? ?? 48 89 86 ?? ?? ?? ?? 48 89 86", 3)]
public unsafe partial struct AddonCharaSelectWorldServer {
    [FieldOffset(0x260)] public AtkComponentList* WorldList;
    [FieldOffset(0x278)] public StdVector<WorldEntry> WorldEntries;

    // Passed as AtkComponentListItemPopulator.PopulateWithRendererDelegate
    [MemberFunction("48 83 EC 38 4C 89 4C 24 ?? 4D 8B C8 44 8B C2 33 D2")]
    public partial void OnWorldListItemPopulate(int listItemWorldIndex, AtkResNode** nodeList, AtkComponentListItemRenderer* listItemRenderer);

    [StructLayout(LayoutKind.Explicit, Size = 0x78)]
    public struct WorldEntry {
        [FieldOffset(0x00)] public ushort Unk0;
        [FieldOffset(0x08)] public Utf8String DisplayName;
        [FieldOffset(0x70)] public ushort WorldId;
        [FieldOffset(0x74)] public uint CharacterCount;
    }
}
