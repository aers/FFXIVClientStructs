using FFXIVClientStructs.FFXIV.Client.System.String;
using FFXIVClientStructs.FFXIV.Component.GUI;

namespace FFXIVClientStructs.FFXIV.Client.UI;

// Client::UI::AddonGuildLeve
//   Component::GUI::AtkUnitBase
//     Component::GUI::AtkEventListener
[Addon("GuildLeve")]
[GenerateInterop]
[Inherits<AtkUnitBase>]
[StructLayout(LayoutKind.Explicit, Size = 0x1B90)]
public unsafe partial struct AddonGuildLeve {
    [FieldOffset(0x238)] public AtkComponentTreeList* AtkComponentTreeList228;
    [FieldOffset(0x240)] public AtkComponentRadioButton* FieldcraftButton;
    [FieldOffset(0x248)] public AtkComponentRadioButton* TradecraftButton;

    [FieldOffset(0x258), CExporterUnion("Button1")] public AtkComponentRadioButton* CarpenterButton;
    [FieldOffset(0x260), CExporterUnion("Button2")] public AtkComponentRadioButton* BlacksmithButton;
    [FieldOffset(0x268), CExporterUnion("Button3")] public AtkComponentRadioButton* ArmorerButton;
    [FieldOffset(0x270)] public AtkComponentRadioButton* GoldsmithButton;
    [FieldOffset(0x278)] public AtkComponentRadioButton* LeatherworkerButton;
    [FieldOffset(0x280)] public AtkComponentRadioButton* WeaverButton;
    [FieldOffset(0x288)] public AtkComponentRadioButton* AlchemistButton;
    [FieldOffset(0x290)] public AtkComponentRadioButton* CulinarianButton;

    [FieldOffset(0x258), CExporterUnion("Button1")] public AtkComponentRadioButton* MinerButton;
    [FieldOffset(0x260), CExporterUnion("Button2")] public AtkComponentRadioButton* BotanistButton;
    [FieldOffset(0x268), CExporterUnion("Button3")] public AtkComponentRadioButton* FisherButton;

    [FieldOffset(0x298)] public AtkResNode* AtkResNode288;

    [FieldOffset(0x2A0), CExporterUnion("Text1")] public Utf8String CarpenterString;
    [FieldOffset(0x308), CExporterUnion("Text2")] public Utf8String BlacksmithString;
    [FieldOffset(0x370), CExporterUnion("Text3")] public Utf8String ArmorerString;
    [FieldOffset(0x3D8)] public Utf8String GoldsmithString;
    [FieldOffset(0x440)] public Utf8String LeatherworkerString;
    [FieldOffset(0x4A8)] public Utf8String WeaverString;
    [FieldOffset(0x510)] public Utf8String AlchemistString;
    [FieldOffset(0x578)] public Utf8String CulinarianString;

    [FieldOffset(0x2A0), CExporterUnion("Text1")] public Utf8String MinerString;
    [FieldOffset(0x308), CExporterUnion("Text2")] public Utf8String BotanistString;
    [FieldOffset(0x370), CExporterUnion("Text3")] public Utf8String FisherString;

    [FieldOffset(0x5E0)] public AtkComponentButton* JournalButton;
    [FieldOffset(0x5E8)] public AtkTextNode* AtkTextNode298;
    [FieldOffset(0x5F0)] public AtkComponentBase* AtkComponentBase290;
    [FieldOffset(0x5F8)] public AtkComponentBase* AtkComponentBase298;

    [FieldOffset(0x18B0)] public AtkAddonControl AddonControl;
}
