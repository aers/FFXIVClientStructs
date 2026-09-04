using System;
using System.Collections.Generic;
using System.Text;
using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::VerticalFogPlate
//   Client::Graphics::Render::RenderObject
//     Client::Graphics::ReferencedClassBase
[GenerateInterop]
[Inherits<ReferencedClassBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct VerticalFogPlate {
    [FieldOffset(0x10)] private byte _unk10;
    [FieldOffset(0x18)] public ushort TileWidth;
    [FieldOffset(0x1A)] public TerrainGridCoordinates GridCoordinates;
    [FieldOffset(0x20)] public ModelResourceHandle* ModelResourceHandle;
    [FieldOffset(0x28)] public ConstantBufferPointer<VerticalFogPlateConstants> ConstantBuffer;

    [MemberFunction("48 83 EC 38 48 8B 41 20 0F 57 DB")]
    public partial AxisAlignedBounds* ComputeAxisAlignedBounds(AxisAlignedBounds* outBounds);

    public readonly Vector3 Translation => new(TileWidth * (GridCoordinates.TileX + 0.5f), 0.0f, TileWidth * (GridCoordinates.TileZ + 0.5f));
}

[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public struct VerticalFogPlateConstants {
    [FieldOffset(0x0)] public Vector3 Translation;
}
