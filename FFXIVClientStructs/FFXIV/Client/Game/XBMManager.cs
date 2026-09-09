namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::XBMManager
// Manager for the Beastmaster pet list
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20)]
public unsafe partial struct XBMManager {
    [StaticAddress("48 83 EC ?? 48 83 3D ?? ?? ?? ?? 00 75 ?? 33 D2 45 33 C0 8D 4A ?? E8 ?? ?? ?? ?? 48 85 C0 74 ?? 48 C7 40 ?? 00 00 00 00", 0x2F, isPointer: true)]
    public static partial XBMManager* Instance();

    [FieldOffset(0x00), FixedSizeArray(isBitArray: true, bitCount: 50)] internal FixedSizeArray7<byte> _unlockedPets;
    [FieldOffset(0x10)] public int NumUnlockedPets;
    [FieldOffset(0x14)] public DataState State;
    [FieldOffset(0x18)] public bool HasNewUnlockedPets;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? 48 8B 44 24 ?? ?? ?? ?? ?? ?? ?? 32 C0")]
    public partial bool IsPetUnlocked(uint petId);

    [MemberFunction("E8 ?? ?? ?? ?? E8 ?? ?? ?? ?? BA ?? ?? ?? ?? 48 8B C8 E8 ?? ?? ?? ?? 48 85 C0 74 ?? 48 8B C8")]
    public partial void SetPetUnlocked(ushort petId);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC ?? ?? ?? ?? BF ?? ?? ?? ?? C7 41")]
    public partial void HandlePetListPacket(nint packet);

    public enum DataState {
        None = 0,
        Requested = 1,
        Received = 3,
    }
}
