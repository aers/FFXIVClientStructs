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
# TODO: jump prefixed offsets "j_<stuff>"

class VTable(object):
    STANDARD_IMAGE_BASE = 0x140000000L
    IMAGE_OFFSET = 0x0L

    VTBL_FORMAT = "vtbl_{name}"
    NAMED_FORMAT = "{name}_{vf_name}"
    SUB_FORMAT = "{name}_vf{number}"
    NULLSUB_FORMAT = "{name}_vf{number}_nullsub"
    LOC_FORMAT = "{name}_vloc{number}"

    SUB_PREFIX = "sub_"
    NULLSUB_PREFIX = "nullsub_"
    LOC_PREFIX = "loc_"
    JUMP_PREFIX = "j_"
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
            elif vfunc_name.startswith(self.LOC_PREFIX):
                vfunc_target_name = self.LOC_FORMAT.format(name=self.class_name, number=vfunc_index)
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

    def set_related(self, ea, name):
        """
        Set a related function by effective address.
        Not present in the vtable.
        :param ea: Effective address
        :param name: Func name
        :return: self
        """
        vfunc_target_name = self.NAMED_FORMAT.format(name=self.class_name, vf_name=name)
        set_addr_name(ea, vfunc_target_name)
        return self

    def set_related_many(self, mapping):
        """
        Call set_related many times
        :param mapping: index:name pairings to be passed to set_related()
        :return: self
        """
        for kvp in mapping.items():
            self.set_related(*kvp)
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
NameAddr(0x14017FF50, "Client::Graphics::Environment::EnvManager_ctor")
NameAddr(0x140194EE0, "j_SleepEx")
NameAddr(0x1401B0460, "ResourceManager_GetResourceAsync")  # no vtbl on this class wouldnt be surprised if it was Client::System::Resource::ResourceManager or something though
NameAddr(0x1401B0680, "ResourceManager_GetResourceSync")
NameAddr(0x1401B8A40, "Client::System::Resource::Handle::ModelResourceHandle_GetMaterialFileNameBySlot")
NameAddr(0x140210710, "Client::UI::Agent::AgentLobby_ctor")
NameAddr(0x1402A5270, "CountdownPointer")
NameAddr(0x1403636E0, "Client::Graphics::Render::RenderManager_ctor")
NameAddr(0x1403648C0, "Client::Graphics::Render::RenderManager_CreateModel")
NameAddr(0x140440E20, "PrepareColorSet")
NameAddr(0x1404410F0, "ReadStainingTemplate")
NameAddr(0x1404D66C0, "CreateAtkNode")
NameAddr(0x1404D7AD0, "CreateAtkComponent")
NameAddr(0x1404DB2C0, "GetScaleListEntryFromScale")
NameAddr(0x1404E9A10, "GetScaleForListOption")
NameAddr(0x140536380, "Component::GUI::TextModuleInterface::GetTextLabelByID")
NameAddr(0x140708970, "Client::UI::Shell::RaptureShellModule_ctor")
NameAddr(0x14070CC90, "Client::UI::Shell::RaptureShellModule_SetChatChannel")
NameAddr(0x14073B630, "CreateBattleCharaStore")
NameAddr(0x14073BC00, "BattleCharaStore_LookupBattleCharaByObjectID")
NameAddr(0x140803D00, "ActionManager::StartCooldown")
NameAddr(0x1408C17E0, "CreateSelectYesno")
NameAddr(0x140A77F70, "EventFramework_GetSingleton")
NameAddr(0x140A80680, "EventFramework_ProcessDirectorUpdate")
NameAddr(0x141021BD0, "Client::UI::AddonHudLayoutScreen::MoveableAddonInfoStruct_UpdateAddonPosition")
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
VTable(0x14164E260, "Common::Configuration::ConfigBase", 4).set_many({}).set_related_many({
    0x140068C30: "ctor",
}).set_defaults()
VTable(0x14164E2C0, "Common::Configuration::SystemConfig", 4).set_many({}).set_related_many({
    0x140078DE0: "ctor",
}).set_defaults()
VTable(0x14164E280, "Common::Configuration::UIConfig", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14164E2A0, "Common::Configuration::UIControlConfig", 4).set_many({}).set_related_many({}).set_defaults()
VTable(0x14164E2E0, "Common::Configuration::DevConfig", 4).set_many({}).set_related_many({
    0x14007EA30: "ctor",
}).set_defaults()
VTable(0x14164F4B8, "Client::System::Framework", 5).set_many({
    1: "Setup",
    4: "Tick",
}).set_related_many({
    0x14008EA40: "ctor",
    0x140091EB0: "GetUIModule",
}).set_defaults()
VTable(0x14164F430, "Client::System::Framework::Task", 3).set_many({
}).set_related_many({
    0x1400946B0: "TaskRunner",  # task starter which runs the task's function pointer
    0x140092D50: "RunTask_Begin",
    0x140092E70: "RunTask_Draw2DBegin",
    0x140093280: "RunTask_UpdateGraphicsScene",
    0x140093330: "RunTask_UpdateBonePhysics",
    0x1400933B0: "RunTask_ResourceManager",
    0x1400933C0: "RunTask_UpdateGame",
}).set_defaults()
VTable(0x14164F448, "Client::System::Framework::TaskManager::RootTask", 3).set_many({}).set_related_many({}).set_defaults()
VTable(0x14164F460, "Client::System::Framework::TaskManager", 3).set_many({}).set_related_many({
    0x140093E60: "ctor",
    0x140171440: "SetTask",
}).set_defaults()
VTable(0x14164F478, "Client::System::Configuration::SystemConfig", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14164F498, "Client::System::Configuration::DevConfig", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14164F4B8, "Client::System::Framework", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14164F4E0, "Component::Excel::ExcelModuleInterface", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416594C0, "Component::GUI::AtkUnitList", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416594C8, "Component::GUI::AtkUnitManager", 43).set_many({}).set_related_many({
    0x1404E5470: "ctor",
}).set_defaults()
VTable(0x141659620, "Client::UI::RaptureAtkUnitManager", 43).set_many({}).set_related_many({
    0x1400AAE50: "ctor",
    0x1404E6F80: "GetAddonByName",  # dalamud GetUIObjByName
    0x1404E9750: "SetUnitScale",
}).set_defaults()
VTable(0x141659878, "Client::UI::RaptureAtkModule", 73).set_many({
    39: "SetUIVisibility",
}).set_related_many({
    0x1400B06F0: "ctor",
    0x1400D37C0: "UpdateTask1",
    0x1400D6750: "IsUIVisible",
}).set_defaults()
VTable(0x141661D28, "Client::Graphics::Kernel::Notifier", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416657C0, "Client::System::Crypt::Crc32", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14166BD58, "Client::Graphics::Environment::EnvSoundState", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14166BD78, "Client::Graphics::Environment::EnvState", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14166BDC8, "Client::Graphics::Environment::EnvSimulator", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14166BDD8, "Client::Graphics::Environment::EnvManager", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14166DA88, "Client::System::Resource::Handle::ResourceHandle", 45).set_many({}).set_related_many({
    0x1401A0080: "DecRef",
    0x1401A00B0: "IncRef",
    0x1401A0270: "ctor",
}).set_defaults()
VTable(0x14166DC08, "Client::System::Resource::Handle::DefaultResourceHandle", 45).set_many({
    23: "GetData",  # This was under Client::System::Resource::Handle::ResourceHandle
}).set_related_many({}).set_defaults()
VTable(0x14166E088, "Client::System::Resource::Handle::TextureResourceHandle", 45).set_many({}).set_related_many({
    0x1401A3730: "ctor",
}).set_defaults()
VTable(0x14166E8B8, "Client::System::Resource::Handle::CharaMakeParameterResourceHandle", 45).set_many({}).set_related_many({}).set_defaults()
VTable(0x14166FB38, "Client::System::Resource::Handle::ApricotResourceHandle", 45).set_many({
    33: "Load",
}).set_related_many({
}).set_defaults()
VTable(0x1416729E8, "Client::System::Resource::Handle::UldResourceHandle", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141672B50, "Client::System::Resource::Handle::UldResourceHandleFactory", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141673178, "Client::Graphics::Primitive::Manager", 1).set_many({}).set_related_many({
    0x1401D1EB0: "ctor",
}).set_defaults()
VTable(0x141673338, "Client::Graphics::DelayedReleaseClassBase", 5).set_many({}).set_related_many({
    0x1401D4810: "ctor",
}).set_defaults()
VTable(0x1416734B0, "Client::Graphics::AllocatorLowLevel", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141673568, "Client::Graphics::AllocatorManager", 2).set_many({}).set_related_many({
    0x1401D6D90: "ctor",
}).set_defaults()
VTable(0x141674968, "Client::Network::NetworkModuleProxy", 1).set_many({}).set_related_many({
    0x1401EBFE0: "ctor",
}).set_defaults()
VTable(0x141675928, "Client::UI::Agent::AgentInterface", 14).set_many({
    4: "IsAgentActive",
}).set_related_many({
    0x1401EDBF0: "ctor",
}).set_defaults()
VTable(0x141675998, "Client::UI::Agent::AgentCharaMake", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141675D70, "Client::UI::Agent::AgentModule", 1).set_many({}).set_related_many({
    0x1401F5FF0: "ctor",
    0x1401FB250: "GetAgentByInternalID",
    0x1401FB260: "GetAgentByInternalID_2",  # dupe?
}).set_defaults()
VTable(0x141676AE0, "Client::UI::Agent::AgentCursor", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141676B50, "Client::UI::Agent::AgentCursorLocation", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14167E120, "Client::Graphics::Kernel::Texture", 5).set_many({}).set_related_many({
    0x1402F9930: "ctor",
}).set_defaults()
VTable(0x14167E3A8, "Client::Graphics::Kernel::ConstantBuffer", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14167E430, "Client::Graphics::Kernel::Device", 1).set_many({}).set_related_many({
    0x140300FA0: "ctor",
}).set_defaults()
VTable(0x1416856A8, "Client::Graphics::Kernel::ShaderSceneKey", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416856B0, "Client::Graphics::Kernel::ShaderSubViewKey", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416856C8, "Client::Graphics::Render::GraphicsConfig", 1).set_many({}).set_related_many({
    0x14031FCE0: "ctor",
}).set_defaults()
VTable(0x141685708, "Client::Graphics::Render::ShadowCamera", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685850, "Client::Graphics::Render::View", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416858D8, "Client::Graphics::Render::PostBoneDeformerBase", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416859C0, "Client::Graphics::Render::AmbientLight", 2).set_many({}).set_related_many({
    0x1403296C0: "ctor",
}).set_defaults()
VTable(0x1416859D0, "Client::Graphics::Render::Model", 8).set_many({}).set_related_many({
    0x14032B630: "ctor",
    0x14032B780: "SetupFromModelResourceHandle",
}).set_defaults()
VTable(0x141685A88, "Client::Graphics::Render::ModelRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::ModelRenderer::RenderJob", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685A90, "Client::Graphics::Render::ModelRenderer", 1).set_many({}).set_related_many({
}).set_defaults()
VTable(0x141685AB8, "Client::Graphics::Render::GeometryInstancingRenderer", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685B60, "Client::Graphics::Render::BGInstancingRenderer_Client::Graphics::JobSystem_CClient::Graphics::Render::tagInstancingContainerRenderInfo", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685B68, "Client::Graphics::Render::BGInstancingRenderer", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685BD0, "Client::Graphics::Render::TerrainRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::TerrainRenderer::RenderJob", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685BD8, "Client::Graphics::Render::TerrainRenderer", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685C48, "Client::Graphics::Render::UnknownRenderer", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685CB0, "Client::Graphics::Render::WaterRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::WaterRenderer::RenderJob", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685CB8, "Client::Graphics::Render::WaterRenderer", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685DA0, "Client::Graphics::Render::VerticalFogRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::VerticalFogRenderer::RenderJob", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685DA8, "Client::Graphics::Render::VerticalFogRenderer", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685EC0, "Client::Graphics::Render::ShadowMaskUnit", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685ED8, "Client::Graphics::Render::ShaderManager", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685EE8, "Client::Graphics::Render::Manager_Client::Graphics::JobSystem_Client::Graphics::Render::Manager::BoneCollectorJob", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685EF0, "Client::Graphics::Render::Updater_Client::Graphics::Render::PostBoneDeformerBase", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685EF8, "Client::Graphics::Render::Manager", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685F10, "Client::Graphics::Render::ShadowManager", 1).set_many({}).set_related_many({
    0x140365BA0: "ctor",
}).set_defaults()
VTable(0x141685F20, "Client::Graphics::Render::LightingManager::LightShape", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685F28, "Client::Graphics::Render::LightingManager::LightingRenderer_Client::Graphics::JobSystem_Client::Graphics::Render::LightingManager::LightingRenderer::RenderJob", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685F30, "Client::Graphics::Render::LightingManager::LightingRenderer", 1).set_many({}).set_related_many({
    0x14036A1D0: "ctor",
}).set_defaults()
VTable(0x141685F38, "Client::Graphics::Render::LightingManager", 1).set_many({}).set_related_many({
    0x140374A80: "ctor",
}).set_defaults()
VTable(0x141685F40, "Client::Graphics::Render::LightingManager_Client::Graphics::Kernel::Notifier", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141685F60, "Client::Graphics::Render::RenderTargetManager", 1).set_many({}).set_related_many({
    0x140375260: "ctor",
}).set_defaults()
VTable(0x141685F68, "Client::Graphics::Render::RenderTargetManager_Client::Graphics::Kernel::Notifier", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416885D8, "Client::Graphics::PostEffect::PostEffectChain", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416885E0, "Client::Graphics::PostEffect::PostEffectRainbow", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416885E8, "Client::Graphics::PostEffect::PostEffectLensFlare", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416885F0, "Client::Graphics::PostEffect::PostEffectRoofQuery", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141688600, "Client::Graphics::PostEffect::PostEffectManager", 1).set_many({}).set_related_many({
    0x140396010: "ctor",
}).set_defaults()
VTable(0x141688608, "Client::Graphics::PostEffect::PostEffectManager_Client::Graphics::Kernel::Notifier", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14168C238, "Client::Graphics::JobSystem(Apricot::Engine::Core_Apricot::Engine::Core::CoreJob_1)", 1).set_many({}).set_related_many({
    0x1403DD170: "ctor",
    0x1403DD3A0: "GetSingleton",
}).set_defaults()
VTable(0x1416959D0, "Client::Graphics::Scene::Object", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141695A00, "Client::Graphics::Scene::DrawObject", 50).set_many({}).set_related_many({
    0x14042BCE0: "ctor",
}).set_defaults()
VTable(0x141695B98, "Client::Graphics::Scene::World_Client::Graphics::JobSystem_Client::Graphics::Scene::World::SceneUpdateJob", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141695BA0, "Client::Graphics::Scene::World", 6).set_many({}).set_related_many({
    0x14042C290: "ctor",
}).set_defaults()
VTable(0x141695BD0, "Client::Graphics::Scene::World_Client::Graphics::Singleton", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141695BD8, "Client::Graphics::Scene::Camera", 6).set_many({}).set_related_many({
    0x14042C550: "ctor",
}).set_defaults()
VTable(0x141695C38, "Client::Graphics::Scene::CameraManager_Client::Graphics::Singleton", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141695C40, "Client::Graphics::Scene::CameraManager", 1).set_many({}).set_related_many({
    0x14042E020: "ctor",
}).set_defaults()
VTable(0x141695E08, "Client::Graphics::Scene::CharacterUtility", 1).set_many({}).set_related_many({
    0x140431750: "ctor",
    0x140431960: "CreateDXRenderObjects",
    0x140431DB0: "LoadDataFiles",
    0x140435B30: "GetSlotEqpFlags",
}).set_defaults()
VTable(0x141695E88, "Client::Graphics::Scene::CharacterBase", 98).set_many({
    11: "UpdateMaterials",
    92: "CreateRenderModelForMDL",
}).set_related_many({
    0x140438BD0: "ctor",
    0x14044AC50: "CreateSlotStorage",
    0x14043C9C0: "CreateBonePhysicsModule",
    0x14043E430: "LoadAnimation",
    0x14043EE00: "LoadMDLForSlot",
    0x14043EEF0: "LoadIMCForSlot",
    0x14043F0C0: "LoadAllMTRLsFromMDLInSlot",
    0x14043F260: "LoadAllDecalTexFromMDLInSlot",
    0x14043F3D0: "LoadPHYBForSlot",
    0x14043FB80: "CopyIMCForSlot",
    0x14043FEF0: "CreateStagingArea",
    0x140440010: "PopulateMaterialsFromStaging",
    0x140440160: "LoadMDLSubFilesIntoStaging",
    0x140440370: "LoadMDLSubFilesForSlot",
    0x14045FDD0: "dtor",
    0x1406E3470: "Create",
}).set_defaults()
VTable(0x141696198, "Client::Graphics::Scene::Human", 98).set_many({
    1: "CleanupRender",
    4: "UpdateRender",
    67: "FlagSlotForUpdate",
    68: "GetDataForSlot",
    73: "ResolveMDLPath",
    82: "ResolveMTRLPath",
    86: "GetDyeForSlot",
}).set_related_many({
    0x140443E40: "ctor",
    0x140444080: "SetupFromCharacterData",
    0x140460BB0: "dtor",
}).set_defaults()
VTable(0x141697860, "Client::Graphics::Scene::ResidentResourceManager::ResourceList", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141697870, "Client::Graphics::Scene::ResidentResourceManager", 2).set_many({}).set_related_many({
    0x14045E220: "ctor",
    0x14045E250: "nullsub_1",
    0x14045E280: "LoadDataFiles",
}).set_defaults()
VTable(0x141697950, "Client::System::Task::SpursJobEntityWorkerThread", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141697D60, "Common::Lua::LuaState", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141697D60, "Common::Lua::LuaThread", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141698A90, "Client::Game::Control::TargetSystem::AggroListFeeder", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141698AA0, "Client::Game::Control::TargetSystem::AllianceListFeeder", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141698AB0, "Client::Game::Control::TargetSystem::PartyListFeeder", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141698B00, "Client::Game::Control::TargetSystem", 1).set_many({}).set_related_many({
    0x1404937B0: "ctor",
}).set_defaults()
VTable(0x14169A300, "Component::GUI::AtkArrayData", 2).set_many({}).set_related_many({}).set_defaults()
VTable(0x14169A310, "Component::GUI::NumberArrayData", 2).set_many({}).set_related_many({
    0x1404AABE0: "SetValue",
}).set_defaults()
VTable(0x14169A320, "Component::GUI::StringArrayData", 2).set_many({}).set_related_many({}).set_defaults()
VTable(0x14169A330, "Component::GUI::ExtendArrayData", 2).set_many({}).set_related_many({}).set_defaults()
VTable(0x14169A438, "Component::GUI::AtkSimpleTween", 2).set_many({}).set_related_many({}).set_defaults()
VTable(0x14169A448, "Component::GUI::AtkTexture", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14169A5A8, "Component::GUI::AtkStage", 2).set_many({}).set_related_many({
    0x1404BC9C0: "ctor",
    0x1404DDEA0: "GetSingleton1",  # dalamud GetBaseUIObject
    0x1404DDEB0: "GetSingleton2",
}).set_defaults()
VTable(0x14169AE50, "Component::GUI::AtkResNode", 3).set_many({
    1: "Destroy",
}).set_related_many({
    0x1404CC6B0: "ctor",
    0x1404CC810: "GetAsAtkImageNode",
    0x1404CC830: "GetAsAtkTextNode",
    0x1404CC850: "GetAsAtkNineGridNode",
    0x1404CC870: "GetAsAtkCounterNode",
    0x1404CC890: "GetAsAtkCollisionNode",
    0x1404CC8B0: "GetAsAtkComponentNode",
    0x1404CC8D0: "GetComponent",
    0x1404CD470: "GetPositionFloat",
    0x1404CD490: "SetPositionFloat",
    0x1404CD4E0: "GetPositionShort",
    0x1404CD510: "SetPositionShort",
    0x1404CD570: "GetScale",
    0x1404CD590: "GetScaleX",
    0x1404CD5B0: "GetScaleY",
    0x1404CD5D0: "SetScale",
    0x1404D8DF0: "SetSize",
    0x1404CE6E0: "Init",
    0x1404CE8B0: "SetScale0",  # SetScale jumps to this
    0x1404D5850: "SetupFromULDFileBuffer",
}).set_defaults()
VTable(0x14169AE68, "Component::GUI::AtkImageNode", 3).set_many({
    1: "Destroy",
}).set_related_many({
    0x14053F960: "ctor",
}).set_defaults()
VTable(0x14169AE80, "Component::GUI::AtkTextNode", 3).set_many({
    1: "Destroy",
}).set_related_many({
    0x14053FB10: "ctor",
    0x1404CF1A0: "SetText",
    0x1404CFCD0: "SetForegroundColour",
    0x1404D0DF0: "SetGlowColour",
}).set_defaults()
VTable(0x14169AE98, "Component::GUI::AtkNineGridNode", 3).set_many({
    1: "Destroy",
}).set_related_many({
    0x14053F9C0: "ctor",
}).set_defaults()
VTable(0x14169AEB0, "Component::GUI::AtkCounterNode", 3).set_many({
    1: "Destroy",
}).set_related_many({
    0x14053F8E0: "ctor",
}).set_defaults()
VTable(0x14169AEC8, "Component::GUI::AtkCollisionNode", 3).set_many({
    1: "Destroy",
}).set_related_many({
    0x14053F820: "ctor",
}).set_defaults()
VTable(0x14169AEE0, "Component::GUI::AtkComponentNode", 3).set_many({
    1: "Destroy",
}).set_related_many({
    0x14053F880: "ctor",
}).set_defaults()
VTable(0x14169AEF8, "Component::GUI::AtkUnitBase", 68).set_many({
    8: "SetPosition",
    9: "SetX",
    10: "SetY",
    11: "GetX",
    12: "GetY",
    13: "GetPosition",
    14: "SetAlpha",
    15: "SetScale",
    39: "Draw"
}).set_related_many({
    0x1404DA700: "ctor",
    0x1404DAE60: "SetPosition",
    0x1404DAFE0: "SetAlpha",
    0x1404DB3E0: "SetScale",
    0x1404DB750: "CalculateBounds",
    0x1404DDA00: "Draw",
    0x1404D3BB0: "ULDAddonData_SetupFromULDResourceHandle",
    0x1404D5FD0: "ULDAddonData_ReadTPHD",
    0x1404D61E0: "ULDAddonData_ReadAHSDAndLoadTextures",
}).set_defaults()
VTable(0x14169B188, "Component::GUI::AtkComponentBase", 19).set_many({}).set_related_many({
    0x1404F2670: "ctor",
    0x1404F2920: "GetOwnerNodePosition",
}).set_defaults()
VTable(0x14169B228, "Component::GUI::AtkComponentButton", 25).set_many({
    10: "SetEnabledState",
    17: "InitializeFromComponentData",
}).set_related_many({
    0x1404F3DA0: "ctor",
}).set_defaults()
VTable(0x14169B2F0, "Component::GUI::AtkComponentIcon", 20).set_many({}).set_related_many({
    0x1404F62E0: "ctor",
}).set_defaults()
VTable(0x14169B410, "Component::GUI::AtkComponentListItemRenderer", 26).set_many({}).set_related_many({
    0x1404F6E20: "ctor",
}).set_defaults()
VTable(0x14169B580, "Component::GUI::AtkComponentList", 45).set_many({}).set_related_many({
    0x140502070: "ctor",
}).set_defaults()
VTable(0x14169B6E8, "Component::GUI::AtkComponentTreeList", 45).set_many({}).set_related_many({
    0x140506A00: "ctor",
}).set_defaults()
VTable(0x14169B850, "Component::GUI::AtkModule", 73).set_many({}).set_related_many({
    0x14050B670: "ctor",
}).set_defaults()
VTable(0x14169BAF8, "Component::GUI::AtkComponentCheckBox", 26).set_many({}).set_related_many({
    0x14050F620: "ctor",
}).set_defaults()
VTable(0x14169BBC8, "Component::GUI::AtkComponentGaugeBar", 20).set_many({}).set_related_many({
    0x140510540: "ctor",
}).set_defaults()
VTable(0x14169BC68, "Component::GUI::AtkComponentSlider", 20).set_many({}).set_related_many({
    0x140512670: "ctor",
}).set_defaults()
VTable(0x14169BD08, "Component::GUI::AtkComponentInputBase", 20).set_many({}).set_related_many({
    0x140513A80: "ctor",
}).set_defaults()
VTable(0x14169BDA8, "Component::GUI::AtkComponentTextInput", 20).set_many({}).set_related_many({
    0x140515240: "ctor",
}).set_defaults()
VTable(0x14169BEA8, "Component::GUI::AtkComponentNumericInput", 20).set_many({}).set_related_many({
    0x140519950: "ctor",
}).set_defaults()
VTable(0x14169BF70, "Component::GUI::AtkComponentDropDownList", 20).set_many({}).set_related_many({
    0x14051D5F0: "ctor",
}).set_defaults()
VTable(0x14169C010, "Component::GUI::AtkComponentRadioButton", 34).set_many({}).set_related_many({
    0x14051EAE0: "ctor",
}).set_defaults()
VTable(0x14169C120, "Component::GUI::AtkComponentTab", 34).set_many({}).set_related_many({
    0x14051F3B0: "ctor",
}).set_defaults()
VTable(0x14169C230, "Component::GUI::AtkComponentGuildLeveCard", 20).set_many({}).set_related_many({
    0x14051F990: "ctor",
}).set_defaults()
VTable(0x14169C2D0, "Component::GUI::AtkComponentTextNineGrid", 20).set_many({}).set_related_many({
    0x14051FD20: "ctor",
}).set_defaults()
VTable(0x14169C370, "Component::GUI::AtkResourceRendererBase", 3).set_many({}).set_related_many({
}).set_defaults()
VTable(0x14169C388, "Component::GUI::AtkImageNodeRenderer", 3).set_many({}).set_related_many({}).set_defaults()
VTable(0x14169C3A0, "Component::GUI::AtkTextNodeRenderer", 4).set_many({}).set_related_many({}).set_defaults()
VTable(0x14169C3C0, "Component::GUI::AtkNineGridNodeRenderer", 3).set_many({}).set_related_many({}).set_defaults()
VTable(0x14169C3D8, "Component::GUI::AtkCounterNodeRenderer", 3).set_many({}).set_related_many({}).set_defaults()
VTable(0x14169C3F0, "Component::GUI::AtkComponentNodeRenderer", 3).set_many({}).set_related_many({}).set_defaults()
VTable(0x14169C408, "Component::GUI::AtkResourceRendererManager", 4).set_many({}).set_related_many({
    0x140522930: "ctor",
    0x140522B30: "DrawUldFromData",
    0x140522C10: "DrawUldFromDataClipped",
}).set_defaults()
VTable(0x14169C428, "Component::GUI::AtkComponentMap", 20).set_many({}).set_related_many({
    0x140525120: "ctor",
}).set_defaults()
VTable(0x14169C4C8, "Component::GUI::AtkComponentPreview", 20).set_many({}).set_related_many({
    0x140527B50: "ctor",
}).set_defaults()
VTable(0x14169C568, "Component::GUI::AtkComponentScrollBar", 20).set_many({}).set_related_many({
    0x140528BB0: "ctor",
}).set_defaults()
VTable(0x14169C608, "Component::GUI::AtkComponentIconText", 20).set_many({}).set_related_many({
    0x14052A5C0: "ctor",
}).set_defaults()
VTable(0x14169C6A8, "Component::GUI::AtkComponentDragDrop", 20).set_many({}).set_related_many({
    0x14052B840: "ctor",
}).set_defaults()
VTable(0x14169C7C8, "Component::GUI::AtkComponentMultipurpose", 20).set_many({}).set_related_many({
    0x14052D4A0: "ctor",
}).set_defaults()
VTable(0x14169C938, "Component::GUI::AtkComponentWindow", 26).set_many({}).set_related_many({
    0x14052DDD0: "ctor",
}).set_defaults()
VTable(0x14169CA08, "Component::GUI::AtkComponentJournalCanvas", 20).set_many({}).set_related_many({
    0x140533360: "ctor",
}).set_defaults()
VTable(0x14169CAA8, "Component::GUI::AtkComponentUnknownButton", 25).set_many({}).set_related_many({
    0x140536E90: "ctor",
}).set_defaults()
VTable(0x1416A9390, "Client::UI::Misc::UserFileManager::UserFileEvent", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416A9CF8, "Client::UI::UI3DModule::ObjectInfo", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416A9D28, "Client::UI::UI3DModule::MemberInfo", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416A9D88, "Client::UI::UI3DModule", 1).set_many({}).set_related_many({
    0x1405BB780: "ctor",
}).set_defaults()
VTable(0x1416A9DA0, "Client::UI::UIModule", 1).set_many({}).set_related_many({
    0x1405C47E0: "ctor",
}).set_defaults()
VTable(0x1416AA5A0, "Client::System::Crypt::SimpleString", 3).set_many({
    1: "Encrypt",
    2: "Decrypt",
}).set_related_many({
}).set_defaults()
VTable(0x1416AB430, "Component::Text::MacroDecoder", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416AB5F0, "Component::Text::TextChecker", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416AEAE8, "Client::UI::Misc::ConfigModule", 1).set_many({}).set_related_many({
    0x1405FAEA0: "ctor",
}).set_defaults()
VTable(0x1416AEAF8, "Client::UI::Misc::ConfigModule_Common::Configuration::ConfigBase::ChangeEventInterface", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416AEBD8, "Client::UI::Misc::RaptureMacroModule", 1).set_many({
    1: "ReadFile",
    2: "WriteFile",
}).set_related_many({}).set_defaults()
VTable(0x1416AEC40, "Client::UI::Misc::RaptureTextModule", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416AEEB8, "Client::UI::Misc::RaptureLogModule", 1).set_many({}).set_related_many({
    0x140615880: "ctor",
    0x140617010: "PrintMessage",
}).set_defaults()
VTable(0x1416AEF08, "Client::UI::Misc::RaptureHotbarModule", 1).set_many({}).set_related_many({
    0x1406207D0: "ctor",
}).set_defaults()
VTable(0x1416AEF70, "Client::UI::Misc::RaptureHotbarModule_Client::System::Input::InputCodeModifiedInterface", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416AEFE8, "Client::UI::Misc::PronounModule", 1).set_many({}).set_related_many({
    0x140629590: "ctor",
}).set_defaults()
VTable(0x1416AFAC0, "Client::UI::Misc::CharaView", 1).set_many({
    1: "Initialize",
    2: "Finalize",
}).set_related_many({
    0x14064FB80: "ctor",
    0x14065F700: "dtor",
}).set_defaults()
VTable(0x1416B0EC0, "Client::Game::Object::GameObject", 78).set_many({}).set_related_many({
    0x1406C5270: "Initialize",
    0x1406C54D0: "ctor",
}).set_defaults()
VTable(0x1416B1B48, "Client::Game::Character::Character", 89).set_many({
    3: "GetObjectKind",
    16: "EnableDraw",
    17: "DisableDraw",
    21: "SetDrawObject",
}).set_related_many({
    0x1406D5AC0: "dtor",
    0x1406EA340: "ctor",
}).set_defaults()
VTable(0x1416B1E10, "Client::Game::Character::Character_Client::Graphics::Vfx::VfxDataListener", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416C8150, "Client::Game::Character::BattleChara", 89).set_many({}).set_related_many({
    0x14073C140: "ctor",
    0x14073C230: "dtor",
}).set_defaults()
VTable(0x1416C8418, "Client::Game::Character::BattleChara_Client::Graphics::Vfx::VfxDataListener", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416CA7C0, "Client::Game::ActionManager", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416CC740, "Client::UI::Agent::AgentHUD", 14).set_many({
    5: "Update"
}).set_related_many({
    0x14081F350: "ctor",
    0x140824ED0: "UpdateParty",
}).set_defaults()
VTable(0x1416CCAF0, "Client::UI::Agent::AgentItemDetail", 15).set_many({}).set_related_many({
    0x1408D3F50: "ctor",
    0x1408D4F80: "OnItemHovered",
}).set_defaults()
VTable(0x1416CD4B8, "Client::UI::Agent::AgentMap::MapMarkerStructSearchName", 2).set_many({
    1: "Evaluate",
}).set_related_many({}).set_defaults()
VTable(0x1416CD4C8, "Client::UI::Agent::AgentMap", 14).set_many({}).set_related_many({
    0x140887BE0: "ctor",
}).set_defaults()
VTable(0x1416CE090, "Client::UI::Agent::AgentHudLayout", 14).set_many({
    2: "Show",
    3: "Hide",
}).set_related_many({
    0x1408C0B10: "ctor",
}).set_defaults()
VTable(0x1416CEED8, "Client::UI::Agent::AgentStatus", 14).set_many({}).set_related_many({
    0x140904190: "ctor",
}).set_defaults()
VTable(0x1416CEEA0, "Client::UI::Agent::AgentStatus::StatusCharaView", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416DF680, "Client::Game::Event::ModuleBase", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416E05C8, "Client::Game::Event::EventSceneModuleUsualImpl", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416E48A0, "Client::Game::Event::EventHandlerModule", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416E4918, "Client::Game::Event::DirectorModule", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1416F4AA8, "Client::Game::Gimmick::GimmickBill", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141798F70, "Client::UI::AddonNowLoading", 68).set_many({
    41: "LoadUldResourceHandle",
}).set_related_many({
    0x140CCD730: "ctor",
}).set_defaults()
VTable(0x1417C9DC8, "Client::UI::Atk2DAreaMap", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1417D4E18, "Client::UI::AddonTalk", 1).set_many({}).set_related_many({
    0x140E7C1D0: "ctor",
}).set_defaults()
VTable(0x1417D6AA0, "Client::UI::AddonItemDetail", 1).set_many({}).set_related_many({
    0x140E90440: "ctor",
    0x140E91960: "GenerateTooltip",
}).set_defaults()
VTable(0x1417DCDD0, "Client::UI::AddonAreaMap", 68).set_many({}).set_related_many({
    0x140EBDC30: "ctor",
}).set_defaults()
VTable(0x1417DEC90, "Client::UI::AddonNamePlate", 68).set_many({
    47: "UpdateNameplates",
}).set_related_many({
    0x140ED87F0: "ctor"
}).set_defaults()
VTable(0x14179BAD0, "Client::UI::AddonHudSelectYesno", 68).set_many({}).set_related_many({
    0x140CD9150: "ctor",
    0x140DD2610: "dtor",
}).set_defaults()
VTable(0x141810480, "Client::UI::AddonHudLayoutWindow", 1).set_many({}).set_related_many({
    0x14101D810: "ctor",
}).set_defaults()
VTable(0x1418106A0, "Client::UI::AddonHudLayoutScreen", 68).set_many({
    2: "Client::UI::AddonHudLayoutScreen_HandleMouseEvent",
}).set_related_many({
    0x14101EAA0: "ctor",
    0x141023730: "AddonOverlayMouseMovedEvent",
    0x141023960: "AddonOverlayMouseClickEvent",
    0x141023D60: "AddonOverlayMouseReleaseEvent",
    0x1410259A0: "_SetAddonScale",
}).set_defaults()
VTable(0x141825368, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::CullingJobOpt", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141825370, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::CallbackJobOpt", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141825378, "Client::Graphics::Culling::CullingManager_Client::Graphics::JobSystem_Client::Graphics::Culling::RenderCallbackJob", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141825380, "Client::Graphics::Culling::CullingManager", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x141828A68, "Client::Game::Character::Companion", 89).set_many({
    16: "EnableDraw",
}).set_related_many({
    0x141101890: "ctor",
}).set_defaults()
VTable(0x141829C80, "Client::Game::CameraBase", 12).set_many({}).set_related_many({}).set_defaults()
VTable(0x141829CE0, "Client::Game::Camera", 32).set_many({}).set_related_many({
    0x14110A340: "ctor",
}).set_defaults()
VTable(0x14182B780, "Client::Graphics::Culling::OcclusionCullingManager", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14182B790, "Client::Graphics::Streaming::StreamingManager_Client::Graphics::JobSystem_Client::Graphics::Streaming::StreamingManager::StreamingJob", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14182B798, "Client::Graphics::Streaming::StreamingManager", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x1418334C8, "Component::Log::LogModule", 1).set_many({}).set_related_many({}).set_defaults()
VTable(0x14187A2A0, "Client::Game::Gimmick::GimmickRect", 265).set_many({}).set_related_many({}).set_defaults()
# endregion
