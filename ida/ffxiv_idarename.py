# current exe version: 2020.12.02.0000.0000

from __future__ import print_function

try:
    from typing import List, Optional
except ImportError:
    pass

try:
    import idaapi
    import idc

    # @formatter:off
    get_image_base = idaapi.get_imagebase  # func()->ea
    set_addr_name = idc.set_name           # func(ea, name)->1: ok, 0: fail
    get_addr_name = idc.get_name           # func(ea)->name: ok, "": fail
    get_qword = idc.get_qword              # func(ea)->long
    def is_offset(ea): return idc.is_off0(idc.get_full_flags(ea))  # func(ea)->bool
    # @formatter:on
except ImportError:  # Ghidra
    # @formatter:off
    def get_image_base():        raise NotImplementedError  # noqa
    def set_addr_name(ea, name): raise NotImplementedError  # noqa
    def get_addr_name(ea):       raise NotImplementedError  # noqa
    def get_qword(ea):           raise NotImplementedError  # noqa
    def is_offset(ea):           raise NotImplementedError  # noqa
    # @formatter:on

NameAddr = set_addr_name

print("Importing IDA data ...")


# TODO: Biggest thing: inheritance needs to be setup so that the base functions get named properly.
# TODO: Test the image offset stuff, should set the names regardless of your current image base
# TODO: Force the vtable into a struct, fancy decompiled output
# TODO: VTables with a count of 1 are likely placeholders. Figure out their true vfunc count
# TODO: Move individually named functions into their vtable definition

class VTable(object):
    STANDARD_IMAGE_BASE = 0x140000000L
    IMAGE_OFFSET = 0x0L

    VTBL_FORMAT = "vtbl_{name}"
    NAMED_FORMAT = "{name}_{vf_name}"
    SUB_FORMAT = "{name}_vf{number}"
    NULLSUB_FORMAT = "{name}_vf{number}_nullsub"

    SUB_PREFIX = "sub_"
    NULLSUB_PREFIX = "nullsub_"
    PURECALL = "_purecall"

    def __init__(self, vtable_addr, class_name, vfunc_count):
        current_image_base = get_image_base()
        if self.STANDARD_IMAGE_BASE != current_image_base:
            self.IMAGE_OFFSET = self.STANDARD_IMAGE_BASE - current_image_base

        self.vtable_addr = vtable_addr + self.IMAGE_OFFSET  # type: long
        self.class_name = class_name  # type: str
        self.vfunc_count = vfunc_count  # type: int
        self.vtbl_entries = []  # type: List[Optional[long]]

        set_addr_name(self.vtable_addr, self.VTBL_FORMAT.format(name=self.class_name))

        # Add all the dq offset vfuncs
        for vfunc_rel_offset in xrange(0, self.vfunc_count * 8, 8):
            vfunc_offset = self.vtable_addr + vfunc_rel_offset
            vfunc_addr = get_qword(vfunc_offset)  # type: long
            if not is_offset(vfunc_offset):
                print("Skipping: vtbl {0} offset {1:X} is not an offset: {2:X}".format(self.class_name, vfunc_rel_offset, vfunc_addr))
                self.vtbl_entries.append(None)
            else:
                self.vtbl_entries.append(vfunc_addr)

    def set_defaults(self):
        for index in xrange(len(self.vtbl_entries)):
            self.set(index, None)

    def set(self, vfunc_index, name=None):
        """
        Set the name of a vfunc target via vfunc index from the vtable start
        :param vfunc_index: VFunc index from the VTable start ea
        :param name: VFunc name, None for default
        :return: self
        """
        vfunc_addr = self.vtbl_entries[vfunc_index]
        if vfunc_addr is None:
            return

        vfunc_name = get_addr_name(vfunc_addr)  # type: str

        if name is not None:
            vfunc_target_name = self.NAMED_FORMAT.format(name=self.class_name, vf_name=name)
            set_addr_name(vfunc_addr, vfunc_target_name)
        else:
            if self.class_name in vfunc_name:
                return
            elif vfunc_name == self.PURECALL:
                return
            elif vfunc_name.startswith(self.SUB_PREFIX):
                vfunc_target_name = self.SUB_FORMAT.format(name=self.class_name, number=vfunc_index)
                set_addr_name(vfunc_addr, vfunc_target_name)
            elif vfunc_name.startswith(self.NULLSUB_PREFIX):
                vfunc_target_name = self.NULLSUB_FORMAT.format(name=self.class_name, number=vfunc_index)
                set_addr_name(vfunc_addr, vfunc_target_name)
            else:
                print("Skipping: vtbl {0} index {1} had a name of \"{2}\"".format(self.class_name, vfunc_index, vfunc_name))

        return self

    def set_rel(self, vfunc_rel_offset, name):
        """
        Set the name of a vfunc target via relative offset from the vtable start.
        :param vfunc_rel_offset: Relative offset from the VTable start ea
        :param name: VFunc name, None for default
        :return: self
        """
        vfunc_index = vfunc_rel_offset / 8
        if vfunc_index > self.vfunc_count:
            print("Error: vtbl {0} attempted to set a relative vfunc higher than its scope: {1:X}".format(self.class_name, rel_offset))

        return self.set(vfunc_index, name)

    def set_many(self, mapping):
        """
        Call set many times
        :param mapping: index:name pairings to be passed to set()
        :return: self
        """
        for kvp in mapping.items():
            self.set(*kvp)
        return self

    def set_rel_many(self, mapping):
        """
        Call set_rel many times
        :param mapping: index:name pairings to be passed to set_rel()
        :return: self
        """
        for kvp in mapping.items():
            self.set_rel(*kvp)
        return self


# region: functions
# ffxivstring is just their implementation of std::string presumably, there are more ctors etc
NameAddr(0x140059670, "FFXIVString_ctor")  # empty string ctor
NameAddr(0x1400596B0, "FFXIVString_ctor_copy")  # copy constructor
NameAddr(0x140059730, "FFXIVString_ctor_FromCStr")  # from null-terminated string
NameAddr(0x1400597C0, "FFXIVString_ctor_FromSequence")  # (FFXIVString, char * str, size_t size)
NameAddr(0x14005A280, "FFXIVString_dtor")
NameAddr(0x14005A300, "FFXIVString_SetString")
NameAddr(0x1400604B0, "MemoryManager_Alloc")
NameAddr(0x140064F10, "IsMacClient")
NameAddr(0x140068C30, "Common::Configuration::ConfigBase_ctor")
NameAddr(0x140078DE0, "Common::Configuration::SystemConfig_ctor")
NameAddr(0x14007EA30, "Common::Configuration::DevConfig_ctor")
NameAddr(0x14008EA40, "Client::System::Framework_ctor")
NameAddr(0x14008EE40, "Client::System::Framework_Setup")
NameAddr(0x1400912F0, "Client::System::Framework_Tick")
NameAddr(0x140091EB0, "Client::System::Framework_GetUIModule")
NameAddr(0x140092D50, "Client::System::Framework::Task_RunTask_Begin")
NameAddr(0x140092E70, "Client::System::Framework::Task_RunTask_Draw2DBegin")
NameAddr(0x140093280, "Client::System::Framework::Task_RunTask_UpdateGraphicsScene")
NameAddr(0x140093330, "Client::System::Framework::Task_RunTask_UpdateBonePhysics")
NameAddr(0x1400933B0, "Client::System::Framework::Task_RunTask_ResourceManager")
NameAddr(0x1400933C0, "Client::System::Framework::Task_RunTask_UpdateGame")
NameAddr(0x140093E60, "Client::System::Framework::TaskManager_ctor")
NameAddr(0x1400946B0, "Client::System::Framework::Task_TaskRunner")  # task starter which runs the task's function pointer
NameAddr(0x1400AAE50, "Client::UI::RaptureAtkUnitManager_ctor")
NameAddr(0x1400B06F0, "Client::UI::RaptureAtkModule_ctor")
NameAddr(0x1400D37C0, "Client::UI::RaptureAtkModule_UpdateTask1")
NameAddr(0x1400D6750, "Client::UI::RaptureAtkModule_IsUIVisible")
NameAddr(0x1400D6770, "Client::UI::RaptureAtkModule_SetUIVisibility")
NameAddr(0x140158DE0, "Component::GUI::AtkUnitBase_GetPosition")
NameAddr(0x140158E00, "Component::GUI::AtkUnitBase_GetX")
NameAddr(0x140158E10, "Component::GUI::AtkUnitBase_GetY")
NameAddr(0x140159A70, "Component::GUI::AtkUnitBase_SetX")
NameAddr(0x140159A90, "Component::GUI::AtkUnitBase_SetY")
NameAddr(0x140168270, "Client::System::Crypt::SimpleString_Encrypt")
NameAddr(0x1401682D0, "Client::System::Crypt::SimpleString_Decrypt")
NameAddr(0x140171440, "Client::System::Framework::TaskManager_SetTask")
NameAddr(0x14017FF50, "Client::Graphics::Environment::EnvManager_ctor")
NameAddr(0x140194EE0, "j_SleepEx")
NameAddr(0x1401A0080, "Client::System::Resource::Handle::ResourceHandle_DecRef")
NameAddr(0x1401A00B0, "Client::System::Resource::Handle::ResourceHandle_IncRef")
NameAddr(0x1401A0270, "Client::System::Resource::Handle::ResourceHandle_ctor")
NameAddr(0x1401A1F70, "Client::System::Resource::Handle::ResourceHandle_GetData")
NameAddr(0x1401A3730, "Client::System::Resource::Handle::TextureResourceHandle_ctor")
NameAddr(0x1401AF430, "Client::System::Resource::Handle::ApricotResourceHandle_Load")
NameAddr(0x1401B0460, "ResourceManager_GetResourceAsync")  # no vtbl on this class wouldnt be surprised if it was Client::System::Resource::ResourceManager or something though
NameAddr(0x1401B0680, "ResourceManager_GetResourceSync")
NameAddr(0x1401B8A40, "Client::System::Resource::Handle::ModelResourceHandle_GetMaterialFileNameBySlot")
NameAddr(0x1401D1EB0, "Client::Graphics::Primitive::Manager_ctor")
NameAddr(0x1401D4810, "Client::Graphics::DelayedReleaseClassBase_ctor")
NameAddr(0x1401D6D90, "Client::Graphics::AllocatorManager_ctor")
NameAddr(0x1401EBFE0, "Client::Network::NetworkModuleProxy_ctor")
NameAddr(0x1401EDBF0, "Client::UI::Agent::AgentInterface_ctor")
NameAddr(0x1401EDCF0, "Client::UI::AgentInterface_IsAgentActive")
NameAddr(0x1401F5FF0, "Client::UI::Agent::AgentModule_ctor")
NameAddr(0x1401FB250, "Client::UI::Agent::AgentModule::GetAgentByInternalID")
NameAddr(0x1401FB260, "Client::UI::Agent::AgentModule::GetAgentByInternalID_2")  # dupe?
NameAddr(0x140210710, "Client::UI::Agent::AgentLobby_ctor")
NameAddr(0x1402A5270, "CountdownPointer")
NameAddr(0x1402F9930, "Client::Graphics::Kernel::Texture_ctor")
NameAddr(0x140300FA0, "Client::Graphics::Kernel::Device_ctor")
NameAddr(0x14031FCE0, "Client::Graphics::Render::GraphicsConfig_ctor")
NameAddr(0x1403296C0, "Client::Graphics::Render::AmbientLight_ctor")
NameAddr(0x14032B630, "Client::Graphics::Render::Model_ctor")
NameAddr(0x14032B780, "Client::Graphics::Render::Model_SetupFromModelResourceHandle")
NameAddr(0x1403636E0, "Client::Graphics::Render::RenderManager_ctor")
NameAddr(0x1403648C0, "Client::Graphics::Render::RenderManager_CreateModel")
NameAddr(0x140365BA0, "Client::Graphics::Render::ShadowManager_ctor")
NameAddr(0x14036A1D0, "Client::Graphics::Render::LightingManager::LightingRenderer_ctor")
NameAddr(0x140374A80, "Client::Graphics::Render::LightingManager_ctor")
NameAddr(0x140375260, "Client::Graphics::Render::RenderTargetManager_ctor")
NameAddr(0x140396010, "Client::Graphics::PostEffect::PostEffectManager_ctor")
NameAddr(0x1403DD170, "Client::Graphics::JobSystem(Apricot::Engine::Core_Apricot::Engine::Core::CoreJob_1)_ctor")
NameAddr(0x1403DD3A0, "Client::Graphics::JobSystem(Apricot::Engine::Core_Apricot::Engine::Core::CoreJob_1)_GetSingleton")
NameAddr(0x14042BCE0, "Client::Graphics::Scene::DrawObject_ctor")
NameAddr(0x14042C290, "Client::Graphics::Scene::World_ctor")
NameAddr(0x14042C550, "Client::Graphics::Scene::Camera_ctor")
NameAddr(0x14042E020, "Client::Graphics::Scene::CameraManager_ctor")
NameAddr(0x140431750, "Client::Graphics::Scene::CharacterUtility_ctor")
NameAddr(0x140431960, "Client::Graphics::Scene::CharacterUtility_CreateDXRenderObjects")
NameAddr(0x140431DB0, "Client::Graphics::Scene::CharacterUtility_LoadDataFiles")
NameAddr(0x140435B30, "Client::Graphics::Scene::CharacterUtility_GetSlotEqpFlags")
NameAddr(0x140438BD0, "Client::Graphics::Scene::CharacterBase_ctor")
NameAddr(0x14044AC50, "Client::Graphics::Scene::CharacterBase_CreateSlotStorage")
NameAddr(0x14043C9C0, "Client::Graphics::Scene::CharacterBase_CreateBonePhysicsModule")
NameAddr(0x14043E430, "Client::Graphics::Scene::CharacterBase_LoadAnimation")
NameAddr(0x14043EE00, "Client::Graphics::Scene::CharacterBase_LoadMDLForSlot")
NameAddr(0x14043EEF0, "Client::Graphics::Scene::CharacterBase_LoadIMCForSlot")
NameAddr(0x14043F0C0, "Client::Graphics::Scene::CharacterBase_LoadAllMTRLsFromMDLInSlot")
NameAddr(0x14043F260, "Client::Graphics::Scene::CharacterBase_LoadAllDecalTexFromMDLInSlot")
NameAddr(0x14043F3D0, "Client::Graphics::Scene::CharacterBase_LoadPHYBForSlot")
NameAddr(0x14043FB80, "Client::Graphics::Scene::CharacterBase_CopyIMCForSlot")
NameAddr(0x14043FEF0, "Client::Graphics::Scene::CharacterBase_CreateStagingArea")
NameAddr(0x140440010, "Client::Graphics::Scene::CharacterBase_PopulateMaterialsFromStaging")
NameAddr(0x140440160, "Client::Graphics::Scene::CharacterBase_LoadMDLSubFilesIntoStaging")
NameAddr(0x140440370, "Client::Graphics::Scene::CharacterBase_LoadMDLSubFilesForSlot")
NameAddr(0x140440640, "Client::Graphics::Scene::CharacterBase_UpdateMaterials")
NameAddr(0x140440E20, "PrepareColorSet")
NameAddr(0x1404410F0, "ReadStainingTemplate")
NameAddr(0x1404426F0, "Client::Graphics::Scene::CharacterBase_CreateRenderModelForMDL")
NameAddr(0x140443E40, "Client::Graphics::Scene::Human_ctor")
NameAddr(0x140444080, "Client::Graphics::Scene::Human_SetupFromCharacterData")
NameAddr(0x140444390, "Client::Graphics::Scene::Human_CleanupRender")
NameAddr(0x140444B10, "Client::Graphics::Scene::Human_UpdateRender")
NameAddr(0x140445210, "Client::Graphics::Scene::Human_FlagSlotForUpdate")
NameAddr(0x140445290, "Client::Graphics::Scene::Human_GetDataForSlot")
NameAddr(0x140445990, "Client::Graphics::Scene::Human_ResolveMDLPath")
NameAddr(0x140446750, "Client::Graphics::Scene::Human_ResolveMTRLPath")
NameAddr(0x140447140, "Client::Graphics::Scene::Human_GetDyeForSlot")
NameAddr(0x14045E220, "Client::Graphics::Scene::ResidentResourceManager_ctor")
NameAddr(0x14045E250, "Client::Graphics::Scene::ResidentResourceManager_nullsub_1")
NameAddr(0x14045E280, "Client::Graphics::Scene::ResidentResourceManager_LoadDataFiles")
NameAddr(0x14045FDD0, "Client::Graphics::Scene::CharacterBase_dtor")
NameAddr(0x140460BB0, "Client::Graphics::Scene::Human_dtor")
NameAddr(0x1404937B0, "Client::Game::Control::TargetSystem_ctor")
NameAddr(0x1404AABE0, "Component::GUI::NumberArrayData_SetValue")
NameAddr(0x1404BC9C0, "Component::GUI::AtkStage_ctor")
NameAddr(0x1404CC6B0, "Component::GUI::AtkResNode_ctor")
NameAddr(0x1404CC810, "Component::GUI::AtkResNode_GetAsAtkImageNode")
NameAddr(0x1404CC830, "Component::GUI::AtkResNode_GetAsAtkTextNode")
NameAddr(0x1404CC850, "Component::GUI::AtkResNode_GetAsAtkNineGridNode")
NameAddr(0x1404CC870, "Component::GUI::AtkResNode_GetAsAtkCounterNode")
NameAddr(0x1404CC890, "Component::GUI::AtkResNode_GetAsAtkCollisionNode")
NameAddr(0x1404CC8B0, "Component::GUI::AtkResNode_GetAsAtkComponentNode")
NameAddr(0x1404CC8D0, "Component::GUI::AtkResNode_GetComponent")
NameAddr(0x1404CD470, "Component::GUI::AtkResNode_GetPositionFloat")
NameAddr(0x1404CD490, "Component::GUI::AtkResNode_SetPositionFloat")
NameAddr(0x1404CD4E0, "Component::GUI::AtkResNode_GetPositionShort")
NameAddr(0x1404CD510, "Component::GUI::AtkResNode_SetPositionShort")
NameAddr(0x1404CD570, "Component::GUI::AtkResNode_GetScale")
NameAddr(0x1404CD590, "Component::GUI::AtkResNode_GetScaleX")
NameAddr(0x1404CD5B0, "Component::GUI::AtkResNode_GetScaleY")
NameAddr(0x1404CD5D0, "Component::GUI::AtkResNode_SetScale")
NameAddr(0x1404CE6E0, "Component::GUI::AtkResNode_Init")
NameAddr(0x1404CE8B0, "Component::GUI::AtkResNode_SetScale0")  # SetScale jumps to this
NameAddr(0x1404CF1A0, "Component::GUI::AtkTextNode_SetText")
NameAddr(0x1404CFCD0, "Component::GUI::AtkTextNode_SetForegroundColour")
NameAddr(0x1404D0DF0, "Component::GUI::AtkTextNode_SetGlowColour")
NameAddr(0x1404D3BB0, "Component::GUI::AtkUnitBase_ULDAddonData_SetupFromULDResourceHandle")
NameAddr(0x1404D5850, "Component::GUI::AtkResNode_SetupFromULDFileBuffer")
NameAddr(0x1404D5FD0, "Component::GUI::AtkUnitBase_ULDAddonData_ReadTPHD")
NameAddr(0x1404D61E0, "Component::GUI::AtkUnitBase_ULDAddonData_ReadAHSDAndLoadTextures")
NameAddr(0x1404D66C0, "CreateAtkNode")
NameAddr(0x1404D7AD0, "CreateAtkComponent")
NameAddr(0x1404D8DF0, "Component::GUI::AtkResNode_SetSize")
NameAddr(0x1404DA700, "Component::GUI::AtkUnitBase_ctor")
NameAddr(0x1404DAE60, "Component::GUI::AtkUnitBase_SetPosition")
NameAddr(0x1404DAFE0, "Component::GUI::AtkUnitBase_SetAlpha")
NameAddr(0x1404DB2C0, "GetScaleListEntryFromScale")
NameAddr(0x1404DB3E0, "Component::GUI::AtkUnitBase_SetScale")
NameAddr(0x1404DB750, "Component::GUI::AtkUnitBase_CalculateBounds")
NameAddr(0x1404DDA00, "Component::GUI::AtkUnitBase_Draw")
NameAddr(0x1404DDEA0, "Component::GUI::AtkStage_GetSingleton1")  # dalamud GetBaseUIObject
NameAddr(0x1404DDEB0, "Component::GUI::AtkStage_GetSingleton2")
NameAddr(0x1404E5470, "Component::GUI::AtkUnitManager_ctor")
NameAddr(0x1404E6F80, "Client::UI::RaptureAtkUnitManager_GetAddonByName")  # dalamud GetUIObjByName
NameAddr(0x1404E9750, "Client::UI::RaptureAtkUnitManager_SetUnitScale")
NameAddr(0x1404E9A10, "GetScaleForListOption")
NameAddr(0x1404F2670, "Component::GUI::AtkComponentBase_ctor")
NameAddr(0x1404F2920, "Component::GUI::AtkComponentBase_GetOwnerNodePosition")
NameAddr(0x1404F34A0, "Component::GUI::AtkComponentButton_SetEnabledState")
NameAddr(0x1404F3DA0, "Component::GUI::AtkComponentButton_ctor")
NameAddr(0x1404F4D90, "Component::GUI::AtkComponentButton_InitializeFromComponentData")
NameAddr(0x1404F62E0, "Component::GUI::AtkComponentIcon_ctor")
NameAddr(0x1404F6E20, "Component::GUI::AtkComponentListItemRenderer_ctor")
NameAddr(0x140502070, "Component::GUI::AtkComponentList_ctor")
NameAddr(0x140506A00, "Component::GUI::AtkComponentTreeList_ctor")
NameAddr(0x14050B670, "Component::GUI::AtkModule_ctor")
NameAddr(0x14050F620, "Component::GUI::AtkComponentCheckBox_ctor")
NameAddr(0x140510540, "Component::GUI::AtkComponentGaugeBar_ctor")
NameAddr(0x140512670, "Component::GUI::AtkComponentSlider_ctor")
NameAddr(0x140513A80, "Component::GUI::AtkComponentInputBase_ctor")
NameAddr(0x140515240, "Component::GUI::AtkComponentTextInput_ctor")
NameAddr(0x140519950, "Component::GUI::AtkComponentNumericInput_ctor")
NameAddr(0x14051D5F0, "Component::GUI::AtkComponentDropDownList_ctor")
NameAddr(0x14051EAE0, "Component::GUI::AtkComponentRadioButton_ctor")
NameAddr(0x14051F3B0, "Component::GUI::AtkComponentTab_ctor")
NameAddr(0x14051F990, "Component::GUI::AtkComponentGuildLeveCard_ctor")
NameAddr(0x14051FD20, "Component::GUI::AtkComponentTextNineGrid_ctor")
NameAddr(0x140522930, "Component::GUI::AtkResourceRendererManager_ctor")
NameAddr(0x140522B30, "Component::GUI::AtkResourceRendererManager_DrawUldFromData")
NameAddr(0x140522C10, "Component::GUI::AtkResourceRendererManager_DrawUldFromDataClipped")
NameAddr(0x140525120, "Component::GUI::AtkComponentMap_ctor")
NameAddr(0x140527B50, "Component::GUI::AtkComponentPreview_ctor")
NameAddr(0x140528BB0, "Component::GUI::AtkComponentScrollBar_ctor")
NameAddr(0x14052A5C0, "Component::GUI::AtkComponentIconText_ctor")
NameAddr(0x14052B840, "Component::GUI::AtkComponentDragDrop_ctor")
NameAddr(0x14052D4A0, "Component::GUI::AtkComponentMultipurpose_ctor")
NameAddr(0x14052DDD0, "Component::GUI::AtkComponentWindow_ctor")
NameAddr(0x140533360, "Component::GUI::AtkComponentJournalCanvas_ctor")
NameAddr(0x140536380, "Component::GUI::TextModuleInterface::GetTextLabelByID")
NameAddr(0x140536E90, "Component::GUI::AtkComponentUnknownButton_ctor")
NameAddr(0x14053F820, "Component::GUI::AtkCollisionNode_ctor")
NameAddr(0x14053F880, "Component::GUI::AtkComponentNode_ctor")
NameAddr(0x14053F8E0, "Component::GUI::AtkCounterNode_ctor")
NameAddr(0x14053F960, "Component::GUI::AtkImageNode_ctor")
NameAddr(0x14053F9C0, "Component::GUI::AtkNineGridNode_ctor")
NameAddr(0x14053FB10, "Component::GUI::AtkTextNode_ctor")
NameAddr(0x1405408F0, "Component::GUI::AtkComponentNode_Destroy")
NameAddr(0x140540E40, "Component::GUI::AtkCollisionNode_Destroy")
NameAddr(0x140541B50, "Component::GUI::AtkCounterNode_Destroy")
NameAddr(0x1405422C0, "Component::GUI::AtkImageNode_Destroy")
NameAddr(0x140542450, "Component::GUI::AtkNineGridNode_Destroy")
NameAddr(0x140542510, "Component::GUI::AtkResNode_Destroy")
NameAddr(0x140542710, "Component::GUI::AtkTextNode_Destroy")
NameAddr(0x1405BB780, "Client::UI::UI3DModule_ctor")
NameAddr(0x1405C47E0, "Client::UI::UIModule_ctor")
NameAddr(0x1405FAEA0, "Client::UI::Misc::ConfigModule_ctor")
NameAddr(0x140615880, "Client::UI::Misc::RaptureLogModule_ctor")
NameAddr(0x140617010, "Client::UI::Misc::RaptureLogModule_PrintMessage")
NameAddr(0x1406207D0, "Client::UI::Misc::RaptureHotbarModule_ctor")
NameAddr(0x140629590, "Client::UI::Misc::PronounModule_ctor")
NameAddr(0x14064FB80, "Client::UI::Misc::CharaView_ctor")
NameAddr(0x14064FC90, "Client::UI::Misc::CharaView_Initialize")
NameAddr(0x14064FDB0, "Client::UI::Misc::CharaView_Finalize")
NameAddr(0x14065F700, "Client::UI::Misc::CharaView_dtor")
NameAddr(0x140661280, "Client::UI::Misc::RaptureMacroModule_vfunc4")
NameAddr(0x140661D00, "Client::UI::Misc::RaptureMacroModule_ReadFile")
NameAddr(0x1406620E0, "Client::UI::Misc::RaptureMacroModule_WriteFile")
NameAddr(0x1406C5270, "Client::Game::Object::GameObject_Initialize")
NameAddr(0x1406C54D0, "Client::Game::Object::GameObject_ctor")
NameAddr(0x1406CDD60, "Client::Game::Character::Character_EnableDraw")
NameAddr(0x1406CE510, "Client::Game::Character::Character_DisableDraw")
NameAddr(0x1406CFC10, "Client::Game::Character::Character_GetObjectKind")
NameAddr(0x1406D5AC0, "Client::Game::Character::Character_dtor")
NameAddr(0x1406D6080, "Client::Game::Character::Character_SetDrawObject")
NameAddr(0x1406E3470, "Client::Graphics::Scene::CharacterBase_Create")
NameAddr(0x1406EA340, "Client::Game::Character::Character_ctor")
NameAddr(0x140708970, "Client::UI::Shell::RaptureShellModule_ctor")
NameAddr(0x14070CC90, "Client::UI::Shell::RaptureShellModule_SetChatChannel")
NameAddr(0x14073B630, "CreateBattleCharaStore")
NameAddr(0x14073BC00, "BattleCharaStore_LookupBattleCharaByObjectID")
NameAddr(0x14073C140, "Client::Game::Character::BattleChara_ctor")
NameAddr(0x14073C230, "Client::Game::Character::BattleChara_dtor")
NameAddr(0x140803D00, "ActionManager::StartCooldown")
NameAddr(0x14081F350, "Client::UI::Agent::AgentHUD_ctor")
NameAddr(0x140820D70, "Client::UI::Agent::AgentHUD_Update")
NameAddr(0x140824ED0, "Client::UI::Agent::AgentHUD_UpdateParty")
NameAddr(0x140887BE0, "Client::UI::Agent::AgentMap_ctor")
NameAddr(0x140889C50, "Client::UI::AgentMap::MapMarkerStructSearchName_Evaluate")
NameAddr(0x1408C0B10, "Client::UI::Agent::AgentHUDLayout_ctor")
NameAddr(0x1408C0C10, "Client::UI::Agent::AgentHUDLayout_Show")
NameAddr(0x1408C0C80, "Client::UI::Agent::AgentHUDLayout_Hide")
NameAddr(0x1408C17E0, "CreateSelectYesno")
NameAddr(0x1408D3F50, "Client::UI::Agent::AgentItemDetail_ctor")
NameAddr(0x1408D4F80, "Client::UI::Agent::AgentItemDetail_OnItemHovered")
NameAddr(0x140904190, "Client::UI::Agent::AgentStatus_ctor")
NameAddr(0x140A77F70, "EventFramework_GetSingleton")
NameAddr(0x140A80680, "EventFramework_ProcessDirectorUpdate")
NameAddr(0x14110A340, "Client::Game::Camera_ctor")
NameAddr(0x140CCD730, "Client::UI::AddonNowLoading_ctor")
NameAddr(0x140CCD810, "Client::UI::AddonNowLoading_LoadUldResourceHandle")
NameAddr(0x140CD9150, "Client::UI::AddonHudSelectYesno_ctor")
NameAddr(0x140DD2610, "Client::UI::AddonHudSelectYesno_dtor")
NameAddr(0x140E90440, "Client::UI::AddonItemDetail_ctor")
NameAddr(0x140E91960, "Client::UI::AddonItemDetail_GenerateTooltip")
NameAddr(0x140EBDC30, "Client::UI::AddonAreaMap_ctor")
NameAddr(0x140ED87F0, "Client::UI::AddonNamePlate_ctor")
NameAddr(0x140EDA830, "Client::UI::AddonNamePlate_UpdateNameplates")
NameAddr(0x140E7C1D0, "Client::UI::AddonTalk_ctor")
NameAddr(0x14101D810, "Client::UI::AddonHudLayoutWindow_ctor")
NameAddr(0x14101EAA0, "Client::UI::AddonHudLayoutScreen_ctor")
NameAddr(0x141021BD0, "Client::UI::AddonHudLayoutScreen::MoveableAddonInfoStruct_UpdateAddonPosition")
NameAddr(0x1410233A0, "Client::UI::AddonHudLayoutScreen_HandleMouseEvent")
NameAddr(0x141023730, "Client::UI::AddonHudLayoutScreen_AddonOverlayMouseMovedEvent")
NameAddr(0x141023960, "Client::UI::AddonHudLayoutScreen_AddonOverlayMouseClickEvent")
NameAddr(0x141023D60, "Client::UI::AddonHudLayoutScreen_AddonOverlayMouseReleaseEvent")
NameAddr(0x1410259A0, "Client::UI::AddonHudLayoutScreen_SetAddonScale")
NameAddr(0x1410C3D00, "Client::Game::Character::Companion_EnableDraw")
NameAddr(0x141101890, "Client::Game::Character::Companion_ctor")
NameAddr(0x1412F78E0, "crc")
NameAddr(0x1413716E4, "FreeMemory")
# endregion

# region: globals
NameAddr(0x14169A2A0, "g_HUDScaleTable")
NameAddr(0x141D3CE60, "g_ActionManager")
NameAddr(0x141D66690, "g_Framework")
NameAddr(0x141D66860, "g_KernelDevice")
NameAddr(0x141D68228, "g_GraphicsConfig")
NameAddr(0x141D68238, "g_Framework_2")  # these both point to framework
NameAddr(0x141D68278, "g_AllocatorManager")
NameAddr(0x141D68280, "g_PrimitiveManager")
NameAddr(0x141D68288, "g_RenderManager")
NameAddr(0x141D68290, "g_ShadowManager")
NameAddr(0x141D68298, "g_LightingManager")
NameAddr(0x141D682A0, "g_RenderTargetManager")
NameAddr(0x141D682A8, "g_StreamingManager")
NameAddr(0x141D682B0, "g_PostEffectManager")
NameAddr(0x141D682B8, "g_EnvManager")
NameAddr(0x141D682C0, "g_World")
NameAddr(0x141D682C8, "g_CameraManager")
NameAddr(0x141D682D0, "g_CharacterUtility")
NameAddr(0x141D682D8, "g_ResidentResourceManager")
NameAddr(0x141D6A7E0, "g_CullingManager")
NameAddr(0x141D6A800, "g_TaskManager")
NameAddr(0x141D6FA90, "g_ResourceManager")
NameAddr(0x141D81AA0, "g_OcclusionCullingManager")
NameAddr(0x141D81AE0, "g_RenderModelLinkedListStart")
NameAddr(0x141D81AE8, "g_RenderModelLinkedListEnd")
NameAddr(0x141D82930, "g_JobSystem_ApricotEngineCore")  # not a ptr
NameAddr(0x141D8A070, "g_CameraHolder")
NameAddr(0x141D8A1C0, "g_TargetSystem")
NameAddr(0x141D8E500, "g_AtkStage")
NameAddr(0x141DB1D00, "g_BattleCharaStore")  # this is a struct/object containing a list of all battlecharas (0x100) and the memory ptrs below
NameAddr(0x141DB2020, "g_BattleCharaMemory")
NameAddr(0x141DB2028, "g_CompanionMemory")
NameAddr(0x141DB2050, "g_ActorList")
NameAddr(0x141DB2D90, "g_ActorListEnd")
NameAddr(0x141DD6F08, "g_EventFramework")
NameAddr(0x141DE2D50, "g_ClientObjectManager")
# endregion

# region: vtbl
VTable(0x14164E260, "Common::Configuration::ConfigBase", 1).set_defaults()
VTable(0x14164E2C0, "Common::Configuration::SystemConfig", 1).set_defaults()
VTable(0x14164E280, "Common::Configuration::UIConfig", 1).set_defaults()
VTable(0x14164E2A0, "Common::Configuration::UIControlConfig", 1).set_defaults()
VTable(0x14164E2E0, "Common::Configuration::DevConfig", 1).set_defaults()
VTable(0x14164F4B8, "Client::System::Framework", 1).set_defaults()
VTable(0x14164F430, "Client::System::Framework::Task", 1).set_defaults()
VTable(0x14164F448, "Client::System::Framework::TaskManager::RootTask", 1).set_defaults()
VTable(0x14164F460, "Client::System::Framework::TaskManager", 1).set_defaults()
VTable(0x14164F478, "Client::System::Configuration::SystemConfig", 1).set_defaults()
VTable(0x14164F498, "Client::System::Configuration::DevConfig", 1).set_defaults()
VTable(0x14164F4B8, "Client::System::Framework", 1).set_defaults()
VTable(0x14164F4E0, "Component::Excel::ExcelModuleInterface", 1).set_defaults()
VTable(0x1416594C0, "Component::GUI::AtkUnitList", 1).set_defaults()
VTable(0x1416594C8, "Component::GUI::AtkUnitManager", 1).set_defaults()
VTable(0x141659620, "Client::UI::RaptureAtkUnitManager", 1).set_defaults()
VTable(0x141659878, "Client::UI::RaptureAtkModule", 1).set_defaults()
VTable(0x141661D28, "Client::Graphics::Kernel::Notifier", 1).set_defaults()
VTable(0x1416657C0, "Client::System::Crypt::Crc32", 1).set_defaults()
VTable(0x14166BD58, "Client::Graphics::Environment::EnvSoundState", 1).set_defaults()
VTable(0x14166BD78, "Client::Graphics::Environment::EnvState", 1).set_defaults()
VTable(0x14166BDC8, "Client::Graphics::Environment::EnvSimulator", 1).set_defaults()
VTable(0x14166BDD8, "Client::Graphics::Environment::EnvManager", 1).set_defaults()
VTable(0x14166DA88, "Client::System::Resource::Handle::ResourceHandle", 1).set_defaults()
VTable(0x14166DC08, "Client::System::Resource::Handle::DefaultResourceHandle", 1).set_defaults()
VTable(0x14166E088, "Client::System::Resource::Handle::TextureResourceHandle", 1).set_defaults()
VTable(0x14166E8B8, "Client::System::Resource::Handle::CharaMakeParameterResourceHandle", 1).set_defaults()
VTable(0x14166FB38, "Client::System::Resource::Handle::ApricotResourceHandle", 1).set_defaults()
VTable(0x1416729E8, "Client::System::Resource::Handle::UldResourceHandle", 1).set_defaults()
VTable(0x141672B50, "Client::System::Resource::Handle::UldResourceHandleFactory", 1).set_defaults()
VTable(0x141673178, "Client::Graphics::Primitive::Manager", 1).set_defaults()
VTable(0x141673338, "Client::Graphics::DelayedReleaseClassBase", 1).set_defaults()
VTable(0x1416734B0, "Client::Graphics::AllocatorLowLevel", 1).set_defaults()
VTable(0x141673568, "Client::Graphics::AllocatorManager", 1).set_defaults()
VTable(0x141674968, "Client::Network::NetworkModuleProxy", 1).set_defaults()
VTable(0x141675928, "Client::UI::Agent::AgentInterface", 1).set_defaults()
VTable(0x141675998, "Client::UI::Agent::AgentCharaMake", 1).set_defaults()
VTable(0x141675D70, "Client::UI::Agent::AgentModule", 1).set_defaults()
VTable(0x141676AE0, "Client::UI::Agent::AgentCursor", 1).set_defaults()
VTable(0x141676B50, "Client::UI::Agent::AgentCursorLocation", 1).set_defaults()
VTable(0x14167E120, "Client::Graphics::Kernel::Texture", 1).set_defaults()
VTable(0x14167E3A8, "Client::Graphics::Kernel::ConstantBuffer", 1).set_defaults()
VTable(0x14167E430, "Client::Graphics::Kernel::Device", 1).set_defaults()
VTable(0x1416856A8, "Client::Graphics::Kernel::ShaderSceneKey", 1).set_defaults()
VTable(0x1416856B0, "Client::Graphics::Kernel::ShaderSubViewKey", 1).set_defaults()
VTable(0x1416856C8, "Client::Graphics::Render::GraphicsConfig", 1).set_defaults()
VTable(0x141685708, "Client::Graphics::Render::ShadowCamera", 1).set_defaults()
VTable(0x141685850, "Client::Graphics::Render::View", 1).set_defaults()
VTable(0x1416858D8, "Client::Graphics::Render::PostBoneDeformerBase", 1).set_defaults()
VTable(0x1416859C0, "Client::Graphics::Render::AmbientLight", 1).set_defaults()
VTable(0x1416859D0, "Client::Graphics::Render::Model", 1).set_defaults()
VTable(0x141685A88, "Client::Graphics::Render::ModelRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::ModelRenderer::RenderJob", 1).set_defaults()
VTable(0x141685A90, "Client::Graphics::Render::ModelRenderer", 1).set_defaults()
VTable(0x141685AB8, "Client::Graphics::Render::GeometryInstancingRenderer", 1).set_defaults()
VTable(0x141685B60, "Client::Graphics::Render::BGInstancingRenderer_Client::Graphics::JobSystem_CClient::Graphics::Render::tagInstancingContainerRenderInfo", 1).set_defaults()
VTable(0x141685B68, "Client::Graphics::Render::BGInstancingRenderer", 1).set_defaults()
VTable(0x141685BD0, "Client::Graphics::Render::TerrainRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::TerrainRenderer::RenderJob", 1).set_defaults()
VTable(0x141685BD8, "Client::Graphics::Render::TerrainRenderer", 1).set_defaults()
VTable(0x141685C48, "Client::Graphics::Render::UnknownRenderer", 1).set_defaults()
VTable(0x141685CB0, "Client::Graphics::Render::WaterRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::WaterRenderer::RenderJob", 1).set_defaults()
VTable(0x141685CB8, "Client::Graphics::Render::WaterRenderer", 1).set_defaults()
VTable(0x141685DA0, "Client::Graphics::Render::VerticalFogRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::VerticalFogRenderer::RenderJob", 1).set_defaults()
VTable(0x141685DA8, "Client::Graphics::Render::VerticalFogRenderer", 1).set_defaults()
VTable(0x141685EC0, "Client::Graphics::Render::ShadowMaskUnit", 1).set_defaults()
VTable(0x141685ED8, "Client::Graphics::Render::ShaderManager", 1).set_defaults()
VTable(0x141685EE8, "Client::Graphics::Render::Manager_Client::Graphics::JobSystem_Client::Graphics::Render::Manager::BoneCollectorJob", 1).set_defaults()
VTable(0x141685EF0, "Client::Graphics::Render::Updater_Client::Graphics::Render::PostBoneDeformerBase", 1).set_defaults()
VTable(0x141685EF8, "Client::Graphics::Render::Manager", 1).set_defaults()
VTable(0x141685F10, "Client::Graphics::Render::ShadowManager", 1).set_defaults()
VTable(0x141685F20, "Client::Graphics::Render::LightingManager::LightShape", 1).set_defaults()
VTable(0x141685F28, "Client::Graphics::Render::LightingManager::LightingRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::LightingManager::LightingRenderer::RenderJob", 1).set_defaults()
VTable(0x141685F30, "Client::Graphics::Render::LightingManager::LightingRenderer", 1).set_defaults()
VTable(0x141685F38, "Client::Graphics::Render::LightingManager", 1).set_defaults()
VTable(0x141685F40, "Client::Graphics::Render::LightingManager_Client::Graphics::Kernel::Notifier", 1).set_defaults()
VTable(0x141685F60, "Client::Graphics::Render::RenderTargetManager", 1).set_defaults()
VTable(0x141685F68, "Client::Graphics::Render::RenderTargetManager_Client::Graphics::Kernel::Notifier", 1).set_defaults()
VTable(0x1416885D8, "Client::Graphics::PostEffect::PostEffectChain", 1).set_defaults()
VTable(0x1416885E0, "Client::Graphics::PostEffect::PostEffectRainbow", 1).set_defaults()
VTable(0x1416885E8, "Client::Graphics::PostEffect::PostEffectLensFlare", 1).set_defaults()
VTable(0x1416885F0, "Client::Graphics::PostEffect::PostEffectRoofQuery", 1).set_defaults()
VTable(0x141688600, "Client::Graphics::PostEffect::PostEffectManager", 1).set_defaults()
VTable(0x141688608, "Client::Graphics::PostEffect::PostEffectManager_Client::Graphics::Kernel::Notifier", 1).set_defaults()
VTable(0x14168C238, "Client::Graphics::JobSystem(Apricot::Engine::Core_Apricot::Engine::Core::CoreJob_1)", 1).set_defaults()
VTable(0x1416959D0, "Client::Graphics::Scene::Object", 1).set_defaults()
VTable(0x141695A00, "Client::Graphics::Scene::DrawObject", 1).set_defaults()
VTable(0x141695B98, "Client::Graphics::Scene::World_Client::Graphics::JobSystem_Client::Graphics::Scene::World::SceneUpdateJob", 1).set_defaults()
VTable(0x141695BA0, "Client::Graphics::Scene::World", 1).set_defaults()
VTable(0x141695BD0, "Client::Graphics::Scene::World_Client::Graphics::Singleton", 1).set_defaults()
VTable(0x141695BD8, "Client::Graphics::Scene::Camera", 1).set_defaults()
VTable(0x141695C38, "Client::Graphics::Scene::CameraManager_Client::Graphics::Singleton", 1).set_defaults()
VTable(0x141695C40, "Client::Graphics::Scene::CameraManager", 1).set_defaults()
VTable(0x141695E08, "Client::Graphics::Scene::CharacterUtility", 1).set_defaults()
VTable(0x141695E88, "Client::Graphics::Scene::CharacterBase", 1).set_defaults()
VTable(0x141696198, "Client::Graphics::Scene::Human", 1).set_defaults()
VTable(0x141697860, "Client::Graphics::Scene::ResidentResourceManager::ResourceList", 1).set_defaults()
VTable(0x141697870, "Client::Graphics::Scene::ResidentResourceManager", 1).set_defaults()
VTable(0x141697950, "Client::System::Task::SpursJobEntityWorkerThread", 1).set_defaults()
VTable(0x141697D60, "Common::Lua::LuaState", 1).set_defaults()
VTable(0x141697D60, "Common::Lua::LuaThread", 1).set_defaults()
VTable(0x141698A90, "Client::Game::Control::TargetSystem::AggroListFeeder", 1).set_defaults()
VTable(0x141698AA0, "Client::Game::Control::TargetSystem::AllianceListFeeder", 1).set_defaults()
VTable(0x141698AB0, "Client::Game::Control::TargetSystem::PartyListFeeder", 1).set_defaults()
VTable(0x141698B00, "Client::Game::Control::TargetSystem", 1).set_defaults()
VTable(0x14169A300, "Component::GUI::AtkArrayData", 2).set_defaults()
VTable(0x14169A310, "Component::GUI::NumberArrayData", 2).set_defaults()
VTable(0x14169A320, "Component::GUI::StringArrayData", 2).set_defaults()
VTable(0x14169A330, "Component::GUI::ExtendArrayData", 2).set_defaults()
VTable(0x14169A438, "Component::GUI::AtkSimpleTween", 2).set_defaults()
VTable(0x14169A448, "Component::GUI::AtkTexture", 1).set_defaults()
VTable(0x14169A5A8, "Component::GUI::AtkStage", 1).set_defaults()
VTable(0x14169AE50, "Component::GUI::AtkResNode", 3).set_defaults()
VTable(0x14169AE68, "Component::GUI::AtkImageNode", 3).set_defaults()
VTable(0x14169AE80, "Component::GUI::AtkTextNode", 3).set_defaults()
VTable(0x14169AE98, "Component::GUI::AtkNineGridNode", 3).set_defaults()
VTable(0x14169AEB0, "Component::GUI::AtkCounterNode", 3).set_defaults()
VTable(0x14169AEC8, "Component::GUI::AtkCollisionNode", 3).set_defaults()
VTable(0x14169AEE0, "Component::GUI::AtkComponentNode", 3).set_defaults()
VTable(0x14169AEF8, "Component::GUI::AtkUnitBase", 68).set_many({
    9: "SetPosition",
    10: "SetX",
    11: "SetY",
    12: "GetX",
    13: "GetY",
    14: "GetPosition",
    15: "SetAlpha",
    16: "SetScale",
    39: "Draw"
}).set_defaults()
VTable(0x14169B188, "Component::GUI::AtkComponentBase", 19).set_defaults()
VTable(0x14169B228, "Component::GUI::AtkComponentButton", 25).set_defaults()
VTable(0x14169B2F0, "Component::GUI::AtkComponentIcon", 20).set_defaults()
VTable(0x14169B410, "Component::GUI::AtkComponentListItemRenderer", 26).set_defaults()
VTable(0x14169B580, "Component::GUI::AtkComponentList", 45).set_defaults()
VTable(0x14169B6E8, "Component::GUI::AtkComponentTreeList", 45).set_defaults()
VTable(0x14169B850, "Component::GUI::AtkModule", 73).set_defaults()
VTable(0x14169BAF8, "Component::GUI::AtkComponentCheckBox", 26).set_defaults()
VTable(0x14169BBC8, "Component::GUI::AtkComponentGaugeBar", 20).set_defaults()
VTable(0x14169BC68, "Component::GUI::AtkComponentSlider", 20).set_defaults()
VTable(0x14169BD08, "Component::GUI::AtkComponentInputBase", 20).set_defaults()
VTable(0x14169BDA8, "Component::GUI::AtkComponentTextInput", 20).set_defaults()
VTable(0x14169BEA8, "Component::GUI::AtkComponentNumericInput", 20).set_defaults()
VTable(0x14169BF70, "Component::GUI::AtkComponentDropDownList", 20).set_defaults()
VTable(0x14169C010, "Component::GUI::AtkComponentRadioButton", 34).set_defaults()
VTable(0x14169C120, "Component::GUI::AtkComponentTab", 34).set_defaults()
VTable(0x14169C230, "Component::GUI::AtkComponentGuildLeveCard", 20).set_defaults()
VTable(0x14169C2D0, "Component::GUI::AtkComponentTextNineGrid", 20).set_defaults()
VTable(0x14169C370, "Component::GUI::AtkResourceRendererBase", 3).set_defaults()
VTable(0x14169C388, "Component::GUI::AtkImageNodeRenderer", 3).set_defaults()
VTable(0x14169C3A0, "Component::GUI::AtkTextNodeRenderer", 4).set_defaults()
VTable(0x14169C3C0, "Component::GUI::AtkNineGridNodeRenderer", 3).set_defaults()
VTable(0x14169C3D8, "Component::GUI::AtkCounterNodeRenderer", 3).set_defaults()
VTable(0x14169C3F0, "Component::GUI::AtkComponentNodeRenderer", 3).set_defaults()
VTable(0x14169C408, "Component::GUI::AtkResourceRendererManager", 4).set_defaults()
VTable(0x14169C428, "Component::GUI::AtkComponentMap", 20).set_defaults()
VTable(0x14169C4C8, "Component::GUI::AtkComponentPreview", 20).set_defaults()
VTable(0x14169C568, "Component::GUI::AtkComponentScrollBar", 20).set_defaults()
VTable(0x14169C608, "Component::GUI::AtkComponentIconText", 20).set_defaults()
VTable(0x14169C6A8, "Component::GUI::AtkComponentDragDrop", 20).set_defaults()
VTable(0x14169C7C8, "Component::GUI::AtkComponentMultipurpose", 20).set_defaults()
VTable(0x14169C938, "Component::GUI::AtkComponentWindow", 26).set_defaults()
VTable(0x14169CA08, "Component::GUI::AtkComponentJournalCanvas", 20).set_defaults()
VTable(0x14169CAA8, "Component::GUI::AtkComponentUnknownButton", 25).set_defaults()
VTable(0x1416A9390, "Client::UI::Misc::UserFileManager::UserFileEvent", 1).set_defaults()
VTable(0x1416A9CF8, "Client::UI::UI3DModule::ObjectInfo", 1).set_defaults()
VTable(0x1416A9D28, "Client::UI::UI3DModule::MemberInfo", 1).set_defaults()
VTable(0x1416A9D88, "Client::UI::UI3DModule", 1).set_defaults()
VTable(0x1416A9DA0, "Client::UI::UIModule", 1).set_defaults()
VTable(0x1416AA5A0, "Client::System::Crypt::SimpleString", 1).set_defaults()
VTable(0x1416AB430, "Component::Text::MacroDecoder", 1).set_defaults()
VTable(0x1416AB5F0, "Component::Text::TextChecker", 1).set_defaults()
VTable(0x1416AEAE8, "Client::UI::Misc::ConfigModule", 1).set_defaults()
VTable(0x1416AEAF8, "Client::UI::Misc::ConfigModule_Common::Configuration::ConfigBase::ChangeEventInterface", 1).set_defaults()
VTable(0x1416AEBD8, "Client::UI::Misc::RaptureMacroModule", 1).set_defaults()
VTable(0x1416AEC40, "Client::UI::Misc::RaptureTextModule", 1).set_defaults()
VTable(0x1416AEEB8, "Client::UI::Misc::RaptureLogModule", 1).set_defaults()
VTable(0x1416AEF08, "Client::UI::Misc::RaptureHotbarModule", 1).set_defaults()
VTable(0x1416AEF70, "Client::UI::Misc::RaptureHotbarModule_Client::System::Input::InputCodeModifiedInterface", 1).set_defaults()
VTable(0x1416AEFE8, "Client::UI::Misc::PronounModule", 1).set_defaults()
VTable(0x1416AFAC0, "Client::UI::Misc::CharaView", 1).set_defaults()
VTable(0x1416B0EC0, "Client::Game::Object::GameObject", 1).set_defaults()
VTable(0x1416B1B48, "Client::Game::Character::Character", 1).set_defaults()
VTable(0x1416B1E10, "Client::Game::Character::Character_Client::Graphics::Vfx::VfxDataListener", 1).set_defaults()
VTable(0x1416C8150, "Client::Game::Character::BattleChara", 1).set_defaults()
VTable(0x1416C8418, "Client::Game::Character::BattleChara_Client::Graphics::Vfx::VfxDataListener", 1).set_defaults()
VTable(0x1416CA7C0, "Client::Game::ActionManager", 1).set_defaults()
VTable(0x1416CC740, "Client::UI::Agent::AgentHUD", 1).set_defaults()
VTable(0x1416CCAF0, "Client::UI::Agent::AgentItemDetail", 1).set_defaults()
VTable(0x1416CD4B8, "Client::UI::Agent::AgentMap::MapMarkerStructSearchName", 1).set_defaults()
VTable(0x1416CD4C8, "Client::UI::Agent::AgentMap", 1).set_defaults()
VTable(0x1416CE090, "Client::UI::Agent::AgentHudLayout", 1).set_defaults()
VTable(0x1416CEED8, "Client::UI::Agent::AgentStatus", 1).set_defaults()
VTable(0x1416CEEA0, "Client::UI::Agent::AgentStatus::StatusCharaView", 1).set_defaults()
VTable(0x1416DF680, "Client::Game::Event::ModuleBase", 1).set_defaults()
VTable(0x1416E05C8, "Client::Game::Event::EventSceneModuleUsualImpl", 1).set_defaults()
VTable(0x1416E48A0, "Client::Game::Event::EventHandlerModule", 1).set_defaults()
VTable(0x1416E4918, "Client::Game::Event::DirectorModule", 1).set_defaults()
VTable(0x1416F4AA8, "Client::Game::Gimmick::GimmickBill", 1).set_defaults()
VTable(0x141798F70, "Client::UI::AddonNowLoading", 1).set_defaults()
VTable(0x1417C9DC8, "Client::UI::Atk2DAreaMap", 1).set_defaults()
VTable(0x1417D4E18, "Client::UI::AddonTalk", 1).set_defaults()
VTable(0x1417D6AA0, "Client::UI::AddonItemDetail", 1).set_defaults()
VTable(0x1417DCDD0, "Client::UI::AddonAreaMap", 1).set_defaults()
VTable(0x1417DEC90, "Client::UI::AddonNamePlate", 1).set_defaults()
VTable(0x14179BAD0, "Client::UI::AddonHudSelectYesno", 1).set_defaults()
VTable(0x141810480, "Client::UI::AddonHudLayoutWindow", 1).set_defaults()
VTable(0x1418106A0, "Client::UI::AddonHudLayoutScreen", 1).set_defaults()
VTable(0x141825368, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::CullingJobOpt", 1).set_defaults()
VTable(0x141825370, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::CallbackJobOpt", 1).set_defaults()
VTable(0x141825378, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::RenderCallbackJob", 1).set_defaults()
VTable(0x141825380, "Client::Graphics::Culling::CullingManager", 1).set_defaults()
VTable(0x141828A68, "Client::Game::Character::Companion", 1).set_defaults()
VTable(0x141829C80, "Client::Game::CameraBase", 1).set_defaults()
VTable(0x141829CE0, "Client::Game::Camera", 1).set_defaults()
VTable(0x14182B780, "Client::Graphics::Culling::OcclusionCullingManager", 1).set_defaults()
VTable(0x14182B790, "Client::Graphics::Streaming::StreamingManager_Client::Graphics::JobSystem_Client::Graphics::Streaming::StreamingManager::StreamingJob", 1).set_defaults()
VTable(0x14182B798, "Client::Graphics::Streaming::StreamingManager", 1).set_defaults()
VTable(0x1418334C8, "Component::Log::LogModule", 1).set_defaults()
VTable(0x14187A2A0, "Client::Game::Gimmick::GimmickRect", 1).set_defaults()
# endregion
