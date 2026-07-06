using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Component.GUI;

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct AtkUICommandEntry {
    [FieldOffset(0x00)] public uint SortKey;
    [FieldOffset(0x04)] private uint Unk04; // unused padding
    [FieldOffset(0x08), CExporterUnion("AtkUICommand")] public AtkUICommandClipMask* ClipMaskCommand;
    [FieldOffset(0x08), CExporterUnion("AtkUICommand")] public AtkUICommandDraw* DrawCommand;
}

public enum AtkUICommandType : uint {
    ClipMask = 0x01,
    ClipRect = 0x02,
    // All of the below use AtkUICommandDraw
    DrawLineList = 0x10,
    DrawLineStrip = 0x11,
    DrawTriangleList = 0x20,
    DrawTriangleFan = 0x21,
    DrawQuadList = 0x22,
    DrawTriangleStrip = 0x23,
}

public enum AtkUICommandFormat : ushort {
    Default = 0,
    // 1 & 2 change texture counts which use extended variants of AtkUICommandDraw.
    ClipMask = 3,
}

[StructLayout(LayoutKind.Explicit, Size = 0x60)]
public unsafe struct AtkUICommandClipMask {
    [FieldOffset(0x00)] public AtkUICommandType Type;
    [FieldOffset(0x04)] public AtkUICommandFormat Format;
    [FieldOffset(0x08)] public uint Flags;
    [FieldOffset(0x10)] public Texture* MaskTexture;
    [FieldOffset(0x20)] public Matrix4x4 Transform;
}

[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct AtkUICommandDraw {
    [FieldOffset(0x00)] public AtkUICommandType Type;
    [FieldOffset(0x04)] public AtkUICommandFormat Format;
    [FieldOffset(0x08)] public PackedBlendStateDesc BlendState;
    [FieldOffset(0x10)] public Texture* Texture;
    [FieldOffset(0x18)] private uint Unk18;
    [FieldOffset(0x1C)] private uint Unk1C;
    [FieldOffset(0x20)] public uint VertexCount;
    [FieldOffset(0x28)] public void* VertexData;
    [FieldOffset(0x30)] private uint Unk30;
}

