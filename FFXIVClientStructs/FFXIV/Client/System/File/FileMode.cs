namespace FFXIVClientStructs.FFXIV.Client.System.File;

public enum FileMode : byte {
    
    /// <summary>
    /// Reads a file on disk into a ResourceHandle.
    /// </summary>
    LoadUnpackedResource = 0,
    /// <summary>
    /// Reads a file on disk into a byte buffer.
    /// </summary>
    LoadFileResource = 1, // Misleading name, does not involve a ResourceHandle at all
    WriteFile = 2,
    AppendFile = 3,
    Seek = 4,
    GetSize = 5,

    LoadIndexResource = 0xA,
    /// <summary>
    /// Reads an entry in a .sqpack archive into a ResourceHandle.
    /// </summary>
    LoadSqPackResource = 0xB,
}
