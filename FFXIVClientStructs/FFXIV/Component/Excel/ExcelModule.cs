using System.Runtime.InteropServices;
using FFXIVClientStructs.Common;

namespace FFXIVClientStructs.FFXIV.Component.Excel {
    [StructLayout(LayoutKind.Explicit, Size = 0x818)]
    public unsafe partial struct ExcelModule {
        [VirtualFunction(1)]
        public partial void* GetSheetByIndex(uint sheetIndex);

        [VirtualFunction(2)]
        public partial void* GetSheetByName(string sheetName);

        [VirtualFunction(3)]
        public partial void LoadSheet(string sheetName, byte a3 = 0, byte a4 = 0);
    }
}
