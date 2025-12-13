using FFXIVClientStructs.Apricot.Instance;
using FFXIVClientStructs.FFXIV.Client.Graphics.Vfx;

namespace FFXIVClientStructs.Apricot;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x2980)]
public unsafe partial struct ApricotEngine {
	[FieldOffset(0x1128)] public DataContainer* Data;

    [MemberFunction("E8 ?? ?? ?? ?? 4B 8B 0C 27")]
    public static partial ApricotEngine* GetInstance();
    
    [GenerateInterop(isInherited: true)]
	[StructLayout(LayoutKind.Explicit, Size = 0x83030)]
	public partial struct DataContainer {
        [FieldOffset(0x2030), FixedSizeArray] internal FixedSizeArray2048<InstanceContainer> _instances;

        public DocumentInstance* GetDocument(int index) => this._instances[index].Instance;

        public DocumentInstance* GetDocument(VfxResourceHandle handle) => this.GetDocument((int)handle.Index);
    }
}
