namespace FFXIVClientStructs.FFXIV.Client.Game.UI; 

// ctor E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? 48 8D 8B ?? ?? ?? ?? E8 ?? ?? ?? ?? B9 ?? ?? ?? ?? 48 89 B3

[StructLayout(LayoutKind.Explicit, Size = 0x610)]
public unsafe partial struct RecipeNote {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 81 FE ?? ?? ?? ?? 75 0F", 3)]
    public static partial RecipeNote* Instance();
    
    [FieldOffset(0x00)] public fixed uint Jobs[8];  // CraftType -> ClassJob
        
    [FieldOffset(0xB8)] public RecipeData* RecipeList;

    [StructLayout(LayoutKind.Explicit, Size = 0x3B0)]
    public struct RecipeData {
        [FieldOffset(0x000)] public RecipeEntry* Recipes;
        [FieldOffset(0x3A8)] public ushort SelectedIndex;
        public RecipeEntry* SelectedRecipe => Recipes + SelectedIndex;
    }
        
    [StructLayout(LayoutKind.Explicit, Size = 0x4F8)]
    public struct RecipeEntry {
        [FieldOffset(0x4E7)] public byte CraftType;
        [FieldOffset(0x4C2)] public ushort RecipeId;
    }
}
