using FFXIVClientStructs.Havok.Common.Base.Math.Vector;

namespace FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;

// Client::System::Resource::Handle::SkeletonParamResourceHandle
//   Client::System::Resource::Handle::DefaultResourceHandle
//     Client::System::Resource::Handle::ResourceHandle
//       Client::System::Common::NonCopyable
// .skp
[GenerateInterop]
[Inherits<DefaultResourceHandle>]
[StructLayout(LayoutKind.Explicit, Size = 0x148)]
public unsafe partial struct SkeletonParamResourceHandle {
    [FieldOffset(0xC0)] public SklpHeader Header;
    [FieldOffset(0xE0)] public SklpLookAt LookAt;
    [FieldOffset(0x100)] public SklpSlope Slope;
    [FieldOffset(0x128)] public SklpFeet Feet;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct SklpHeader {
        [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray4<byte> _magic;
        [FieldOffset(0x04), FixedSizeArray(isString: true)] internal FixedSizeArray4<byte> _version;
        [FieldOffset(0x08)] public SkpFlag Flags;
        [FieldOffset(0x0C)] public uint HeaderSize;
        [FieldOffset(0x10)] public uint LookAtOffset;
        [FieldOffset(0x14)] public uint CCDOffset;
        [FieldOffset(0x18)] public uint FeetOffset;
        [FieldOffset(0x1C)] public uint SlopeOffset;
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public partial struct SklpLookAt {
        [FieldOffset(0x00)] public byte ParameterCount;
        [FieldOffset(0x01)] public byte GroupCount;
        [FieldOffset(0x08)] public byte* GroupElementCount;
        [FieldOffset(0x10)] public LookAtParam* Parameters;
        [FieldOffset(0x18)] public LookAtGroup* Groups;

        public Span<LookAtParam> ParametersSpan => new(Parameters, ParameterCount);
        public Span<LookAtGroup> GroupsSpan => new(Groups, GroupCount);

        [StructLayout(LayoutKind.Explicit, Size = 0x38)]
        public struct LookAtParam {
            [FieldOffset(0x00)] public hkVector4f ForwardLookAtVector;
            [FieldOffset(0x10)] public float ForwardRotationX;
            [FieldOffset(0x14)] public float ForwardRotationY;
            [FieldOffset(0x18)] public float ForwardRotationZ;
            [FieldOffset(0x1C)] public float LimitAngle;
            [FieldOffset(0x20)] public float EyePositionX;
            [FieldOffset(0x24)] public float EyePositionY;
            [FieldOffset(0x28)] public float EyePositionZ;
            [FieldOffset(0x2C)] public uint Flags;
            [FieldOffset(0x30)] public float Gain;
            [FieldOffset(0x34)] public uint Index;
        }

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x30)]
        public partial struct LookAtGroup {
            [FieldOffset(0x00), FixedSizeArray(isString: true)] internal FixedSizeArray8<byte> _groupId;
            [FieldOffset(0x20)] public byte ElementCount;
            [FieldOffset(0x28)] public LookAtElement* Elements;

            public Span<LookAtElement> ElementsSpan => new(Elements, ElementCount);
        }

        [GenerateInterop]
        [StructLayout(LayoutKind.Explicit, Size = 0x42)]
        public partial struct LookAtElement {
            [FieldOffset(0x00)] public byte Priority;
            [FieldOffset(0x01)] public byte SetupParameterIndex;
            [FieldOffset(0x02), FixedSizeArray(isString: true)] internal FixedSizeArray14<byte> _boneName;
            [FieldOffset(0x22), FixedSizeArray(isString: true)] internal FixedSizeArray14<byte> _parentBoneName;
        }
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public struct SklpSlope;

    [StructLayout(LayoutKind.Explicit, Size = 0x20)]
    public struct SklpFeet;
}

[Flags]
public enum SkpFlag {
    Animation = 0x01,
    LookAt = 0x02,
    CCD = 0x04,
    Feet = 0x08,
    Slope = 0x10
}
