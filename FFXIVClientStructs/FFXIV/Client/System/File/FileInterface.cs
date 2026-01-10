using System;
using System.Collections.Generic;
using System.Text;

namespace FFXIVClientStructs.FFXIV.Client.System.File;

[GenerateInterop]
[StructLayout(LayoutKind.Explicit, Size = 0x230)]
public unsafe partial struct FileInterface { 
    [FieldOffset(0x10)] public nint FileHandle;
    [FieldOffset(0x20)] public bool IsOpen;

    [MemberFunction("E8 ?? ?? ?? ?? 33 F6 45 32 F6")]
    public partial void Ctor();

    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C8 3C 01"), GenerateStringOverloads]
    public partial sbyte Open(CStringPointer filePath,int openMode);

    [MemberFunction("E8 ?? ?? ?? ?? 8B 05 ?? ?? ?? ?? EB 18")]
    public partial sbyte Close();

    [MemberFunction("E8 ?? ?? ?? ?? 89 1F 33 C0")]
    public partial sbyte Read(void* buffer,ulong size);

    [MemberFunction("E8 ?? ?? ?? ?? 48 8B 44 24 ?? 48 03 E8")]
    public partial sbyte ReadWithOffset(void* buffer, ulong size, ulong offset);

    [MemberFunction("E8 ?? ?? ?? ?? 41 3A C7 75 0E")]
    public partial sbyte Write(void* buffer, ulong size);

    [MemberFunction("E8 ?? ?? ?? ?? 49 2B C6")]
    public partial ulong GetFileSize();
}
