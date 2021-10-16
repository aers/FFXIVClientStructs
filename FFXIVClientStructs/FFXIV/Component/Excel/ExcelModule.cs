using System.Runtime.InteropServices;
using FFXIVClientStructs.Attributes;

namespace FFXIVClientStructs.FFXIV.Component.Excel {
    [StructLayout(LayoutKind.Explicit, Size = 0x818)]
    public unsafe partial struct ExcelModule {
        [VirtualFunction(1)]
        public partial ExcelSheet* GetSheetByIndex(uint sheetIndex);

        [VirtualFunction(2)]
        public partial ExcelSheet* GetSheetByName(string sheetName);

        [VirtualFunction(3)]
        public partial void LoadSheet(string sheetName, byte a3 = 0, byte a4 = 0);
    }
}
