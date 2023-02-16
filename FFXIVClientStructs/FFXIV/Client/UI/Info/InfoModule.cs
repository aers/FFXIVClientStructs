using FFXIVClientStructs.FFXIV.Client.System.Framework;
using FFXIVClientStructs.FFXIV.Client.System.String;

namespace FFXIVClientStructs.FFXIV.Client.UI.Info; 

[StructLayout(LayoutKind.Explicit, Size = 0x1C70)]
public unsafe struct InfoModule
{
	public static InfoModule* Instance() => Framework.Instance()->UIModule->GetInfoModule();

	[FieldOffset(0x19E0)] public FreeCompanyInfo FreeCompanyInfo;
	
	[FieldOffset(0x1978)] public fixed long InfoProxyArray[34];
	[FieldOffset(0x1A88)] public ulong LocalContentId;
	[FieldOffset(0x1A90)] public Utf8String UnkString0;
	[FieldOffset(0x1AF8)] public Utf8String UnkString1;
	[FieldOffset(0x1B60)] public Utf8String UnkString2;
	[FieldOffset(0x1BC8)] public Utf8String UnkString3;
}
