using FFXIVClientStructs.FFXIV.Common.Component.Excel;
using FFXIVClientStructs.FFXIV.Component.Excel;
using ExcelModuleInterface = FFXIVClientStructs.FFXIV.Component.Excel.ExcelModuleInterface;

namespace FFXIVClientStructs.FFXIV.Component.Text;

// this belongs into a Component::Text::Localize namespace but that causes namespace issues
[GenerateInterop]
[Inherits<ExcelLanguageEvent>]
[StructLayout(LayoutKind.Explicit, Size = 0x28)]
public unsafe partial struct Localize {
    [FieldOffset(0x08)] public ExcelModuleInterface* ExcelModuleInterface;
    [FieldOffset(0x10)] public ExcelSheet* ExcelSheet;
    [FieldOffset(0x18)] public StdMap<Utf8String, Pointer<Noun>> NounCache;

    [MemberFunction("E8 ?? ?? ?? ?? 84 C0 74 ?? ?? ?? ?? 4C 8D 4D")]
    public partial bool ProcessNoun(NounParams* nounParams, Utf8String* outString);

    [StructLayout(LayoutKind.Explicit, Size = 0x80)]
    public struct NounParams {
        [FieldOffset(0x00)] public Utf8String SheetName;
        [FieldOffset(0x68)] public int OffsetIndex;
        [FieldOffset(0x6C)] public int RowId;
        [FieldOffset(0x70)] public int Quantity;
        [FieldOffset(0x74)] public int ArticleType;
        [FieldOffset(0x78)] public int GrammaticalCase;
        [FieldOffset(0x7C)] public sbyte LinkMarker; // char. if set, usually '/'
    }

    // Component::Text::Localize::Noun
    [GenerateInterop(isInherited: true)]
    [StructLayout(LayoutKind.Explicit, Size = 0x18)]
    public partial struct Noun {
        [FieldOffset(0x08)] public ExcelSheet* RowSheet;
        [FieldOffset(0x10)] public ExcelSheet* AttributiveSheet;

        [VirtualFunction(0)]
        public partial Noun* Dtor(byte freeFlags);

        [VirtualFunction(1)]
        public partial bool Resolve(NounParams* nounParams, Utf8String* outString);

        [MemberFunction("E8 ?? ?? ?? ?? 44 8B 63 ?? 8B F0")]
        public partial int GetColumnOffset(Utf8String* sheetName);
    }

    // Component::Text::Localize::NounJa
    //   Component::Text::Localize::Noun
    [GenerateInterop]
    [Inherits<Noun>]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct NounJa {
        [FieldOffset(0x20)] public NounJaOffsets* Offsets;

        [StructLayout(LayoutKind.Explicit, Size = 0x04)]
        public struct NounJaOffsets {
            [FieldOffset(0x00)] public int SingularColumnIdx;
        }
    }

    // Component::Text::Localize::NounEn
    //   Component::Text::Localize::Noun
    [GenerateInterop]
    [Inherits<Noun>]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct NounEn {
        [FieldOffset(0x20)] public NounEnOffsets* Offsets;

        [StructLayout(LayoutKind.Explicit, Size = 0x14)]
        public struct NounEnOffsets {
            [FieldOffset(0x00)] public int SingularColumnIdx;
            [FieldOffset(0x04)] public int PluralColumnIdx;
            [FieldOffset(0x08)] public int StartsWithVowelColumnIdx;
            [FieldOffset(0x0C)] public int PossessivePronounColumnIdx;
            [FieldOffset(0x10)] public int ArticleColumnIdx;
        }
    }

    // Component::Text::Localize::NounDe
    //   Component::Text::Localize::Noun
    [GenerateInterop]
    [Inherits<Noun>]
    [StructLayout(LayoutKind.Explicit, Size = 0x58)]
    public partial struct NounDe {
        [FieldOffset(0x20)] public NounDeOffsets* Offsets;
        [FieldOffset(0x28)] public IExcelRowWrapper* AttributiveRow24;
        [FieldOffset(0x30)] public IExcelRowWrapper* AttributiveRow25;
        [FieldOffset(0x38)] public IExcelRowWrapper* AttributiveRow26;
        [FieldOffset(0x40)] public IExcelRowWrapper* AttributiveRow37;
        [FieldOffset(0x48)] public IExcelRowWrapper* AttributiveRow38;
        [FieldOffset(0x50)] public IExcelRowWrapper* AttributiveRow39;

        [StructLayout(LayoutKind.Explicit, Size = 0x1C)]
        public struct NounDeOffsets {
            [FieldOffset(0x00)] public int SingularColumnIdx;
            [FieldOffset(0x04)] public int PluralColumnIdx;
            [FieldOffset(0x08)] public int PronounColumnIdx;
            [FieldOffset(0x0C)] public int AdjectiveColumnIdx;
            [FieldOffset(0x10)] public int PossessivePronounColumnIdx;
            [FieldOffset(0x14)] public int CountabilityColumnIdx;
            [FieldOffset(0x18)] public int ArticleColumnIdx;
        }
    }

    // Component::Text::Localize::NounFr
    //   Component::Text::Localize::Noun
    [GenerateInterop]
    [Inherits<Noun>]
    [StructLayout(LayoutKind.Explicit, Size = 0x28)]
    public partial struct NounFr {
        [FieldOffset(0x20)] public NounFrOffsets* Offsets;

        [StructLayout(LayoutKind.Explicit, Size = 0x18)]
        public struct NounFrOffsets {
            [FieldOffset(0x00)] public int SingularColumnIdx;
            [FieldOffset(0x04)] public int PluralColumnIdx;
            [FieldOffset(0x08)] public int StartsWithVowelColumnIdx;
            [FieldOffset(0x0C)] public int PronounColumnIdx;
            [FieldOffset(0x10)] public int CountabilityColumnIdx;
            [FieldOffset(0x14)] public int ArticleColumnIdx;
        }
    }
}
