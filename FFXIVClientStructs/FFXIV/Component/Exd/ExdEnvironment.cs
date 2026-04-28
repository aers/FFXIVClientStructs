using FFXIVClientStructs.FFXIV.Client.System.Resource;
using FFXIVClientStructs.FFXIV.Common.Component.Excel;

namespace FFXIVClientStructs.FFXIV.Component.Exd;

// Component::Exd::ExdEnvironment
//   Common::Component::Excel::IExcelListener
//     Common::Component::Environment::AllocatorInterface
//     Common::Component::Environment::ResourceInterface
//     Common::Component::Environment::DebugInterface
//   Client::System::Resource::ResourceEventListener
[GenerateInterop]
[Inherits<IExcelListener>, Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x168)]
public unsafe partial struct ExdEnvironment {
    [FieldOffset(0x130)] public Common.Component.Excel.LinkedList<ExdModuleResourceHandle> First; // unsure
    [FieldOffset(0x148)] public Common.Component.Excel.LinkedList<ExdModuleResourceHandle> Last; // unsure
}