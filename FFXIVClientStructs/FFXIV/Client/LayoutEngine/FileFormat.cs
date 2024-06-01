using System.Numerics;
using System.Runtime.CompilerServices;
using FFXIVClientStructs.FFXIV.Client.Game;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Layer;
using FFXIVClientStructs.FFXIV.Common.Component.BGCollision.Math;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine;

// various files used by layout engine (at least LVB/LCB) are simple containers with one or more sections
// typically they have one section each (SCN1 for LVB, LGP1 for LCB)
// nested subsections are identified by byte offsets from parent section start
// strings are generally located at the end of the file
[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public unsafe struct FileHeader {
    [FieldOffset(0)] public uint Magic;
    [FieldOffset(4)] public uint TotalSize;
    [FieldOffset(8)] public uint NumSections;

    [CExportIgnore]
    public unsafe ref struct Enumerator {
        private FileHeader* _header;
        private FileSectionHeader* _next;
        private FileSectionHeader* _current;
        private int _nextIndex;

        internal Enumerator(FileHeader* header) {
            _header = header;
            Reset();
        }

        public bool MoveNext() {
            _current = _next;
            ++_nextIndex;
            _next = _nextIndex < _header->NumSections ? (FileSectionHeader*)((byte*)_next + _next->TotalSize) : null;
            return _current != null;
        }

        public void Reset() {
            _current = null;
            _next = (FileSectionHeader*)(_header + 1);
            _nextIndex = 0;
        }

        public FileSectionHeader* Current => _current;

        public Enumerator GetEnumerator() => this;
    }
    public Enumerator Sections => new((FileHeader*)Unsafe.AsPointer(ref this));
}

// each section is preceeded by a header that allows identifying type and skipping forward
[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct FileSectionHeader {
    [FieldOffset(0)] public uint Magic;
    [FieldOffset(4)] public uint TotalSize;

    public T* Data<T>() where T : unmanaged => (T*)((FileSectionHeader*)Unsafe.AsPointer(ref this) + 1);
}

// SCN1 header - this is the main (only?) section of LVB file
// scene is a set of layer groups, layer groups consist of layers, and layers consist of object instances
// layer group is a purely logical grouping of layers that contain similar objects (e.g. background, vfx, sounds, etc)
// multiple territories can use the same scene, so individual layers can be enabled or disabled based on conditions
[StructLayout(LayoutKind.Explicit, Size = 0x40)]
public unsafe struct FileSceneHeader {
    [FieldOffset(0x00)] public int OffsetEmbeddedLayerGroups; // offset to FileLayerGroupHeader[NumEmbeddedLayerGroups]
    [FieldOffset(0x04)] public int NumEmbeddedLayerGroups;
    [FieldOffset(0x08)] public int OffsetGeneral; // offset to FileSceneGeneral
    [FieldOffset(0x0C)] public int OffsetFilters; // offset to FileSceneFilterList
    //[FieldOffset(0x10)] public int Offset10;
    [FieldOffset(0x14)] public int OffsetLayerGroupResources; // offset to a list of path offsets (ints)
    [FieldOffset(0x18)] public int NumLayerGroupResources;
    //[FieldOffset(0x20)] public int Offset20;

    public Span<FileLayerGroupHeader> EmbeddedLayerGroups => new((byte*)Unsafe.AsPointer(ref this) + OffsetEmbeddedLayerGroups, NumEmbeddedLayerGroups);
    public FileSceneGeneral* General => OffsetGeneral > 0 ? (FileSceneGeneral*)((byte*)Unsafe.AsPointer(ref this) + OffsetGeneral) : null;
    public FileSceneFilterList* Filters => OffsetFilters > 0 ? (FileSceneFilterList*)((byte*)Unsafe.AsPointer(ref this) + OffsetFilters) : null;
    public Span<int> LayerGroupResourceOffsets => new((byte*)Unsafe.AsPointer(ref this) + OffsetLayerGroupResources, NumLayerGroupResources);
    public byte* LayerGroupResource(int offset) => (byte*)Unsafe.AsPointer(ref this) + OffsetLayerGroupResources + offset;
}

// first subsection of the SCN1, contains general properties of the scene
[StructLayout(LayoutKind.Explicit, Size = 0x58)]
public unsafe struct FileSceneGeneral {
    [FieldOffset(0x00)] public bool HaveLayerGroups;
    [FieldOffset(0x04)] public int OffsetPathTerrain;
    [FieldOffset(0x08)] public int OffsetEnvSpaces;
    [FieldOffset(0x0C)] public int NumEnvSpaces;
    [FieldOffset(0x14)] public int OffsetPathSkyVisibility;
    [FieldOffset(0x34)] public int OffsetPathLCB;
    [FieldOffset(0x4C)] public bool HaveLCBUW;

    public byte* PathTerrain => OffsetPathTerrain > 0 ? (byte*)Unsafe.AsPointer(ref this) + OffsetPathTerrain : null;
    public byte* PathSkyVisibility => OffsetPathSkyVisibility > 0 ? (byte*)Unsafe.AsPointer(ref this) + OffsetPathSkyVisibility : null;
    public byte* PathLCB => OffsetPathLCB > 0 ? (byte*)Unsafe.AsPointer(ref this) + OffsetPathLCB : null;
}

[StructLayout(LayoutKind.Explicit, Size = 0x8)]
public unsafe struct FileSceneFilterList {
    [FieldOffset(0)] public int OffsetEntries; // offset to FileSceneFilter[NumEntries]
    [FieldOffset(4)] public int NumEntries;

    public Span<FileSceneFilter> Entries => new((byte*)Unsafe.AsPointer(ref this) + OffsetEntries, NumEntries);
}

[StructLayout(LayoutKind.Explicit, Size = 0x1C)]
public unsafe struct FileSceneFilter {
    //[FieldOffset(0x00)] public int u0;
    [FieldOffset(0x04)] public uint Key;
    //[FieldOffset(0x08)] public int u8;
    //[FieldOffset(0x0C)] public int uC;
    [FieldOffset(0x10)] public ushort TerritoryTypeId;
    [FieldOffset(0x12)] public ushort CfcId;
    //[FieldOffset(0x14)] public int u14;
    //[FieldOffset(0x18)] public int u18;
}


// LGP1 header - this is the main (only?) section of LGB file
[StructLayout(LayoutKind.Explicit, Size = 0x10)]
public unsafe struct FileLayerGroupHeader {
    [FieldOffset(0x00)] public int Id;
    [FieldOffset(0x04)] public int OffsetLayerGroupName;
    [FieldOffset(0x08)] public int OffsetLayers; // offset of int array - offsets to FileLayerGroupLayer
    [FieldOffset(0x0C)] public int NumLayers;

    public byte* LayerGroupName => OffsetLayerGroupName > 0 ? (byte*)Unsafe.AsPointer(ref this) + OffsetLayerGroupName : null;
    public Span<int> LayerOffsets => new((byte*)Unsafe.AsPointer(ref this) + OffsetLayers, NumLayers);
    public FileLayerGroupLayer* Layer(int offset) => (FileLayerGroupLayer*)((byte*)Unsafe.AsPointer(ref this) + OffsetLayers + offset);
}

[StructLayout(LayoutKind.Explicit, Size = 0x34)]
public unsafe struct FileLayerGroupLayer {
    [FieldOffset(0x00)] public ushort Key;
    [FieldOffset(0x04)] public int OffsetLayerName;
    [FieldOffset(0x08)] public int OffsetInstances; // offset of int array - offsets to FileLayerGroupInstance
    [FieldOffset(0x0C)] public int NumInstances;
    //[FieldOffset(0x10)] public byte u10;
    //[FieldOffset(0x11)] public byte u11;
    [FieldOffset(0x14)] public int OffsetFilter; // offset of FileLayerGroupLayerFilter
    [FieldOffset(0x18)] public GameMain.Festival Festival;
    //[FieldOffset(0x1C)] public byte u1C;
    //[FieldOffset(0x20)] public byte u20;

    public byte* LayerName => OffsetLayerName > 0 ? (byte*)Unsafe.AsPointer(ref this) + OffsetLayerName : null;
    public FileLayerGroupLayerFilter* Filter => OffsetFilter > 0 ? (FileLayerGroupLayerFilter*)((byte*)Unsafe.AsPointer(ref this) + OffsetFilter) : null;
    public Span<int> InstanceOffsets => new((byte*)Unsafe.AsPointer(ref this) + OffsetInstances, NumInstances);
    public FileLayerGroupInstance* Instance(int offset) => (FileLayerGroupInstance*)((byte*)Unsafe.AsPointer(ref this) + OffsetInstances + offset);
}

[StructLayout(LayoutKind.Explicit, Size = 0xC)]
public unsafe struct FileLayerGroupLayerFilter {
    public enum Op {
        None, // no filter, layer is always active (list is empty)
        Match, // layer is active if list contains key
        NoMatch, // layer is active if list does not contain key
    }

    [FieldOffset(0)] public Op Operation;
    [FieldOffset(4)] public int OffsetListEntries;
    [FieldOffset(8)] public int NumListEntries;

    public Span<uint> Entries => new((byte*)Unsafe.AsPointer(ref this) + OffsetListEntries, NumListEntries);
}

[StructLayout(LayoutKind.Explicit, Size = 0x24)]
public unsafe struct FileLayerGroupTransform {
    [FieldOffset(0x00)] public Vector3 Translation;
    [FieldOffset(0x0C)] public Vector3 Rotation; // euler angles
    [FieldOffset(0x18)] public Vector3 Scale;
}

[GenerateInterop(isInherited: true)]
[StructLayout(LayoutKind.Explicit, Size = 0x30)]
public unsafe partial struct FileLayerGroupInstance {
    [FieldOffset(0x00)] public InstanceType Type;
    [FieldOffset(0x04)] public uint Key;
    [FieldOffset(0x08)] public int OffsetName;
    [FieldOffset(0x0C)] public FileLayerGroupTransform Transform;

    public byte* Name => OffsetName > 0 ? (byte*)Unsafe.AsPointer(ref this) + OffsetName : null;
}

[GenerateInterop]
[Inherits<FileLayerGroupInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x5C)]
public unsafe partial struct FileLayerGroupInstanceBgPart {
    public enum Collider { None, Mesh, Analytic }

    [FieldOffset(0x30)] public int OffsetPathMdl;
    [FieldOffset(0x34)] public int OffsetPathPcb;
    [FieldOffset(0x38)] public Collider ColliderType;
    [FieldOffset(0x3C)] public uint MaterialMaskLow;
    [FieldOffset(0x40)] public uint MaterialIdLow;
    [FieldOffset(0x44)] public uint MaterialMaskHigh;
    [FieldOffset(0x48)] public uint MaterialIdHigh;
    [FieldOffset(0x4C)] public int OffsetColliderAnalyticData; // offset of FileLayerGroupAnalyticCollider
    //[FieldOffset(0x50)] public byte u50;
    //[FieldOffset(0x51)] public byte u51;
    //[FieldOffset(0x52)] public byte u52;
    //[FieldOffset(0x53)] public byte u53;
    //[FieldOffset(0x54)] public float u54;
    //[FieldOffset(0x54)] public int u58;

    public byte* PathMdl => OffsetPathMdl > 0 ? (byte*)Unsafe.AsPointer(ref this) + OffsetPathMdl : null;
    public byte* PathPcb => OffsetPathPcb > 0 ? (byte*)Unsafe.AsPointer(ref this) + OffsetPathPcb : null;
    public FileLayerGroupAnalyticCollider* ColliderAnalyticData => OffsetColliderAnalyticData > 0 ? (FileLayerGroupAnalyticCollider*)((byte*)Unsafe.AsPointer(ref this) + OffsetColliderAnalyticData) : null;
}

[StructLayout(LayoutKind.Explicit, Size = 0x50)]
public unsafe struct FileLayerGroupAnalyticCollider {
    public enum Type { None, Box, Sphere, Cylinder, Plane }

    [FieldOffset(0x00)] public uint MaterialMask;
    [FieldOffset(0x04)] public uint MaterialId;
    //[FieldOffset(0x08)] public uint u8;
    //[FieldOffset(0x0C)] public uint uC;
    [FieldOffset(0x10)] public Type ColliderType;
    [FieldOffset(0x14)] public FileLayerGroupTransform Transform;
    [FieldOffset(0x38)] public AABB Bounds;
}

// used for SharedGroup and HelperObject
[GenerateInterop]
[Inherits<FileLayerGroupInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x98)]
public unsafe partial struct FileLayerGroupInstanceSharedGroup {
    [FieldOffset(0x30)] public int OffsetPath;
    //[FieldOffset(0x34)] public int u34;
    //[FieldOffset(0x38)] public int u38;
    //[FieldOffset(0x3C)] public int u3C;
    //[FieldOffset(0x40)] public int u40;

    public byte* Path => OffsetPath > 0 ? (byte*)Unsafe.AsPointer(ref this) + OffsetPath : null;
}

// base class used for various colliders / trigger volumes
[GenerateInterop(isInherited: true)]
[Inherits<FileLayerGroupInstance>]
[StructLayout(LayoutKind.Explicit, Size = 0x3C)]
public unsafe partial struct FileLayerGroupInstanceTriggerBox {
    [FieldOffset(0x30)] public ColliderType ColliderType;
    //[FieldOffset(0x34)] public ushort u34;
    [FieldOffset(0x36)] public bool ActiveByDefault;
}

[GenerateInterop]
[Inherits<FileLayerGroupInstanceTriggerBox>]
[StructLayout(LayoutKind.Explicit, Size = 0x54)]
public unsafe partial struct FileLayerGroupInstanceCollisionBox {
    [FieldOffset(0x3C)] public uint MaterialMaskLow;
    [FieldOffset(0x40)] public uint MaterialIdLow;
    [FieldOffset(0x44)] public uint MaterialMaskHigh;
    [FieldOffset(0x48)] public uint MaterialIdHigh;
    [FieldOffset(0x4C)] public bool Layer43h;
    [FieldOffset(0x50)] public int OffsetPath;

    public byte* Path => OffsetPath > 0 ? (byte*)Unsafe.AsPointer(ref this) + OffsetPath : null;
}
