using FFXIVClientStructs.Havok.Animation;
using FFXIVClientStructs.Havok.Animation.Animation;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::PartialAnimationPackResourceHandle
//   Client::System::Resource::Handle::DefaultResourceHandle
//     Client::System::Resource::Handle::ResourceHandle
//       Client::System::Common::NonCopyable
// .pap
[GenerateInterop]
[Inherits<DefaultResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0x118)]
public unsafe partial struct PartialAnimationPackResourceHandle {
    [FieldOffset(0xC0)] public hkaAnimationContainer* HavokAnimationContainer;
    [FieldOffset(0xD8)] public ushort AnimationCount;
    [FieldOffset(0xF0)] public Animation* AnimationsPtr;

    public Span<Animation> Animations => new(AnimationsPtr, AnimationCount);

    /// <summary>
    /// Searches <see cref="Animations"/> for an animation with the given name.
    /// </summary>
    /// <param name="animationName">The name of the animation to search for.</param>
    /// <returns>The index of the first animation with the given name, or -1 if no matching animation was found.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 66 85 C0 79 45"), GenerateStringOverloads]
    public partial int GetAnimationIndex(CStringPointer animationName);

    /// <summary>
    /// Searches <see cref="Animations"/> for an animation with the given name and returns its <see cref="Animation.HavokIndex"/>.
    /// </summary>
    /// <param name="animationName">The name of the animation to search for.</param>
    /// <returns>The index of the animation's Havok binding, or -1 if no matching animation was found.</returns>
    [MemberFunction("48 89 5C 24 ?? 44 0F B7 91 ?? ?? ?? ?? 45 33 C0"), GenerateStringOverloads]
    public partial int GetAnimationHavokIndex(CStringPointer animationName);

    /// <summary>
    /// Searches <see cref="Animations"/> for an animation with the given name and the <see cref="Animation.IsFaceAnimation"/> flag
    /// and returns its <see cref="Animation.HavokIndex"/>.
    /// </summary>
    /// <param name="facialAnimationName">The name of the facial animation to search for.</param>
    /// <returns>The index of the first animation with the given name and the facial animation flag, or -1 if no matching animation was found.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 66 85 C0 78 10"), GenerateStringOverloads]
    public partial int GetFacialAnimationHavokIndex(CStringPointer facialAnimationName);

    /// <summary>
    /// Searches for an animation with the given name and returns its Havok animation binding.
    /// </summary>
    /// <param name="animationName">The name of the animation to search for.</param>
    /// <returns>The Havok animation binding for the animation, or <see langword="null"/> if none was found.</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 0D ?? ?? ?? ?? 4C 8B F0 48 8B 49 38"), GenerateStringOverloads]
    public partial hkaAnimationBinding* GetAnimationHavokBinding(CStringPointer animationName);

    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct Animation {
        [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _name;
        [FieldOffset(0x20)] public short Type;
        [FieldOffset(0x22)] public ushort HavokIndex;
        [BitField<bool>(nameof(IsFaceAnimation), 0)]
        [FieldOffset(0x24)] public byte Flags;
    }
}
