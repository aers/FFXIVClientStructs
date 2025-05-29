namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

// Client::Game::InstanceContent::PublicContentBozja
//   Client::Game::InstanceContent::PublicContentDirector
//     Client::Game::InstanceContent::ContentDirector
//       Client::Game::Event::Director
//         Client::Game::Event::LuaEventHandler
//           Client::Game::Event::EventHandler
[GenerateInterop]
[Inherits<PublicContentDirector>]
[StructLayout(LayoutKind.Explicit, Size = 0x3258)]
public unsafe partial struct PublicContentBozja {
    [FieldOffset(0x13E0)] public DynamicEventContainer DynamicEventContainer;
    [FieldOffset(0x3160)] public BozjaState State;
    [FieldOffset(0x3250)] public bool StateInitialized;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B F8 E8 ?? ?? ?? ?? 48 85 FF 74 1D")]
    public static partial PublicContentBozja* GetInstance();

    /// <summary>
    /// Returns pointer to the state, if bozja director is active and state is initialized; otherwise returns null.
    /// </summary>
    /// <returns></returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 85 FF 74 1D")]
    public static partial BozjaState* GetState();

    /// <summary>
    /// Use lost action from holster into specified duty action slot (slot is ignored for items, which are used directly).
    /// </summary>
    /// <param name="holsterIndex">Index of the action in the holster (see HolsterActions array).</param>
    /// <param name="slot">Action slot (has to be 0 or 1).</param>
    /// <returns></returns>
    [MemberFunction("40 53 55 57 48 83 EC 40 8B FA")]
    public partial bool UseFromHolster(uint holsterIndex, uint slot);
}

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0xF0)]
public partial struct BozjaState {
    [FieldOffset(0x00)] public uint CurrentExperience; // Mettle
    [FieldOffset(0x04)] public uint NeededExperience;
    [FieldOffset(0x6C), FixedSizeArray] internal FixedSizeArray100<byte> _holsterActions; // elements are MYCTemporaryItem row ids
}
