namespace FFXIVClientStructs.FFXIV.Client.Graphics.Render;

// Client::Graphics::Render::SkeletonHelper
[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 1)]
public unsafe partial struct SkeletonHelper {
    /// <summary> Calls hkaPose::syncModelSpace on every partial skeleton, from <paramref name="first"/> on. </summary>
    [MemberFunction("E8 ?? ?? ?? ?? E8 ?? ?? ?? ?? E8 ?? ?? ?? ?? 41 8B FF")]
    public static partial void SyncModelSpacePoses(Skeleton* first);
}
