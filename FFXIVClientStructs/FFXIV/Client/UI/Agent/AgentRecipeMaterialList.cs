using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

[Agent(AgentId.RecipeMaterialList)]
[VTableAddress("48 8D 05 ?? ?? ?? ?? 48 C7 43 ?? ?? ?? ?? ?? 48 89 03 33 C0 89 43 28", 3)]
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe partial struct AgentRecipeMaterialList {
    [FieldOffset(0)] public AgentInterface AgentInterface;
    [FieldOffset(0x28)] public ushort RecipeId;

    [FieldOffset(0x2C)] public uint Amount;

    [FieldOffset(0x34)] public bool WindowLocked;
    [FieldOffset(0x38)] public RecipeData* Recipe;

    [MemberFunction("E8 ?? ?? ?? ?? EB B1 48 8B 4B 28")]
    public readonly partial void OpenByRecipeId(ushort recipeId, uint amount = 1);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 BA ?? ?? ?? ?? 48 8B D9 E8 ?? ?? ?? ?? 48 8B F8 48 85 C0 74 5A")]
    public readonly partial void OpenRecipeResultItemContextMenu();

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
