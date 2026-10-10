using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Scene;

// Client::Graphics::Scene::Monster
//   Client::Graphics::Scene::CharacterBase
//     Client::Graphics::Scene::DrawObject
//       Client::Graphics::Scene::Object
[GenerateInterop]
[Inherits<CharacterBase>]
[StructLayout(LayoutKind.Explicit, Size = 0xA50)]
public unsafe partial struct Monster : ICreatable<Monster> {
    [FieldOffset(0xA20)] public ushort ModelSetId;
    [FieldOffset(0xA22)] public ushort SecondaryId;
    [FieldOffset(0xA24)] public ushort Variant;

    [FieldOffset(0xA30)] public TextureResourceHandle* Decal;

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B E8 48 89 AE")]
    public partial Monster* Ctor();

    // Expects at least 8 bytes of data.
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 0F 57 C0 48 8D 4C 24 ?? 0F 11 44 24")]
    public partial bool SetupFromData(byte* data); // TODO: change byte* to DrawData*
    public bool SetupFromData(DrawData* data) => SetupFromData((byte*)data); // TODO: remove

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x08)]
    public partial struct DrawData : ICreatable<DrawData> {
        [FieldOffset(0x00)] public ushort ModelSetId;
        [FieldOffset(0x02)] public ushort SecondaryId;
        [FieldOffset(0x04)] public ushort Variant;
        [BitField<bool>(nameof(LoadMountAnimations), 0)] // comes from CharacterBase.Create param 4 == 1. Load mount resident pap rather than the monster resident pap.
        // [BitField<bool>(nameof(Flag1), 1)] // comes from ModelChara.PackedBool1A & 0x40. Sets bit 0 in Monster+0xA26.
        [BitField<bool>(nameof(LoadOrnamentAnimations), 2)] // comes from CharacterBase.Create param 4 == 2. Load ornament resident pap rather than the monster resident pap.
        [FieldOffset(0x06)] internal byte BitFields;
        [FieldOffset(0x07)] public byte AnimationVariant;

        [MemberFunction("E8 ?? ?? ?? ?? 8B CB E8 ?? ?? ?? ?? 48 8B D8 48 85 C0 0F 84 ?? ?? ?? ?? 0F B6 48 10")]
        public partial DrawData* Ctor();

        /// <summary>
        /// Enables or disables the <see cref="LoadMountAnimations"/> flag.
        /// </summary>
        /// <param name="loadMountAnimations">Whether the flag should be set or removed.</param>
        [MemberFunction("E8 ?? ?? ?? ?? 41 83 FE ?? 48 8D 4C 24 ?? 0F 94 C2 E8 ?? ?? ?? ?? 48 8D 54 24")]
        public partial void SetLoadMountAnimations(bool loadMountAnimations);

        /// <summary>
        /// Enables or disables the <see cref="LoadOrnamentAnimations"/> flag.
        /// </summary>
        /// <param name="loadOrnamentAnimations">Whether the flag should be set or removed.</param>
        [MemberFunction("E8 ?? ?? ?? ?? 48 8D 54 24 ?? 48 8B CF E8 ?? ?? ?? ?? E9")]
        public partial void SetLoadOrnamentAnimations(bool loadOrnamentAnimations);
    }
}
