using FFXIVClientStructs.FFXIV.Client.System.Memory;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Client.Game.Event;

[GenerateInterop]
[Inherits<ExcelSheetWaiter>]
[StructLayout(LayoutKind.Explicit, Size = 0xB8)]
public unsafe partial struct RacingChocoboNameResolver : ICreatable<RacingChocoboNameResolver> {
    [FieldOffset(0x30)] private nint Unk30; // 3?
    [FieldOffset(0x38)] public RacingChocoboNameResolver* WaiterCallbackThisArg;
    [FieldOffset(0x40)] public void* WaiterCallback;
    [FieldOffset(0x48)] public ExcelSheet* Sheet; // RacingChocoboName
    [FieldOffset(0x50)] public bool WaiterCallbackCalled;
    [FieldOffset(0x58)] public bool HasComposedName;
    [FieldOffset(0x5A)] public ushort FirstNameId;
    [FieldOffset(0x5C)] public ushort LastNameId;
    [FieldOffset(0x5E), FixedSizeArray(isString: true)] internal FixedSizeArray64<byte> _fullName;
    [FieldOffset(0xA0)] public delegate* unmanaged<void*, void*, void>  Callback;
    [FieldOffset(0xA8)] public void* CallbackThisArg;
    [FieldOffset(0xB0)] public void* CallbackArg;

    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B7 C7 49 8D 4E")]
    public partial RacingChocoboNameResolver* Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? B8 ?? ?? ?? ?? 66 89 43 ?? 48 83 C4")]
    public partial void SetCallback(delegate* unmanaged<void*, void*, void> callback, void* callbackThisArg, void* callbackArg = null);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 5C 24 ?? EB ?? 33 FF")]
    public partial void Resolve(ushort firstNameId, ushort lastNameId);
}
