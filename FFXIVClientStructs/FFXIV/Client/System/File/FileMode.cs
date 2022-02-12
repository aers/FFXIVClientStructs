namespace FFXIVClientStructs.FFXIV.Client.System.File;

public enum FileMode : uint
{
    // based on penumbra
    LoadUnpackedResource = 0,
    LoadFileResource = 1,
    CreateFileResource = 2,
    LoadIndexResource = 0xA,
    LoadSqPackResource = 0xB
}