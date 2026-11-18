using FFXIVClientStructs.FFXIV.Client.Graphics.Render;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;
using FFXIVClientStructs.Havok.Animation.Rig;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Animation;

/// <summary>
/// Rotates individual bones in a Skeleton to point towards target positions.
/// </summary>
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x3A0)]
public unsafe partial struct LookAtIkModule {
    [FieldOffset(0x00)] public uint GroupCount;
    [FieldOffset(0x04)] public uint PartialSkeletonCount;
    [FieldOffset(0x08)] public Skeleton* Skeleton;
    /// <summary>
    /// Each group is a pointer to an array with a group job for each partial skeleton.
    /// </summary>
    [FieldOffset(0x10)] public LookAtGroupJob** Groups;
    [FieldOffset(0x18)] public void* CallbackParam;
    [FieldOffset(0x20)] public delegate* unmanaged<void*, uint, void> PrepareGroupCallback; // called with CallbackParam and the group index from any thread
    [FieldOffset(0x28)] public delegate* unmanaged<void*, void> FinishedCallback; // called with CallbackParam from any thread

    // 0x30 begins a large struct that is created when the Skeleton's Owner is a Human and there is a group with the IsEyes flag
    [FieldOffset(0x30)] internal ulong UnkHumanEyeThing;
    // 0x250 begins a large struct that is created when there is a group with the IsEyes flag
    [FieldOffset(0x250)] internal ulong UnkEyeThing;

    /// <summary>
    /// Returns the index of the first group with a matching ID, or -1 if none were found.
    /// </summary>
    [MemberFunction("48 89 5C 24 ?? 44 8B 11"), GenerateStringOverloads]
    public partial int FindGroup(CStringPointer groupId);

    /// <summary>
    /// A group of bones in a single partial skeleton that should aim towards a shared target point.
    /// </summary>
    /// <remarks>
    /// <para>
    /// There is one of these per partial skeleton for each group.
    /// </para>
    /// <para>
    /// These are generally created by referencing the contents of a <see cref="SkeletonParamResourceHandle.SklpLookAt.LookAtGroup"/>
    /// with the bones present in the target partial skeleton.
    /// </para>
    /// </remarks>
    [GenerateInterop]
    [StructLayout(LayoutKind.Explicit, Size = 0x50)]
    public unsafe partial struct LookAtGroupJob {
        [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray16<byte> _groupId;
        [FieldOffset(0x20)] public Vector3 TargetPosition;
        [FieldOffset(0x30)] public Skeleton* Skeleton;
        [FieldOffset(0x38)] public uint BoneCount;
        [FieldOffset(0x3C)] public float Amount; // Multiplied by each bone's BaseWeight to produce its FinalWeight
        [FieldOffset(0x40)] public GroupFlags Flags;
        [FieldOffset(0x48)] public LookAtBone* Bones;

        public Span<LookAtBone> BonesSpan => new(Bones, (int)BoneCount);
    }

    [Flags]
    public enum GroupFlags : uint {
        None = 0,
        /// <summary>
        /// The group should be applied.
        /// </summary>
        IsEnabled = 1 << 0,
        /// <summary>
        /// The group is named <c>"eyes"</c> or <c>"Eyes"</c>
        /// </summary>
        IsEyes = 1 << 1,
        /// <summary>
        /// Set when the angle between the line from the world origin to the group's new target position and the origin to the group's old target position is large enough.
        /// </summary>
        /// <remarks>
        /// Honestly I'm not really sure what purpose this serves. Could it be a mistake where it's meant to be the angle to the new and old targets *relative to the character*?
        /// </remarks>
        DiscontinuousJump = 1 << 2,
        Unk4 = 1 << 3,
    }

    /// <summary>
    /// Controls how a bone in a look-at group is rotated to face the target point.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 0x70)]
    public struct LookAtBone {
        [FieldOffset(0x00)] public float LimitAngleUp;
        [FieldOffset(0x04)] public float LimitAngleDown;
        [FieldOffset(0x08)] public float LimitAngleLeft;
        [FieldOffset(0x0C)] public float LimitAngleRight;

        [FieldOffset(0x20)] public Vector4 EyePositionLocalSpace; // where the bone is 'looking from' relative to itself
        [FieldOffset(0x30)] public hkaPose* Pose;
        [FieldOffset(0x38)] public float LimitAngleRadians;
        [FieldOffset(0x3C)] public float BaseWeight; // The weight of the look-at effect excluding any runtime fading
        [FieldOffset(0x40)] public BoneFlags Flags;

        [FieldOffset(0x44)] public ushort PartialSkeletonIndex;
        [FieldOffset(0x46)] public ushort BoneIndexToRotate;
        [FieldOffset(0x48)] public ushort BoneIndexRangeLimits;

        [FieldOffset(0x50)] public float FinalWeight; // The final weight including any runtime modifications
        [FieldOffset(0x54)] public uint Unk54;
        [FieldOffset(0x58)] public Skeleton* Skeleton;
        [FieldOffset(0x60)] public bool IsEnabled;
        [FieldOffset(0x61)] internal bool Unk61;
    }

    [Flags]
    public enum BoneFlags : byte {
        None = 0,
        HasRangeLimits = 1 << 0,
    }
}
