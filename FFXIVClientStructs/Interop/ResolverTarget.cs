using System.Diagnostics;
using System.Reflection;

namespace FFXIVClientStructs.Interop;

public unsafe class ResolverTarget
{
    public nint TargetSpace;
    public int TargetLength;

    public int TextSectionOffset;
    public int TextSectionSize;
    public int DataSectionOffset;
    public int DataSectionSize;
    public int RdataSectionOffset;
    public int RdataSectionSize;

    private ResolverTarget(ProcessModule module) : this(module, module.BaseAddress)
    {
    }

    private ResolverTarget(ProcessModule module, nint memoryPointer)
    {
        TargetSpace = memoryPointer;
        TargetLength = module.ModuleMemorySize;
        SetSearchSpace(module);
    }
    
    public ResolverTarget(nint memoryPointer, int memorySize, int textSectionOffset, int textSectionSize, 
        int dataSectionOffset, int dataSectionSize, int rdataSectionOffset, int rdataSectionSize)
    {
        TargetSpace = memoryPointer;
        TargetLength = memorySize;
        TextSectionOffset = textSectionOffset;
        TextSectionSize = textSectionSize;
        DataSectionOffset = dataSectionOffset;
        DataSectionSize = dataSectionSize;
        RdataSectionOffset = rdataSectionOffset;
        RdataSectionSize = rdataSectionSize;
    }

    public static ResolverTarget FromRunningModule()
    {
        ProcessModule module = Process.GetCurrentProcess().MainModule;
        return new ResolverTarget(module);
    }

    public static ResolverTarget FromRunningModuleWithCopy(nint copyPointer)
    {
        ProcessModule module = Process.GetCurrentProcess().MainModule;
        return new ResolverTarget(module, copyPointer);
    }
    
    private void SetSearchSpace(ProcessModule module)
    {
        ReadOnlySpan<byte> baseAddress = new(module.BaseAddress.ToPointer(), module.ModuleMemorySize);

        // We don't want to read all of IMAGE_DOS_HEADER or IMAGE_NT_HEADER stuff so we cheat here.
        int ntNewOffset = BitConverter.ToInt32(baseAddress.Slice(0x3C, 4));
        ReadOnlySpan<byte> ntHeader = baseAddress[ntNewOffset..];

        // IMAGE_NT_HEADER
        ReadOnlySpan<byte> fileHeader = ntHeader[4..];
        short numSections = BitConverter.ToInt16(ntHeader.Slice(6, 2));

        // IMAGE_OPTIONAL_HEADER
        ReadOnlySpan<byte> optionalHeader = fileHeader[20..];

        ReadOnlySpan<byte> sectionHeader = optionalHeader[240..]; // IMAGE_OPTIONAL_HEADER64

        // IMAGE_SECTION_HEADER
        ReadOnlySpan<byte> sectionCursor = sectionHeader;
        for (int i = 0; i < numSections; i++)
        {
            long sectionName = BitConverter.ToInt64(sectionCursor);

            // .text
            switch (sectionName)
            {
                case 0x747865742E: // .text
                    TextSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                    TextSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
                    break;
                case 0x617461642E: // .data
                    DataSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                    DataSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
                    break;
                case 0x61746164722E: // .rdata
                    RdataSectionOffset = BitConverter.ToInt32(sectionCursor.Slice(12, 4));
                    RdataSectionSize = BitConverter.ToInt32(sectionCursor.Slice(8, 4));
                    break;
            }

            sectionCursor = sectionCursor[40..]; // advance by 40
        }
    }

    public ReadOnlySpan<byte> AsSpan()
    {
        return new ReadOnlySpan<byte>(TargetSpace.ToPointer(), TargetLength);
    }
}