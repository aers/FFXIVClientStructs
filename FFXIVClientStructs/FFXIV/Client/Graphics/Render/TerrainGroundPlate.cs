using System;
using System.Collections.Generic;
using System.Text;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Common.Math;

namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::TerrainGroundPlate
//   Client::Graphics::Render::RenderObject
//     Client::Graphics::ReferencedClassBase
[GenerateInterop]
[Inherits<ReferencedClassBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe partial struct TerrainGroundPlate {
    [FieldOffset(0x10)] internal byte Unk10;
    [FieldOffset(0x18)] public TerrainGridCoordinates GridCoordinates;
    [FieldOffset(0x20)] public Vector3 BoundsCenter;
    [FieldOffset(0x30)] public ModelResourceHandle* ModelResourceHandle;
    [FieldOffset(0x38)] public ushort TileWidth; // The size of this plate's grid tile along the X and Z axes, in world units.
    [FieldOffset(0x3A)] public ushort LinearGridIndex; // A single index based on GridCoordinates flattened into the terrain renderer's 1D plate array
    [FieldOffset(0x40)] internal void* PtrModelThingBuffer; // An array of things correspinding to something int the ModelResourceHandle.
    [FieldOffset(0x48)] internal uint ModelThingBufferLength;

    [MemberFunction("48 83 EC 38 48 8B 41 30 4C 8B D2")]
    public partial AxisAlignedBounds* ComputeAxisAlignedBounds(AxisAlignedBounds* outBounds);

    public readonly Vector3 Translation => new(TileWidth * (GridCoordinates.TileX + 0.5f), 0.0f, TileWidth * (GridCoordinates.TileZ + 0.5f));
}
