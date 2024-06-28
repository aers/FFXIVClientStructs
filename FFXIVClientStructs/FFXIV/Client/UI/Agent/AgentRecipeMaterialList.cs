using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentRecipeMaterialList
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.RecipeMaterialList)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
[VirtualTable("48 8D 05 ?? ?? ?? ?? 48 C7 43 ?? ?? ?? ?? ?? 48 89 03 33 C0 89 43 28", 3)]
public unsafe partial struct AgentRecipeMaterialList {
    [FieldOffset(0x28)] public ushort RecipeId;

    [FieldOffset(0x2C)] public uint Amount;

    [FieldOffset(0x34)] public bool WindowLocked;
    [FieldOffset(0x38)] public RecipeData* Recipe;

    [MemberFunction("E8 ?? ?? ?? ?? C6 47 08 00 EB 30")]
    public partial void OpenByRecipeId(ushort recipeId, uint amount = 1);

    [StructLayout(LayoutKind.Explicit, Size = 0x2B0)]
    public struct RecipeData {
        [FieldOffset(0xB8)] public ushort RecipeId;
        [FieldOffset(0xBC)] public uint ResultItemId;
        [FieldOffset(0xC0)] public uint ResultAmount;
        [FieldOffset(0xC4)] public uint ResultItemIconId;
        [FieldOffset(0xC8)] public Utf8String ItemName;
        [FieldOffset(0x132)] public ushort Amount;
    }
}
