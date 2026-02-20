using FFXIVClientStructs.FFXIV.Client.Graphics;
using FFXIVClientStructs.FFXIV.Client.LayoutEngine.Node;
using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Client.System.Resource.Handle;
using FFXIVClientStructs.FFXIV.Client.System.Scheduler.Instance;

namespace FFXIVClientStructs.FFXIV.Client.LayoutEngine.Group;

// Client::LayoutEngine::Group::SharedGroupLayoutInstance
//   Client::LayoutEngine::ILayoutInstance
//   Client::System::Resource::ResourceEventListener
/// <summary>
/// A set of instances used together. Can be nested up to 4 levels deep.
/// Each prefab is a scene, however it has some limitations (only single embedded layer group with a single layer is supported).
/// </summary>
[GenerateInterop]
[Inherits<ILayoutInstance>, Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x190)]
public unsafe partial struct SharedGroupLayoutInstance {
    /// <summary>
    /// The number of stains available for objects (housing items).
    /// </summary>
    public const byte ObjectStainCount = 0xC9;

    [FieldOffset(0x038)] public ResourceHandle* ResourceHandle;
    [FieldOffset(0x040)] public LayoutSharedGroupObject* TimelineObject;
    [FieldOffset(0x050)] public Transform Transform;
    [FieldOffset(0x080)] public ChildNodeContainer Instances;
    // [FieldOffset(0x0A8)] public ChildNodeContainer uA8;

    [FieldOffset(0xD0)] public TimeLineContainer TimeLineContainer;

    /// <summary>
    /// Contains stain state, among other things, for supported shared group layouts.
    /// </summary>
    /// <remarks>
    /// Support for staining is based on a hardcoded path check like so:
    /// <code>strstr(path, "/hou/") || strstr(path, "/ind/") || strstr(path, "/mji/") || strstr(path, "/pvp_xx/") &amp;&amp; strstr(path, "cst")</code>
    /// </remarks>
    [FieldOffset(0xF8)] public SharedGroupStainInfo* StainInfo;

    // [FieldOffset(0x108)] public ILayoutInstance* ExtraTimelineInstance; // not sure of purpose
    [FieldOffset(0x110)] public SGActionController* ActionController1;
    [FieldOffset(0x118)] public SGActionController* ActionController2;

    [FieldOffset(0x120)] public uint PrefabFlags1; // 0x1 = load started; 0x3 = load failed or contents added; 0x4 = failed to add contents
    [FieldOffset(0x12C)] public uint PrefabFlags2; // 0x8 = colliders active

    // [FieldOffset(0x14C), FixedSizeArray] internal FixedSizeArray16<byte> _timelineIndices; // used by EventObjAnimation ActorControl packet, some kind of simple lookup table

    [MemberFunction("E8 ?? ?? ?? ?? 41 FF C7 48 8D 76 04")]
    public partial bool InitAnimationHandlers(void* fileData);
    [MemberFunction("E8 ?? ?? ?? ?? 0F BE 8F ?? ?? ?? ?? 83 E9 01")]
    public partial void InitTimelines(void* fileData);

    /// <summary>
    /// Takes the stain selection in <see cref="StainInfo"/> and recursively applies it to the child layout instances.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 44 8B 46 0C 48 8B CE")]
    public partial void ReapplyStain();

    /// <summary>
    /// Looks up the sRGB color for the object stain choice at the given index.
    /// </summary>
    /// <remarks>
    /// Index zero is a sentinel representing leaving the default stain, and will return empty black.
    /// </remarks>
    /// <param name="stainIndex">The object stain index to look up the color of.</param>
    /// <returns>The sRGB color for the given object stain.</returns>
    [MemberFunction("33 C0 81 F9 ?? ?? ?? ?? 0F 42 C1")]
    public static partial ByteColor GetObjectStainColorByIndex(byte stainIndex);

    /// <summary>
    /// Attempts to set the stain on the models in this group.
    /// </summary>
    /// <param name="stainIndex">
    /// The stain index into the table of object stains provided by
    /// <see cref="GetObjectStainColorByIndex(byte)"/>. Zero indicates that the default stain
    /// should be applied, if any.
    /// </param>
    /// <returns>
    /// True if the stain was applied, or false if the object does not support staining or
    /// the given index was out of range (see <see cref="ObjectStainCount"/>).
    /// </returns>
    public bool TryApplyStain(byte stainIndex) {
        if (StainInfo != null && stainIndex < ObjectStainCount) {
            StainInfo->ChosenStainIndex = stainIndex;
            StainInfo->Flags |= SharedGroupStainFlags.StainModified;
            ReapplyStain();
            return true;
        } else {
            return false;
        }
    }
}

[StructLayout(LayoutKind.Explicit, Size = 0xE0)]
public partial struct SharedGroupStainInfo {
    /// <summary>
    /// The stain to use if <see cref="ChosenStainIndex"/> is zero.
    /// </summary>
    [FieldOffset(0x01)] public byte DefaultStainIndex;

    /// <summary>
    /// The stain that has been specified to be used for the group, or zero to use the <see cref="DefaultStainIndex"/>.
    /// </summary>
    /// <remarks>
    /// This will take effect the next time <see cref="SharedGroupLayoutInstance.ReapplyStain"/> is called when
    /// <see cref="Flags"/> has the <see cref="SharedGroupStainFlags.StainModified"/> flag set.
    /// </remarks>
    [FieldOffset(0x02)] public byte ChosenStainIndex;

    [FieldOffset(0x18)] public ChildNodeContainer ChildNodeContainer;

    [FieldOffset(0xC4)] public SharedGroupStainFlags Flags;
}

[Flags]
public enum SharedGroupStainFlags {
    None = 0,

    /// <summary>
    /// If this bit is set, the next call to <see cref="SharedGroupLayoutInstance.ReapplyStain"/> will apply the stain color.
    /// </summary>
    StainModified = (1 << 0),
}
