namespace FFXIVClientStructs.FFXIV.Client.Game.Control;

// Client::Game::Control::PoseTypeInfoList
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x20 * 8)]
public unsafe partial struct PoseTypeInfoList {
    [StaticAddress("48 8D 15 ?? ?? ?? ?? 49 C1 E1", 3)]
    public static partial PoseTypeInfoList* Instance();
    /// <remarks>
    /// One entry for every <see cref="EmoteController.PoseType"/> 
    /// </remarks>
    [FieldOffset(0x0), FixedSizeArray] internal FixedSizeArray8<PoseTypeInfo> _poseTypeInfo;
}
