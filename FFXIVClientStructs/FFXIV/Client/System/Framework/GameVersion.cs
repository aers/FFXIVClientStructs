using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.Framework;

// Allocates a lot of space for inlined array, even though it only uses 5 strings.
[StructLayout(LayoutKind.Explicit, Size = 0x900)]
[GenerateInterop]
public unsafe partial struct GameVersion {
    [FieldOffset(0x00)][FixedSizeArray(isString: true)] internal FixedSizeArray32<byte> _baseVersion;
    // Big unused gap between base and expansions
    // TODO: make this not an array of arrays
    [FieldOffset(0xE0)][FixedSizeArray] internal FixedSizeArray320<byte> _expansionVersion;

    public string Base => this[0];
    public string Heavensward => this[1];
    public string Stormblood => this[2];
    public string Shadowbringers => this[3];
    public string Endwalker => this[4];

    public string this[int i] {
        get {
            if (i == 0) {
                return BaseVersionString;
            }
            fixed (byte* p = ExpansionVersion) {
                return Encoding.UTF8.GetString(p + i * 32, 32).TrimEnd('\0');
            }
        }
    }
}
