// Forward References
struct Common::Math::Matrix2x2;
struct Common::Math::Matrix4x4;
struct Common::Math::Quaternion;
struct Common::Math::Rectangle;
struct Common::Math::Vector2;
struct Common::Math::Vector3;
struct Common::Math::Vector4;
struct Common::Lua::LuaState;
struct Common::Lua::lua_State;
struct Common::Lua::LuaThread;
struct Common::Log::LogModule;
struct Common::Configuration::ConfigProperties;
struct Common::Configuration::ConfigValue;
struct Common::Configuration::ConfigEntry;
struct Common::Configuration::ChangeEventInterface;
struct Common::Configuration::ConfigBase;
struct Common::Configuration::DevConfig;
struct Common::Configuration::SystemConfig;
struct Common::Component::BGCollision::BGCollisionModule;
struct Common::Component::BGCollision::RaycastHit;
struct Common::Component::BGCollision::Object;
struct Component::Exd::ExdModule;
struct Component::Excel::ExcelModule;
struct Component::Excel::ExcelModuleInterface;
struct Component::Excel::ExcelSheet;
struct Component::GUI::AgentHudLayout;
struct Component::GUI::AgentInterface;
struct Component::GUI::AtkArrayData;
struct Component::GUI::AtkArrayDataHolder;
struct Component::GUI::AtkCollisionNode;
struct Component::GUI::AtkComponentBase;
struct Component::GUI::AtkComponentButton;
struct Component::GUI::AtkComponentCheckBox;
struct Component::GUI::AtkComponentDragDrop;
struct Component::GUI::AtkComponentDropDownList;
struct Component::GUI::AtkComponentGaugeBar;
struct Component::GUI::AtkComponentGuildLeveCard;
struct Component::GUI::AtkComponentHoldButton;
struct Component::GUI::AtkComponentIcon;
struct Component::GUI::AtkComponentIconText;
struct Component::GUI::AtkComponentInputBase;
struct Component::GUI::AtkComponentJournalCanvas;
struct Component::GUI::AtkComponentList;
struct Component::GUI::AtkComponentListItemRenderer;
struct Component::GUI::AtkComponentNode;
struct Component::GUI::AtkComponentNumericInput;
struct Component::GUI::AtkComponentRadioButton;
struct Component::GUI::AtkComponentScrollBar;
struct Component::GUI::AtkComponentSlider;
struct Component::GUI::AtkComponentTextInput;
struct Component::GUI::AtkComponentTextNineGrid;
struct Component::GUI::AtkComponentTreeList;
struct Component::GUI::AtkComponentWindow;
struct Component::GUI::AtkCounterNode;
struct Component::GUI::AtkCursor;
struct Component::GUI::AtkDragDropManager;
struct Component::GUI::AtkEvent;
struct Component::GUI::AtkEventListener;
struct Component::GUI::AtkEventListenerUnk1;
struct Component::GUI::AtkEventManager;
struct Component::GUI::AtkEventTarget;
struct Component::GUI::AtkImageNode;
struct Component::GUI::AtkLinkedList;
struct Component::GUI::AtkModule;
struct Component::GUI::AtkEventInterface;
struct Component::GUI::AtkNineGridNode;
struct Component::GUI::AtkResNode;
struct Component::GUI::AtkStage;
struct Component::GUI::AtkTextNode;
struct Component::GUI::AtkTexture;
struct Component::GUI::AtkTextureResource;
struct Component::GUI::AtkTimelineManager;
struct Component::GUI::AtkTooltipManager;
struct Component::GUI::AtkUldAsset;
struct Component::GUI::AtkUldComponentDataBase;
struct Component::GUI::AtkUldComponentDataButton;
struct Component::GUI::AtkUldComponentDataCheckBox;
struct Component::GUI::AtkUldComponentDataDragDrop;
struct Component::GUI::AtkUldComponentDataDropDownList;
struct Component::GUI::AtkUldComponentDataGaugeBar;
struct Component::GUI::AtkUldComponentDataGuildLeveCard;
struct Component::GUI::AtkUldComponentDataHoldButton;
struct Component::GUI::AtkUldComponentDataIcon;
struct Component::GUI::AtkUldComponentDataIconText;
struct Component::GUI::AtkUldComponentDataInputBase;
struct Component::GUI::AtkUldComponentDataJournalCanvas;
struct Component::GUI::AtkUldComponentDataList;
struct Component::GUI::AtkUldComponentDataListItemRenderer;
struct Component::GUI::AtkUldComponentDataMap;
struct Component::GUI::AtkUldComponentDataMultipurpose;
struct Component::GUI::AtkUldComponentDataNumericInput;
struct Component::GUI::AtkUldComponentDataPreview;
struct Component::GUI::AtkUldComponentDataRadioButton;
struct Component::GUI::AtkUldComponentDataScrollBar;
struct Component::GUI::AtkUldComponentDataSlider;
struct Component::GUI::AtkUldComponentDataTextInput;
struct Component::GUI::AtkUldComponentDataTextNineGrid;
struct Component::GUI::AtkUldComponentDataTreeList;
struct Component::GUI::AtkUldComponentDataWindow;
struct Component::GUI::AtkUldComponentInfo;
struct Component::GUI::AtkUldManager;
struct Component::GUI::AtkUldObjectInfo;
struct Component::GUI::AtkUldPart;
struct Component::GUI::AtkUldPartsList;
struct Component::GUI::AtkUldWidgetInfo;
struct Component::GUI::AtkUnitBase;
struct Component::GUI::AtkUnitList;
struct Component::GUI::AtkUnitManager;
struct Component::GUI::AtkValue;
struct Component::GUI::ExtendArrayData;
struct Component::GUI::NumberArrayData;
struct Component::GUI::StringArrayData;
struct Component::GUI::ULD::AtkUldComponentDataTab;
struct Client::UI::AddonActionBar;
struct Client::UI::AddonActionBarBase;
struct Client::UI::ActionBarSlot;
struct Client::UI::AddonActionCross;
struct Client::UI::AddonActionBarX;
struct Client::UI::AddonActionDoubleCrossBase;
struct Client::UI::AddonAOZNotebook;
struct Client::UI::AddonBank;
struct Client::UI::AddonCastBar;
struct Client::UI::AddonCharacterInspect;
struct Client::UI::AddonChatLogPanel;
struct Client::UI::AddonChocoboBreedTraining;
struct Client::UI::AddonContentsFinder;
struct Client::UI::AddonContentsFinderConfirm;
struct Client::UI::AddonContextIconMenu;
struct Client::UI::AddonContextMenu;
struct Client::UI::AddonCutSceneSelectString;
struct Client::UI::AddonEnemyList;
struct Client::UI::AddonExp;
struct Client::UI::AddonFateReward;
struct Client::UI::AddonFieldMarker;
struct Client::UI::AddonWaymarkInfo;
struct Client::UI::AddonFriendList;
struct Client::UI::AddonGathering;
struct Client::UI::AddonGatheringMasterpiece;
struct Client::UI::AddonGcArmyCapture;
struct Client::UI::AddonGcArmyExpedition;
struct Client::UI::AddonGcArmyExpeditionResult;
struct Client::UI::AddonGoldSaucerInfo;
struct Client::UI::AddonGrandCompanySupplyList;
struct Client::UI::AddonGrandCompanySupplyReward;
struct Client::UI::AddonGSInfoCardDeck;
struct Client::UI::AddonGSInfoCardList;
struct Client::UI::AddonGSInfoChocoboParam;
struct Client::UI::AddonGSInfoGeneral;
struct Client::UI::AddonGSInfoEmj;
struct Client::UI::AddonGSInfoMinionBattle;
struct Client::UI::AddonGuildLeve;
struct Client::UI::AddonHudLayoutScreen;
struct Client::UI::MoveableAddonInfoStruct;
struct Client::UI::AddonHudLayoutWindow;
struct Client::UI::AddonImage;
struct Client::UI::AddonItemInspectionList;
struct Client::UI::AddonItemInspectionResult;
struct Client::UI::AddonItemSearchResult;
struct Client::UI::AddonJournalDetail;
struct Client::UI::AddonJournalResult;
struct Client::UI::AddonLookingForGroupDetail;
struct Client::UI::AddonLotteryDaily;
struct Client::UI::AddonMacro;
struct Client::UI::AddonMaterializeDialog;
struct Client::UI::AddonMateriaRetrieveDialog;
struct Client::UI::AddonMobHunt;
struct Client::UI::AddonNamePlate;
struct Client::UI::AddonNeedGreed;
struct Client::UI::AddonPartyList;
struct Client::UI::AddonRaceChocoboResult;
struct Client::UI::AddonRaidFinder;
struct Client::UI::RaidFinderDutyEntry;
struct Client::UI::AddonRecipeNote;
struct Client::UI::AddonReconstructionBox;
struct Client::UI::AddonItemDonationInfo;
struct Client::UI::AddonRelicNoteBook;
struct Client::UI::AddonRepair;
struct Client::UI::AddonRequest;
struct Client::UI::AddonRetainerItemTransferList;
struct Client::UI::AddonRetainerItemTransferProgress;
struct Client::UI::AddonRetainerList;
struct Client::UI::AddonRetainerSell;
struct Client::UI::AddonRetainerTaskAsk;
struct Client::UI::AddonRetainerTaskList;
struct Client::UI::AddonRetainerTaskResult;
struct Client::UI::AddonSalvageDialog;
struct Client::UI::AddonSalvageItemSelector;
struct Client::UI::AddonSatisfactionSupply;
struct Client::UI::AddonDeliveryItemInfo;
struct Client::UI::AddonSelectIconString;
struct Client::UI::AddonSelectOk;
struct Client::UI::AddonSelectString;
struct Client::UI::AddonSelectYesno;
struct Client::UI::AddonShopCardDialog;
struct Client::UI::AddonSocial;
struct Client::UI::AddonSynthesis;
struct Client::UI::AddonTalk;
struct Client::UI::AddonTeleport;
struct Client::UI::AddonWeeklyBingo;
struct Client::UI::DutySlotList;
struct Client::UI::DutySlot;
struct Client::UI::StringThing;
struct Client::UI::StickerSlotList;
struct Client::UI::StickerSlot;
struct Client::UI::AddonWeeklyPuzzle;
struct Client::UI::PopupMenu;
struct Client::UI::RaptureAtkModule;
struct Client::UI::RaptureAtkUnitManager;
struct Client::UI::UI3DModule;
struct Client::UI::UIModule;
struct Client::UI::Shell::RaptureShellModule;
struct Client::UI::Misc::CharaView;
struct Client::UI::Misc::ConfigModule;
struct Client::UI::Misc::FieldMarkerModule;
struct Client::UI::Misc::GamePresetPoint;
struct Client::UI::Misc::FieldMarkerPreset;
struct Client::UI::Misc::ItemFinderModule;
struct Client::UI::Misc::ItemFinderModuleResult;
struct Client::UI::Misc::ItemFinderModuleRetainerResult;
struct Client::UI::Misc::ItemOrderModule;
struct Client::UI::Misc::ItemOrderModuleSorter;
struct Client::UI::Misc::ItemOrderModuleSorterRetainerEntry;
struct Client::UI::Misc::ItemOrderModuleSorterItemEntry;
struct Client::UI::Misc::ItemOrderModuleSorterPreviousOrderEntry;
struct Client::UI::Misc::ItemOrderModuleSorterSortFunctionEntry;
struct Client::UI::Misc::PronounModule;
struct Client::UI::Misc::RaptureGearsetModule;
struct Client::UI::Misc::RaptureHotbarModule;
struct Client::UI::Misc::HotBars;
struct Client::UI::Misc::HotBar;
struct Client::UI::Misc::HotBarSlots;
struct Client::UI::Misc::HotBarSlot;
struct Client::UI::Misc::SavedHotBars;
struct Client::UI::Misc::RaptureLogModule;
struct Client::UI::Misc::LogMessageSource;
struct Client::UI::Misc::RaptureLogModuleTab;
struct Client::UI::Misc::RaptureMacroModule;
struct Client::UI::Misc::RaptureTextModule;
struct Client::UI::Misc::RaptureUiDataModule;
struct Client::UI::Misc::RecommendEquipModule;
struct Client::UI::Misc::RetainerCommentModule;
struct Client::UI::Misc::ScreenLog;
struct Client::UI::Misc::UiSavePackModule;
struct Client::UI::Misc::UserFileManager::UserFileEvent;
struct Client::UI::Info::InfoModule;
struct Client::UI::Info::InfoProxy11;
struct Client::UI::Info::InfoProxy17;
struct Client::UI::Info::InfoProxy20;
struct Client::UI::Info::InfoProxy21;
struct Client::UI::Info::InfoProxy22;
struct Client::UI::Info::InfoProxy23;
struct Client::UI::Info::InfoProxy24;
struct Client::UI::Info::InfoProxy25;
struct Client::UI::Info::InfoProxy26;
struct Client::UI::Info::InfoProxy27;
struct Client::UI::Info::InfoProxy28;
struct Client::UI::Info::InfoProxyBlacklist;
struct Client::UI::Info::InfoProxyCircle;
struct Client::UI::Info::InfoProxyCircleFinder;
struct Client::UI::Info::InfoProxyCircleList;
struct Client::UI::Info::InfoProxyCommonList;
struct Client::UI::Info::InfoProxyCrossRealm;
struct Client::UI::Info::CrossRealmGroup;
struct Client::UI::Info::CrossRealmMember;
struct Client::UI::Info::InfoProxyCrossWorldLinkShell;
struct Client::UI::Info::InfoProxyCrossWorldLinkShellMember;
struct Client::UI::Info::InfoProxyFreeCompany;
struct Client::UI::Info::InfoProxyFreeCompanyCreate;
struct Client::UI::Info::InfoProxyFreeCompanyMember;
struct Client::UI::Info::InfoProxyFriendList;
struct Client::UI::Info::InfoProxyInterface;
struct Client::UI::Info::InfoProxyInvitedInterface;
struct Client::UI::Info::InfoProxyPageInterface;
struct Client::UI::Info::InfoProxyInvitedList;
struct Client::UI::Info::InfoProxyItemSearch;
struct Client::UI::Info::InfoProxyLetter;
struct Client::UI::Info::InfoProxyLinkShell;
struct Client::UI::Info::InfoProxyLinkShellChat;
struct Client::UI::Info::InfoProxyLinkshellMember;
struct Client::UI::Info::InfoProxyParty;
struct Client::UI::Info::InfoProxyPartyInvite;
struct Client::UI::Info::InfoProxySearch;
struct Client::UI::Info::InfoProxySearchComment;
struct Client::UI::Agent::AgentActionMenu;
struct Client::UI::Agent::ActionData;
struct Client::UI::Agent::ExtraCommandData;
struct Client::UI::Agent::AgentAozContentBriefing;
struct Client::UI::Agent::AozContentData;
struct Client::UI::Agent::AozArrangementData;
struct Client::UI::Agent::AozWeeklyReward;
struct Client::UI::Agent::AgentAozContentResult;
struct Client::UI::Agent::AozContentResultData;
struct Client::UI::Agent::AgentArchiveItem;
struct Client::UI::Agent::ArchiveItem;
struct Client::UI::Agent::AgentBannerInterface;
struct Client::UI::Agent::AgentBannerMIP;
struct Client::UI::Agent::AgentBannerParty;
struct Client::UI::Agent::AgentCharaCard;
struct Client::UI::Agent::AgentCompanyCraftMaterial;
struct Client::UI::Agent::AgentContentsFinder;
struct Client::UI::Agent::ContentsFinderRewards;
struct Client::UI::Agent::ItemReward;
struct Client::UI::Agent::AgentContext;
struct Client::UI::Agent::ContextMenu;
struct Client::UI::Agent::ContextMenuTarget;
struct Client::UI::Agent::AgentCraftActionSimulator;
struct Client::UI::Agent::ProgressEfficiencyCalculations;
struct Client::UI::Agent::QualityEfficiencyCalculations;
struct Client::UI::Agent::EfficiencyCalculation;
struct Client::UI::Agent::ProgressEfficiencyCalculation;
struct Client::UI::Agent::QualityEfficiencyCalculation;
struct Client::UI::Agent::AgentDeepDungeonInspect;
struct Client::UI::Agent::AgentDeepDungeonMap;
struct Client::UI::Agent::AgentDeepDungeonMapData;
struct Client::UI::Agent::AgentDeepDungeonStatus;
struct Client::UI::Agent::DeepDungeonStatusData;
struct Client::UI::Agent::DeepDungeonStatusItem;
struct Client::UI::Agent::AgentAirshipExplorationResult;
struct Client::UI::Agent::AgentSubmersibleExplorationResult;
struct Client::UI::Agent::AgentExplorationResultInterface;
struct Client::UI::Agent::ExplorationResultData;
struct Client::UI::Agent::ExplorationResultDataItemReturn;
struct Client::UI::Agent::AgentFieldMarker;
struct Client::UI::Agent::AgentFishGuide;
struct Client::UI::Agent::AgentFreeCompany;
struct Client::UI::Agent::AgentFreeCompanyCrestEditor;
struct Client::UI::Agent::AgentFreeCompanyProfile;
struct Client::UI::Agent::CrestData;
struct Client::UI::Agent::AgentGatheringNote;
struct Client::UI::Agent::AgentGcArmyExpedition;
struct Client::UI::Agent::GcArmyExpeditionData;
struct Client::UI::Agent::MissionInfo;
struct Client::UI::Agent::AgentGoldSaucer;
struct Client::UI::Agent::AgentGrandCompanySupply;
struct Client::UI::Agent::SupplyProvisioningData;
struct Client::UI::Agent::SupplyProvisioningItem;
struct Client::UI::Agent::GrandCompanyItem;
struct Client::UI::Agent::AgentHUD;
struct Client::UI::Agent::HudPartyMemberEnmity;
struct Client::UI::Agent::HudPartyMember;
struct Client::UI::Agent::AgentInspect;
struct Client::UI::Agent::AgentInventoryContext;
struct Client::UI::Agent::AgentItemSearch;
struct Client::UI::Agent::AgentLobby;
struct Client::UI::Agent::AgentLoot;
struct Client::UI::Agent::AgentMap;
struct Client::UI::Agent::MapMarkerBase;
struct Client::UI::Agent::FlagMapMarker;
struct Client::UI::Agent::MapMarkerInfo;
struct Client::UI::Agent::TempMapMarker;
struct Client::UI::Agent::MiniMapMarker;
struct Client::UI::Agent::OpenMapInfo;
struct Client::UI::Agent::AgentMiragePrismPrismBox;
struct Client::UI::Agent::MiragePrismPrismBoxData;
struct Client::UI::Agent::PrismBoxItem;
struct Client::UI::Agent::PrismBoxCrystallizeItem;
struct Client::UI::Agent::AgentMJIPouch;
struct Client::UI::Agent::PouchInventoryItem;
struct Client::UI::Agent::AgentModule;
struct Client::UI::Agent::AgentMonsterNote;
struct Client::UI::Agent::AgentMycItemBox;
struct Client::UI::Agent::MycItemBoxData;
struct Client::UI::Agent::MycItemCategory;
struct Client::UI::Agent::MycItem;
struct Client::UI::Agent::AgentReadyCheck;
struct Client::UI::Agent::AgentRecipeNote;
struct Client::UI::Agent::AgentReconstructionBox;
struct Client::UI::Agent::AgentItemDonationInfo;
struct Client::UI::Agent::AgentRequest;
struct Client::UI::Agent::AgentRetainerItemTransfer;
struct Client::UI::Agent::AgentRetainerItemTransferData;
struct Client::UI::Agent::AgentRetainerList;
struct Client::UI::Agent::AgentRevive;
struct Client::UI::Agent::AgentSalvage;
struct Client::UI::Agent::SalvageResult;
struct Client::UI::Agent::AgentSatisfactionSupply;
struct Client::UI::Agent::AgentDeliveryItemInfo;
struct Client::UI::Agent::BalloonInfo;
struct Client::UI::Agent::BalloonSlot;
struct Client::UI::Agent::AgentScreenLog;
struct Client::UI::Agent::AgentTeleport;
struct Client::System::String::Utf8String;
struct Client::System::Scheduler::Resource::SchedulerResource;
struct Client::System::Scheduler::Resource::SchedulerResourceManagement;
struct Client::System::Scheduler::Base::SchedulerState;
struct Client::System::Scheduler::Base::SchedulerTimeline;
struct Client::System::Scheduler::Base::TimelineController;
struct Client::System::Resource::ResourceGraph;
struct Client::System::Resource::ResourceManager;
struct Client::System::Resource::Handle::MaterialResourceHandle;
struct Client::System::Resource::Handle::ResourceHandle;
struct Client::System::Resource::Handle::SkeletonResourceHandle;
struct Client::System::Resource::Handle::TextureResourceHandle;
struct Client::System::Memory::IMemorySpace;
struct Client::System::Framework::Framework;
struct Client::System::Framework::GameVersion;
struct Client::System::File::FileDescriptor;
struct Client::System::Configuration::DevConfig;
struct Client::System::Configuration::SystemConfig;
struct Client::LayoutEngine::LayoutManager;
struct Client::LayoutEngine::IndoorAreaLayoutData;
struct Client::LayoutEngine::IndoorFloorLayoutData;
struct Client::LayoutEngine::LayoutWorld;
struct Client::Graphics::ByteColor;
struct Client::Graphics::Ray;
struct Client::Graphics::ReferencedClassBase;
struct Client::Graphics::Transform;
struct Client::Graphics::Vfx::VfxData;
struct Client::Graphics::Scene::Camera;
struct Client::Graphics::Scene::CameraManager;
struct Client::Graphics::Scene::CharacterBase;
struct Client::Graphics::Scene::Demihuman;
struct Client::Graphics::Scene::DrawObject;
struct Client::Graphics::Scene::EnvLocation;
struct Client::Graphics::Scene::EnvScene;
struct Client::Graphics::Scene::EnvSpace;
struct Client::Graphics::Scene::Human;
struct Client::Graphics::Scene::Monster;
struct Client::Graphics::Scene::Object;
struct Client::Graphics::Scene::Weapon;
struct Client::Graphics::Scene::World;
struct Client::Graphics::Physics::BoneSimulators;
struct Client::Graphics::Physics::BonePhysicsModule;
struct Client::Graphics::Physics::BoneSimulator;
struct Client::Graphics::Render::Notifier;
struct Client::Graphics::Render::Texture;
struct Client::Graphics::Render::Camera;
struct Client::Graphics::Render::Manager;
struct Client::Graphics::Render::OffscreenRenderingManager;
struct Client::Graphics::Render::PartialSkeleton;
struct Client::Graphics::Render::RenderTargetManager;
struct Client::Graphics::Render::ShadowCamera;
struct Client::Graphics::Render::Skeleton;
struct Client::Graphics::Render::SubView;
struct Client::Graphics::Render::View;
struct Client::Graphics::Kernel::CVector;
struct Client::Graphics::Kernel::Device;
struct Client::Graphics::Kernel::PixelShader;
struct Client::Graphics::Kernel::ShaderNode;
struct Client::Graphics::Kernel::ShaderPackage;
struct Client::Graphics::Kernel::SwapChain;
struct Client::Graphics::Kernel::VertexShader;
struct Client::Graphics::Environment::EnvManager;
struct Client::Graphics::Environment::EnvSimulator;
struct Client::Graphics::Environment::EnvSoundState;
struct Client::Graphics::Environment::EnvState;
struct Client::Graphics::Animation::AnimationResourceHandle;
struct Client::Game::ActionManager;
struct Client::Game::RecastDetail;
struct Client::Game::ComboDetail;
struct Client::Game::ActionTimelineManager;
struct Client::Game::ActionTimelineDriver;
struct Client::Game::Balloon;
struct Client::Game::Camera;
struct Client::Game::LobbyCamera;
struct Client::Game::Camera3;
struct Client::Game::LowCutCamera;
struct Client::Game::Camera4;
struct Client::Game::CameraBase;
struct Client::Game::GameMain;
struct Client::Game::InventoryManager;
struct Client::Game::InventoryContainer;
struct Client::Game::InventoryItem;
struct Client::Game::JobGaugeManager;
struct Client::Game::MonsterNoteManager;
struct Client::Game::MonsterNoteRankInfo;
struct Client::Game::RankData;
struct Client::Game::QuestManager;
struct Client::Game::RaceChocoboManager;
struct Client::Game::ReconstructionBoxManager;
struct Client::Game::ReconstructionBoxData;
struct Client::Game::RetainerManager;
struct Client::Game::SatisfactionSupplyManager;
struct Client::Game::SavedAppearanceManager;
struct Client::Game::SavedAppearanceSlot;
struct Client::Game::Status;
struct Client::Game::StatusManager;
struct Client::Game::UI::AreaInstance;
struct Client::Game::UI::Buddy;
struct Client::Game::UI::Cabinet;
struct Client::Game::UI::ContentsFinder;
struct Client::Game::UI::ContentsNote;
struct Client::Game::UI::Hate;
struct Client::Game::UI::HateInfo;
struct Client::Game::UI::Hater;
struct Client::Game::UI::HaterInfo;
struct Client::Game::UI::Hotbar;
struct Client::Game::UI::LimitBreakController;
struct Client::Game::UI::Loot;
struct Client::Game::UI::LootItem;
struct Client::Game::UI::Map;
struct Client::Game::UI::MarkingController;
struct Client::Game::UI::FieldMarker;
struct Client::Game::UI::MobHunt;
struct Client::Game::UI::PlayerState;
struct Client::Game::UI::PvPProfile;
struct Client::Game::UI::RecipeNote;
struct Client::Game::UI::RelicNote;
struct Client::Game::UI::Revive;
struct Client::Game::UI::RouletteController;
struct Client::Game::UI::Telepo;
struct Client::Game::UI::TeleportInfo;
struct Client::Game::UI::SelectUseTicketInvoker;
struct Client::Game::UI::TerritoryInfo;
struct Client::Game::UI::UIState;
struct Client::Game::UI::WeaponState;
struct Client::Game::Object::ClientObjectManager;
struct Client::Game::Object::GameObjectID;
struct Client::Game::Object::GameObject;
struct Client::Game::Object::GameObjectManager;
struct Client::Game::MJI::IslandState;
struct Client::Game::MJI::MJIWorkshops;
struct Client::Game::MJI::MJIGranaries;
struct Client::Game::MJI::MJIFarmPasture;
struct Client::Game::MJI::MJIFarmState;
struct Client::Game::MJI::MJIManager;
struct Client::Game::MJI::MJIBuildingPlacement;
struct Client::Game::MJI::MJILandmarkPlacement;
struct Client::Game::MJI::MJIFarmPasturePlacement;
struct Client::Game::MJI::MJIPastureHandler;
struct Client::Game::MJI::MJIAnimal;
struct Client::Game::MJI::MJIMinionSlot;
struct Client::Game::InstanceContent::ContentDirector;
struct Client::Game::InstanceContent::InstanceContentDeepDungeon;
struct Client::Game::InstanceContent::InstanceContentDirector;
struct Client::Game::InstanceContent::PublicContentDirector;
struct Client::Game::Housing::HousingManager;
struct Client::Game::Housing::HousingTerritory;
struct Client::Game::Housing::HousingWorkshopTerritory;
struct Client::Game::Housing::HousingWorkshopAirshipData;
struct Client::Game::Housing::HousingWorkshopSubmersibleData;
struct Client::Game::Housing::HousingWorkshopAirshipSubData;
struct Client::Game::Housing::HousingWorkshopAirshipGathered;
struct Client::Game::Housing::HousingWorkshopSubmersibleSubData;
struct Client::Game::Housing::HousingWorkshopSubmarineGathered;
struct Client::Game::Group::GroupManager;
struct Client::Game::Group::PartyMember;
struct Client::Game::Gauge::JobGauge;
struct Client::Game::Gauge::WhiteMageGauge;
struct Client::Game::Gauge::ScholarGauge;
struct Client::Game::Gauge::AstrologianGauge;
struct Client::Game::Gauge::SageGauge;
struct Client::Game::Gauge::BlackMageGauge;
struct Client::Game::Gauge::SummonerGauge;
struct Client::Game::Gauge::RedMageGauge;
struct Client::Game::Gauge::BardGauge;
struct Client::Game::Gauge::MachinistGauge;
struct Client::Game::Gauge::DancerGauge;
struct Client::Game::Gauge::MonkGauge;
struct Client::Game::Gauge::DragoonGauge;
struct Client::Game::Gauge::NinjaGauge;
struct Client::Game::Gauge::SamuraiGauge;
struct Client::Game::Gauge::ReaperGauge;
struct Client::Game::Gauge::DarkKnightGauge;
struct Client::Game::Gauge::PaladinGauge;
struct Client::Game::Gauge::WarriorGauge;
struct Client::Game::Gauge::GunbreakerGauge;
struct Client::Game::Fate::FateContext;
struct Client::Game::Fate::FateDirector;
struct Client::Game::Fate::FateManager;
struct Client::Game::Event::Director;
struct Client::Game::Event::DirectorModule;
struct Client::Game::Event::EventFramework;
struct Client::Game::Event::EventGPoseController;
struct Client::Game::Event::EventHandler;
struct Client::Game::Event::EventHandlerInfo;
struct Client::Game::Event::EventId;
struct Client::Game::Event::EventHandlerModule;
struct Client::Game::Event::EventSceneModule;
struct Client::Game::Event::EventSceneModuleUsualImpl;
struct Client::Game::Event::EventSceneModuleImplBase;
struct Client::Game::Event::EventState;
struct Client::Game::Event::LuaActor;
struct Client::Game::Event::LuaActorModule;
struct Client::Game::Event::LuaEventHandler;
struct Client::Game::Event::ModuleBase;
struct Client::Game::Control::CameraManager;
struct Client::Game::Control::Control;
struct Client::Game::Control::InputManager;
struct Client::Game::Control::TargetSystem;
struct Client::Game::Control::GameObjectArray;
struct Client::Game::Character::BattleChara;
struct Client::Game::Character::Character;
struct Client::Game::Character::CharacterManager;
struct Client::Game::Character::Companion;
struct Client::Game::Character::DrawDataContainer;
struct Client::Game::Character::DrawObjectData;
struct Client::Game::Character::CustomizeData;
struct Client::Game::Character::WeaponModelId;
struct Client::Game::Character::EquipmentModelId;
struct Client::Game::Character::Ornament;
struct Application::Network::WorkDefinitions::BeastReputationWork;
struct Application::Network::WorkDefinitions::DailyQuestWork;
struct Application::Network::WorkDefinitions::LeveWork;
struct Application::Network::WorkDefinitions::QuestWork;
struct Application::Network::WorkDefinitions::TrackingWork;
struct Common::Configuration::ConfigProperties::UIntProperties;
struct Common::Configuration::ConfigProperties::FloatProperties;
struct Common::Configuration::ConfigProperties::StringProperties;
struct Component::Excel::ExcelModule::ExcelModuleVTable;
struct Component::Excel::ExcelModuleInterface::ExcelModuleInterfaceVTable;
struct Component::GUI::AgentInterface::AgentInterfaceVTable;
struct Component::GUI::AtkComponentBase::AtkComponentBaseVTable;
struct Component::GUI::AtkComponentList::ListItem;
struct Component::GUI::AtkLinkedList::Node;
struct Component::GUI::AtkModule::AtkModuleVTable;
struct Component::GUI::AtkResNode::AtkResNodeVTable;
struct Component::GUI::AtkTexture::AtkTextureVTable;
struct Component::GUI::AtkTooltipManager::AtkTooltipArgs;
struct Component::GUI::AtkTooltipManager::AtkTooltipInfo;
struct Component::GUI::AtkUldManager::DuplicateNodeInfo;
struct Component::GUI::AtkUldManager::DuplicateObjectList;
struct Component::GUI::AtkUnitBase::AtkUnitBaseVTable;
struct Client::UI::AddonActionBarBase::AddonActionBarBaseVTable;
struct Client::UI::AddonAOZNotebook::SpellbookBlock;
struct Client::UI::AddonAOZNotebook::ActiveActions;
struct Client::UI::AddonBank::AddonBankVTable;
struct Client::UI::AddonContentsFinder::AddonContentsFinderVTable;
struct Client::UI::AddonContentsFinderConfirm::AddonContentsFinderConfirmVTable;
struct Client::UI::AddonLotteryDaily::GameTileRow;
struct Client::UI::AddonLotteryDaily::GameTileBoard;
struct Client::UI::AddonLotteryDaily::LaneTileSelector;
struct Client::UI::AddonLotteryDaily::GameNumberRow;
struct Client::UI::AddonLotteryDaily::GameBoardNumbers;
struct Client::UI::AddonNamePlate::BakePlateRenderer;
struct Client::UI::AddonNamePlate::BakeData;
struct Client::UI::AddonNamePlate::NamePlateObject;
struct Client::UI::AddonNeedGreed::LootItemInfo;
struct Client::UI::AddonPartyList::PartyMembers;
struct Client::UI::AddonPartyList::TrustMembers;
struct Client::UI::AddonPartyList::PartyListMemberStruct;
struct Client::UI::AddonRaceChocoboResult::AddonRaceChocoboResultVTable;
struct Client::UI::AddonRelicNoteBook::TargetNode;
struct Client::UI::AddonRetainerItemTransferList::AddonRetainerItemTransferListVTable;
struct Client::UI::AddonRetainerItemTransferProgress::AddonRetainerItemTransferProgressVTable;
struct Client::UI::AddonRetainerList::AddonRetainerListVTable;
struct Client::UI::AddonRetainerTaskAsk::AddonRetainerTaskAskVTable;
struct Client::UI::AddonRetainerTaskList::AddonRetainerTaskListVTable;
struct Client::UI::AddonRetainerTaskResult::AddonRetainerTaskResultVTable;
struct Client::UI::AddonSalvageItemSelector::SalvageItem;
struct Client::UI::AddonSelectIconString::PopupMenuDerive;
struct Client::UI::AddonSelectString::PopupMenuDerive;
struct Client::UI::AddonSelectString::AddonSelectStringVTable;
struct Client::UI::AddonSynthesis::CraftEffect;
struct Client::UI::AddonWeeklyPuzzle::RewardPanelItem;
struct Client::UI::AddonWeeklyPuzzle::GameTileBoard;
struct Client::UI::AddonWeeklyPuzzle::GameTileRow;
struct Client::UI::AddonWeeklyPuzzle::GameTileItem;
struct Client::UI::RaptureAtkModule::NamePlateInfo;
struct Client::UI::RaptureAtkModule::RaptureAtkModuleVTable;
struct Client::UI::UI3DModule::MapInfo;
struct Client::UI::UI3DModule::ObjectInfo;
struct Client::UI::UI3DModule::MemberInfo;
struct Client::UI::UI3DModule::UnkInfo;
struct Client::UI::UIModule::Unk1;
struct Client::UI::UIModule::Unk2;
struct Client::UI::UIModule::Unk3;
struct Client::UI::UIModule::UIModuleVTable;
struct Client::UI::Misc::CharaView::UnkStruct;
struct Client::UI::Misc::ConfigModule::Option;
struct Client::UI::Misc::RaptureGearsetModule::Gearsets;
struct Client::UI::Misc::RaptureGearsetModule::GearsetItem;
struct Client::UI::Misc::RaptureGearsetModule::GearsetEntry;
struct Client::UI::Misc::SavedHotBars::SavedHotBarClassJob;
struct Client::UI::Misc::SavedHotBars::SavedHotBarClassJobBars;
struct Client::UI::Misc::SavedHotBars::SavedHotBarClassJobSlots;
struct Client::UI::Misc::RaptureMacroModule::Macro;
struct Client::UI::Misc::RaptureMacroModule::MacroPage;
struct Client::UI::Misc::RetainerCommentModule::RetainerCommentList;
struct Client::UI::Misc::RetainerCommentModule::RetainerComment;
struct Client::UI::Misc::UiSavePackModule::UiSavePackModuleVTable;
struct Client::UI::Misc::UserFileManager::UserFileEvent::UserFileEventVTable;
struct Client::UI::Info::InfoProxyCircle::Unk1;
struct Client::UI::Info::InfoProxyCommonList::CharacterData;
struct Client::UI::Info::InfoProxyCommonList::CharIndexEntry;
struct Client::UI::Info::InfoProxyCommonList::CharacterDict;
struct Client::UI::Info::InfoProxyCommonList::CharacterArray;
struct Client::UI::Info::InfoProxyCrossWorldLinkShell::CWLSEntry;
struct Client::UI::Info::InfoProxyFreeCompany::RankData;
struct Client::UI::Info::InfoProxyFriendList::StrBuf;
struct Client::UI::Info::InfoProxyInterface::InfoProxyInterfaceVTable;
struct Client::UI::Info::InfoProxyInvitedInterface::Unk18;
struct Client::UI::Info::InfoProxyItemSearch::Entry;
struct Client::UI::Info::InfoProxyLetter::Letter;
struct Client::UI::Info::InfoProxyLinkShell::Entry;
struct Client::UI::Agent::AgentBannerInterface::Storage;
struct Client::UI::Agent::AgentCharaCard::Storage;
struct Client::UI::Agent::AgentDeepDungeonInspect::AgentDeepDungeonInspectData;
struct Client::UI::Agent::AgentFreeCompany::FreeCompanyActionTimer;
struct Client::UI::Agent::AgentFreeCompanyProfile::FCProfile;
struct Client::UI::Agent::AgentInspect::FreeCompanyData;
struct Client::UI::Agent::AgentInspect::ItemData;
struct Client::UI::Agent::AgentMJIPouch::PouchIndexInfo;
struct Client::UI::Agent::AgentMJIPouch::PouchInventoryData;
struct Client::UI::Agent::AgentReadyCheck::ReadyCheckEntry;
struct Client::UI::Agent::AgentRetainerItemTransferData::DuplicateItemEntry;
struct Client::UI::Agent::AgentRetainerList::RetainerList;
struct Client::UI::Agent::AgentRetainerList::Retainer;
struct Client::UI::Agent::AgentSalvage::SalvageListItem;
struct Client::UI::Agent::AgentSatisfactionSupply::SatisfactionSupplyNpcInfo;
struct Client::UI::Agent::AgentSatisfactionSupply::ItemInfo;
struct Client::System::Scheduler::Resource::SchedulerResource::ResourceName;
struct Client::System::Scheduler::Base::SchedulerTimeline::SchedulerTimelineVTable;
struct Client::System::Resource::ResourceGraph::CategoryContainer;
struct Client::System::Resource::Handle::SkeletonResourceHandle::SkeletonHeader;
struct Client::System::Memory::IMemorySpace::IMemorySpaceVTable;
struct Client::Graphics::Scene::CharacterBase::CharacterBaseVTable;
struct Client::Graphics::Scene::Object::ObjectVTable;
struct Client::Graphics::Kernel::ShaderNode::ShaderPass;
struct Client::Graphics::Kernel::ShaderPackage::MaterialElement;
struct Client::Graphics::Kernel::ShaderPackage::ConstantSamplerUnknown;
struct Client::Game::QuestManager::QuestListArray;
struct Client::Game::RetainerManager::RetainerList;
struct Client::Game::SavedAppearanceManager::SavedAppearanceManagerVTable;
struct Client::Game::UI::Buddy::BuddyMember;
struct Client::Game::UI::Map::QuestMarkerArray;
struct Client::Game::UI::Map::MapMarkerInfo;
struct Client::Game::UI::MobHunt::KillCounts;
struct Client::Game::UI::RecipeNote::RecipeData;
struct Client::Game::UI::RecipeNote::RecipeEntry;
struct Client::Game::Object::GameObject::GameObjectVTable;
struct Client::Game::InstanceContent::InstanceContentDeepDungeon::DeepDungeonPartyInfo;
struct Client::Game::InstanceContent::InstanceContentDeepDungeon::DeepDungeonItemInfo;
struct Client::Game::InstanceContent::InstanceContentDeepDungeon::DeepDungeonChestInfo;
struct Client::Game::Character::Character::CastInfo;
struct Client::Game::Character::Character::ForayInfo;
struct Client::Game::Character::Character::MountContainer;
struct Client::Game::Character::Character::CompanionContainer;
struct Client::Game::Character::Character::OrnamentContainer;
struct Client::Game::Character::Character::CharacterVTable;
struct Client::UI::AddonPartyList::PartyListMemberStruct::StatusIcons;
struct Client::UI::Misc::SavedHotBars::SavedHotBarClassJobBars::SavedHotBarClassJobBar;
struct Client::UI::Misc::SavedHotBars::SavedHotBarClassJobSlots::SavedHotBarClassJobSlot;
struct Client::UI::Misc::RaptureMacroModule::Macro::Lines;
struct Client::UI::Info::InfoProxyCommonList::CharacterDict::Entry;
struct Client::UI::Info::InfoProxyCommonList::CharacterArray::Entry;
struct Client::UI::Info::InfoProxyLetter::Letter::ItemAttachment;
struct Client::UI::Agent::AgentBannerInterface::Storage::CharacterData;
struct Client::UI::Agent::AgentInspect::ItemData::ColorRGB;
struct Client::Game::QuestManager::QuestListArray::Quest;
struct Client::Game::RetainerManager::RetainerList::Retainer;

// Definitions
struct Common::Math::Quaternion /* Size=0x10 */
{
    /* 0x00 */ float X;
    /* 0x04 */ float Y;
    /* 0x08 */ float Z;
    /* 0x0C */ float W;
};

struct Common::Math::Rectangle /* Size=0x10 */
{
    /* 0x00 */ float Left;
    /* 0x04 */ float Top;
    /* 0x08 */ float Right;
    /* 0x0C */ float Bottom;
};

struct Common::Math::Vector2 /* Size=0x8 */
{
    /* 0x0 */ float X;
    /* 0x4 */ float Y;
};

struct Common::Math::Vector3 /* Size=0x10 */
{
    /* 0x00 */ float X;
    /* 0x04 */ float Y;
    /* 0x08 */ float Z;
    /*      */ byte _gap_0xC[0x4];
};

struct Common::Math::Vector4 /* Size=0x10 */
{
    /* 0x00 */ float X;
    /* 0x04 */ float Y;
    /* 0x08 */ float Z;
    /* 0x0C */ float W;
};

struct Common::Lua::lua_State /* Size=0xB0 */
{
    /*      */ byte _gap_0x0[0xB0];
};

struct Common::Lua::LuaState /* Size=0x28 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ Common::Lua::lua_State* State;
    /* 0x10 */ bool GCEnabled;
    /*      */ byte _gap_0x11;
    /*      */ byte _gap_0x12[0x2];
    /*      */ byte _gap_0x14[0x4];
    /* 0x18 */ __int64 LastGCRestart;
    /* 0x20 */ __int64 db_errorfb;
};

enum LuaType: __int32
{
    Nil = 0,
    Boolean = 1,
    LightUserData = 2,
    Number = 3,
    String = 4,
    Table = 5,
    Function = 6,
    UserData = 7,
    Thread = 8,
    Proto = 9,
    Upval = 10,
    None = -1
};

struct Common::Lua::LuaThread /* Size=0x28 */
{
    /* 0x00 */ Common::Lua::LuaState LuaState;
};

struct StdVector::SystemInt32 /* Size=0x18 */
{
    /* 0x00 */ __int32* First;
    /* 0x08 */ __int32* Last;
    /* 0x10 */ __int32* End;
};

struct StdVector::SystemByte /* Size=0x18 */
{
    /* 0x00 */ byte* First;
    /* 0x08 */ byte* Last;
    /* 0x10 */ byte* End;
};

struct Common::Log::LogModule /* Size=0x80 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ unsigned __int64 LocalPlayerContentId;
    /*      */ byte _gap_0x10[0x4];
    /* 0x14 */ __int32 LogMessageCount;
    /*      */ byte _gap_0x18[0x30];
    /* 0x48 */ StdVector::SystemInt32 LogMessageIndex;
    /* 0x60 */ StdVector::SystemByte LogMessageData;
    /*      */ byte _gap_0x78[0x8];
};

enum ConfigType: __int32
{
    Unused = 0,
    Category = 1,
    UInt = 2,
    Float = 3,
    String = 4
};

struct Common::Configuration::ConfigProperties::UIntProperties /* Size=0xC */
{
    /* 0x0 */ unsigned __int32 DefaultValue;
    /* 0x4 */ unsigned __int32 MinValue;
    /* 0x8 */ unsigned __int32 MaxValue;
};

struct Common::Configuration::ConfigProperties::FloatProperties /* Size=0xC */
{
    /* 0x0 */ float DefaultValue;
    /* 0x4 */ float MinValue;
    /* 0x8 */ float MaxValue;
};

struct Client::System::String::Utf8String /* Size=0x68 */
{
    /* 0x00 */ byte* StringPtr;
    /* 0x08 */ __int64 BufSize;
    /* 0x10 */ __int64 BufUsed;
    /* 0x18 */ __int64 StringLength;
    /* 0x20 */ byte IsEmpty;
    /* 0x21 */ byte IsUsingInlineBuffer;
    /* 0x22 */ byte InlineBuffer[0x40];
    /*      */ byte _gap_0x62[0x2];
    /*      */ byte _gap_0x64[0x4];
};

struct Common::Configuration::ConfigProperties::StringProperties /* Size=0x8 */
{
    /* 0x0 */ Client::System::String::Utf8String* DefaultValue;
};

struct Common::Configuration::ConfigProperties /* Size=0x10 */
{
    union {
    /* 0x00 */ Common::Configuration::ConfigProperties::UIntProperties UInt;
    /* 0x00 */ Common::Configuration::ConfigProperties::FloatProperties Float;
    /* 0x00 */ Common::Configuration::ConfigProperties::StringProperties String;
    } _union_0x0;
    /*      */ byte _gap_0x8[0x8];
};

struct Common::Configuration::ConfigValue /* Size=0x8 */
{
    union {
    /* 0x0 */ unsigned __int32 UInt;
    /* 0x0 */ float Float;
    /* 0x0 */ Client::System::String::Utf8String* String;
    } _union_0x0;
};

struct Common::Configuration::ChangeEventInterface /* Size=0x18 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ Common::Configuration::ChangeEventInterface* Next;
    /* 0x10 */ Common::Configuration::ConfigBase* Owner;
};

struct Common::Configuration::ConfigBase /* Size=0x110 */
{
    /* 0x000 */ void* vtbl;
    /* 0x008 */ Common::Configuration::ChangeEventInterface* Listener;
    /*       */ byte _gap_0x10[0x4];
    /* 0x014 */ unsigned __int32 ConfigCount;
    /* 0x018 */ Common::Configuration::ConfigEntry* ConfigEntry;
    /*       */ byte _gap_0x20[0x30];
    /* 0x050 */ Client::System::String::Utf8String UnkString;
    /*       */ byte _gap_0xB8[0x58];
};

struct Common::Configuration::ConfigEntry /* Size=0x38 */
{
    /* 0x00 */ Common::Configuration::ConfigProperties Properties;
    /* 0x10 */ byte* Name;
    /* 0x18 */ __int32 Type;
    /*      */ byte _gap_0x1C[0x4];
    /* 0x20 */ Common::Configuration::ConfigValue Value;
    /* 0x28 */ Common::Configuration::ConfigBase* Owner;
    /* 0x30 */ unsigned __int32 Index;
    /* 0x34 */ unsigned __int32 _Padding;
};

struct Common::Configuration::DevConfig /* Size=0x110 */
{
    /* 0x000 */ Common::Configuration::ConfigBase ConfigBase;
};

struct Common::Configuration::SystemConfig /* Size=0x450 */
{
    /* 0x000 */ Common::Configuration::ConfigBase ConfigBase;
    /*       */ byte _gap_0x110[0x8];
    /* 0x118 */ Common::Configuration::ConfigBase UiConfig;
    /* 0x228 */ Common::Configuration::ConfigBase UiControlConfig;
    /* 0x338 */ Common::Configuration::ConfigBase UiControlGamepadConfig;
    /*       */ byte _gap_0x448[0x8];
};

struct Common::Component::BGCollision::BGCollisionModule /* Size=0xC0 */
{
    /*      */ byte _gap_0x0[0xC0];
};

struct System::Numerics::Vector3 /* Size=0xC */
{
    /* 0x0 */ float X;
    /* 0x4 */ float Y;
    /* 0x8 */ float Z;
};

struct Common::Component::BGCollision::Object /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct Common::Component::BGCollision::RaycastHit /* Size=0x50 */
{
    /* 0x00 */ System::Numerics::Vector3 Point;
    /* 0x0C */ System::Numerics::Vector3 V1;
    /* 0x18 */ System::Numerics::Vector3 V2;
    /* 0x24 */ System::Numerics::Vector3 V3;
    /* 0x30 */ System::Numerics::Vector3 Unk30;
    /* 0x3C */ __int32 Flags;
    /* 0x40 */ __int32 Unk40;
    /* 0x44 */ float Distance;
    /* 0x48 */ Common::Component::BGCollision::Object* Object;
};

struct Component::Excel::ExcelModule::ExcelModuleVTable /* Size=0x20 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int64 GetSheetByIndex;
    /* 0x10 */ __int64 GetSheetByName;
    /* 0x18 */ __int64 LoadSheet;
};

struct Component::Excel::ExcelModule /* Size=0x818 */
{
    /* 0x000 */ Component::Excel::ExcelModule::ExcelModuleVTable* VTable;
    /*       */ byte _gap_0x8[0x810];
};

struct Component::Exd::ExdModule /* Size=0x28 */
{
    /*      */ byte _gap_0x0[0x20];
    /* 0x20 */ Component::Excel::ExcelModule* ExcelModule;
};

struct Component::Excel::ExcelModuleInterface::ExcelModuleInterfaceVTable /* Size=0x18 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int64 GetSheetByIndex;
    /* 0x10 */ __int64 GetSheetByName;
};

struct Component::Excel::ExcelModuleInterface /* Size=0x10 */
{
    /* 0x00 */ Component::Excel::ExcelModuleInterface::ExcelModuleInterfaceVTable* VTable;
    /* 0x08 */ Component::Exd::ExdModule* ExdModule;
};

struct Component::Excel::ExcelSheet /* Size=0x110 */
{
    union {
    /* 0x000 */ void* vtbl;
    /* 0x000 */ void** vfunc;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x8];
    /* 0x010 */ byte* SheetName;
    /*       */ byte _gap_0x18[0x8];
    /* 0x020 */ unsigned __int32 RowCount;
    /*       */ byte _gap_0x24[0x4];
    /*       */ byte _gap_0x28[0xE8];
};

struct Component::GUI::AtkEventInterface /* Size=0x8 */
{
    /* 0x0 */ void** vtbl;
};

struct Component::GUI::AgentInterface::AgentInterfaceVTable /* Size=0x48 */
{
    /* 0x00 */ __int64 ReceiveEvent;
    /*      */ byte _gap_0x8[0x10];
    /* 0x18 */ __int64 Show;
    /* 0x20 */ __int64 Hide;
    /* 0x28 */ __int64 IsAgentActive;
    /*      */ byte _gap_0x30[0x10];
    /* 0x40 */ __int64 GetAddonID;
};

struct Client::UI::UIModule::UIModuleVTable /* Size=0x670 */
{
    /*       */ byte _gap_0x0[0x28];
    /* 0x028 */ __int64 GetExcelModule;
    /* 0x030 */ __int64 GetRaptureTextModule;
    /* 0x038 */ __int64 GetRaptureAtkModule;
    /*       */ byte _gap_0x40[0x8];
    /* 0x048 */ __int64 GetRaptureShellModule;
    /* 0x050 */ __int64 GetPronounModule;
    /* 0x058 */ __int64 GetRaptureLogModule;
    /* 0x060 */ __int64 GetRaptureMacroModule;
    /* 0x068 */ __int64 GetRaptureHotbarModule;
    /* 0x070 */ __int64 GetRaptureGearsetModule;
    /* 0x078 */ __int64 GetAcquaintanceModule;
    /* 0x080 */ __int64 GetItemOrderModule;
    /* 0x088 */ __int64 GetItemFinderModule;
    /* 0x090 */ __int64 GetConfigModule;
    /* 0x098 */ __int64 GetAddonConfig;
    /* 0x0A0 */ __int64 GetUiSavePackModule;
    /* 0x0A8 */ __int64 GetLetterDataModule;
    /* 0x0B0 */ __int64 GetRetainerTaskDataModule;
    /* 0x0B8 */ __int64 GetFlagStatusModule;
    /*       */ byte _gap_0xC0[0x10];
    /* 0x0D0 */ __int64 GetRaptureUiDataModule;
    /*       */ byte _gap_0xD8[0x18];
    /* 0x0F0 */ __int64 GetRaptureTeleportHistory;
    /*       */ byte _gap_0xF8[0x8];
    /* 0x100 */ __int64 GetRecommendEquipModule;
    /*       */ byte _gap_0x108[0x8];
    /* 0x110 */ __int64 GetInfoModule;
    /*       */ byte _gap_0x118[0x8];
    /* 0x120 */ __int64 GetAgentModule;
    /*       */ byte _gap_0x128[0x8];
    /* 0x130 */ __int64 GetUI3DModule;
    /*       */ byte _gap_0x138[0x50];
    /* 0x188 */ __int64 GetFieldMarkerModule;
    /*       */ byte _gap_0x190[0x38];
    /* 0x1C8 */ __int64 GetRetainerCommentModule;
    /*       */ byte _gap_0x1D0[0x30];
    /* 0x200 */ __int64 GetUIInputData;
    /* 0x208 */ __int64 GetUIInputModule;
    /*       */ byte _gap_0x210[0x8];
    /* 0x218 */ __int64 GetLogFilterConfig;
    /*       */ byte _gap_0x220[0x38];
    /* 0x258 */ __int64 EnterGPose;
    /* 0x260 */ __int64 ExitGPose;
    /*       */ byte _gap_0x268[0x8];
    /* 0x270 */ __int64 EnterIdleCam;
    /* 0x278 */ __int64 ExitIdleCam;
    /*       */ byte _gap_0x280[0x1E8];
    /* 0x468 */ __int64 ToggleUi;
    /*       */ byte _gap_0x470[0x48];
    /* 0x4B8 */ __int64 ShowGoldSaucerReward;
    /* 0x4C0 */ __int64 HideGoldSaucerReward;
    /* 0x4C8 */ __int64 ShowTextRelicAtma;
    /*       */ byte _gap_0x4D0[0x30];
    /* 0x500 */ __int64 ShowHousingHarvest;
    /*       */ byte _gap_0x508[0x18];
    /* 0x520 */ __int64 ShowImage;
    /* 0x528 */ __int64 ShowText;
    /* 0x530 */ __int64 ShowTextChain;
    /* 0x538 */ __int64 ShowAreaText;
    /* 0x540 */ __int64 ShowPoisonText;
    /* 0x548 */ __int64 ShowErrorText;
    /* 0x550 */ __int64 ShowTextClassChange;
    /* 0x558 */ __int64 ShowGetAction;
    /* 0x560 */ __int64 ShowLocationTitle;
    /*       */ byte _gap_0x568[0x18];
    /* 0x580 */ __int64 ShowGrandCompany1;
    /*       */ byte _gap_0x588[0x10];
    /* 0x598 */ __int64 ShowStreak;
    /* 0x5A0 */ __int64 ShowAddonKillStreakForManeuvers;
    /* 0x5A8 */ __int64 ShowBalloonMessage;
    /* 0x5B0 */ __int64 ShowBattleTalk;
    /* 0x5B8 */ __int64 ShowBattleTalkImage;
    /*       */ byte _gap_0x5C0[0x8];
    /* 0x5C8 */ __int64 ShowBattleTalkSound;
    /*       */ byte _gap_0x5D0[0x20];
    /* 0x5F0 */ __int64 ExecuteMainCommand;
    /* 0x5F8 */ __int64 IsMainCommandUnlocked;
    /*       */ byte _gap_0x600[0x68];
    /* 0x668 */ __int64 Test205;
};

struct Client::UI::UIModule::Unk1 /* Size=0x8 */
{
    union {
    /* 0x0 */ void* vtbl;
    /* 0x0 */ void** vfunc;
    } _union_0x0;
};

struct Client::UI::UIModule::Unk2 /* Size=0x8 */
{
    union {
    /* 0x0 */ void* vtbl;
    /* 0x0 */ void** vfunc;
    } _union_0x0;
};

struct Client::UI::UIModule::Unk3 /* Size=0x8 */
{
    union {
    /* 0x0 */ void* vtbl;
    /* 0x0 */ void** vfunc;
    } _union_0x0;
};

struct Client::UI::UIModule /* Size=0xEB400 */
{
    union {
    /* 0x00000 */ void* vtbl;
    /* 0x00000 */ void** vfunc;
    /* 0x00000 */ Client::UI::UIModule::UIModuleVTable* VTable;
    } _union_0x0;
    /* 0x00008 */ Client::UI::UIModule::Unk1 UnkObj1;
    /* 0x00010 */ Client::UI::UIModule::Unk2 UnkObj2;
    /* 0x00018 */ Client::UI::UIModule::Unk3 UnkObj3;
    /* 0x00020 */ void* unk;
    /* 0x00028 */ void* SystemConfig;
    /*         */ byte _gap_0x30[0xEB3D0];
};

struct Component::GUI::AgentInterface /* Size=0x28 */
{
    union {
    /* 0x00 */ Component::GUI::AtkEventInterface AtkEventInterface;
    /* 0x00 */ Component::GUI::AgentInterface::AgentInterfaceVTable* VTable;
    } _union_0x0;
    /*      */ byte _gap_0x8[0x8];
    /* 0x10 */ Client::UI::UIModule* UiModule;
    /*      */ byte _gap_0x18[0x8];
    /* 0x20 */ unsigned __int32 AddonId;
    /*      */ byte _gap_0x24[0x4];
};

struct Component::GUI::AgentHudLayout /* Size=0x78 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /*      */ byte _gap_0x28[0x48];
    /* 0x70 */ bool NeedToSave;
    /*      */ byte _gap_0x71;
    /*      */ byte _gap_0x72[0x2];
    /*      */ byte _gap_0x74[0x4];
};

struct Component::GUI::AtkArrayData /* Size=0x20 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ __int32 Size;
    /*      */ byte _gap_0xC[0x4];
    /*      */ byte _gap_0x10[0x8];
    /*      */ byte _gap_0x18[0x4];
    /* 0x1C */ byte Unk1C;
    /* 0x1D */ byte Unk1D;
    /* 0x1E */ bool HasModifiedData;
    /* 0x1F */ byte Unk1F;
};

struct Component::GUI::NumberArrayData /* Size=0x28 */
{
    /* 0x00 */ Component::GUI::AtkArrayData AtkArrayData;
    /* 0x20 */ __int32* IntArray;
};

struct Component::GUI::StringArrayData /* Size=0x30 */
{
    /* 0x00 */ Component::GUI::AtkArrayData AtkArrayData;
    /* 0x20 */ byte** StringArray;
    /* 0x28 */ byte** ManagedStringArray;
};

struct Component::GUI::ExtendArrayData /* Size=0x28 */
{
    /* 0x00 */ Component::GUI::AtkArrayData AtkArrayData;
    /* 0x20 */ void** DataArray;
};

struct Component::GUI::AtkArrayDataHolder /* Size=0x50 */
{
    /* 0x00 */ __int16 NumberArrayCount;
    /* 0x02 */ __int16 StringArrayCount;
    /* 0x04 */ __int16 ExtendArrayCount;
    /*      */ byte _gap_0x6[0x2];
    /* 0x08 */ __int16* NumberArrayKeys;
    /* 0x10 */ Component::GUI::NumberArrayData** _NumberArrays;
    /* 0x18 */ Component::GUI::NumberArrayData** NumberArrays;
    /* 0x20 */ __int16* StringArrayKeys;
    /* 0x28 */ Component::GUI::StringArrayData** _StringArrays;
    /* 0x30 */ Component::GUI::StringArrayData** StringArrays;
    /* 0x38 */ __int16* ExtendArrayKeys;
    /* 0x40 */ Component::GUI::ExtendArrayData** _ExtendArrays;
    /* 0x48 */ Component::GUI::ExtendArrayData** ExtendArrays;
};

enum CollisionType: unsigned __int16
{
    Hit = 0,
    Focus = 1,
    Move = 2
};

struct Component::GUI::AtkEventTarget /* Size=0x8 */
{
    union {
    /* 0x0 */ void* vtbl;
    /* 0x0 */ void** vfunc;
    } _union_0x0;
};

struct Component::GUI::AtkResNode::AtkResNodeVTable /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int64 Destroy;
};

struct Component::GUI::AtkEventListener /* Size=0x8 */
{
    union {
    /* 0x0 */ void* vtbl;
    /* 0x0 */ void** vfunc;
    } _union_0x0;
};

enum AtkEventType: byte
{
    MouseDown = 3,
    MouseUp = 4,
    MouseMove = 5,
    MouseOver = 6,
    MouseOut = 7,
    MouseClick = 9,
    InputReceived = 12,
    FocusStart = 18,
    FocusStop = 19,
    ButtonPress = 23,
    ButtonRelease = 24,
    ButtonClick = 25,
    ListItemRollOver = 33,
    ListItemRollOut = 34,
    ListItemToggle = 35,
    DragDropRollOver = 52,
    DragDropRollOut = 53,
    DragDropUnk54 = 54,
    DragDropUnk55 = 55,
    IconTextRollOver = 56,
    IconTextRollOut = 57,
    IconTextClick = 58,
    WindowRollOver = 67,
    WindowRollOut = 68,
    WindowChangeScale = 69
};

struct Component::GUI::AtkEvent /* Size=0x31 */
{
    /* 0x00 */ Component::GUI::AtkResNode* Node;
    /* 0x08 */ Component::GUI::AtkEventTarget* Target;
    /* 0x10 */ Component::GUI::AtkEventListener* Listener;
    /* 0x18 */ unsigned __int32 Param;
    /*      */ byte _gap_0x1C[0x4];
    /* 0x20 */ Component::GUI::AtkEvent* NextEvent;
    /* 0x28 */ Component::GUI::AtkEventType Type;
    /* 0x29 */ byte Unk29;
    /*      */ byte _gap_0x2A[0x2];
    /*      */ byte _gap_0x2C[0x4];
    /* 0x30 */ byte Flags;
};

struct Component::GUI::AtkEventManager /* Size=0x8 */
{
    /* 0x0 */ Component::GUI::AtkEvent* Event;
};

enum NodeType: unsigned __int16
{
    Res = 1,
    Image = 2,
    Text = 3,
    NineGrid = 4,
    Counter = 5,
    Collision = 8
};

struct Client::Graphics::ByteColor /* Size=0x4 */
{
    /* 0x0 */ byte R;
    /* 0x1 */ byte G;
    /* 0x2 */ byte B;
    /* 0x3 */ byte A;
};

struct Component::GUI::AtkResNode /* Size=0xA8 */
{
    union {
    /* 0x00 */ Component::GUI::AtkEventTarget AtkEventTarget;
    /* 0x00 */ Component::GUI::AtkResNode::AtkResNodeVTable* VTable;
    } _union_0x0;
    /* 0x08 */ unsigned __int32 NodeID;
    /*      */ byte _gap_0xC[0x4];
    /* 0x10 */ void* TimelineObject;
    /* 0x18 */ Component::GUI::AtkEventManager AtkEventManager;
    /* 0x20 */ Component::GUI::AtkResNode* ParentNode;
    /* 0x28 */ Component::GUI::AtkResNode* PrevSiblingNode;
    /* 0x30 */ Component::GUI::AtkResNode* NextSiblingNode;
    /* 0x38 */ Component::GUI::AtkResNode* ChildNode;
    /* 0x40 */ Component::GUI::NodeType Type;
    /* 0x42 */ unsigned __int16 ChildCount;
    /* 0x44 */ float X;
    /* 0x48 */ float Y;
    /* 0x4C */ float ScaleX;
    /* 0x50 */ float ScaleY;
    /* 0x54 */ float Rotation;
    /* 0x58 */ Common::Math::Matrix2x2 Transform;
    /* 0x68 */ float ScreenX;
    /* 0x6C */ float ScreenY;
    /* 0x70 */ Client::Graphics::ByteColor Color;
    /* 0x74 */ float Depth;
    /* 0x78 */ float Depth_2;
    /* 0x7C */ unsigned __int16 AddRed;
    /* 0x7E */ unsigned __int16 AddGreen;
    /* 0x80 */ unsigned __int16 AddBlue;
    /* 0x82 */ unsigned __int16 AddRed_2;
    /* 0x84 */ unsigned __int16 AddGreen_2;
    /* 0x86 */ unsigned __int16 AddBlue_2;
    /* 0x88 */ byte MultiplyRed;
    /* 0x89 */ byte MultiplyGreen;
    /* 0x8A */ byte MultiplyBlue;
    /* 0x8B */ byte MultiplyRed_2;
    /* 0x8C */ byte MultiplyGreen_2;
    /* 0x8D */ byte MultiplyBlue_2;
    /* 0x8E */ byte Alpha_2;
    /* 0x8F */ byte UnkByte_1;
    /* 0x90 */ unsigned __int16 Width;
    /* 0x92 */ unsigned __int16 Height;
    /* 0x94 */ float OriginX;
    /* 0x98 */ float OriginY;
    /* 0x9C */ unsigned __int16 Priority;
    /* 0x9E */ __int16 Flags;
    union {
    /* 0xA0 */ unsigned __int32 Flags_2;
    /* 0xA0 */ unsigned __int32 DrawFlags;
    } _union_0xA0;
};

struct Component::GUI::AtkComponentBase::AtkComponentBaseVTable /* Size=0x58 */
{
    /*      */ byte _gap_0x0[0x50];
    /* 0x50 */ __int64 SetEnabledState;
};

struct Component::GUI::AtkTexture::AtkTextureVTable /* Size=0x8 */
{
    /* 0x0 */ __int64 Destroy;
};

enum ResourceCategory: __int32
{
    Common = 0,
    BgCommon = 1,
    Bg = 2,
    Cut = 3,
    Chara = 4,
    Shader = 5,
    Ui = 6,
    Sound = 7,
    Vfx = 8,
    UiScript = 9,
    Exd = 10,
    GameScript = 11,
    Music = 12,
    SqpackTest = 18,
    Debug = 19,
    MaxCount = 20
};

struct StdString /* Size=0x20 */
{
    union {
    /* 0x00 */ byte* BufferPtr;
    /* 0x00 */ byte Buffer[0x10];
    } _union_0x0;
    /*      */ byte _gap_0x8[0x8];
    /* 0x10 */ unsigned __int64 Length;
    /* 0x18 */ unsigned __int64 Capacity;
};

struct Client::System::Resource::Handle::ResourceHandle /* Size=0xB0 */
{
    union {
    /* 0x00 */ void* vtbl;
    /* 0x00 */ void** vfunc;
    } _union_0x0;
    /* 0x08 */ Client::System::Resource::ResourceCategory Category;
    /* 0x0C */ unsigned __int32 FileType;
    /* 0x10 */ unsigned __int32 Id;
    /*      */ byte _gap_0x14[0x4];
    /*      */ byte _gap_0x18[0x10];
    /* 0x28 */ unsigned __int32 FileSize;
    /* 0x2C */ unsigned __int32 FileSize2;
    /*      */ byte _gap_0x30[0x4];
    /* 0x34 */ unsigned __int32 FileSize3;
    /*      */ byte _gap_0x38[0x10];
    /* 0x48 */ StdString FileName;
    /*      */ byte _gap_0x68[0x40];
    /*      */ byte _gap_0xA8[0x4];
    /* 0xAC */ unsigned __int32 RefCount;
};

struct Client::System::Resource::Handle::TextureResourceHandle /* Size=0x140 */
{
    /* 0x000 */ Client::System::Resource::Handle::ResourceHandle ResourceHandle;
    /*       */ byte _gap_0xB0[0x90];
};

struct Client::Graphics::Render::Notifier /* Size=0x18 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ Client::Graphics::Render::Notifier* Next;
    /* 0x10 */ Client::Graphics::Render::Notifier* Prev;
};

enum TextureFormat: unsigned __int32
{
    R8G8B8A8 = 5200,
    D24S8 = 16976
};

struct Client::Graphics::Render::Texture /* Size=0xC0 */
{
    /* 0x00 */ void* vtbl;
    /*      */ byte _gap_0x8[0x18];
    /* 0x20 */ Client::Graphics::Render::Notifier Notifier;
    /* 0x38 */ unsigned __int32 Width;
    /* 0x3C */ unsigned __int32 Height;
    /* 0x40 */ unsigned __int32 Width2;
    /* 0x44 */ unsigned __int32 Height2;
    /* 0x48 */ unsigned __int32 Width3;
    /* 0x4C */ unsigned __int32 Height3;
    /* 0x50 */ unsigned __int32 Depth;
    /* 0x54 */ byte MipLevel;
    /* 0x55 */ byte Unk_55;
    /* 0x56 */ byte Unk_56;
    /* 0x57 */ byte Unk_57;
    /* 0x58 */ Client::Graphics::Render::TextureFormat TextureFormat;
    /* 0x5C */ unsigned __int32 Flags;
    /* 0x60 */ byte Unk_60;
    /*      */ byte _gap_0x61;
    /*      */ byte _gap_0x62[0x2];
    /*      */ byte _gap_0x64[0x4];
    /* 0x68 */ void* D3D11Texture2D;
    /* 0x70 */ void* D3D11ShaderResourceView;
    /*      */ byte _gap_0x78[0x48];
};

struct Component::GUI::AtkTextureResource /* Size=0x20 */
{
    /* 0x00 */ unsigned __int32 TexPathHash;
    /* 0x04 */ __int32 IconID;
    /* 0x08 */ Client::System::Resource::Handle::TextureResourceHandle* TexFileResourceHandle;
    /* 0x10 */ Client::Graphics::Render::Texture* KernelTextureObject;
    /* 0x18 */ unsigned __int16 Count_1;
    /* 0x1A */ byte Count_2;
    /*      */ byte _gap_0x1B;
    /*      */ byte _gap_0x1C[0x4];
};

enum TextureType: byte
{
    Resource = 1,
    Crest = 2,
    KernelTexture = 3
};

struct Component::GUI::AtkTexture /* Size=0x18 */
{
    union {
    /* 0x00 */ void* vtbl;
    /* 0x00 */ Component::GUI::AtkTexture::AtkTextureVTable* VTable;
    } _union_0x0;
    union {
    /* 0x08 */ Component::GUI::AtkTextureResource* Resource;
    /* 0x08 */ void* Crest;
    /* 0x08 */ Client::Graphics::Render::Texture* KernelTexture;
    } _union_0x8;
    /* 0x10 */ Component::GUI::TextureType TextureType;
    /* 0x11 */ byte UnkBool_2;
    /*      */ byte _gap_0x12[0x2];
    /*      */ byte _gap_0x14[0x4];
};

struct Component::GUI::AtkUldAsset /* Size=0x20 */
{
    /* 0x00 */ unsigned __int32 Id;
    /*      */ byte _gap_0x4[0x4];
    /* 0x08 */ Component::GUI::AtkTexture AtkTexture;
};

struct Component::GUI::AtkUldPart /* Size=0x10 */
{
    /* 0x00 */ Component::GUI::AtkUldAsset* UldAsset;
    /* 0x08 */ unsigned __int16 U;
    /* 0x0A */ unsigned __int16 V;
    /* 0x0C */ unsigned __int16 Width;
    /* 0x0E */ unsigned __int16 Height;
};

struct Component::GUI::AtkUldPartsList /* Size=0x10 */
{
    /* 0x00 */ unsigned __int32 Id;
    /* 0x04 */ unsigned __int32 PartCount;
    /* 0x08 */ Component::GUI::AtkUldPart* Parts;
};

struct Component::GUI::AtkUldObjectInfo /* Size=0x10 */
{
    /* 0x00 */ unsigned __int32 Id;
    /* 0x04 */ __int32 NodeCount;
    /* 0x08 */ Component::GUI::AtkResNode** NodeList;
};

struct Component::GUI::AtkUldComponentDataBase /* Size=0x9 */
{
    /* 0x0 */ byte Index;
    /* 0x1 */ byte Up;
    /* 0x2 */ byte Down;
    /* 0x3 */ byte Left;
    /* 0x4 */ byte Right;
    /* 0x5 */ byte Cursor;
    /* 0x6 */ byte OffsetX;
    /* 0x7 */ byte OffsetY;
    /* 0x8 */ byte Unk;
};

struct Component::GUI::AtkUldManager::DuplicateNodeInfo /* Size=0x8 */
{
    /* 0x0 */ unsigned __int32 NodeId;
    /* 0x4 */ unsigned __int32 Count;
};

struct Component::GUI::AtkTimelineManager /* Size=0x58 */
{
    /*      */ byte _gap_0x0[0x58];
};

struct Pointer::ComponentGUIAtkUldManagerDuplicateObjectList /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct Component::GUI::AtkLinkedList::Node::PointerComponentGUIAtkUldManagerDuplicateObjectList /* Size=0x18 */
{
    /* 0x00 */ Pointer::ComponentGUIAtkUldManagerDuplicateObjectList Value;
    /* 0x08 */ Component::GUI::AtkLinkedList::Node::PointerComponentGUIAtkUldManagerDuplicateObjectList* Next;
    /* 0x10 */ Component::GUI::AtkLinkedList::Node::PointerComponentGUIAtkUldManagerDuplicateObjectList* Previous;
};

struct Component::GUI::AtkLinkedList::PointerComponentGUIAtkUldManagerDuplicateObjectList /* Size=0x18 */
{
    /* 0x00 */ Component::GUI::AtkLinkedList::Node::PointerComponentGUIAtkUldManagerDuplicateObjectList* End;
    /* 0x08 */ Component::GUI::AtkLinkedList::Node::PointerComponentGUIAtkUldManagerDuplicateObjectList* Start;
    /* 0x10 */ unsigned __int32 Count;
    /*      */ byte _gap_0x14[0x4];
};

enum AtkLoadState: byte
{
    Unloaded = 0,
    ResourceLoading = 1,
    TexturesLoading = 2,
    Loaded = 3,
    LoadError = 4
};

struct Component::GUI::AtkUldManager /* Size=0x90 */
{
    /* 0x00 */ Component::GUI::AtkUldAsset* Assets;
    /* 0x08 */ Component::GUI::AtkUldPartsList* PartsList;
    /* 0x10 */ Component::GUI::AtkUldObjectInfo* Objects;
    /* 0x18 */ Component::GUI::AtkUldComponentDataBase* ComponentData;
    /* 0x20 */ unsigned __int16 AssetCount;
    /* 0x22 */ unsigned __int16 PartsListCount;
    /* 0x24 */ unsigned __int16 ObjectCount;
    /* 0x26 */ unsigned __int16 DuplicateObjectCount;
    /* 0x28 */ Client::System::Resource::Handle::ResourceHandle* UldResourceHandle;
    /* 0x30 */ Component::GUI::AtkUldManager::DuplicateNodeInfo* DuplicateNodeInfoList;
    /* 0x38 */ Component::GUI::AtkTimelineManager* TimelineManager;
    /* 0x40 */ unsigned __int16 Unk40;
    /* 0x42 */ unsigned __int16 NodeListCount;
    /*      */ byte _gap_0x44[0x4];
    /* 0x48 */ void* AtkResourceRendererManager;
    /* 0x50 */ Component::GUI::AtkResNode** NodeList;
    /* 0x58 */ Component::GUI::AtkLinkedList::PointerComponentGUIAtkUldManagerDuplicateObjectList DuplicateObjects;
    /*      */ byte _gap_0x70[0x8];
    /* 0x78 */ Component::GUI::AtkResNode* RootNode;
    /* 0x80 */ unsigned __int16 RootNodeWidth;
    /* 0x82 */ unsigned __int16 RootNodeHeight;
    /* 0x84 */ unsigned __int16 NodeListSize;
    /* 0x86 */ byte Flags1;
    /*      */ byte _gap_0x87;
    /*      */ byte _gap_0x88;
    /* 0x89 */ Component::GUI::AtkLoadState LoadedState;
    /*      */ byte _gap_0x8A[0x2];
    /*      */ byte _gap_0x8C[0x4];
};

struct Component::GUI::AtkComponentNode /* Size=0xB0 */
{
    /* 0x00 */ Component::GUI::AtkResNode AtkResNode;
    /* 0xA8 */ Component::GUI::AtkComponentBase* Component;
};

struct Component::GUI::AtkComponentBase /* Size=0xC0 */
{
    union {
    /* 0x00 */ Component::GUI::AtkEventListener AtkEventListener;
    /* 0x00 */ Component::GUI::AtkComponentBase::AtkComponentBaseVTable* VTable;
    } _union_0x0;
    /* 0x08 */ Component::GUI::AtkUldManager UldManager;
    /*      */ byte _gap_0x98[0x8];
    /* 0xA0 */ Component::GUI::AtkResNode* AtkResNode;
    /* 0xA8 */ Component::GUI::AtkComponentNode* OwnerNode;
    /*      */ byte _gap_0xB0[0x10];
};

struct Component::GUI::AtkCollisionNode /* Size=0xB8 */
{
    /* 0x00 */ Component::GUI::AtkResNode AtkResNode;
    /* 0xA8 */ unsigned __int16 CollisionType;
    /* 0xAA */ unsigned __int16 Uses;
    /*      */ byte _gap_0xAC[0x4];
    /* 0xB0 */ Component::GUI::AtkComponentBase* LinkedComponent;
};

enum ComponentType: byte
{
    Base = 0,
    Button = 1,
    Window = 2,
    CheckBox = 3,
    RadioButton = 4,
    GaugeBar = 5,
    Slider = 6,
    TextInput = 7,
    NumericInput = 8,
    List = 9,
    DropDownList = 10,
    Tab = 11,
    TreeList = 12,
    ScrollBar = 13,
    ListItemRenderer = 14,
    Icon = 15,
    IconText = 16,
    DragDrop = 17,
    GuildLeveCard = 18,
    TextNineGrid = 19,
    JournalCanvas = 20,
    Multipurpose = 21,
    Map = 22,
    Preview = 23,
    HoldButton = 24
};

struct Component::GUI::AtkTextNode /* Size=0x158 */
{
    /* 0x000 */ Component::GUI::AtkResNode AtkResNode;
    /* 0x0A8 */ unsigned __int32 TextId;
    /* 0x0AC */ Client::Graphics::ByteColor TextColor;
    /* 0x0B0 */ Client::Graphics::ByteColor EdgeColor;
    /* 0x0B4 */ Client::Graphics::ByteColor BackgroundColor;
    /* 0x0B8 */ Client::System::String::Utf8String NodeText;
    /*       */ byte _gap_0x120[0x8];
    /* 0x128 */ void* UnkPtr_1;
    /*       */ byte _gap_0x130[0x8];
    /* 0x138 */ unsigned __int32 SelectStart;
    /* 0x13C */ unsigned __int32 SelectEnd;
    /*       */ byte _gap_0x140[0x8];
    /*       */ byte _gap_0x148[0x2];
    /* 0x14A */ byte LineSpacing;
    /* 0x14B */ byte CharSpacing;
    /* 0x14C */ byte AlignmentFontType;
    /* 0x14D */ byte FontSize;
    /* 0x14E */ byte SheetType;
    /*       */ byte _gap_0x14F;
    /* 0x150 */ unsigned __int16 FontCacheHandle;
    /* 0x152 */ byte TextFlags;
    /* 0x153 */ byte TextFlags2;
    /*       */ byte _gap_0x154[0x4];
};

struct Component::GUI::AtkComponentButton /* Size=0xF0 */
{
    /* 0x00 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /* 0xC0 */ __int16 Left;
    /* 0xC2 */ __int16 Top;
    /* 0xC4 */ __int16 Right;
    /* 0xC6 */ __int16 Bottom;
    /* 0xC8 */ Component::GUI::AtkTextNode* ButtonTextNode;
    /* 0xD0 */ Component::GUI::AtkResNode* ButtonBGNode;
    /*      */ byte _gap_0xD8[0x10];
    /* 0xE8 */ unsigned __int32 Flags;
    /*      */ byte _gap_0xEC[0x4];
};

struct Component::GUI::AtkComponentCheckBox /* Size=0x110 */
{
    /* 0x000 */ Component::GUI::AtkComponentButton AtkComponentButton;
    /*       */ byte _gap_0xF0[0x20];
};

struct Component::GUI::AtkImageNode /* Size=0xB8 */
{
    /* 0x00 */ Component::GUI::AtkResNode AtkResNode;
    /* 0xA8 */ Component::GUI::AtkUldPartsList* PartsList;
    /* 0xB0 */ unsigned __int16 PartId;
    /* 0xB2 */ byte WrapMode;
    /* 0xB3 */ byte Flags;
    /*      */ byte _gap_0xB4[0x4];
};

enum IconComponentFlags: unsigned __int32
{
    None = 0,
    DyeIcon = 8,
    Macro = 16,
    GlamourIcon = 32,
    Moving = 256,
    Casting = 1024,
    InventoryItem = 2048
};

struct Component::GUI::AtkComponentIcon /* Size=0x118 */
{
    /* 0x000 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /* 0x0C0 */ __int64 IconId;
    /* 0x0C8 */ Component::GUI::AtkUldAsset* Texture;
    /* 0x0D0 */ Component::GUI::AtkResNode* IconAdditionsContainer;
    /* 0x0D8 */ Component::GUI::AtkResNode* ComboBorder;
    /* 0x0E0 */ Component::GUI::AtkResNode* Frame;
    /* 0x0E8 */ __int64 Unknown0E8;
    /* 0x0F0 */ Component::GUI::AtkImageNode* IconImage;
    /* 0x0F8 */ Component::GUI::AtkImageNode* FrameIcon;
    /* 0x100 */ Component::GUI::AtkImageNode* UnknownImageNode;
    /* 0x108 */ Component::GUI::AtkTextNode* QuantityText;
    /*       */ byte _gap_0x110[0x4];
    /* 0x114 */ Component::GUI::IconComponentFlags Flags;
};

struct Component::GUI::AtkComponentDragDrop /* Size=0x110 */
{
    /* 0x000 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*       */ byte _gap_0xC0[0x38];
    /* 0x0F8 */ Component::GUI::AtkComponentIcon* AtkComponentIcon;
    /*       */ byte _gap_0x100[0x10];
};

struct Component::GUI::AtkComponentDropDownList /* Size=0x224 */
{
    /* 0x000 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*       */ byte _gap_0xC0[0x160];
    /*       */ byte _gap_0x220[0x4];
};

struct Component::GUI::AtkComponentGaugeBar /* Size=0x1A8 */
{
    /* 0x000 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*       */ byte _gap_0xC0[0xE8];
};

struct Component::GUI::AtkComponentGuildLeveCard /* Size=0xF0 */
{
    /* 0x00 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*      */ byte _gap_0xC0[0x30];
};

struct Component::GUI::AtkComponentHoldButton /* Size=0x120 */
{
    /* 0x000 */ Component::GUI::AtkComponentButton AtkComponentButton;
    /*       */ byte _gap_0xF0[0x30];
};

struct Component::GUI::AtkComponentIconText /* Size=0xE8 */
{
    /* 0x00 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*      */ byte _gap_0xC0[0x28];
};

struct Component::GUI::AtkComponentInputBase /* Size=0x1B0 */
{
    /* 0x000 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*       */ byte _gap_0xC0[0x8];
    /* 0x0C8 */ Component::GUI::AtkTextNode* AtkTextNode;
    /*       */ byte _gap_0xD0[0x10];
    /* 0x0E0 */ Client::System::String::Utf8String UnkText1;
    /* 0x148 */ Client::System::String::Utf8String UnkText2;
};

struct Component::GUI::AtkComponentJournalCanvas /* Size=0x520 */
{
    /* 0x000 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*       */ byte _gap_0xC0[0x460];
};

struct Component::GUI::AtkComponentListItemRenderer /* Size=0x1A8 */
{
    /* 0x000 */ Component::GUI::AtkComponentButton AtkComponentButton;
    /*       */ byte _gap_0xF0[0x90];
    /*       */ byte _gap_0x180[0x4];
    /* 0x184 */ __int32 ListItemIndex;
    /*       */ byte _gap_0x188[0x20];
};

struct Component::GUI::AtkComponentScrollBar /* Size=0x140 */
{
    /* 0x000 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*       */ byte _gap_0xC0[0x80];
};

struct Component::GUI::AtkComponentList::ListItem /* Size=0x18 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ Component::GUI::AtkComponentListItemRenderer* AtkComponentListItemRenderer;
    /*      */ byte _gap_0x10[0x8];
};

struct Component::GUI::AtkComponentList /* Size=0x1A8 */
{
    /* 0x000 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /* 0x0C0 */ Component::GUI::AtkComponentListItemRenderer* FirstAtkComponentListItemRenderer;
    /* 0x0C8 */ Component::GUI::AtkComponentScrollBar* AtkComponentScrollBarC8;
    /*       */ byte _gap_0xD0[0x20];
    /* 0x0F0 */ Component::GUI::AtkComponentList::ListItem* ItemRendererList;
    /*       */ byte _gap_0xF8[0x20];
    /* 0x118 */ __int32 ListLength;
    /*       */ byte _gap_0x11C[0x4];
    /*       */ byte _gap_0x120[0x8];
    /*       */ byte _gap_0x128[0x4];
    /* 0x12C */ __int32 SelectedItemIndex;
    /* 0x130 */ __int32 HeldItemIndex;
    /* 0x134 */ __int32 HoveredItemIndex;
    /*       */ byte _gap_0x138[0x10];
    /* 0x148 */ Component::GUI::AtkCollisionNode* HoveredItemCollisionNode;
    /* 0x150 */ __int32 HoveredItemIndex2;
    /*       */ byte _gap_0x154[0x4];
    /* 0x158 */ __int32 HoveredItemIndex3;
    /*       */ byte _gap_0x15C[0x4];
    /*       */ byte _gap_0x160[0x48];
};

struct Component::GUI::AtkUldComponentDataInputBase /* Size=0x10 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ Client::Graphics::ByteColor FocusColor;
};

struct Component::GUI::AtkUldComponentDataNumericInput /* Size=0x3C */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataInputBase InputBase;
    /* 0x10 */ unsigned __int32 Nodes[0x5];
    /* 0x24 */ __int32 Value;
    /* 0x28 */ __int32 Min;
    /* 0x2C */ __int32 Max;
    /* 0x30 */ __int32 Add;
    /* 0x34 */ unsigned __int32 EndLetterId;
    /* 0x38 */ byte Comma;
    /*      */ byte _gap_0x39;
    /*      */ byte _gap_0x3A[0x2];
};

struct Component::GUI::AtkComponentNumericInput /* Size=0x338 */
{
    /* 0x000 */ Component::GUI::AtkComponentInputBase AtkComponentInputBase;
    /*       */ byte _gap_0x1B0[0x148];
    /* 0x2F8 */ Component::GUI::AtkUldComponentDataNumericInput Data;
    /*       */ byte _gap_0x334[0x4];
};

struct Component::GUI::AtkComponentRadioButton /* Size=0xF8 */
{
    /* 0x00 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*      */ byte _gap_0xC0[0x38];
};

struct Component::GUI::AtkComponentSlider /* Size=0x100 */
{
    /* 0x000 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*       */ byte _gap_0xC0[0x40];
};

struct Component::GUI::AtkComponentTextInput /* Size=0x600 */
{
    /* 0x000 */ Component::GUI::AtkComponentInputBase AtkComponentInputBase;
    /*       */ byte _gap_0x1B0[0xD0];
    /* 0x280 */ Client::System::String::Utf8String UnkText1;
    /* 0x2E8 */ Client::System::String::Utf8String UnkText2;
    /* 0x350 */ Client::System::String::Utf8String UnkText3;
    /*       */ byte _gap_0x3B8[0x98];
    /* 0x450 */ Client::System::String::Utf8String UnkText4;
    /* 0x4B8 */ Client::System::String::Utf8String UnkText5;
    /*       */ byte _gap_0x520[0xE0];
};

struct Component::GUI::AtkComponentTextNineGrid /* Size=0xD8 */
{
    /* 0x00 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*      */ byte _gap_0xC0[0x18];
};

struct Component::GUI::AtkComponentTreeList /* Size=0x228 */
{
    /* 0x000 */ Component::GUI::AtkComponentList AtkComponentList;
    /*       */ byte _gap_0x1A8[0x80];
};

struct Component::GUI::AtkComponentWindow /* Size=0x108 */
{
    /* 0x000 */ Component::GUI::AtkComponentBase AtkComponentBase;
    /*       */ byte _gap_0xC0[0x48];
};

struct Component::GUI::AtkCounterNode /* Size=0x128 */
{
    /* 0x000 */ Component::GUI::AtkResNode AtkResNode;
    /* 0x0A8 */ Component::GUI::AtkUldPartsList* PartsList;
    /* 0x0B0 */ unsigned __int32 PartId;
    /* 0x0B4 */ byte NumberWidth;
    /* 0x0B5 */ byte CommaWidth;
    /* 0x0B6 */ byte SpaceWidth;
    /*       */ byte _gap_0xB7;
    /* 0x0B8 */ unsigned __int16 TextAlign;
    /*       */ byte _gap_0xBA[0x2];
    /* 0x0BC */ float Width;
    /* 0x0C0 */ Client::System::String::Utf8String NodeText;
};

enum CursorType: byte
{
    Arrow = 0,
    Boot = 1,
    Search = 2,
    ChatPointer = 3,
    Interact = 4,
    Attack = 5,
    Hand = 6,
    ResizeWE = 7,
    ResizeNS = 8,
    ResizeNWSR = 9,
    ResizeNESW = 10,
    Clickable = 11,
    TextInput = 12,
    TextClick = 13,
    Grab = 14,
    ChatBubble = 15,
    NoAccess = 16,
    Hidden = 17
};

struct Component::GUI::AtkCursor /* Size=0x10 */
{
    /* 0x00 */ Component::GUI::AtkCursor::CursorType Type;
    /*      */ byte _gap_0x1;
    /*      */ byte _gap_0x2[0x2];
    /*      */ byte _gap_0x4[0x4];
    /*      */ byte _gap_0x8[0x4];
    /*      */ byte _gap_0xC[0x2];
    /* 0x0E */ byte Visible;
    /*      */ byte _gap_0xF;
};

struct Component::GUI::AtkUnitBase::AtkUnitBaseVTable /* Size=0x190 */
{
    /*       */ byte _gap_0x0[0x18];
    /* 0x018 */ __int64 Open;
    /* 0x020 */ __int64 Close;
    /* 0x028 */ __int64 Show;
    /* 0x030 */ __int64 Hide;
    /* 0x038 */ __int64 SetPosition;
    /*       */ byte _gap_0x40[0x138];
    /* 0x178 */ __int64 OnSetup;
    /*       */ byte _gap_0x180[0x8];
    /* 0x188 */ __int64 OnUpdate;
};

enum ValueType: __int32
{
    Bool = 2,
    Int = 3,
    UInt = 4,
    Float = 5,
    String = 6,
    String8 = 8,
    Vector = 9,
    Texture = 10,
    AllocatedString = 38,
    AllocatedVector = 41
};

struct StdVector::ComponentGUIAtkValue /* Size=0x18 */
{
    /* 0x00 */ Component::GUI::AtkValue* First;
    /* 0x08 */ Component::GUI::AtkValue* Last;
    /* 0x10 */ Component::GUI::AtkValue* End;
};

struct Component::GUI::AtkValue /* Size=0x10 */
{
    /* 0x00 */ Component::GUI::ValueType Type;
    union {
    /* 0x04 */ __int32 Int;
    /* 0x04 */ unsigned __int32 UInt;
    /* 0x04 */ byte* String;
    /* 0x04 */ float Float;
    /* 0x04 */ byte Byte;
    /* 0x04 */ StdVector::ComponentGUIAtkValue* Vector;
    /* 0x04 */ Client::Graphics::Render::Texture* Texture;
    } _union_0x8;
    /*      */ byte _gap_0xC[0x4];
};

struct Component::GUI::AtkUnitBase /* Size=0x220 */
{
    union {
    /* 0x000 */ Component::GUI::AtkEventListener AtkEventListener;
    /* 0x000 */ Component::GUI::AtkUnitBase::AtkUnitBaseVTable* VTable;
    } _union_0x0;
    /* 0x008 */ byte Name[0x20];
    /* 0x028 */ Component::GUI::AtkUldManager UldManager;
    /*       */ byte _gap_0xB8[0x10];
    /* 0x0C8 */ Component::GUI::AtkResNode* RootNode;
    /* 0x0D0 */ Component::GUI::AtkCollisionNode* WindowCollisionNode;
    /* 0x0D8 */ Component::GUI::AtkCollisionNode* WindowHeaderCollisionNode;
    /* 0x0E0 */ Component::GUI::AtkResNode* CursorTarget;
    /*       */ byte _gap_0xE8[0x20];
    /* 0x108 */ Component::GUI::AtkComponentNode* WindowNode;
    /*       */ byte _gap_0x110[0x50];
    /* 0x160 */ Component::GUI::AtkValue* AtkValues;
    /*       */ byte _gap_0x168[0x18];
    /*       */ byte _gap_0x180[0x2];
    /* 0x182 */ byte Flags;
    /*       */ byte _gap_0x183;
    /*       */ byte _gap_0x184[0x4];
    /*       */ byte _gap_0x188[0x20];
    /*       */ byte _gap_0x1A8[0x4];
    /* 0x1AC */ float Scale;
    /*       */ byte _gap_0x1B0[0x4];
    /*       */ byte _gap_0x1B4[0x2];
    /* 0x1B6 */ byte VisibilityFlags;
    /*       */ byte _gap_0x1B7;
    /*       */ byte _gap_0x1B8[0x4];
    /* 0x1BC */ __int16 X;
    /* 0x1BE */ __int16 Y;
    /*       */ byte _gap_0x1C0[0x8];
    /*       */ byte _gap_0x1C8[0x2];
    /* 0x1CA */ unsigned __int16 AtkValuesCount;
    /* 0x1CC */ unsigned __int16 ID;
    /* 0x1CE */ unsigned __int16 ParentID;
    /* 0x1D0 */ unsigned __int16 UnknownID;
    /* 0x1D2 */ unsigned __int16 ContextMenuParentID;
    /*       */ byte _gap_0x1D4;
    /* 0x1D5 */ byte Alpha;
    /*       */ byte _gap_0x1D6[0x2];
    /* 0x1D8 */ Component::GUI::AtkResNode** CollisionNodeList;
    /* 0x1E0 */ unsigned __int32 CollisionNodeListCount;
    /*       */ byte _gap_0x1E4[0x4];
    /*       */ byte _gap_0x1E8[0x38];
};

struct Component::GUI::AtkUnitList /* Size=0x810 */
{
    /* 0x000 */ void* vtbl;
    /* 0x008 */ Component::GUI::AtkUnitBase* AtkUnitEntries;
    /*       */ byte _gap_0x10[0x7F8];
    /* 0x808 */ unsigned __int32 Count;
    /*       */ byte _gap_0x80C[0x4];
};

struct Component::GUI::AtkUnitManager /* Size=0x9C88 */
{
    /* 0x0000 */ Component::GUI::AtkEventListener AtkEventListener;
    /*        */ byte _gap_0x8[0x28];
    /* 0x0030 */ Component::GUI::AtkUnitList DepthLayerOneList;
    /* 0x0840 */ Component::GUI::AtkUnitList DepthLayerTwoList;
    /* 0x1050 */ Component::GUI::AtkUnitList DepthLayerThreeList;
    /* 0x1860 */ Component::GUI::AtkUnitList DepthLayerFourList;
    /* 0x2070 */ Component::GUI::AtkUnitList DepthLayerFiveList;
    /* 0x2880 */ Component::GUI::AtkUnitList DepthLayerSixList;
    /* 0x3090 */ Component::GUI::AtkUnitList DepthLayerSevenList;
    /* 0x38A0 */ Component::GUI::AtkUnitList DepthLayerEightList;
    /* 0x40B0 */ Component::GUI::AtkUnitList DepthLayerNineList;
    /* 0x48C0 */ Component::GUI::AtkUnitList DepthLayerTenList;
    /* 0x50D0 */ Component::GUI::AtkUnitList DepthLayerElevenList;
    /* 0x58E0 */ Component::GUI::AtkUnitList DepthLayerTwelveList;
    /* 0x60F0 */ Component::GUI::AtkUnitList DepthLayerThirteenList;
    /* 0x6900 */ Component::GUI::AtkUnitList AllLoadedUnitsList;
    /* 0x7110 */ Component::GUI::AtkUnitList FocusedUnitsList;
    /* 0x7920 */ Component::GUI::AtkUnitList UnitList16;
    /* 0x8130 */ Component::GUI::AtkUnitList UnitList17;
    /* 0x8940 */ Component::GUI::AtkUnitList UnitList18;
    /*        */ byte _gap_0x9150[0xB38];
};

struct Client::UI::RaptureAtkUnitManager /* Size=0x9D10 */
{
    /* 0x0000 */ Component::GUI::AtkUnitManager AtkUnitManager;
    /*        */ byte _gap_0x9C88[0x88];
};

struct Pointer::ComponentGUIAtkResNode /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct Pointer::ComponentGUIAtkTooltipManagerAtkTooltipInfo /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdPair::PointerComponentGUIAtkResNode::PointerComponentGUIAtkTooltipManagerAtkTooltipInfo /* Size=0x10 */
{
    /* 0x00 */ Pointer::ComponentGUIAtkResNode Item1;
    /* 0x08 */ Pointer::ComponentGUIAtkTooltipManagerAtkTooltipInfo Item2;
};

struct StdMap::Node::PointerComponentGUIAtkResNode::PointerComponentGUIAtkTooltipManagerAtkTooltipInfo /* Size=0x38 */
{
    /* 0x00 */ StdMap::Node::PointerComponentGUIAtkResNode::PointerComponentGUIAtkTooltipManagerAtkTooltipInfo* Left;
    /* 0x08 */ StdMap::Node::PointerComponentGUIAtkResNode::PointerComponentGUIAtkTooltipManagerAtkTooltipInfo* Parent;
    /* 0x10 */ StdMap::Node::PointerComponentGUIAtkResNode::PointerComponentGUIAtkTooltipManagerAtkTooltipInfo* Right;
    /* 0x18 */ byte Color;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /* 0x1C */ bool IsNil;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ byte _18;
    /* 0x21 */ byte _19;
    /*      */ byte _gap_0x22[0x2];
    /*      */ byte _gap_0x24[0x4];
    /* 0x28 */ StdPair::PointerComponentGUIAtkResNode::PointerComponentGUIAtkTooltipManagerAtkTooltipInfo KeyValuePair;
};

struct StdMap::PointerComponentGUIAtkResNode::PointerComponentGUIAtkTooltipManagerAtkTooltipInfo /* Size=0x10 */
{
    /* 0x00 */ StdMap::Node::PointerComponentGUIAtkResNode::PointerComponentGUIAtkTooltipManagerAtkTooltipInfo* Head;
    /* 0x08 */ unsigned __int64 Count;
};

struct Component::GUI::AtkTooltipManager /* Size=0x150 */
{
    /* 0x000 */ Component::GUI::AtkEventListener AtkEventListener;
    /* 0x008 */ StdMap::PointerComponentGUIAtkResNode::PointerComponentGUIAtkTooltipManagerAtkTooltipInfo TooltipMap;
    /* 0x018 */ Component::GUI::AtkStage* AtkStage;
    /*       */ byte _gap_0x20[0x130];
};

struct Component::GUI::AtkStage /* Size=0x75DF8 */
{
    /* 0x00000 */ Component::GUI::AtkEventTarget AtkEventTarget;
    union {
    /* 0x00008 */ Client::UI::RaptureAtkUnitManager* RaptureAtkUnitManager;
    /* 0x00008 */ __int64 AtkInputManager;
    } _union_0x20;
    /*         */ byte _gap_0x10[0x28];
    /* 0x00038 */ Component::GUI::AtkArrayDataHolder* AtkArrayDataHolder;
    /*         */ byte _gap_0x40[0x38];
    /* 0x00078 */ Component::GUI::AtkDragDropManager DragDropManager;
    /*         */ byte _gap_0x140[0x28];
    /* 0x00168 */ Component::GUI::AtkTooltipManager TooltipManager;
    /*         */ byte _gap_0x2B8[0x80];
    /* 0x00338 */ Component::GUI::AtkCursor AtkCursor;
    /*         */ byte _gap_0x348[0x8];
    /* 0x00350 */ void* AtkEventDispatcher;
    /*         */ byte _gap_0x358[0x510];
    /* 0x00868 */ Component::GUI::AtkEvent* RegisteredEvents;
    /*         */ byte _gap_0x870[0x75588];
};

struct Component::GUI::AtkDragDropManager /* Size=0xC8 */
{
    /* 0x00 */ Component::GUI::AtkEventListener AtkEventListener;
    /*      */ byte _gap_0x8[0x88];
    /* 0x90 */ Component::GUI::AtkStage* AtkStage;
    /*      */ byte _gap_0x98[0x20];
    /* 0xB8 */ __int16 DragStartX;
    /* 0xBA */ __int16 DragStartY;
    /*      */ byte _gap_0xBC[0x4];
    /*      */ byte _gap_0xC0[0x8];
};

struct Component::GUI::AtkEventListenerUnk1 /* Size=0x60 */
{
    union {
    /* 0x00 */ void* vtbl;
    /* 0x00 */ void** vfunc;
    } _union_0x0;
    /* 0x08 */ void* Unk;
    /*      */ byte _gap_0x10[0x10];
    /* 0x20 */ Component::GUI::AtkUnitBase* AtkUnitBase;
    /* 0x28 */ Component::GUI::AtkStage* AtkStage;
    /*      */ byte _gap_0x30[0x30];
};

enum ImageNodeFlags: __int32
{
    FlipH = 1,
    FlipV = 2,
    AutoFit = 128
};

struct Component::GUI::AtkLinkedList; /* Size=unknown due to generic type with parameters */
struct Component::GUI::AtkModule::AtkModuleVTable /* Size=0xD8 */
{
    /*      */ byte _gap_0x0[0x48];
    /* 0x48 */ __int64 GetNumberArrayData;
    /* 0x50 */ __int64 GetStringArrayData;
    /* 0x58 */ __int64 GetExtendArrayData;
    /*      */ byte _gap_0x60[0x70];
    /* 0xD0 */ __int64 IsAddonReady;
};

struct Component::GUI::AtkModule /* Size=0x8240 */
{
    union {
    /* 0x0000 */ void* vtbl;
    /* 0x0000 */ Component::GUI::AtkModule::AtkModuleVTable* VTable;
    } _union_0x0;
    /*        */ byte _gap_0x8[0x1B08];
    /* 0x1B10 */ Component::GUI::AtkUnitBase* IntersectingAddon;
    /* 0x1B18 */ Component::GUI::AtkCollisionNode* IntersectingCollisionNode;
    /*        */ byte _gap_0x1B20[0x28];
    /* 0x1B48 */ Component::GUI::AtkArrayDataHolder AtkArrayDataHolder;
    /*        */ byte _gap_0x1B98[0x66A8];
};

struct Component::GUI::AtkNineGridNode /* Size=0xC8 */
{
    /* 0x00 */ Component::GUI::AtkResNode AtkResNode;
    /* 0xA8 */ Component::GUI::AtkUldPartsList* PartsList;
    /* 0xB0 */ unsigned __int32 PartID;
    /* 0xB4 */ __int16 TopOffset;
    /* 0xB6 */ __int16 BottomOffset;
    /* 0xB8 */ __int16 LeftOffset;
    /* 0xBA */ __int16 RightOffset;
    /* 0xBC */ unsigned __int32 BlendMode;
    /* 0xC0 */ byte PartsTypeRenderType;
    /*      */ byte _gap_0xC1;
    /*      */ byte _gap_0xC2[0x2];
    /*      */ byte _gap_0xC4[0x4];
};

enum NodeFlags: __int32
{
    AnchorTop = 1,
    AnchorLeft = 2,
    AnchorBottom = 4,
    AnchorRight = 8,
    Visible = 16,
    Enabled = 32,
    Clip = 64,
    Fill = 128,
    HasCollision = 256,
    RespondToMouse = 512,
    Focusable = 1024,
    Droppable = 2048,
    IsTopNode = 4096,
    EmitsEvents = 8192,
    UseDepthBasedPriority = 16384,
    UnkFlag2 = 32768
};

enum TextFlags: __int32
{
    AutoAdjustNodeSize = 1,
    Bold = 2,
    Italic = 4,
    Edge = 8,
    Glare = 16,
    Emboss = 32,
    WordWrap = 64,
    MultiLine = 128
};

enum TextFlags2: __int32
{
    Ellipsis = 4
};

enum FontType: byte
{
    Axis = 0,
    MiedingerMed = 1,
    Miedinger = 2,
    TrumpGothic = 3,
    Jupiter = 4,
    JupiterLarge = 5
};

struct Component::GUI::AtkUldComponentDataButton /* Size=0x18 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x2];
    /* 0x14 */ unsigned __int32 TextId;
};

struct Component::GUI::AtkUldComponentDataCheckBox /* Size=0x1C */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x3];
    /* 0x18 */ unsigned __int32 TextId;
};

struct Component::GUI::AtkUldComponentDataDragDrop /* Size=0x10 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x1];
};

struct Component::GUI::AtkUldComponentDataDropDownList /* Size=0x14 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x2];
};

struct Component::GUI::AtkUldComponentDataGaugeBar /* Size=0x3C */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x6];
    /* 0x24 */ unsigned __int16 MarginV;
    /* 0x26 */ unsigned __int16 MarginH;
    /* 0x28 */ byte Vertical;
    /*      */ byte _gap_0x29;
    /*      */ byte _gap_0x2A[0x2];
    /* 0x2C */ __int32 Indicator;
    /* 0x30 */ __int32 Min;
    /* 0x34 */ __int32 Max;
    /* 0x38 */ __int32 Value;
};

struct Component::GUI::AtkUldComponentDataGuildLeveCard /* Size=0x1C */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x3];
    /*      */ byte _gap_0x18[0x4];
};

struct Component::GUI::AtkUldComponentDataHoldButton /* Size=0x20 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x4];
    /* 0x1C */ unsigned __int32 TextId;
};

struct Component::GUI::AtkUldComponentDataIcon /* Size=0x2C */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x8];
};

struct Component::GUI::AtkUldComponentDataIconText /* Size=0x14 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x2];
};

struct Component::GUI::AtkUldComponentDataJournalCanvas /* Size=0x94 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x20];
    /* 0x8C */ unsigned __int16 ItemMargin;
    /* 0x8E */ unsigned __int16 BasicMargin;
    /* 0x90 */ unsigned __int16 AnotherMargin;
    /* 0x92 */ unsigned __int16 Padding;
};

struct Component::GUI::AtkUldComponentDataList /* Size=0x28 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x5];
    /* 0x20 */ byte Wrap;
    /* 0x21 */ byte Orientation;
    /* 0x22 */ unsigned __int16 RowNum;
    /* 0x24 */ unsigned __int16 ColNum;
    /*      */ byte _gap_0x26[0x2];
};

struct Component::GUI::AtkUldComponentDataListItemRenderer /* Size=0x20 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x4];
    /* 0x1C */ byte CanToggle;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
};

struct Component::GUI::AtkUldComponentDataMap /* Size=0x34 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0xA];
};

struct Component::GUI::AtkUldComponentDataMultipurpose /* Size=0x18 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x3];
};

struct Component::GUI::AtkUldComponentDataPreview /* Size=0x14 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x2];
};

struct Component::GUI::AtkUldComponentDataRadioButton /* Size=0x24 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x4];
    /* 0x1C */ unsigned __int32 TextId;
    /* 0x20 */ unsigned __int32 GroupId;
};

struct Component::GUI::AtkUldComponentDataScrollBar /* Size=0x20 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x4];
    /* 0x1C */ unsigned __int16 Margin;
    /* 0x1E */ byte Vertical;
    /*      */ byte _gap_0x1F;
};

struct Component::GUI::AtkUldComponentDataSlider /* Size=0x34 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x4];
    /* 0x1C */ __int32 Min;
    /* 0x20 */ __int32 Max;
    /* 0x24 */ __int32 Step;
    /* 0x28 */ __int32 OfffsetL;
    /* 0x2C */ __int32 OffsetR;
    /* 0x30 */ byte Vertical;
    /*      */ byte _gap_0x31;
    /*      */ byte _gap_0x32[0x2];
};

enum TextInputFlags1: __int32
{
    Capitalize = 1,
    Mask = 2,
    EnableDictionary = 4,
    EnableHistory = 8,
    EnableIME = 16,
    EscapeClears = 32,
    AllowUpperCase = 64,
    AllowLowerCase = 128
};

enum TextInputFlags2: __int32
{
    AllowNumberInput = 1,
    AllowSymbolInput = 2,
    WordWrap = 4,
    MultiLine = 8,
    AutoMaxWidth = 16
};

struct Component::GUI::AtkUldComponentDataTextInput /* Size=0x7C */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataInputBase InputBase;
    /* 0x10 */ unsigned __int32 Nodes[0x10];
    /* 0x50 */ Client::Graphics::ByteColor CandidateColor;
    /* 0x54 */ Client::Graphics::ByteColor IMEColor;
    /* 0x58 */ unsigned __int32 MaxWidth;
    /* 0x5C */ unsigned __int32 MaxLine;
    /* 0x60 */ unsigned __int32 MaxByte;
    /* 0x64 */ unsigned __int32 MaxChar;
    /* 0x68 */ unsigned __int16 CharSet;
    /* 0x6A */ byte Flags1;
    /* 0x6B */ byte Flags2;
    /* 0x6C */ byte CharSetExtras[0x10];
};

struct Component::GUI::AtkUldComponentDataTextNineGrid /* Size=0x18 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x2];
    /* 0x14 */ unsigned __int32 TextId;
};

struct Component::GUI::AtkUldComponentDataTreeList /* Size=0x28 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x5];
    /* 0x20 */ byte Wrap;
    /* 0x21 */ byte Orientation;
    /* 0x22 */ unsigned __int16 RowNum;
    /* 0x24 */ unsigned __int16 ColNum;
    /*      */ byte _gap_0x26[0x2];
};

struct Component::GUI::AtkUldComponentDataWindow /* Size=0x38 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x8];
    /* 0x2C */ unsigned __int32 TitleTextId;
    /* 0x30 */ unsigned __int32 SubtitleTextId;
    /* 0x34 */ byte ShowCloseButton;
    /* 0x35 */ byte ShowConfigButton;
    /* 0x36 */ byte ShowHelpButton;
    /* 0x37 */ byte ShowHeader;
};

struct Component::GUI::AtkUldComponentInfo /* Size=0x18 */
{
    /* 0x00 */ Component::GUI::AtkUldObjectInfo ObjectInfo;
    /* 0x10 */ Component::GUI::ComponentType ComponentType;
    /*      */ byte _gap_0x11;
    /*      */ byte _gap_0x12[0x2];
    /*      */ byte _gap_0x14[0x4];
};

enum AlignmentType: __int32
{
    TopLeft = 0,
    Top = 1,
    TopRight = 2,
    Left = 3,
    Center = 4,
    Right = 5,
    BottomLeft = 6,
    Bottom = 7,
    BottomRight = 8
};

struct Component::GUI::AtkUldWidgetInfo /* Size=0x20 */
{
    /* 0x00 */ Component::GUI::AtkUldObjectInfo ObjectInfo;
    /* 0x10 */ unsigned __int32 AlignmentType;
    /* 0x14 */ float X;
    /* 0x18 */ float Y;
    /*      */ byte _gap_0x1C[0x4];
};

struct Component::GUI::ULD::AtkUldComponentDataTab /* Size=0x24 */
{
    /* 0x00 */ Component::GUI::AtkUldComponentDataBase Base;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ unsigned __int32 Nodes[0x4];
    /* 0x1C */ unsigned __int32 TextId;
    /* 0x20 */ unsigned __int32 GroupId;
};

struct Client::UI::AddonActionBarBase::AddonActionBarBaseVTable /* Size=0x270 */
{
    /*       */ byte _gap_0x0[0x268];
    /* 0x268 */ __int64 PulseActionBarSlot;
};

struct Client::UI::ActionBarSlot /* Size=0xC8 */
{
    /*      */ byte _gap_0x0[0x4];
    /* 0x04 */ __int32 ActionId;
    /*      */ byte _gap_0x8[0x88];
    /* 0x90 */ Component::GUI::AtkComponentNode* Icon;
    /* 0x98 */ Component::GUI::AtkTextNode* ControlHintTextNode;
    /* 0xA0 */ Component::GUI::AtkResNode* IconFrame;
    /* 0xA8 */ Component::GUI::AtkImageNode* ChargeIcon;
    /* 0xB0 */ Component::GUI::AtkResNode* RecastOverlayContainer;
    /* 0xB8 */ byte* PopUpHelpTextPtr;
    /*      */ byte _gap_0xC0[0x8];
};

struct Client::UI::AddonActionBarBase /* Size=0x248 */
{
    union {
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x000 */ Client::UI::AddonActionBarBase::AddonActionBarBaseVTable* VTable;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x218];
    /* 0x220 */ Client::UI::ActionBarSlot* ActionBarSlots;
    /*       */ byte _gap_0x228[0x10];
    /* 0x238 */ __int16 CurrentPulsingSlots;
    /*       */ byte _gap_0x23A[0x2];
    /* 0x23C */ byte RaptureHotbarId;
    /*       */ byte _gap_0x23D;
    /* 0x23E */ byte SlotCount;
    /*       */ byte _gap_0x23F;
    /* 0x240 */ bool IsSharedHotbar;
    /*       */ byte _gap_0x241;
    /*       */ byte _gap_0x242[0x2];
    /*       */ byte _gap_0x244[0x4];
};

struct Client::UI::AddonActionBarX /* Size=0x298 */
{
    /* 0x000 */ Client::UI::AddonActionBarBase AddonActionBarBase;
    /*       */ byte _gap_0x248[0x50];
};

struct Client::UI::AddonActionBar /* Size=0x2B8 */
{
    /* 0x000 */ Client::UI::AddonActionBarX AddonActionBarX;
    /*       */ byte _gap_0x298[0x20];
};

struct Client::UI::AddonActionCross /* Size=0x710 */
{
    /* 0x000 */ Client::UI::AddonActionBarBase ActionBarBase;
    /*       */ byte _gap_0x248[0x4A0];
    /* 0x6E8 */ __int32 ExpandedHoldControlsLTRT;
    /* 0x6EC */ __int32 ExpandedHoldControlsRTLT;
    /*       */ byte _gap_0x6F0[0x20];
};

struct Client::UI::AddonActionDoubleCrossBase /* Size=0x2F8 */
{
    /* 0x000 */ Client::UI::AddonActionBarBase ActionBarBase;
    /*       */ byte _gap_0x248[0x98];
    /*       */ byte _gap_0x2E0;
    /* 0x2E1 */ byte ShowDPadSlots;
    /*       */ byte _gap_0x2E2[0x2];
    /*       */ byte _gap_0x2E4[0x4];
    /* 0x2E8 */ byte BarTarget;
    /*       */ byte _gap_0x2E9;
    /*       */ byte _gap_0x2EA[0x2];
    /* 0x2EC */ byte UseLeftSide;
    /* 0x2ED */ byte MergedPositioning;
    /*       */ byte _gap_0x2EE[0x2];
    /*       */ byte _gap_0x2F0[0x8];
};

struct Client::UI::AddonAOZNotebook::SpellbookBlock /* Size=0x48 */
{
    /* 0x00 */ Component::GUI::AtkComponentBase* AtkComponentBase;
    /* 0x08 */ Component::GUI::AtkCollisionNode* AtkCollisionNode;
    /* 0x10 */ Component::GUI::AtkComponentCheckBox* AtkComponentCheckBox;
    /* 0x18 */ Component::GUI::AtkComponentIcon* AtkComponentIcon;
    /* 0x20 */ Component::GUI::AtkTextNode* AtkTextNode;
    /* 0x28 */ Component::GUI::AtkResNode* AtkResNode1;
    /* 0x30 */ Component::GUI::AtkResNode* AtkResNode2;
    /* 0x38 */ char* Name;
    /* 0x40 */ unsigned __int32 ActionID;
    /*      */ byte _gap_0x44[0x4];
};

struct Client::UI::AddonAOZNotebook::ActiveActions /* Size=0x20 */
{
    /* 0x00 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop;
    /* 0x08 */ Component::GUI::AtkTextNode* AtkTextNode;
    /* 0x10 */ char* Name;
    /* 0x18 */ __int32 ActionID;
    /*      */ byte _gap_0x1C[0x4];
};

struct Client::UI::AddonAOZNotebook /* Size=0xCD0 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0xE8];
    /* 0x308 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock01;
    /* 0x350 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock02;
    /* 0x398 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock03;
    /* 0x3E0 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock04;
    /* 0x428 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock05;
    /* 0x470 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock06;
    /* 0x4B8 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock07;
    /* 0x500 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock08;
    /* 0x548 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock09;
    /* 0x590 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock10;
    /* 0x5D8 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock11;
    /* 0x620 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock12;
    /* 0x668 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock13;
    /* 0x6B0 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock14;
    /* 0x6F8 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock15;
    /* 0x740 */ Client::UI::AddonAOZNotebook::SpellbookBlock SpellbookBlock16;
    /*       */ byte _gap_0x788[0x98];
    /* 0x820 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions01;
    /* 0x840 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions02;
    /* 0x860 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions03;
    /* 0x880 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions04;
    /* 0x8A0 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions05;
    /* 0x8C0 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions06;
    /* 0x8E0 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions07;
    /* 0x900 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions08;
    /* 0x920 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions09;
    /* 0x940 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions10;
    /* 0x960 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions11;
    /* 0x980 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions12;
    /* 0x9A0 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions13;
    /* 0x9C0 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions14;
    /* 0x9E0 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions15;
    /* 0xA00 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions16;
    /* 0xA20 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions17;
    /* 0xA40 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions18;
    /* 0xA60 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions19;
    /* 0xA80 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions20;
    /* 0xAA0 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions21;
    /* 0xAC0 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions22;
    /* 0xAE0 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions23;
    /* 0xB00 */ Client::UI::AddonAOZNotebook::ActiveActions ActiveActions24;
    /*       */ byte _gap_0xB20[0x1B0];
};

struct Client::UI::AddonBank::AddonBankVTable /* Size=0x180 */
{
    /*       */ byte _gap_0x0[0x178];
    /* 0x178 */ __int64 OnSetup;
};

struct Client::UI::AddonBank /* Size=0x298 */
{
    union {
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x000 */ Client::UI::AddonBank::AddonBankVTable* VTable;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x290];
};

struct Client::UI::AddonCastBar /* Size=0x500 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Client::System::String::Utf8String CastName;
    /*       */ byte _gap_0x288[0x30];
    /*       */ byte _gap_0x2B8[0x4];
    /* 0x2BC */ unsigned __int16 CastTime;
    /*       */ byte _gap_0x2BE[0x2];
    /* 0x2C0 */ float CastPercent;
    /*       */ byte _gap_0x2C4[0x4];
    /*       */ byte _gap_0x2C8[0x238];
};

struct Client::UI::AddonCharacterInspect /* Size=0x500 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x210];
    /* 0x430 */ Component::GUI::AtkComponentBase* PreviewComponent;
    /*       */ byte _gap_0x438[0xC8];
};

struct Client::UI::AddonChatLogPanel /* Size=0x3D0 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x60];
    /* 0x280 */ Component::GUI::AtkTextNode* ChatText;
    /*       */ byte _gap_0x288[0x28];
    /* 0x2B0 */ byte FontSize;
    /*       */ byte _gap_0x2B1;
    /*       */ byte _gap_0x2B2[0x2];
    /* 0x2B4 */ unsigned __int32 FirstLineVisible;
    /* 0x2B8 */ unsigned __int32 LastLineVisible;
    /*       */ byte _gap_0x2BC[0x4];
    /* 0x2C0 */ unsigned __int32 Unknown2C0;
    /* 0x2C4 */ unsigned __int32 TotalLineCount;
    /*       */ byte _gap_0x2C8[0x30];
    /* 0x2F8 */ unsigned __int32 MessagesAboveCurrent;
    /*       */ byte _gap_0x2FC[0x4];
    /*       */ byte _gap_0x300[0x40];
    /*       */ byte _gap_0x340;
    /* 0x341 */ byte IsScrolledBottom;
    /*       */ byte _gap_0x342[0x2];
    /*       */ byte _gap_0x344[0x4];
    /*       */ byte _gap_0x348[0x88];
};

struct Client::UI::AddonChocoboBreedTraining /* Size=0x230 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentButton* CommenceButton;
    /* 0x228 */ Component::GUI::AtkComponentButton* CancelButton;
};

struct Client::UI::AddonContentsFinder /* Size=0x16C8 */
{
    /* 0x0000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*        */ byte _gap_0x220[0x98];
    /* 0x02B8 */ Component::GUI::AtkComponentButton* ClearSelectionButton;
    /* 0x02C0 */ Component::GUI::AtkComponentButton* JoinButton;
    /* 0x02C8 */ Component::GUI::AtkComponentRadioButton* DutyRouletteRadioButton;
    /* 0x02D0 */ Component::GUI::AtkComponentRadioButton* Dungeons1RadioButton;
    /* 0x02D8 */ Component::GUI::AtkComponentRadioButton* Dungeons2RadioButton;
    /* 0x02E0 */ Component::GUI::AtkComponentRadioButton* GuildHeistsRadioButton;
    /* 0x02E8 */ Component::GUI::AtkComponentRadioButton* Trials1RadioButton;
    /* 0x02F0 */ Component::GUI::AtkComponentRadioButton* Trials2RadioButton;
    /* 0x02F8 */ Component::GUI::AtkComponentRadioButton* Raids1RadioButton;
    /* 0x0300 */ Component::GUI::AtkComponentRadioButton* Raids2RadioButton;
    /* 0x0308 */ Component::GUI::AtkComponentRadioButton* PvpRadioButton;
    /* 0x0310 */ Component::GUI::AtkComponentRadioButton* GoldSaucerRadioButton;
    /* 0x0318 */ byte SelectedDutyTextNode[0x28];
    /* 0x0340 */ Component::GUI::AtkComponentTreeList* DutyList;
    /* 0x0348 */ Component::GUI::AtkComponentDropDownList* OrderByButton;
    /* 0x0350 */ Component::GUI::AtkComponentButton* RefreshButton;
    /* 0x0358 */ Component::GUI::AtkComponentButton* DutyTypeButton;
    /* 0x0360 */ Component::GUI::AtkTextNode* JobNameTextNode;
    /* 0x0368 */ Component::GUI::AtkTextNode* UnkTextNode;
    /* 0x0370 */ Component::GUI::AtkTextNode* LevelTextNode;
    /* 0x0378 */ Component::GUI::AtkTextNode* ItemLevelTextNode;
    /* 0x0380 */ Component::GUI::AtkTextNode* RoleTextNode;
    /* 0x0388 */ Component::GUI::AtkTextNode* NumberSelectedTextNode;
    /* 0x0390 */ Component::GUI::AtkTextNode* ObtainingDataTextNode;
    /* 0x0398 */ Component::GUI::AtkTextNode* NumOtherPartiesRecruitingTextNode;
    /*        */ byte _gap_0x3A0[0x8];
    /* 0x03A8 */ Component::GUI::AtkImageNode* StarImageNode;
    /* 0x03B0 */ Component::GUI::AtkResNode* RoleIconResNode;
    /* 0x03B8 */ Component::GUI::AtkImageNode* RoleIconImageNode;
    /* 0x03C0 */ Component::GUI::AtkResNode* NumOtherPartiesRecruitingResNode;
    /* 0x03C8 */ byte SettingsButton[0x40];
    /*        */ byte _gap_0x408[0x12A0];
    /* 0x16A8 */ unsigned __int32 SelectedRadioButton;
    /*        */ byte _gap_0x16AC[0x4];
    /*        */ byte _gap_0x16B0[0x4];
    /* 0x16B4 */ unsigned __int32 SelectedRow;
    /* 0x16B8 */ unsigned __int32 NumEntries;
    /*        */ byte _gap_0x16BC[0x4];
    /*        */ byte _gap_0x16C0[0x8];
};

struct Client::UI::AddonContentsFinderConfirm /* Size=0x2A0 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x8];
    /* 0x228 */ Component::GUI::AtkTextNode* AtkTextNode228;
    /* 0x230 */ Component::GUI::AtkTextNode* AtkTextNode230;
    /* 0x238 */ Component::GUI::AtkTextNode* AtkTextNode238;
    /* 0x240 */ Component::GUI::AtkTextNode* AtkTextNode240;
    /* 0x248 */ Component::GUI::AtkTextNode* AtkTextNode248;
    /*       */ byte _gap_0x250[0x38];
    /* 0x288 */ Component::GUI::AtkComponentButton* CommenceButton;
    /* 0x290 */ Component::GUI::AtkComponentButton* WithdrawButton;
    /* 0x298 */ Component::GUI::AtkComponentButton* WaitButton;
};

struct Client::UI::AddonContextIconMenu /* Size=0x2B0 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ __int32 EntryCount;
    /*       */ byte _gap_0x224[0x4];
    /*       */ byte _gap_0x228[0x18];
    /* 0x240 */ Component::GUI::AtkComponentList* AtkComponentList240;
    /* 0x248 */ void* unk248;
    /* 0x250 */ Component::GUI::AtkComponentRadioButton* AtkComponentRadioButton250;
    /* 0x258 */ Component::GUI::AtkComponentRadioButton* AtkComponentRadioButton258;
    /* 0x260 */ Component::GUI::AtkComponentRadioButton* AtkComponentRadioButton260;
    /* 0x268 */ Component::GUI::AtkComponentRadioButton* AtkComponentRadioButton268;
    /* 0x270 */ Component::GUI::AtkComponentRadioButton* AtkComponentRadioButton270;
    /* 0x278 */ Component::GUI::AtkComponentRadioButton* AtkComponentRadioButton278;
    /* 0x280 */ Component::GUI::AtkComponentRadioButton* AtkComponentRadioButton280;
    /* 0x288 */ Component::GUI::AtkComponentRadioButton* AtkComponentRadioButton288;
    /* 0x290 */ Component::GUI::AtkComponentRadioButton* AtkComponentRadioButton290;
    /* 0x298 */ Component::GUI::AtkComponentRadioButton* AtkComponentRadioButton298;
    /*       */ byte _gap_0x2A0[0x10];
};

struct Client::UI::AddonCutSceneSelectString /* Size=0x248 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x10];
    /* 0x230 */ Component::GUI::AtkComponentList* OptionList;
    /* 0x238 */ Component::GUI::AtkComponentTextNineGrid* TextLabel;
    /*       */ byte _gap_0x240[0x8];
};

struct Client::UI::AddonEnemyList /* Size=0x278 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentButton** EnemyOneComponent;
    /*       */ byte _gap_0x228[0x48];
    /*       */ byte _gap_0x270[0x2];
    /* 0x272 */ byte EnemyCount;
    /* 0x273 */ byte HoveredIndex;
    /* 0x274 */ byte SelectedIndex;
    /*       */ byte _gap_0x275;
    /*       */ byte _gap_0x276[0x2];
};

struct Client::UI::AddonExp /* Size=0x290 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x50];
    /* 0x270 */ byte ClassJob;
    /*       */ byte _gap_0x271;
    /*       */ byte _gap_0x272[0x2];
    /*       */ byte _gap_0x274[0x4];
    /* 0x278 */ unsigned __int32 CurrentExp;
    /* 0x27C */ unsigned __int32 RequiredExp;
    /* 0x280 */ unsigned __int32 RestedExp;
    /*       */ byte _gap_0x284[0x4];
    /*       */ byte _gap_0x288[0x8];
};

struct Client::UI::AddonFateReward /* Size=0x570 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkResNode* AtkResNode220;
    /* 0x228 */ Component::GUI::AtkImageNode* AtkImageNode228;
    /* 0x230 */ Component::GUI::AtkImageNode* AtkImageNode230;
    /* 0x238 */ Component::GUI::AtkResNode* AtkResNode238;
    /* 0x240 */ Component::GUI::AtkTextNode* AtkTextNode240;
    /* 0x248 */ Component::GUI::AtkTextNode* AtkTextNode248;
    /* 0x250 */ Component::GUI::AtkTextNode* AtkTextNode250;
    /* 0x258 */ Component::GUI::AtkImageNode* AtkImageNode258;
    /*       */ byte _gap_0x260[0x68];
    /* 0x2C8 */ Component::GUI::AtkComponentTextNineGrid* AtkComponentTextNineGrid2C8;
    /* 0x2D0 */ Component::GUI::AtkImageNode* AtkImageNode2D0;
    /* 0x2D8 */ Component::GUI::AtkResNode* AtkResNode2D8;
    /*       */ byte _gap_0x2E0[0x68];
    /* 0x348 */ Component::GUI::AtkComponentTextNineGrid* AtkComponentTextNineGrid348;
    /* 0x350 */ Component::GUI::AtkImageNode* AtkImageNode350;
    /* 0x358 */ Component::GUI::AtkResNode* AtkResNode358;
    /*       */ byte _gap_0x360[0x200];
    /* 0x560 */ Component::GUI::AtkResNode* AtkResNode560;
    /* 0x568 */ float ElapsedSeconds;
    /*       */ byte _gap_0x56C[0x4];
};

struct Client::UI::AddonFieldMarker /* Size=0x598 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x10];
    /* 0x230 */ __int32 HoveredButtonIndex;
    /*       */ byte _gap_0x234[0x4];
    /* 0x238 */ byte WaymarkInfo[0xC0];
    /*       */ byte _gap_0x2F8[0x280];
    /*       */ byte _gap_0x578[0x4];
    /* 0x57C */ __int32 HoveredPresetIndex;
    /* 0x580 */ byte SelectedPage;
    /*       */ byte _gap_0x581;
    /*       */ byte _gap_0x582[0x2];
    /*       */ byte _gap_0x584[0x4];
    /*       */ byte _gap_0x588[0x10];
};

struct Client::UI::AddonWaymarkInfo /* Size=0x18 */
{
    /* 0x00 */ __int32 IconId;
    /* 0x04 */ __int32 Active;
    /* 0x08 */ byte* TooltipString;
    /* 0x10 */ __int32 Slot;
    /*      */ byte _gap_0x14[0x4];
};

struct Client::UI::AddonFriendList /* Size=0x380 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0xD0];
    /* 0x2F0 */ Component::GUI::AtkComponentList* FriendList;
    /* 0x2F8 */ Component::GUI::AtkComponentButton* AddButton;
    /* 0x300 */ Component::GUI::AtkComponentCheckBox* MoveOnlineToTopCheckBox;
    /* 0x308 */ Component::GUI::AtkTextNode* CurrentFriendCountTextNode;
    /* 0x310 */ Component::GUI::AtkTextNode* ListIsEmptyTextNode;
    /*       */ byte _gap_0x318[0x8];
    /* 0x320 */ Component::GUI::AtkComponentDropDownList* FilterDropDownList;
    /* 0x328 */ Component::GUI::AtkComponentDropDownList* SortDropDownList;
    /*       */ byte _gap_0x330[0x50];
};

struct Client::UI::AddonGathering /* Size=0x300 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkResNode* UnkResNode220;
    /* 0x228 */ Component::GUI::AtkComponentCheckBox* GatheredItemComponentCheckBox1;
    /* 0x230 */ Component::GUI::AtkComponentCheckBox* GatheredItemComponentCheckBox2;
    /* 0x238 */ Component::GUI::AtkComponentCheckBox* GatheredItemComponentCheckBox3;
    /* 0x240 */ Component::GUI::AtkComponentCheckBox* GatheredItemComponentCheckBox4;
    /* 0x248 */ Component::GUI::AtkComponentCheckBox* GatheredItemComponentCheckBox5;
    /* 0x250 */ Component::GUI::AtkComponentCheckBox* GatheredItemComponentCheckBox6;
    /* 0x258 */ Component::GUI::AtkComponentCheckBox* GatheredItemComponentCheckBox7;
    /* 0x260 */ Component::GUI::AtkComponentCheckBox* GatheredItemComponentCheckBox8;
    /* 0x268 */ Component::GUI::AtkTextNode* InventoryQuantityTextNode;
    /* 0x270 */ Component::GUI::AtkResNode* UnkResNode270;
    /* 0x278 */ Component::GUI::AtkComponentCheckBox* QuickGatheringComponentCheckBox;
    /* 0x280 */ Component::GUI::AtkResNode* UnkResNode;
    /* 0x288 */ unsigned __int64 unk288;
    /* 0x290 */ unsigned __int64 unk290;
    /* 0x298 */ unsigned __int64 unk298;
    /* 0x2A0 */ unsigned __int64 unk2A0;
    /* 0x2A8 */ unsigned __int64 unk2A8;
    /* 0x2B0 */ unsigned __int64 unk2B0;
    /* 0x2B8 */ unsigned __int64 unk2B8;
    /* 0x2C0 */ unsigned __int64 unk2C0;
    /* 0x2C8 */ unsigned __int32 GatheredItemId1;
    /* 0x2CC */ unsigned __int32 GatheredItemId2;
    /* 0x2D0 */ unsigned __int32 GatheredItemId3;
    /* 0x2D4 */ unsigned __int32 GatheredItemId4;
    /* 0x2D8 */ unsigned __int32 GatheredItemId5;
    /* 0x2DC */ unsigned __int32 GatheredItemId6;
    /* 0x2E0 */ unsigned __int32 GatheredItemId7;
    /* 0x2E4 */ unsigned __int32 GatheredItemId8;
    /* 0x2E8 */ unsigned __int64 unk2E8;
    /* 0x2F0 */ unsigned __int64 unk2F0;
    /* 0x2F8 */ __int32 unk2F8;
    /* 0x2FC */ __int16 unk2FC;
    /*       */ byte _gap_0x2FE[0x2];
};

struct Client::UI::AddonGatheringMasterpiece /* Size=0x7F8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x168];
    /* 0x388 */ Component::GUI::AtkComponentDragDrop* CollectDragDrop;
    /*       */ byte _gap_0x390[0x468];
};

struct Client::UI::AddonGcArmyCapture /* Size=0x268 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentButton* DeployButton;
    /* 0x228 */ Component::GUI::AtkComponentList* MissionList;
    /* 0x230 */ Component::GUI::AtkComponentList* ChosenRecruitList;
    /* 0x238 */ Component::GUI::AtkTextNode* ScriptsTextNode;
    /* 0x240 */ Component::GUI::AtkTextNode* ExpRewardTextNode;
    /* 0x248 */ Component::GUI::AtkComponentBase* ExpRewardComponent;
    /* 0x250 */ Component::GUI::AtkTextNode* ExpendituresTextNode;
    /* 0x258 */ Component::GUI::AtkTextNode* MissionLevelTextNode;
    /* 0x260 */ Component::GUI::AtkTextNode* MissionRequirementsTextNode;
};

struct Client::UI::AddonGcArmyExpedition /* Size=0x2E8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentButton* DeployButton;
    /* 0x228 */ Component::GUI::AtkComponentList* MissionList;
    /*       */ byte _gap_0x230[0x8];
    /* 0x238 */ Component::GUI::AtkTextNode* ListHeaderTextNode;
    /* 0x240 */ Component::GUI::AtkTextNode* ScriptsTextNode;
    /* 0x248 */ Component::GUI::AtkTextNode* MissionDescriptionTextNode;
    /*       */ byte _gap_0x250[0x8];
    /* 0x258 */ Component::GUI::AtkComponentBase* SquadronExpRewardComponentNode;
    /* 0x260 */ Component::GUI::AtkComponentBase* ItemRewardComponentNode;
    /* 0x268 */ Component::GUI::AtkTextNode* MissionSealCostTextNode;
    /* 0x270 */ Component::GUI::AtkResNode* MissionLevelResNode;
    /* 0x278 */ Component::GUI::AtkTextNode* MissionLevelTextNode;
    /*       */ byte _gap_0x280[0x18];
    /* 0x298 */ Component::GUI::AtkComponentBase* RequiredAttributesComponentNode;
    /* 0x2A0 */ Component::GUI::AtkComponentBase* CurrentAttributesComponentNode;
    /*       */ byte _gap_0x2A8[0x18];
    /* 0x2C0 */ Component::GUI::AtkResNode* SquadronSergeantImageResNode;
    /* 0x2C8 */ Component::GUI::AtkResNode* SquadronSergeantChatMessageResNode;
    /* 0x2D0 */ Component::GUI::AtkTextNode* SquadronSergeantChatMessageTextNode;
    /* 0x2D8 */ __int32 SelectedTab;
    /*       */ byte _gap_0x2DC[0x4];
    /*       */ byte _gap_0x2E0[0x8];
};

struct Client::UI::AddonGcArmyExpeditionResult /* Size=0x228 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentButton* CompleteButton;
};

struct Client::UI::AddonGrandCompanySupplyList /* Size=0x760 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x60];
    /* 0x280 */ Component::GUI::AtkComponentList* SupplyProvisioningList;
    /* 0x288 */ Component::GUI::AtkComponentList* ExpertDeliveryList;
    /* 0x290 */ Component::GUI::AtkComponentDropDownList* SortByDropdown;
    /* 0x298 */ Component::GUI::AtkComponentDropDownList* FilterDropdown;
    /* 0x2A0 */ Component::GUI::AtkComponentRadioButton* SupplyRadioButton;
    /* 0x2A8 */ Component::GUI::AtkComponentRadioButton* ProvisioningRadioButton;
    /* 0x2B0 */ Component::GUI::AtkComponentRadioButton* ExpertDeliveryRadioButton;
    /*       */ byte _gap_0x2B8[0x8];
    /* 0x2C0 */ Component::GUI::AtkTextNode* NextMissionAllowanceTextNode;
    /* 0x2C8 */ Component::GUI::AtkTextNode* ListEmptyTextNode;
    /* 0x2D0 */ Component::GUI::AtkTextNode* SealCountTextNode;
    /* 0x2D8 */ Component::GUI::AtkImageNode* SealIconNode;
    /*       */ byte _gap_0x2E0[0x8];
    /* 0x2E8 */ __int32 SelectedTab;
    /* 0x2EC */ __int32 SelectedSortBy;
    /* 0x2F0 */ __int32 SelectedFilter;
    /*       */ byte _gap_0x2F4[0x4];
    /*       */ byte _gap_0x2F8[0x468];
};

struct Client::UI::AddonGrandCompanySupplyReward /* Size=0x230 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentButton* DeliverButton;
    /* 0x228 */ Component::GUI::AtkComponentButton* CancelButton;
};

struct Client::UI::AddonGSInfoCardDeck /* Size=0x228 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentList* DeckList;
};

enum GSInfoCardListFilterMode: __int32
{
    DisplayOwnedCards = 6,
    DisplayUnownedCards = 9,
    DisplayAllCards = 14
};

struct Client::UI::AddonGSInfoCardList /* Size=0x540 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x128];
    /* 0x348 */ Component::GUI::AtkResNode* PageSelection;
    /* 0x350 */ byte PageButtons[0x48];
    /* 0x398 */ Component::GUI::AtkComponentButton* GotoFirstPageButton;
    /* 0x3A0 */ Component::GUI::AtkComponentButton* GotoLastPageButton;
    /*       */ byte _gap_0x3A8[0x10];
    /* 0x3B8 */ byte CardButtons[0xF0];
    /* 0x4A8 */ Component::GUI::AtkTextNode* TotalTextNode;
    /* 0x4B0 */ Component::GUI::AtkImageNode* SelectedButtonBorderImage;
    /* 0x4B8 */ Component::GUI::AtkComponentDropDownList* CardDisplayFilter;
    /*       */ byte _gap_0x4C0[0x10];
    /* 0x4D0 */ Component::GUI::AtkTextNode* SelectedCardName;
    /* 0x4D8 */ Component::GUI::AtkTextNode* SelectedCardTribeName;
    /* 0x4E0 */ Component::GUI::AtkTextNode* SelectedCardDescription;
    /* 0x4E8 */ Component::GUI::AtkTextNode* PreviewedCardNumber;
    /* 0x4F0 */ Component::GUI::AtkTextNode* SelectedCardNumber;
    /* 0x4F8 */ Component::GUI::AtkTextNode* SelectedCardAcquisitionName;
    /* 0x500 */ Component::GUI::AtkImageNode* SelectedCardAcquisitionIcon;
    /* 0x508 */ Client::UI::GSInfoCardListFilterMode FilterMode;
    /*       */ byte _gap_0x50C[0x4];
    /* 0x510 */ __int32 SelectedPage;
    /* 0x514 */ __int32 SelectedCardIndex;
    /*       */ byte _gap_0x518[0x28];
};

struct Client::UI::AddonGSInfoChocoboParam /* Size=0x248 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x18];
    /* 0x238 */ Component::GUI::AtkComponentBase* RaceAbility1;
    /* 0x240 */ Component::GUI::AtkComponentBase* RaceAbility2;
};

struct Client::UI::AddonGSInfoGeneral /* Size=0x250 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentBase* MGPAmountDisplay;
    /* 0x228 */ Component::GUI::AtkComponentBase* TournamentMatches;
    /* 0x230 */ Component::GUI::AtkComponentBase* TournamentWins;
    /* 0x238 */ Component::GUI::AtkComponentBase* TournamentPoints;
    /* 0x240 */ Component::GUI::AtkComponentBase* TournamentInfo;
    /* 0x248 */ Component::GUI::AtkResNode* TournamentResults;
};

struct Client::UI::AddonGSInfoEmj /* Size=0x258 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkTextNode* MatchesPlayed;
    /* 0x228 */ Component::GUI::AtkTextNode* CurrentRating;
    /* 0x230 */ Component::GUI::AtkTextNode* HighestRating;
    /* 0x238 */ Component::GUI::AtkTextNode* Rank;
    /* 0x240 */ Component::GUI::AtkTextNode* NextRankPoints;
    /* 0x248 */ Component::GUI::AtkTextNode* Points;
    /* 0x250 */ Component::GUI::AtkComponentButton* ResetRankButton;
};

struct Client::UI::AddonGSInfoMinionBattle /* Size=0x248 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentBase* TournamentMatches;
    /* 0x228 */ Component::GUI::AtkComponentBase* TournamentWins;
    /* 0x230 */ Component::GUI::AtkComponentBase* TournamentPoints;
    /* 0x238 */ Component::GUI::AtkComponentBase* TournamentInfo;
    /* 0x240 */ Component::GUI::AtkResNode* TournamentResults;
};

struct Client::UI::AddonGuildLeve /* Size=0x18F0 */
{
    /* 0x0000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*        */ byte _gap_0x220[0x8];
    /* 0x0228 */ Component::GUI::AtkComponentTreeList* AtkComponentTreeList228;
    /* 0x0230 */ Component::GUI::AtkComponentRadioButton* FieldcraftButton;
    /* 0x0238 */ Component::GUI::AtkComponentRadioButton* TradecraftButton;
    union {
    /* 0x0240 */ Component::GUI::AtkComponentRadioButton* CarpenterButton;
    /* 0x0240 */ Component::GUI::AtkComponentRadioButton* MinerButton;
    } _union_0x248;
    union {
    /* 0x0248 */ Component::GUI::AtkComponentRadioButton* BlacksmithButton;
    /* 0x0248 */ Component::GUI::AtkComponentRadioButton* BotanistButton;
    } _union_0x250;
    union {
    /* 0x0250 */ Component::GUI::AtkComponentRadioButton* ArmorerButton;
    /* 0x0250 */ Component::GUI::AtkComponentRadioButton* FisherButton;
    } _union_0x258;
    /*        */ byte _gap_0x258[0x8];
    /* 0x0260 */ Component::GUI::AtkComponentRadioButton* GoldsmithButton;
    /* 0x0268 */ Component::GUI::AtkComponentRadioButton* LeatherworkerButton;
    /* 0x0270 */ Component::GUI::AtkComponentRadioButton* WeaverButton;
    /* 0x0278 */ Component::GUI::AtkComponentRadioButton* AlchemistButton;
    /* 0x0280 */ Component::GUI::AtkComponentRadioButton* CulinarianButton;
    /* 0x0288 */ Component::GUI::AtkResNode* AtkResNode288;
    union {
    /* 0x0290 */ Client::System::String::Utf8String CarpenterString;
    /* 0x0290 */ Client::System::String::Utf8String MinerString;
    } _union_0x290;
    union {
    /* 0x0298 */ Client::System::String::Utf8String BlacksmithString;
    /* 0x0298 */ Client::System::String::Utf8String BotanistString;
    } _union_0x2F8;
    union {
    /* 0x02A0 */ Client::System::String::Utf8String ArmorerString;
    /* 0x02A0 */ Client::System::String::Utf8String FisherString;
    } _union_0x360;
    /*        */ byte _gap_0x2A8[0x120];
    /* 0x03C8 */ Client::System::String::Utf8String GoldsmithString;
    /* 0x0430 */ Client::System::String::Utf8String LeatherworkerString;
    /* 0x0498 */ Client::System::String::Utf8String WeaverString;
    /* 0x0500 */ Client::System::String::Utf8String AlchemistString;
    /* 0x0568 */ Client::System::String::Utf8String CulinarianString;
    /* 0x05D0 */ Component::GUI::AtkComponentButton* JournalButton;
    /* 0x05D8 */ Component::GUI::AtkTextNode* AtkTextNode298;
    /* 0x05E0 */ Component::GUI::AtkComponentBase* AtkComponentBase290;
    /* 0x05E8 */ Component::GUI::AtkComponentBase* AtkComponentBase298;
    /*        */ byte _gap_0x5F0[0x1300];
};

struct Client::UI::AddonHudLayoutWindow /* Size=0x268 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x18];
    /* 0x238 */ Component::GUI::AtkComponentButton* SaveButton;
    /*       */ byte _gap_0x240[0x28];
};

struct Client::UI::MoveableAddonInfoStruct /* Size=0x50 */
{
    /*      */ byte _gap_0x0[0x20];
    /* 0x20 */ Client::UI::AddonHudLayoutScreen* hudLayoutScreen;
    /* 0x28 */ Component::GUI::AtkUnitBase* SelectedAtkUnit;
    /*      */ byte _gap_0x30[0x8];
    /*      */ byte _gap_0x38[0x4];
    /* 0x3C */ __int32 Flags;
    /*      */ byte _gap_0x40[0x4];
    /* 0x44 */ __int16 XOffset;
    /* 0x46 */ __int16 YOffset;
    /* 0x48 */ __int16 OverlayWidth;
    /* 0x4A */ __int16 OverlayHeight;
    /*      */ byte _gap_0x4C;
    /* 0x4D */ byte Slot;
    /*      */ byte _gap_0x4E;
    /* 0x4F */ byte PositionHasChanged;
};

struct Client::UI::AddonHudLayoutScreen /* Size=0x8A8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0xA8];
    /* 0x2C8 */ Client::UI::AddonHudLayoutWindow* HudLayoutWindow;
    /*       */ byte _gap_0x2D0[0x270];
    /* 0x540 */ Component::GUI::AtkComponentNode* SelectedOverlayNode;
    /*       */ byte _gap_0x548[0x268];
    /* 0x7B0 */ Client::UI::MoveableAddonInfoStruct* SelectedAddon;
    /*       */ byte _gap_0x7B8[0xF0];
};

struct Client::UI::AddonImage /* Size=0x290 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x40];
    /* 0x260 */ Component::GUI::AtkResNode* ResNode1;
    /* 0x268 */ Component::GUI::AtkResNode* ResNode2;
    /* 0x270 */ Component::GUI::AtkImageNode* ImageNode;
    /*       */ byte _gap_0x278[0x4];
    /* 0x27C */ unsigned __int16 Width;
    /*       */ byte _gap_0x27E[0x2];
    /* 0x280 */ unsigned __int16 Height;
    /*       */ byte _gap_0x282[0x2];
    /*       */ byte _gap_0x284[0x4];
    /*       */ byte _gap_0x288[0x8];
};

struct Client::UI::AddonItemInspectionList /* Size=0x1230 */
{
    /* 0x0000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*        */ byte _gap_0x220[0x1010];
};

struct Client::UI::AddonItemInspectionResult /* Size=0x2F8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0xD8];
};

struct Client::UI::AddonItemSearchResult /* Size=0x3D0 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentIcon* ItemIcon;
    /* 0x228 */ Component::GUI::AtkTextNode* ItemName;
    /*       */ byte _gap_0x230[0x18];
    /* 0x248 */ Component::GUI::AtkComponentButton* History;
    /* 0x250 */ Component::GUI::AtkComponentButton* AdvancedSearch;
    /*       */ byte _gap_0x258[0x8];
    /* 0x260 */ Component::GUI::AtkComponentList* Results;
    /* 0x268 */ Component::GUI::AtkTextNode* HitsMessage;
    /* 0x270 */ Component::GUI::AtkTextNode* ErrorMessage;
    /*       */ byte _gap_0x278[0x158];
};

struct Client::UI::AddonJournalDetail /* Size=0x2F8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x10];
    /* 0x230 */ Component::GUI::AtkComponentScrollBar* ScrollBarNode;
    /* 0x238 */ Component::GUI::AtkComponentGuildLeveCard* GuildLeveCardNode;
    /* 0x240 */ Component::GUI::AtkTextNode* DutyNameTextNode;
    /* 0x248 */ Component::GUI::AtkTextNode* DutyLevelTextNode;
    /* 0x250 */ Component::GUI::AtkImageNode* DutyCategoryImageNode;
    /* 0x258 */ Component::GUI::AtkImageNode* DutyCategoryBackgroundImageNode;
    /* 0x260 */ Component::GUI::AtkImageNode* GuildLeveCardBackgroundImageNode;
    /* 0x268 */ Component::GUI::AtkResNode* RewardsReceivedResNode;
    /* 0x270 */ Component::GUI::AtkTextNode* RewardsReceivedTextNode;
    /* 0x278 */ Component::GUI::AtkResNode* ButtonsResNode;
    /* 0x280 */ Component::GUI::AtkComponentButton* AcceptMapButton;
    /* 0x288 */ Component::GUI::AtkComponentButton* InitiateButton;
    /* 0x290 */ Component::GUI::AtkComponentButton* AbandonDeclineButton;
    /* 0x298 */ Component::GUI::AtkResNode* AtkResNode298;
    /* 0x2A0 */ Component::GUI::AtkImageNode* QuestImageNode;
    /* 0x2A8 */ Component::GUI::AtkTextNode* AtkTextNode2A8;
    /* 0x2B0 */ Component::GUI::AtkTextNode* RequirementsNotMetLabelTextNode;
    /* 0x2B8 */ Component::GUI::AtkTextNode* RequirementsNotMetTextNode;
    /* 0x2C0 */ Component::GUI::AtkTextNode* AtkTextNode2C0;
    /* 0x2C8 */ Component::GUI::AtkComponentButton* AtkComponentButton2C8;
    /* 0x2D0 */ Component::GUI::AtkComponentJournalCanvas* JournalCanvasNode;
    /*       */ byte _gap_0x2D8[0x20];
};

struct Client::UI::AddonJournalResult /* Size=0x288 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkImageNode* AtkImageNode220;
    /* 0x228 */ Component::GUI::AtkImageNode* AtkImageNode228;
    /* 0x230 */ Component::GUI::AtkImageNode* AtkImageNode230;
    /* 0x238 */ Component::GUI::AtkComponentGuildLeveCard* AtkComponentGuildLeveCard238;
    /* 0x240 */ Component::GUI::AtkComponentButton* CompleteButton;
    /* 0x248 */ Component::GUI::AtkComponentButton* DeclineButton;
    /* 0x250 */ Component::GUI::AtkTextNode* AtkTextNode250;
    /* 0x258 */ Component::GUI::AtkTextNode* AtkTextNode258;
    /* 0x260 */ Component::GUI::AtkImageNode* AtkImageNode260;
    /* 0x268 */ Component::GUI::AtkComponentJournalCanvas* AtkComponentJournalCanvas268;
    /*       */ byte _gap_0x270[0x18];
};

struct Client::UI::AddonLookingForGroupDetail /* Size=0x3E8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x28];
    /* 0x248 */ Component::GUI::AtkComponentButton* JoinPartyButton;
    /* 0x250 */ byte JoinAllianceButtons[0x30];
    /* 0x280 */ Component::GUI::AtkComponentButton* SendTellButton;
    /* 0x288 */ Component::GUI::AtkComponentButton* AllianceBackButton;
    /* 0x290 */ Component::GUI::AtkComponentButton* BackButton;
    /*       */ byte _gap_0x298[0x30];
    /* 0x2C8 */ Component::GUI::AtkImageNode* LookingForGroupImageNode;
    /* 0x2D0 */ Component::GUI::AtkTextNode* PartyLeaderTextNode;
    /* 0x2D8 */ Component::GUI::AtkTextNode* LocationTextNode;
    /* 0x2E0 */ Component::GUI::AtkTextNode* TimeRemainingTextNode;
    /* 0x2E8 */ Component::GUI::AtkTextNode* DutyNameTextNode;
    union {
    /* 0x2F0 */ Component::GUI::AtkTextNode* ItemLevelTextNode;
    /* 0x2F0 */ Component::GUI::AtkTextNode* StatusTextNode;
    } _union_0x2F0;
    /*       */ byte _gap_0x2F8[0x8];
    /* 0x300 */ Component::GUI::AtkTextNode* DescriptionTextNode;
    /* 0x308 */ Client::System::String::Utf8String DescriptionString;
    /* 0x370 */ Client::System::String::Utf8String CategoriesString;
    /*       */ byte _gap_0x3D8[0x10];
};

struct Client::UI::AddonLotteryDaily::GameTileRow /* Size=0x18 */
{
    /* 0x00 */ Component::GUI::AtkComponentCheckBox* Col1;
    /* 0x08 */ Component::GUI::AtkComponentCheckBox* Col2;
    /* 0x10 */ Component::GUI::AtkComponentCheckBox* Col3;
};

struct Client::UI::AddonLotteryDaily::GameTileBoard /* Size=0x48 */
{
    /* 0x00 */ Client::UI::AddonLotteryDaily::GameTileRow Row1;
    /* 0x18 */ Client::UI::AddonLotteryDaily::GameTileRow Row2;
    /* 0x30 */ Client::UI::AddonLotteryDaily::GameTileRow Row3;
};

struct Client::UI::AddonLotteryDaily::LaneTileSelector /* Size=0x40 */
{
    /* 0x00 */ Component::GUI::AtkComponentRadioButton* MajorDiagonal;
    /* 0x08 */ Component::GUI::AtkComponentRadioButton* Col1;
    /* 0x10 */ Component::GUI::AtkComponentRadioButton* Col2;
    /* 0x18 */ Component::GUI::AtkComponentRadioButton* Col3;
    /* 0x20 */ Component::GUI::AtkComponentRadioButton* MinorDiagonal;
    /* 0x28 */ Component::GUI::AtkComponentRadioButton* Row1;
    /* 0x30 */ Component::GUI::AtkComponentRadioButton* Row2;
    /* 0x38 */ Component::GUI::AtkComponentRadioButton* Row3;
};

struct Client::UI::AddonLotteryDaily::GameNumberRow /* Size=0xC */
{
    /* 0x0 */ __int32 Col1;
    /* 0x4 */ __int32 Col2;
    /* 0x8 */ __int32 Col3;
};

struct Client::UI::AddonLotteryDaily::GameBoardNumbers /* Size=0x24 */
{
    /* 0x00 */ Client::UI::AddonLotteryDaily::GameNumberRow Row1;
    /* 0x0C */ Client::UI::AddonLotteryDaily::GameNumberRow Row2;
    /* 0x18 */ Client::UI::AddonLotteryDaily::GameNumberRow Row3;
};

struct Client::UI::AddonLotteryDaily /* Size=0x408 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Client::UI::AddonLotteryDaily::GameTileBoard GameBoard;
    /* 0x268 */ Client::UI::AddonLotteryDaily::LaneTileSelector LaneSelector;
    /* 0x2A8 */ Component::GUI::AtkComponentBase* UnkCompBase2A8;
    /* 0x2B0 */ Component::GUI::AtkComponentBase* UnkCompBase2B0;
    /* 0x2B8 */ Component::GUI::AtkComponentBase* UnkCompBase2B8;
    /* 0x2C0 */ Component::GUI::AtkComponentBase* UnkCompBase2C0;
    /* 0x2C8 */ Component::GUI::AtkComponentBase* UnkCompBase2C8;
    /* 0x2D0 */ Component::GUI::AtkComponentBase* UnkCompBase2D0;
    /* 0x2D8 */ Component::GUI::AtkComponentBase* UnkCompBase2D8;
    /* 0x2E0 */ Component::GUI::AtkComponentBase* UnkCompBase2E0;
    /* 0x2E8 */ Component::GUI::AtkComponentBase* UnkCompBase2E8;
    /* 0x2F0 */ Component::GUI::AtkResNode* UnkResNode2F0;
    /* 0x2F8 */ Component::GUI::AtkResNode* UnkResNode2F8;
    /* 0x300 */ Component::GUI::AtkResNode* UnkResNode300;
    /* 0x308 */ Component::GUI::AtkComponentBase* UnkCompBase308;
    /* 0x310 */ Component::GUI::AtkComponentBase* UnkCompBase310;
    /* 0x318 */ Component::GUI::AtkComponentBase* UnkCompBase318;
    /* 0x320 */ Component::GUI::AtkComponentButton* UnkCompButton320;
    /* 0x328 */ Component::GUI::AtkTextNode* UnkTextNode328;
    /* 0x330 */ Component::GUI::AtkComponentBase* UnkCompBase330;
    /* 0x338 */ Component::GUI::AtkComponentBase* UnkCompBase338;
    /* 0x340 */ Component::GUI::AtkComponentBase* UnkCompBase340;
    /* 0x348 */ Component::GUI::AtkComponentBase* UnkCompBase348;
    /* 0x350 */ Component::GUI::AtkComponentBase* UnkCompBase350;
    /* 0x358 */ Component::GUI::AtkComponentBase* UnkCompBase358;
    /* 0x360 */ Component::GUI::AtkComponentBase* UnkCompBase360;
    /* 0x368 */ Component::GUI::AtkComponentBase* UnkCompBase368;
    /* 0x370 */ Component::GUI::AtkComponentBase* UnkCompBase370;
    /* 0x378 */ Component::GUI::AtkComponentBase* UnkCompBase378;
    /* 0x380 */ Component::GUI::AtkComponentBase* UnkCompBase380;
    /* 0x388 */ Component::GUI::AtkComponentBase* UnkCompBase388;
    /* 0x390 */ Component::GUI::AtkComponentBase* UnkCompBase390;
    /* 0x398 */ Component::GUI::AtkComponentBase* UnkCompBase398;
    /* 0x3A0 */ Component::GUI::AtkComponentBase* UnkCompBase3A0;
    /* 0x3A8 */ Component::GUI::AtkComponentBase* UnkCompBase3A8;
    /* 0x3B0 */ Component::GUI::AtkComponentBase* UnkCompBase3B0;
    /* 0x3B8 */ Component::GUI::AtkComponentBase* UnkCompBase3B8;
    /* 0x3C0 */ Component::GUI::AtkComponentBase* UnkCompBase3C0;
    /* 0x3C8 */ Component::GUI::AtkImageNode* UnkImageNode3C8;
    /* 0x3D0 */ __int32 UnkNumber3D0;
    /* 0x3D4 */ __int32 UnkNumber3D4;
    /* 0x3D8 */ Client::UI::AddonLotteryDaily::GameBoardNumbers GameNumbers;
    /* 0x3FC */ __int32 UnkNumber3FC;
    /* 0x400 */ __int32 UnkNumber400;
    /* 0x404 */ __int32 UnkNumber404;
};

struct Client::UI::AddonMacro /* Size=0x30B0 */
{
    /* 0x0000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*        */ byte _gap_0x220[0x98];
    /* 0x02B8 */ byte DragDropComponent[0x320];
    /*        */ byte _gap_0x5D8[0x8];
    /* 0x05E0 */ __int32 DefaultIcon;
    /*        */ byte _gap_0x5E4[0x4];
    /*        */ byte _gap_0x5E8[0x4];
    /* 0x05EC */ __int32 MacroSetIcon[0x64];
    /*        */ byte _gap_0x77C[0x4];
    /* 0x0780 */ byte MacroName[0x28A0];
    /* 0x3020 */ bool MacroCreated[0x64];
    /*        */ byte _gap_0x3084[0x4];
    /*        */ byte _gap_0x3088[0x18];
    /*        */ byte _gap_0x30A0[0x4];
    /* 0x30A4 */ unsigned __int32 SelectedMacroIndex;
    /* 0x30A8 */ unsigned __int32 SelectedPage;
    /*        */ byte _gap_0x30AC[0x4];
};

struct Client::UI::AddonMaterializeDialog /* Size=0x248 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkTextNode* Text;
    /* 0x228 */ Component::GUI::AtkComponentIcon* ItemIcon;
    /* 0x230 */ Component::GUI::AtkTextNode* ItemName;
    /* 0x238 */ Component::GUI::AtkComponentButton* YesButton;
    /* 0x240 */ Component::GUI::AtkComponentButton* NoButton;
};

struct Client::UI::AddonMateriaRetrieveDialog /* Size=0x220 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
};

struct Client::UI::AddonMobHunt /* Size=0x248 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentButton* NextPageButton;
    /* 0x228 */ Component::GUI::AtkComponentButton* PreviousPageButton;
    /* 0x230 */ Component::GUI::AtkComponentButton* OpenMapButton;
    /* 0x238 */ __int32 CurrentPage;
    /*       */ byte _gap_0x23C[0x4];
    /*       */ byte _gap_0x240[0x8];
};

struct Client::UI::AddonNamePlate::BakePlateRenderer /* Size=0x240 */
{
    /*       */ byte _gap_0x0[0x230];
    /* 0x230 */ byte DisableFixedFontResolution;
    /*       */ byte _gap_0x231;
    /*       */ byte _gap_0x232[0x2];
    /*       */ byte _gap_0x234[0x4];
    /*       */ byte _gap_0x238[0x8];
};

struct Client::UI::AddonNamePlate::BakeData /* Size=0xC */
{
    /* 0x0 */ __int16 U;
    /* 0x2 */ __int16 V;
    /* 0x4 */ __int16 Width;
    /* 0x6 */ __int16 Height;
    /*     */ byte _gap_0x8[0x2];
    /* 0xA */ byte Alpha;
    /* 0xB */ byte IsBaked;
};

struct Client::UI::AddonNamePlate::NamePlateObject /* Size=0x78 */
{
    /* 0x00 */ Client::UI::AddonNamePlate::BakeData BakeData;
    /*      */ byte _gap_0xC[0x4];
    /* 0x10 */ Component::GUI::AtkComponentNode* RootNode;
    /* 0x18 */ Component::GUI::AtkResNode* ResNode;
    /* 0x20 */ Component::GUI::AtkTextNode* NameText;
    /* 0x28 */ Component::GUI::AtkImageNode* IconImageNode;
    /* 0x30 */ Component::GUI::AtkImageNode* ImageNode2;
    /* 0x38 */ Component::GUI::AtkImageNode* ImageNode3;
    /* 0x40 */ Component::GUI::AtkImageNode* ImageNode4;
    /* 0x48 */ Component::GUI::AtkImageNode* ImageNode5;
    /* 0x50 */ Component::GUI::AtkCollisionNode* CollisionNode1;
    /* 0x58 */ Component::GUI::AtkCollisionNode* CollisionNode2;
    /* 0x60 */ __int32 Priority;
    /* 0x64 */ __int16 TextW;
    /* 0x66 */ __int16 TextH;
    /* 0x68 */ __int16 IconXAdjust;
    /* 0x6A */ __int16 IconYAdjust;
    /* 0x6C */ byte NameplateKind;
    /* 0x6D */ byte HasHPBar;
    /* 0x6E */ byte ClickThrough;
    /* 0x6F */ byte IsPvpEnemy;
    /* 0x70 */ byte NeedsToBeBaked;
    /*      */ byte _gap_0x71;
    /*      */ byte _gap_0x72[0x2];
    /*      */ byte _gap_0x74[0x4];
};

struct Client::UI::AddonNamePlate /* Size=0x470 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Client::UI::AddonNamePlate::BakePlateRenderer BakePlate;
    /* 0x460 */ Client::UI::AddonNamePlate::NamePlateObject* NamePlateObjectArray;
    /* 0x468 */ byte DoFullUpdate;
    /*       */ byte _gap_0x469;
    /* 0x46A */ unsigned __int16 AlternatePartId;
    /*       */ byte _gap_0x46C[0x4];
};

struct Client::UI::AddonNeedGreed /* Size=0x728 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x8];
    /* 0x228 */ byte Items[0x500];
};

struct Client::UI::AddonPartyList::PartyListMemberStruct::StatusIcons /* Size=0x50 */
{
    /* 0x00 */ Component::GUI::AtkComponentIconText* StatusIcon0;
    /* 0x08 */ Component::GUI::AtkComponentIconText* StatusIcon1;
    /* 0x10 */ Component::GUI::AtkComponentIconText* StatusIcon2;
    /* 0x18 */ Component::GUI::AtkComponentIconText* StatusIcon3;
    /* 0x20 */ Component::GUI::AtkComponentIconText* StatusIcon4;
    /* 0x28 */ Component::GUI::AtkComponentIconText* StatusIcon5;
    /* 0x30 */ Component::GUI::AtkComponentIconText* StatusIcon6;
    /* 0x38 */ Component::GUI::AtkComponentIconText* StatusIcon7;
    /* 0x40 */ Component::GUI::AtkComponentIconText* StatusIcon8;
    /* 0x48 */ Component::GUI::AtkComponentIconText* StatusIcon9;
};

struct Client::UI::AddonPartyList::PartyListMemberStruct /* Size=0xF8 */
{
    /* 0x00 */ Client::UI::AddonPartyList::PartyListMemberStruct::StatusIcons StatusIcon;
    /* 0x50 */ Component::GUI::AtkComponentBase* PartyMemberComponent;
    /* 0x58 */ Component::GUI::AtkTextNode* IconBottomLeftText;
    /* 0x60 */ Component::GUI::AtkResNode* NameAndBarsContainer;
    /* 0x68 */ Component::GUI::AtkTextNode* GroupSlotIndicator;
    /* 0x70 */ Component::GUI::AtkTextNode* Name;
    /* 0x78 */ Component::GUI::AtkTextNode* CastingActionName;
    /* 0x80 */ Component::GUI::AtkImageNode* CastingProgressBar;
    /* 0x88 */ Component::GUI::AtkImageNode* CastingProgressBarBackground;
    /* 0x90 */ Component::GUI::AtkResNode* EmnityBarContainer;
    /* 0x98 */ Component::GUI::AtkNineGridNode* EmnityBarFill;
    /* 0xA0 */ Component::GUI::AtkImageNode* ClassJobIcon;
    /* 0xA8 */ void* UnknownA8;
    /* 0xB0 */ Component::GUI::AtkImageNode* UnknownImageB0;
    /* 0xB8 */ Component::GUI::AtkComponentBase* HPGaugeComponent;
    /* 0xC0 */ Component::GUI::AtkComponentGaugeBar* HPGaugeBar;
    /* 0xC8 */ Component::GUI::AtkComponentGaugeBar* MPGaugeBar;
    /* 0xD0 */ Component::GUI::AtkResNode* TargetGlowContainer;
    /* 0xD8 */ Component::GUI::AtkNineGridNode* ClickFlash;
    /* 0xE0 */ Component::GUI::AtkNineGridNode* TargetGlow;
    /*      */ byte _gap_0xE8[0x8];
    /* 0xF0 */ byte EmnityByte;
    /*      */ byte _gap_0xF1;
    /*      */ byte _gap_0xF2[0x2];
    /*      */ byte _gap_0xF4[0x4];
};

struct Client::UI::AddonPartyList::PartyMembers /* Size=0x7C0 */
{
    /* 0x000 */ Client::UI::AddonPartyList::PartyListMemberStruct PartyMember0;
    /* 0x0F8 */ Client::UI::AddonPartyList::PartyListMemberStruct PartyMember1;
    /* 0x1F0 */ Client::UI::AddonPartyList::PartyListMemberStruct PartyMember2;
    /* 0x2E8 */ Client::UI::AddonPartyList::PartyListMemberStruct PartyMember3;
    /* 0x3E0 */ Client::UI::AddonPartyList::PartyListMemberStruct PartyMember4;
    /* 0x4D8 */ Client::UI::AddonPartyList::PartyListMemberStruct PartyMember5;
    /* 0x5D0 */ Client::UI::AddonPartyList::PartyListMemberStruct PartyMember6;
    /* 0x6C8 */ Client::UI::AddonPartyList::PartyListMemberStruct PartyMember7;
};

struct Client::UI::AddonPartyList::TrustMembers /* Size=0x6C8 */
{
    /* 0x000 */ Client::UI::AddonPartyList::PartyListMemberStruct Trust0;
    /* 0x0F8 */ Client::UI::AddonPartyList::PartyListMemberStruct Trust1;
    /* 0x1F0 */ Client::UI::AddonPartyList::PartyListMemberStruct Trust2;
    /* 0x2E8 */ Client::UI::AddonPartyList::PartyListMemberStruct Trust3;
    /* 0x3E0 */ Client::UI::AddonPartyList::PartyListMemberStruct Trust4;
    /* 0x4D8 */ Client::UI::AddonPartyList::PartyListMemberStruct Trust5;
    /* 0x5D0 */ Client::UI::AddonPartyList::PartyListMemberStruct Trust6;
};

struct Client::UI::AddonPartyList /* Size=0x13D8 */
{
    /* 0x0000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x0220 */ Client::UI::AddonPartyList::PartyMembers PartyMember;
    /* 0x09E0 */ Client::UI::AddonPartyList::TrustMembers TrustMember;
    /* 0x10A8 */ Client::UI::AddonPartyList::PartyListMemberStruct Chocobo;
    /* 0x11A0 */ Client::UI::AddonPartyList::PartyListMemberStruct Pet;
    /* 0x1298 */ unsigned __int32 PartyClassJobIconId[0x8];
    /* 0x12B8 */ unsigned __int32 TrustClassJobIconId[0x7];
    /* 0x12D4 */ unsigned __int32 ChocoboIconId;
    /* 0x12D8 */ unsigned __int32 PetIconId;
    /*        */ byte _gap_0x12DC[0x4];
    /*        */ byte _gap_0x12E0[0x80];
    /* 0x1360 */ __int16 Edited[0x11];
    /*        */ byte _gap_0x1382[0x2];
    /*        */ byte _gap_0x1384[0x4];
    /* 0x1388 */ Component::GUI::AtkNineGridNode* BackgroundNineGridNode;
    /* 0x1390 */ Component::GUI::AtkTextNode* PartyTypeTextNode;
    /* 0x1398 */ Component::GUI::AtkResNode* LeaderMarkResNode;
    /* 0x13A0 */ Component::GUI::AtkResNode* MpBarSpecialResNode;
    /* 0x13A8 */ Component::GUI::AtkTextNode* MpBarSpecialTextNode;
    /* 0x13B0 */ __int32 MemberCount;
    /* 0x13B4 */ __int32 TrustCount;
    /* 0x13B8 */ __int32 EnmityLeaderIndex;
    /* 0x13BC */ __int32 HideWhenSolo;
    /* 0x13C0 */ __int32 HoveredIndex;
    /* 0x13C4 */ __int32 TargetedIndex;
    /* 0x13C8 */ __int32 Unknown1410;
    /* 0x13CC */ __int32 Unknown1414;
    /* 0x13D0 */ byte Unknown1418;
    /* 0x13D1 */ byte PetCount;
    /* 0x13D2 */ byte ChocoboCount;
    /*        */ byte _gap_0x13D3;
    /*        */ byte _gap_0x13D4[0x4];
};

struct Client::UI::AddonRaceChocoboResult /* Size=0x2C8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x48];
    /* 0x268 */ Component::GUI::AtkComponentButton* LeaveButton;
    /*       */ byte _gap_0x270[0x58];
};

struct Client::UI::AddonRaidFinder /* Size=0xEF0 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x68];
    /* 0x288 */ Component::GUI::AtkComponentList* DutyList;
    /* 0x290 */ Component::GUI::AtkComponentNode* CategoryDescriptionComponent;
    /* 0x298 */ Component::GUI::AtkComponentScrollBar* CategoryDescriptionScrollBar;
    /* 0x2A0 */ Component::GUI::AtkTextNode* ItemLevelText;
    /* 0x2A8 */ Component::GUI::AtkComponentButton* UnselectButton;
    /* 0x2B0 */ Component::GUI::AtkComponentDropDownList* OrderByDropDownList;
    /* 0x2B8 */ Component::GUI::AtkComponentButton* DutyTypeButton;
    /*       */ byte _gap_0x2C0[0xB8];
    /* 0x378 */ Client::System::String::Utf8String RaidsTooltipString;
    /* 0x3E0 */ Client::System::String::Utf8String TrialsTooltipString;
    /* 0x448 */ Client::System::String::Utf8String UltimatesTooltipString;
    /*       */ byte _gap_0x4B0[0x20];
    /*       */ byte _gap_0x4D0[0x4];
    /* 0x4D4 */ __int32 HighlightedRow;
    /*       */ byte _gap_0x4D8[0x4];
    /* 0x4DC */ __int32 NumDisplayedEntries;
    /* 0x4E0 */ __int32 SelectedTab;
    /*       */ byte _gap_0x4E4[0x4];
    /* 0x4E8 */ byte EntryInfoArray[0xA00];
    /*       */ byte _gap_0xEE8[0x8];
};

enum RaidFinderEntryFlags: byte
{
    AvailableForSelection = 1,
    Selected = 2,
    Locked = 4,
    Ultimate = 8,
    Unreal = 32,
    Extreme = 64
};

struct Client::UI::RaidFinderDutyEntry /* Size=0x140 */
{
    /* 0x000 */ Client::System::String::Utf8String DutyName;
    /* 0x068 */ Client::System::String::Utf8String DutyLevel;
    /* 0x0D0 */ Client::System::String::Utf8String CurrentlyRecruitingPartiesCount;
    /* 0x138 */ Client::UI::RaidFinderEntryFlags Flags;
    /*       */ byte _gap_0x139;
    /*       */ byte _gap_0x13A[0x2];
    /*       */ byte _gap_0x13C[0x4];
};

struct Client::UI::AddonRecipeNote /* Size=0x22D0 */
{
    /* 0x0000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x0220 */ Component::GUI::AtkTextNode* Unk220;
    /* 0x0228 */ Component::GUI::AtkTextNode* Unk228;
    /* 0x0230 */ Component::GUI::AtkTextNode* Unk230;
    /* 0x0238 */ Component::GUI::AtkImageNode* Unk238;
    /*        */ byte _gap_0x240[0x8];
    /* 0x0248 */ Component::GUI::AtkResNode* Unk248;
    /* 0x0250 */ Component::GUI::AtkResNode* Unk250;
    /* 0x0258 */ Component::GUI::AtkResNode* Unk258;
    /* 0x0260 */ Component::GUI::AtkComponentRadioButton* Unk260;
    /* 0x0268 */ Component::GUI::AtkComponentRadioButton* Unk268;
    /* 0x0270 */ Component::GUI::AtkComponentRadioButton* Unk270;
    /* 0x0278 */ Component::GUI::AtkComponentRadioButton* Unk278;
    /* 0x0280 */ Component::GUI::AtkComponentRadioButton* Unk280;
    /* 0x0288 */ Component::GUI::AtkComponentRadioButton* Unk288;
    /* 0x0290 */ Component::GUI::AtkComponentRadioButton* Unk290;
    /* 0x0298 */ Component::GUI::AtkComponentRadioButton* Unk298;
    /* 0x02A0 */ Component::GUI::AtkComponentRadioButton* Unk2A0;
    /*        */ byte _gap_0x2A8[0x28];
    /* 0x02D0 */ Component::GUI::AtkImageNode* Unk2D0;
    /* 0x02D8 */ Component::GUI::AtkImageNode* Unk2D8;
    /* 0x02E0 */ Component::GUI::AtkImageNode* Unk2E0;
    /* 0x02E8 */ Component::GUI::AtkImageNode* Unk2E8;
    /* 0x02F0 */ Component::GUI::AtkImageNode* Unk2F0;
    /* 0x02F8 */ Component::GUI::AtkImageNode* Unk2F8;
    /* 0x0300 */ Component::GUI::AtkImageNode* Unk300;
    /* 0x0308 */ Component::GUI::AtkImageNode* Unk308;
    /* 0x0310 */ Component::GUI::AtkImageNode* Unk310;
    /* 0x0318 */ Component::GUI::AtkComponentButton* TrialSynthesisButton;
    /* 0x0320 */ Component::GUI::AtkComponentButton* QuickSynthesisButton;
    /* 0x0328 */ Component::GUI::AtkComponentButton* SynthesizeButton;
    /* 0x0330 */ Component::GUI::AtkComponentButton* Unk330;
    /* 0x0338 */ Component::GUI::AtkComponentButton* Unk338;
    /* 0x0340 */ Component::GUI::AtkComponentButton* Unk340;
    /* 0x0348 */ Component::GUI::AtkComponentButton* Unk348;
    /* 0x0350 */ Component::GUI::AtkComponentButton* Unk350;
    /* 0x0358 */ Component::GUI::AtkResNode* Unk358;
    /* 0x0360 */ Component::GUI::AtkTextNode* Unk360;
    /* 0x0368 */ Component::GUI::AtkComponentBase* Unk368;
    /* 0x0370 */ Component::GUI::AtkComponentBase* Unk370;
    /* 0x0378 */ Component::GUI::AtkComponentBase* Unk378;
    /* 0x0380 */ Component::GUI::AtkComponentBase* Unk380;
    /* 0x0388 */ Component::GUI::AtkComponentBase* Unk388;
    /* 0x0390 */ Component::GUI::AtkTextNode* Unk390;
    /* 0x0398 */ Component::GUI::AtkTextNode* Unk398;
    /* 0x03A0 */ Component::GUI::AtkTextNode* Unk3A0;
    /* 0x03A8 */ Component::GUI::AtkTextNode* Unk3A8;
    /* 0x03B0 */ Component::GUI::AtkTextNode* Unk3B0;
    /* 0x03B8 */ Component::GUI::AtkTextNode* Unk3B8;
    /* 0x03C0 */ Component::GUI::AtkResNode* Unk3C0;
    /* 0x03C8 */ void* Unk3C8;
    /* 0x03D0 */ Component::GUI::AtkComponentButton* Unk3D0;
    /* 0x03D8 */ Component::GUI::AtkResNode* Unk3D8;
    /* 0x03E0 */ Component::GUI::AtkComponentButton* Unk3E0;
    /* 0x03E8 */ Component::GUI::AtkResNode* Unk3E8;
    /* 0x03F0 */ Component::GUI::AtkResNode* Unk3F0;
    /* 0x03F8 */ void* Unk3F8;
    /* 0x0400 */ void* Unk400;
    /* 0x0408 */ void* Unk408;
    /* 0x0410 */ Client::UI::AddonRecipeNote* this410;
    /* 0x0418 */ void* Unk418;
    /* 0x0420 */ void* Unk420;
    /* 0x0428 */ void* Unk428;
    /* 0x0430 */ Client::UI::AddonRecipeNote* this430;
    /* 0x0438 */ void* Unk438;
    /* 0x0440 */ void* Unk440;
    /* 0x0448 */ void* Unk448;
    /* 0x0450 */ void* Unk450;
    /* 0x0458 */ void* Unk458;
    /* 0x0460 */ void* Unk460;
    /* 0x0468 */ void* Unk468;
    /* 0x0470 */ void* Unk470;
    /* 0x0478 */ Component::GUI::AtkTextNode* Quality;
    /* 0x0480 */ void* Unk480;
    /* 0x0488 */ void* Unk488;
    /* 0x0490 */ void* Unk490;
    /* 0x0498 */ void* Unk498;
    /* 0x04A0 */ void* Unk4A0;
    /* 0x04A8 */ void* Unk4A8;
    /* 0x04B0 */ void* Unk4B0;
    /* 0x04B8 */ void* Unk4B8;
    /* 0x04C0 */ void* Unk4C0;
    /* 0x04C8 */ void* Unk4C8;
    /* 0x04D0 */ void* Unk4D0;
    /* 0x04D8 */ void* Unk4D8;
    /* 0x04E0 */ void* Unk4E0;
    /* 0x04E8 */ void* Unk4E8;
    /* 0x04F0 */ void* Unk4F0;
    /* 0x04F8 */ void* Unk4F8;
    /* 0x0500 */ void* Unk500;
    /* 0x0508 */ void* Unk508;
    /* 0x0510 */ void* Unk510;
    /* 0x0518 */ void* Unk518;
    /* 0x0520 */ void* Unk520;
    /* 0x0528 */ void* Unk528;
    /* 0x0530 */ void* Unk530;
    /* 0x0538 */ void* Unk538;
    /* 0x0540 */ void* Unk540;
    /* 0x0548 */ void* Unk548;
    /* 0x0550 */ void* Unk550;
    /* 0x0558 */ void* Unk558;
    /* 0x0560 */ void* Unk560;
    /*        */ byte _gap_0x568[0x10];
    /* 0x0578 */ void* Unk578;
    /* 0x0580 */ void* Unk580;
    /* 0x0588 */ void* Unk588;
    /* 0x0590 */ void* Unk590;
    /* 0x0598 */ void* Unk598;
    /* 0x05A0 */ void* Unk5A0;
    /* 0x05A8 */ void* Unk5A8;
    /* 0x05B0 */ void* Unk5B0;
    /* 0x05B8 */ void* Unk5B8;
    /* 0x05C0 */ void* Unk5C0;
    /* 0x05C8 */ void* Unk5C8;
    /* 0x05D0 */ void* Unk5D0;
    /*        */ byte _gap_0x5D8[0x10];
    /* 0x05E8 */ void* Unk5E8;
    /* 0x05F0 */ void* Unk5F0;
    /* 0x05F8 */ void* Unk5F8;
    /* 0x0600 */ void* Unk600;
    /* 0x0608 */ void* Unk608;
    /* 0x0610 */ void* Unk610;
    /* 0x0618 */ void* Unk618;
    /* 0x0620 */ void* Unk620;
    /* 0x0628 */ void* Unk628;
    /* 0x0630 */ void* Unk630;
    /* 0x0638 */ void* Unk638;
    /* 0x0640 */ void* Unk640;
    /*        */ byte _gap_0x648[0x10];
    /* 0x0658 */ void* Unk658;
    /* 0x0660 */ void* Unk660;
    /* 0x0668 */ void* Unk668;
    /* 0x0670 */ void* Unk670;
    /* 0x0678 */ void* Unk678;
    /* 0x0680 */ void* Unk680;
    /* 0x0688 */ void* Unk688;
    /* 0x0690 */ void* Unk690;
    /* 0x0698 */ void* Unk698;
    /* 0x06A0 */ void* Unk6A0;
    /* 0x06A8 */ void* Unk6A8;
    /* 0x06B0 */ void* Unk6B0;
    /*        */ byte _gap_0x6B8[0x10];
    /* 0x06C8 */ void* Unk6C8;
    /* 0x06D0 */ void* Unk6D0;
    /* 0x06D8 */ void* Unk6D8;
    /* 0x06E0 */ void* Unk6E0;
    /* 0x06E8 */ void* Unk6E8;
    /* 0x06F0 */ void* Unk6F0;
    /* 0x06F8 */ void* Unk6F8;
    /* 0x0700 */ void* Unk700;
    /* 0x0708 */ void* Unk708;
    /* 0x0710 */ void* Unk710;
    /* 0x0718 */ void* Unk718;
    /* 0x0720 */ void* Unk720;
    /*        */ byte _gap_0x728[0x10];
    /* 0x0738 */ void* Unk738;
    /* 0x0740 */ void* Unk740;
    /* 0x0748 */ void* Unk748;
    /* 0x0750 */ void* Unk750;
    /* 0x0758 */ void* Unk758;
    /* 0x0760 */ void* Unk760;
    /* 0x0768 */ void* Unk768;
    /* 0x0770 */ void* Unk770;
    /* 0x0778 */ void* Unk778;
    /* 0x0780 */ void* Unk780;
    /* 0x0788 */ void* Unk788;
    /* 0x0790 */ void* Unk790;
    /*        */ byte _gap_0x798[0x10];
    /* 0x07A8 */ void* Unk7A8;
    /*        */ byte _gap_0x7B0[0x50];
    /* 0x0800 */ Client::UI::AddonRecipeNote* this800;
    /* 0x0808 */ Component::GUI::AtkStage* Unk808;
    /* 0x0810 */ Component::GUI::AtkComponentTextInput* Unk810;
    /* 0x0818 */ Client::UI::AddonRecipeNote* this818;
    /*        */ byte _gap_0x820[0x330];
    /* 0x0B50 */ char* UnkB50;
    /*        */ byte _gap_0xB58[0x8];
    /* 0x0B60 */ char* UnkB60;
    /*        */ byte _gap_0xB68[0x8];
    /* 0x0B70 */ char* UnkB70;
    /*        */ byte _gap_0xB78[0x8];
    /* 0x0B80 */ char* UnkB80;
    /*        */ byte _gap_0xB88[0x8];
    /* 0x0B90 */ char* UnkB90;
    /*        */ byte _gap_0xB98[0x8];
    /* 0x0BA0 */ char* UnkBA0;
    /*        */ byte _gap_0xBA8[0x8];
    /* 0x0BB0 */ char* UnkBB0;
    /*        */ byte _gap_0xBB8[0x8];
    /* 0x0BC0 */ char* UnkBC0;
    /*        */ byte _gap_0xBC8[0x8];
    /* 0x0BD0 */ char* UnkBD0;
    /*        */ byte _gap_0xBD8[0x8];
    /* 0x0BE0 */ char* UnkBE0;
    /*        */ byte _gap_0xBE8[0x8];
    /* 0x0BF0 */ char* UnkBF0;
    /*        */ byte _gap_0xBF8[0x8];
    /* 0x0C00 */ char* UnkC00;
    /*        */ byte _gap_0xC08[0x8];
    /* 0x0C10 */ char* UnkC10;
    /*        */ byte _gap_0xC18[0x1520];
    /* 0x2138 */ char* Unk2138;
    /* 0x2140 */ char* Unk2140;
    /* 0x2148 */ char* Unk2148;
    /* 0x2150 */ char* Unk2150;
    /* 0x2158 */ char* Unk2158;
    /* 0x2160 */ char* Unk2160;
    /* 0x2168 */ char* Unk2168;
    /* 0x2170 */ char* Unk2170;
    /* 0x2178 */ char* Unk2178;
    /*        */ byte _gap_0x2180[0x150];
};

struct Client::UI::AddonReconstructionBox /* Size=0x440 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x38];
    /* 0x258 */ byte DonationInfoArray[0x1E0];
    /* 0x438 */ __int32 ItemHovered;
    /*       */ byte _gap_0x43C[0x4];
};

struct Client::UI::AddonItemDonationInfo /* Size=0x30 */
{
    /* 0x00 */ void* UnkPtr1;
    /* 0x08 */ void* UnkPtr2;
    /* 0x10 */ void* UnkPtr3;
    /* 0x18 */ void* UnkPtr4;
    /* 0x20 */ void* UnkPtr5;
    /*      */ byte _gap_0x28[0x4];
    /* 0x2C */ __int32 UnkValue1;
};

struct Client::UI::AddonRelicNoteBook::TargetNode /* Size=0x28 */
{
    /* 0x00 */ Component::GUI::AtkComponentCheckBox* CheckBox;
    /* 0x08 */ Component::GUI::AtkResNode* ResNode;
    /* 0x10 */ Component::GUI::AtkImageNode* ImageNode;
    /* 0x18 */ Component::GUI::AtkTextNode* CounterTextNode;
    /*      */ byte _gap_0x20[0x8];
};

struct Client::UI::AddonRelicNoteBook /* Size=0xAA8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkImageNode* CornerImage;
    /* 0x228 */ Component::GUI::AtkComponentBase* WeaponImageContainer;
    /* 0x230 */ Component::GUI::AtkImageNode* WeaponImage;
    /* 0x238 */ Component::GUI::AtkTextNode* WeaponText;
    /* 0x240 */ Component::GUI::AtkTextNode* RewardText;
    /* 0x248 */ Component::GUI::AtkTextNode* RewardTextAmount;
    /* 0x250 */ Component::GUI::AtkComponentList* CategoryList;
    /* 0x258 */ Component::GUI::AtkResNode* EnemyContainer;
    /* 0x260 */ Client::UI::AddonRelicNoteBook::TargetNode Enemy0;
    /* 0x288 */ Client::UI::AddonRelicNoteBook::TargetNode Enemy1;
    /* 0x2B0 */ Client::UI::AddonRelicNoteBook::TargetNode Enemy2;
    /* 0x2D8 */ Client::UI::AddonRelicNoteBook::TargetNode Enemy3;
    /* 0x300 */ Client::UI::AddonRelicNoteBook::TargetNode Enemy4;
    /* 0x328 */ Client::UI::AddonRelicNoteBook::TargetNode Enemy5;
    /* 0x350 */ Client::UI::AddonRelicNoteBook::TargetNode Enemy6;
    /* 0x378 */ Client::UI::AddonRelicNoteBook::TargetNode Enemy7;
    /* 0x3A0 */ Client::UI::AddonRelicNoteBook::TargetNode Enemy8;
    /* 0x3C8 */ Client::UI::AddonRelicNoteBook::TargetNode Enemy9;
    /* 0x3F0 */ Component::GUI::AtkResNode* DungeonContainer;
    /* 0x3F8 */ Client::UI::AddonRelicNoteBook::TargetNode Dungeon0;
    /* 0x420 */ Client::UI::AddonRelicNoteBook::TargetNode Dungeon1;
    /* 0x448 */ Client::UI::AddonRelicNoteBook::TargetNode Dungeon2;
    /*       */ byte _gap_0x470[0x118];
    /* 0x588 */ Component::GUI::AtkResNode* FateContainer;
    /* 0x590 */ Client::UI::AddonRelicNoteBook::TargetNode Fate0;
    /* 0x5B8 */ Client::UI::AddonRelicNoteBook::TargetNode Fate1;
    /* 0x5E0 */ Client::UI::AddonRelicNoteBook::TargetNode Fate2;
    /*       */ byte _gap_0x608[0x118];
    /* 0x720 */ Component::GUI::AtkResNode* LeveContainer;
    /* 0x728 */ Client::UI::AddonRelicNoteBook::TargetNode Leve0;
    /* 0x750 */ Client::UI::AddonRelicNoteBook::TargetNode Leve1;
    /* 0x778 */ Client::UI::AddonRelicNoteBook::TargetNode Leve2;
    /*       */ byte _gap_0x7A0[0x118];
    /* 0x8B8 */ Component::GUI::AtkTextNode* TargetText;
    /* 0x8C0 */ Component::GUI::AtkTextNode* TargetLocationText;
    /*       */ byte _gap_0x8C8[0x1E0];
};

struct Client::UI::AddonRepair /* Size=0xF7A0 */
{
    /* 0x0000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*        */ byte _gap_0x220[0x8];
    /* 0x0228 */ Component::GUI::AtkTextNode* UnusedText1;
    /* 0x0230 */ Component::GUI::AtkTextNode* JobLevel;
    /* 0x0238 */ Component::GUI::AtkImageNode* JobIcon;
    /* 0x0240 */ Component::GUI::AtkTextNode* JobName;
    /* 0x0248 */ Component::GUI::AtkTextNode* UnusedText2;
    /* 0x0250 */ Component::GUI::AtkComponentDropDownList* Dropdown;
    /* 0x0258 */ Component::GUI::AtkComponentButton* RepairAllButton;
    /* 0x0260 */ Component::GUI::AtkResNode* HeaderContainer;
    /* 0x0268 */ Component::GUI::AtkTextNode* UnusedText3;
    /* 0x0270 */ Component::GUI::AtkTextNode* NothingToRepairText;
    /* 0x0278 */ Component::GUI::AtkComponentList* ItemList;
    /*        */ byte _gap_0x280[0xF520];
};

struct Client::UI::AddonRequest /* Size=0x2E0 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkCollisionNode* AtkCollisionNode220;
    /* 0x228 */ Component::GUI::AtkComponentIcon* AtkComponentIcon228;
    /* 0x230 */ Component::GUI::AtkComponentIcon* AtkComponentIcon230;
    /* 0x238 */ Component::GUI::AtkComponentIcon* AtkComponentIcon238;
    /* 0x240 */ Component::GUI::AtkComponentIcon* AtkComponentIcon240;
    /* 0x248 */ Component::GUI::AtkComponentIcon* AtkComponentIcon248;
    /* 0x250 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop250;
    /* 0x258 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop258;
    /* 0x260 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop260;
    /* 0x268 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop268;
    /* 0x270 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop270;
    /* 0x278 */ Component::GUI::AtkComponentButton* HandOverButton;
    /* 0x280 */ Component::GUI::AtkComponentButton* CancelButton;
    /* 0x288 */ Component::GUI::AtkComponentIcon* AtkComponentIcon288;
    /* 0x290 */ Component::GUI::AtkComponentIcon* AtkComponentIcon290;
    /* 0x298 */ Component::GUI::AtkComponentIcon* AtkComponentIcon298;
    /* 0x2A0 */ Component::GUI::AtkComponentIcon* AtkComponentIcon2A0;
    /* 0x2A8 */ Component::GUI::AtkComponentIcon* AtkComponentIcon2A8;
    /* 0x2B0 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop2B0;
    /* 0x2B8 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop2B8;
    /* 0x2C0 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop2C0;
    /* 0x2C8 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop2C8;
    /* 0x2D0 */ Component::GUI::AtkComponentDragDrop* AtkComponentDragDrop2D0;
    /* 0x2D8 */ __int32 EntryCount;
    /*       */ byte _gap_0x2DC[0x4];
};

struct Client::UI::AddonRetainerItemTransferList /* Size=0x2C8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkTextNode* SomeText;
    /* 0x228 */ Component::GUI::AtkComponentButton* ConfirmButton;
    /* 0x230 */ Component::GUI::AtkComponentButton* CancelButton;
    /* 0x238 */ byte ListItems[0xA];
    /*       */ byte _gap_0x242[0x2];
    /*       */ byte _gap_0x244[0x4];
    /*       */ byte _gap_0x248[0x80];
};

struct Client::UI::AddonRetainerItemTransferProgress /* Size=0x240 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkTextNode* EntrustAllItemsButton;
    /* 0x228 */ Component::GUI::AtkComponentButton* CloseWindowButton;
    /* 0x230 */ Component::GUI::AtkResNode* ProgressBar;
    /* 0x238 */ unsigned __int16 Progress;
    /*       */ byte _gap_0x23A[0x2];
    /*       */ byte _gap_0x23C[0x4];
};

struct Client::UI::AddonRetainerList::AddonRetainerListVTable /* Size=0x180 */
{
    /*       */ byte _gap_0x0[0x178];
    /* 0x178 */ __int64 OnSetup;
};

struct Client::UI::AddonRetainerList /* Size=0x220 */
{
    union {
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x000 */ Client::UI::AddonRetainerList::AddonRetainerListVTable* VTable;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x218];
};

struct Client::UI::AddonRetainerSell /* Size=0x278 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentButton* Confirm;
    /* 0x228 */ Component::GUI::AtkComponentButton* Cancel;
    /* 0x230 */ Component::GUI::AtkComponentButton* ComparePrices;
    /* 0x238 */ Component::GUI::AtkComponentIcon* ItemIcon;
    /*       */ byte _gap_0x240[0x8];
    /* 0x248 */ Component::GUI::AtkComponentNumericInput* Quantity;
    /* 0x250 */ Component::GUI::AtkComponentNumericInput* AskingPrice;
    /* 0x258 */ Component::GUI::AtkTextNode* ItemName;
    /* 0x260 */ Component::GUI::AtkTextNode* Total;
    /* 0x268 */ Component::GUI::AtkTextNode* Tax;
    /*       */ byte _gap_0x270[0x8];
};

struct Client::UI::AddonRetainerTaskAsk::AddonRetainerTaskAskVTable /* Size=0x180 */
{
    /*       */ byte _gap_0x0[0x178];
    /* 0x178 */ __int64 OnSetup;
};

struct Client::UI::AddonRetainerTaskAsk /* Size=0x2B8 */
{
    union {
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x000 */ Client::UI::AddonRetainerTaskAsk::AddonRetainerTaskAskVTable* VTable;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x2A0];
    /* 0x2A8 */ Component::GUI::AtkComponentButton* AssignButton;
    /* 0x2B0 */ Component::GUI::AtkComponentButton* ReturnButton;
};

struct Client::UI::AddonRetainerTaskList::AddonRetainerTaskListVTable /* Size=0x180 */
{
    /*       */ byte _gap_0x0[0x178];
    /* 0x178 */ __int64 OnSetup;
};

struct Client::UI::AddonRetainerTaskList /* Size=0x220 */
{
    union {
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x000 */ Client::UI::AddonRetainerTaskList::AddonRetainerTaskListVTable* VTable;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x218];
};

struct Client::UI::AddonRetainerTaskResult::AddonRetainerTaskResultVTable /* Size=0x180 */
{
    /*       */ byte _gap_0x0[0x178];
    /* 0x178 */ __int64 OnSetup;
};

struct Client::UI::AddonRetainerTaskResult /* Size=0x258 */
{
    union {
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x000 */ Client::UI::AddonRetainerTaskResult::AddonRetainerTaskResultVTable* VTable;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x238];
    /* 0x240 */ Component::GUI::AtkComponentButton* ReassignButton;
    /* 0x248 */ Component::GUI::AtkComponentButton* ConfirmButton;
    /*       */ byte _gap_0x250[0x8];
};

struct Client::UI::AddonSalvageDialog /* Size=0x250 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x8];
    /* 0x228 */ Component::GUI::AtkComponentButton* DesynthesizeButton;
    /* 0x230 */ Component::GUI::AtkComponentCheckBox* CheckBox;
    /*       */ byte _gap_0x238[0x8];
    /* 0x240 */ Component::GUI::AtkComponentCheckBox* CheckBox2;
    /* 0x248 */ bool BulkDesynthEnabled;
    /*       */ byte _gap_0x249;
    /*       */ byte _gap_0x24A[0x2];
    /*       */ byte _gap_0x24C[0x4];
};

enum SalvageItemCategory: __int32
{
    InventoryEquipment = 0,
    InventoryHousing = 1,
    ArmouryMainOff = 2,
    ArmouryHeadBodyHands = 3,
    ArmouryLegsFeet = 4,
    ArmouryNeckEars = 5,
    ArmouryWristsRings = 6,
    Equipped = 7
};

struct Client::UI::AddonSalvageItemSelector /* Size=0x1CB0 */
{
    /* 0x0000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*        */ byte _gap_0x220[0x48];
    /* 0x0268 */ byte ItemData[0x1A40];
    /* 0x1CA8 */ Client::UI::Agent::AgentSalvage::SalvageItemCategory SelectedCategory;
    /* 0x1CAC */ unsigned __int32 ItemCount;
};

struct Client::UI::AddonSatisfactionSupply /* Size=0x670 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x4];
    /* 0x224 */ __int32 HoveredElementIndex;
    /*       */ byte _gap_0x228[0xE0];
    /* 0x308 */ byte DeliveryInfo[0x138];
    /*       */ byte _gap_0x440[0x230];
};

struct Client::UI::AddonDeliveryItemInfo /* Size=0x68 */
{
    /* 0x00 */ unsigned __int32 ItemId;
    /*      */ byte _gap_0x4[0x4];
    /*      */ byte _gap_0x8[0x60];
};

struct Client::UI::PopupMenu /* Size=0x68 */
{
    /* 0x00 */ Component::GUI::AtkEventListener AtkEventListener;
    /* 0x08 */ Component::GUI::AtkStage* AtkStage;
    /* 0x10 */ byte** EntryNames;
    /*      */ byte _gap_0x18[0x18];
    /* 0x30 */ Component::GUI::AtkComponentWindow* Window;
    /* 0x38 */ Component::GUI::AtkComponentList* List;
    /* 0x40 */ Component::GUI::AtkUnitBase* Owner;
    /*      */ byte _gap_0x48[0x4];
    /* 0x4C */ __int32 EntryCount;
    /*      */ byte _gap_0x50[0x18];
};

struct Client::UI::AddonSelectIconString::PopupMenuDerive /* Size=0x68 */
{
    /* 0x00 */ Client::UI::PopupMenu PopupMenu;
};

struct Client::UI::AddonSelectIconString /* Size=0x2A8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x18];
    /* 0x238 */ Client::UI::AddonSelectIconString::PopupMenuDerive PopupMenu;
    /*       */ byte _gap_0x2A0[0x8];
};

struct Client::UI::AddonSelectOk /* Size=0x2A8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkTextNode* PromptText;
    /* 0x228 */ Component::GUI::AtkComponentButton* OkButton;
    /*       */ byte _gap_0x230[0x78];
};

struct Client::UI::AddonSelectString::AddonSelectStringVTable /* Size=0x180 */
{
    /*       */ byte _gap_0x0[0x178];
    /* 0x178 */ __int64 OnSetup;
};

struct Client::UI::AddonSelectString::PopupMenuDerive /* Size=0x70 */
{
    /* 0x00 */ Client::UI::PopupMenu PopupMenu;
    /*      */ byte _gap_0x68[0x8];
};

struct Client::UI::AddonSelectString /* Size=0x2A8 */
{
    union {
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x000 */ Client::UI::AddonSelectString::AddonSelectStringVTable* VTable;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x218];
    /* 0x220 */ Client::UI::AddonSelectString::PopupMenuDerive PopupMenu;
    /*       */ byte _gap_0x290[0x18];
};

struct Client::UI::AddonSelectYesno /* Size=0x2D0 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkTextNode* PromptText;
    /* 0x228 */ Component::GUI::AtkComponentButton* YesButton;
    /* 0x230 */ Component::GUI::AtkComponentButton* NoButton;
    /* 0x238 */ Component::GUI::AtkComponentButton* AtkComponentButton238;
    /* 0x240 */ Component::GUI::AtkResNode* AtkResNode240;
    /* 0x248 */ Component::GUI::AtkResNode* AtkResNode248;
    /*       */ byte _gap_0x250[0x8];
    /* 0x258 */ Component::GUI::AtkResNode* AtkResNode258;
    /* 0x260 */ Component::GUI::AtkComponentButton* AtkComponentButton260;
    /* 0x268 */ Component::GUI::AtkComponentButton* AtkComponentButton268;
    /* 0x270 */ Component::GUI::AtkComponentButton* AtkComponentButton270;
    /* 0x278 */ Component::GUI::AtkComponentHoldButton* AtkComponentHoldButton278;
    /* 0x280 */ Component::GUI::AtkComponentHoldButton* AtkComponentHoldButton280;
    /* 0x288 */ Component::GUI::AtkComponentHoldButton* AtkComponentHoldButton288;
    /* 0x290 */ Component::GUI::AtkComponentCheckBox* ConfirmCheckBox;
    /* 0x298 */ Component::GUI::AtkTextNode* AtkTextNode298;
    /* 0x2A0 */ Component::GUI::AtkComponentBase* AtkComponentBase2A0;
    /*       */ byte _gap_0x2A8[0x28];
};

struct Client::UI::AddonShopCardDialog /* Size=0x230 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentNumericInput* CardQuantityInput;
    /*       */ byte _gap_0x228[0x8];
};

struct Client::UI::AddonSocial /* Size=0x320 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x70];
    /* 0x290 */ Component::GUI::AtkComponentRadioButton* PartyMembersRadioButton;
    /* 0x298 */ Component::GUI::AtkComponentRadioButton* FriendListRadioButton;
    /* 0x2A0 */ Component::GUI::AtkComponentRadioButton* BlacklistRadioButton;
    /* 0x2A8 */ Component::GUI::AtkComponentRadioButton* PlayerSearchRadioButton;
    /* 0x2B0 */ Client::System::String::Utf8String PlayerSearchString;
    /*       */ byte _gap_0x318[0x8];
};

struct Client::UI::AddonSynthesis::CraftEffect /* Size=0x20 */
{
    /* 0x00 */ Component::GUI::AtkComponentBase* Container;
    /* 0x08 */ Component::GUI::AtkImageNode* Image;
    /* 0x10 */ Component::GUI::AtkTextNode* StepsRemaining;
    /* 0x18 */ Component::GUI::AtkTextNode* Name;
};

struct Client::UI::AddonSynthesis /* Size=0x8A8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /*       */ byte _gap_0x220[0x18];
    /* 0x238 */ Component::GUI::AtkComponentButton* QuitButton;
    /* 0x240 */ Component::GUI::AtkComponentButton* CalculationsButton;
    /* 0x248 */ Component::GUI::AtkComponentIcon* ItemIcon;
    /*       */ byte _gap_0x250[0x8];
    /* 0x258 */ Component::GUI::AtkTextNode* ItemName;
    /* 0x260 */ Component::GUI::AtkResNode* DiamondImageNodeContainer;
    /*       */ byte _gap_0x268[0x8];
    /* 0x270 */ Component::GUI::AtkTextNode* Condition;
    /*       */ byte _gap_0x278[0x10];
    /* 0x288 */ Component::GUI::AtkTextNode* CurrentQuality;
    /* 0x290 */ Component::GUI::AtkTextNode* MaxQuality;
    /*       */ byte _gap_0x298[0x20];
    /* 0x2B8 */ Component::GUI::AtkTextNode* HQLiteral;
    /* 0x2C0 */ Component::GUI::AtkTextNode* HQPercentage;
    /* 0x2C8 */ Component::GUI::AtkTextNode* StepNumber;
    /*       */ byte _gap_0x2D0[0x10];
    /* 0x2E0 */ Component::GUI::AtkTextNode* CurrentProgress;
    /* 0x2E8 */ Component::GUI::AtkTextNode* MaxProgress;
    /*       */ byte _gap_0x2F0[0x8];
    /* 0x2F8 */ Component::GUI::AtkTextNode* CurrentDurability;
    /* 0x300 */ Component::GUI::AtkTextNode* StartingDurability;
    /*       */ byte _gap_0x308[0x68];
    /* 0x370 */ Component::GUI::AtkTextNode* CollectabilityLow;
    /* 0x378 */ Component::GUI::AtkTextNode* CollectabilityMid;
    /* 0x380 */ Component::GUI::AtkTextNode* CollectabilityHigh;
    /* 0x388 */ Component::GUI::AtkComponentCheckBox* ToggleCraftEffectPane;
    /*       */ byte _gap_0x390[0x18];
    /* 0x3A8 */ Component::GUI::AtkTextNode* CraftEffectOverflow;
    /* 0x3B0 */ Client::UI::AddonSynthesis::CraftEffect CraftEffect1;
    /* 0x3D0 */ Client::UI::AddonSynthesis::CraftEffect CraftEffect2;
    /* 0x3F0 */ Client::UI::AddonSynthesis::CraftEffect CraftEffect3;
    /* 0x410 */ Client::UI::AddonSynthesis::CraftEffect CraftEffect4;
    /* 0x430 */ Client::UI::AddonSynthesis::CraftEffect CraftEffect5;
    /* 0x450 */ Client::UI::AddonSynthesis::CraftEffect CraftEffect6;
    /* 0x470 */ Client::UI::AddonSynthesis::CraftEffect CraftEffect7;
    /* 0x490 */ Client::UI::AddonSynthesis::CraftEffect CraftEffect8;
    /* 0x4B0 */ Client::UI::AddonSynthesis::CraftEffect CraftEffect9;
    /*       */ byte _gap_0x4D0[0x20];
    /* 0x4F0 */ Client::System::String::Utf8String CraftEffect1HoverText;
    /* 0x558 */ Client::System::String::Utf8String CraftEffect2HoverText;
    /* 0x5C0 */ Client::System::String::Utf8String CraftEffect3HoverText;
    /* 0x628 */ Client::System::String::Utf8String CraftEffect4HoverText;
    /* 0x690 */ Client::System::String::Utf8String CraftEffect5HoverText;
    /* 0x6F8 */ Client::System::String::Utf8String CraftEffect6HoverText;
    /* 0x760 */ Client::System::String::Utf8String CraftEffect7HoverText;
    /* 0x7C8 */ Client::System::String::Utf8String CraftEffect8HoverText;
    /* 0x830 */ Client::System::String::Utf8String CraftEffect9HoverText;
    /*       */ byte _gap_0x898[0x10];
};

struct Client::UI::AddonTalk /* Size=0xE80 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkTextNode* AtkTextNode220;
    /* 0x228 */ Component::GUI::AtkTextNode* AtkTextNode228;
    /* 0x230 */ Component::GUI::AtkResNode* AtkResNode230;
    /* 0x238 */ Component::GUI::AtkTextNode* AtkTextNode238;
    /* 0x240 */ Component::GUI::AtkTextNode* AtkTextNode240;
    /* 0x248 */ Component::GUI::AtkTextNode* AtkTextNode248;
    /*       */ byte _gap_0x250[0x18];
    /* 0x268 */ Client::System::String::Utf8String String268;
    /* 0x2D0 */ Client::System::String::Utf8String String2D0;
    /* 0x338 */ Client::System::String::Utf8String String338;
    /*       */ byte _gap_0x3A0[0x68];
    /* 0x408 */ Client::System::String::Utf8String String408;
    /* 0x470 */ Client::System::String::Utf8String String470;
    /* 0x4D8 */ Client::System::String::Utf8String String4D8;
    /* 0x540 */ Client::System::String::Utf8String String540;
    /*       */ byte _gap_0x5A8[0x870];
    /* 0xE18 */ Component::GUI::AtkEventTarget AtkEventTarget;
    /* 0xE20 */ Component::GUI::AtkEventListenerUnk1 AtkEventListenerUnk;
};

struct Client::UI::AddonTeleport /* Size=0x2D8 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Component::GUI::AtkComponentRadioButton* TabHeaderAll;
    /* 0x228 */ Component::GUI::AtkComponentRadioButton* TabHeaderLaNoscea;
    /* 0x230 */ Component::GUI::AtkComponentRadioButton* TabHeaderBlackShroud;
    /* 0x238 */ Component::GUI::AtkComponentRadioButton* TabHeaderThanalan;
    /* 0x240 */ Component::GUI::AtkComponentRadioButton* TabHeaderIshgard;
    /* 0x248 */ Component::GUI::AtkComponentRadioButton* TabHeaderGyrAbania;
    /* 0x250 */ Component::GUI::AtkComponentRadioButton* TabHeaderFarEast;
    /* 0x258 */ Component::GUI::AtkComponentRadioButton* TabHeaderIlsabard;
    /* 0x260 */ Component::GUI::AtkComponentRadioButton* TabHeaderNorvandt;
    /* 0x268 */ Component::GUI::AtkComponentRadioButton* TabHeaderOther;
    /* 0x270 */ Component::GUI::AtkComponentRadioButton* TabHeaderHistory;
    /* 0x278 */ Component::GUI::AtkComponentRadioButton* TabHeaderFavourite;
    /* 0x280 */ Component::GUI::AtkTextNode* GilCountText;
    /* 0x288 */ Component::GUI::AtkComponentTreeList* TeleportTreeList;
    /* 0x290 */ Component::GUI::AtkComponentListItemRenderer* TeleportTreeListFirstHeader;
    /* 0x298 */ Component::GUI::AtkComponentListItemRenderer* TeleportTreeListFirstItem;
    /* 0x2A0 */ void* UnknownVtbl;
    /* 0x2A8 */ Client::UI::AddonTeleport* Addon;
    /* 0x2B0 */ __int64 UnknownFunction;
    /* 0x2B8 */ Component::GUI::AtkComponentButton* SettingsButton;
    /* 0x2C0 */ Component::GUI::AtkTextNode* AetheryteTicketsText;
    /* 0x2C8 */ unsigned __int32 SelectedTab;
    /* 0x2CC */ unsigned __int32 SelectedTabItemCount;
    /* 0x2D0 */ unsigned __int32 ListTotalCount;
    /* 0x2D4 */ unsigned __int32 Unknown2D4;
};

struct Client::UI::DutySlot /* Size=0x168 */
{
    /* 0x000 */ void** vtbl;
    /* 0x008 */ Client::UI::AddonWeeklyBingo* addon;
    /* 0x010 */ __int32 index;
    /*       */ byte _gap_0x14[0x4];
    /*       */ byte _gap_0x18[0x120];
    /* 0x138 */ Component::GUI::AtkComponentButton* DutyButton;
    /* 0x140 */ Component::GUI::AtkImageNode* DutyImage;
    /* 0x148 */ Component::GUI::AtkResNode* DutyResNode;
    /* 0x150 */ Component::GUI::AtkResNode* ResNode1;
    /* 0x158 */ Component::GUI::AtkTextNode* TextNode;
    /* 0x160 */ Component::GUI::AtkResNode* ResNode2;
};

struct Client::UI::DutySlotList /* Size=0x18E8 */
{
    /* 0x0000 */ void** vtbl;
    /* 0x0008 */ void* addon;
    /*        */ byte _gap_0x10[0x10];
    /*        */ byte _gap_0x20[0x4];
    /* 0x0024 */ unsigned __int32 NumSecondChances;
    /* 0x0028 */ Client::UI::DutySlot DutySlot1;
    /* 0x0190 */ Client::UI::DutySlot DutySlot2;
    /* 0x02F8 */ Client::UI::DutySlot DutySlot3;
    /* 0x0460 */ Client::UI::DutySlot DutySlot4;
    /* 0x05C8 */ Client::UI::DutySlot DutySlot5;
    /* 0x0730 */ Client::UI::DutySlot DutySlot6;
    /* 0x0898 */ Client::UI::DutySlot DutySlot7;
    /* 0x0A00 */ Client::UI::DutySlot DutySlot8;
    /* 0x0B68 */ Client::UI::DutySlot DutySlot9;
    /* 0x0CD0 */ Client::UI::DutySlot DutySlot10;
    /* 0x0E38 */ Client::UI::DutySlot DutySlot11;
    /* 0x0FA0 */ Client::UI::DutySlot DutySlot12;
    /* 0x1108 */ Client::UI::DutySlot DutySlot13;
    /* 0x1270 */ Client::UI::DutySlot DutySlot14;
    /* 0x13D8 */ Client::UI::DutySlot DutySlot15;
    /* 0x1540 */ Client::UI::DutySlot DutySlot16;
    /*        */ byte _gap_0x16A8[0x220];
    /* 0x18C8 */ Component::GUI::AtkComponentButton* SecondChanceButton;
    /* 0x18D0 */ Component::GUI::AtkComponentButton* CancelButton;
    /* 0x18D8 */ Component::GUI::AtkTextNode* SecondChancesRemaining;
    /* 0x18E0 */ Component::GUI::AtkResNode* DutyContainer;
};

struct Client::UI::StringThing /* Size=0x50 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ byte* FullSealsText;
    /* 0x10 */ byte* OneOrMoreLinesText;
    /* 0x18 */ byte* SecondChancePointsText;
    /* 0x20 */ byte* ReceiveSealCompleteText;
    /* 0x28 */ byte* ReceiveSealIncompleteText;
    /* 0x30 */ byte* SecondChanceRetryText;
    /*      */ byte _gap_0x38[0x8];
    /* 0x40 */ void* addon;
    /* 0x48 */ Component::GUI::AtkTextNode* TextNode;
};

struct Client::UI::StickerSlot /* Size=0x58 */
{
    /* 0x00 */ void** vtbl;
    /* 0x08 */ void* addon;
    /* 0x10 */ __int32 index;
    /*      */ byte _gap_0x14[0x4];
    /*      */ byte _gap_0x18[0x8];
    /* 0x20 */ Component::GUI::AtkComponentButton* Button;
    /* 0x28 */ Component::GUI::AtkComponentBase* StickerComponentBase;
    /* 0x30 */ Component::GUI::AtkComponentBase* StickerShadowComponentBase;
    /* 0x38 */ Component::GUI::AtkResNode* StickerResNode;
    /* 0x40 */ Component::GUI::AtkResNode* StickerShadowResNode;
    /* 0x48 */ Component::GUI::AtkComponentBase* StickerSidebarBase;
    /* 0x50 */ Component::GUI::AtkResNode* StickerSidebarResNode;
};

struct Client::UI::StickerSlotList /* Size=0x590 */
{
    /* 0x000 */ void** vtbl;
    /* 0x008 */ void* addon;
    /* 0x010 */ Client::UI::StickerSlot StickerSlot1;
    /* 0x068 */ Client::UI::StickerSlot StickerSlot2;
    /* 0x0C0 */ Client::UI::StickerSlot StickerSlot3;
    /* 0x118 */ Client::UI::StickerSlot StickerSlot4;
    /* 0x170 */ Client::UI::StickerSlot StickerSlot5;
    /* 0x1C8 */ Client::UI::StickerSlot StickerSlot6;
    /* 0x220 */ Client::UI::StickerSlot StickerSlot7;
    /* 0x278 */ Client::UI::StickerSlot StickerSlot8;
    /* 0x2D0 */ Client::UI::StickerSlot StickerSlot9;
    /* 0x328 */ Client::UI::StickerSlot StickerSlot10;
    /* 0x380 */ Client::UI::StickerSlot StickerSlot11;
    /* 0x3D8 */ Client::UI::StickerSlot StickerSlot12;
    /* 0x430 */ Client::UI::StickerSlot StickerSlot13;
    /* 0x488 */ Client::UI::StickerSlot StickerSlot14;
    /* 0x4E0 */ Client::UI::StickerSlot StickerSlot15;
    /* 0x538 */ Client::UI::StickerSlot StickerSlot16;
};

struct Client::UI::AddonWeeklyPuzzle::RewardPanelItem /* Size=0x28 */
{
    /* 0x00 */ Component::GUI::AtkComponentBase* CompBase;
    /* 0x08 */ Component::GUI::AtkResNode* Res;
    /* 0x10 */ Component::GUI::AtkTextNode* NameText;
    /* 0x18 */ Component::GUI::AtkTextNode* RewardText;
    /* 0x20 */ __int64 Unk20;
};

struct Client::UI::AddonWeeklyPuzzle::GameTileItem /* Size=0x30 */
{
    /* 0x00 */ Client::UI::AddonWeeklyPuzzle* self;
    /* 0x08 */ Component::GUI::AtkComponentButton* Button;
    /* 0x10 */ Component::GUI::AtkResNode* RevealedIconResNode;
    /* 0x18 */ Component::GUI::AtkResNode* UnkRes20;
    /* 0x20 */ Component::GUI::AtkResNode* RevealedTileResNode;
    /* 0x28 */ __int64 Unk28;
};

struct Client::UI::AddonWeeklyPuzzle::GameTileRow /* Size=0x120 */
{
    /* 0x000 */ Client::UI::AddonWeeklyPuzzle::GameTileItem Col1;
    /* 0x030 */ Client::UI::AddonWeeklyPuzzle::GameTileItem Col2;
    /* 0x060 */ Client::UI::AddonWeeklyPuzzle::GameTileItem Col3;
    /* 0x090 */ Client::UI::AddonWeeklyPuzzle::GameTileItem Col4;
    /* 0x0C0 */ Client::UI::AddonWeeklyPuzzle::GameTileItem Col5;
    /* 0x0F0 */ Client::UI::AddonWeeklyPuzzle::GameTileItem Col6;
};

struct Client::UI::AddonWeeklyPuzzle::GameTileBoard /* Size=0x6C0 */
{
    /* 0x000 */ Client::UI::AddonWeeklyPuzzle::GameTileRow Row1;
    /* 0x120 */ Client::UI::AddonWeeklyPuzzle::GameTileRow Row2;
    /* 0x240 */ Client::UI::AddonWeeklyPuzzle::GameTileRow Row3;
    /* 0x360 */ Client::UI::AddonWeeklyPuzzle::GameTileRow Row4;
    /* 0x480 */ Client::UI::AddonWeeklyPuzzle::GameTileRow Row5;
    /* 0x5A0 */ Client::UI::AddonWeeklyPuzzle::GameTileRow Row6;
};

struct Client::UI::AddonWeeklyPuzzle /* Size=0xD00 */
{
    /* 0x000 */ Component::GUI::AtkUnitBase AtkUnitBase;
    /* 0x220 */ Client::UI::AddonWeeklyPuzzle::RewardPanelItem RewardPanelCommander;
    /* 0x248 */ Client::UI::AddonWeeklyPuzzle::RewardPanelItem RewardPanelCoffer;
    /* 0x270 */ Client::UI::AddonWeeklyPuzzle::RewardPanelItem RewardPanelGiftBox;
    /* 0x298 */ Client::UI::AddonWeeklyPuzzle::RewardPanelItem RewardPanelDualBlades;
    /* 0x2C0 */ Component::GUI::AtkComponentButton* AtkComponentButton2C0;
    /* 0x2C8 */ Component::GUI::AtkResNode* AtkResNode2C8;
    /* 0x2D0 */ Component::GUI::AtkTextNode* AtkTextNode2D0;
    /* 0x2D8 */ Component::GUI::AtkTextNode* AtkTextNode2D8;
    /* 0x2E0 */ Component::GUI::AtkResNode* AtkResNode2E0;
    /* 0x2E8 */ Component::GUI::AtkTextNode* AtkTextNode2E8;
    /* 0x2F0 */ Component::GUI::AtkTextNode* AtkTextNode2F0;
    /* 0x2F8 */ Client::UI::AddonWeeklyPuzzle::GameTileBoard GameBoard;
    /*       */ byte _gap_0x9B8[0x80];
    /* 0xA38 */ Component::GUI::AtkResNode* AtkResNodeA38;
    /*       */ byte _gap_0xA40[0x108];
    /* 0xB48 */ Client::System::String::Utf8String CommanderStr;
    /* 0xBB0 */ Client::System::String::Utf8String CofferStr;
    /* 0xC18 */ Client::System::String::Utf8String GiftBoxStr;
    /* 0xC80 */ Client::System::String::Utf8String DualBladesStr;
    /*       */ byte _gap_0xCE8[0x18];
};

struct Client::UI::RaptureAtkModule::RaptureAtkModuleVTable /* Size=0x140 */
{
    /*       */ byte _gap_0x0[0x138];
    /* 0x138 */ __int64 SetUiVisibility;
};

enum RaptureAtkModuleFlags: byte
{
    None = 0,
    Unk01 = 1,
    Unk02 = 2,
    UiHidden = 4,
    Unk08 = 8,
    Unk10 = 16,
    Unk20 = 32,
    Unk40 = 64,
    Unk80 = 128
};

struct Client::UI::UI3DModule::MapInfo /* Size=0x18 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int32 MapId;
    /* 0x0C */ __int32 IconId;
    /*      */ byte _gap_0x10[0x2];
    /* 0x12 */ byte Unk_12;
    /*      */ byte _gap_0x13;
    /*      */ byte _gap_0x14[0x4];
};

struct Client::Game::Object::GameObject::GameObjectVTable /* Size=0x1E8 */
{
    /*       */ byte _gap_0x0[0x8];
    /* 0x008 */ __int64 GetObjectID;
    /* 0x010 */ __int64 GetObjectKind;
    /*       */ byte _gap_0x18[0x8];
    /* 0x020 */ __int64 GetIsTargetable;
    /*       */ byte _gap_0x28[0x8];
    /* 0x030 */ __int64 GetName;
    /* 0x038 */ __int64 GetRadius;
    /* 0x040 */ __int64 GetHeight;
    /*       */ byte _gap_0x48[0x38];
    /* 0x080 */ __int64 EnableDraw;
    /* 0x088 */ __int64 DisableDraw;
    /*       */ byte _gap_0x90[0x48];
    /* 0x0D8 */ __int64 GetDrawObject;
    /*       */ byte _gap_0xE0[0x98];
    /* 0x178 */ __int64 GetNpcID;
    /*       */ byte _gap_0x180[0x40];
    /* 0x1C0 */ __int64 IsDead;
    /* 0x1C8 */ __int64 IsNotMounted;
    /*       */ byte _gap_0x1D0[0x10];
    /* 0x1E0 */ __int64 IsCharacter;
};

enum ObjectTargetableFlags: byte
{
    IsTargetable = 2,
    Unk1 = 4
};

struct Client::Graphics::Scene::Object::ObjectVTable /* Size=0x18 */
{
    /*      */ byte _gap_0x0[0x10];
    /* 0x10 */ __int64 GetObjectType;
};

struct Client::Graphics::Scene::Object /* Size=0x80 */
{
    /* 0x00 */ Client::Graphics::Scene::Object::ObjectVTable* VTable;
    /*      */ byte _gap_0x8[0x10];
    /* 0x18 */ Client::Graphics::Scene::Object* ParentObject;
    /* 0x20 */ Client::Graphics::Scene::Object* PreviousSiblingObject;
    /* 0x28 */ Client::Graphics::Scene::Object* NextSiblingObject;
    /* 0x30 */ Client::Graphics::Scene::Object* ChildObject;
    /*      */ byte _gap_0x38[0x18];
    /* 0x50 */ Common::Math::Vector3 Position;
    /* 0x60 */ Common::Math::Quaternion Rotation;
    /* 0x70 */ Common::Math::Vector3 Scale;
};

struct Client::Graphics::Scene::DrawObject /* Size=0x90 */
{
    /* 0x00 */ Client::Graphics::Scene::Object Object;
    /*      */ byte _gap_0x80[0x8];
    /* 0x88 */ byte Flags;
    /*      */ byte _gap_0x89;
    /*      */ byte _gap_0x8A[0x2];
    /*      */ byte _gap_0x8C[0x4];
};

struct Client::Game::Event::LuaActor /* Size=0x80 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ Client::Game::Object::GameObject* Object;
    /* 0x10 */ Client::System::String::Utf8String LuaString;
    /* 0x78 */ Common::Lua::LuaState* LuaState;
};

struct Client::Game::Object::GameObject /* Size=0x1A0 */
{
    /* 0x000 */ Client::Game::Object::GameObject::GameObjectVTable* VTable;
    /*       */ byte _gap_0x8[0x8];
    /* 0x010 */ Common::Math::Vector3 DefaultPosition;
    /* 0x020 */ float DefaultRotation;
    /*       */ byte _gap_0x24[0x4];
    /*       */ byte _gap_0x28[0x8];
    /* 0x030 */ byte Name[0x40];
    /*       */ byte _gap_0x70[0x4];
    /* 0x074 */ unsigned __int32 ObjectID;
    /*       */ byte _gap_0x78[0x8];
    /* 0x080 */ unsigned __int32 DataID;
    /* 0x084 */ unsigned __int32 OwnerID;
    /* 0x088 */ unsigned __int16 ObjectIndex;
    /*       */ byte _gap_0x8A[0x2];
    /* 0x08C */ byte ObjectKind;
    /* 0x08D */ byte SubKind;
    /* 0x08E */ byte Gender;
    /*       */ byte _gap_0x8F;
    /* 0x090 */ byte YalmDistanceFromPlayerX;
    /* 0x091 */ byte TargetStatus;
    /* 0x092 */ byte YalmDistanceFromPlayerZ;
    /*       */ byte _gap_0x93;
    /*       */ byte _gap_0x94;
    /* 0x095 */ Client::Game::Object::ObjectTargetableFlags TargetableStatus;
    /*       */ byte _gap_0x96[0x2];
    /*       */ byte _gap_0x98[0x18];
    /* 0x0B0 */ Common::Math::Vector3 Position;
    /* 0x0C0 */ float Rotation;
    /* 0x0C4 */ float Scale;
    /* 0x0C8 */ float Height;
    /* 0x0CC */ float VfxScale;
    /* 0x0D0 */ float HitboxRadius;
    /*       */ byte _gap_0xD4[0x4];
    /*       */ byte _gap_0xD8[0x18];
    /*       */ byte _gap_0xF0[0x4];
    /* 0x0F4 */ Client::Game::Event::EventId EventId;
    /* 0x0F8 */ unsigned __int32 FateId;
    /*       */ byte _gap_0xFC[0x4];
    /* 0x100 */ Client::Graphics::Scene::DrawObject* DrawObject;
    /*       */ byte _gap_0x108[0x8];
    /* 0x110 */ unsigned __int32 NamePlateIconId;
    /* 0x114 */ __int32 RenderFlags;
    /*       */ byte _gap_0x118[0x40];
    /* 0x158 */ Client::Game::Event::LuaActor* LuaActor;
    /*       */ byte _gap_0x160[0x40];
};

struct Client::UI::UI3DModule::ObjectInfo /* Size=0x60 */
{
    /* 0x00 */ Client::UI::UI3DModule::MapInfo MapInfo;
    /* 0x18 */ Client::Game::Object::GameObject* GameObject;
    /* 0x20 */ Common::Math::Vector3 NamePlatePos;
    /* 0x30 */ Common::Math::Vector3 ObjectPosProjectedScreenSpace;
    /* 0x40 */ float DistanceFromCamera;
    /* 0x44 */ float DistanceFromPlayer;
    /* 0x48 */ unsigned __int32 Unk_48;
    /* 0x4C */ byte NamePlateScale;
    /* 0x4D */ byte NamePlateObjectKind;
    /* 0x4E */ byte NamePlateObjectKindAdjusted;
    /* 0x4F */ byte NamePlateIndex;
    /* 0x50 */ byte Unk_50;
    /* 0x51 */ byte SortPriority;
    /*      */ byte _gap_0x52[0x2];
    /*      */ byte _gap_0x54[0x4];
    /*      */ byte _gap_0x58[0x8];
};

struct Client::UI::UI3DModule /* Size=0x11BE0 */
{
    /*         */ byte _gap_0x0[0x10];
    /* 0x00010 */ Client::UI::UIModule* UIModule;
    /*         */ byte _gap_0x18[0x8];
    /* 0x00020 */ byte ObjectInfoArray[0xE0A0];
    /* 0x0E0C0 */ byte SortedObjectInfoPointerArray[0x12B8];
    /* 0x0F378 */ __int32 SortedObjectInfoCount;
    /*         */ byte _gap_0xF37C[0x4];
    /* 0x0F380 */ byte NamePlateObjectInfoPointerArray[0x190];
    /* 0x0F510 */ __int32 NamePlateObjectInfoCount;
    /*         */ byte _gap_0xF514[0x4];
    /*         */ byte _gap_0xF518[0x20];
    /* 0x0F538 */ byte NamePlateObjectIdList[0x190];
    /* 0x0F6C8 */ byte NamePlateObjectIdList_2[0x190];
    /* 0x0F858 */ byte CharacterObjectInfoPointerArray[0x190];
    /* 0x0F9E8 */ __int32 CharacterObjectInfoCount;
    /*         */ byte _gap_0xF9EC[0x4];
    /* 0x0F9F0 */ byte MapObjectInfoPointerArray[0x220];
    /* 0x0FC10 */ __int32 MapObjectInfoCount;
    /*         */ byte _gap_0xFC14[0x4];
    /* 0x0FC18 */ Client::UI::UI3DModule::ObjectInfo* TargetObjectInfo;
    /* 0x0FC20 */ byte MemberInfoArray[0x780];
    /* 0x103A0 */ byte MemberInfoPointerArray[0x180];
    /* 0x10520 */ __int32 MemberInfoCount;
    /*         */ byte _gap_0x10524[0x4];
    /*         */ byte _gap_0x10528[0x8];
    /* 0x10530 */ byte UnkInfoArray[0x780];
    /* 0x10CB0 */ __int32 UnkCount;
    /*         */ byte _gap_0x10CB4[0x4];
    /*         */ byte _gap_0x10CB8[0xF28];
};

struct Client::UI::Shell::RaptureShellModule /* Size=0x1208 */
{
    /*        */ byte _gap_0x0[0x2B0];
    /*        */ byte _gap_0x2B0[0x2];
    /*        */ byte _gap_0x2B2;
    /* 0x02B3 */ bool MacroLocked;
    /*        */ byte _gap_0x2B4[0x4];
    /*        */ byte _gap_0x2B8[0x8];
    /* 0x02C0 */ __int32 MacroCurrentLine;
    /*        */ byte _gap_0x2C4[0x4];
    /*        */ byte _gap_0x2C8[0xF38];
    /* 0x1200 */ unsigned __int32 Flags;
    /*        */ byte _gap_0x1204[0x4];
};

struct Client::Graphics::ReferencedClassBase /* Size=0x10 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ unsigned __int32 RefCount;
    /*      */ byte _gap_0xC[0x4];
};

struct Client::Graphics::Render::Camera /* Size=0x130 */
{
    /* 0x000 */ Client::Graphics::ReferencedClassBase ReferencedClassBase;
    /*       */ byte _gap_0x10[0x40];
    /* 0x050 */ Common::Math::Matrix4x4 ProjectionMatrix;
    /*       */ byte _gap_0x90[0x10];
    /*       */ byte _gap_0xA0[0x4];
    /* 0x0A4 */ float FoV;
    /* 0x0A8 */ float AspectRatio;
    /* 0x0AC */ float NearPlane;
    /* 0x0B0 */ float FarPlane;
    /*       */ byte _gap_0xB4[0x4];
    /*       */ byte _gap_0xB8[0x78];
};

struct Client::Graphics::Scene::Camera /* Size=0xF0 */
{
    /* 0x00 */ Client::Graphics::Scene::Object Object;
    /* 0x80 */ Common::Math::Vector3 LookAtVector;
    /* 0x90 */ Common::Math::Vector3 Vector_1;
    /* 0xA0 */ Common::Math::Matrix4x4 ViewMatrix;
    /* 0xE0 */ Client::Graphics::Render::Camera* RenderCamera;
    /*      */ byte _gap_0xE8[0x8];
};

struct Client::Game::CameraBase /* Size=0x110 */
{
    /* 0x000 */ void** vtbl;
    /*       */ byte _gap_0x8[0x8];
    /* 0x010 */ Client::Graphics::Scene::Camera SceneCamera;
    /* 0x100 */ unsigned __int32 UnkUInt;
    /*       */ byte _gap_0x104[0x4];
    /* 0x108 */ unsigned __int32 UnkFlags;
    /*       */ byte _gap_0x10C[0x4];
};

struct Client::Game::Camera /* Size=0x2B0 */
{
    /* 0x000 */ Client::Game::CameraBase CameraBase;
    /*       */ byte _gap_0x110[0x4];
    /* 0x114 */ float Distance;
    /* 0x118 */ float MinDistance;
    /* 0x11C */ float MaxDistance;
    /* 0x120 */ float FoV;
    /* 0x124 */ float MinFoV;
    /* 0x128 */ float MaxFoV;
    /*       */ byte _gap_0x12C[0x4];
    /*       */ byte _gap_0x130[0x48];
    /*       */ byte _gap_0x178[0x4];
    /* 0x17C */ float InterpDistance;
    /*       */ byte _gap_0x180[0x8];
    /* 0x188 */ float SavedDistance;
    /*       */ byte _gap_0x18C[0x4];
    /*       */ byte _gap_0x190[0x120];
};

struct Client::UI::Misc::CharaView::UnkStruct /* Size=0x20 */
{
    /* 0x00 */ unsigned __int16 Unk0;
    /*      */ byte _gap_0x2;
    /* 0x03 */ byte Unk1;
    /* 0x04 */ byte Unk2;
    /*      */ byte _gap_0x5;
    /*      */ byte _gap_0x6[0x2];
    /* 0x08 */ unsigned __int64 Unk3;
    /* 0x10 */ unsigned __int64 Unk4;
    /* 0x18 */ unsigned __int64 Unk5;
};

struct Client::UI::Misc::ConfigModule /* Size=0xDEE8 */
{
    /*        */ byte _gap_0x0[0x28];
    /* 0x0028 */ Client::UI::UIModule* UIModule;
    /*        */ byte _gap_0x30[0xDEB8];
};

enum ConfigOption: __int16
{
    None = 0,
    GuidVersion = 2,
    ConfigVersion = 3,
    Language = 4,
    Region = 5,
    UPnP = 7,
    Port = 8,
    LastLogin0 = 9,
    LastLogin1 = 10,
    WorldId = 11,
    ServiceIndex = 12,
    DktSessionId = 13,
    MainAdapter = 15,
    ScreenLeft = 16,
    ScreenTop = 17,
    ScreenWidth = 18,
    ScreenHeight = 19,
    ScreenMode = 20,
    FullScreenWidth = 21,
    FullScreenHeight = 22,
    Refreshrate = 23,
    Fps = 24,
    AntiAliasing = 25,
    FPSInActive = 26,
    ResoMouseDrag = 27,
    MouseOpeLimit = 28,
    LangSelectSub = 29,
    Gamma = 30,
    UiBaseScale = 31,
    CharaLight = 32,
    UiHighScale = 33,
    TextureFilterQuality = 35,
    TextureAnisotropicQuality = 36,
    SSAO = 37,
    Glare = 38,
    DistortionWater = 39,
    DepthOfField = 40,
    RadialBlur = 42,
    Vignetting = 43,
    GrassQuality = 44,
    TranslucentQuality = 45,
    ShadowVisibilityType = 46,
    ShadowSoftShadowType = 47,
    ShadowTextureSizeType = 48,
    ShadowCascadeCountType = 49,
    LodType = 50,
    StreamingType = 51,
    GeneralQuality = 52,
    OcclusionCulling = 53,
    ShadowLOD = 54,
    BattleEffectSelf = 55,
    BattleEffectParty = 56,
    BattleEffectOther = 57,
    BattleEffectPvPEnemyPc = 58,
    PhysicsType = 59,
    MapResolution = 60,
    ShadowVisibilityTypeSelf = 61,
    ShadowVisibilityTypeParty = 62,
    ShadowVisibilityTypeOther = 63,
    ShadowVisibilityTypeEnemy = 64,
    PhysicsTypeSelf = 65,
    PhysicsTypeParty = 66,
    PhysicsTypeOther = 67,
    PhysicsTypeEnemy = 68,
    ReflectionType = 69,
    ScreenShotImageType = 70,
    IsSoundDisable = 72,
    IsSoundAlways = 73,
    IsSoundBgmAlways = 74,
    IsSoundSeAlways = 75,
    IsSoundVoiceAlways = 76,
    IsSoundSystemAlways = 77,
    IsSoundEnvAlways = 78,
    IsSoundPerformAlways = 79,
    PadGuid = 82,
    InstanceGuid = 83,
    ProductGuid = 84,
    DeadArea = 85,
    Alias = 86,
    AlwaysInput = 87,
    ForceFeedBack = 88,
    PadPovInput = 89,
    PadMode = 90,
    PadAvailable = 91,
    PadReverseConfirmCancel = 92,
    PadSelectButtonIcon = 93,
    PadMouseMode = 94,
    TextPasteEnable = 95,
    EnablePsFunction = 96,
    WaterWet = 97,
    DisplayObjectLimitType = 98,
    WindowDispNum = 99,
    ScreenShotDir = 100,
    AntiAliasing_DX11 = 102,
    TextureFilterQuality_DX11 = 103,
    TextureAnisotropicQuality_DX11 = 104,
    SSAO_DX11 = 105,
    Glare_DX11 = 106,
    DistortionWater_DX11 = 107,
    DepthOfField_DX11 = 108,
    RadialBlur_DX11 = 109,
    Vignetting_DX11 = 110,
    GrassQuality_DX11 = 111,
    TranslucentQuality_DX11 = 112,
    ShadowSoftShadowType_DX11 = 113,
    ShadowTextureSizeType_DX11 = 114,
    ShadowCascadeCountType_DX11 = 115,
    LodType_DX11 = 116,
    OcclusionCulling_DX11 = 117,
    ShadowLOD_DX11 = 118,
    MapResolution_DX11 = 119,
    ShadowVisibilityTypeSelf_DX11 = 120,
    ShadowVisibilityTypeParty_DX11 = 121,
    ShadowVisibilityTypeOther_DX11 = 122,
    ShadowVisibilityTypeEnemy_DX11 = 123,
    PhysicsTypeSelf_DX11 = 124,
    PhysicsTypeParty_DX11 = 125,
    PhysicsTypeOther_DX11 = 126,
    PhysicsTypeEnemy_DX11 = 127,
    ReflectionType_DX11 = 128,
    WaterWet_DX11 = 129,
    ParallaxOcclusion_DX11 = 130,
    Tessellation_DX11 = 131,
    GlareRepresentation_DX11 = 132,
    UiSystemEnlarge = 133,
    SoundPadSeType = 134,
    SoundPad = 135,
    IsSoundPad = 136,
    TouchPadMouse = 137,
    TouchPadCursorSpeed = 138,
    TouchPadButtonExtension = 139,
    TouchPadButton_Left = 140,
    TouchPadButton_Right = 141,
    RemotePlayRearTouchpadEnable = 142,
    SupportButtonAutorunEnable = 143,
    R3ButtonWindowScalingEnable = 144,
    AutoAfkSwitchingTime = 145,
    AutoChangeCameraMode = 146,
    AccessibilitySoundVisualEnable = 147,
    AccessibilitySoundVisualDispSize = 148,
    AccessibilitySoundVisualPermeabilityRate = 149,
    AccessibilityColorBlindFilterEnable = 150,
    AccessibilityColorBlindFilterType = 151,
    AccessibilityColorBlindFilterStrength = 152,
    MouseAutoFocus = 154,
    FPSDownAFK = 156,
    IdlingCameraAFK = 157,
    WeaponAutoPutAway = 159,
    WeaponAutoPutAwayTime = 160,
    LipMotionType = 161,
    FirstPersonDefaultYAngle = 163,
    FirstPersonDefaultZoom = 164,
    FirstPersonDefaultDistance = 165,
    ThirdPersonDefaultYAngle = 166,
    ThirdPersonDefaultZoom = 167,
    ThirdPersonDefaultDistance = 168,
    LockonDefaultYAngle = 169,
    LockonDefaultZoom = 170,
    LockonDefaultZoom_171 = 171,
    AutoChangePointOfView = 172,
    KeyboardCameraInterpolationType = 173,
    KeyboardCameraVerticalInterpolation = 174,
    TiltOffset = 175,
    KeyboardSpeed = 176,
    PadSpeed = 177,
    MouseSpeed = 178,
    PadFpsXReverse = 179,
    PadFpsYReverse = 180,
    PadTpsXReverse = 181,
    PadTpsYReverse = 182,
    MouseFpsXReverse = 183,
    MouseFpsYReverse = 184,
    MouseTpsXReverse = 185,
    MouseTpsYReverse = 186,
    MouseCharaViewRotYReverse = 187,
    MouseCharaViewRotXReverse = 188,
    MouseCharaViewMoveYReverse = 189,
    MouseCharaViewMoveXReverse = 190,
    PADCharaViewRotYReverse = 191,
    PADCharaViewRotXReverse = 192,
    PADCharaViewMoveYReverse = 193,
    PADCharaViewMoveXReverse = 194,
    CameraProductionOfAction = 195,
    FPSCameraInterpolationType = 196,
    FPSCameraVerticalInterpolation = 197,
    LegacyCameraCorrectionFix = 198,
    LegacyCameraType = 199,
    CameraZoom = 200,
    EventCameraAutoControl = 201,
    CameraLookBlinkType = 202,
    IdleEmoteTime = 203,
    IdleEmoteRandomType = 204,
    CutsceneSkipIsShip = 205,
    CutsceneSkipIsContents = 206,
    CutsceneSkipIsHousing = 207,
    FlyingControlType = 208,
    FlyingLegacyAutorun = 209,
    AutoFaceTargetOnAction = 211,
    SelfClick = 212,
    NoTargetClickCancel = 213,
    AutoTarget = 214,
    TargetTypeSelect = 215,
    AutoLockOn = 216,
    CircleBattleModeAutoChange = 218,
    CircleIsCustom = 219,
    CircleSwordDrawnIsActive = 220,
    CircleSwordDrawnNonPartyPc = 221,
    CircleSwordDrawnParty = 222,
    CircleSwordDrawnEnemy = 223,
    CircleSwordDrawnAggro = 224,
    CircleSwordDrawnNpcOrObject = 225,
    CircleSwordDrawnMinion = 226,
    CircleSwordDrawnDutyEnemy = 227,
    CircleSwordDrawnPet = 228,
    CircleSwordDrawnAlliance = 229,
    CircleSwordDrawnMark = 230,
    CircleSheathedIsActive = 231,
    CircleSheathedNonPartyPc = 232,
    CircleSheathedParty = 233,
    CircleSheathedEnemy = 234,
    CircleSheathedAggro = 235,
    CircleSheathedNpcOrObject = 236,
    CircleSheathedMinion = 237,
    CircleSheathedDutyEnemy = 238,
    CircleSheathedPet = 239,
    CircleSheathedAlliance = 240,
    CircleSheathedMark = 241,
    CircleClickIsActive = 242,
    CircleClickNonPartyPc = 243,
    CircleClickParty = 244,
    CircleClickEnemy = 245,
    CircleClickAggro = 246,
    CircleClickNpcOrObject = 247,
    CircleClickMinion = 248,
    CircleClickDutyEnemy = 249,
    CircleClickPet = 250,
    CircleClickAlliance = 251,
    CircleClickMark = 252,
    CircleXButtonIsActive = 253,
    CircleXButtonNonPartyPc = 254,
    CircleXButtonParty = 255,
    CircleXButtonEnemy = 256,
    CircleXButtonAggro = 257,
    CircleXButtonNpcOrObject = 258,
    CircleXButtonMinion = 259,
    CircleXButtonDutyEnemy = 260,
    CircleXButtonPet = 261,
    CircleXButtonAlliance = 262,
    CircleXButtonMark = 263,
    CircleYButtonIsActive = 264,
    CircleYButtonNonPartyPc = 265,
    CircleYButtonParty = 266,
    CircleYButtonEnemy = 267,
    CircleYButtonAggro = 268,
    CircleYButtonNpcOrObject = 269,
    CircleYButtonMinion = 270,
    CircleYButtonDutyEnemy = 271,
    CircleYButtonPet = 272,
    CircleYButtonAlliance = 273,
    CircleYButtonMark = 274,
    CircleBButtonIsActive = 275,
    CircleBButtonNonPartyPc = 276,
    CircleBButtonParty = 277,
    CircleBButtonEnemy = 278,
    CircleBButtonAggro = 279,
    CircleBButtonNpcOrObject = 280,
    CircleBButtonMinion = 281,
    CircleBButtonDutyEnemy = 282,
    CircleBButtonPet = 283,
    CircleBButtonAlliance = 284,
    CircleBButtonMark = 285,
    CircleAButtonIsActive = 286,
    CircleAButtonNonPartyPc = 287,
    CircleAButtonParty = 288,
    CircleAButtonEnemy = 289,
    CircleAButtonAggro = 290,
    CircleAButtonNpcOrObject = 291,
    CircleAButtonMinion = 292,
    CircleAButtonDutyEnemy = 293,
    CircleAButtonPet = 294,
    CircleAButtonAlliance = 295,
    CircleAButtonMark = 296,
    GroundTargetType = 297,
    GroundTargetCursorSpeed = 298,
    PetTargetOffInCombat = 299,
    GroundTargetFPSPosX = 300,
    GroundTargetFPSPosY = 301,
    GroundTargetTPSPosX = 302,
    GroundTargetTPSPosY = 303,
    TargetDisableAnchor = 304,
    TargetCircleClickFilterEnableNearestCursor = 305,
    TargetEnableMouseOverSelect = 306,
    GroundTargetCursorCorrectType = 307,
    GroundTargetActionExcuteType = 308,
    TargetCircleType = 309,
    TargetLineType = 310,
    LinkLineType = 311,
    ObjectBorderingType = 312,
    AutoNearestTarget = 313,
    AutoNearestTargetType = 314,
    DynamicRezoType = 315,
    RightClickExclusionPC = 316,
    RightClickExclusionBNPC = 317,
    RightClickExclusionMinion = 318,
    MoveMode = 320,
    TurnSpeed = 321,
    Is3DAudio = 322,
    FootEffect = 323,
    BattleEffect = 324,
    BGEffect = 325,
    LegacySeal = 326,
    GBarrelDisp = 327,
    EgiMirageTypeGaruda = 328,
    EgiMirageTypeTitan = 329,
    EgiMirageTypeIfrit = 330,
    BahamutSize = 331,
    PetMirageTypeCarbuncleSupport = 332,
    PhoenixSize = 333,
    GarudaSize = 334,
    TitanSize = 335,
    IfritSize = 336,
    TimeMode = 337,
    Time12 = 338,
    TimeEorzea = 339,
    TimeLocal = 340,
    TimeServer = 341,
    ActiveLS_H = 342,
    ActiveLS_L = 343,
    HotbarDisp = 344,
    HotbarLock = 345,
    HotbarEmptyVisible = 346,
    HotbarDispRecastTime = 347,
    HotbarCrossContentsActionEnableInput = 348,
    HotbarDispRecastTimeDispType = 349,
    HotbarNoneSlotDisp01 = 350,
    HotbarNoneSlotDisp02 = 351,
    HotbarNoneSlotDisp03 = 352,
    HotbarNoneSlotDisp04 = 353,
    HotbarNoneSlotDisp05 = 354,
    HotbarNoneSlotDisp06 = 355,
    HotbarNoneSlotDisp07 = 356,
    HotbarNoneSlotDisp08 = 357,
    HotbarNoneSlotDisp09 = 358,
    HotbarNoneSlotDisp10 = 359,
    HotbarNoneSlotDispEX = 360,
    ExHotbarSetting = 361,
    ExHotbarChangeHotbar1 = 362,
    HotbarExHotbarUseSetting = 363,
    HotbarCommon01 = 364,
    HotbarCommon02 = 365,
    HotbarCommon03 = 366,
    HotbarCommon04 = 367,
    HotbarCommon05 = 368,
    HotbarCommon06 = 369,
    HotbarCommon07 = 370,
    HotbarCommon08 = 371,
    HotbarCommon09 = 372,
    HotbarCommon10 = 373,
    HotbarCrossCommon01 = 374,
    HotbarCrossCommon02 = 375,
    HotbarCrossCommon03 = 376,
    HotbarCrossCommon04 = 377,
    HotbarCrossCommon05 = 378,
    HotbarCrossCommon06 = 379,
    HotbarCrossCommon07 = 380,
    HotbarCrossCommon08 = 381,
    HotbarCrossHelpDisp = 382,
    HotbarCrossOperation = 383,
    HotbarCrossDisp = 384,
    HotbarCrossLock = 385,
    HotbarCrossUseEx = 386,
    HotbarCrossUseExDirection = 387,
    HotbarCrossUsePadGuide = 388,
    HotbarCrossActiveSet = 389,
    HotbarCrossActiveSetPvP = 390,
    HotbarCrossSetChangeCustomIsAuto = 391,
    HotbarCrossDispType = 392,
    HotbarCrossSetChangeCustom = 393,
    HotbarCrossSetChangeCustomSet1 = 394,
    HotbarCrossSetChangeCustomSet2 = 395,
    HotbarCrossSetChangeCustomSet3 = 396,
    HotbarCrossSetChangeCustomSet4 = 397,
    HotbarCrossSetChangeCustomSet5 = 398,
    HotbarCrossSetChangeCustomSet6 = 399,
    HotbarCrossSetChangeCustomSet7 = 400,
    HotbarCrossSetChangeCustomSet8 = 401,
    HotbarCrossSetChangeCustomIsSword = 402,
    HotbarCrossSetChangeCustomIsSwordSet1 = 403,
    HotbarCrossSetChangeCustomIsSwordSet2 = 404,
    HotbarCrossSetChangeCustomIsSwordSet3 = 405,
    HotbarCrossSetChangeCustomIsSwordSet4 = 406,
    HotbarCrossSetChangeCustomIsSwordSet5 = 407,
    HotbarCrossSetChangeCustomIsSwordSet6 = 408,
    HotbarCrossSetChangeCustomIsSwordSet7 = 409,
    HotbarCrossSetChangeCustomIsSwordSet8 = 410,
    HotbarCrossAdvancedSetting = 411,
    HotbarCrossAdvancedSettingLeft = 412,
    HotbarCrossAdvancedSettingRight = 413,
    HotbarCrossSetPvpModeActive = 414,
    HotbarCrossSetChangeCustomPvp = 415,
    HotbarCrossSetChangeCustomIsAutoPvp = 416,
    HotbarCrossSetChangeCustomSet1Pvp = 417,
    HotbarCrossSetChangeCustomSet2Pvp = 418,
    HotbarCrossSetChangeCustomSet3Pvp = 419,
    HotbarCrossSetChangeCustomSet4Pvp = 420,
    HotbarCrossSetChangeCustomSet5Pvp = 421,
    HotbarCrossSetChangeCustomSet6Pvp = 422,
    HotbarCrossSetChangeCustomSet7Pvp = 423,
    HotbarCrossSetChangeCustomSet8Pvp = 424,
    HotbarCrossSetChangeCustomIsSwordPvp = 425,
    HotbarCrossSetChangeCustomIsSwordSet1Pvp = 426,
    HotbarCrossSetChangeCustomIsSwordSet2Pvp = 427,
    HotbarCrossSetChangeCustomIsSwordSet3Pvp = 428,
    HotbarCrossSetChangeCustomIsSwordSet4Pvp = 429,
    HotbarCrossSetChangeCustomIsSwordSet5Pvp = 430,
    HotbarCrossSetChangeCustomIsSwordSet6Pvp = 431,
    HotbarCrossSetChangeCustomIsSwordSet7Pvp = 432,
    HotbarCrossSetChangeCustomIsSwordSet8Pvp = 433,
    HotbarCrossAdvancedSettingPvp = 434,
    HotbarCrossAdvancedSettingLeftPvp = 435,
    HotbarCrossAdvancedSettingRightPvp = 436,
    HotbarWXHBEnable = 437,
    HotbarWXHBSetLeft = 438,
    HotbarWXHBSetRight = 439,
    HotbarWXHBEnablePvP = 440,
    HotbarWXHBSetLeftPvP = 441,
    HotbarWXHBSetRightPvP = 442,
    HotbarWXHB8Button = 443,
    HotbarWXHB8ButtonPvP = 444,
    HotbarWXHBSetInputTime = 445,
    HotbarWXHBDisplay = 446,
    HotbarWXHBFreeLayout = 447,
    HotbarXHBActiveTransmissionAlpha = 448,
    HotbarXHBAlphaDefault = 449,
    HotbarXHBAlphaActiveSet = 450,
    HotbarXHBAlphaInactiveSet = 451,
    HotbarWXHBInputOnce = 452,
    IdlingCameraSwitchType = 453,
    PlateType = 454,
    PlateDispHPBar = 455,
    PlateDisableMaxHPBar = 456,
    NamePlateHpSizeType = 457,
    NamePlateColorSelf = 458,
    NamePlateEdgeSelf = 459,
    NamePlateDispTypeSelf = 460,
    NamePlateNameTypeSelf = 461,
    NamePlateHpTypeSelf = 462,
    NamePlateColorSelfBuddy = 463,
    NamePlateEdgeSelfBuddy = 464,
    NamePlateDispTypeSelfBuddy = 465,
    NamePlateHpTypeSelfBuddy = 466,
    NamePlateColorSelfPet = 467,
    NamePlateEdgeSelfPet = 468,
    NamePlateDispTypeSelfPet = 469,
    NamePlateHpTypeSelfPet = 470,
    NamePlateColorParty = 471,
    NamePlateEdgeParty = 472,
    NamePlateDispTypeParty = 473,
    NamePlateNameTypeParty = 474,
    NamePlateHpTypeParty = 475,
    NamePlateDispTypePartyPet = 476,
    NamePlateHpTypePartyPet = 477,
    NamePlateDispTypePartyBuddy = 478,
    NamePlateHpTypePartyBuddy = 479,
    NamePlateColorAlliance = 480,
    NamePlateEdgeAlliance = 481,
    NamePlateDispTypeAlliance = 482,
    NamePlateNameTypeAlliance = 483,
    NamePlateHpTypeAlliance = 484,
    NamePlateDispTypeAlliancePet = 485,
    NamePlateHpTypeAlliancePet = 486,
    NamePlateColorOther = 487,
    NamePlateEdgeOther = 488,
    NamePlateDispTypeOther = 489,
    NamePlateNameTypeOther = 490,
    NamePlateHpTypeOther = 491,
    NamePlateDispTypeOtherPet = 492,
    NamePlateHpTypeOtherPet = 493,
    NamePlateDispTypeOtherBuddy = 494,
    NamePlateHpTypeOtherBuddy = 495,
    NamePlateColorUnengagedEnemy = 496,
    NamePlateEdgeUnengagedEnemy = 497,
    NamePlateDispTypeUnengagedEnemy = 498,
    NamePlateHpTypeUnengagedEmemy = 499,
    NamePlateColorEngagedEnemy = 500,
    NamePlateEdgeEngagedEnemy = 501,
    NamePlateDispTypeEngagedEnemy = 502,
    NamePlateHpTypeEngagedEmemy = 503,
    NamePlateColorClaimedEnemy = 504,
    NamePlateEdgeClaimedEnemy = 505,
    NamePlateDispTypeClaimedEnemy = 506,
    NamePlateHpTypeClaimedEmemy = 507,
    NamePlateColorUnclaimedEnemy = 508,
    NamePlateEdgeUnclaimedEnemy = 509,
    NamePlateDispTypeUnclaimedEnemy = 510,
    NamePlateHpTypeUnclaimedEmemy = 511,
    NamePlateColorNpc = 512,
    NamePlateEdgeNpc = 513,
    NamePlateDispTypeNpc = 514,
    NamePlateHpTypeNpc = 515,
    NamePlateColorObject = 516,
    NamePlateEdgeObject = 517,
    NamePlateDispTypeObject = 518,
    NamePlateHpTypeObject = 519,
    NamePlateColorMinion = 520,
    NamePlateEdgeMinion = 521,
    NamePlateDispTypeMinion = 522,
    NamePlateColorOtherBuddy = 523,
    NamePlateEdgeOtherBuddy = 524,
    NamePlateColorOtherPet = 525,
    NamePlateEdgeOtherPet = 526,
    NamePlateNameTitleTypeSelf = 527,
    NamePlateNameTitleTypeParty = 528,
    NamePlateNameTitleTypeAlliance = 529,
    NamePlateNameTitleTypeOther = 530,
    NamePlateNameTitleTypeFriend = 531,
    NamePlateColorFriend = 532,
    NamePlateColorFriendEdge = 533,
    NamePlateDispTypeFriend = 534,
    NamePlateNameTypeFriend = 535,
    NamePlateHpTypeFriend = 536,
    NamePlateDispTypeFriendPet = 537,
    NamePlateHpTypeFriendPet = 538,
    NamePlateDispTypeFriendBuddy = 539,
    NamePlateHpTypeFriendBuddy = 540,
    NamePlateColorLim = 541,
    NamePlateColorLimEdge = 542,
    NamePlateColorGri = 543,
    NamePlateColorGriEdge = 544,
    NamePlateColorUld = 545,
    NamePlateColorUldEdge = 546,
    NamePlateColorHousingFurniture = 547,
    NamePlateColorHousingFurnitureEdge = 548,
    NamePlateDispTypeHousingFurniture = 549,
    NamePlateColorHousingField = 550,
    NamePlateColorHousingFieldEdge = 551,
    NamePlateDispTypeHousingField = 552,
    NamePlateNameTypePvPEnemy = 553,
    NamePlateDispTypeFeast = 554,
    NamePlateNameTypeFeast = 555,
    NamePlateHpTypeFeast = 556,
    NamePlateDispTypeFeastPet = 557,
    NamePlateHpTypeFeastPet = 558,
    NamePlateNameTitleTypeFeast = 559,
    NamePlateDispSize = 560,
    ActiveInfo = 561,
    PartyList = 562,
    PartyListStatus = 563,
    PartyListSoloOff = 564,
    PartyListStatusTimer = 565,
    EnemyList = 566,
    TargetInfo = 567,
    Gil = 568,
    DTR = 569,
    PlayerInfo = 571,
    NaviMap = 572,
    Help = 573,
    HowTo = 574,
    CrossMainHelp = 575,
    HousingFurnitureBindConfirm = 576,
    HousingLocatePreview = 577,
    Log = 578,
    LogTell = 579,
    LogFontSize = 581,
    LogTabName2 = 582,
    LogTabName3 = 583,
    LogTabFilter0 = 584,
    LogTabFilter1 = 585,
    LogTabFilter2 = 586,
    LogTabFilter3 = 587,
    LogChatFilter = 588,
    LogEnableErrMsgLv1 = 589,
    DirectChat = 590,
    LogNameType = 591,
    LogTimeDisp = 592,
    LogTimeSettingType = 593,
    LogTimeDispType = 594,
    IsLogTell = 595,
    IsLogParty = 596,
    LogParty = 597,
    IsLogAlliance = 598,
    LogAlliance = 599,
    IsLogFc = 600,
    LogFc = 601,
    IsLogPvpTeam = 602,
    LogPvpTeam = 603,
    IsLogLs1 = 604,
    LogLs1 = 605,
    IsLogLs2 = 606,
    LogLs2 = 607,
    IsLogLs3 = 608,
    LogLs3 = 609,
    IsLogLs4 = 610,
    LogLs4 = 611,
    IsLogLs5 = 612,
    LogLs5 = 613,
    IsLogLs6 = 614,
    LogLs6 = 615,
    IsLogLs7 = 616,
    LogLs7 = 617,
    IsLogLs8 = 618,
    LogLs8 = 619,
    IsLogBeginner = 620,
    LogBeginner = 621,
    IsLogCwls = 622,
    IsLogCwls2 = 623,
    IsLogCwls3 = 624,
    IsLogCwls4 = 625,
    IsLogCwls5 = 626,
    IsLogCwls6 = 627,
    IsLogCwls7 = 628,
    IsLogCwls8 = 629,
    LogCwls = 630,
    LogCwls2 = 631,
    LogCwls3 = 632,
    LogCwls4 = 633,
    LogCwls5 = 634,
    LogCwls6 = 635,
    LogCwls7 = 636,
    LogCwls8 = 637,
    LogRecastActionErrDisp = 638,
    LogPermeationRate = 639,
    LogFontSizeForm = 640,
    LogItemLinkEnableType = 641,
    LogFontSizeLog2 = 642,
    LogTimeDispLog2 = 643,
    LogPermeationRateLog2 = 644,
    LogFontSizeLog3 = 645,
    LogTimeDispLog3 = 646,
    LogPermeationRateLog3 = 647,
    LogFontSizeLog4 = 648,
    LogTimeDispLog4 = 649,
    LogPermeationRateLog4 = 650,
    LogFlyingHeightMaxErrDisp = 651,
    LogCrossWorldName = 652,
    LogDragResize = 653,
    ChatType = 654,
    ShopSell = 655,
    ColorSay = 656,
    ColorShout = 657,
    ColorTell = 658,
    ColorParty = 659,
    ColorAlliance = 660,
    ColorLS1 = 661,
    ColorLS2 = 662,
    ColorLS3 = 663,
    ColorLS4 = 664,
    ColorLS5 = 665,
    ColorLS6 = 666,
    ColorLS7 = 667,
    ColorLS8 = 668,
    ColorFCompany = 669,
    ColorPvPGroup = 670,
    ColorPvPGroupAnnounce = 671,
    ColorBeginner = 672,
    ColorEmoteUser = 673,
    ColorEmote = 674,
    ColorYell = 675,
    ColorBeginnerAnnounce = 677,
    ColorCWLS = 678,
    ColorCWLS2 = 679,
    ColorCWLS3 = 680,
    ColorCWLS4 = 681,
    ColorCWLS5 = 682,
    ColorCWLS6 = 683,
    ColorCWLS7 = 684,
    ColorCWLS8 = 685,
    ColorAttackSuccess = 686,
    ColorAttackFailure = 687,
    ColorAction = 688,
    ColorItem = 689,
    ColorCureGive = 690,
    ColorBuffGive = 691,
    ColorDebuffGive = 692,
    ColorEcho = 693,
    ColorSysMsg = 694,
    ColorFCAnnounce = 695,
    ColorSysBattle = 696,
    ColorSysGathering = 697,
    ColorSysErr = 698,
    ColorNpcSay = 699,
    ColorItemNotice = 700,
    ColorGrowup = 701,
    ColorLoot = 702,
    ColorCraft = 703,
    ColorGathering = 704,
    ColorThemeType = 705,
    ShopConfirm = 706,
    ShopConfirmMateria = 707,
    ShopConfirmExRare = 708,
    ShopConfirmSpiritBondMax = 709,
    ItemSortItemCategory = 710,
    ItemSortEquipLevel = 711,
    ItemSortItemLevel = 712,
    ItemSortItemStack = 713,
    ItemSortTidyingType = 714,
    ItemNoArmoryMaskOff = 715,
    CharaParamDisp = 716,
    LimitBreakGaugeDisp = 717,
    ScenarioTreeDisp = 718,
    ScenarioTreeCompleteDisp = 719,
    HotbarCrossDispAlways = 720,
    ExpDisp = 721,
    InventryStatusDisp = 722,
    DutyListDisp = 723,
    NaviMapDisp = 724,
    GilStatusDisp = 725,
    InfoSettingDisp = 726,
    InfoSettingDispType = 727,
    InfoSettingDispWorldNameType = 728,
    TargetInfoDisp = 729,
    TargetNamePlateNameType = 730,
    EnemyListDisp = 731,
    FocusTargetDisp = 732,
    FocusTargetNamePlateNameType = 733,
    ItemDetailDisp = 734,
    ItemDetailTemporarilySwitch = 735,
    ItemDetailTemporarilySwitchKey = 736,
    ItemDetailTemporarilyHide = 737,
    ItemDetailTemporarilyHideKey = 738,
    ActionDetailDisp = 739,
    DetailTrackingType = 740,
    ToolTipDisp = 741,
    MapPermeationRate = 742,
    MapOperationType = 743,
    PartyListDisp = 744,
    PartyListNameType = 745,
    FlyTextDisp = 746,
    MapPermeationMode = 747,
    ToolTipDispSize = 748,
    RecommendLoginDisp = 749,
    RecommendAreaChangeDisp = 750,
    PlayGuideLoginDisp = 751,
    PlayGuideAreaChangeDisp = 752,
    AllianceList1Disp = 753,
    AllianceList2Disp = 754,
    MapPadOperationYReverse = 755,
    MapPadOperationXReverse = 756,
    TargetInfoSelfBuff = 757,
    MapDispSize = 758,
    FlyTextDispSize = 759,
    PopUpTextDisp = 760,
    PopUpTextDispSize = 761,
    DetailDispDelayType = 762,
    PartyListSortTypeTank = 763,
    PartyListSortTypeHealer = 764,
    PartyListSortTypeDps = 765,
    PartyListSortTypeOther = 766,
    RatioHpDisp = 767,
    BuffDispType = 768,
    ContentsInfoDisp = 769,
    DutyListHideWhenCntInfoDisp = 770,
    ContentsFinderListSortType = 771,
    ContentsFinderSupplyEnable = 772,
    DutyListNumDisp = 773,
    InInstanceContentDutyListDisp = 774,
    InPublicContentDutyListDisp = 775,
    ContentsInfoJoiningRequestDisp = 776,
    ContentsInfoJoiningRequestSituationDisp = 777,
    EnemyListCastbarEnable = 778,
    AchievementAppealLoginDisp = 779,
    ContentsFinderUseLangTypeJA = 780,
    ContentsFinderUseLangTypeEN = 781,
    ContentsFinderUseLangTypeDE = 782,
    ContentsFinderUseLangTypeFR = 783,
    HotbarDispSetNum = 784,
    HotbarDispSetChangeType = 785,
    HotbarDispSetDragType = 786,
    MainCommandType = 787,
    MainCommandDisp = 788,
    MainCommandDragShortcut = 789,
    HotbarDispLookNum = 790,
    ItemInventryWindowSizeType = 791,
    ItemInventryRetainerWindowSizeType = 792,
    SystemMouseOperationSoftOn = 793,
    SystemMouseOperationTrajectory = 794,
    SystemMouseOperationCursorScaling = 795,
    HardwareCursorSize = 796,
    UiAssetType = 797,
    BattleTalkShowFace = 798,
    BannerContentsDispType = 799,
    BannerContentsNotice = 800,
    MipDispType = 801,
    BannerContentsOrderType = 802,
    EmoteTextType = 803,
    IsEmoteSe = 804,
    EmoteSeType = 805,
    PartyFinderNewArrivalDisp = 806,
    GPoseTargetFilterNPCLookAt = 807,
    GPoseMotionFilterAction = 808,
    LsListSortPriority = 809,
    FriendListSortPriority = 810,
    FriendListFilterType = 811,
    FriendListSortType = 812,
    LetterListFilterType = 813,
    LetterListSortType = 814,
    FellowshipShowNewNotice = 815,
    ContentsReplayEnable = 816,
    MouseWheelOperationUp = 817,
    MouseWheelOperationDown = 818,
    MouseWheelOperationCtrlUp = 819,
    MouseWheelOperationCtrlDown = 820,
    MouseWheelOperationAltUp = 821,
    MouseWheelOperationAltDown = 822,
    MouseWheelOperationShiftUp = 823,
    MouseWheelOperationShiftDown = 824,
    TelepoTicketUseType = 825,
    TelepoTicketGilSetting = 826,
    CutsceneMovieVoice = 828,
    CutsceneMovieCaption = 829,
    CutsceneMovieOpening = 830,
    PvPFrontlinesGCFree = 831,
    SoundMaster = 833,
    SoundBgm = 834,
    SoundSe = 835,
    SoundVoice = 836,
    SoundEnv = 837,
    SoundSystem = 838,
    SoundPerform = 839,
    SoundPlayer = 840,
    SoundParty = 841,
    SoundOther = 842,
    IsSndMaster = 843,
    IsSndBgm = 844,
    IsSndSe = 845,
    IsSndVoice = 846,
    IsSndEnv = 847,
    IsSndSystem = 848,
    IsSndPerform = 849,
    SoundDolby = 850,
    SoundMicpos = 851,
    SoundChocobo = 852,
    SoundFieldBattle = 853,
    SoundCfTimeCount = 854,
    SoundHousing = 855,
    SoundEqualizerType = 856,
    PadButton_L2 = 858,
    PadButton_R2 = 859,
    PadButton_L1 = 860,
    PadButton_R1 = 861,
    PadButton_Triangle = 862,
    PadButton_Circle = 863,
    PadButton_Cross = 864,
    PadButton_Square = 865,
    PadButton_Select = 866,
    PadButton_Start = 867,
    PadButton_LS = 868,
    PadButton_RS = 869,
    PadButton_L3 = 870,
    PadButton_R3 = 871,
    Invalid = -1
};

struct Client::UI::Misc::UserFileManager::UserFileEvent::UserFileEventVTable /* Size=0x68 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int64 ReadFile;
    /* 0x10 */ __int64 WriteFile;
    /*      */ byte _gap_0x18[0x8];
    /* 0x20 */ __int64 GetFileSize;
    /* 0x28 */ __int64 GetDataSize;
    /* 0x30 */ __int64 GetFileVersion;
    /* 0x38 */ __int64 GetFileType;
    /*      */ byte _gap_0x40[0x8];
    /* 0x48 */ __int64 GetHasChanges;
    /* 0x50 */ __int64 GetIsSavePending;
    /* 0x58 */ __int64 SetCharacterContentId;
    /* 0x60 */ __int64 SaveFile;
};

struct Client::UI::Misc::UserFileManager::UserFileEvent /* Size=0x40 */
{
    /* 0x00 */ Client::UI::Misc::UserFileManager::UserFileEvent::UserFileEventVTable* VTable;
    /* 0x08 */ unsigned __int64 CharacterContentID;
    /* 0x10 */ __int64 UserFileManager;
    /* 0x18 */ __int64 TempDataPtr;
    /* 0x20 */ unsigned __int32 TempDataBytesWritten;
    /*      */ byte _gap_0x24[0x4];
    /*      */ byte _gap_0x28[0x8];
    /* 0x30 */ byte FileName[0xC];
    /* 0x3C */ bool Unk3C;
    /* 0x3D */ bool IsSavePending;
    /* 0x3E */ bool HasChanges;
    /* 0x3F */ bool IsVirtual;
};

struct Client::UI::Misc::FieldMarkerModule /* Size=0xC78 */
{
    /* 0x000 */ Client::UI::Misc::UserFileManager::UserFileEvent UserFileEvent;
    /* 0x040 */ byte PresetArray[0xC30];
    /*       */ byte _gap_0xC70[0x8];
};

struct Client::UI::Misc::GamePresetPoint /* Size=0xC */
{
    /* 0x0 */ __int32 X;
    /* 0x4 */ __int32 Y;
    /* 0x8 */ __int32 Z;
};

struct Client::UI::Misc::FieldMarkerPreset /* Size=0x68 */
{
    /* 0x00 */ Client::UI::Misc::GamePresetPoint A;
    /* 0x0C */ Client::UI::Misc::GamePresetPoint B;
    /* 0x18 */ Client::UI::Misc::GamePresetPoint C;
    /* 0x24 */ Client::UI::Misc::GamePresetPoint D;
    /* 0x30 */ Client::UI::Misc::GamePresetPoint One;
    /* 0x3C */ Client::UI::Misc::GamePresetPoint Two;
    /* 0x48 */ Client::UI::Misc::GamePresetPoint Three;
    /* 0x54 */ Client::UI::Misc::GamePresetPoint Four;
    /* 0x60 */ byte ActiveMarkers;
    /* 0x61 */ byte Reserved;
    /* 0x62 */ unsigned __int16 ContentFinderConditionId;
    /* 0x64 */ __int32 Timestamp;
};

struct Client::UI::Misc::ItemFinderModuleRetainerResult /* Size=0x80 */
{
    /* 0x00 */ Client::UI::Misc::ItemFinderModuleRetainerResult* Next;
    /*      */ byte _gap_0x8[0x18];
    /* 0x20 */ __int64 RetainerId;
    /* 0x28 */ __int32 EquipmentSlot;
    /* 0x2C */ __int32 CrystalsCount;
    /* 0x30 */ __int32 Page1Count;
    /* 0x34 */ __int32 Page2Count;
    /* 0x38 */ __int32 Page3Count;
    /* 0x3C */ __int32 Page4Count;
    /* 0x40 */ __int32 Page5Count;
    /* 0x44 */ __int32 EquipmentSlotHQ;
    /* 0x48 */ __int32 CrystalsCountHQ;
    /* 0x4C */ __int32 Page1CountHQ;
    /* 0x50 */ __int32 Page2CountHQ;
    /* 0x54 */ __int32 Page3CountHQ;
    /* 0x58 */ __int32 Page4CountHQ;
    /* 0x5C */ __int32 Page5CountHQ;
    /* 0x60 */ __int32 EquipmentSlotCollectible;
    /* 0x64 */ __int32 CrystalsCountCollectible;
    /* 0x68 */ __int32 Page1CountCollectible;
    /* 0x6C */ __int32 Page2CountCollectible;
    /* 0x70 */ __int32 Page3CountCollectible;
    /* 0x74 */ __int32 Page4CountCollectible;
    /* 0x78 */ __int32 Page5CountCollectible;
    /*      */ byte _gap_0x7C[0x4];
};

struct Client::UI::Misc::ItemFinderModuleResult /* Size=0x1F8 */
{
    /* 0x000 */ Client::System::String::Utf8String ItemName;
    /* 0x068 */ Client::System::String::Utf8String ItemNameHQ;
    /* 0x0D0 */ Client::System::String::Utf8String ItemNameCollectible;
    /* 0x138 */ __int32 EquipmentSlot;
    /* 0x13C */ __int32 ArmouryChestCategory;
    /* 0x140 */ __int32 ArmouryChestCount;
    /* 0x144 */ __int32 CrystalsCount;
    /* 0x148 */ __int32 InventoryPage1Count;
    /* 0x14C */ __int32 InventoryPage2Count;
    /* 0x150 */ __int32 InventoryPage3Count;
    /* 0x154 */ __int32 InventoryPage4Count;
    /* 0x158 */ __int32 ArmoireCount;
    /* 0x15C */ __int32 SaddleBagPage1Count;
    /* 0x160 */ __int32 SaddleBagPage2Count;
    /* 0x164 */ __int32 PremiumSaddleBagPage1Count;
    /* 0x168 */ __int32 PremiumSaddleBagPage2Count;
    /* 0x16C */ __int32 GlamourDresserCount;
    /* 0x170 */ __int32 EquipmentSlotHQ;
    /* 0x174 */ __int32 ArmouryChestCategoryHQ;
    /* 0x178 */ __int32 ArmouryChestCountHQ;
    /* 0x17C */ __int32 CrystalsCountHQ;
    /* 0x180 */ __int32 InventoryPage1CountHQ;
    /* 0x184 */ __int32 InventoryPage2CountHQ;
    /* 0x188 */ __int32 InventoryPage3CountHQ;
    /* 0x18C */ __int32 InventoryPage4CountHQ;
    /* 0x190 */ __int32 ArmoireCountHQ;
    /* 0x194 */ __int32 SaddleBagPage1CountHQ;
    /* 0x198 */ __int32 SaddleBagPage2CountHQ;
    /* 0x19C */ __int32 PremiumSaddleBagPage1CountHQ;
    /* 0x1A0 */ __int32 PremiumSaddleBagPage2CountHQ;
    /* 0x1A4 */ __int32 GlamourDresserCountHQ;
    /* 0x1A8 */ __int32 EquipmentSlotCollectible;
    /* 0x1AC */ __int32 ArmouryChestCategoryCollectible;
    /* 0x1B0 */ __int32 ArmouryChestCountCollectible;
    /* 0x1B4 */ __int32 CrystalsCountCollectible;
    /* 0x1B8 */ __int32 InventoryPage1CountCollectible;
    /* 0x1BC */ __int32 InventoryPage2CountCollectible;
    /* 0x1C0 */ __int32 InventoryPage3CountCollectible;
    /* 0x1C4 */ __int32 InventoryPage4CountCollectible;
    /* 0x1C8 */ __int32 ArmoireCountCollectible;
    /* 0x1CC */ __int32 SaddleBagPage1CountCollectible;
    /* 0x1D0 */ __int32 SaddleBagPage2CountCollectible;
    /* 0x1D4 */ __int32 PremiumSaddleBagPage1CountCollectible;
    /* 0x1D8 */ __int32 PremiumSaddleBagPage2CountCollectible;
    /* 0x1DC */ __int32 GlamourDresserCountCollectible;
    /* 0x1E0 */ Client::UI::Misc::ItemFinderModuleRetainerResult** Retainer;
    /* 0x1E8 */ __int64 RetainerCount;
    /* 0x1F0 */ bool ShowHQCount;
    /* 0x1F1 */ byte Unk1F1;
    /* 0x1F2 */ bool ShowCollectibleCount;
    /* 0x1F3 */ byte Unk1F3;
    /*       */ byte _gap_0x1F4[0x4];
};

struct Client::UI::Misc::ItemFinderModule /* Size=0x11D0 */
{
    /* 0x0000 */ Client::UI::Misc::UserFileManager::UserFileEvent UserFileEvent;
    /* 0x0040 */ unsigned __int32 RequestItemIds[0x18];
    /* 0x00A0 */ bool IsRequestUnfulfilled;
    /* 0x00A1 */ bool IsCabinetCached;
    /* 0x00A2 */ bool IsRetainerManagerReady;
    /* 0x00A3 */ bool IsSaddleBagCached;
    /* 0x00A4 */ bool IsGlamourDresserCached;
    /* 0x00A5 */ bool ShouldResetInvalid;
    /* 0x00A6 */ byte UnkA6;
    /* 0x00A7 */ byte UnkA7;
    /* 0x00A8 */ __int64 Retainer;
    /* 0x00B0 */ __int64 RetainerCount;
    /* 0x00B8 */ __int64 RetainerInventory;
    /* 0x00C0 */ __int64 RetainerInventoryCount;
    /* 0x00C8 */ unsigned __int32 SaddleBagItemIds[0x46];
    /* 0x01E0 */ unsigned __int32 PremiumSaddleBagItemIds[0x46];
    /* 0x02F8 */ unsigned __int16 SaddleBagItemCount[0x46];
    /* 0x0384 */ unsigned __int16 PremiumSaddleBagItemCount[0x46];
    /* 0x0410 */ unsigned __int32 GlamourDresserItemIds[0x320];
    /*        */ byte _gap_0x1090[0x10];
    /* 0x10A0 */ Client::UI::Misc::ItemFinderModuleResult* Result;
    /*        */ byte _gap_0x10A8[0x128];
};

enum InventoryType: unsigned __int32
{
    Inventory1 = 0,
    Inventory2 = 1,
    Inventory3 = 2,
    Inventory4 = 3,
    EquippedItems = 1000,
    Currency = 2000,
    Crystals = 2001,
    Mail = 2003,
    KeyItems = 2004,
    HandIn = 2005,
    DamagedGear = 2007,
    Examine = 2009,
    ArmoryOffHand = 3200,
    ArmoryHead = 3201,
    ArmoryBody = 3202,
    ArmoryHands = 3203,
    ArmoryWaist = 3204,
    ArmoryLegs = 3205,
    ArmoryFeets = 3206,
    ArmoryEar = 3207,
    ArmoryNeck = 3208,
    ArmoryWrist = 3209,
    ArmoryRings = 3300,
    ArmorySoulCrystal = 3400,
    ArmoryMainHand = 3500,
    SaddleBag1 = 4000,
    SaddleBag2 = 4001,
    PremiumSaddleBag1 = 4100,
    PremiumSaddleBag2 = 4101,
    RetainerPage1 = 10000,
    RetainerPage2 = 10001,
    RetainerPage3 = 10002,
    RetainerPage4 = 10003,
    RetainerPage5 = 10004,
    RetainerPage6 = 10005,
    RetainerPage7 = 10006,
    RetainerEquippedItems = 11000,
    RetainerGil = 12000,
    RetainerCrystals = 12001,
    RetainerMarket = 12002,
    FreeCompanyPage1 = 20000,
    FreeCompanyPage2 = 20001,
    FreeCompanyPage3 = 20002,
    FreeCompanyPage4 = 20003,
    FreeCompanyPage5 = 20004,
    FreeCompanyGil = 22000,
    FreeCompanyCrystals = 22001,
    HousingExteriorAppearance = 25000,
    HousingExteriorPlacedItems = 25001,
    HousingInteriorAppearance = 25002,
    HousingInteriorPlacedItems1 = 25003,
    HousingInteriorPlacedItems2 = 25004,
    HousingInteriorPlacedItems3 = 25005,
    HousingInteriorPlacedItems4 = 25006,
    HousingInteriorPlacedItems5 = 25007,
    HousingInteriorPlacedItems6 = 25008,
    HousingInteriorPlacedItems7 = 25009,
    HousingInteriorPlacedItems8 = 25010,
    HousingExteriorStoreroom = 27000,
    HousingInteriorStoreroom1 = 27001,
    HousingInteriorStoreroom2 = 27002,
    HousingInteriorStoreroom3 = 27003,
    HousingInteriorStoreroom4 = 27004,
    HousingInteriorStoreroom5 = 27005,
    HousingInteriorStoreroom6 = 27006,
    HousingInteriorStoreroom7 = 27007,
    HousingInteriorStoreroom8 = 27008
};

struct Client::UI::Misc::ItemOrderModuleSorterItemEntry /* Size=0xC */
{
    /* 0x0 */ unsigned __int16 Page;
    /* 0x2 */ unsigned __int16 Slot;
    /*     */ byte _gap_0x4[0x4];
    /* 0x8 */ unsigned __int16 Index;
    /* 0xA */ byte Flags;
    /*     */ byte _gap_0xB;
};

struct StdVector::ClientUIMiscItemOrderModuleSorterItemEntry /* Size=0x18 */
{
    /* 0x00 */ Client::UI::Misc::ItemOrderModuleSorterItemEntry* First;
    /* 0x08 */ Client::UI::Misc::ItemOrderModuleSorterItemEntry* Last;
    /* 0x10 */ Client::UI::Misc::ItemOrderModuleSorterItemEntry* End;
};

struct Client::UI::Misc::ItemOrderModuleSorterSortFunctionEntry /* Size=0x10 */
{
    /* 0x00 */ __int64 FunctionPtr;
    /* 0x08 */ bool Descending;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC[0x4];
};

struct StdVector::ClientUIMiscItemOrderModuleSorterSortFunctionEntry /* Size=0x18 */
{
    /* 0x00 */ Client::UI::Misc::ItemOrderModuleSorterSortFunctionEntry* First;
    /* 0x08 */ Client::UI::Misc::ItemOrderModuleSorterSortFunctionEntry* Last;
    /* 0x10 */ Client::UI::Misc::ItemOrderModuleSorterSortFunctionEntry* End;
};

struct Client::UI::Misc::ItemOrderModuleSorterPreviousOrderEntry /* Size=0x4 */
{
    /* 0x0 */ unsigned __int16 Slot;
    /* 0x2 */ unsigned __int16 Page;
};

struct Client::UI::Misc::ItemOrderModuleSorter /* Size=0x60 */
{
    /* 0x00 */ Client::Game::InventoryType InventoryType;
    /*      */ byte _gap_0x4[0x4];
    /* 0x08 */ StdVector::ClientUIMiscItemOrderModuleSorterItemEntry Items;
    /*      */ byte _gap_0x20[0x8];
    /* 0x28 */ __int32 ItemsPerPage;
    /*      */ byte _gap_0x2C[0x4];
    /*      */ byte _gap_0x30[0x8];
    /* 0x38 */ __int32 SortFunctionIndex;
    /* 0x3C */ __int32 PercentComplete;
    /* 0x40 */ StdVector::ClientUIMiscItemOrderModuleSorterSortFunctionEntry SortFunctions;
    /* 0x58 */ Client::UI::Misc::ItemOrderModuleSorterPreviousOrderEntry* PreviousOrderArray;
};

struct Client::UI::Misc::ItemOrderModuleSorterRetainerEntry /* Size=0x40 */
{
    /*      */ byte _gap_0x0[0x20];
    /* 0x20 */ unsigned __int64 RetainerId;
    /* 0x28 */ Client::UI::Misc::ItemOrderModuleSorter* Sorter;
    /*      */ byte _gap_0x30[0x10];
};

struct StdVector::ClientUIMiscItemOrderModuleSorterRetainerEntry /* Size=0x18 */
{
    /* 0x00 */ Client::UI::Misc::ItemOrderModuleSorterRetainerEntry* First;
    /* 0x08 */ Client::UI::Misc::ItemOrderModuleSorterRetainerEntry* Last;
    /* 0x10 */ Client::UI::Misc::ItemOrderModuleSorterRetainerEntry* End;
};

struct Client::UI::Misc::ItemOrderModule /* Size=0xD8 */
{
    /* 0x00 */ Client::UI::Misc::UserFileManager::UserFileEvent UserFileEvent;
    /* 0x40 */ Client::UI::Misc::ItemOrderModuleSorter* InventorySorter;
    union {
    /* 0x48 */ byte ArmourySorter[0x60];
    /* 0x48 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryMainHandSorter;
    } _union_0x48;
    /* 0x50 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryHeadSorter;
    /* 0x58 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryBodySorter;
    /* 0x60 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryHandsSorter;
    /* 0x68 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryLegsSorter;
    /* 0x70 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryFeetSorter;
    /* 0x78 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryOffHandSorter;
    /* 0x80 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryEarsSorter;
    /* 0x88 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryNeckSorter;
    /* 0x90 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryWristsSorter;
    /* 0x98 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryRingsSorter;
    /* 0xA0 */ Client::UI::Misc::ItemOrderModuleSorter* ArmourySoulCrystalSorter;
    /* 0xA8 */ Client::UI::Misc::ItemOrderModuleSorter* ArmouryWaistSorter;
    /* 0xB0 */ unsigned __int64 ActiveRetainerId;
    /* 0xB8 */ StdVector::ClientUIMiscItemOrderModuleSorterRetainerEntry* RetainerSorter;
    /* 0xC0 */ __int64 RetainerSorterCount;
    /* 0xC8 */ Client::UI::Misc::ItemOrderModuleSorter* SaddleBagSorter;
    /* 0xD0 */ Client::UI::Misc::ItemOrderModuleSorter* PremiumSaddleBagSorter;
};

struct Client::UI::Misc::PronounModule /* Size=0x3B0 */
{
    /*       */ byte _gap_0x0[0x3B0];
};

struct Client::UI::Misc::RaptureGearsetModule::Gearsets /* Size=0xAF2C */
{
    /*        */ byte _gap_0x0[0xAF28];
    /*        */ byte _gap_0xAF28[0x4];
};

struct Client::UI::Misc::RaptureGearsetModule /* Size=0xB670 */
{
    union {
    /* 0x0000 */ Client::UI::Misc::UserFileManager::UserFileEvent UserFileEvent;
    /* 0x0000 */ void* vtbl;
    } _union_0x0;
    /*        */ byte _gap_0x8[0x40];
    /* 0x0048 */ Client::UI::Misc::RaptureGearsetModule::Gearsets Gearset;
    /*        */ byte _gap_0xAF74[0x4];
    /*        */ byte _gap_0xAF78[0x6F8];
};

struct Client::UI::Misc::HotBars /* Size=0xFC00 */
{
    /*        */ byte _gap_0x0[0xFC00];
};

struct Client::UI::Misc::SavedHotBars /* Size=0x15720 */
{
    /*         */ byte _gap_0x0[0x15720];
};

struct Client::UI::Misc::RaptureHotbarModule /* Size=0x27278 */
{
    /* 0x00000 */ Client::UI::Misc::UserFileManager::UserFileEvent UserFileEvent;
    /*         */ byte _gap_0x40[0x8];
    /* 0x00048 */ Client::UI::UIModule* UiModule;
    /*         */ byte _gap_0x50[0x40];
    /* 0x00090 */ Client::UI::Misc::HotBars HotBar;
    /*         */ byte _gap_0xFC90[0x1CE0];
    /*         */ byte _gap_0x11970[0x4];
    /* 0x11974 */ Client::UI::Misc::SavedHotBars SavedClassJob;
    /*         */ byte _gap_0x27094[0x4];
    /*         */ byte _gap_0x27098[0x1E0];
};

struct Client::UI::Misc::HotBarSlots /* Size=0xE00 */
{
    /*       */ byte _gap_0x0[0xE00];
};

struct Client::UI::Misc::HotBar /* Size=0xE00 */
{
    /* 0x000 */ Client::UI::Misc::HotBarSlots Slot;
};

enum HotbarSlotType: byte
{
    Empty = 0,
    Action = 1,
    Item = 2,
    EventItem = 4,
    Emote = 6,
    Macro = 7,
    Marker = 8,
    CraftAction = 9,
    GeneralAction = 10,
    CompanionOrder = 11,
    MainCommand = 12,
    Minion = 13,
    GearSet = 15,
    PetOrder = 16,
    Mount = 17,
    FieldMarker = 18,
    Recipe = 20,
    ChocoboRaceAbility = 21,
    ChocoboRaceItem = 22,
    Unk_0x17 = 23,
    ExtraCommand = 24,
    PvPQuickChat = 25,
    PvPCombo = 26,
    SquadronOrder = 27,
    Unk_0x1C = 28,
    PerformanceInstrument = 29,
    Collection = 30,
    FashionAccessory = 31,
    LostFindsItem = 32
};

struct Client::UI::Misc::HotBarSlot /* Size=0xE0 */
{
    /* 0x00 */ Client::System::String::Utf8String PopUpHelp;
    /* 0x68 */ byte CostText[0x20];
    /* 0x88 */ byte PopUpKeybindHint[0x20];
    /* 0xA8 */ byte KeybindHint[0x10];
    /* 0xB8 */ unsigned __int32 CommandId;
    /* 0xBC */ unsigned __int32 IconA;
    /* 0xC0 */ unsigned __int32 IconB;
    /* 0xC4 */ unsigned __int16 UNK_0xC4;
    /*      */ byte _gap_0xC6;
    /* 0xC7 */ Client::UI::Misc::HotbarSlotType CommandType;
    /* 0xC8 */ Client::UI::Misc::HotbarSlotType IconTypeA;
    /* 0xC9 */ Client::UI::Misc::HotbarSlotType IconTypeB;
    /* 0xCA */ byte UNK_0xCA;
    /* 0xCB */ byte UNK_0xCB;
    /* 0xCC */ __int32 Icon;
    /* 0xD0 */ unsigned __int32 UNK_0xD0;
    /* 0xD4 */ unsigned __int32 UNK_0xD4;
    /* 0xD8 */ unsigned __int32 UNK_0xD8;
    /* 0xDC */ byte UNK_0xDC;
    /* 0xDD */ byte UNK_0xDD;
    /* 0xDE */ byte UNK_0xDE;
    /* 0xDF */ byte IsLoaded;
};

struct Client::UI::Misc::RaptureTextModule /* Size=0xE58 */
{
    /*       */ byte _gap_0x0[0xE58];
};

struct Client::UI::Misc::LogMessageSource /* Size=0x10 */
{
    /* 0x00 */ unsigned __int64 ContentId;
    /* 0x08 */ __int32 LogMessageIndex;
    /* 0x0C */ __int16 World;
    /* 0x0E */ __int16 ChatType;
};

struct Client::UI::Misc::RaptureLogModule /* Size=0x3480 */
{
    /* 0x0000 */ Common::Log::LogModule LogModule;
    /*        */ byte _gap_0x80[0x68];
    /* 0x00E8 */ Component::Excel::ExcelModuleInterface* ExcelModuleInterface;
    /* 0x00F0 */ Client::UI::Misc::RaptureTextModule* RaptureTextModule;
    /*        */ byte _gap_0xF8[0x430];
    /* 0x0528 */ byte ChatTabs[0x2DC8];
    /*        */ byte _gap_0x32F0[0x180];
    /* 0x3470 */ Client::UI::Misc::LogMessageSource* MsgSourceArray;
    /* 0x3478 */ __int32 MsgSourceArrayLength;
    /*        */ byte _gap_0x347C[0x4];
};

struct Client::UI::Misc::RaptureLogModuleTab /* Size=0x928 */
{
    /* 0x000 */ Client::System::String::Utf8String Name;
    /* 0x068 */ Client::System::String::Utf8String VisibleLogLines;
    /*       */ byte _gap_0xD0[0x858];
};

struct Client::UI::Misc::RaptureMacroModule::MacroPage /* Size=0x28D20 */
{
    /*         */ byte _gap_0x0[0x28D20];
};

struct Client::UI::Misc::RaptureMacroModule /* Size=0x51AA8 */
{
    /* 0x00000 */ Client::UI::Misc::UserFileManager::UserFileEvent UserFileEvent;
    /*         */ byte _gap_0x40[0x18];
    /* 0x00058 */ Client::UI::Misc::RaptureMacroModule::MacroPage Individual;
    /* 0x28D78 */ Client::UI::Misc::RaptureMacroModule::MacroPage Shared;
    /*         */ byte _gap_0x51A98[0x10];
};

struct Client::UI::Misc::RaptureUiDataModule /* Size=0x5958 */
{
    /* 0x0000 */ Client::UI::Misc::UserFileManager::UserFileEvent UserFileEvent;
    /*        */ byte _gap_0x40[0x5918];
};

enum ItemFlags: byte
{
    None = 0,
    HQ = 1,
    CompanyCrestApplied = 2,
    Relic = 4,
    Collectable = 8
};

struct Client::Game::InventoryItem /* Size=0x38 */
{
    /* 0x00 */ Client::Game::InventoryType Container;
    /* 0x04 */ __int16 Slot;
    /*      */ byte _gap_0x6[0x2];
    /* 0x08 */ unsigned __int32 ItemID;
    /* 0x0C */ unsigned __int32 Quantity;
    /* 0x10 */ unsigned __int16 Spiritbond;
    /* 0x12 */ unsigned __int16 Condition;
    /* 0x14 */ Client::Game::InventoryItem::ItemFlags Flags;
    /*      */ byte _gap_0x15;
    /*      */ byte _gap_0x16[0x2];
    /* 0x18 */ unsigned __int64 CrafterContentID;
    /* 0x20 */ unsigned __int16 Materia[0x5];
    /* 0x2A */ byte MateriaGrade[0x5];
    /* 0x2F */ byte Stain;
    /* 0x30 */ unsigned __int32 GlamourID;
    /*      */ byte _gap_0x34[0x4];
};

struct Client::UI::Misc::RetainerCommentModule::RetainerCommentList /* Size=0x410 */
{
    /*       */ byte _gap_0x0[0x410];
};

struct Client::UI::Misc::RetainerCommentModule /* Size=0x450 */
{
    /* 0x000 */ Client::UI::Misc::UserFileManager::UserFileEvent UserFileEvent;
    /* 0x040 */ Client::UI::Misc::RetainerCommentModule::RetainerCommentList Retainers;
};

struct Client::UI::Misc::ScreenLog /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

struct Client::UI::Misc::UiSavePackModule::UiSavePackModuleVTable /* Size=0x70 */
{
    /*      */ byte _gap_0x0[0x68];
    /* 0x68 */ __int64 GetSegment;
};

struct Client::UI::Misc::UiSavePackModule /* Size=0x50 */
{
    union {
    /* 0x00 */ Client::UI::Misc::UserFileManager::UserFileEvent UserFileEvent;
    /* 0x00 */ Client::UI::Misc::UiSavePackModule::UiSavePackModuleVTable* VTable;
    } _union_0x0;
    /*      */ byte _gap_0x8[0x48];
};

enum DataSegment: byte
{
    LETTER = 0,
    RETTASK = 1,
    FLAGS = 2,
    RCFAV = 3,
    UIDATA = 4,
    TLPH = 5,
    ITCC = 6,
    PVPSET = 7,
    EMTH = 8,
    MNONLST = 9,
    MUNTLST = 10,
    EMJ = 11,
    AOZNOTE = 12,
    CWLS = 13,
    ARCHVLST = 14,
    GRPPOS = 15,
    CRAFT = 16,
    FMARKER = 17,
    MYCNOT = 18,
    ORNMLST = 19,
    MYCITEM = 20,
    GRPSTAMP = 21,
    RTNR = 22,
    BANNER = 23,
    ADVNOTE = 24,
    AKTKNOT = 25,
    VVDNOTE = 26,
    VVDACT = 27,
    TOFU = 28
};

enum UserFileType: unsigned __int16
{
    ADDON = 0,
    MACRO = 1,
    HOTBAR = 2,
    KEYBIND = 3,
    LOGFLTR = 4,
    GEARSET = 5,
    ACQ = 6,
    ITEMODR = 7,
    ITEMFDR = 8,
    UISAVE = 9,
    GS = 10,
    CONTROL = 13
};

struct Client::UI::Info::InfoModule /* Size=0x1C70 */
{
    /*        */ byte _gap_0x0[0x1978];
    /* 0x1978 */ __int64 InfoProxyArray[0x22];
    /* 0x1A88 */ unsigned __int64 LocalContentId;
    /* 0x1A90 */ Client::System::String::Utf8String LocalCharName;
    /* 0x1AF8 */ Client::System::String::Utf8String UnkString1;
    /* 0x1B60 */ Client::System::String::Utf8String UnkString2;
    /* 0x1BC8 */ Client::System::String::Utf8String UnkString3;
    /*        */ byte _gap_0x1C30[0x40];
};

enum InfoProxyId: unsigned __int32
{
    Party = 0,
    Party2 = 1,
    PartyInvite = 2,
    LinkShell = 3,
    LinkShellMember = 4,
    Blacklist = 5,
    FriendList = 6,
    FriendList2 = 7,
    Letter = 8,
    PlayerSearch = 9,
    SearchComment = 10,
    ItemSearch = 12,
    FreeCompany = 13,
    FreeCompanyCreate = 14,
    FreeCompanyMember = 15,
    FreeCompanyMember2 = 16,
    LinkShellChat = 18,
    CrossRealmParty = 19,
    CrossWorldLinkShell = 29,
    CrossWorldLinkShellMember = 30,
    CircleList = 31,
    Circle = 32,
    CircleFinder = 33
};

struct Client::UI::Info::InfoProxyInterface::InfoProxyInterfaceVTable /* Size=0x40 */
{
    /*      */ byte _gap_0x0[0x38];
    /* 0x38 */ __int64 GetEntryCount;
};

struct Client::UI::Info::InfoProxyInterface /* Size=0x18 */
{
    union {
    /* 0x00 */ void** vtbl;
    /* 0x00 */ Client::UI::Info::InfoProxyInterface::InfoProxyInterfaceVTable* VTable;
    } _union_0x0;
    /* 0x08 */ Client::UI::UIModule* UiModule;
    /* 0x10 */ unsigned __int32 EntryCount;
    /*      */ byte _gap_0x14[0x4];
};

struct Client::UI::Info::InfoProxyPageInterface /* Size=0x20 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*      */ byte _gap_0x18[0x8];
};

struct Client::UI::Info::InfoProxy11 /* Size=0x5B98 */
{
    /* 0x0000 */ Client::UI::Info::InfoProxyPageInterface InfoProxyPageInterface;
    /*        */ byte _gap_0x20[0x5B78];
};

struct Client::UI::Info::InfoProxy17 /* Size=0x1F8 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*       */ byte _gap_0x18[0x20];
    /* 0x038 */ Client::System::String::Utf8String UnkString0;
    /* 0x0A0 */ Client::System::String::Utf8String UnkString1;
    /*       */ byte _gap_0x108[0xF0];
};

struct Client::UI::Info::InfoProxy20 /* Size=0x28 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*      */ byte _gap_0x18[0x10];
};

enum GrandCompany: byte
{
    None = 0,
    Maelstrom = 1,
    TwinAdder = 2,
    ImmortalFlames = 3
};

struct Client::UI::Info::InfoProxyCommonList::CharacterData /* Size=0x60 */
{
    /* 0x00 */ __int64 ContentId;
    /*      */ byte _gap_0x8;
    /* 0x09 */ unsigned __int16 OnlineStatus;
    /* 0x0B */ byte MentorState;
    /* 0x0C */ byte PartyStatus;
    /* 0x0D */ byte DutyStatus;
    /*      */ byte _gap_0xE[0x2];
    /*      */ byte _gap_0x10[0x2];
    /*      */ byte _gap_0x12;
    /* 0x13 */ byte Unk13;
    /* 0x14 */ byte DictIndex;
    /*      */ byte _gap_0x15;
    /* 0x16 */ unsigned __int16 CurrentWorld;
    /* 0x18 */ unsigned __int16 HomeWorld;
    /* 0x1A */ unsigned __int16 Location;
    /* 0x1C */ Client::UI::Agent::GrandCompany GrandCompany;
    /* 0x1D */ byte MainLanguage;
    /* 0x1E */ byte AvailableLanguages;
    /*      */ byte _gap_0x1F;
    /*      */ byte _gap_0x20;
    /* 0x21 */ byte Job;
    /* 0x22 */ byte Name[0x20];
    /* 0x42 */ byte FCTag[0x6];
    /*      */ byte _gap_0x48[0x18];
};

struct Client::UI::Info::InfoProxyCommonList::CharIndexEntry /* Size=0x10 */
{
    /* 0x00 */ __int64 ContentID;
    /*      */ byte _gap_0x8[0x2];
    /* 0x0A */ unsigned __int16 HomeWorld;
    /*      */ byte _gap_0xC[0x4];
};

struct Client::UI::Info::InfoProxyCommonList /* Size=0xB8 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyPageInterface InfoProxyPageInterface;
    /* 0x20 */ Client::System::String::Utf8String Unk20;
    /* 0x88 */ byte Unk88;
    /* 0x89 */ byte Unk89;
    /* 0x8A */ unsigned __int16 DataSize;
    /* 0x8C */ unsigned __int16 DictSize;
    /* 0x8E */ unsigned __int16 Unk8E;
    /* 0x90 */ unsigned __int16 Unk90;
    /*      */ byte _gap_0x92[0x2];
    /*      */ byte _gap_0x94[0x4];
    /* 0x98 */ Client::UI::Info::InfoProxyCommonList::CharacterData* CharData;
    /* 0xA0 */ Client::UI::Info::InfoProxyCommonList::CharIndexEntry* CharIndex;
    /*      */ byte _gap_0xA8[0x10];
};

struct Client::UI::Info::InfoProxyInvitedList /* Size=0xC8 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyCommonList InfoProxyCommonList;
    /*      */ byte _gap_0xB8[0x10];
};

struct Client::UI::Info::InfoProxy21 /* Size=0xC8 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyInvitedList InfoProxyInvitedList;
};

struct Client::UI::Info::InfoProxy22 /* Size=0xC8 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyInvitedList InfoProxyInvitedList;
};

struct Client::UI::Info::InfoProxy23 /* Size=0xA20 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyCommonList InfoProxyCommonList;
    /*       */ byte _gap_0xB8[0x968];
};

struct Client::UI::Info::InfoProxy24 /* Size=0x188 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*       */ byte _gap_0x18[0x20];
    /* 0x038 */ Client::System::String::Utf8String UnkString0;
    /* 0x0A0 */ Client::System::String::Utf8String UnkString1;
    /* 0x108 */ Client::System::String::Utf8String UnkString2;
    /*       */ byte _gap_0x170[0x18];
};

struct Client::UI::Info::InfoProxy25 /* Size=0x3E8 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*       */ byte _gap_0x18[0x20];
    /* 0x038 */ Client::System::String::Utf8String UnkString0;
    /* 0x0A0 */ Client::System::String::Utf8String UnkString1;
    /* 0x108 */ Component::GUI::AtkEventListener Unk108;
    /*       */ byte _gap_0x110[0x2A0];
    /* 0x3B0 */ Component::GUI::AtkEventTarget Unk3B0;
    /*       */ byte _gap_0x3B8[0x30];
};

struct Client::UI::Info::InfoProxy26 /* Size=0x28 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*      */ byte _gap_0x18[0x10];
};

struct Client::UI::Info::InfoProxy27 /* Size=0x28 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*      */ byte _gap_0x18[0x10];
};

struct Client::UI::Info::InfoProxy28 /* Size=0x110 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*       */ byte _gap_0x18[0x20];
    /* 0x038 */ Client::System::String::Utf8String UnkString0;
    /* 0x0A0 */ Client::System::String::Utf8String UnkString1;
    /*       */ byte _gap_0x108[0x8];
};

struct Client::UI::Info::InfoProxyBlacklist /* Size=0x1A00 */
{
    /* 0x0000 */ Client::UI::Info::InfoProxyPageInterface InfoProxyPageInterface;
    /* 0x0020 */ __int64 ContentIdArray[0xC8];
    /* 0x0660 */ Client::System::String::Utf8String Unk660;
    /* 0x06C8 */ Client::System::String::Utf8String Unk6C8;
    /*        */ byte _gap_0x730[0x12D0];
};

struct Client::UI::Info::InfoProxyCircleFinder /* Size=0x1C8 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*       */ byte _gap_0x18[0x88];
    /* 0x0A0 */ Client::System::String::Utf8String UnkString0;
    /*       */ byte _gap_0x108[0x8];
    /* 0x110 */ Client::System::String::Utf8String UnkString1;
    /*       */ byte _gap_0x178[0x8];
    /* 0x180 */ Component::GUI::AtkEventTarget AtkEventTarget0;
    /*       */ byte _gap_0x188[0x8];
    /* 0x190 */ Component::GUI::AtkEventTarget AtkEventTarget1;
    /*       */ byte _gap_0x198[0x30];
};

struct Client::UI::Info::InfoProxyCircleList /* Size=0x1E0 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*       */ byte _gap_0x18[0x20];
    /* 0x038 */ Client::System::String::Utf8String UnkString0;
    /* 0x0A0 */ Client::System::String::Utf8String UnkString1;
    /* 0x108 */ void* UnkObj108;
    /*       */ byte _gap_0x110[0x18];
    /* 0x128 */ Client::System::String::Utf8String UnkString2;
    /*       */ byte _gap_0x190[0x8];
    /* 0x198 */ void* UnkObj198;
    /*       */ byte _gap_0x1A0[0x8];
    /* 0x1A8 */ void* UnkObj1A8;
    /*       */ byte _gap_0x1B0[0x30];
};

struct Client::UI::Info::InfoProxyCrossRealm /* Size=0x14A0 */
{
    /* 0x0000 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*        */ byte _gap_0x18[0x370];
    /*        */ byte _gap_0x388[0x4];
    /*        */ byte _gap_0x38C;
    /* 0x038D */ byte LocalPlayerGroupIndex;
    /* 0x038E */ byte GroupCount;
    /*        */ byte _gap_0x38F;
    /* 0x0390 */ byte IsCrossRealm;
    /* 0x0391 */ byte IsInAllianceRaid;
    /* 0x0392 */ byte IsPartyLeader;
    /* 0x0393 */ byte IsInCrossRealmParty;
    /*        */ byte _gap_0x394[0x4];
    /*        */ byte _gap_0x398[0x8];
    /* 0x03A0 */ byte CrossRealmGroupArray[0xF30];
    /*        */ byte _gap_0x12D0[0x1D0];
};

struct Client::UI::Info::CrossRealmGroup /* Size=0x288 */
{
    /* 0x000 */ byte GroupMemberCount;
    /*       */ byte _gap_0x1;
    /*       */ byte _gap_0x2[0x2];
    /*       */ byte _gap_0x4[0x4];
    /* 0x008 */ byte GroupMembers[0x280];
};

struct Client::UI::Info::CrossRealmMember /* Size=0x50 */
{
    /* 0x00 */ unsigned __int64 ContentId;
    /*      */ byte _gap_0x8[0x8];
    /* 0x10 */ unsigned __int32 ObjectId;
    /*      */ byte _gap_0x14[0x4];
    /* 0x18 */ byte Level;
    /*      */ byte _gap_0x19;
    /* 0x1A */ __int16 HomeWorld;
    /* 0x1C */ __int16 CurrentWorld;
    /* 0x1E */ byte ClassJobId;
    /*      */ byte _gap_0x1F;
    /*      */ byte _gap_0x20[0x2];
    /* 0x22 */ byte Name[0x1E];
    /*      */ byte _gap_0x40[0x8];
    /* 0x48 */ byte MemberIndex;
    /* 0x49 */ byte GroupIndex;
    /*      */ byte _gap_0x4A;
    /* 0x4B */ byte IsPartyLeader;
    /*      */ byte _gap_0x4C[0x4];
};

struct Client::UI::Info::InfoProxyInvitedInterface::Unk18 /* Size=0x10 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ void* Data;
};

struct Client::UI::Info::InfoProxyInvitedInterface /* Size=0x28 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyInterface InfoProxynterface;
    /* 0x18 */ Client::UI::Info::InfoProxyInvitedInterface::Unk18 Unk18Obj;
};

struct Client::UI::Info::InfoProxyCrossWorldLinkShell /* Size=0x558 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInvitedInterface InfoProxyInvitedInterface;
    /* 0x028 */ unsigned __int32 NumInvites;
    /*       */ byte _gap_0x2C[0x4];
    /* 0x030 */ byte Unk30;
    /*       */ byte _gap_0x31;
    /*       */ byte _gap_0x32[0x2];
    /*       */ byte _gap_0x34[0x4];
    /* 0x038 */ Client::System::String::Utf8String InvitedName;
    /* 0x0A0 */ Client::System::String::Utf8String UnkString0;
    /* 0x108 */ byte CWLSArray[0x440];
    /*       */ byte _gap_0x548[0x10];
};

struct Client::UI::Info::InfoProxyCrossWorldLinkShellMember /* Size=0xD0 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyCommonList InfoProxyCommonList;
    /*      */ byte _gap_0xB8[0x18];
};

struct Client::UI::Info::InfoProxyFreeCompany /* Size=0x6E8 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*       */ byte _gap_0x18[0x8];
    /* 0x020 */ void* Unk20;
    /*       */ byte _gap_0x28[0x8];
    /* 0x030 */ unsigned __int64 ID;
    /*       */ byte _gap_0x38[0x8];
    /*       */ byte _gap_0x40[0x4];
    /*       */ byte _gap_0x44[0x2];
    /* 0x046 */ unsigned __int16 HomeWorldID;
    /*       */ byte _gap_0x48[0x20];
    /*       */ byte _gap_0x68;
    /* 0x069 */ Client::UI::Agent::GrandCompany GrandCompany;
    /*       */ byte _gap_0x6A;
    /* 0x06B */ byte Rank;
    /*       */ byte _gap_0x6C[0x4];
    /* 0x070 */ Client::UI::Agent::CrestData Crest;
    /* 0x078 */ unsigned __int16 OnlineMembers;
    /* 0x07A */ unsigned __int16 TotalMembers;
    /* 0x07C */ byte Name[0x16];
    /*       */ byte _gap_0x92;
    /* 0x093 */ byte Master[0x3C];
    /*       */ byte _gap_0xCF;
    /* 0x0D0 */ Client::System::String::Utf8String UnkD0;
    /* 0x138 */ byte ActiveListItemNum;
    /* 0x139 */ byte MemberTabIndex;
    /*       */ byte _gap_0x13A[0x2];
    /*       */ byte _gap_0x13C[0x2];
    /* 0x13E */ byte InfoTabIndex;
    /*       */ byte _gap_0x13F;
    /*       */ byte _gap_0x140[0x38];
    /* 0x178 */ byte RankArray[0x4D0];
    /*       */ byte _gap_0x648[0xA0];
};

struct Client::UI::Info::InfoProxyFreeCompanyCreate /* Size=0x118 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInvitedInterface InfoProxyUnk3Interface;
    /*       */ byte _gap_0x28[0x20];
    /* 0x048 */ Client::System::String::Utf8String UnkString0;
    /* 0x0B0 */ Client::System::String::Utf8String UnkString1;
};

struct Client::UI::Info::InfoProxyFreeCompanyMember /* Size=0xD0 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyCommonList InfoProxyCommonList;
    /* 0xB8 */ unsigned __int64 FreeCompanyID;
    /*      */ byte _gap_0xC0[0x10];
};

struct Client::UI::Info::InfoProxyFriendList /* Size=0x3AD0 */
{
    /* 0x0000 */ Client::UI::Info::InfoProxyCommonList InfoProxyCommonList;
    /*        */ byte _gap_0xB8[0x20];
    /* 0x00D8 */ Client::System::String::Utf8String Str2;
    /* 0x0140 */ Client::System::String::Utf8String Str3;
    /* 0x01A8 */ Client::System::String::Utf8String Str4;
    /* 0x0210 */ Client::System::String::Utf8String Str5;
    /* 0x0278 */ byte Names[0x3200];
    /*        */ byte _gap_0x3478[0x320];
    /* 0x3798 */ byte Unk3798[0x320];
    /*        */ byte _gap_0x3AB8[0x18];
};

struct Client::UI::Info::InfoProxyItemSearch /* Size=0x3C8 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyPageInterface InfoProxyPageInterface;
    /*       */ byte _gap_0x20[0x8];
    /* 0x028 */ Client::System::String::Utf8String Query;
    /* 0x090 */ byte Entries[0xA0];
    /*       */ byte _gap_0x130[0x298];
};

struct Client::UI::Info::InfoProxyLetter /* Size=0x5250 */
{
    /* 0x0000 */ Client::UI::Info::InfoProxyPageInterface InfoProxyPageInterface;
    /*        */ byte _gap_0x20[0x4];
    /* 0x0024 */ byte NumAtachments;
    /*        */ byte _gap_0x25;
    /*        */ byte _gap_0x26;
    /* 0x0027 */ byte NumLettersFromFriends;
    /* 0x0028 */ byte NumPurchases;
    /*        */ byte _gap_0x29;
    /*        */ byte _gap_0x2A[0x2];
    /*        */ byte _gap_0x2C[0x4];
    /* 0x0030 */ byte Letters[0x5140];
    /*        */ byte _gap_0x5170[0x8];
    /* 0x5178 */ Client::System::String::Utf8String UnkString0;
    /* 0x51E0 */ Client::System::String::Utf8String UnkString1;
    /*        */ byte _gap_0x5248[0x8];
};

struct Client::UI::Info::InfoProxyLinkShell /* Size=0x1E8 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*       */ byte _gap_0x18[0x20];
    /* 0x038 */ Client::System::String::Utf8String UnkString0;
    /* 0x0A0 */ Client::System::String::Utf8String UnkString1;
    /* 0x108 */ byte LinkShells[0xC0];
    /*       */ byte _gap_0x1C8[0x20];
};

struct Client::UI::Info::InfoProxyLinkShellChat /* Size=0x58 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*      */ byte _gap_0x18[0x40];
};

struct Client::UI::Info::InfoProxyLinkshellMember /* Size=0xD0 */
{
    /* 0x00 */ Client::UI::Info::InfoProxyCommonList InfoProxyCommonList;
    /*      */ byte _gap_0xB8[0x18];
};

struct Client::UI::Info::InfoProxyParty /* Size=0x348 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyCommonList InfoProxyCommonList;
    /*       */ byte _gap_0xB8[0x30];
    /* 0x0E8 */ void* UnkE8;
    /*       */ byte _gap_0xF0[0x10];
    /* 0x100 */ void* Unk100;
    /*       */ byte _gap_0x108[0x240];
};

struct Client::UI::Info::InfoProxyPartyInvite /* Size=0x148 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInvitedInterface InfoProxyInvitedInterface;
    /*       */ byte _gap_0x28[0x10];
    /*       */ byte _gap_0x38[0x4];
    /* 0x03C */ unsigned __int32 InviteTime;
    /*       */ byte _gap_0x40[0x2];
    /* 0x042 */ unsigned __int16 InviterWorldID;
    /*       */ byte _gap_0x44[0x4];
    /* 0x048 */ Client::System::String::Utf8String IviterName;
    /* 0x0B0 */ Client::System::String::Utf8String IviterNameWithHomeworld;
    /*       */ byte _gap_0x118[0x30];
};

struct Client::UI::Info::InfoProxySearch /* Size=0x178 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyCommonList InfoProxyCommonList;
    /*       */ byte _gap_0xB8[0xC0];
};

struct Client::UI::Info::InfoProxySearchComment /* Size=0x240 */
{
    /* 0x000 */ Client::UI::Info::InfoProxyInterface InfoProxyInterface;
    /*       */ byte _gap_0x18[0x8];
    /* 0x020 */ void* Unk20;
    /*       */ byte _gap_0x28[0x10];
    /*       */ byte _gap_0x38[0x2];
    /* 0x03A */ byte SearchCommentAsByteArr[0x3E];
    /*       */ byte _gap_0x78[0x88];
    /* 0x100 */ Client::System::String::Utf8String SearchComment;
    /* 0x168 */ Client::System::String::Utf8String UnkString1;
    /* 0x1D0 */ Client::System::String::Utf8String UnkString2;
    /*       */ byte _gap_0x238[0x8];
};

struct Client::UI::Agent::ActionData /* Size=0x88 */
{
    /* 0x00 */ Client::System::String::Utf8String DisplayString;
    /* 0x68 */ unsigned __int32 ActionId;
    /* 0x6C */ unsigned __int32 UnkValue0;
    /* 0x70 */ unsigned __int32 ActionCategoryId;
    /* 0x74 */ unsigned __int32 IconId;
    /* 0x78 */ unsigned __int32 Level;
    /*      */ byte _gap_0x7C[0x4];
    /*      */ byte _gap_0x80;
    /* 0x81 */ bool IsSlotable;
    /*      */ byte _gap_0x82[0x2];
    /*      */ byte _gap_0x84[0x4];
};

struct StdVector::ClientUIAgentActionData /* Size=0x18 */
{
    /* 0x00 */ Client::UI::Agent::ActionData* First;
    /* 0x08 */ Client::UI::Agent::ActionData* Last;
    /* 0x10 */ Client::UI::Agent::ActionData* End;
};

struct Client::UI::Agent::ExtraCommandData /* Size=0xE0 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ Client::System::String::Utf8String Name;
    /* 0x70 */ Client::System::String::Utf8String Description;
    /*      */ byte _gap_0xD8[0x8];
};

struct StdVector::ClientUIAgentExtraCommandData /* Size=0x18 */
{
    /* 0x00 */ Client::UI::Agent::ExtraCommandData* First;
    /* 0x08 */ Client::UI::Agent::ExtraCommandData* Last;
    /* 0x10 */ Client::UI::Agent::ExtraCommandData* End;
};

struct Client::UI::Agent::AgentActionMenu /* Size=0x2E8 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x8];
    /* 0x030 */ unsigned __int32 JobIconId;
    /* 0x034 */ unsigned __int32 Level;
    /* 0x038 */ unsigned __int32 JobId;
    /* 0x03C */ unsigned __int32 ClassId;
    /* 0x040 */ unsigned __int32 ClassJobCategoryId;
    /* 0x044 */ bool JobStoneEquipped;
    /*       */ byte _gap_0x45;
    /*       */ byte _gap_0x46[0x2];
    /*       */ byte _gap_0x48[0x8];
    /*       */ byte _gap_0x50[0x4];
    /* 0x054 */ __int32 Flags;
    /*       */ byte _gap_0x58[0x4];
    /* 0x05C */ bool CompactView;
    /*       */ byte _gap_0x5D;
    /*       */ byte _gap_0x5E[0x2];
    /* 0x060 */ unsigned __int32 OpenUpgradeActionId;
    /*       */ byte _gap_0x64[0x4];
    /* 0x068 */ StdVector::ClientUIAgentActionData ClassActionList;
    /* 0x080 */ StdVector::ClientUIAgentActionData JobActionList;
    /* 0x098 */ StdVector::ClientUIAgentActionData TraitList;
    /* 0x0B0 */ StdVector::ClientUIAgentActionData GeneralList;
    /* 0x0C8 */ StdVector::ClientUIAgentActionData CompanionOrderList;
    /* 0x0E0 */ StdVector::ClientUIAgentActionData SquadronOrderList;
    /* 0x0F8 */ StdVector::ClientUIAgentActionData MainCommandList;
    /* 0x110 */ StdVector::ClientUIAgentActionData PetActionList;
    /* 0x128 */ StdVector::ClientUIAgentActionData PetOrderList;
    /* 0x140 */ StdVector::ClientUIAgentActionData PerformanceList;
    /* 0x158 */ StdVector::ClientUIAgentActionData ExtraList;
    /* 0x170 */ StdVector::ClientUIAgentActionData CombatRoleActionList;
    /* 0x188 */ StdVector::ClientUIAgentActionData GatheringRoleActionList;
    /*       */ byte _gap_0x1A0[0x40];
    /* 0x1E0 */ Client::System::String::Utf8String ClassJobTitle;
    /*       */ byte _gap_0x248[0x70];
    /* 0x2B8 */ StdVector::ClientUIAgentExtraCommandData ExtraCommandData;
    /* 0x2D0 */ void* ExtraCommandExcelSheet;
    /*       */ byte _gap_0x2D8[0x8];
    /* 0x2E0 */ unsigned __int32 UpgradeAddonId;
    /*       */ byte _gap_0x2E4[0x4];
};

struct Client::UI::Agent::AozArrangementData /* Size=0x7A */
{
    /*      */ byte _gap_0x0;
    /* 0x01 */ byte Count;
    /* 0x02 */ unsigned __int16 Enemies[0x1E];
    /* 0x3E */ unsigned __int16 Positions[0x1E];
};

struct Client::UI::Agent::AozWeeklyReward /* Size=0x8 */
{
    /* 0x0 */ unsigned __int16 Gil;
    /* 0x2 */ unsigned __int16 Seals;
    /* 0x4 */ unsigned __int16 Tomes;
    /*     */ byte _gap_0x6[0x2];
};

struct Client::UI::Agent::AozContentData /* Size=0x380 */
{
    /*       */ byte _gap_0x0[0x8];
    /*       */ byte _gap_0x8[0x4];
    /* 0x00C */ __int32 SelectedContentIndex;
    /* 0x010 */ __int32 MaxContentEntries;
    /*       */ byte _gap_0x14[0x4];
    /*       */ byte _gap_0x18[0x28];
    /* 0x040 */ __int32 CurrentContentIndex;
    /*       */ byte _gap_0x44[0x4];
    /* 0x048 */ byte CurrentActIndex;
    /* 0x049 */ byte CurrentEnemyIndex;
    union {
    /* 0x04A */ byte Arrangements[0x16E];
    /* 0x04A */ Client::UI::Agent::AozArrangementData Act1Arrangement;
    } _union_0x4A;
    /*       */ byte _gap_0x52[0x2];
    /*       */ byte _gap_0x54[0x4];
    /*       */ byte _gap_0x58[0x68];
    /*       */ byte _gap_0xC0[0x4];
    /* 0x0C4 */ Client::UI::Agent::AozArrangementData Act2Arrangement;
    /* 0x13E */ Client::UI::Agent::AozArrangementData Act3Arrangement;
    /*       */ byte _gap_0x1B8[0x70];
    /* 0x228 */ Client::System::String::Utf8String NoviceString;
    /* 0x290 */ Client::System::String::Utf8String ModerateString;
    /* 0x2F8 */ Client::System::String::Utf8String AdvancedString;
    union {
    /* 0x360 */ byte WeeklyRewards[0x18];
    /* 0x360 */ Client::UI::Agent::AozWeeklyReward NoviceRewards;
    } _union_0x360;
    /* 0x368 */ Client::UI::Agent::AozWeeklyReward ModerateRewards;
    /* 0x370 */ Client::UI::Agent::AozWeeklyReward AdvancedRewards;
    /*       */ byte _gap_0x378[0x8];
};

enum AozWeeklyFlags: byte
{
    None = 0,
    Unknown = 1,
    Novice = 2,
    Moderate = 4,
    Advanced = 8
};

struct Client::UI::Agent::AgentAozContentBriefing /* Size=0x1A0 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x028 */ Client::UI::Agent::AozContentData* AozContentData;
    /* 0x030 */ Client::System::String::Utf8String WeeklyNoviceTitle;
    /* 0x098 */ Client::System::String::Utf8String WeeklyModerateTitle;
    /* 0x100 */ Client::System::String::Utf8String WeeklyAdvancedTitle;
    /* 0x168 */ Client::UI::Agent::AozWeeklyFlags WeeklyCompletion;
    /* 0x169 */ byte WeeklyAozContentId[0x3];
    /* 0x16C */ byte NoviceRequirement[0x3];
    /* 0x16F */ byte ModerateRequirement[0x3];
    /* 0x172 */ byte AdvancedRequirement[0x3];
    /*       */ byte _gap_0x175;
    /*       */ byte _gap_0x176[0x2];
    /* 0x178 */ byte* NoviceRequirements;
    /* 0x180 */ byte* ModerateRequirements;
    /* 0x188 */ byte* AdvancedRequirements;
    /*       */ byte _gap_0x190[0x10];
};

enum AozWeeklyChallenge: __int32
{
    Novice = 0,
    Moderate = 1,
    Advanced = 2
};

struct Client::UI::Agent::AozContentResultData /* Size=0x90 */
{
    /*      */ byte _gap_0x0[0x4];
    /* 0x04 */ unsigned __int32 ClearTime;
    /*      */ byte _gap_0x8[0x4];
    /* 0x0C */ unsigned __int32 Score;
    /*      */ byte _gap_0x10[0x18];
    /* 0x28 */ Client::System::String::Utf8String StageName;
};

struct Client::UI::Agent::AgentAozContentResult /* Size=0x30 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::AozContentResultData* AozContentResultData;
};

struct Client::UI::Agent::ArchiveItem /* Size=0xB0 */
{
    /*      */ byte _gap_0x0[0x10];
    /* 0x10 */ unsigned __int32 ItemId;
    /*      */ byte _gap_0x14[0x4];
    /* 0x18 */ Client::System::String::Utf8String ItemName;
    /*      */ byte _gap_0x80[0x30];
};

struct Client::UI::Agent::AgentArchiveItem /* Size=0x30 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::ArchiveItem* ArchiveItem;
};

struct Client::UI::Agent::AgentBannerInterface::Storage /* Size=0x3B30 */
{
    union {
    /* 0x0000 */ void* Agent;
    /* 0x0000 */ byte CharacterArray[0x3B00];
    } _union_0x0;
    /* 0x0008 */ Client::UI::UIModule* UiModule;
    /* 0x0010 */ unsigned __int32 Unk1;
    /* 0x0014 */ unsigned __int32 Unk2;
    /*        */ byte _gap_0x18[0x3B08];
    /* 0x3B20 */ __int64 Unk3;
    /* 0x3B28 */ __int64 Unk4;
};

struct Client::UI::Agent::AgentBannerInterface /* Size=0x30 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::AgentBannerInterface::Storage* Data;
};

struct Client::UI::Agent::AgentBannerMIP /* Size=0x38 */
{
    /* 0x00 */ Client::UI::Agent::AgentBannerInterface AgentBannerInterface;
    /*      */ byte _gap_0x30[0x8];
};

struct Client::UI::Agent::AgentBannerParty /* Size=0x38 */
{
    /* 0x00 */ Client::UI::Agent::AgentBannerInterface AgentBannerInterface;
    /*      */ byte _gap_0x30[0x8];
};

struct Client::UI::Agent::AgentCharaCard::Storage /* Size=0x950 */
{
    /*       */ byte _gap_0x0[0x58];
    /* 0x058 */ Client::System::String::Utf8String Name;
    /*       */ byte _gap_0xC0[0x18];
    /* 0x0D8 */ Client::System::String::Utf8String FreeCompany;
    /* 0x140 */ Client::System::String::Utf8String UnkString1;
    /* 0x1A8 */ Client::System::String::Utf8String UnkString2;
    /*       */ byte _gap_0x210[0x40];
    /* 0x250 */ unsigned __int32 Activity1IconId;
    /*       */ byte _gap_0x254[0x4];
    /* 0x258 */ Client::System::String::Utf8String Activity1Name;
    /* 0x2C0 */ unsigned __int32 Activity2IconId;
    /*       */ byte _gap_0x2C4[0x4];
    /* 0x2C8 */ Client::System::String::Utf8String Activity2Name;
    /* 0x330 */ unsigned __int32 Activity3IconId;
    /*       */ byte _gap_0x334[0x4];
    /* 0x338 */ Client::System::String::Utf8String Activity3Name;
    /* 0x3A0 */ unsigned __int32 Activity4IconId;
    /*       */ byte _gap_0x3A4[0x4];
    /* 0x3A8 */ Client::System::String::Utf8String Activity4Name;
    /* 0x410 */ unsigned __int32 Activity5IconId;
    /*       */ byte _gap_0x414[0x4];
    /* 0x418 */ Client::System::String::Utf8String Activity5Name;
    /* 0x480 */ unsigned __int32 Activity6IconId;
    /*       */ byte _gap_0x484[0x4];
    /* 0x488 */ Client::System::String::Utf8String Activity6Name;
    /*       */ byte _gap_0x4F0[0x50];
    /* 0x540 */ Client::UI::Misc::CharaView CharaView;
    /*       */ byte _gap_0x808[0x148];
};

struct Client::UI::Agent::AgentCharaCard /* Size=0x38 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::AgentCharaCard::Storage* Data;
    /*      */ byte _gap_0x30[0x8];
};

struct Client::UI::Agent::AgentCompanyCraftMaterial /* Size=0xE8 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /*      */ byte _gap_0x28[0x68];
    /*      */ byte _gap_0x90[0x4];
    /* 0x94 */ unsigned __int32 ResultItem;
    /*      */ byte _gap_0x98;
    /* 0x99 */ byte SelectedSupplyItemIndex;
    /*      */ byte _gap_0x9A[0x2];
    /* 0x9C */ unsigned __int32 SupplyItem[0xC];
    /*      */ byte _gap_0xCC[0x4];
    /*      */ byte _gap_0xD0[0x18];
};

struct Client::UI::Agent::ContentsFinderRewards /* Size=0x20 */
{
    union {
    /* 0x00 */ __int32 ExpReward;
    /* 0x00 */ __int32 GilReward;
    /* 0x00 */ __int32 SealReward;
    /* 0x00 */ __int32 PoeticReward;
    /* 0x00 */ __int32 NonLimitedTomestoneReward;
    /* 0x00 */ __int32 LimitedTomestoneRward;
    /* 0x00 */ __int32 PvPExpReward;
    /* 0x00 */ __int32 WolfMarkReward;
    } _union_0x0;
    /*      */ byte _gap_0x8[0x18];
};

enum ContentsRouletteRole: byte
{
    Tank = 0,
    Healer = 1,
    DPS = 2,
    None = 3
};

struct Client::UI::Agent::ContextMenu /* Size=0x678 */
{
    /* 0x000 */ __int16 CurrentEventIndex;
    /* 0x002 */ __int16 CurrentEventId;
    /*       */ byte _gap_0x4[0x4];
    /* 0x008 */ byte EventParams[0x210];
    /*       */ byte _gap_0x218[0x210];
    /* 0x428 */ byte EventIdArray[0x20];
    /*       */ byte _gap_0x448[0x8];
    /* 0x450 */ __int64 EventHandlerArray[0x20];
    /*       */ byte _gap_0x550[0x8];
    /* 0x558 */ __int64 EventHandlerParamArray[0x20];
    /*       */ byte _gap_0x658[0x8];
    /* 0x660 */ unsigned __int32 ContextItemDisabledMask;
    /* 0x664 */ unsigned __int32 ContextSubMenuMask;
    /* 0x668 */ byte* ContextTitleString;
    /* 0x670 */ byte SelectedContextItemIndex;
    /*       */ byte _gap_0x671;
    /*       */ byte _gap_0x672[0x2];
    /*       */ byte _gap_0x674[0x4];
};

struct System::Drawing::Point /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct Client::UI::Agent::ContextMenuTarget /* Size=0x60 */
{
    /* 0x00 */ unsigned __int64 ContentId;
    /*      */ byte _gap_0x8[0x8];
    /*      */ byte _gap_0x10[0x4];
    /* 0x14 */ byte AddonListIndex;
    /*      */ byte _gap_0x15;
    /* 0x16 */ unsigned __int16 CurrentWorldId;
    /* 0x18 */ unsigned __int16 HomeWorldId;
    /* 0x1A */ unsigned __int16 TerritoryTypeId;
    /* 0x1C */ byte GrandCompany;
    /* 0x1D */ byte ClientLanguage;
    /* 0x1E */ byte LanguageBitmask;
    /*      */ byte _gap_0x1F;
    /* 0x20 */ byte Gender;
    /* 0x21 */ byte ClassJobId;
    /* 0x22 */ byte Name[0x20];
    /* 0x42 */ byte FcName[0xE];
    /* 0x50 */ void* Unk_Info_Ptr;
    /*      */ byte _gap_0x58[0x8];
};

struct Client::Game::Object::GameObjectID /* Size=0x8 */
{
    /* 0x0 */ unsigned __int32 ObjectID;
    /* 0x4 */ byte Type;
    /*     */ byte _gap_0x5;
    /*     */ byte _gap_0x6[0x2];
};

struct Client::UI::Agent::AgentContext /* Size=0x1748 */
{
    /* 0x0000 */ Component::GUI::AgentInterface AgentInterface;
    union {
    /* 0x0028 */ byte ContextMenuArray[0xCF0];
    /* 0x0028 */ Client::UI::Agent::ContextMenu MainContextMenu;
    } _union_0x28;
    /*        */ byte _gap_0x30[0x670];
    /* 0x06A0 */ Client::UI::Agent::ContextMenu SubContextMenu;
    /* 0x0D18 */ Client::UI::Agent::ContextMenu* CurrentContextMenu;
    /* 0x0D20 */ Client::System::String::Utf8String ContextMenuTitle;
    /* 0x0D88 */ System::Drawing::Point Position;
    /* 0x0D90 */ unsigned __int32 OwnerAddon;
    /*        */ byte _gap_0xD94[0x4];
    /*        */ byte _gap_0xD98[0x8];
    /* 0x0DA0 */ Client::UI::Agent::ContextMenuTarget ContextMenuTarget;
    /* 0x0E00 */ Client::UI::Agent::ContextMenuTarget* CurrentContextMenuTarget;
    /* 0x0E08 */ Client::System::String::Utf8String TargetName;
    /* 0x0E70 */ Client::System::String::Utf8String YesNoTargetName;
    /*        */ byte _gap_0xED8[0x8];
    /* 0x0EE0 */ unsigned __int64 TargetContentId;
    /* 0x0EE8 */ unsigned __int64 YesNoTargetContentId;
    /* 0x0EF0 */ Client::Game::Object::GameObjectID TargetObjectId;
    /* 0x0EF8 */ Client::Game::Object::GameObjectID YesNoTargetObjectId;
    /* 0x0F00 */ __int16 TargetHomeWorldId;
    /* 0x0F02 */ __int16 YesNoTargetHomeWorldId;
    /* 0x0F04 */ byte YesNoEventId;
    /*        */ byte _gap_0xF05;
    /*        */ byte _gap_0xF06[0x2];
    /* 0x0F08 */ __int32 TargetGender;
    /* 0x0F0C */ unsigned __int32 TargetMountSeats;
    /*        */ byte _gap_0xF10[0x820];
    /* 0x1730 */ void* UpdateChecker;
    /* 0x1738 */ __int64 UpdateCheckerParam;
    /* 0x1740 */ byte ContextMenuIndex;
    /* 0x1741 */ byte OpenAtPosition;
    /*        */ byte _gap_0x1742[0x2];
    /*        */ byte _gap_0x1744[0x4];
};

enum ActionStatus: byte
{
    Available = 0,
    NotYetAvailable = 1,
    NotCurrentlyAvailable = 3
};

struct Client::UI::Agent::ProgressEfficiencyCalculation /* Size=0x18 */
{
    /* 0x00 */ unsigned __int32 ActionId;
    /* 0x04 */ unsigned __int32 ProgressEfficiency;
    /* 0x08 */ unsigned __int32 ProgressIncrease;
    /*      */ byte _gap_0xC[0x4];
    /*      */ byte _gap_0x10[0x4];
    /*      */ byte _gap_0x14[0x2];
    /* 0x16 */ Client::UI::Agent::ActionStatus Status;
    /*      */ byte _gap_0x17;
};

struct Client::UI::Agent::ProgressEfficiencyCalculations /* Size=0x108 */
{
    /* 0x000 */ Client::UI::Agent::ProgressEfficiencyCalculation BasicSynthesis;
    /* 0x018 */ Client::UI::Agent::ProgressEfficiencyCalculation RapidSynthesis;
    /* 0x030 */ Client::UI::Agent::ProgressEfficiencyCalculation MuscleMemory;
    /* 0x048 */ Client::UI::Agent::ProgressEfficiencyCalculation CarefulSynthesis;
    /* 0x060 */ Client::UI::Agent::ProgressEfficiencyCalculation FocusedSynthesis;
    /* 0x078 */ Client::UI::Agent::ProgressEfficiencyCalculation Groundwork;
    /* 0x090 */ Client::UI::Agent::ProgressEfficiencyCalculation DelicateSynthesis;
    /* 0x0A8 */ Client::UI::Agent::ProgressEfficiencyCalculation IntensiveSynthesis;
    /* 0x0C0 */ Client::UI::Agent::ProgressEfficiencyCalculation PrudentSynthesis;
    /*       */ byte _gap_0xD8[0x30];
};

struct Client::UI::Agent::QualityEfficiencyCalculation /* Size=0x18 */
{
    /* 0x00 */ unsigned __int32 ActionId;
    /*      */ byte _gap_0x4[0x4];
    /*      */ byte _gap_0x8[0x4];
    /* 0x0C */ unsigned __int32 QualityEfficiencyPercentage;
    /* 0x10 */ unsigned __int32 QualityIncrease;
    /*      */ byte _gap_0x14[0x2];
    /* 0x16 */ Client::UI::Agent::ActionStatus Status;
    /*      */ byte _gap_0x17;
};

struct Client::UI::Agent::QualityEfficiencyCalculations /* Size=0x138 */
{
    /* 0x000 */ Client::UI::Agent::QualityEfficiencyCalculation BasicTouch;
    /* 0x018 */ Client::UI::Agent::QualityEfficiencyCalculation HastyTouch;
    /* 0x030 */ Client::UI::Agent::QualityEfficiencyCalculation StandardTouch;
    /* 0x048 */ Client::UI::Agent::QualityEfficiencyCalculation ByregotsBlessing;
    /* 0x060 */ Client::UI::Agent::QualityEfficiencyCalculation PreciseTouch;
    /* 0x078 */ Client::UI::Agent::QualityEfficiencyCalculation PrudentTouch;
    /* 0x090 */ Client::UI::Agent::QualityEfficiencyCalculation FocusedTouch;
    /* 0x0A8 */ Client::UI::Agent::QualityEfficiencyCalculation Reflect;
    /* 0x0C0 */ Client::UI::Agent::QualityEfficiencyCalculation PreparatoryTouch;
    /* 0x0D8 */ Client::UI::Agent::QualityEfficiencyCalculation DelicateSynthesis;
    /* 0x0F0 */ Client::UI::Agent::QualityEfficiencyCalculation TrainedEye;
    /* 0x108 */ Client::UI::Agent::QualityEfficiencyCalculation AdvancedTouch;
    /* 0x120 */ Client::UI::Agent::QualityEfficiencyCalculation TrainedFinesse;
};

struct Client::UI::Agent::AgentCraftActionSimulator /* Size=0x90 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::ProgressEfficiencyCalculations* Progress;
    /*      */ byte _gap_0x30[0x10];
    /* 0x40 */ Client::UI::Agent::QualityEfficiencyCalculations* Quality;
    /*      */ byte _gap_0x48[0x48];
};

struct Client::UI::Agent::EfficiencyCalculation /* Size=0x18 */
{
    /* 0x00 */ unsigned __int32 ActionId;
    /* 0x04 */ unsigned __int32 ProgressEfficiency;
    /* 0x08 */ unsigned __int32 ProgressIncrease;
    /* 0x0C */ unsigned __int32 QualityEfficiencyPercentage;
    /* 0x10 */ unsigned __int32 QualityIncrease;
    /*      */ byte _gap_0x14[0x2];
    /* 0x16 */ Client::UI::Agent::ActionStatus Status;
    /*      */ byte _gap_0x17;
};

struct Client::UI::Agent::AgentDeepDungeonInspect::AgentDeepDungeonInspectData /* Size=0x160 */
{
    /* 0x000 */ unsigned __int32 RequestObjectID;
    /* 0x004 */ unsigned __int32 CurrentObjectID;
    /* 0x008 */ unsigned __int32 StatusSearchComment;
    /* 0x00C */ unsigned __int32 Unk0C;
    /* 0x010 */ Client::System::String::Utf8String SearchComment;
    /* 0x078 */ Client::UI::Info::InfoProxySearchComment* InfoProxySearchComment;
    /* 0x080 */ byte Title;
    /* 0x081 */ byte Unk81;
    /* 0x082 */ byte WorldID;
    /* 0x083 */ byte Unk83;
    /* 0x084 */ byte Unk84;
    /* 0x085 */ byte Job;
    /* 0x086 */ byte Level;
    /* 0x087 */ byte AetherPoolArmLvl;
    /* 0x088 */ byte AetherPoolArmorLvl;
    /*       */ byte _gap_0x89;
    /*       */ byte _gap_0x8A[0x2];
    /*       */ byte _gap_0x8C[0x4];
    /* 0x090 */ Client::System::String::Utf8String Name;
    /* 0x0F8 */ Client::System::String::Utf8String UnkF8;
};

struct Client::UI::Agent::AgentDeepDungeonInspect /* Size=0x30 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::AgentDeepDungeonInspect::AgentDeepDungeonInspectData* Data;
};

struct Client::UI::Agent::AgentDeepDungeonMapData /* Size=0x36 */
{
    /* 0x00 */ signed __int8 MapArray[0x19];
    /* 0x19 */ signed __int8 RoomIndexArray[0x19];
    /* 0x32 */ byte RoomIndexCount;
    /* 0x33 */ byte DeepDungeonId;
    /* 0x34 */ byte Unk_34;
    /* 0x35 */ bool MapLocked;
};

struct Client::UI::Agent::AgentDeepDungeonMap /* Size=0x30 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::AgentDeepDungeonMapData* Data;
};

struct Client::UI::Agent::DeepDungeonStatusData /* Size=0x8D8 */
{
    /* 0x000 */ unsigned __int32 Level;
    /* 0x004 */ unsigned __int32 MaxLevel;
    /* 0x008 */ unsigned __int32 ClassJobId;
    /*       */ byte _gap_0xC[0x4];
    /*       */ byte _gap_0x10[0x8];
    /* 0x018 */ byte Pomander[0x700];
    /* 0x718 */ byte Magicite[0x1C0];
};

struct Client::UI::Agent::AgentDeepDungeonStatus /* Size=0x30 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::DeepDungeonStatusData* Data;
};

struct Client::UI::Agent::DeepDungeonStatusItem /* Size=0x70 */
{
    /* 0x00 */ unsigned __int32 ItemId;
    /* 0x04 */ unsigned __int32 Icon;
    /* 0x08 */ Client::System::String::Utf8String Name;
};

struct Client::UI::Agent::ExplorationResultData /* Size=0x3CB0 */
{
    /* 0x0000 */ byte ValueArray[0x970];
    /*        */ byte _gap_0x970[0x18];
    /* 0x0988 */ Client::System::String::Utf8String Rating;
    /*        */ byte _gap_0x9F0[0x10];
    /* 0x0A00 */ byte ItemReturn[0x6E0];
    /* 0x10E0 */ byte ItemReturnListCount;
    /*        */ byte _gap_0x10E1;
    /*        */ byte _gap_0x10E2[0x2];
    /*        */ byte _gap_0x10E4[0x4];
    /* 0x10E8 */ byte StringArray[0x28A0];
    /* 0x3988 */ byte StringPointerArray[0x320];
    /* 0x3CA8 */ byte StringPointerListCount;
    /*        */ byte _gap_0x3CA9;
    /*        */ byte _gap_0x3CAA[0x2];
    /*        */ byte _gap_0x3CAC[0x4];
};

struct Client::UI::Agent::AgentExplorationResultInterface /* Size=0x38 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ unsigned __int32 ItemId;
    /*      */ byte _gap_0x2C[0x4];
    /* 0x30 */ Client::UI::Agent::ExplorationResultData* Data;
};

struct Client::UI::Agent::AgentAirshipExplorationResult /* Size=0x38 */
{
    /* 0x00 */ Client::UI::Agent::AgentExplorationResultInterface Interface;
};

struct Client::UI::Agent::AgentSubmersibleExplorationResult /* Size=0x38 */
{
    /* 0x00 */ Client::UI::Agent::AgentExplorationResultInterface Interface;
};

struct Client::UI::Agent::ExplorationResultDataItemReturn /* Size=0xB0 */
{
    /* 0x00 */ unsigned __int32 ItemId;
    /* 0x04 */ unsigned __int32 Quantity;
    /* 0x08 */ byte UnknownBytes[0xA8];
};

enum WaymarkIndex: __int32
{
    A = 0,
    B = 1,
    C = 2,
    D = 3,
    One = 4,
    Two = 5,
    Three = 6,
    Four = 7
};

struct Client::UI::Agent::AgentFishGuide /* Size=0x1A8 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x180];
};

struct Client::UI::Agent::AgentFreeCompany::FreeCompanyActionTimer /* Size=0x10 */
{
    /* 0x00 */ unsigned __int32 TimeSinceUpdate;
    /* 0x04 */ unsigned __int32 TimeRemainingAtUpdate[0x3];
};

struct Client::UI::Agent::AgentFreeCompany /* Size=0xAD8 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x028 */ void* vtbl2;
    /* 0x030 */ void* vtbl3;
    /*       */ byte _gap_0x38[0x8];
    /* 0x040 */ Client::UI::Misc::RaptureTextModule* RaptureTextModule;
    /* 0x048 */ void* InfoProxy0;
    /* 0x050 */ void* InfoProxy1;
    /*       */ byte _gap_0x58[0x2D0];
    /* 0x328 */ Client::System::String::Utf8String Board;
    /*       */ byte _gap_0x390[0x70];
    /* 0x400 */ Client::System::String::Utf8String Slogan;
    /*       */ byte _gap_0x468[0x70];
    /* 0x4D8 */ Client::System::String::Utf8String ShortMessage;
    /*       */ byte _gap_0x540[0x550];
    /* 0xA90 */ Client::UI::Agent::AgentFreeCompany::FreeCompanyActionTimer ActionTimeRemaining;
    /*       */ byte _gap_0xAA0[0x38];
};

struct Client::UI::Agent::AgentFreeCompanyCrestEditor /* Size=0x70 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /*      */ byte _gap_0x28[0x38];
    /* 0x60 */ Client::UI::Agent::CrestData OriginalCrest;
    /* 0x68 */ Client::UI::Agent::CrestData CurrentCrest;
};

enum FocusType: unsigned __int16
{
    None = 0,
    RolePlaying = 1,
    Leveling = 2,
    Casual = 4,
    Hardcore = 8,
    GuildHeist = 16,
    Trials = 32,
    Dungeons = 64,
    Raids = 128,
    PvP = 256
};

enum SeekingType: unsigned __int16
{
    None = 0,
    Tank = 1,
    HEaler = 2,
    DPS = 4,
    Crafter = 8,
    Gatherer = 16
};

enum ActiveType: byte
{
    Always = 0,
    Weekdays = 1,
    Weekends = 2
};

enum RecruitmentType: __int32
{
    None = 0,
    Full = 1,
    Provisional = 2
};

struct Client::UI::Agent::AgentFreeCompanyProfile::FCProfile /* Size=0xA */
{
    /* 0x0 */ Client::UI::Agent::AgentFreeCompanyProfile::FCProfile::FocusType Focus;
    /* 0x2 */ Client::UI::Agent::AgentFreeCompanyProfile::FCProfile::SeekingType Seeking;
    /* 0x4 */ Client::UI::Agent::AgentFreeCompanyProfile::FCProfile::ActiveType Active;
    /*     */ byte _gap_0x5;
    /* 0x6 */ Client::UI::Agent::AgentFreeCompanyProfile::FCProfile::RecruitmentType Recruitment;
};

struct Client::UI::Agent::AgentGatheringNote /* Size=0x178 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x150];
};

struct Client::UI::Agent::GcArmyExpeditionData /* Size=0x1998 */
{
    /*        */ byte _gap_0x0[0x10];
    /* 0x0010 */ __int32 NumEntries;
    /*        */ byte _gap_0x14[0x4];
    /* 0x0018 */ byte MissionInfoArray[0x1770];
    /*        */ byte _gap_0x1788[0x210];
};

struct Client::UI::Agent::AgentGcArmyExpedition /* Size=0x48 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::GcArmyExpeditionData* ExpeditionData;
    /*      */ byte _gap_0x30[0x10];
    /* 0x40 */ __int32 SelectedTab;
    /* 0x44 */ __int32 SelectedRow;
};

struct Client::UI::Agent::MissionInfo /* Size=0x78 */
{
    /* 0x00 */ Client::System::String::Utf8String Name;
    /* 0x68 */ byte Available;
    /*      */ byte _gap_0x69;
    /*      */ byte _gap_0x6A[0x2];
    /*      */ byte _gap_0x6C[0x4];
    /* 0x70 */ byte Level;
    /*      */ byte _gap_0x71;
    /*      */ byte _gap_0x72[0x2];
    /*      */ byte _gap_0x74[0x4];
};

struct Client::UI::Agent::AgentGoldSaucer /* Size=0x210 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x30];
    /*       */ byte _gap_0x58[0x2];
    /* 0x05A */ __int16 GoldSaucerSelectedTab;
    /* 0x05C */ __int16 ChocoboSeletedTab;
    /*       */ byte _gap_0x5E[0x2];
    /*       */ byte _gap_0x60[0xA0];
    /* 0x100 */ __int32 EditDeckSelectedPage;
    /*       */ byte _gap_0x104[0x4];
    /* 0x108 */ __int32 EditDeckSelectedCardIndex;
    /*       */ byte _gap_0x10C[0x4];
    /*       */ byte _gap_0x110[0x100];
};

struct Client::UI::Agent::SupplyProvisioningData /* Size=0x790 */
{
    /*       */ byte _gap_0x0[0x40];
    /* 0x040 */ byte SupplyData[0x540];
    /* 0x580 */ byte ProvisioningData[0x1F8];
    /*       */ byte _gap_0x778[0x18];
};

struct Client::UI::Agent::GrandCompanyItem /* Size=0xA0 */
{
    /* 0x00 */ Client::System::String::Utf8String ItemName;
    /*      */ byte _gap_0x68[0x8];
    /* 0x70 */ __int32 IconID;
    /* 0x74 */ __int32 ExpReward;
    /* 0x78 */ __int32 SealReward;
    /*      */ byte _gap_0x7C[0x4];
    /* 0x80 */ __int32 NumPossessed;
    /*      */ byte _gap_0x84[0x4];
    /*      */ byte _gap_0x88[0x8];
    /* 0x90 */ __int32 NumRequested;
    /*      */ byte _gap_0x94[0x4];
    /*      */ byte _gap_0x98[0x2];
    /* 0x9A */ byte TurnInAvailable;
    /* 0x9B */ byte Bonus;
    /*      */ byte _gap_0x9C[0x4];
};

struct Client::UI::Agent::AgentGrandCompanySupply /* Size=0x98 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /*      */ byte _gap_0x28[0x38];
    /* 0x60 */ Client::UI::Agent::SupplyProvisioningData* SupplyProvisioningData;
    /* 0x68 */ Client::UI::Agent::GrandCompanyItem* ItemArray;
    /*      */ byte _gap_0x70[0x8];
    /* 0x78 */ __int32 NumItems;
    /*      */ byte _gap_0x7C[0x4];
    /*      */ byte _gap_0x80[0x10];
    /* 0x90 */ __int32 SelectedTab;
    /*      */ byte _gap_0x94[0x4];
};

struct Client::UI::Agent::SupplyProvisioningItem /* Size=0xA8 */
{
    /* 0x00 */ __int32 ItemId;
    /* 0x04 */ __int32 ExpReward;
    /* 0x08 */ __int32 SealReward;
    /*      */ byte _gap_0xC[0x4];
    /*      */ byte _gap_0x10[0x8];
    /*      */ byte _gap_0x18[0x2];
    /* 0x1A */ byte NumRequested;
    /*      */ byte _gap_0x1B;
    /*      */ byte _gap_0x1C[0x4];
    /*      */ byte _gap_0x20[0x8];
    /* 0x28 */ Client::System::String::Utf8String ItemName;
    /* 0x90 */ __int32 ItemCategoryIconId;
    /*      */ byte _gap_0x94[0x4];
    /*      */ byte _gap_0x98[0x10];
};

struct Client::UI::Agent::HudPartyMemberEnmity /* Size=0xC */
{
    /* 0x0 */ unsigned __int32 ObjectId;
    /* 0x4 */ __int32 Enmity;
    /* 0x8 */ __int32 Index;
};

struct Client::UI::Agent::AgentHUD /* Size=0x4BA0 */
{
    /* 0x0000 */ Component::GUI::AgentInterface AgentInterface;
    /*        */ byte _gap_0x28[0xC90];
    /* 0x0CB8 */ __int32 CompanionSummonTimer;
    /*        */ byte _gap_0xCBC[0x4];
    /*        */ byte _gap_0xCC0[0x8];
    /* 0x0CC8 */ byte PartyMemberList[0x140];
    /*        */ byte _gap_0xE08[0x4B0];
    /* 0x12B8 */ __int16 PartyMemberCount;
    /*        */ byte _gap_0x12BA[0x2];
    /*        */ byte _gap_0x12BC[0x4];
    /* 0x12C0 */ unsigned __int32 PartyTitleAddonId;
    /* 0x12C4 */ unsigned __int32 RaidMemberIds[0x28];
    /* 0x1364 */ __int32 RaidGroupSize;
    /*        */ byte _gap_0x1368[0x88];
    /* 0x13F0 */ Client::UI::Agent::HudPartyMemberEnmity* PartyEnmityList;
    /*        */ byte _gap_0x13F8[0x37A8];
};

struct Client::Game::Character::Character::CharacterVTable /* Size=0x2B8 */
{
    /*       */ byte _gap_0x0[0x270];
    /* 0x270 */ __int64 GetStatusManager;
    /*       */ byte _gap_0x278[0x8];
    /* 0x280 */ __int64 GetCastInfo;
    /*       */ byte _gap_0x288[0x18];
    /* 0x2A0 */ __int64 GetForayInfo;
    /*       */ byte _gap_0x2A8[0x8];
    /* 0x2B0 */ __int64 IsMount;
};

struct Client::Game::Character::Character::MountContainer /* Size=0x60 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ Client::Game::Character::BattleChara* OwnerObject;
    /* 0x10 */ Client::Game::Character::Character* MountObject;
    /* 0x18 */ unsigned __int16 MountId;
    /*      */ byte _gap_0x1A[0x2];
    /* 0x1C */ float DismountTimer;
    /* 0x20 */ byte Flags;
    /*      */ byte _gap_0x21;
    /*      */ byte _gap_0x22[0x2];
    /* 0x24 */ unsigned __int32 MountedObjectIds[0x7];
    /*      */ byte _gap_0x40[0x20];
};

struct Client::Game::Character::Companion /* Size=0x1BE0 */
{
    /* 0x0000 */ Client::Game::Character::Character Character;
    /*        */ byte _gap_0x1B20[0xC0];
};

struct Client::Game::Character::Character::CompanionContainer /* Size=0x20 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ Client::Game::Character::BattleChara* OwnerObject;
    /* 0x10 */ Client::Game::Character::Companion* CompanionObject;
    /* 0x18 */ unsigned __int16 CompanionId;
    /*      */ byte _gap_0x1A[0x2];
    /*      */ byte _gap_0x1C[0x4];
};

struct Client::Game::Character::DrawObjectData /* Size=0x44 */
{
    /*      */ byte _gap_0x0[0x40];
    /*      */ byte _gap_0x40[0x4];
};

struct Client::Game::StatusManager /* Size=0x188 */
{
    /* 0x000 */ Client::Game::Character::Character* Owner;
    /* 0x008 */ byte Status[0x168];
    /* 0x170 */ unsigned __int32 Unk_170;
    /* 0x174 */ unsigned __int16 Unk_174;
    /*       */ byte _gap_0x176[0x2];
    /* 0x178 */ __int64 Unk_178;
    /* 0x180 */ byte Unk_180;
    /*       */ byte _gap_0x181;
    /*       */ byte _gap_0x182[0x2];
    /*       */ byte _gap_0x184[0x4];
};

enum ActionType: byte
{
    None = 0,
    Spell = 1,
    Item = 2,
    KeyItem = 3,
    Ability = 4,
    General = 5,
    Companion = 6,
    Unk_7 = 7,
    Unk_8 = 8,
    CraftAction = 9,
    MainCommand = 10,
    PetAction = 11,
    Unk_12 = 12,
    Mount = 13,
    PvPAction = 14,
    Waymark = 15,
    ChocoboRaceAbility = 16,
    ChocoboRaceItem = 17,
    Unk_18 = 18,
    SquadronAction = 19,
    Accessory = 20
};

struct Client::Game::Character::Character::CastInfo /* Size=0x170 */
{
    /* 0x000 */ byte IsCasting;
    /* 0x001 */ byte Interruptible;
    /* 0x002 */ Client::Game::ActionType ActionType;
    /*       */ byte _gap_0x3;
    /* 0x004 */ unsigned __int32 ActionID;
    /* 0x008 */ unsigned __int32 Unk_08;
    /*       */ byte _gap_0xC[0x4];
    /* 0x010 */ unsigned __int32 CastTargetID;
    /*       */ byte _gap_0x14[0x4];
    /*       */ byte _gap_0x18[0x8];
    /* 0x020 */ Common::Math::Vector3 CastLocation;
    /* 0x030 */ unsigned __int32 Unk_30;
    /* 0x034 */ float CurrentCastTime;
    /* 0x038 */ float TotalCastTime;
    /* 0x03C */ float AdjustedTotalCastTime;
    /* 0x040 */ unsigned __int32 UsedActionId;
    /* 0x044 */ Client::Game::ActionType UsedActionType;
    /*       */ byte _gap_0x45;
    /*       */ byte _gap_0x46[0x2];
    /*       */ byte _gap_0x48[0x10];
    /* 0x058 */ __int64 ActionRecipientsObjectIdArray[0x20];
    /* 0x158 */ __int32 ActionRecipientsCount;
    /*       */ byte _gap_0x15C[0x4];
    /*       */ byte _gap_0x160[0x10];
};

enum EurekaElement: byte
{
    None = 0,
    Fire = 1,
    Ice = 2,
    Wind = 3,
    Earth = 4,
    Lightning = 5,
    Water = 6
};

struct Client::Game::Character::Character::ForayInfo /* Size=0x2 */
{
    /* 0x0 */ byte ForayRank;
    /* 0x1 */ Client::Game::Character::Character::EurekaElement Element;
};

struct Client::Game::Character::BattleChara /* Size=0x2D70 */
{
    /* 0x0000 */ Client::Game::Character::Character Character;
    /*        */ byte _gap_0x1B20[0x40];
    /* 0x1B60 */ Client::Game::StatusManager StatusManager;
    /*        */ byte _gap_0x1CE8[0x8];
    /* 0x1CF0 */ Client::Game::Character::Character::CastInfo SpellCastInfo;
    /*        */ byte _gap_0x1E60[0xF00];
    /* 0x2D60 */ Client::Game::Character::Character::ForayInfo Foray;
    /*        */ byte _gap_0x2D62[0x2];
    /*        */ byte _gap_0x2D64[0x4];
    /*        */ byte _gap_0x2D68[0x8];
};

struct Client::UI::Agent::HudPartyMember /* Size=0x20 */
{
    /* 0x00 */ Client::Game::Character::BattleChara* Object;
    /* 0x08 */ byte* Name;
    /* 0x10 */ unsigned __int64 ContentId;
    /* 0x18 */ unsigned __int32 ObjectId;
    /*      */ byte _gap_0x1C[0x4];
};

struct Client::UI::Agent::AgentInspect::FreeCompanyData /* Size=0x86 */
{
    /* 0x00 */ byte Unkown4b0;
    /* 0x01 */ bool IsPArtOfFreeCOmpany;
    /*      */ byte _gap_0x2[0x2];
    /*      */ byte _gap_0x4[0x4];
    /* 0x08 */ __int64 ID;
    /* 0x10 */ Client::UI::Agent::CrestData Crest;
    /* 0x18 */ unsigned __int16 MemberCount;
    /* 0x1A */ unsigned __int16 GrandCompany;
    /* 0x1C */ unsigned __int16 Unk1C;
    /* 0x1E */ Client::System::String::Utf8String GuildName;
};

struct Client::UI::Agent::AgentInspect /* Size=0x558 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x028 */ unsigned __int32 RequestObjectID;
    /* 0x02C */ unsigned __int32 RequestSearchCommentOID;
    /* 0x030 */ unsigned __int32 RequestFreeCompanyOID;
    /* 0x034 */ unsigned __int32 CurrentObjectID;
    /* 0x038 */ Client::System::String::Utf8String SearchComment;
    /* 0x0A0 */ Client::System::String::Utf8String UnkString1;
    /* 0x108 */ Client::System::String::Utf8String PsnName;
    /* 0x170 */ Client::System::String::Utf8String ChocoboBarding1;
    /* 0x1D8 */ Client::System::String::Utf8String ChocoboBarding2;
    /* 0x240 */ Client::System::String::Utf8String ChocoboBarding3;
    /* 0x2A8 */ byte Items[0x208];
    /* 0x4B0 */ Client::UI::Agent::AgentInspect::FreeCompanyData FreeCompany;
    /* 0x536 */ __int16 UnkObj536;
    /* 0x538 */ unsigned __int32 FetchCharacterDataStatus;
    /* 0x53C */ unsigned __int32 FetchSearchCommentStatus;
    /* 0x540 */ unsigned __int32 FetchFreeCompanyStatus;
    /* 0x544 */ unsigned __int32 UnkObj544;
    /* 0x548 */ Client::UI::Info::InfoProxySearchComment* InfoProxySearchComment;
    /* 0x550 */ Client::UI::Info::InfoProxyFreeCompany* InfoProxyFreeCompany;
};

struct Client::UI::Agent::AgentInventoryContext /* Size=0x678 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x028 */ unsigned __int32 BlockingAddonId;
    /* 0x02C */ __int32 ContexItemStartIndex;
    /* 0x030 */ __int32 ContextItemCount;
    /*       */ byte _gap_0x34[0x4];
    /* 0x038 */ byte EventParams[0x520];
    /* 0x558 */ byte EventIdArray[0x50];
    /* 0x5A8 */ unsigned __int32 ContextItemDisabledMask;
    /* 0x5AC */ unsigned __int32 ContextItemSubmenuMask;
    /* 0x5B0 */ __int32 PositionX;
    /* 0x5B4 */ __int32 PositionY;
    /*       */ byte _gap_0x5B8[0x10];
    /* 0x5C8 */ unsigned __int32 OwnerAddonId;
    union {
    /* 0x5CC */ Client::Game::InventoryType TargetInventoryId;
    /* 0x5CC */ Client::Game::InventoryType BlockedInventoryId;
    } _union_0x5D0;
    union {
    /* 0x5D4 */ __int32 TargetInventorySlotId;
    /* 0x5D4 */ __int32 BlockedInventorySlotId;
    } _union_0x5D4;
    /* 0x5DC */ unsigned __int32 DummyInventoryId;
    /*       */ byte _gap_0x5E0[0x8];
    /* 0x5E8 */ Client::Game::InventoryItem* TargetInventorySlot;
    /* 0x5F0 */ Client::Game::InventoryItem TargetDummyItem;
    /*       */ byte _gap_0x628[0x10];
    /* 0x638 */ Client::Game::InventoryItem DiscardDummyItem;
    /*       */ byte _gap_0x670[0x8];
};

struct Client::UI::Agent::AgentItemSearch /* Size=0x37F0 */
{
    /* 0x0000 */ Component::GUI::AgentInterface AgentInterface;
    /*        */ byte _gap_0x28[0x32D8];
    /*        */ byte _gap_0x3300[0x4];
    /* 0x3304 */ unsigned __int32 ResultItemID;
    /*        */ byte _gap_0x3308[0x4];
    /* 0x330C */ unsigned __int32 ResultSelectedIndex;
    /*        */ byte _gap_0x3310[0x8];
    /*        */ byte _gap_0x3318[0x4];
    /* 0x331C */ unsigned __int32 ResultHoveredIndex;
    /*        */ byte _gap_0x3320[0x4];
    /* 0x3324 */ unsigned __int32 ResultHoveredCount;
    /*        */ byte _gap_0x3328[0x4];
    /* 0x332C */ byte ResultHoveredHQ;
    /*        */ byte _gap_0x332D;
    /*        */ byte _gap_0x332E[0x2];
    /*        */ byte _gap_0x3330[0x4C0];
};

struct Client::UI::Agent::AgentLobby /* Size=0x1C58 */
{
    /* 0x0000 */ Component::GUI::AgentInterface AgentInterface;
    /*        */ byte _gap_0x28[0xE98];
    /* 0x0EC0 */ unsigned __int64 SelectedCharacterId;
    /* 0x0EC8 */ byte DataCenter;
    /*        */ byte _gap_0xEC9;
    /*        */ byte _gap_0xECA[0x2];
    /* 0x0ECC */ unsigned __int16 WorldId;
    /*        */ byte _gap_0xECE[0x2];
    /*        */ byte _gap_0xED0[0xC8];
    /* 0x0F98 */ unsigned __int32 IdleTime;
    /*        */ byte _gap_0xF9C[0x4];
    /*        */ byte _gap_0xFA0[0xCB8];
};

struct Client::UI::Agent::AgentLoot /* Size=0x90 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /*      */ byte _gap_0x28[0x4];
    /* 0x2C */ byte HoveredSlotIndex;
    /*      */ byte _gap_0x2D;
    /*      */ byte _gap_0x2E[0x2];
    /* 0x30 */ unsigned __int32 HoveredItemId;
    /*      */ byte _gap_0x34[0x4];
    /*      */ byte _gap_0x38[0x38];
    /*      */ byte _gap_0x70[0x4];
    /* 0x74 */ __int32 SelectedSlotIndex;
    /*      */ byte _gap_0x78[0x4];
    /* 0x7C */ __int32 NumItems;
    /*      */ byte _gap_0x80[0x10];
};

struct StdPair::SystemUInt32::SystemUInt32 /* Size=0x8 */
{
    /* 0x0 */ unsigned __int32 Item1;
    /* 0x4 */ unsigned __int32 Item2;
};

struct StdMap::Node::SystemUInt32::SystemUInt32 /* Size=0x30 */
{
    /* 0x00 */ StdMap::Node::SystemUInt32::SystemUInt32* Left;
    /* 0x08 */ StdMap::Node::SystemUInt32::SystemUInt32* Parent;
    /* 0x10 */ StdMap::Node::SystemUInt32::SystemUInt32* Right;
    /* 0x18 */ byte Color;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /* 0x1C */ bool IsNil;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ byte _18;
    /* 0x21 */ byte _19;
    /*      */ byte _gap_0x22[0x2];
    /* 0x24 */ StdPair::SystemUInt32::SystemUInt32 KeyValuePair;
    /*      */ byte _gap_0x2C[0x4];
};

struct StdMap::SystemUInt32::SystemUInt32 /* Size=0x10 */
{
    /* 0x00 */ StdMap::Node::SystemUInt32::SystemUInt32* Head;
    /* 0x08 */ unsigned __int64 Count;
};

struct Client::UI::Agent::MapMarkerBase /* Size=0x38 */
{
    /* 0x00 */ byte SubtextOrientation;
    /* 0x01 */ byte SubtextStyle;
    /* 0x02 */ unsigned __int16 IconFlags;
    /* 0x04 */ unsigned __int32 IconId;
    /* 0x08 */ unsigned __int32 SecondaryIconId;
    /* 0x0C */ __int32 Scale;
    /* 0x10 */ byte* Subtext;
    /* 0x18 */ byte Index;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /*      */ byte _gap_0x1C[0x4];
    /*      */ byte _gap_0x20[0x8];
    /*      */ byte _gap_0x28[0x4];
    /* 0x2C */ __int16 X;
    /* 0x2E */ __int16 Y;
    /*      */ byte _gap_0x30[0x8];
};

struct Client::UI::Agent::FlagMapMarker /* Size=0x48 */
{
    /* 0x00 */ Client::UI::Agent::MapMarkerBase MapMarker;
    /* 0x38 */ unsigned __int32 TerritoryId;
    /* 0x3C */ unsigned __int32 MapId;
    /* 0x40 */ float XFloat;
    /* 0x44 */ float YFloat;
};

struct Client::UI::Agent::AgentMap /* Size=0x68A8 */
{
    /* 0x0000 */ Component::GUI::AgentInterface AgentInterface;
    /*        */ byte _gap_0x28[0xF0];
    /* 0x0118 */ StdMap::SystemUInt32::SystemUInt32 SymbolMap;
    /*        */ byte _gap_0x128[0x30];
    /* 0x0158 */ Client::System::String::Utf8String CurrentMapPath;
    /* 0x01C0 */ Client::System::String::Utf8String SelectedMapPath;
    /* 0x0228 */ Client::System::String::Utf8String SelectedMapBgPath;
    /* 0x0290 */ Client::System::String::Utf8String CurrentMapBgPath;
    /* 0x02F8 */ byte MapSelectionStrings[0x1A0];
    /* 0x0498 */ Client::System::String::Utf8String MapTitleString;
    /*        */ byte _gap_0x500[0x138];
    /* 0x0638 */ byte MapMarkerInfoArray[0x2520];
    /* 0x2B58 */ byte TempMapMarkerArray[0xC60];
    /* 0x37B8 */ Client::UI::Agent::FlagMapMarker FlagMapMarker;
    /* 0x3800 */ byte WarpMarkerArray[0x2A0];
    /* 0x3AA0 */ byte UnkArray2[0x3F0];
    /* 0x3E90 */ byte MiniMapMarkerArray[0x1900];
    /*        */ byte _gap_0x5790[0xA8];
    /* 0x5838 */ float SelectedMapSizeFactorFloat;
    /* 0x583C */ float CurrentMapSizeFactorFloat;
    /* 0x5840 */ __int16 SelectedMapSizeFactor;
    /* 0x5842 */ __int16 CurrentMapSizeFactor;
    /* 0x5844 */ __int16 SelectedOffsetX;
    /* 0x5846 */ __int16 SelectedOffsetY;
    /* 0x5848 */ __int16 CurrentOffsetX;
    /* 0x584A */ __int16 CurrentOffsetY;
    /*        */ byte _gap_0x584C[0x4];
    /*        */ byte _gap_0x5850[0x90];
    /* 0x58E0 */ unsigned __int32 CurrentTerritoryId;
    /* 0x58E4 */ unsigned __int32 CurrentMapId;
    /*        */ byte _gap_0x58E8[0x4];
    /* 0x58EC */ unsigned __int32 CurrentMapMarkerRange;
    /* 0x58F0 */ unsigned __int32 CurrentMapDiscoveryFlag;
    /* 0x58F4 */ unsigned __int32 SelectedTerritoryId;
    /* 0x58F8 */ unsigned __int32 SelectedMapId;
    /* 0x58FC */ unsigned __int32 SelectedMapMarkerRange;
    /* 0x5900 */ unsigned __int32 SelectedMapDiscoveryFlag;
    /* 0x5904 */ unsigned __int32 SelectedMapSub;
    /*        */ byte _gap_0x5908[0x8];
    /*        */ byte _gap_0x5910[0x4];
    /* 0x5914 */ unsigned __int32 UpdateFlags;
    /*        */ byte _gap_0x5918[0x98];
    /*        */ byte _gap_0x59B0[0x2];
    /* 0x59B2 */ byte MapMarkerCount;
    /* 0x59B3 */ byte TempMapMarkerCount;
    /*        */ byte _gap_0x59B4;
    /* 0x59B5 */ byte IsFlagMarkerSet;
    /*        */ byte _gap_0x59B6;
    /* 0x59B7 */ byte MiniMapMarkerCount;
    /*        */ byte _gap_0x59B8[0x4];
    /*        */ byte _gap_0x59BC[0x2];
    /*        */ byte _gap_0x59BE;
    /* 0x59BF */ byte IsPlayerMoving;
    /*        */ byte _gap_0x59C0[0x4];
    /*        */ byte _gap_0x59C4[0x2];
    /*        */ byte _gap_0x59C6;
    /* 0x59C7 */ byte IsControlKeyPressed;
    /*        */ byte _gap_0x59C8[0xEE0];
};

struct Client::UI::Agent::MapMarkerInfo /* Size=0x48 */
{
    /* 0x00 */ Client::UI::Agent::MapMarkerBase MapMarker;
    /*      */ byte _gap_0x38[0x4];
    /* 0x3C */ unsigned __int16 DataType;
    /* 0x3E */ unsigned __int16 DataKey;
    /*      */ byte _gap_0x40[0x4];
    /* 0x44 */ byte MapMarkerSubKey;
    /*      */ byte _gap_0x45;
    /*      */ byte _gap_0x46[0x2];
};

struct Client::UI::Agent::TempMapMarker /* Size=0x108 */
{
    /* 0x000 */ Client::System::String::Utf8String TooltipText;
    /* 0x068 */ Client::UI::Agent::MapMarkerBase MapMarker;
    /*       */ byte _gap_0xA0[0x8];
    /* 0x0A8 */ unsigned __int32 StyleFlags;
    /* 0x0AC */ unsigned __int32 Type;
    /*       */ byte _gap_0xB0[0x58];
};

struct Client::UI::Agent::MiniMapMarker /* Size=0x40 */
{
    /* 0x00 */ unsigned __int16 DataType;
    /* 0x02 */ unsigned __int16 DataKey;
    /*      */ byte _gap_0x4[0x4];
    /* 0x08 */ Client::UI::Agent::MapMarkerBase MapMarker;
};

enum MapType: unsigned __int32
{
    SharedFate = 0,
    FlagMarker = 1,
    GatheringLog = 2,
    QuestLog = 3,
    Centered = 4,
    Treasure = 5,
    Teleport = 6,
    MobHunt = 7,
    AetherCurrent = 8,
    Bozja = 9
};

struct Client::UI::Agent::OpenMapInfo /* Size=0xB8 */
{
    /* 0x00 */ Client::UI::Agent::MapType Type;
    /*      */ byte _gap_0x4[0x4];
    /* 0x08 */ unsigned __int32 TerritoryId;
    /* 0x0C */ unsigned __int32 MapId;
    /*      */ byte _gap_0x10[0x10];
    /* 0x20 */ Client::System::String::Utf8String TitleString;
    /*      */ byte _gap_0x88[0x30];
};

struct Client::UI::Agent::PrismBoxItem /* Size=0x88 */
{
    /* 0x00 */ Client::System::String::Utf8String Name;
    /*      */ byte _gap_0x68[0x4];
    /* 0x6C */ unsigned __int32 ItemId;
    /* 0x70 */ unsigned __int32 IconId;
    /*      */ byte _gap_0x74[0x4];
    /*      */ byte _gap_0x78[0x4];
    /*      */ byte _gap_0x7C[0x2];
    /* 0x7E */ byte Stain;
    /*      */ byte _gap_0x7F;
    /*      */ byte _gap_0x80[0x8];
};

struct Client::UI::Agent::PrismBoxCrystallizeItem /* Size=0x1C */
{
    /* 0x00 */ Client::Game::InventoryType Inventory;
    /* 0x04 */ __int32 Slot;
    /* 0x08 */ unsigned __int32 ItemId;
    /*      */ byte _gap_0xC[0x4];
    /*      */ byte _gap_0x10[0x8];
    /*      */ byte _gap_0x18[0x4];
};

struct Client::UI::Agent::MiragePrismPrismBoxData /* Size=0x1BAE0 */
{
    /*         */ byte _gap_0x0[0x8];
    /* 0x00008 */ byte PrismBoxItems[0x1A900];
    /* 0x1A908 */ Client::UI::Agent::PrismBoxItem TempContextItem;
    /* 0x1A990 */ __int32 PageItemIndexArray[0x32];
    /* 0x1AA58 */ __int32 TempContextItemIndex;
    /* 0x1AA5C */ __int32 SelectedPageIndex;
    /* 0x1AA60 */ __int32 UsedSlots;
    /*         */ byte _gap_0x1AA64[0x4];
    /*         */ byte _gap_0x1AA68[0x8];
    /* 0x1AA70 */ __int32 CrystallizeCategory;
    /* 0x1AA74 */ __int32 CrystallizeItemIndex;
    /* 0x1AA78 */ __int32 CrystallizeItemCount;
    /* 0x1AA7C */ byte CrystallizeItems[0xF50];
    /* 0x1B9CC */ Client::UI::Agent::PrismBoxCrystallizeItem CrystallizeSelectedItem;
    /*         */ byte _gap_0x1B9E8[0x8];
    /*         */ byte _gap_0x1B9F0[0x4];
    /* 0x1B9F4 */ unsigned __int32 FilterFlags;
    /* 0x1B9F8 */ void* AgentCabinet;
    /* 0x1BA00 */ void* AgentMiragePrismMiragePlate;
    /* 0x1BA08 */ byte FilterLevel;
    /*         */ byte _gap_0x1BA09;
    /* 0x1BA0A */ byte FilterGender;
    /*         */ byte _gap_0x1BA0B;
    /*         */ byte _gap_0x1BA0C[0x4];
    /* 0x1BA10 */ Client::System::String::Utf8String FilterString;
    /* 0x1BA78 */ Client::System::String::Utf8String SearchString;
};

struct Client::UI::Agent::AgentMiragePrismPrismBox /* Size=0x80 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::MiragePrismPrismBoxData* Data;
    /*      */ byte _gap_0x30[0x8];
    /*      */ byte _gap_0x38;
    /* 0x39 */ byte TabIndex;
    /* 0x3A */ byte PageIndex;
    /*      */ byte _gap_0x3B;
    /*      */ byte _gap_0x3C[0x4];
    /*      */ byte _gap_0x40[0x8];
    /* 0x48 */ Client::Game::InventoryItem TempDyeItem;
};

struct Client::UI::Agent::AgentMJIPouch::PouchIndexInfo /* Size=0x8 */
{
    /* 0x0 */ __int32 CurrentIndex;
    /* 0x4 */ __int32 MaxIndex;
};

struct Client::UI::Agent::PouchInventoryItem /* Size=0x80 */
{
    /* 0x00 */ unsigned __int32 ItemId;
    /* 0x04 */ unsigned __int32 IconId;
    /* 0x08 */ __int32 SlotIndex;
    /* 0x0C */ __int32 StackSize;
    /* 0x10 */ __int32 MaxStackSize;
    /* 0x14 */ byte InventoryIndex;
    /* 0x15 */ byte ItemCategory;
    /* 0x16 */ byte Undiscovered;
    /*      */ byte _gap_0x17;
    /* 0x18 */ Client::System::String::Utf8String Name;
};

struct StdVector::ClientUIAgentPouchInventoryItem /* Size=0x18 */
{
    /* 0x00 */ Client::UI::Agent::PouchInventoryItem* First;
    /* 0x08 */ Client::UI::Agent::PouchInventoryItem* Last;
    /* 0x10 */ Client::UI::Agent::PouchInventoryItem* End;
};

struct Pointer::ClientUIAgentPouchInventoryItem /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdVector::PointerClientUIAgentPouchInventoryItem /* Size=0x18 */
{
    /* 0x00 */ Pointer::ClientUIAgentPouchInventoryItem* First;
    /* 0x08 */ Pointer::ClientUIAgentPouchInventoryItem* Last;
    /* 0x10 */ Pointer::ClientUIAgentPouchInventoryItem* End;
};

struct StdVector::ClientSystemStringUtf8String /* Size=0x18 */
{
    /* 0x00 */ Client::System::String::Utf8String* First;
    /* 0x08 */ Client::System::String::Utf8String* Last;
    /* 0x10 */ Client::System::String::Utf8String* End;
};

struct Client::UI::Agent::AgentMJIPouch::PouchInventoryData /* Size=0x1A0 */
{
    /*       */ byte _gap_0x0[0x78];
    /* 0x078 */ StdVector::ClientUIAgentPouchInventoryItem Inventory;
    /* 0x090 */ StdVector::PointerClientUIAgentPouchInventoryItem Materials;
    /* 0x0A8 */ StdVector::PointerClientUIAgentPouchInventoryItem Produce;
    /* 0x0C0 */ StdVector::PointerClientUIAgentPouchInventoryItem StockStores;
    /* 0x0D8 */ StdVector::PointerClientUIAgentPouchInventoryItem Tools;
    /* 0x0F0 */ StdVector::ClientSystemStringUtf8String InventoryNames;
    /* 0x108 */ unsigned __int32 MJIItemPouchItemCount;
    /*       */ byte _gap_0x10C[0x4];
    /*       */ byte _gap_0x110[0x90];
};

struct Client::UI::Agent::AgentMJIPouch /* Size=0x38 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::AgentMJIPouch::PouchIndexInfo* InventoryIndex;
    /* 0x30 */ Client::UI::Agent::AgentMJIPouch::PouchInventoryData* InventoryData;
};

struct Client::UI::Agent::AgentModule /* Size=0xD78 */
{
    /* 0x000 */ void* vtbl;
    /* 0x008 */ Client::UI::UIModule* UIModule;
    /* 0x010 */ byte Initialized;
    /* 0x011 */ byte Unk_11;
    /*       */ byte _gap_0x12[0x2];
    /* 0x014 */ unsigned __int32 FrameCounter;
    /* 0x018 */ float FrameDelta;
    /*       */ byte _gap_0x1C[0x4];
    /* 0x020 */ byte Agents[0xD48];
    /* 0xD68 */ Client::UI::UIModule* UIModulePtr;
    /* 0xD70 */ Client::UI::Agent::AgentModule* AgentModulePtr;
};

enum AgentId: unsigned __int32
{
    Lobby = 0,
    CharaMake = 1,
    MovieStaffList = 2,
    Cursor = 3,
    Hud = 4,
    ChatLog = 5,
    Inventory = 6,
    ScenarioTree = 7,
    EventFade = 8,
    Context = 9,
    InventoryContext = 10,
    Config = 11,
    ConfigLog = 12,
    ConfigLogColor = 13,
    Configkey = 14,
    ConfigCharacter = 15,
    ConfigPadcustomize = 16,
    ChatConfig = 17,
    HudLayout = 18,
    Emote = 19,
    Macro = 20,
    TargetCircle = 21,
    GatheringNote = 22,
    RecipeNote = 23,
    RecipeTree = 24,
    RecipeMaterialList = 25,
    RecipeProductList = 26,
    FishingNote = 27,
    FishGuide = 28,
    FishRecord = 29,
    Journal = 31,
    ActionMenu = 32,
    Marker = 33,
    Trade = 34,
    ScreenLog = 35,
    Request = 36,
    Status = 37,
    Map = 38,
    Loot = 39,
    Repair = 40,
    Materialize = 42,
    MateriaAttach = 43,
    MiragePrism = 44,
    Colorant = 45,
    Howto = 46,
    HowtoNotice = 47,
    ContentsTutorial = 48,
    Inspect = 49,
    Teleport = 50,
    TelepotTown = 51,
    ContentsFinder = 52,
    ContentsFinderSetting = 53,
    Social = 54,
    SocialBlacklist = 55,
    SocialFriendList = 56,
    Linkshell = 57,
    SocialPartyMember = 58,
    SocialSearch = 60,
    SocialDetail = 61,
    LetterList = 62,
    LetterView = 63,
    LetterEdit = 64,
    ItemDetail = 65,
    ActionDetail = 66,
    Retainer = 67,
    Return = 68,
    Cutscene = 69,
    CutsceneReplay = 70,
    MonsterNote = 71,
    ItemSearch = 72,
    GoldSaucerReward = 73,
    FateProgress = 74,
    Catch = 75,
    FreeCompany = 76,
    FreeCompanyProfile = 78,
    FreeCompanyProfileEdit = 79,
    FreeCompanyInputString = 81,
    FreeCompanyChest = 82,
    FreeCompanyExchange = 83,
    FreeCompanyCrestEditor = 84,
    FreeCompanyCrestDecal = 85,
    ArmouryBoard = 87,
    HowtoList = 88,
    Cabinet = 89,
    LegacyItemStorage = 90,
    GrandCompanyRank = 91,
    GrandCompanySupply = 92,
    GrandCompanyExchange = 93,
    Gearset = 94,
    SupportMain = 95,
    SupportList = 96,
    SupportView = 97,
    SupportEdit = 98,
    Achievement = 99,
    LicenseViewer = 101,
    ContentsTimer = 102,
    MovieSubtitle = 103,
    PadMouseMode = 104,
    RecommendList = 105,
    Buddy = 106,
    ColosseumRecord = 107,
    CloseMessage = 108,
    CreditPlayer = 109,
    CreditScroll = 110,
    CreditCast = 111,
    CreditEnd = 112,
    CreditCutCast = 113,
    Shop = 114,
    Bait = 115,
    Housing = 116,
    HousingHarvest = 117,
    HousingSignboard = 118,
    HousingPortal = 119,
    HousingTravellersNote = 120,
    HousingPlant = 121,
    PersonalRoomPortal = 122,
    HousingBuddyList = 123,
    TreasureHunt = 124,
    Salvage = 125,
    LookingForGroup = 126,
    ContentsMvp = 127,
    VoteKick = 128,
    VoteGiveUp = 129,
    VoteTreasure = 130,
    PvpProfile = 131,
    ContentsNote = 132,
    ReadyCheck = 133,
    FieldMarker = 134,
    CursorLocation = 135,
    CursorRect = 136,
    RetainerStatus = 137,
    RetainerTask = 138,
    RetainerItemTransfer = 141,
    RelicNotebook = 143,
    RelicSphere = 144,
    TradeMultiple = 145,
    RelicSphereUpgrade = 146,
    Relic2Glass = 149,
    Minigame = 150,
    Tryon = 151,
    TryonRetainer = 152,
    AdventureNotebook = 153,
    ArmouryNotebook = 154,
    MinionNotebook = 155,
    MountNotebook = 156,
    ItemCompare = 157,
    DailyQuestSupply = 158,
    MobHunt = 159,
    PatchMark = 160,
    HousingWithdrawStorage = 161,
    WeatherReport = 162,
    LoadingTips = 164,
    Revive = 165,
    ChocoboRace = 167,
    GoldSaucerMiniGame = 169,
    TrippleTriad = 170,
    LotteryDaily = 178,
    AetherialWheel = 179,
    LotteryWeekly = 180,
    GoldSaucer = 181,
    TripleTriadCoinExchange = 182,
    ShopExchangeCoin = 183,
    JournalAccept = 184,
    JournalResult = 185,
    LeveQuest = 186,
    CompanyCraftRecipeNoteBook = 187,
    AirShipParts = 188,
    AirShipExploration = 189,
    AirShipExplorationResult = 190,
    AirShipExplorationDetail = 191,
    SubmersibleParts = 192,
    SubmersibleExploration = 193,
    SubmersibleExplorationResult = 194,
    SubmersibleExplorationDetail = 195,
    CompanyCraftMaterial = 196,
    AetherCurrent = 197,
    FreeCompanyCreditShop = 198,
    Currency = 199,
    PuryfyItemSelector = 200,
    LovmParty = 202,
    LovmRanking = 203,
    LovmNamePlate = 204,
    CharacterTitle = 205,
    CharacterTitleSelect = 206,
    LovmResult = 207,
    LovmPaletteEdit = 208,
    SkyIslandFinder = 209,
    SkyIslandFinderSetting = 210,
    SkyIslandResult = 211,
    SkyIsland2Result = 212,
    ItemContextCustomize = 213,
    BeginnersMansionProblem = 214,
    DpsChallenge = 215,
    PlayGuide = 216,
    WebLauncher = 217,
    WebGuidance = 218,
    Orchestrion = 219,
    BeginnerChatList = 220,
    ReturnerDialog = 223,
    OrchestrionInn = 224,
    HousingEditContainer = 225,
    ConfigPartyListRoleSort = 226,
    RecommendEquip = 227,
    YkwNote = 228,
    ContentsFinderMenu = 229,
    RaidFinder = 230,
    GcArmyExpedition = 231,
    GcArmyMemberList = 232,
    DeepDungeonInspect = 234,
    DeepDungeonMap = 235,
    DeepDungeonStatus = 236,
    DeepDungeonSaveData = 237,
    DeepDungeonScore = 238,
    GcArmyTraining = 239,
    GcArmyMenberProfile = 240,
    GcArmyExpeditionResult = 241,
    GcArmyCapture = 242,
    GcArmyOrder = 243,
    MansionSelectRoom = 244,
    OrchestrionPlayList = 245,
    CountDownSettingDialog = 246,
    WeeklyBingo = 247,
    WeeklyPuzzle = 248,
    CameraSetting = 249,
    PvPDuelRequest = 250,
    PvPHeader = 251,
    AquariumSetting = 255,
    DeepDungeonMenu = 257,
    DeepDungeonResult = 259,
    ItemAppraisal = 260,
    ItemInspection = 261,
    RecipeItemContext = 262,
    ContactList = 263,
    SatisfactionSupply = 266,
    SatisfactionSupplyResult = 267,
    Snipe = 268,
    MountSpeed = 269,
    HarpoonTip = 270,
    PvpScreenInformationHotBar = 271,
    PvpWelcome = 272,
    UserPolicyPerformance = 277,
    PvpTeamInputString = 279,
    PvpTeamCrestEditor = 284,
    PvpTeam = 285,
    EurekaElementalHud = 287,
    EurekaElementalEdit = 288,
    EurekaChainInfo = 289,
    TeleportHousingFriend = 293,
    ContentMemberList = 294,
    InventoryBuddy = 295,
    ContentsReplayPlayer = 296,
    ContentsReplaySetting = 297,
    MiragePrismPrismBox = 298,
    MiragePrismPrismItemDetail = 299,
    MiragePrismMiragePlate = 300,
    PerformanceMode = 301,
    Fashion = 304,
    SelectYesno = 306,
    HousingGuestBook = 307,
    ReconstructionBox = 310,
    ReconstructionBuyback = 311,
    CrossWorldLinkShell = 312,
    MiragePrismENpcSatisfaction = 313,
    Description = 314,
    Alarm = 315,
    FreeShop = 318,
    AozNotebook = 319,
    RhythmAction = 320,
    WeddingNotification = 321,
    Emj = 322,
    EmjIntro = 325,
    AozContentBriefing = 326,
    AozContentResult = 327,
    WorldTravel = 328,
    RideShooting = 329,
    Credit = 331,
    EmjSetting = 332,
    RetainerList = 333,
    QIBCStatus = 334,
    Dawn = 338,
    DawnStory = 339,
    HousingCatalogPreview = 340,
    SubmersibleExplorationMapSelect = 342,
    QuestRedo = 343,
    QuestRedoHud = 344,
    CircleList = 346,
    CircleBook = 347,
    CircleFinder = 352,
    MentorCondition = 354,
    PerformanceMetronome = 355,
    PerformanceGamepadGuide = 356,
    PerformanceReadyCheck = 358,
    HwdAetherGauge = 362,
    HwdScore = 364,
    HwdMonument = 366,
    McGuffin = 367,
    CraftActionSimulator = 368,
    MycWarResultNotebook = 375,
    MycInfo = 376,
    MycItemBox = 377,
    MycItemBag = 378,
    MycBattleAreaInfo = 380,
    OrnamentNoteBook = 382,
    TourismMenu = 384,
    StarlightGiftBox = 386,
    SpearFishing = 387,
    Omikuji = 388,
    FittingShop = 389,
    AkatsukiNote = 390,
    ExHotbarEditor = 391,
    BannerList = 392,
    BannerEditor = 393,
    BannerUpdateView = 394,
    PvPMap = 395,
    CharaCard = 397,
    CharaCardDesignSetting = 398,
    CharaCardProfileSetting = 399,
    PvPMKSIntroduction = 401,
    MJIHud = 402,
    MJIPouch = 403,
    MJIRecipeNoteBook = 404,
    MJICraftSchedule = 405,
    MJICraftSales = 406,
    MJIAnimalManagement = 407,
    MJIFarmManagement = 408,
    MJIGatheringHouse = 409,
    MJIBuilding = 410,
    MJIGatheringNoteBook = 411,
    MJIDisposeShop = 412,
    MJIMinionManagement = 413,
    MJIMinionNoteBook = 414,
    MJIBuildingMove = 415,
    MJIEntrance = 416,
    MJISettings = 417,
    ArchiveItem = 418,
    VVDNotebook = 419,
    VVDFinder = 420,
    TofuList = 421,
    BannerParty = 423,
    BannerMIP = 424
};

struct Client::UI::Agent::AgentMonsterNote /* Size=0x68 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ StdVector::ClientSystemStringUtf8String StringVector;
    /* 0x40 */ unsigned __int32 BaseId;
    /* 0x44 */ byte ClassId;
    /* 0x45 */ byte ClassIndex;
    /* 0x46 */ byte MonsterNote;
    /* 0x47 */ byte Rank;
    /* 0x48 */ byte Filter;
    /*      */ byte _gap_0x49;
    /*      */ byte _gap_0x4A[0x2];
    /*      */ byte _gap_0x4C[0x4];
    /*      */ byte _gap_0x50[0x8];
    /*      */ byte _gap_0x58[0x4];
    /* 0x5C */ byte IsLocked;
    /*      */ byte _gap_0x5D;
    /*      */ byte _gap_0x5E[0x2];
    /*      */ byte _gap_0x60[0x8];
};

struct Client::UI::Agent::MycItemCategory /* Size=0x184 */
{
    /* 0x000 */ byte ItemArray[0x180];
    /* 0x180 */ __int32 ItemCount;
};

struct Client::UI::Agent::MycItemBoxData /* Size=0x1580 */
{
    union {
    /* 0x0000 */ byte ItemCacheArray[0xA9C];
    /* 0x0000 */ Client::UI::Agent::MycItemCategory OffensiveCache;
    } _union_0x8;
    /*        */ byte _gap_0x8[0x180];
    /*        */ byte _gap_0x188[0x4];
    /* 0x018C */ Client::UI::Agent::MycItemCategory DefensiveCache;
    /* 0x0310 */ Client::UI::Agent::MycItemCategory RestorativeCache;
    /* 0x0494 */ Client::UI::Agent::MycItemCategory BeneficialCache;
    /* 0x0618 */ Client::UI::Agent::MycItemCategory TacticalCache;
    /* 0x079C */ Client::UI::Agent::MycItemCategory DetrimentalCache;
    /* 0x0920 */ Client::UI::Agent::MycItemCategory ItemRelatedCache;
    union {
    /* 0x0AA4 */ byte ItemHolsterArray[0xA9C];
    /* 0x0AA4 */ Client::UI::Agent::MycItemCategory OffensiveHolster;
    } _union_0xAA4;
    /*        */ byte _gap_0xAAC[0x4];
    /*        */ byte _gap_0xAB0[0x178];
    /* 0x0C28 */ Client::UI::Agent::MycItemCategory DefensiveHolster;
    /* 0x0DAC */ Client::UI::Agent::MycItemCategory RestorativeHolster;
    /* 0x0F30 */ Client::UI::Agent::MycItemCategory BeneficialHolster;
    /* 0x10B4 */ Client::UI::Agent::MycItemCategory TacticalHolster;
    /* 0x1238 */ Client::UI::Agent::MycItemCategory DetrimentalHolster;
    /* 0x13BC */ Client::UI::Agent::MycItemCategory ItemRelatedHolster;
    /*        */ byte _gap_0x1540[0x10];
    /* 0x1550 */ __int32 HolsterCurrentTab;
    /*        */ byte _gap_0x1554[0x4];
    /* 0x1558 */ __int32 LastSelectedActionId;
    /*        */ byte _gap_0x155C[0x4];
    /*        */ byte _gap_0x1560[0x20];
};

struct Client::UI::Agent::AgentMycItemBox /* Size=0x58 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /*      */ byte _gap_0x28[0x18];
    /* 0x40 */ Client::UI::Agent::MycItemBoxData* ItemBoxData;
    /*      */ byte _gap_0x48[0x10];
};

struct Client::UI::Agent::MycItem /* Size=0x8 */
{
    /* 0x0 */ __int32 ActionId;
    /* 0x4 */ __int32 Count;
};

struct Client::UI::Agent::AgentReadyCheck /* Size=0x3B0 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x88];
    /* 0x0B0 */ byte ReadyCheckEntries[0x300];
};

struct Client::UI::Agent::AgentRecipeNote /* Size=0x560 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x390];
    /*       */ byte _gap_0x3B8[0x4];
    /* 0x3BC */ __int32 SelectedRecipeIndex;
    /*       */ byte _gap_0x3C0[0x10];
    /*       */ byte _gap_0x3D0[0x4];
    /* 0x3D4 */ unsigned __int32 ActiveCraftRecipeId;
    /*       */ byte _gap_0x3D8[0x188];
};

struct Client::UI::Agent::AgentReconstructionBox /* Size=0x240 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x28];
    /* 0x050 */ byte ItemDonationArray[0xF0];
    union {
    /* 0x140 */ __int32 LimitedTotal;
    /* 0x140 */ __int32 UnlimitedTotal;
    } _union_0x21C;
    /*       */ byte _gap_0x148[0xF8];
};

struct Client::UI::Agent::AgentItemDonationInfo /* Size=0x18 */
{
    /* 0x00 */ void* UnkPtr1;
    /* 0x08 */ void* UnkPtr2;
    /* 0x10 */ void* UnkPtr3;
};

struct Client::UI::Agent::AgentRequest /* Size=0x460 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0xE8];
    /*       */ byte _gap_0x110[0x4];
    /* 0x114 */ signed __int8 SelectedTurnInSlot;
    /*       */ byte _gap_0x115;
    /*       */ byte _gap_0x116[0x2];
    /*       */ byte _gap_0x118[0x8];
    /*       */ byte _gap_0x120[0x4];
    /* 0x124 */ __int16 SelectedTurnInSlotItemOptions;
    /*       */ byte _gap_0x126[0x2];
    /*       */ byte _gap_0x128[0x338];
};

struct Client::UI::Agent::AgentRetainerItemTransferData /* Size=0x41E8 */
{
    /* 0x0000 */ __int32 ItemCount;
    /*        */ byte _gap_0x4[0x4];
    /*        */ byte _gap_0x8[0x8];
    /* 0x0010 */ byte DuplicateItem[0x41A0];
    /*        */ byte _gap_0x41B0[0x38];
};

struct Client::UI::Agent::AgentRetainerItemTransfer /* Size=0x38 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::UI::Agent::AgentRetainerItemTransferData* Data;
    /*      */ byte _gap_0x30[0x8];
};

struct Client::UI::Agent::AgentRetainerList::Retainer /* Size=0x70 */
{
    /* 0x00 */ Client::System::String::Utf8String Name;
    /*      */ byte _gap_0x68[0x4];
    /* 0x6C */ byte Index;
    /* 0x6D */ byte SortedIndex;
    /*      */ byte _gap_0x6E[0x2];
};

struct Client::UI::Agent::AgentRetainerList::RetainerList /* Size=0x460 */
{
    /* 0x000 */ Client::UI::Agent::AgentRetainerList::Retainer Retainer0;
    /* 0x070 */ Client::UI::Agent::AgentRetainerList::Retainer Retainer1;
    /* 0x0E0 */ Client::UI::Agent::AgentRetainerList::Retainer Retainer2;
    /* 0x150 */ Client::UI::Agent::AgentRetainerList::Retainer Retainer3;
    /* 0x1C0 */ Client::UI::Agent::AgentRetainerList::Retainer Retainer4;
    /* 0x230 */ Client::UI::Agent::AgentRetainerList::Retainer Retainer5;
    /* 0x2A0 */ Client::UI::Agent::AgentRetainerList::Retainer Retainer6;
    /* 0x310 */ Client::UI::Agent::AgentRetainerList::Retainer Retainer7;
    /* 0x380 */ Client::UI::Agent::AgentRetainerList::Retainer Retainer8;
    /* 0x3F0 */ Client::UI::Agent::AgentRetainerList::Retainer Retainer9;
};

struct Client::UI::Agent::AgentRetainerList /* Size=0x5B8 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x8];
    /* 0x030 */ unsigned __int32 RetainerListOpenedTime;
    /* 0x034 */ unsigned __int32 RetainerListSortAddonId;
    /*       */ byte _gap_0x38[0x10];
    /* 0x048 */ byte RetainerCount;
    /*       */ byte _gap_0x49;
    /*       */ byte _gap_0x4A[0x2];
    /*       */ byte _gap_0x4C[0x4];
    /* 0x050 */ Client::UI::Agent::AgentRetainerList::RetainerList Retainers;
    /*       */ byte _gap_0x4B0[0x108];
};

struct Client::Game::UI::Revive /* Size=0x30 */
{
    /* 0x00 */ Component::GUI::AtkEventInterface AtkEventInterface;
    /*      */ byte _gap_0x8[0x8];
    /*      */ byte _gap_0x10[0x4];
    /* 0x14 */ float Timer;
    /*      */ byte _gap_0x18[0x8];
    /*      */ byte _gap_0x20[0x4];
    /* 0x24 */ byte ReviveState;
    /*      */ byte _gap_0x25;
    /*      */ byte _gap_0x26[0x2];
    /*      */ byte _gap_0x28[0x8];
};

struct Client::UI::Agent::AgentRevive /* Size=0xB8 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /* 0x28 */ Client::Game::UI::Revive* Revive;
    /*      */ byte _gap_0x30[0x8];
    /* 0x38 */ byte ReviveState;
    /*      */ byte _gap_0x39;
    /*      */ byte _gap_0x3A[0x2];
    /*      */ byte _gap_0x3C[0x4];
    /* 0x40 */ __int32 ResurrectionTimeLeft;
    /* 0x44 */ unsigned __int32 ResurrectingPlayerId;
    /* 0x48 */ Client::System::String::Utf8String ResurrectingPlayerName;
    /*      */ byte _gap_0xB0[0x8];
};

struct Client::UI::Agent::AgentSalvage::SalvageListItem /* Size=0x88 */
{
    /* 0x00 */ Client::System::String::Utf8String Name;
    /* 0x68 */ Client::Game::InventoryType InventoryType;
    /* 0x6C */ unsigned __int32 InventorySlot;
    /* 0x70 */ unsigned __int32 Quantity;
    /* 0x74 */ unsigned __int32 ItemId;
    /* 0x78 */ unsigned __int32 ClassJob;
    /* 0x7C */ byte Flags;
    /*      */ byte _gap_0x7D;
    /*      */ byte _gap_0x7E[0x2];
    /*      */ byte _gap_0x80[0x8];
};

struct Client::UI::Agent::SalvageResult /* Size=0x8 */
{
    /* 0x0 */ unsigned __int32 ItemId;
    /* 0x4 */ __int32 Quantity;
};

struct Client::UI::Agent::AgentSalvage /* Size=0x3D0 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x8];
    /* 0x030 */ Client::UI::Agent::AgentSalvage::SalvageItemCategory SelectedCategory;
    /*       */ byte _gap_0x34[0x4];
    /* 0x038 */ Client::UI::Agent::AgentSalvage::SalvageListItem* ItemList;
    /* 0x040 */ Client::System::String::Utf8String TextCarpenter;
    /* 0x0A8 */ Client::System::String::Utf8String TextBlacksmith;
    /* 0x110 */ Client::System::String::Utf8String TextArmourer;
    /* 0x178 */ Client::System::String::Utf8String TextGoldsmith;
    /* 0x1E0 */ Client::System::String::Utf8String TextLeatherworker;
    /* 0x248 */ Client::System::String::Utf8String TextWeaver;
    /* 0x2B0 */ Client::System::String::Utf8String TextAlchemist;
    /* 0x318 */ Client::System::String::Utf8String TextCulinarian;
    /* 0x380 */ unsigned __int32 ItemCount;
    /*       */ byte _gap_0x384[0x4];
    /*       */ byte _gap_0x388[0x8];
    /* 0x390 */ Client::Game::InventoryItem* DesynthItemSlot;
    /* 0x398 */ Client::UI::Agent::SalvageResult DesynthItem;
    /*       */ byte _gap_0x3A0[0x4];
    /* 0x3A4 */ unsigned __int32 DesynthItemId;
    /* 0x3A8 */ byte DesynthResult[0x18];
    /*       */ byte _gap_0x3C0[0x10];
};

struct Client::UI::Agent::AgentSatisfactionSupply::SatisfactionSupplyNpcInfo /* Size=0x1A */
{
    /* 0x00 */ unsigned __int32 Id;
    /* 0x04 */ unsigned __int32 SatisfactionRank;
    /*      */ byte _gap_0x8[0x8];
    /*      */ byte _gap_0x10[0x4];
    /* 0x14 */ unsigned __int16 SelectedItemIndex;
    /*      */ byte _gap_0x16[0x2];
    /*      */ byte _gap_0x18;
    /* 0x19 */ byte IsQuestSomething;
};

struct Client::UI::Agent::AgentSatisfactionSupply /* Size=0x500 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x18];
    /* 0x040 */ Client::UI::Agent::AgentSatisfactionSupply::SatisfactionSupplyNpcInfo NpcInfo;
    /*       */ byte _gap_0x5A[0x2];
    /*       */ byte _gap_0x5C[0x2];
    /* 0x05E */ unsigned __int16 ClassJobId;
    /* 0x060 */ unsigned __int16 ClassJobLevel;
    /*       */ byte _gap_0x62[0x2];
    /* 0x064 */ unsigned __int32 NpcId;
    /*       */ byte _gap_0x68[0x10];
    /* 0x078 */ unsigned __int16 RemainingAllowances;
    /* 0x07A */ __int16 LevelUnlocked;
    /* 0x07C */ byte CanGlamour;
    /*       */ byte _gap_0x7D;
    /*       */ byte _gap_0x7E[0x2];
    /* 0x080 */ byte Item[0xB4];
    /*       */ byte _gap_0x134[0x4];
    /* 0x138 */ void* ENpcResidentRow;
    /* 0x140 */ void* Item1Row;
    /* 0x148 */ void* Item2Row;
    /* 0x150 */ void* Item3Row;
    /* 0x158 */ byte DeliveryInfo[0x318];
    /* 0x470 */ void* Item1Reward1Row;
    /* 0x478 */ void* Item2Reward1Row;
    /* 0x480 */ void* Item3Reward1Row;
    /* 0x488 */ void* Item1Reward2Row;
    /* 0x490 */ void* Item2Reward2Row;
    /* 0x498 */ void* Item3Reward2Row;
    /* 0x4A0 */ void* GilRow;
    /* 0x4A8 */ void* WhiteCrafterScriptRow;
    /* 0x4B0 */ void* PurpleCrafterScriptRow;
    /* 0x4B8 */ void* WhiteGathererScriptRow;
    /* 0x4C0 */ void* PurpleGathererScriptRow;
    /* 0x4C8 */ void* FishingSpotRow;
    /* 0x4D0 */ void* SpearFishingNotebookRow;
    /* 0x4D8 */ unsigned __int32 WhiteCrafterScrriptId;
    /* 0x4DC */ unsigned __int32 PurpleCrafterScriptId;
    /* 0x4E0 */ unsigned __int32 WhiteGathererScriptId;
    /* 0x4E4 */ unsigned __int32 PurpleGathererScriptId;
    /* 0x4E8 */ unsigned __int32 TimeRemainingHours;
    /* 0x4EC */ unsigned __int32 TimeRemainingMinutes;
    /*       */ byte _gap_0x4F0[0x10];
};

struct Client::UI::Agent::AgentDeliveryItemInfo /* Size=0x108 */
{
    /*       */ byte _gap_0x0[0xA0];
    /* 0x0A0 */ Client::System::String::Utf8String ItemName;
};

enum BalloonType: unsigned __int32
{
    Timer = 0,
    Unknown = 1
};

struct Client::UI::Agent::BalloonSlot /* Size=0x8 */
{
    /* 0x0 */ __int32 Id;
    /* 0x4 */ byte Available;
    /*     */ byte _gap_0x5;
    /*     */ byte _gap_0x6[0x2];
};

struct StdDeque::ClientUIAgentBalloonInfo /* Size=0x28 */
{
    /* 0x00 */ void* ContainerBase;
    /* 0x08 */ Client::UI::Agent::BalloonInfo** Map;
    /* 0x10 */ unsigned __int64 MapSize;
    /* 0x18 */ unsigned __int64 MyOff;
    /* 0x20 */ unsigned __int64 MySize;
};

struct Client::UI::Agent::AgentScreenLog /* Size=0x3F0 */
{
    /* 0x000 */ Component::GUI::AgentInterface AgentInterface;
    /*       */ byte _gap_0x28[0x328];
    /* 0x350 */ StdDeque::ClientUIAgentBalloonInfo BalloonQueue;
    /* 0x378 */ byte BalloonsHaveUpdate;
    /*       */ byte _gap_0x379;
    /*       */ byte _gap_0x37A[0x2];
    /* 0x37C */ __int32 BalloonCounter;
    /*       */ byte _gap_0x380[0x10];
    /* 0x390 */ byte BalloonSlots[0x50];
    /*       */ byte _gap_0x3E0[0x10];
};

struct Client::Game::UI::TeleportInfo /* Size=0x20 */
{
    /* 0x00 */ unsigned __int32 AetheryteId;
    /* 0x04 */ unsigned __int32 GilCost;
    /* 0x08 */ unsigned __int16 TerritoryId;
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC[0x4];
    /*      */ byte _gap_0x10[0x8];
    /* 0x18 */ byte Ward;
    /* 0x19 */ byte Plot;
    /* 0x1A */ byte SubIndex;
    /* 0x1B */ byte IsFavourite;
    /*      */ byte _gap_0x1C[0x4];
};

struct StdVector::ClientGameUITeleportInfo /* Size=0x18 */
{
    /* 0x00 */ Client::Game::UI::TeleportInfo* First;
    /* 0x08 */ Client::Game::UI::TeleportInfo* Last;
    /* 0x10 */ Client::Game::UI::TeleportInfo* End;
};

struct Client::UI::Agent::AgentTeleport /* Size=0x90 */
{
    /* 0x00 */ Component::GUI::AgentInterface AgentInterface;
    /*      */ byte _gap_0x28[0x38];
    /* 0x60 */ __int32 AetheryteCount;
    /*      */ byte _gap_0x64[0x4];
    /* 0x68 */ StdVector::ClientGameUITeleportInfo* AetheryteList;
    /*      */ byte _gap_0x70[0x20];
};

struct Client::System::Scheduler::Resource::SchedulerResource::ResourceName /* Size=0x40 */
{
    /* 0x00 */ void** VTable;
    /* 0x08 */ byte* DataPointer;
    /* 0x10 */ unsigned __int16 Unk1;
    /* 0x12 */ byte Buffer[0x2E];
};

struct Client::System::Scheduler::Resource::SchedulerResource /* Size=0x88 */
{
    /* 0x00 */ void** VTable;
    /* 0x08 */ Client::System::Scheduler::Resource::SchedulerResource* Next;
    /* 0x10 */ Client::System::Scheduler::Resource::SchedulerResource* Previous;
    /*      */ byte _gap_0x18[0x8];
    /* 0x20 */ Client::System::Resource::Handle::ResourceHandle* Resource;
    /*      */ byte _gap_0x28[0x10];
    /* 0x38 */ Client::System::Scheduler::Resource::SchedulerResource::ResourceName Name;
    /* 0x78 */ unsigned __int32 Unk1;
    /* 0x7C */ unsigned __int32 Consumers;
    /*      */ byte _gap_0x80[0x8];
};

struct Client::System::Scheduler::Resource::SchedulerResourceManagement /* Size=0x58 */
{
    /* 0x00 */ void** VTable;
    /* 0x08 */ Client::System::Scheduler::Resource::SchedulerResource* Begin;
    /* 0x10 */ void* Unknown;
    /* 0x18 */ unsigned __int64 NumResources;
    /*      */ byte _gap_0x20[0x38];
};

struct Client::System::Scheduler::Base::SchedulerState /* Size=0x18 */
{
    /* 0x00 */ void** VTable;
    /*      */ byte _gap_0x8[0x10];
};

struct Client::System::Scheduler::Base::TimelineController /* Size=0x80 */
{
    /* 0x00 */ Client::System::Scheduler::Base::SchedulerState SchedulerState;
    /*      */ byte _gap_0x18[0x68];
};

struct Client::System::Scheduler::Base::SchedulerTimeline::SchedulerTimelineVTable /* Size=0xE8 */
{
    /*      */ byte _gap_0x0[0xE0];
    /* 0xE0 */ __int64 GetOwningGameObjectIndex;
};

struct Client::System::Scheduler::Base::SchedulerTimeline /* Size=0x280 */
{
    union {
    /* 0x000 */ Client::System::Scheduler::Base::TimelineController TimelineController;
    /* 0x000 */ Client::System::Scheduler::Base::SchedulerTimeline::SchedulerTimelineVTable* VTable;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x180];
    /*       */ byte _gap_0x188[0x4];
    /* 0x18C */ unsigned __int32 OwningGameObjectIndex;
    /*       */ byte _gap_0x190[0xF0];
};

struct Pointer::StdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdPair::SystemUInt32::PointerStdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle /* Size=0x10 */
{
    /* 0x00 */ unsigned __int32 Item1;
    /*      */ byte _gap_0x4[0x4];
    /* 0x08 */ Pointer::StdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle Item2;
};

struct StdMap::Node::SystemUInt32::PointerStdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle /* Size=0x38 */
{
    /* 0x00 */ StdMap::Node::SystemUInt32::PointerStdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle* Left;
    /* 0x08 */ StdMap::Node::SystemUInt32::PointerStdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle* Parent;
    /* 0x10 */ StdMap::Node::SystemUInt32::PointerStdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle* Right;
    /* 0x18 */ byte Color;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /* 0x1C */ bool IsNil;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ byte _18;
    /* 0x21 */ byte _19;
    /*      */ byte _gap_0x22[0x2];
    /*      */ byte _gap_0x24[0x4];
    /* 0x28 */ StdPair::SystemUInt32::PointerStdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle KeyValuePair;
};

struct StdMap::SystemUInt32::PointerStdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle /* Size=0x10 */
{
    /* 0x00 */ StdMap::Node::SystemUInt32::PointerStdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle* Head;
    /* 0x08 */ unsigned __int64 Count;
};

struct Client::System::Resource::ResourceGraph::CategoryContainer /* Size=0xA0 */
{
    union {
    /* 0x00 */ byte CategoryMaps[0xA0];
    /* 0x00 */ StdMap::SystemUInt32::PointerStdMapSystemUInt32PointerClientSystemResourceHandleResourceHandle* MainMap;
    } _union_0x0;
    /*      */ byte _gap_0x8[0x98];
};

struct Client::System::Resource::ResourceGraph /* Size=0xC80 */
{
    union {
    /* 0x000 */ byte ContainerArray[0xC80];
    /* 0x000 */ Client::System::Resource::ResourceGraph::CategoryContainer CommonContainer;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x98];
    /* 0x0A0 */ Client::System::Resource::ResourceGraph::CategoryContainer BgCommonContainer;
    /* 0x140 */ Client::System::Resource::ResourceGraph::CategoryContainer BgContainer;
    /* 0x1E0 */ Client::System::Resource::ResourceGraph::CategoryContainer CutContainer;
    /* 0x280 */ Client::System::Resource::ResourceGraph::CategoryContainer CharaContainer;
    /* 0x320 */ Client::System::Resource::ResourceGraph::CategoryContainer ShaderContainer;
    /* 0x3C0 */ Client::System::Resource::ResourceGraph::CategoryContainer UiContainer;
    /* 0x460 */ Client::System::Resource::ResourceGraph::CategoryContainer SoundContainer;
    /* 0x500 */ Client::System::Resource::ResourceGraph::CategoryContainer VfxContainer;
    /* 0x5A0 */ Client::System::Resource::ResourceGraph::CategoryContainer UiScriptContainer;
    /* 0x640 */ Client::System::Resource::ResourceGraph::CategoryContainer ExdContainer;
    /* 0x6E0 */ Client::System::Resource::ResourceGraph::CategoryContainer GameScriptContainer;
    /* 0x780 */ Client::System::Resource::ResourceGraph::CategoryContainer MusicContainer;
    /*       */ byte _gap_0x820[0x320];
    /* 0xB40 */ Client::System::Resource::ResourceGraph::CategoryContainer SqpackTestContainer;
    /* 0xBE0 */ Client::System::Resource::ResourceGraph::CategoryContainer DebugContainer;
};

struct Client::System::Resource::ResourceManager /* Size=0x1728 */
{
    /*        */ byte _gap_0x0[0x8];
    /* 0x0008 */ Client::System::Resource::ResourceGraph* ResourceGraph;
    /*        */ byte _gap_0x10[0x1718];
};

struct Client::System::Resource::Handle::MaterialResourceHandle /* Size=0x108 */
{
    /* 0x000 */ Client::System::Resource::Handle::ResourceHandle ResourceHandle;
    /*       */ byte _gap_0xB0[0x58];
};

struct FFXIVClientStructs::Havok::hkBaseObject::hkBaseObjectVtbl /* Size=0x10 */
{
    /* 0x00 */ void* dtor;
    /* 0x08 */ void* __first_virtual_table_function__;
};

struct FFXIVClientStructs::Havok::hkBaseObject /* Size=0x8 */
{
    /* 0x0 */ FFXIVClientStructs::Havok::hkBaseObject::hkBaseObjectVtbl* vfptr;
};

struct FFXIVClientStructs::Havok::hkReferencedObject /* Size=0x10 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkBaseObject hkBaseObject;
    /* 0x08 */ unsigned __int32 MemSizeAndRefCount;
    /*      */ byte _gap_0xC[0x4];
};

struct FFXIVClientStructs::Havok::hkStringPtr /* Size=0x8 */
{
    /* 0x0 */ byte* StringAndFlag;
};

struct FFXIVClientStructs::Havok::hkArray::SystemInt16 /* Size=0x10 */
{
    /* 0x00 */ __int16* Data;
    /* 0x08 */ __int32 Length;
    /* 0x0C */ __int32 CapacityAndFlags;
};

struct FFXIVClientStructs::Havok::hkaBone /* Size=0x10 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkStringPtr Name;
    /* 0x08 */ byte LockTranslation;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC[0x4];
};

struct FFXIVClientStructs::Havok::hkArray::FFXIVClientStructsHavokhkaBone /* Size=0x10 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkaBone* Data;
    /* 0x08 */ __int32 Length;
    /* 0x0C */ __int32 CapacityAndFlags;
};

struct FFXIVClientStructs::Havok::hkVector4f /* Size=0x10 */
{
    /* 0x00 */ float X;
    /* 0x04 */ float Y;
    /* 0x08 */ float Z;
    /* 0x0C */ float W;
};

struct FFXIVClientStructs::Havok::hkQuaternionf /* Size=0x10 */
{
    /* 0x00 */ float X;
    /* 0x04 */ float Y;
    /* 0x08 */ float Z;
    /* 0x0C */ float W;
};

struct FFXIVClientStructs::Havok::hkQsTransformf /* Size=0x30 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkVector4f Translation;
    /* 0x10 */ FFXIVClientStructs::Havok::hkQuaternionf Rotation;
    /* 0x20 */ FFXIVClientStructs::Havok::hkVector4f Scale;
};

struct FFXIVClientStructs::Havok::hkArray::FFXIVClientStructsHavokhkQsTransformf /* Size=0x10 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkQsTransformf* Data;
    /* 0x08 */ __int32 Length;
    /* 0x0C */ __int32 CapacityAndFlags;
};

struct FFXIVClientStructs::Havok::hkArray::SystemSingle /* Size=0x10 */
{
    /* 0x00 */ float* Data;
    /* 0x08 */ __int32 Length;
    /* 0x0C */ __int32 CapacityAndFlags;
};

struct FFXIVClientStructs::Havok::hkArray::FFXIVClientStructsHavokhkStringPtr /* Size=0x10 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkStringPtr* Data;
    /* 0x08 */ __int32 Length;
    /* 0x0C */ __int32 CapacityAndFlags;
};

struct FFXIVClientStructs::Havok::hkLocalFrame /* Size=0x10 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkReferencedObject hkReferencedObject;
};

struct FFXIVClientStructs::Havok::hkRefPtr::FFXIVClientStructsHavokhkLocalFrame /* Size=0x8 */
{
    /* 0x0 */ FFXIVClientStructs::Havok::hkLocalFrame* ptr;
};

struct FFXIVClientStructs::Havok::hkaSkeleton::LocalFrameOnBone /* Size=0x10 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkRefPtr::FFXIVClientStructsHavokhkLocalFrame LocalFrame;
    /* 0x08 */ __int16 BoneIndex;
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC[0x4];
};

struct FFXIVClientStructs::Havok::hkArray::FFXIVClientStructsHavokhkaSkeletonLocalFrameOnBone /* Size=0x10 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkaSkeleton::LocalFrameOnBone* Data;
    /* 0x08 */ __int32 Length;
    /* 0x0C */ __int32 CapacityAndFlags;
};

struct FFXIVClientStructs::Havok::hkaSkeleton::Partition /* Size=0x10 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkStringPtr Name;
    /* 0x08 */ __int16 StartBoneIndex;
    /* 0x0A */ __int16 NumBones;
    /*      */ byte _gap_0xC[0x4];
};

struct FFXIVClientStructs::Havok::hkArray::FFXIVClientStructsHavokhkaSkeletonPartition /* Size=0x10 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkaSkeleton::Partition* Data;
    /* 0x08 */ __int32 Length;
    /* 0x0C */ __int32 CapacityAndFlags;
};

struct FFXIVClientStructs::Havok::hkaSkeleton /* Size=0x88 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkReferencedObject hkReferencedObject;
    /* 0x10 */ FFXIVClientStructs::Havok::hkStringPtr Name;
    /* 0x18 */ FFXIVClientStructs::Havok::hkArray::SystemInt16 ParentIndices;
    /* 0x28 */ FFXIVClientStructs::Havok::hkArray::FFXIVClientStructsHavokhkaBone Bones;
    /* 0x38 */ FFXIVClientStructs::Havok::hkArray::FFXIVClientStructsHavokhkQsTransformf ReferencePose;
    /* 0x48 */ FFXIVClientStructs::Havok::hkArray::SystemSingle ReferenceFloats;
    /* 0x58 */ FFXIVClientStructs::Havok::hkArray::FFXIVClientStructsHavokhkStringPtr FloatSlots;
    /* 0x68 */ FFXIVClientStructs::Havok::hkArray::FFXIVClientStructsHavokhkaSkeletonLocalFrameOnBone LocalFrames;
    /* 0x78 */ FFXIVClientStructs::Havok::hkArray::FFXIVClientStructsHavokhkaSkeletonPartition Partitions;
};

struct Pointer::FFXIVClientStructsHavokhkaSkeletonMapper /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdPair::SystemUInt32::PointerFFXIVClientStructsHavokhkaSkeletonMapper /* Size=0x10 */
{
    /* 0x00 */ unsigned __int32 Item1;
    /*      */ byte _gap_0x4[0x4];
    /* 0x08 */ Pointer::FFXIVClientStructsHavokhkaSkeletonMapper Item2;
};

struct StdMap::Node::SystemUInt32::PointerFFXIVClientStructsHavokhkaSkeletonMapper /* Size=0x38 */
{
    /* 0x00 */ StdMap::Node::SystemUInt32::PointerFFXIVClientStructsHavokhkaSkeletonMapper* Left;
    /* 0x08 */ StdMap::Node::SystemUInt32::PointerFFXIVClientStructsHavokhkaSkeletonMapper* Parent;
    /* 0x10 */ StdMap::Node::SystemUInt32::PointerFFXIVClientStructsHavokhkaSkeletonMapper* Right;
    /* 0x18 */ byte Color;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /* 0x1C */ bool IsNil;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ byte _18;
    /* 0x21 */ byte _19;
    /*      */ byte _gap_0x22[0x2];
    /*      */ byte _gap_0x24[0x4];
    /* 0x28 */ StdPair::SystemUInt32::PointerFFXIVClientStructsHavokhkaSkeletonMapper KeyValuePair;
};

struct StdMap::SystemUInt32::PointerFFXIVClientStructsHavokhkaSkeletonMapper /* Size=0x10 */
{
    /* 0x00 */ StdMap::Node::SystemUInt32::PointerFFXIVClientStructsHavokhkaSkeletonMapper* Head;
    /* 0x08 */ unsigned __int64 Count;
};

struct Pointer::FFXIVClientStructsHavokhkResource /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct FFXIVClientStructs::Havok::hkArray::PointerFFXIVClientStructsHavokhkResource /* Size=0x10 */
{
    /* 0x00 */ Pointer::FFXIVClientStructsHavokhkResource* Data;
    /* 0x08 */ __int32 Length;
    /* 0x0C */ __int32 CapacityAndFlags;
};

struct FFXIVClientStructs::Havok::hkLoader /* Size=0x20 */
{
    /* 0x00 */ FFXIVClientStructs::Havok::hkReferencedObject hkReferencedObject;
    /* 0x10 */ FFXIVClientStructs::Havok::hkArray::PointerFFXIVClientStructsHavokhkResource LoadedData;
};

struct Client::System::Resource::Handle::SkeletonResourceHandle::SkeletonHeader /* Size=0x30 */
{
    /* 0x00 */ unsigned __int32 SklbMagic;
    /* 0x04 */ unsigned __int32 SklbVersion;
    /* 0x08 */ unsigned __int32 LayerOffset;
    /* 0x0C */ unsigned __int32 SklbOffset;
    /* 0x10 */ unsigned __int16 ConnectBoneIndex;
    /*      */ byte _gap_0x12[0x2];
    /* 0x14 */ unsigned __int32 CharacterId;
    /* 0x18 */ unsigned __int32 SkeletonMappers[0x4];
    /* 0x28 */ unsigned __int16 ConnectBoneIds[0x4];
};

struct Client::System::Resource::Handle::SkeletonResourceHandle /* Size=0x138 */
{
    /* 0x000 */ Client::System::Resource::Handle::ResourceHandle ResourceHandle;
    /*       */ byte _gap_0xB0[0x18];
    /* 0x0C8 */ unsigned __int32 BoneCount;
    /*       */ byte _gap_0xCC[0x4];
    /* 0x0D0 */ FFXIVClientStructs::Havok::hkaSkeleton* HavokSkeleton;
    /* 0x0D8 */ StdMap::SystemUInt32::PointerFFXIVClientStructsHavokhkaSkeletonMapper SkeletonMapperDict1;
    /* 0x0E8 */ StdMap::SystemUInt32::PointerFFXIVClientStructsHavokhkaSkeletonMapper SkeletonMapperDict2;
    /* 0x0F8 */ Common::Math::Matrix4x4* InverseBoneMatrix;
    /* 0x100 */ FFXIVClientStructs::Havok::hkLoader* HavokLoader;
    /* 0x108 */ Client::System::Resource::Handle::SkeletonResourceHandle::SkeletonHeader SkeletonData;
};

struct Client::System::Memory::IMemorySpace::IMemorySpaceVTable /* Size=0x20 */
{
    /*      */ byte _gap_0x0[0x18];
    /* 0x18 */ __int64 Malloc;
};

struct Client::System::Memory::IMemorySpace /* Size=0x8 */
{
    /* 0x0 */ Client::System::Memory::IMemorySpace::IMemorySpaceVTable* VTable;
};

struct Client::System::Configuration::SystemConfig /* Size=0x450 */
{
    /* 0x000 */ Common::Configuration::SystemConfig CommonSystemConfig;
};

struct Client::System::Configuration::DevConfig /* Size=0x110 */
{
    /* 0x000 */ Common::Configuration::DevConfig CommonDevConfig;
};

struct Client::Game::SavedAppearanceManager::SavedAppearanceManagerVTable /* Size=0x38 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int64 IsSlotCreated;
    /* 0x10 */ __int64 GetSlot;
    /*      */ byte _gap_0x18[0x18];
    /* 0x30 */ __int64 GetSlotCount;
};

struct Client::Game::SavedAppearanceManager /* Size=0x9EB8 */
{
    /* 0x0000 */ Client::Game::SavedAppearanceManager::SavedAppearanceManagerVTable* VTable;
    /* 0x0008 */ byte Slot[0x3200];
    /*        */ byte _gap_0x3208[0x6CB0];
};

struct Client::System::Framework::GameVersion /* Size=0x900 */
{
    /*       */ byte _gap_0x0[0x900];
};

struct Client::System::Framework::Framework /* Size=0x35C8 */
{
    /*        */ byte _gap_0x0[0x10];
    /* 0x0010 */ Client::System::Configuration::SystemConfig SystemConfig;
    /* 0x0460 */ Client::System::Configuration::DevConfig DevConfig;
    /* 0x0570 */ Client::Game::SavedAppearanceManager* SavedAppearanceData;
    /*        */ byte _gap_0x578[0x1100];
    /* 0x1678 */ bool IsNetworkModuleInitialized;
    /* 0x1679 */ bool EnableNetworking;
    /*        */ byte _gap_0x167A[0x2];
    /*        */ byte _gap_0x167C[0x4];
    /* 0x1680 */ __int64 ServerTime;
    /*        */ byte _gap_0x1688[0x30];
    /* 0x16B8 */ float FrameDeltaTime;
    /*        */ byte _gap_0x16BC[0x4];
    /*        */ byte _gap_0x16C0[0x8];
    /* 0x16C8 */ unsigned __int32 FrameCounter;
    /*        */ byte _gap_0x16CC[0x4];
    /*        */ byte _gap_0x16D0[0xA0];
    /* 0x1770 */ __int64 EorzeaTime;
    /*        */ byte _gap_0x1778[0x20];
    /* 0x1798 */ __int64 EorzeaTimeOverride;
    /* 0x17A0 */ bool IsEorzeaTimeOverridden;
    /*        */ byte _gap_0x17A1;
    /*        */ byte _gap_0x17A2[0x2];
    /*        */ byte _gap_0x17A4[0x4];
    /*        */ byte _gap_0x17A8[0x18];
    /*        */ byte _gap_0x17C0[0x4];
    /* 0x17C4 */ float FrameRate;
    /*        */ byte _gap_0x17C8[0x8];
    /* 0x17D0 */ bool WindowInactive;
    /*        */ byte _gap_0x17D1;
    /*        */ byte _gap_0x17D2[0x2];
    /*        */ byte _gap_0x17D4[0x4];
    /*        */ byte _gap_0x17D8[0x1358];
    /* 0x2B30 */ Component::Excel::ExcelModuleInterface* ExcelModuleInterface;
    /* 0x2B38 */ Component::Exd::ExdModule* ExdModule;
    /*        */ byte _gap_0x2B40[0x10];
    /* 0x2B50 */ Common::Component::BGCollision::BGCollisionModule* BGCollisionModule;
    /*        */ byte _gap_0x2B58[0x8];
    /* 0x2B60 */ Client::UI::UIModule* UIModule;
    /*        */ byte _gap_0x2B68[0x60];
    /* 0x2BC8 */ Common::Lua::LuaState LuaState;
    /* 0x2BF0 */ Client::System::Framework::GameVersion GameVersion;
    /*        */ byte _gap_0x34F0[0xD8];
};

enum FileMode: unsigned __int32
{
    LoadUnpackedResource = 0,
    LoadFileResource = 1,
    CreateFileResource = 2,
    LoadIndexResource = 10,
    LoadSqPackResource = 11
};

struct Client::System::File::FileDescriptor /* Size=0x278 */
{
    /* 0x000 */ Client::System::File::FileMode FileMode;
    /*       */ byte _gap_0x4[0x4];
    /* 0x008 */ byte* FileBuffer;
    /* 0x010 */ unsigned __int64 FileLength;
    /* 0x018 */ unsigned __int64 CurrentFileOffset;
    /*       */ byte _gap_0x20[0x10];
    /* 0x030 */ void* FileInterface;
    /*       */ byte _gap_0x38[0x28];
    /* 0x060 */ Client::System::File::FileDescriptor* Previous;
    /* 0x068 */ Client::System::File::FileDescriptor* Next;
    /* 0x070 */ byte Utf16FilePath[0x208];
};

struct Client::LayoutEngine::IndoorFloorLayoutData /* Size=0x14 */
{
    /* 0x00 */ __int32 Part0;
    /* 0x04 */ __int32 Part1;
    /* 0x08 */ __int32 Part2;
    /* 0x0C */ __int32 Part3;
    /* 0x10 */ __int32 Part4;
};

struct Client::LayoutEngine::IndoorAreaLayoutData /* Size=0x84 */
{
    /*      */ byte _gap_0x0[0x28];
    /* 0x28 */ Client::LayoutEngine::IndoorFloorLayoutData Floor0;
    /* 0x3C */ Client::LayoutEngine::IndoorFloorLayoutData Floor1;
    /* 0x50 */ Client::LayoutEngine::IndoorFloorLayoutData Floor2;
    /*      */ byte _gap_0x64[0x4];
    /*      */ byte _gap_0x68[0x18];
    /* 0x80 */ float LightLevel;
};

struct Client::LayoutEngine::LayoutManager /* Size=0x98 */
{
    /*      */ byte _gap_0x0[0x20];
    /* 0x20 */ unsigned __int32 TerritoryTypeId;
    /*      */ byte _gap_0x24[0x4];
    /*      */ byte _gap_0x28[0x10];
    /* 0x38 */ unsigned __int32 FestivalStatus;
    /*      */ byte _gap_0x3C[0x4];
    /* 0x40 */ unsigned __int32 ActiveFestivals[0x4];
    /*      */ byte _gap_0x50[0x30];
    /* 0x80 */ void* HousingController;
    /*      */ byte _gap_0x88[0x8];
    /* 0x90 */ Client::LayoutEngine::IndoorAreaLayoutData* IndoorAreaData;
};

struct Pointer::SystemByte /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdPair::ClientSystemStringUtf8String::PointerSystemByte /* Size=0x70 */
{
    /* 0x00 */ Client::System::String::Utf8String Item1;
    /* 0x68 */ Pointer::SystemByte Item2;
};

struct StdMap::Node::ClientSystemStringUtf8String::PointerSystemByte /* Size=0x98 */
{
    /* 0x00 */ StdMap::Node::ClientSystemStringUtf8String::PointerSystemByte* Left;
    /* 0x08 */ StdMap::Node::ClientSystemStringUtf8String::PointerSystemByte* Parent;
    /* 0x10 */ StdMap::Node::ClientSystemStringUtf8String::PointerSystemByte* Right;
    /* 0x18 */ byte Color;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /* 0x1C */ bool IsNil;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ byte _18;
    /* 0x21 */ byte _19;
    /*      */ byte _gap_0x22[0x2];
    /*      */ byte _gap_0x24[0x4];
    /* 0x28 */ StdPair::ClientSystemStringUtf8String::PointerSystemByte KeyValuePair;
};

struct StdMap::ClientSystemStringUtf8String::PointerSystemByte /* Size=0x10 */
{
    /* 0x00 */ StdMap::Node::ClientSystemStringUtf8String::PointerSystemByte* Head;
    /* 0x08 */ unsigned __int64 Count;
};

struct Client::LayoutEngine::LayoutWorld /* Size=0x228 */
{
    /*       */ byte _gap_0x0[0x20];
    /* 0x020 */ Client::LayoutEngine::LayoutManager* ActiveLayout;
    /*       */ byte _gap_0x28[0x1F0];
    /* 0x218 */ StdMap::ClientSystemStringUtf8String::PointerSystemByte* RsvMap;
    /*       */ byte _gap_0x220[0x8];
};

struct Client::Graphics::Ray /* Size=0x20 */
{
    /* 0x00 */ Common::Math::Vector3 Origin;
    /* 0x10 */ Common::Math::Vector3 Direction;
};

struct Client::Graphics::Transform /* Size=0x30 */
{
    /* 0x00 */ Common::Math::Vector3 Position;
    /* 0x10 */ Common::Math::Quaternion Rotation;
    /* 0x20 */ Common::Math::Vector3 Scale;
};

struct Client::Graphics::Vfx::VfxData /* Size=0x1D0 */
{
    /*       */ byte _gap_0x0[0x1D0];
};

struct Client::Graphics::Scene::CameraManager /* Size=0x120 */
{
    /*       */ byte _gap_0x0[0x50];
    /* 0x050 */ __int32 CameraIndex;
    /*       */ byte _gap_0x54[0x4];
    /* 0x058 */ byte CameraArray[0x70];
    /*       */ byte _gap_0xC8[0x58];
};

struct Client::Graphics::Scene::CharacterBase::CharacterBaseVTable /* Size=0x220 */
{
    /*       */ byte _gap_0x0[0x190];
    /* 0x190 */ __int64 GetModelType;
    /*       */ byte _gap_0x198[0x80];
    /* 0x218 */ __int64 FlagSlotForUpdate;
};

struct Client::Graphics::Animation::AnimationResourceHandle /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

struct Client::Graphics::Render::PartialSkeleton /* Size=0x1C0 */
{
    /* 0x000 */ void* vtbl;
    /*       */ byte _gap_0x8[0x18];
    /* 0x020 */ byte Jobs[0x100];
    /* 0x120 */ __int16 ConnectedParentBoneIndex;
    /* 0x122 */ __int16 ConnectedBoneIndex;
    /*       */ byte _gap_0x124[0x4];
    /*       */ byte _gap_0x128[0x8];
    /* 0x130 */ unsigned __int64 HavokAnimatedSkeleton[0x2];
    /* 0x140 */ unsigned __int64 HavokPoses[0x4];
    /* 0x160 */ Client::Graphics::Render::Skeleton* Skeleton;
    /*       */ byte _gap_0x168[0x18];
    /* 0x180 */ void* SkeletonParameterResourceHandle;
    /* 0x188 */ Client::System::Resource::Handle::SkeletonResourceHandle* SkeletonResourceHandle;
    /*       */ byte _gap_0x190[0x30];
};

struct Client::Graphics::Render::Skeleton /* Size=0x100 */
{
    /* 0x000 */ Client::Graphics::ReferencedClassBase ReferencedClassBase;
    /* 0x010 */ Client::Graphics::Render::Skeleton* LinkedListPrevious;
    /* 0x018 */ Client::Graphics::Render::Skeleton* LinkedListNext;
    /* 0x020 */ Client::Graphics::Transform Transform;
    /* 0x050 */ unsigned __int16 PartialSkeletonCount;
    /*       */ byte _gap_0x52[0x2];
    /*       */ byte _gap_0x54[0x4];
    /* 0x058 */ Client::System::Resource::Handle::SkeletonResourceHandle** SkeletonResourceHandles;
    /* 0x060 */ Client::Graphics::Animation::AnimationResourceHandle** AnimationResourceHandles;
    /* 0x068 */ Client::Graphics::Render::PartialSkeleton* PartialSkeletons;
    /*       */ byte _gap_0x70[0x48];
    /* 0x0B8 */ Client::Graphics::Scene::CharacterBase* Owner;
    /*       */ byte _gap_0xC0[0x40];
};

struct Pointer::ClientGraphicsPhysicsBoneSimulator /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdVector::PointerClientGraphicsPhysicsBoneSimulator /* Size=0x18 */
{
    /* 0x00 */ Pointer::ClientGraphicsPhysicsBoneSimulator* First;
    /* 0x08 */ Pointer::ClientGraphicsPhysicsBoneSimulator* Last;
    /* 0x10 */ Pointer::ClientGraphicsPhysicsBoneSimulator* End;
};

struct Client::Graphics::Physics::BoneSimulators /* Size=0x78 */
{
    /* 0x00 */ StdVector::PointerClientGraphicsPhysicsBoneSimulator BoneSimulator_1;
    /* 0x18 */ StdVector::PointerClientGraphicsPhysicsBoneSimulator BoneSimulator_2;
    /* 0x30 */ StdVector::PointerClientGraphicsPhysicsBoneSimulator BoneSimulator_3;
    /* 0x48 */ StdVector::PointerClientGraphicsPhysicsBoneSimulator BoneSimulator_4;
    /* 0x60 */ StdVector::PointerClientGraphicsPhysicsBoneSimulator BoneSimulator_5;
};

struct Client::Graphics::Physics::BonePhysicsModule /* Size=0x1C0 */
{
    /* 0x000 */ void* vtbl;
    /*       */ byte _gap_0x8[0x8];
    /* 0x010 */ Common::Math::Matrix4x4 SkeletonWorldMatrix;
    /* 0x050 */ Common::Math::Matrix4x4 SkeletonInvWorldMatrix;
    /* 0x090 */ float WindScale;
    /* 0x094 */ float WindVariation;
    /* 0x098 */ Client::Graphics::Render::Skeleton* Skeleton;
    /* 0x0A0 */ Client::Graphics::Physics::BoneSimulators BoneSimulators;
    /*       */ byte _gap_0x118[0xA8];
};

struct Client::Graphics::Scene::CharacterBase /* Size=0x8F0 */
{
    union {
    /* 0x000 */ Client::Graphics::Scene::DrawObject DrawObject;
    /* 0x000 */ Client::Graphics::Scene::CharacterBase::CharacterBaseVTable* VTable;
    } _union_0x0;
    /*       */ byte _gap_0x8[0x88];
    /* 0x090 */ byte UnkFlags_01;
    /* 0x091 */ byte UnkFlags_02;
    /* 0x092 */ byte UnkFlags_03;
    /*       */ byte _gap_0x93;
    /*       */ byte _gap_0x94[0x4];
    /* 0x098 */ __int32 SlotCount;
    /*       */ byte _gap_0x9C[0x4];
    /* 0x0A0 */ Client::Graphics::Render::Skeleton* Skeleton;
    /* 0x0A8 */ void** ModelArray;
    /*       */ byte _gap_0xB0[0x98];
    /* 0x148 */ void* PostBoneDeformer;
    /* 0x150 */ Client::Graphics::Physics::BonePhysicsModule* BonePhysicsModule;
    /*       */ byte _gap_0x158[0xC8];
    /*       */ byte _gap_0x220[0x4];
    /* 0x224 */ float VfxScale;
    /*       */ byte _gap_0x228[0x18];
    /* 0x240 */ void* CharacterDataCB;
    /*       */ byte _gap_0x248[0x68];
    /* 0x2B0 */ float WeatherWetness;
    /* 0x2B4 */ float SwimmingWetness;
    /* 0x2B8 */ float WetnessDepth;
    /* 0x2BC */ float ForcedWetness;
    /*       */ byte _gap_0x2C0[0x8];
    /* 0x2C8 */ unsigned __int32 HasModelInSlotLoaded;
    /* 0x2CC */ unsigned __int32 HasModelFilesInSlotLoaded;
    /* 0x2D0 */ void* TempData;
    /* 0x2D8 */ void* TempSlotData;
    /*       */ byte _gap_0x2E0[0x8];
    /* 0x2E8 */ void** MaterialArray;
    /* 0x2F0 */ void* EID;
    /* 0x2F8 */ void** IMCArray;
    /*       */ byte _gap_0x300[0x5F0];
};

struct Client::Graphics::Scene::Demihuman /* Size=0x978 */
{
    /* 0x000 */ Client::Graphics::Scene::CharacterBase CharacterBase;
    /*       */ byte _gap_0x8F0[0x88];
};

struct Client::Graphics::Scene::EnvLocation /* Size=0xB0 */
{
    /* 0x00 */ Client::Graphics::Scene::DrawObject DrawObject;
    /*      */ byte _gap_0x90[0x20];
};

struct Client::Graphics::Scene::EnvScene /* Size=0x790 */
{
    /*       */ byte _gap_0x0[0xB0];
    /* 0x0B0 */ byte EnvSpaces[0x680];
    /*       */ byte _gap_0x730[0x60];
};

struct Client::Graphics::Scene::EnvSpace /* Size=0xD0 */
{
    /* 0x00 */ Client::Graphics::Scene::DrawObject DrawObject;
    /*      */ byte _gap_0x90[0x20];
    /* 0xB0 */ Client::Graphics::Scene::EnvLocation* EnvLocation;
    /*      */ byte _gap_0xB8[0x18];
};

struct Client::Game::Character::CustomizeData /* Size=0x1A */
{
    /* 0x00 */ byte Data[0x1A];
};

struct Client::Graphics::Scene::Monster /* Size=0x900 */
{
    /* 0x000 */ Client::Graphics::Scene::CharacterBase CharacterBase;
    /*       */ byte _gap_0x8F0[0x10];
};

enum ObjectType: __int32
{
    Object = 0,
    Terrain = 1,
    BgObject = 2,
    CharacterBase = 3,
    VfxObject = 4,
    Light = 5,
    Unk_Type6 = 6,
    EnvSpace = 7,
    EnvLocation = 8,
    Unk_Type9 = 9
};

struct Client::Graphics::Scene::Weapon /* Size=0x920 */
{
    /* 0x000 */ Client::Graphics::Scene::CharacterBase CharacterBase;
    /* 0x8F0 */ unsigned __int16 ModelSetId;
    /* 0x8F2 */ unsigned __int16 SecondaryId;
    /* 0x8F4 */ unsigned __int16 Variant;
    /* 0x8F6 */ unsigned __int16 ModelUnknown;
    /*       */ byte _gap_0x8F8[0x2];
    /* 0x8FA */ byte MaterialId;
    /* 0x8FB */ byte DecalId;
    /*       */ byte _gap_0x8FC[0x2];
    /* 0x8FE */ byte VfxId;
    /*       */ byte _gap_0x8FF;
    /*       */ byte _gap_0x900[0x20];
};

struct Client::Graphics::Scene::World /* Size=0x160 */
{
    /* 0x000 */ Client::Graphics::Scene::Object Object;
    /*       */ byte _gap_0x80[0xE0];
};

struct Client::Graphics::Physics::BoneSimulator /* Size=0x100 */
{
    /* 0x000 */ void* vtbl;
    /*       */ byte _gap_0x8[0x8];
    /* 0x010 */ unsigned __int32 PhysicsGroup;
    /*       */ byte _gap_0x14[0x4];
    /* 0x018 */ Client::Graphics::Render::Skeleton* Skeleton;
    /* 0x020 */ Common::Math::Vector3 CharacterPosition;
    /* 0x030 */ Common::Math::Vector3 Gravity;
    /* 0x040 */ Common::Math::Vector3 Wind;
    /*       */ byte _gap_0x50[0xB0];
};

struct Client::Graphics::Render::Manager /* Size=0x2D710 */
{
    /* 0x00000 */ void* Vtbl;
    /* 0x00008 */ byte ViewArray[0xB400];
    /*         */ byte _gap_0xB408[0x22308];
};

struct Client::Graphics::Render::OffscreenRenderingManager /* Size=0x190 */
{
    /* 0x000 */ void* vtbl;
    /* 0x008 */ void* JobSystem_vtbl;
    /*       */ byte _gap_0x10[0xB8];
    /* 0x0C8 */ void* Camera_1;
    /* 0x0D0 */ void* Camera_2;
    /* 0x0D8 */ void* Camera_3;
    /* 0x0E0 */ void* Camera_4;
    /*       */ byte _gap_0xE8[0xA8];
};

struct Client::Graphics::Render::ShadowCamera /* Size=0x150 */
{
    /* 0x000 */ Client::Graphics::Render::Camera Camera;
    /*       */ byte _gap_0x130[0x20];
};

struct Client::Graphics::Render::SubView /* Size=0x58 */
{
    /* 0x00 */ void* Vtbl;
    /* 0x08 */ unsigned __int32 Flags;
    /*      */ byte _gap_0xC[0x4];
    /* 0x10 */ Common::Math::Rectangle ViewportRegion;
    /* 0x20 */ void* Camera;
    /* 0x28 */ Client::Graphics::Render::Texture* RenderTarget_1;
    /* 0x30 */ Client::Graphics::Render::Texture* RenderTarget_2;
    /* 0x38 */ Client::Graphics::Render::Texture* RenderTarget_3;
    /* 0x40 */ Client::Graphics::Render::Texture* RenderTarget_4;
    /* 0x48 */ unsigned __int32 RenderTargetUsedCount;
    /*      */ byte _gap_0x4C[0x4];
    /* 0x50 */ Client::Graphics::Render::Texture* DepthStencil;
};

struct Client::Graphics::Render::View /* Size=0x5A0 */
{
    /* 0x000 */ void* Vtbl;
    /* 0x008 */ unsigned __int32 Flags;
    /*       */ byte _gap_0xC[0x4];
    /* 0x010 */ Common::Math::Rectangle CanvasRegion;
    /* 0x020 */ byte SubViewArray[0x580];
};

struct Client::Graphics::Kernel::CVector; /* Size=unknown due to generic type with parameters */
struct Client::Graphics::Kernel::SwapChain /* Size=0x70 */
{
    /*      */ byte _gap_0x0[0x38];
    /* 0x38 */ unsigned __int32 Width;
    /* 0x3C */ unsigned __int32 Height;
    /*      */ byte _gap_0x40[0x18];
    /* 0x58 */ Client::Graphics::Render::Texture* BackBuffer;
    /* 0x60 */ Client::Graphics::Render::Texture* DepthStencil;
    /* 0x68 */ void* DXGISwapChain;
};

struct Client::Graphics::Kernel::Device /* Size=0x258 */
{
    /*       */ byte _gap_0x0[0x8];
    /* 0x008 */ void* ContextArray;
    /* 0x010 */ void* RenderThread;
    /*       */ byte _gap_0x18[0x58];
    /* 0x070 */ Client::Graphics::Kernel::SwapChain* SwapChain;
    /*       */ byte _gap_0x78[0x2];
    /* 0x07A */ byte RequestResolutionChange;
    /*       */ byte _gap_0x7B;
    /*       */ byte _gap_0x7C[0x4];
    /*       */ byte _gap_0x80[0x8];
    /* 0x088 */ unsigned __int32 Width;
    /* 0x08C */ unsigned __int32 Height;
    /* 0x090 */ float AspectRatio;
    /* 0x094 */ float GammaCorrection;
    /* 0x098 */ __int32 ColorFilter;
    /* 0x09C */ float ColorFilterRange;
    /*       */ byte _gap_0xA0[0x120];
    /* 0x1C0 */ unsigned __int32 NewWidth;
    /* 0x1C4 */ unsigned __int32 NewHeight;
    /*       */ byte _gap_0x1C8[0x58];
    /* 0x220 */ __int32 D3DFeatureLevel;
    /*       */ byte _gap_0x224[0x4];
    /* 0x228 */ void* DXGIFactory;
    /* 0x230 */ void* DXGIOutput;
    /* 0x238 */ void* D3D11Forwarder;
    /* 0x240 */ void* D3D11DeviceContext;
    /*       */ byte _gap_0x248[0x8];
    /* 0x250 */ void* ImmediateContext;
};

struct Client::Graphics::Kernel::PixelShader /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

struct Pointer::ClientGraphicsKernelVertexShader /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdVector::PointerClientGraphicsKernelVertexShader /* Size=0x18 */
{
    /* 0x00 */ Pointer::ClientGraphicsKernelVertexShader* First;
    /* 0x08 */ Pointer::ClientGraphicsKernelVertexShader* Last;
    /* 0x10 */ Pointer::ClientGraphicsKernelVertexShader* End;
};

struct Client::Graphics::Kernel::CVector::PointerClientGraphicsKernelVertexShader /* Size=0x20 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ StdVector::PointerClientGraphicsKernelVertexShader Vector;
};

struct Pointer::ClientGraphicsKernelPixelShader /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdVector::PointerClientGraphicsKernelPixelShader /* Size=0x18 */
{
    /* 0x00 */ Pointer::ClientGraphicsKernelPixelShader* First;
    /* 0x08 */ Pointer::ClientGraphicsKernelPixelShader* Last;
    /* 0x10 */ Pointer::ClientGraphicsKernelPixelShader* End;
};

struct Client::Graphics::Kernel::CVector::PointerClientGraphicsKernelPixelShader /* Size=0x20 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ StdVector::PointerClientGraphicsKernelPixelShader Vector;
};

struct Pointer::ClientGraphicsKernelShaderNode /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdVector::PointerClientGraphicsKernelShaderNode /* Size=0x18 */
{
    /* 0x00 */ Pointer::ClientGraphicsKernelShaderNode* First;
    /* 0x08 */ Pointer::ClientGraphicsKernelShaderNode* Last;
    /* 0x10 */ Pointer::ClientGraphicsKernelShaderNode* End;
};

struct Client::Graphics::Kernel::CVector::PointerClientGraphicsKernelShaderNode /* Size=0x20 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ StdVector::PointerClientGraphicsKernelShaderNode Vector;
};

struct Client::Graphics::Kernel::ShaderPackage::MaterialElement /* Size=0x8 */
{
    /* 0x0 */ unsigned __int32 CRC;
    /* 0x4 */ unsigned __int16 Offset;
    /* 0x6 */ unsigned __int16 Size;
};

struct Client::Graphics::Kernel::ShaderPackage::ConstantSamplerUnknown /* Size=0xC */
{
    /*     */ byte _gap_0x0[0x8];
    /*     */ byte _gap_0x8[0x4];
};

struct Client::Graphics::Kernel::ShaderPackage /* Size=0x408 */
{
    /* 0x000 */ Client::Graphics::ReferencedClassBase ReferencedClassBase;
    /* 0x010 */ Client::Graphics::Kernel::CVector::PointerClientGraphicsKernelVertexShader VertexShaders;
    /* 0x030 */ Client::Graphics::Kernel::CVector::PointerClientGraphicsKernelPixelShader PixelShaders;
    /* 0x050 */ Client::Graphics::Kernel::CVector::PointerClientGraphicsKernelShaderNode ShaderNodes;
    /* 0x070 */ unsigned __int16 MaterialConstantBufferSize;
    /*       */ byte _gap_0x72[0x2];
    /* 0x074 */ unsigned __int16 MaterialElementCount;
    /*       */ byte _gap_0x76[0x2];
    /* 0x078 */ unsigned __int16 ConstantCount;
    /*       */ byte _gap_0x7A[0x2];
    /* 0x07C */ unsigned __int16 SamplerCount;
    /*       */ byte _gap_0x7E[0x2];
    /* 0x080 */ unsigned __int16 UnkCount;
    /*       */ byte _gap_0x82[0x2];
    /* 0x084 */ unsigned __int16 SystemKeyCount;
    /*       */ byte _gap_0x86[0x2];
    /* 0x088 */ unsigned __int16 SceneKeyCount;
    /*       */ byte _gap_0x8A[0x2];
    /* 0x08C */ unsigned __int16 MaterialKeyCount;
    /*       */ byte _gap_0x8E[0x2];
    /* 0x090 */ Client::Graphics::Kernel::ShaderPackage::MaterialElement* MaterialElements;
    /* 0x098 */ Client::Graphics::Kernel::ShaderPackage::ConstantSamplerUnknown* Constants;
    /* 0x0A0 */ Client::Graphics::Kernel::ShaderPackage::ConstantSamplerUnknown* Samplers;
    /* 0x0A8 */ Client::Graphics::Kernel::ShaderPackage::ConstantSamplerUnknown* Unknowns;
    /* 0x0B0 */ unsigned __int32* SystemKeys;
    /* 0x0B8 */ unsigned __int32* SceneKeys;
    /* 0x0C0 */ unsigned __int32* MaterialKeys;
    /* 0x0C8 */ unsigned __int32* SystemValues;
    /* 0x0D0 */ unsigned __int32* SceneValues;
    /* 0x0D8 */ unsigned __int32* MaterialValues;
    /* 0x0E0 */ unsigned __int32 SubviewValue1;
    /* 0x0E4 */ unsigned __int32 SubviewValue2;
    /* 0x0E8 */ void* ShaderNodeTreeVtbl;
    /*       */ byte _gap_0xF0[0x318];
};

struct Client::Graphics::Kernel::ShaderNode::ShaderPass /* Size=0x8 */
{
    /* 0x0 */ unsigned __int32 VertexShader;
    /* 0x4 */ unsigned __int32 PixelShader;
};

struct Client::Graphics::Kernel::ShaderNode /* Size=0x38 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ Client::Graphics::Kernel::ShaderPackage* OwnerPackage;
    /* 0x10 */ unsigned __int32 PassNum;
    /* 0x14 */ byte PassIndices[0x10];
    /*      */ byte _gap_0x24[0x4];
    /* 0x28 */ Client::Graphics::Kernel::ShaderNode::ShaderPass* Passes;
    /* 0x30 */ unsigned __int32* ShaderKeys;
};

struct Client::Graphics::Kernel::VertexShader /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

struct Client::Graphics::Environment::EnvState /* Size=0x258 */
{
    /*       */ byte _gap_0x0[0x258];
};

struct Client::Graphics::Environment::EnvSimulator /* Size=0x310 */
{
    /*       */ byte _gap_0x0[0x310];
};

struct Client::Graphics::Environment::EnvSoundState /* Size=0x68 */
{
    /*      */ byte _gap_0x0[0x68];
};

struct Client::Game::ComboDetail /* Size=0x8 */
{
    /* 0x0 */ float Timer;
    /* 0x4 */ unsigned __int32 Action;
};

struct Client::Game::ActionManager /* Size=0x7F0 */
{
    /*       */ byte _gap_0x0[0x60];
    /* 0x060 */ Client::Game::ComboDetail Combo;
    /* 0x068 */ bool ActionQueued;
    /*       */ byte _gap_0x69;
    /*       */ byte _gap_0x6A[0x2];
    /* 0x06C */ Client::Game::ActionType QueuedActionType;
    /*       */ byte _gap_0x6D;
    /*       */ byte _gap_0x6E[0x2];
    /* 0x070 */ unsigned __int32 QueuedActionId;
    /*       */ byte _gap_0x74[0x4];
    /* 0x078 */ Client::Game::Object::GameObjectID QueuedTargetId;
    /* 0x080 */ unsigned __int32 QueueType;
    /*       */ byte _gap_0x84[0x4];
    /*       */ byte _gap_0x88[0xB0];
    /*       */ byte _gap_0x138[0x4];
    /* 0x13C */ unsigned __int32 BlueMageActions[0x18];
    /*       */ byte _gap_0x19C[0x4];
    /*       */ byte _gap_0x1A0[0x650];
};

struct Client::Game::RecastDetail /* Size=0x14 */
{
    /* 0x00 */ byte IsActive;
    /*      */ byte _gap_0x1;
    /*      */ byte _gap_0x2[0x2];
    /* 0x04 */ unsigned __int32 ActionID;
    /* 0x08 */ float Elapsed;
    /* 0x0C */ float Total;
    /*      */ byte _gap_0x10[0x4];
};

struct Client::Game::ActionTimelineDriver /* Size=0x1F0 */
{
    /*       */ byte _gap_0x0[0xE0];
    /* 0x0E0 */ unsigned __int16 TimelineIds[0xD];
    /*       */ byte _gap_0xFA[0x2];
    /*       */ byte _gap_0xFC[0x4];
    /*       */ byte _gap_0x100[0x50];
    /*       */ byte _gap_0x150[0x4];
    /* 0x154 */ float TimelineSpeeds[0xD];
    /*       */ byte _gap_0x188[0x68];
};

struct Client::Game::ActionTimelineManager /* Size=0x340 */
{
    /*       */ byte _gap_0x0[0x10];
    /* 0x010 */ Client::Game::ActionTimelineDriver Driver;
    /*       */ byte _gap_0x200[0xC0];
    /* 0x2C0 */ float OverallSpeed;
    /*       */ byte _gap_0x2C4[0x4];
    /*       */ byte _gap_0x2C8[0x10];
    /*       */ byte _gap_0x2D8[0x4];
    /* 0x2DC */ unsigned __int16 BaseOverride;
    /* 0x2DE */ unsigned __int16 LipsOverride;
    /*       */ byte _gap_0x2E0[0x60];
};

enum ActionTimelineSlots: __int32
{
    Base = 0,
    UpperBody = 1,
    Facial = 2,
    Add = 3,
    Lips = 7,
    Parts1 = 8,
    Parts2 = 9,
    Parts3 = 10,
    Parts4 = 11,
    Overlay = 12
};

enum BalloonState: unsigned __int32
{
    Waiting = 0,
    Active = 1,
    Closing = 2,
    Inactive = 3
};

struct Client::Game::Balloon /* Size=0x80 */
{
    /* 0x00 */ unsigned __int16 DefaultBalloonId;
    /* 0x02 */ unsigned __int16 NowPlayingBalloonId;
    /* 0x04 */ float PlayTimer;
    /* 0x08 */ Client::Game::BalloonType Type;
    /* 0x0C */ Client::Game::BalloonState State;
    /* 0x10 */ Client::System::String::Utf8String Text;
    /* 0x78 */ byte UnkBool;
    /*      */ byte _gap_0x79;
    /*      */ byte _gap_0x7A[0x2];
    /*      */ byte _gap_0x7C[0x4];
};

struct Client::Game::LobbyCamera /* Size=0x300 */
{
    /* 0x000 */ Client::Game::Camera Camera;
    /*       */ byte _gap_0x2B0[0x48];
    /* 0x2F8 */ void* LobbyExcelSheet;
};

struct Client::Game::Camera3 /* Size=0x300 */
{
    /* 0x000 */ Client::Game::Camera Camera;
    /*       */ byte _gap_0x2B0[0x50];
};

struct Client::Game::LowCutCamera /* Size=0x2E0 */
{
    /* 0x000 */ Client::Game::CameraBase CameraBase;
    /*       */ byte _gap_0x110[0x1D0];
};

struct Client::Game::Camera4 /* Size=0x350 */
{
    /* 0x000 */ Client::Game::CameraBase CameraBase;
    /* 0x110 */ Client::Graphics::Scene::Camera SceneCamera0;
    /* 0x200 */ Client::Graphics::Scene::Camera SceneCamera1;
    /*       */ byte _gap_0x2F0[0x60];
};

struct Client::Game::Gauge::JobGauge /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct Client::Game::Gauge::WhiteMageGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /*      */ byte _gap_0x8[0x2];
    /* 0x0A */ __int16 LilyTimer;
    /* 0x0C */ byte Lily;
    /* 0x0D */ byte BloodLily;
    /*      */ byte _gap_0xE[0x2];
};

struct Client::Game::Gauge::ScholarGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /*      */ byte _gap_0x8[0x2];
    /* 0x0A */ byte Aetherflow;
    /* 0x0B */ byte FairyGauge;
    /* 0x0C */ __int16 SeraphTimer;
    /* 0x0E */ byte DismissedFairy;
    /*      */ byte _gap_0xF;
};

struct Client::Game::Gauge::AstrologianGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int16 Timer;
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC;
    /* 0x0D */ byte Card;
    /* 0x0E */ byte Seals;
    /*      */ byte _gap_0xF;
};

struct Client::Game::Gauge::SageGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int16 AddersgallTimer;
    /* 0x0A */ byte Addersgall;
    /* 0x0B */ byte Addersting;
    /* 0x0C */ byte Eukrasia;
    /*      */ byte _gap_0xD;
    /*      */ byte _gap_0xE[0x2];
};

enum SongFlags: byte
{
    None = 0,
    MagesBallad = 1,
    ArmysPaeon = 2,
    WanderersMinuet = 3,
    MagesBalladLastPlayed = 4,
    ArmysPaeonLastPlayed = 8,
    WanderersMinuetLastPlayed = 12,
    MagesBalladCoda = 16,
    ArmysPaeonCoda = 32,
    WanderersMinuetCoda = 64
};

struct Client::Game::Gauge::BardGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ unsigned __int16 SongTimer;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ byte Repertoire;
    /* 0x0D */ byte SoulVoice;
    /* 0x0E */ Client::Game::Gauge::SongFlags SongFlags;
    /*      */ byte _gap_0xF;
};

struct Client::Game::Gauge::MachinistGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int16 OverheatTimeRemaining;
    /* 0x0A */ __int16 SummonTimeRemaining;
    /* 0x0C */ byte Heat;
    /* 0x0D */ byte Battery;
    /* 0x0E */ byte LastSummonBatteryPower;
    /* 0x0F */ byte TimerActive;
};

struct Client::Game::Gauge::DancerGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte Feathers;
    /* 0x09 */ byte Esprit;
    /* 0x0A */ byte DanceSteps[0x4];
    /* 0x0E */ byte StepIndex;
    /*      */ byte _gap_0xF;
};

enum EnochianFlags: byte
{
    None = 0,
    Enochian = 1,
    Paradox = 2
};

struct Client::Game::Gauge::BlackMageGauge /* Size=0x30 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int16 EnochianTimer;
    /* 0x0A */ __int16 ElementTimeRemaining;
    /* 0x0C */ signed __int8 ElementStance;
    /* 0x0D */ byte UmbralHearts;
    /* 0x0E */ byte PolyglotStacks;
    /* 0x0F */ Client::Game::Gauge::EnochianFlags EnochianFlags;
    /*      */ byte _gap_0x10[0x20];
};

enum AetherFlags: byte
{
    None = 0,
    Aetherflow1 = 1,
    Aetherflow2 = 2,
    Aetherflow = 3,
    IfritAttuned = 4,
    TitanAttuned = 8,
    GarudaAttuned = 12,
    PhoenixReady = 16,
    IfritReady = 32,
    TitanReady = 64,
    GarudaReady = 128
};

struct Client::Game::Gauge::SummonerGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ unsigned __int16 SummonTimer;
    /* 0x0A */ unsigned __int16 AttunementTimer;
    /* 0x0C */ byte ReturnSummon;
    /* 0x0D */ byte ReturnSummonGlam;
    /* 0x0E */ byte Attunement;
    /* 0x0F */ Client::Game::Gauge::AetherFlags AetherFlags;
};

struct Client::Game::Gauge::RedMageGauge /* Size=0x50 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte WhiteMana;
    /* 0x09 */ byte BlackMana;
    /* 0x0A */ byte ManaStacks;
    /*      */ byte _gap_0xB;
    /*      */ byte _gap_0xC[0x4];
    /*      */ byte _gap_0x10[0x40];
};

enum BeastChakraType: byte
{
    None = 0,
    Coeurl = 1,
    OpoOpo = 2,
    Raptor = 3
};

enum NadiFlags: byte
{
    Lunar = 2,
    Solar = 4
};

struct Client::Game::Gauge::MonkGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte Chakra;
    /* 0x09 */ Client::Game::Gauge::BeastChakraType BeastChakra1;
    /* 0x0A */ Client::Game::Gauge::BeastChakraType BeastChakra2;
    /* 0x0B */ Client::Game::Gauge::BeastChakraType BeastChakra3;
    /* 0x0C */ Client::Game::Gauge::NadiFlags Nadi;
    /*      */ byte _gap_0xD;
    /* 0x0E */ unsigned __int16 BlitzTimeRemaining;
};

struct Client::Game::Gauge::DragoonGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ __int16 LotdTimer;
    /* 0x0A */ byte LotdState;
    /* 0x0B */ byte EyeCount;
    /* 0x0C */ byte FirstmindsFocusCount;
    /*      */ byte _gap_0xD;
    /*      */ byte _gap_0xE[0x2];
};

struct Client::Game::Gauge::NinjaGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ unsigned __int16 HutonTimer;
    /* 0x0A */ byte Ninki;
    /* 0x0B */ byte HutonManualCasts;
    /*      */ byte _gap_0xC[0x4];
};

enum KaeshiAction: byte
{
    Higanbana = 1,
    Goken = 2,
    Setsugekka = 3,
    Namikiri = 4
};

enum SenFlags: byte
{
    None = 0,
    Setsu = 1,
    Getsu = 2,
    Ka = 4
};

struct Client::Game::Gauge::SamuraiGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /*      */ byte _gap_0x8[0x2];
    /* 0x0A */ Client::Game::Gauge::KaeshiAction Kaeshi;
    /* 0x0B */ byte Kenki;
    /* 0x0C */ byte MeditationStacks;
    /* 0x0D */ Client::Game::Gauge::SenFlags SenFlags;
    /*      */ byte _gap_0xE[0x2];
};

struct Client::Game::Gauge::ReaperGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte Soul;
    /* 0x09 */ byte Shroud;
    /* 0x0A */ unsigned __int16 EnshroudedTimeRemaining;
    /* 0x0C */ byte LemureShroud;
    /* 0x0D */ byte VoidShroud;
    /*      */ byte _gap_0xE[0x2];
};

struct Client::Game::Gauge::DarkKnightGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte Blood;
    /*      */ byte _gap_0x9;
    /* 0x0A */ unsigned __int16 DarksideTimer;
    /* 0x0C */ byte DarkArtsState;
    /*      */ byte _gap_0xD;
    /* 0x0E */ unsigned __int16 ShadowTimer;
};

struct Client::Game::Gauge::PaladinGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte OathGauge;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC[0x4];
};

struct Client::Game::Gauge::WarriorGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte BeastGauge;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC[0x4];
};

struct Client::Game::Gauge::GunbreakerGauge /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte Ammo;
    /*      */ byte _gap_0x9;
    /* 0x0A */ __int16 MaxTimerDuration;
    /* 0x0C */ byte AmmoComboStep;
    /*      */ byte _gap_0xD;
    /*      */ byte _gap_0xE[0x2];
};

struct Client::Game::JobGaugeManager /* Size=0x60 */
{
    /* 0x00 */ Client::Game::Gauge::JobGauge* CurrentGauge;
    union {
    /* 0x08 */ Client::Game::Gauge::JobGauge EmptyGauge;
    /* 0x08 */ Client::Game::Gauge::WhiteMageGauge WhiteMage;
    /* 0x08 */ Client::Game::Gauge::ScholarGauge Scholar;
    /* 0x08 */ Client::Game::Gauge::AstrologianGauge Astrologian;
    /* 0x08 */ Client::Game::Gauge::SageGauge Sage;
    /* 0x08 */ Client::Game::Gauge::BardGauge Bard;
    /* 0x08 */ Client::Game::Gauge::MachinistGauge Machinist;
    /* 0x08 */ Client::Game::Gauge::DancerGauge Dancer;
    /* 0x08 */ Client::Game::Gauge::BlackMageGauge BlackMage;
    /* 0x08 */ Client::Game::Gauge::SummonerGauge Summoner;
    /* 0x08 */ Client::Game::Gauge::RedMageGauge RedMage;
    /* 0x08 */ Client::Game::Gauge::MonkGauge Monk;
    /* 0x08 */ Client::Game::Gauge::DragoonGauge Dragoon;
    /* 0x08 */ Client::Game::Gauge::NinjaGauge Ninja;
    /* 0x08 */ Client::Game::Gauge::SamuraiGauge Samurai;
    /* 0x08 */ Client::Game::Gauge::ReaperGauge Reaper;
    /* 0x08 */ Client::Game::Gauge::DarkKnightGauge DarkKnight;
    /* 0x08 */ Client::Game::Gauge::PaladinGauge Paladin;
    /* 0x08 */ Client::Game::Gauge::WarriorGauge Warrior;
    /* 0x08 */ Client::Game::Gauge::GunbreakerGauge Gunbreaker;
    } _union_0x8;
    /*      */ byte _gap_0x10[0x48];
    /* 0x58 */ byte ClassJobID;
    /*      */ byte _gap_0x59;
    /*      */ byte _gap_0x5A[0x2];
    /*      */ byte _gap_0x5C[0x4];
};

struct Client::Game::GameMain /* Size=0x58D0 */
{
    /* 0x0000 */ unsigned __int32 ActiveFestivals[0x4];
    /*        */ byte _gap_0x10[0x30];
    /* 0x0040 */ unsigned __int32 QueuedFestivals[0x4];
    /*        */ byte _gap_0x50[0xA88];
    /* 0x0AD8 */ Client::Game::JobGaugeManager JobGaugeManager;
    /*        */ byte _gap_0xB38[0x34D8];
    /* 0x4010 */ unsigned __int32 CurrentTerritoryTypeId;
    /* 0x4014 */ unsigned __int32 CurrentTerritoryIntendedUseId;
    /*        */ byte _gap_0x4018[0x4];
    /* 0x401C */ unsigned __int16 CurrentContentFinderConditionId;
    /*        */ byte _gap_0x401E[0x2];
    /*        */ byte _gap_0x4020[0x8];
    /* 0x4028 */ unsigned __int32 CurrentMapId;
    /*        */ byte _gap_0x402C[0x4];
    /*        */ byte _gap_0x4030[0x18A0];
};

struct Client::Game::InventoryContainer /* Size=0x18 */
{
    /* 0x00 */ Client::Game::InventoryItem* Items;
    /* 0x08 */ Client::Game::InventoryType Type;
    /* 0x0C */ unsigned __int32 Size;
    /* 0x10 */ byte Loaded;
    /*      */ byte _gap_0x11;
    /*      */ byte _gap_0x12[0x2];
    /*      */ byte _gap_0x14[0x4];
};

struct Client::Game::InventoryManager /* Size=0x3620 */
{
    /*        */ byte _gap_0x0[0x1E08];
    /* 0x1E08 */ Client::Game::InventoryContainer* Inventories;
    /*        */ byte _gap_0x1E10[0x1810];
};

struct Client::Game::MonsterNoteManager /* Size=0x460 */
{
    /* 0x000 */ byte RankDataArray[0x300];
    /*       */ byte _gap_0x300[0x160];
};

struct Client::Game::MonsterNoteRankInfo /* Size=0x40 */
{
    /* 0x00 */ byte RankDataArray[0x28];
    /* 0x28 */ __int64 Flags;
    /* 0x30 */ __int32 Rank;
    /* 0x34 */ __int32 Unknown2;
    /* 0x38 */ __int32 Index;
    /* 0x3C */ __int32 Unknown3;
};

struct Client::Game::RankData /* Size=0x4 */
{
    /* 0x0 */ byte Counts[0x4];
};

struct Client::Game::QuestManager::QuestListArray /* Size=0x2D0 */
{
    /*       */ byte _gap_0x0[0x2D0];
};

struct Client::Game::QuestManager /* Size=0xF00 */
{
    union {
    /* 0x000 */ Client::Game::QuestManager::QuestListArray Quest;
    /* 0x000 */ byte NormalQuests[0x2D0];
    } _union_0x10;
    /*       */ byte _gap_0x8[0x560];
    /* 0x568 */ byte DailyQuests[0xC0];
    /*       */ byte _gap_0x628[0x30];
    /* 0x658 */ byte TrackedQuests[0x50];
    /*       */ byte _gap_0x6A8[0x4C8];
    /* 0xB70 */ byte BeastReputation[0x110];
    /* 0xC80 */ byte LeveQuests[0x180];
    /* 0xE00 */ byte NumLeveAllowances;
    /*       */ byte _gap_0xE01;
    /*       */ byte _gap_0xE02[0x2];
    /*       */ byte _gap_0xE04[0x4];
    /*       */ byte _gap_0xE08[0xE0];
    /* 0xEE8 */ byte NumAcceptedQuests;
    /*       */ byte _gap_0xEE9;
    /*       */ byte _gap_0xEEA[0x2];
    /*       */ byte _gap_0xEEC[0x4];
    /*       */ byte _gap_0xEF0[0x8];
    /* 0xEF8 */ byte NumAcceptedLeveQuests;
    /*       */ byte _gap_0xEF9;
    /*       */ byte _gap_0xEFA[0x2];
    /*       */ byte _gap_0xEFC[0x4];
};

struct Client::Game::RaceChocoboManager /* Size=0x26 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte MaximumSpeed;
    /* 0x09 */ byte Acceleration;
    /* 0x0A */ byte Endurance;
    /* 0x0B */ byte Stamina;
    /* 0x0C */ byte Cunning;
    /* 0x0D */ byte Parameters;
    /* 0x0E */ __int16 Father;
    /* 0x10 */ __int16 Mother;
    /* 0x12 */ byte AbilityHereditary;
    /* 0x13 */ byte AbilityLearned;
    /*      */ byte _gap_0x14[0x2];
    /* 0x16 */ __int16 NameFirst;
    /* 0x18 */ __int16 NameLast;
    /* 0x1A */ byte Rank;
    /*      */ byte _gap_0x1B;
    /* 0x1C */ __int16 ExperienceCurrent;
    /* 0x1E */ __int16 ExperienceMax;
    /* 0x20 */ byte Color;
    /* 0x21 */ byte GearHead;
    /* 0x22 */ byte GearBody;
    /* 0x23 */ byte GearLegs;
    /* 0x24 */ byte SessionsAvailable;
    /*      */ byte _gap_0x25;
};

struct Client::Game::ReconstructionBoxData /* Size=0xA8 */
{
    /*      */ byte _gap_0x0[0xA0];
    /* 0xA0 */ unsigned __int16 Donated;
    /*      */ byte _gap_0xA2[0x2];
    /*      */ byte _gap_0xA4[0x2];
    /* 0xA6 */ unsigned __int16 Allowance;
};

struct Client::Game::ReconstructionBoxManager /* Size=0x10 */
{
    /* 0x00 */ Client::Game::ReconstructionBoxData* ReconstructionBoxData;
    /* 0x08 */ void* UnknownDataPointer;
};

enum RetainerTown: byte
{
    LimsaLominsa = 1,
    Gridania = 2,
    Uldah = 3,
    Ishgard = 4,
    Kugane = 7,
    Crystarium = 10,
    OldSharlayan = 12
};

struct Client::Game::RetainerManager::RetainerList::Retainer /* Size=0x48 */
{
    /* 0x00 */ unsigned __int64 RetainerID;
    /* 0x08 */ byte Name[0x20];
    /* 0x28 */ bool Available;
    /* 0x29 */ byte ClassJob;
    /* 0x2A */ byte Level;
    /* 0x2B */ byte ItemCount;
    /* 0x2C */ unsigned __int32 Gil;
    /* 0x30 */ Client::Game::RetainerManager::RetainerList::RetainerTown Town;
    /* 0x31 */ byte MarkerItemCount;
    /*      */ byte _gap_0x32[0x2];
    /* 0x34 */ unsigned __int32 MarketExpire;
    /* 0x38 */ unsigned __int32 VentureID;
    /* 0x3C */ unsigned __int32 VentureComplete;
    /*      */ byte _gap_0x40[0x8];
};

struct Client::Game::RetainerManager::RetainerList /* Size=0x2D0 */
{
    /* 0x000 */ Client::Game::RetainerManager::RetainerList::Retainer Retainer0;
    /* 0x048 */ Client::Game::RetainerManager::RetainerList::Retainer Retainer1;
    /* 0x090 */ Client::Game::RetainerManager::RetainerList::Retainer Retainer2;
    /* 0x0D8 */ Client::Game::RetainerManager::RetainerList::Retainer Retainer3;
    /* 0x120 */ Client::Game::RetainerManager::RetainerList::Retainer Retainer4;
    /* 0x168 */ Client::Game::RetainerManager::RetainerList::Retainer Retainer5;
    /* 0x1B0 */ Client::Game::RetainerManager::RetainerList::Retainer Retainer6;
    /* 0x1F8 */ Client::Game::RetainerManager::RetainerList::Retainer Retainer7;
    /* 0x240 */ Client::Game::RetainerManager::RetainerList::Retainer Retainer8;
    /* 0x288 */ Client::Game::RetainerManager::RetainerList::Retainer Retainer9;
};

struct Client::Game::RetainerManager /* Size=0x2EC */
{
    /* 0x000 */ Client::Game::RetainerManager::RetainerList Retainer;
    /* 0x2D0 */ byte DisplayOrder[0xA];
    /* 0x2DA */ byte Ready;
    /* 0x2DB */ byte MaxRetainerEntitlement;
    /*       */ byte _gap_0x2DC[0x4];
    /* 0x2E0 */ unsigned __int64 LastSelectedRetainerId;
    /* 0x2E8 */ unsigned __int32 RetainerObjectId;
};

struct Client::Game::SatisfactionSupplyManager /* Size=0x31F */
{
    /*       */ byte _gap_0x0[0x10];
    /*       */ byte _gap_0x10[0x4];
    /* 0x014 */ byte SatisfactionRankArray[0x9];
    /* 0x01D */ byte UsedAllowanceArray[0x9];
    /*       */ byte _gap_0x26[0x2];
    /*       */ byte _gap_0x28[0x2F0];
    /*       */ byte _gap_0x318[0x4];
    /*       */ byte _gap_0x31C[0x2];
    /*       */ byte _gap_0x31E;
};

enum SatisfactionSupplyNpc: __int32
{
    ZholeAliapoh = 1,
    Mnaago = 2,
    Kurenai = 3,
    Adkiragh = 4,
    KaiShirr = 5,
    EhllTou = 6,
    Charlemend = 7,
    Ameliance = 8,
    Anden = 9
};

struct Client::Game::SavedAppearanceSlot /* Size=0x140 */
{
    /* 0x000 */ unsigned __int32 Magic;
    /* 0x004 */ unsigned __int32 Version;
    /*       */ byte _gap_0x8[0x8];
    /* 0x010 */ byte Customize[0x1A];
    /*       */ byte _gap_0x2A[0x2];
    /*       */ byte _gap_0x2C[0x4];
    /* 0x030 */ byte LabelBytes[0x40];
    /*       */ byte _gap_0x70[0xC0];
    /*       */ byte _gap_0x130[0x4];
    /* 0x134 */ bool IsCreated;
    /*       */ byte _gap_0x135;
    /*       */ byte _gap_0x136[0x2];
    /*       */ byte _gap_0x138[0x4];
    /* 0x13C */ byte SlotIndex;
    /*       */ byte _gap_0x13D;
    /*       */ byte _gap_0x13E[0x2];
};

struct Client::Game::UI::AreaInstance /* Size=0x28 */
{
    /*      */ byte _gap_0x0[0x10];
    /* 0x10 */ void* vtbl;
    /*      */ byte _gap_0x18[0x8];
    /* 0x20 */ __int32 Instance;
    /*      */ byte _gap_0x24[0x4];
};

struct Client::Game::UI::Buddy::BuddyMember /* Size=0x198 */
{
    /* 0x000 */ unsigned __int32 ObjectID;
    /* 0x004 */ unsigned __int32 CurrentHealth;
    /* 0x008 */ unsigned __int32 MaxHealth;
    /* 0x00C */ byte DataID;
    /* 0x00D */ byte Synced;
    /*       */ byte _gap_0xE[0x2];
    /* 0x010 */ Client::Game::StatusManager StatusManager;
};

struct Client::Game::UI::Buddy /* Size=0xED8 */
{
    /* 0x000 */ Client::Game::UI::Buddy::BuddyMember Companion;
    /* 0x198 */ Client::Game::UI::Buddy::BuddyMember Pet;
    /* 0x330 */ byte BattleBuddies[0xB28];
    /* 0xE58 */ Client::Game::UI::Buddy::BuddyMember* CompanionPtr;
    /* 0xE60 */ float TimeLeft;
    /*       */ byte _gap_0xE64[0x4];
    /*       */ byte _gap_0xE68[0x8];
    /*       */ byte _gap_0xE70[0x2];
    /*       */ byte _gap_0xE72;
    /* 0xE73 */ byte Name[0x15];
    /* 0xE88 */ unsigned __int32 CurrentXP;
    /* 0xE8C */ byte Rank;
    /* 0xE8D */ byte Stars;
    /* 0xE8E */ byte SkillPoints;
    /* 0xE8F */ byte DefenderLevel;
    /* 0xE90 */ byte AttackerLevel;
    /* 0xE91 */ byte HealerLevel;
    /* 0xE92 */ byte ActiveCommand;
    /* 0xE93 */ byte FavoriteFeed;
    /* 0xE94 */ byte CurrentColorStainId;
    /* 0xE95 */ byte Mounted;
    /*       */ byte _gap_0xE96[0x2];
    /*       */ byte _gap_0xE98[0x8];
    /* 0xEA0 */ Client::Game::UI::Buddy::BuddyMember* PetPtr;
    /*       */ byte _gap_0xEA8[0x8];
    /* 0xEB0 */ Client::Game::UI::Buddy::BuddyMember* SquadronTrustPtr;
    /*       */ byte _gap_0xEB8[0x20];
};

struct Client::Game::UI::Cabinet /* Size=0x48 */
{
    /* 0x00 */ __int32 CabinetLoaded;
    /* 0x04 */ byte UnlockedItems[0x41];
    /*      */ byte _gap_0x45;
    /*      */ byte _gap_0x46[0x2];
};

enum LootRule: byte
{
    Normal = 0,
    GreedOnly = 1,
    Lootmaster = 2
};

struct Client::Game::UI::ContentsFinder /* Size=0xB0 */
{
    /* 0x00 */ void* vtbl;
    /*      */ byte _gap_0x8[0x10];
    /* 0x18 */ Client::Game::UI::ContentsFinder::LootRule LootRules;
    /* 0x19 */ bool IsUnrestrictedParty;
    /* 0x1A */ bool IsMinimalIL;
    /* 0x1B */ bool IsSilenceEcho;
    /* 0x1C */ bool IsExplorerMode;
    /* 0x1D */ bool IsLevelSync;
    /* 0x1E */ bool IsLimitedLevelingRoulette;
    /*      */ byte _gap_0x1F;
    /*      */ byte _gap_0x20[0x40];
    /* 0x60 */ __int32 EnteredQueueTimestamp;
    /*      */ byte _gap_0x64[0x4];
    /*      */ byte _gap_0x68[0x10];
    /*      */ byte _gap_0x78[0x4];
    /* 0x7C */ byte PositionInQueue;
    /*      */ byte _gap_0x7D;
    /*      */ byte _gap_0x7E[0x2];
    /*      */ byte _gap_0x80[0x4];
    /*      */ byte _gap_0x84[0x2];
    /*      */ byte _gap_0x86;
    /* 0x87 */ byte AverageWaitTime;
    /*      */ byte _gap_0x88[0x28];
};

struct Client::Game::UI::ContentsNote /* Size=0xA8 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte CompletionFlags[0xB];
    /*      */ byte _gap_0x13;
    /*      */ byte _gap_0x14[0x4];
    /*      */ byte _gap_0x18[0x4];
    /* 0x1C */ byte SelectedTab;
    /* 0x1D */ byte DisplayCount;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ __int32 DisplayID[0x11];
    /* 0x64 */ __int32 DisplayStatus[0x11];
};

struct Client::Game::UI::Hate /* Size=0x108 */
{
    /* 0x000 */ byte HateArray[0x100];
    /* 0x100 */ __int32 HateArrayLength;
    /* 0x104 */ unsigned __int32 HateTargetId;
};

struct Client::Game::UI::HateInfo /* Size=0x8 */
{
    /* 0x0 */ unsigned __int32 ObjectId;
    /* 0x4 */ __int32 Enmity;
};

struct Client::Game::UI::Hater /* Size=0x908 */
{
    /* 0x000 */ byte HaterArray[0x900];
    /* 0x900 */ __int32 HaterArrayLength;
    /*       */ byte _gap_0x904[0x4];
};

struct Client::Game::UI::HaterInfo /* Size=0x48 */
{
    /* 0x00 */ byte Name[0x40];
    /* 0x40 */ unsigned __int32 ObjectId;
    /* 0x44 */ __int32 Enmity;
};

struct Client::Game::UI::Hotbar /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct Client::Game::UI::LimitBreakController /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte BarCount;
    /*      */ byte _gap_0x9;
    /* 0x0A */ unsigned __int16 CurrentValue;
    /* 0x0C */ unsigned __int32 BarValue;
};

struct Client::Game::UI::Loot /* Size=0x6A0 */
{
    /*       */ byte _gap_0x0[0x10];
    /* 0x010 */ byte ItemArray[0x400];
    /* 0x410 */ __int32 SelectedIndex;
    /*       */ byte _gap_0x414[0x4];
    /* 0x418 */ unsigned __int32 UnkObjectId;
    /*       */ byte _gap_0x41C[0x4];
    /*       */ byte _gap_0x420[0x258];
    /* 0x678 */ unsigned __int32 UnkObjectId2;
    /*       */ byte _gap_0x67C[0x4];
    /*       */ byte _gap_0x680[0x20];
};

enum RollState: __int32
{
    UpToNeed = 0,
    UpToGreed = 1,
    UpToPass = 2,
    Rolled = 17,
    Unavailable = 21,
    Unknown = 28
};

enum RollResult: __int32
{
    UnAwarded = 0,
    Greeded = 2,
    Passed = 5,
    Awarded = 6,
    Unknown = 7
};

enum LootMode: __int32
{
    Normal = 0,
    GreedOnly = 1,
    Unavailable = 2,
    LootMasterGreedOnly = 3,
    Unknown = 4
};

struct Client::Game::UI::LootItem /* Size=0x40 */
{
    /* 0x00 */ unsigned __int32 ChestObjectId;
    /* 0x04 */ unsigned __int32 ChestItemIndex;
    /* 0x08 */ unsigned __int32 ItemId;
    /* 0x0C */ unsigned __int16 ItemCount;
    /*      */ byte _gap_0xE[0x2];
    /*      */ byte _gap_0x10[0x10];
    /* 0x20 */ Client::Game::UI::RollState RollState;
    /* 0x24 */ Client::Game::UI::RollResult RollResult;
    /* 0x28 */ unsigned __int32 RollValue;
    /* 0x2C */ float Time;
    /* 0x30 */ float MaxTime;
    /*      */ byte _gap_0x34[0x4];
    /* 0x38 */ Client::Game::UI::LootMode LootMode;
    /*      */ byte _gap_0x3C[0x4];
};

struct Client::Game::UI::Map::QuestMarkerArray /* Size=0x10E0 */
{
    /*        */ byte _gap_0x0[0x10E0];
};

struct Client::Game::UI::Map /* Size=0x1168 */
{
    /*        */ byte _gap_0x0[0x88];
    /* 0x0088 */ Client::Game::UI::Map::QuestMarkerArray QuestMarkers;
};

struct Client::Game::UI::MarkingController /* Size=0x2B0 */
{
    /*       */ byte _gap_0x0[0x10];
    /* 0x010 */ __int64 MarkerArray[0xE];
    /* 0x080 */ unsigned __int32 LetterMarkerArray[0x1A];
    /* 0x0E8 */ __int64 MarkerTimeArray[0xE];
    /*       */ byte _gap_0x158[0x58];
    /* 0x1B0 */ byte FieldMarkerArray[0x100];
};

struct Client::Game::UI::FieldMarker /* Size=0x20 */
{
    /* 0x00 */ System::Numerics::Vector3 Position;
    /*      */ byte _gap_0xC[0x4];
    /* 0x10 */ __int32 X;
    /* 0x14 */ __int32 Y;
    /* 0x18 */ __int32 Z;
    /* 0x1C */ bool Active;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
};

struct Client::Game::UI::MobHunt /* Size=0x198 */
{
    /*       */ byte _gap_0x0[0x8];
    /* 0x008 */ byte AvailableMarkId[0x12];
    /* 0x01A */ byte ObtainedMarkId[0x12];
    /* 0x02C */ byte CurrentKills[0x168];
    /* 0x194 */ __int32 ObtainedFlags;
};

struct Client::Game::UI::PlayerState /* Size=0x7D0 */
{
    /* 0x000 */ byte IsLoaded;
    /* 0x001 */ byte CharacterName[0x40];
    /* 0x041 */ byte PSNOnlineID[0x11];
    /*       */ byte _gap_0x52[0x2];
    /* 0x054 */ unsigned __int32 ObjectId;
    /* 0x058 */ unsigned __int64 ContentId;
    /* 0x060 */ unsigned __int32 PenaltyTimestamps[0x2];
    /*       */ byte _gap_0x68;
    /* 0x069 */ byte MaxLevel;
    /* 0x06A */ byte MaxExpansion;
    /* 0x06B */ byte Sex;
    /* 0x06C */ byte Race;
    /* 0x06D */ byte Tribe;
    /* 0x06E */ byte CurrentClassJobId;
    /*       */ byte _gap_0x6F;
    /*       */ byte _gap_0x70[0x8];
    /* 0x078 */ __int16 CurrentLevel;
    /* 0x07A */ __int16 ClassJobLevelArray[0x1E];
    /*       */ byte _gap_0xB6[0x2];
    /* 0x0B8 */ __int32 ClassJobExpArray[0x1E];
    /* 0x130 */ __int16 SyncedLevel;
    /* 0x132 */ byte IsLevelSynced;
    /* 0x133 */ bool HasPremiumSaddlebag;
    /*       */ byte _gap_0x134[0x2];
    /* 0x136 */ byte GuardianDeity;
    /* 0x137 */ byte BirthMonth;
    /* 0x138 */ byte BirthDay;
    /* 0x139 */ byte FirstClass;
    /* 0x13A */ byte StartTown;
    /* 0x13B */ byte QuestSpecialFlags;
    /*       */ byte _gap_0x13C[0x4];
    /*       */ byte _gap_0x140[0x10];
    /*       */ byte _gap_0x150[0x4];
    /* 0x154 */ __int32 BaseStrength;
    /* 0x158 */ __int32 BaseDexterity;
    /* 0x15C */ __int32 BaseVitality;
    /* 0x160 */ __int32 BaseIntelligence;
    /* 0x164 */ __int32 BaseMind;
    /* 0x168 */ __int32 BasePiety;
    /* 0x16C */ __int32 Attributes[0x4A];
    /* 0x294 */ byte GrandCompany;
    /* 0x295 */ byte GCRankMaelstrom;
    /* 0x296 */ byte GCRankTwinAdders;
    /* 0x297 */ byte GCRankImmortalFlames;
    /* 0x298 */ byte HomeAetheryteId;
    /* 0x299 */ byte FavouriteAetheryteCount;
    /* 0x29A */ byte FavouriteAetheryteArray[0x4];
    /* 0x29E */ byte FreeAetheryteId;
    /*       */ byte _gap_0x29F;
    /* 0x2A0 */ unsigned __int32 BaseRestedExperience;
    /*       */ byte _gap_0x2A4[0x4];
    /*       */ byte _gap_0x2A8[0x38];
    /*       */ byte _gap_0x2E0;
    /* 0x2E1 */ byte NumOwnedMounts;
    /*       */ byte _gap_0x2E2[0x2];
    /*       */ byte _gap_0x2E4[0x4];
    /*       */ byte _gap_0x2E8[0x148];
    /* 0x430 */ unsigned __int32 NumFishCaught;
    /* 0x434 */ unsigned __int32 FishingBait;
    /*       */ byte _gap_0x438[0x28];
    /*       */ byte _gap_0x460[0x4];
    /* 0x464 */ unsigned __int32 NumSpearfishCaught;
    /*       */ byte _gap_0x468[0x4];
    /* 0x46C */ byte ContentRouletteCompletion[0xC];
    /* 0x478 */ __int16 PlayerCommendations;
    /* 0x47A */ byte SelectedPoses[0x7];
    /* 0x481 */ byte PlayerStateFlags1;
    /* 0x482 */ byte PlayerStateFlags2;
    /* 0x483 */ byte PlayerStateFlags3;
    /*       */ byte _gap_0x484[0x4];
    /*       */ byte _gap_0x488[0x78];
    /*       */ byte _gap_0x500;
    /* 0x501 */ byte UnlockFlags[0x2C];
    /*       */ byte _gap_0x52D;
    /*       */ byte _gap_0x52E[0x2];
    /*       */ byte _gap_0x530;
    /* 0x531 */ byte DeliveryLevel;
    /*       */ byte _gap_0x532;
    /* 0x533 */ byte MeisterFlag;
    /*       */ byte _gap_0x534[0x4];
    /* 0x538 */ unsigned __int32 SquadronMissionCompletionTimestamp;
    /* 0x53C */ unsigned __int32 SquadronTrainingCompletionTimestamp;
    /* 0x540 */ unsigned __int16 ActiveGcArmyExpedition;
    /* 0x542 */ unsigned __int16 ActiveGcArmyTraining;
    /*       */ byte _gap_0x544[0x4];
    /*       */ byte _gap_0x548[0xF8];
    /* 0x640 */ byte WeeklyBingoOrderData[0x10];
    /* 0x650 */ byte WeeklyBingoRewardData[0x4];
    /*       */ byte _gap_0x654[0x4];
    /*       */ byte _gap_0x658[0x8];
    /* 0x660 */ byte WeeklyBingoRequestOpenBingoNo;
    /*       */ byte _gap_0x661;
    /*       */ byte _gap_0x662[0x2];
    /*       */ byte _gap_0x664[0x4];
    /*       */ byte _gap_0x668[0x30];
    /*       */ byte _gap_0x698[0x4];
    /* 0x69C */ byte WeeklyBingoExpMultiplier;
    /* 0x69D */ bool WeeklyBingoUnk63;
    /*       */ byte _gap_0x69E[0x2];
    /*       */ byte _gap_0x6A0[0x90];
    /*       */ byte _gap_0x730[0x4];
    /* 0x734 */ byte MentorVersion;
    /*       */ byte _gap_0x735;
    /*       */ byte _gap_0x736[0x2];
    /* 0x738 */ unsigned __int32 DesynthesisLevels[0x8];
    /*       */ byte _gap_0x758[0x78];
};

enum PlayerStateFlag: unsigned __int32
{
    IsLoginSecurityToken = 1,
    IsBuddyInStable = 2,
    IsMentorStatusActive = 7,
    IsNoviceNetworkAutoJoinEnabled = 8,
    IsBattleMentorStatusActive = 9,
    IsTradeMentorStatusActive = 10,
    IsPvPMentorStatusActive = 11,
    Unknown14 = 14
};

struct Client::Game::UI::PvPProfile /* Size=0x7C */
{
    /* 0x00 */ byte IsLoaded;
    /*      */ byte _gap_0x1;
    /*      */ byte _gap_0x2[0x2];
    /* 0x04 */ unsigned __int32 ExperienceMaelstrom;
    /* 0x08 */ unsigned __int32 ExperienceTwinAdder;
    /* 0x0C */ unsigned __int32 ExperienceImmortalFlames;
    /* 0x10 */ byte RankMaelstrom;
    /* 0x11 */ byte RankTwinAdder;
    /* 0x12 */ byte RankImmortalFlames;
    /*      */ byte _gap_0x13;
    /*      */ byte _gap_0x14[0x4];
    /*      */ byte _gap_0x18[0x4];
    /*      */ byte _gap_0x1C[0x2];
    /* 0x1E */ byte Series;
    /* 0x1F */ byte SeriesCurrentRank;
    /* 0x20 */ byte SeriesClaimedRank;
    /*      */ byte _gap_0x21;
    /* 0x22 */ unsigned __int16 SeriesExperience;
    /* 0x24 */ byte PreviousSeriesClaimedRank;
    /* 0x25 */ byte PreviousSeriesRank;
    /*      */ byte _gap_0x26[0x2];
    /* 0x28 */ unsigned __int32 FrontlineTotalMatches;
    /* 0x2C */ unsigned __int32 FrontlineTotalFirstPlace;
    /* 0x30 */ unsigned __int32 FrontlineTotalSecondPlace;
    /* 0x34 */ unsigned __int32 FrontlineTotalThirdPlace;
    /* 0x38 */ unsigned __int16 FrontlineWeeklyMatches;
    /* 0x3A */ unsigned __int16 FrontlineWeeklyFirstPlace;
    /* 0x3C */ unsigned __int16 FrontlineWeeklySecondPlace;
    /* 0x3E */ unsigned __int16 FrontlineWeeklyThirdPlace;
    /*      */ byte _gap_0x40;
    /* 0x41 */ byte CrystallineConflictSeason;
    /* 0x42 */ unsigned __int16 CrystallineConflictCasualMatches;
    /* 0x44 */ unsigned __int16 CrystallineConflictCasualMatchesWon;
    /* 0x46 */ unsigned __int16 CrystallineConflictRankedMatches;
    /* 0x48 */ unsigned __int16 CrystallineConflictRankedMatchesWon;
    /*      */ byte _gap_0x4A[0x2];
    /*      */ byte _gap_0x4C[0x2];
    /* 0x4E */ unsigned __int16 CrystallineConflictCurrentCrystalCredit;
    /* 0x50 */ unsigned __int16 CrystallineConflictHighestCrystalCredit;
    /*      */ byte _gap_0x52[0x2];
    /* 0x54 */ byte CrystallineConflictCurrentRank;
    /* 0x55 */ byte CrystallineConflictHighestRank;
    /* 0x56 */ byte CrystallineConflictCurrentRiser;
    /* 0x57 */ byte CrystallineConflictHighestRiser;
    /* 0x58 */ byte CrystallineConflictCurrentRisingStars;
    /* 0x59 */ byte CrystallineConflictHighestRisingStars;
    /*      */ byte _gap_0x5A[0x2];
    /*      */ byte _gap_0x5C[0x4];
    /*      */ byte _gap_0x60[0x8];
    /*      */ byte _gap_0x68[0x4];
    /* 0x6C */ unsigned __int32 RivalWingsTotalMatches;
    /* 0x70 */ unsigned __int32 RivalWingsTotalMatchesWon;
    /* 0x74 */ unsigned __int32 RivalWingsWeeklyMatches;
    /* 0x78 */ unsigned __int32 RivalWingsWeeklyMatchesWon;
};

struct Client::Game::UI::RecipeNote::RecipeEntry /* Size=0x4F8 */
{
    /*       */ byte _gap_0x0[0x4C0];
    /*       */ byte _gap_0x4C0[0x2];
    /* 0x4C2 */ unsigned __int16 RecipeId;
    /*       */ byte _gap_0x4C4[0x4];
    /*       */ byte _gap_0x4C8[0x18];
    /*       */ byte _gap_0x4E0[0x4];
    /*       */ byte _gap_0x4E4[0x2];
    /*       */ byte _gap_0x4E6;
    /* 0x4E7 */ byte CraftType;
    /*       */ byte _gap_0x4E8[0x10];
};

struct Client::Game::UI::RecipeNote::RecipeData /* Size=0x3B0 */
{
    /* 0x000 */ Client::Game::UI::RecipeNote::RecipeEntry* Recipes;
    /*       */ byte _gap_0x8[0x3A0];
    /* 0x3A8 */ unsigned __int16 SelectedIndex;
    /*       */ byte _gap_0x3AA[0x2];
    /*       */ byte _gap_0x3AC[0x4];
};

struct Client::Game::UI::RecipeNote /* Size=0x610 */
{
    /* 0x000 */ unsigned __int32 Jobs[0x8];
    /*       */ byte _gap_0x20[0x98];
    /* 0x0B8 */ Client::Game::UI::RecipeNote::RecipeData* RecipeList;
    /*       */ byte _gap_0xC0[0x550];
};

struct Client::Game::UI::RelicNote /* Size=0x18 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte RelicID;
    /* 0x09 */ byte RelicNoteID;
    /* 0x0A */ byte MonsterProgress[0xA];
    /* 0x14 */ __int32 ObjectiveProgress;
};

struct Client::Game::UI::RouletteController /* Size=0x70 */
{
    /*      */ byte _gap_0x0[0x70];
};

struct Client::Game::UI::SelectUseTicketInvoker /* Size=0x28 */
{
    /* 0x00 */ void* vtbl;
    /*      */ byte _gap_0x8[0x8];
    /* 0x10 */ Client::Game::UI::Telepo* Telepo;
    /*      */ byte _gap_0x18[0x10];
};

struct Client::Game::UI::Telepo /* Size=0x58 */
{
    /* 0x00 */ void* vtbl;
    /*      */ byte _gap_0x8[0x8];
    /* 0x10 */ StdVector::ClientGameUITeleportInfo TeleportList;
    /* 0x28 */ Client::Game::UI::SelectUseTicketInvoker UseTicketInvoker;
    /*      */ byte _gap_0x50[0x8];
};

struct Client::Game::UI::TerritoryInfo /* Size=0x60 */
{
    /*      */ byte _gap_0x0[0x18];
    /*      */ byte _gap_0x18[0x4];
    /* 0x1C */ __int32 InSanctuary;
    /*      */ byte _gap_0x20[0x4];
    /* 0x24 */ unsigned __int32 AreaPlaceNameID;
    /* 0x28 */ unsigned __int32 SubAreaPlaceNameID;
    /*      */ byte _gap_0x2C[0x4];
    /*      */ byte _gap_0x30[0x30];
};

struct Client::Game::UI::WeaponState /* Size=0x20 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ bool IsUnsheathed;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /* 0x0C */ float SheatheCooldown;
    /* 0x10 */ float AutoSheathTimer;
    /* 0x14 */ bool AutoSheatheState;
    /*      */ byte _gap_0x15;
    /*      */ byte _gap_0x16[0x2];
    /* 0x18 */ bool IsAutoAttacking;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /*      */ byte _gap_0x1C[0x4];
};

struct Pointer::ClientGameObjectGameObject /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdSet::Node::PointerClientGameObjectGameObject /* Size=0x30 */
{
    /* 0x00 */ StdSet::Node::PointerClientGameObjectGameObject* Left;
    /* 0x08 */ StdSet::Node::PointerClientGameObjectGameObject* Parent;
    /* 0x10 */ StdSet::Node::PointerClientGameObjectGameObject* Right;
    /* 0x18 */ byte Color;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /* 0x1C */ bool IsNil;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ byte _18;
    /* 0x21 */ byte _19;
    /*      */ byte _gap_0x22[0x2];
    /*      */ byte _gap_0x24[0x4];
    /* 0x28 */ Pointer::ClientGameObjectGameObject Key;
};

struct StdSet::PointerClientGameObjectGameObject /* Size=0x10 */
{
    /* 0x00 */ StdSet::Node::PointerClientGameObjectGameObject* Head;
    /* 0x08 */ unsigned __int64 Count;
};

struct Client::Game::Event::EventGPoseController /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

struct Client::Game::Event::EventSceneModule /* Size=0x31A0 */
{
    /* 0x0000 */ Client::Game::Event::EventSceneModuleUsualImpl EventSceneModuleUsualImpl;
    /* 0x0010 */ Client::Game::Event::EventSceneModuleImplBase EventSceneModuleImplBase;
    /* 0x0020 */ Client::Game::Event::EventSceneModuleImplBase* EventSceneModuleImpl;
    /*        */ byte _gap_0x28[0x1A8];
    /* 0x01D0 */ Client::Game::Event::EventGPoseController EventGPoseController;
    /*        */ byte _gap_0x1D1;
    /*        */ byte _gap_0x1D2[0x2];
    /*        */ byte _gap_0x1D4[0x4];
    /*        */ byte _gap_0x1D8[0x2FC8];
};

struct Client::Game::Event::EventSceneModuleImplBase /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ Client::Game::Event::EventSceneModule* EventSceneModule;
};

struct Client::Game::Event::EventSceneModuleUsualImpl /* Size=0x10 */
{
    /* 0x00 */ Client::Game::Event::EventSceneModuleImplBase ImplBase;
};

struct Client::Game::Event::EventHandlerInfo /* Size=0x38 */
{
    /* 0x00 */ Client::Game::Event::EventId EventId;
    /* 0x04 */ byte Flags;
    /*      */ byte _gap_0x5;
    /*      */ byte _gap_0x6[0x2];
    /*      */ byte _gap_0x8[0x30];
};

struct Client::Game::Event::EventHandler /* Size=0x210 */
{
    /*       */ byte _gap_0x0[0x8];
    /* 0x008 */ StdSet::PointerClientGameObjectGameObject EventObjects;
    /* 0x018 */ Client::Game::Event::EventSceneModuleUsualImpl* EventSceneModule;
    /* 0x020 */ Client::Game::Event::EventHandlerInfo Info;
    /*       */ byte _gap_0x58[0x70];
    /* 0x0C8 */ Client::System::String::Utf8String UnkString0;
    /*       */ byte _gap_0x130[0x38];
    /* 0x168 */ Client::System::String::Utf8String UnkString1;
    /*       */ byte _gap_0x1D0[0x40];
};

struct Client::Game::Event::LuaEventHandler /* Size=0x330 */
{
    /* 0x000 */ Client::Game::Event::EventHandler EventHandler;
    /* 0x210 */ Common::Lua::LuaState* LuaState;
    /*       */ byte _gap_0x218[0x28];
    /* 0x240 */ Client::System::String::Utf8String LuaClass;
    /* 0x2A8 */ Client::System::String::Utf8String LuaKey;
    /*       */ byte _gap_0x310[0x20];
};

struct Client::Game::Event::Director /* Size=0x4B8 */
{
    /* 0x000 */ Client::Game::Event::LuaEventHandler LuaEventHandler;
    /* 0x330 */ Client::Game::Event::EventHandlerInfo* EventHandlerInfo;
    /* 0x338 */ unsigned __int32 ContentId;
    /* 0x33C */ byte ContentFlags;
    /*       */ byte _gap_0x33D;
    /*       */ byte _gap_0x33E[0x2];
    /* 0x340 */ byte Sequence;
    /*       */ byte _gap_0x341;
    /* 0x342 */ byte UnionData[0xA];
    /*       */ byte _gap_0x34C[0x4];
    /* 0x350 */ Client::System::String::Utf8String String0;
    /* 0x3B8 */ Client::System::String::Utf8String String1;
    /* 0x420 */ Client::System::String::Utf8String String2;
    /*       */ byte _gap_0x488[0x30];
};

struct Client::Game::Fate::FateDirector /* Size=0x4F8 */
{
    /* 0x000 */ Client::Game::Event::Director Director;
    /* 0x4B8 */ byte FateLevel;
    /*       */ byte _gap_0x4B9;
    /*       */ byte _gap_0x4BA[0x2];
    /*       */ byte _gap_0x4BC[0x4];
    /* 0x4C0 */ unsigned __int32 FateNpcObjectId;
    /*       */ byte _gap_0x4C4[0x4];
    /*       */ byte _gap_0x4C8[0x4];
    /* 0x4CC */ unsigned __int16 FateId;
    /*       */ byte _gap_0x4CE[0x2];
    /*       */ byte _gap_0x4D0[0x28];
};

struct Client::Game::UI::UIState /* Size=0x16BAC */
{
    /* 0x00000 */ Client::Game::UI::Hotbar Hotbar;
    /* 0x00008 */ Client::Game::UI::Hate Hate;
    /* 0x00110 */ Client::Game::UI::Hater Hater;
    /* 0x00A18 */ Client::Game::UI::WeaponState WeaponState;
    /* 0x00A38 */ Client::Game::UI::PlayerState PlayerState;
    /* 0x01208 */ Client::Game::UI::Revive Revive;
    /*         */ byte _gap_0x1238[0x268];
    /* 0x014A0 */ Client::Game::UI::Telepo Telepo;
    /* 0x014F8 */ Client::Game::UI::Cabinet Cabinet;
    /*         */ byte _gap_0x1540[0x550];
    /* 0x01A90 */ Client::Game::UI::Buddy Buddy;
    /*         */ byte _gap_0x2968[0x4];
    /* 0x0296C */ Client::Game::UI::PvPProfile PvPProfile;
    /*         */ byte _gap_0x29E8[0x8];
    /* 0x029F0 */ Client::Game::UI::ContentsNote ContentsNote;
    /* 0x02A98 */ Client::Game::UI::RelicNote RelicNote;
    /*         */ byte _gap_0x2AB0[0x48];
    /* 0x02AF8 */ Client::Game::UI::AreaInstance AreaInstance;
    /*         */ byte _gap_0x2B20[0x10];
    /*         */ byte _gap_0x2B30[0x4];
    /* 0x02B34 */ Client::Game::UI::MobHunt MobHunt;
    /*         */ byte _gap_0x2CCC[0x4];
    /*         */ byte _gap_0x2CD0[0x2F0];
    /* 0x02FC0 */ Client::Game::UI::Loot Loot;
    /*         */ byte _gap_0x3660[0x600];
    /* 0x03C60 */ Client::Game::UI::RecipeNote RecipeNote;
    /*         */ byte _gap_0x4270[0x6558];
    /* 0x0A7C8 */ Client::Game::Event::Director* ActiveDirector;
    /*         */ byte _gap_0xA7D0[0x140];
    /* 0x0A910 */ Client::Game::Fate::FateDirector* FateDirector;
    /*         */ byte _gap_0xA918[0x140];
    /* 0x0AA58 */ Client::Game::UI::Map Map;
    /*         */ byte _gap_0xBBC0[0x2E80];
    /* 0x0EA40 */ Client::Game::UI::MarkingController MarkingController;
    /* 0x0ECF0 */ Client::Game::UI::LimitBreakController LimitBreakController;
    /*         */ byte _gap_0xED00[0x2CB8];
    /* 0x119B8 */ Client::Game::UI::RouletteController RouletteController;
    /*         */ byte _gap_0x11A28[0x60];
    /* 0x11A88 */ Client::Game::UI::ContentsFinder ContentsFinder;
    /*         */ byte _gap_0x11B38[0x4EC0];
    /*         */ byte _gap_0x169F8[0x4];
    /* 0x169FC */ byte UnlockLinkBitmask[0x7E];
    /* 0x16A7A */ byte UnlockedCompanionsBitmask[0x3A];
    /*         */ byte _gap_0x16AB4[0x2];
    /* 0x16AB6 */ byte ChocoboTaxiStandsBitmask[0x26];
    /*         */ byte _gap_0x16ADC[0x4];
    /*         */ byte _gap_0x16AE0[0xC8];
    /*         */ byte _gap_0x16BA8[0x4];
};

struct Client::Game::Object::ClientObjectManager /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

enum ObjectKind: byte
{
    None = 0,
    Pc = 1,
    BattleNpc = 2,
    EventNpc = 3,
    Treasure = 4,
    Aetheryte = 5,
    GatheringPoint = 6,
    EventObj = 7,
    Mount = 8,
    Companion = 9,
    Retainer = 10,
    AreaObject = 11,
    HousingEventObject = 12,
    Cutscene = 13,
    MjiObject = 14,
    Ornament = 15,
    CardStand = 16
};

struct Client::Game::Object::GameObjectManager /* Size=0x3888 */
{
    /*        */ byte _gap_0x0[0x4];
    /* 0x0004 */ byte Active;
    /*        */ byte _gap_0x5;
    /*        */ byte _gap_0x6[0x2];
    /*        */ byte _gap_0x8[0x10];
    /* 0x0018 */ __int64 ObjectList[0x257];
    /* 0x12D0 */ __int64 ObjectListFiltered[0x257];
    /* 0x2588 */ __int64 ObjectList3[0x257];
    /* 0x3840 */ __int32 ObjectListFilteredCount;
    /* 0x3844 */ __int32 ObjectList3Count;
    /*        */ byte _gap_0x3848[0x40];
};

struct Client::Game::MJI::MJIFarmPasture /* Size=0x4 */
{
    /* 0x0 */ byte Level;
    /* 0x1 */ byte HoursToCompletion;
    /*     */ byte _gap_0x2[0x2];
    /* 0x4 */ bool UnderConstruction;
    /*     */ byte _gap_0x5;
    /*     */ byte _gap_0x6[0x2];
    /* 0x8 */ byte UNK_0x4;
};

struct Client::Game::MJI::MJIWorkshops /* Size=0x17 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ byte PlaceId[0x3];
    /* 0x0B */ byte GlamourLevel[0x3];
    /* 0x0E */ byte HoursToCompletion[0x3];
    /* 0x11 */ byte BuildingLevel[0x3];
    /* 0x14 */ byte UnderConstruction[0x3];
};

struct Client::Game::MJI::MJIGranaries /* Size=0x12 */
{
    /* 0x00 */ void* vtbl;
    /* 0x08 */ byte PlaceId[0x2];
    /* 0x0A */ byte GlamourLevel[0x2];
    /* 0x0C */ byte HoursToCompletion[0x2];
    /* 0x0E */ byte BuildingLevel[0x2];
    /* 0x10 */ byte UnderConstruction[0x2];
};

struct Client::Game::MJI::IslandState /* Size=0xB0 */
{
    /* 0x00 */ bool CanEditIsland;
    /* 0x01 */ byte CurrentRank;
    /*      */ byte _gap_0x2[0x2];
    /* 0x04 */ unsigned __int32 CurrentXP;
    /* 0x08 */ byte CurrentProgress;
    /* 0x09 */ byte VillageDevelopmentLevel;
    /* 0x0A */ byte PathsGlamourId;
    /* 0x0B */ byte GroundsGlamourId;
    /* 0x0C */ byte SlopesGlamourId;
    /* 0x0D */ unsigned __int16 UnlockedKeyItems;
    /* 0x0F */ byte UnlockedRecipes[0x3];
    /* 0x12 */ byte LockedPouchItems[0x4B];
    /*      */ byte _gap_0x5D;
    /* 0x5E */ Client::Game::MJI::MJIFarmPasture Farm;
    /* 0x62 */ Client::Game::MJI::MJIFarmPasture Pasture;
    /* 0x66 */ bool PastureUnderCare;
    /*      */ byte _gap_0x67;
    /* 0x68 */ unsigned __int16 PastureDailyCareFee;
    /* 0x6A */ unsigned __int16 FarmDailyCareFee;
    /* 0x6C */ byte LandmarkHoursToCompletion[0x4];
    /* 0x70 */ byte LandmarkIds[0x4];
    /* 0x74 */ byte LandmarkUnderConstruction[0x4];
    /* 0x78 */ Client::Game::MJI::MJIWorkshops Workshops;
    /*      */ byte _gap_0x8F;
    /* 0x90 */ Client::Game::MJI::MJIGranaries Granaries;
    /*      */ byte _gap_0xA2[0x2];
    /*      */ byte _gap_0xA4[0x4];
    /* 0xA8 */ byte CabinLevel;
    /* 0xA9 */ byte CabinGlamour;
    /*      */ byte _gap_0xAA[0x2];
    /*      */ byte _gap_0xAC[0x4];
};

struct Client::Game::MJI::MJIFarmState /* Size=0x148 */
{
    /* 0x000 */ void* vtbl;
    /* 0x008 */ void* vtbl2;
    /*       */ byte _gap_0x10[0x10];
    /* 0x020 */ byte SeedType[0x14];
    /* 0x034 */ byte GrowthLevel[0x14];
    /* 0x048 */ byte WaterLevel[0x14];
    /* 0x05C */ byte GardenerYield[0x14];
    /* 0x070 */ byte FarmSlotFlags[0x14];
    /*       */ byte _gap_0x84[0x4];
    /*       */ byte _gap_0x88[0xC0];
};

enum FarmSlotFlags: byte
{
    UnderCare = 1,
    WasUnderCare = 2,
    CareHalted = 4,
    Flag8 = 8
};

enum MJIAllowedVisitors: byte
{
    Friends = 1,
    FreeCompany = 2,
    Party = 4
};

struct Client::Game::MJI::MJIBuildingPlacement /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x4];
    /* 0x04 */ unsigned __int32 PlaceId;
    /* 0x08 */ unsigned __int16 SgbId;
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC[0x4];
};

struct Client::Game::MJI::MJIManager /* Size=0x378 */
{
    /*       */ byte _gap_0x0[0x4];
    /*       */ byte _gap_0x4[0x2];
    /* 0x006 */ byte IsPlayerInSanctuary;
    /*       */ byte _gap_0x7;
    /* 0x008 */ Client::Game::MJI::MJIAllowedVisitors AllowedVisitors;
    /*       */ byte _gap_0x9;
    /*       */ byte _gap_0xA[0x2];
    /*       */ byte _gap_0xC[0x4];
    /* 0x010 */ unsigned __int32 CurrentMode;
    /*       */ byte _gap_0x14[0x4];
    /*       */ byte _gap_0x18[0x4];
    /* 0x01C */ unsigned __int32 CurrentModeItem;
    /*       */ byte _gap_0x20[0x8];
    /* 0x028 */ Client::Game::MJI::IslandState IslandState;
    /*       */ byte _gap_0xD8[0x18];
    /* 0x0F0 */ Client::Game::MJI::MJIPastureHandler* PastureHandler;
    /* 0x0F8 */ Client::Game::MJI::MJIFarmState* FarmState;
    /*       */ byte _gap_0x100[0x80];
    /*       */ byte _gap_0x180[0x4];
    /* 0x184 */ byte LandmarkPlacements[0x30];
    /* 0x1B4 */ byte BuildingPlacements[0x50];
    /* 0x204 */ Client::Game::MJI::MJIBuildingPlacement CabinPlacement;
    /* 0x214 */ byte FarmPlacements[0x24];
    /* 0x238 */ byte PasturePlacements[0x24];
    /*       */ byte _gap_0x25C[0x4];
    /*       */ byte _gap_0x260[0x10];
    /* 0x270 */ byte CurrentPopularity;
    /* 0x271 */ byte NextPopularity;
    /* 0x272 */ byte SupplyAndDemandShifts[0x47];
    /*       */ byte _gap_0x2B9;
    /*       */ byte _gap_0x2BA[0x2];
    /*       */ byte _gap_0x2BC[0x4];
    /*       */ byte _gap_0x2C0[0x40];
    /*       */ byte _gap_0x300[0x4];
    /*       */ byte _gap_0x304[0x2];
    /* 0x306 */ byte CurrentCycleDay;
    /* 0x307 */ byte CraftworksRestDays[0x4];
    /*       */ byte _gap_0x30B;
    /*       */ byte _gap_0x30C[0x4];
    /*       */ byte _gap_0x310[0x40];
    /*       */ byte _gap_0x350[0x4];
    /* 0x354 */ unsigned __int32 CurrentGroove;
    /*       */ byte _gap_0x358[0x20];
};

struct Client::Game::MJI::MJILandmarkPlacement /* Size=0xC */
{
    /*     */ byte _gap_0x0[0x8];
    /* 0x8 */ byte HoursToCompletion;
    /* 0x9 */ byte LandmarkId;
    /* 0xA */ unsigned __int16 UnderConstruction;
};

struct Client::Game::MJI::MJIFarmPasturePlacement /* Size=0xC */
{
    /*     */ byte _gap_0x0[0x8];
    /* 0x8 */ byte SgbId;
    /*     */ byte _gap_0x9;
    /*     */ byte _gap_0xA[0x2];
};

enum CraftworkSupply: __int32
{
    Nonexistent = 0,
    Insufficient = 1,
    Sufficient = 2,
    Surplus = 3,
    Overflowing = 4
};

enum CraftworkDemandShift: __int32
{
    Skyrocketing = 0,
    Increasing = 1,
    None = 2,
    Decreasing = 3,
    Plummeting = 4
};

enum MJIMinimapIcons: byte
{
    Trees = 1,
    Vegetation = 2,
    Soils = 4,
    Minerals = 8,
    Aquatic = 16
};

struct Client::Game::MJI::MJIAnimal /* Size=0x34 */
{
    /* 0x00 */ byte SlotId;
    /*      */ byte _gap_0x1;
    /*      */ byte _gap_0x2[0x2];
    /*      */ byte _gap_0x4[0x4];
    /*      */ byte _gap_0x8[0x10];
    /*      */ byte _gap_0x18[0x4];
    /* 0x1C */ unsigned __int32 BNPCNameId;
    /* 0x20 */ unsigned __int32 ObjectId;
    /* 0x24 */ byte AnimalType;
    /* 0x25 */ byte FoodLevel;
    /* 0x26 */ byte Mood;
    /* 0x27 */ unsigned __int16 Leavings;
    /*      */ byte _gap_0x29;
    /*      */ byte _gap_0x2A[0x2];
    /*      */ byte _gap_0x2C[0x4];
    /*      */ byte _gap_0x30[0x4];
};

struct Client::Game::MJI::MJIMinionSlot /* Size=0xC */
{
    /* 0x0 */ byte SlotId;
    /*     */ byte _gap_0x1;
    /*     */ byte _gap_0x2[0x2];
    /* 0x4 */ unsigned __int32 ObjectId;
    /* 0x8 */ unsigned __int16 MinionId;
    /* 0xA */ byte PopAreaId;
    /*     */ byte _gap_0xB;
};

struct Client::Game::InstanceContent::ContentDirector /* Size=0xC38 */
{
    /* 0x000 */ Client::Game::Event::Director Director;
    /*       */ byte _gap_0x4B8[0x750];
    /* 0xC08 */ float ContentTimeLeft;
    /*       */ byte _gap_0xC0C[0x4];
    /*       */ byte _gap_0xC10[0x28];
};

struct Client::Game::InstanceContent::InstanceContentDirector /* Size=0x1CA0 */
{
    /* 0x0000 */ Client::Game::InstanceContent::ContentDirector ContentDirector;
    /*        */ byte _gap_0xC38[0x98];
    /*        */ byte _gap_0xCD0[0x4];
    /* 0x0CD4 */ byte InstanceContentType;
    /*        */ byte _gap_0xCD5;
    /*        */ byte _gap_0xCD6[0x2];
    /*        */ byte _gap_0xCD8[0xFC8];
};

struct Client::Game::InstanceContent::InstanceContentDeepDungeon /* Size=0x27D8 */
{
    /* 0x0000 */ Client::Game::InstanceContent::InstanceContentDirector InstanceContentDirector;
    /*        */ byte _gap_0x1CA0[0xA0];
    /* 0x1D40 */ byte Party[0x20];
    /* 0x1D60 */ byte Items[0x30];
    /* 0x1D90 */ byte Chests[0x20];
    /*        */ byte _gap_0x1DB0[0x8];
    /* 0x1DB8 */ unsigned __int32 BonusLootItemId;
    /* 0x1DBC */ byte Floor;
    /* 0x1DBD */ byte ReturnProgress;
    /* 0x1DBE */ byte PassageProgress;
    /*        */ byte _gap_0x1DBF;
    /* 0x1DC0 */ byte WeaponLevel;
    /* 0x1DC1 */ byte ArmorLevel;
    /*        */ byte _gap_0x1DC2;
    /* 0x1DC3 */ byte HoardCount;
    /*        */ byte _gap_0x1DC4[0x4];
    /*        */ byte _gap_0x1DC8[0xA10];
};

struct Client::Game::InstanceContent::PublicContentDirector /* Size=0x1080 */
{
    /* 0x0000 */ Client::Game::InstanceContent::ContentDirector ContentDirector;
    /*        */ byte _gap_0xC38[0x448];
};

struct Client::Game::Housing::HousingTerritory /* Size=0x96A4 */
{
    /*        */ byte _gap_0x0[0x96A0];
    /* 0x96A0 */ unsigned __int32 HouseID;
};

struct Client::Game::Housing::HousingWorkshopAirshipData /* Size=0x28F8 */
{
    /* 0x0000 */ byte DataList[0x700];
    /*        */ byte _gap_0x700[0x70];
    /* 0x0770 */ byte ActiveAirshipId;
    /* 0x0771 */ byte AirshipCount;
    /*        */ byte _gap_0x772[0x2];
    /*        */ byte _gap_0x774[0x4];
    /* 0x0778 */ byte AirshipLogList[0x2150];
    /*        */ byte _gap_0x28C8[0x30];
};

struct Client::Game::Housing::HousingWorkshopSubmersibleData /* Size=0x8F40 */
{
    /* 0x0000 */ byte DataList[0x8C80];
    /* 0x8C80 */ byte DataPointerList[0x28];
    /*        */ byte _gap_0x8CA8[0x298];
};

struct Client::Game::Housing::HousingWorkshopTerritory /* Size=0xB8C0 */
{
    /*        */ byte _gap_0x0[0x68];
    /* 0x0068 */ Client::Game::Housing::HousingWorkshopAirshipData Airship;
    /* 0x2960 */ Client::Game::Housing::HousingWorkshopSubmersibleData Submersible;
    /*        */ byte _gap_0xB8A0[0x20];
};

struct Client::Game::Housing::HousingManager /* Size=0xE0 */
{
    /* 0x00 */ Client::Game::Housing::HousingTerritory* CurrentTerritory;
    /* 0x08 */ Client::Game::Housing::HousingTerritory* OutdoorTerritory;
    /* 0x10 */ Client::Game::Housing::HousingTerritory* IndoorTerritory;
    /* 0x18 */ Client::Game::Housing::HousingWorkshopTerritory* WorkshopTerritory;
    /*      */ byte _gap_0x20[0xC0];
};

struct Client::Game::Housing::HousingWorkshopAirshipGathered /* Size=0x38 */
{
    /* 0x00 */ unsigned __int32 ExpGained;
    /*      */ byte _gap_0x4[0x4];
    /*      */ byte _gap_0x8[0x4];
    /* 0x0C */ unsigned __int32 ItemIdPrimary;
    /* 0x10 */ unsigned __int32 ItemIdAdditional;
    /* 0x14 */ unsigned __int16 ItemCountPrimary;
    /* 0x16 */ unsigned __int16 ItemCountAdditional;
    /* 0x18 */ unsigned __int32 Unk1Primary;
    /* 0x1C */ unsigned __int32 Unk1Additional;
    /* 0x20 */ unsigned __int32 Unk2Primary;
    /* 0x24 */ unsigned __int32 Unk2Additional;
    /* 0x28 */ unsigned __int32 Unk3Primary;
    /* 0x2C */ unsigned __int32 Unk3Additional;
    /*      */ byte _gap_0x30[0x2];
    /* 0x32 */ bool AirshipItemValidPrimary;
    /* 0x33 */ bool AirshipItemValidAdditional;
    /*      */ byte _gap_0x34[0x4];
};

struct Client::Game::Housing::HousingWorkshopSubmersibleSubData /* Size=0x2320 */
{
    /* 0x0000 */ Client::Game::Housing::HousingWorkshopSubmersibleData* Parent;
    /*        */ byte _gap_0x8[0x4];
    /*        */ byte _gap_0xC[0x2];
    /* 0x000E */ byte RankId;
    /*        */ byte _gap_0xF;
    /* 0x0010 */ unsigned __int32 RegisterTime;
    /* 0x0014 */ unsigned __int32 ReturnTime;
    /* 0x0018 */ unsigned __int32 CurrentExp;
    /* 0x001C */ unsigned __int32 NextLevelExp;
    /*        */ byte _gap_0x20[0x2];
    /* 0x0022 */ byte Name[0x14];
    /*        */ byte _gap_0x36[0x2];
    /*        */ byte _gap_0x38[0x2];
    /* 0x003A */ unsigned __int16 HullId;
    /* 0x003C */ unsigned __int16 SternId;
    /* 0x003E */ unsigned __int16 BowId;
    /* 0x0040 */ unsigned __int16 BridgeId;
    /* 0x0042 */ byte CurrentExplorationPoints[0x5];
    /*        */ byte _gap_0x47;
    /*        */ byte _gap_0x48[0x2];
    /* 0x004A */ unsigned __int16 SurveillanceBase;
    /* 0x004C */ unsigned __int16 RetrievalBase;
    /* 0x004E */ unsigned __int16 SpeedBase;
    /* 0x0050 */ unsigned __int16 RangeBase;
    /* 0x0052 */ unsigned __int16 FavorBase;
    /* 0x0054 */ unsigned __int16 SurveillanceBonus;
    /* 0x0056 */ unsigned __int16 RetrievalBonus;
    /* 0x0058 */ unsigned __int16 SpeedBonus;
    /* 0x005A */ unsigned __int16 RangeBonus;
    /* 0x005C */ unsigned __int16 FavorBonus;
    /*        */ byte _gap_0x5E[0x2];
    /* 0x0060 */ byte Rating;
    /*        */ byte _gap_0x61;
    /*        */ byte _gap_0x62[0x2];
    /* 0x0064 */ byte GatheredData[0x118];
    /*        */ byte _gap_0x17C[0x4];
    /*        */ byte _gap_0x180[0x30];
    /* 0x01B0 */ byte LogList[0x2150];
    /*        */ byte _gap_0x2300[0x20];
};

struct Client::Game::Housing::HousingWorkshopSubmarineGathered /* Size=0x38 */
{
    /* 0x00 */ byte Point;
    /*      */ byte _gap_0x1;
    /*      */ byte _gap_0x2[0x2];
    /*      */ byte _gap_0x4[0x4];
    /*      */ byte _gap_0x8[0x4];
    /* 0x0C */ unsigned __int32 ExpGained;
    /* 0x10 */ unsigned __int32 ItemIdPrimary;
    /* 0x14 */ unsigned __int32 ItemIdAdditional;
    /* 0x18 */ unsigned __int16 ItemCountPrimary;
    /* 0x1A */ unsigned __int16 ItemCountAdditional;
    /* 0x1C */ bool ItemHQPrimary;
    /* 0x1D */ bool ItemHQAdditional;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ unsigned __int32 UnknownPrimary1;
    /* 0x24 */ unsigned __int32 UnknownAdditional1;
    /* 0x28 */ unsigned __int32 UnknownPrimary2;
    /* 0x2C */ unsigned __int32 UnknownAdditional2;
    /* 0x30 */ unsigned __int32 UnknownPrimary3;
    /* 0x34 */ unsigned __int32 UnknownAdditional3;
};

struct Client::Game::Group::GroupManager /* Size=0x3D70 */
{
    /* 0x0000 */ byte PartyMembers[0x1180];
    /* 0x1180 */ byte AllianceMembers[0x2BC0];
    /* 0x3D40 */ unsigned __int32 Unk_3D40;
    /* 0x3D44 */ unsigned __int16 Unk_3D44;
    /*        */ byte _gap_0x3D46[0x2];
    /* 0x3D48 */ __int64 PartyId;
    /* 0x3D50 */ __int64 PartyId_2;
    /* 0x3D58 */ unsigned __int32 PartyLeaderIndex;
    /* 0x3D5C */ byte MemberCount;
    /* 0x3D5D */ byte Unk_3D5D;
    /*        */ byte _gap_0x3D5E;
    /* 0x3D5F */ byte Unk_3D5F;
    /* 0x3D60 */ byte Unk_3D60;
    /* 0x3D61 */ byte AllianceFlags;
    /*        */ byte _gap_0x3D62[0x2];
    /*        */ byte _gap_0x3D64[0x4];
    /*        */ byte _gap_0x3D68[0x8];
};

struct Client::Game::Group::PartyMember /* Size=0x230 */
{
    /* 0x000 */ Client::Game::StatusManager StatusManager;
    /*       */ byte _gap_0x188[0x8];
    /* 0x190 */ float X;
    /* 0x194 */ float Y;
    /* 0x198 */ float Z;
    /*       */ byte _gap_0x19C[0x4];
    /* 0x1A0 */ __int64 ContentID;
    /* 0x1A8 */ unsigned __int32 ObjectID;
    /* 0x1AC */ unsigned __int32 Unk_ObjectID_1;
    /* 0x1B0 */ unsigned __int32 Unk_ObjectID_2;
    /* 0x1B4 */ unsigned __int32 CurrentHP;
    /* 0x1B8 */ unsigned __int32 MaxHP;
    /* 0x1BC */ unsigned __int16 CurrentMP;
    /* 0x1BE */ unsigned __int16 MaxMP;
    /* 0x1C0 */ unsigned __int16 TerritoryType;
    /* 0x1C2 */ unsigned __int16 HomeWorld;
    /* 0x1C4 */ byte Name[0x40];
    /* 0x204 */ byte Sex;
    /* 0x205 */ byte ClassJob;
    /* 0x206 */ byte Level;
    /*       */ byte _gap_0x207;
    /* 0x208 */ byte Unk_Struct_208__0;
    /*       */ byte _gap_0x209;
    /*       */ byte _gap_0x20A[0x2];
    /* 0x20C */ unsigned __int32 Unk_Struct_208__4;
    /* 0x210 */ unsigned __int16 Unk_Struct_208__8;
    /*       */ byte _gap_0x212[0x2];
    /* 0x214 */ unsigned __int32 Unk_Struct_208__C;
    /* 0x218 */ unsigned __int16 Unk_Struct_208__10;
    /* 0x21A */ unsigned __int16 Unk_Struct_208__14;
    /*       */ byte _gap_0x21C[0x4];
    /* 0x220 */ byte Flags;
    /*       */ byte _gap_0x221;
    /*       */ byte _gap_0x222[0x2];
    /*       */ byte _gap_0x224[0x4];
    /*       */ byte _gap_0x228[0x8];
};

enum AstrologianCard: __int32
{
    None = 0,
    Balance = 1,
    Bole = 2,
    Arrow = 3,
    Spear = 4,
    Ewer = 5,
    Spire = 6,
    Lord = 112,
    Lady = 128
};

enum AstrologianSeal: __int32
{
    Solar = 1,
    Lunar = 2,
    Celestial = 3
};

enum DanceStep: byte
{
    Finish = 0,
    Emboite = 1,
    Entrechat = 2,
    Jete = 3,
    Pirouette = 4
};

struct Client::Game::Fate::FateContext /* Size=0x1040 */
{
    /*        */ byte _gap_0x0[0x18];
    /* 0x0018 */ unsigned __int16 FateId;
    /*        */ byte _gap_0x1A[0x2];
    /*        */ byte _gap_0x1C[0x4];
    /* 0x0020 */ __int32 StartTimeEpoch;
    /*        */ byte _gap_0x24[0x4];
    /* 0x0028 */ __int16 Duration;
    /*        */ byte _gap_0x2A[0x2];
    /*        */ byte _gap_0x2C[0x4];
    /*        */ byte _gap_0x30[0x90];
    /* 0x00C0 */ Client::System::String::Utf8String Name;
    /* 0x0128 */ Client::System::String::Utf8String Description;
    /* 0x0190 */ Client::System::String::Utf8String Objective;
    /*        */ byte _gap_0x1F8[0x1B0];
    /*        */ byte _gap_0x3A8[0x4];
    /* 0x03AC */ byte State;
    /*        */ byte _gap_0x3AD;
    /*        */ byte _gap_0x3AE;
    /* 0x03AF */ byte HandInCount;
    /*        */ byte _gap_0x3B0[0x8];
    /* 0x03B8 */ byte Progress;
    /*        */ byte _gap_0x3B9;
    /*        */ byte _gap_0x3BA[0x2];
    /*        */ byte _gap_0x3BC[0x4];
    /*        */ byte _gap_0x3C0[0x18];
    /* 0x03D8 */ unsigned __int32 IconId;
    /*        */ byte _gap_0x3DC[0x4];
    /*        */ byte _gap_0x3E0[0x18];
    /*        */ byte _gap_0x3F8;
    /* 0x03F9 */ byte Level;
    /* 0x03FA */ byte MaxLevel;
    /*        */ byte _gap_0x3FB;
    /*        */ byte _gap_0x3FC[0x4];
    /*        */ byte _gap_0x400[0x50];
    /* 0x0450 */ System::Numerics::Vector3 Location;
    /*        */ byte _gap_0x45C[0x4];
    /*        */ byte _gap_0x460[0x4];
    /* 0x0464 */ float Radius;
    /*        */ byte _gap_0x468[0x2B8];
    /* 0x0720 */ unsigned __int32 MapIconId;
    /*        */ byte _gap_0x724[0x4];
    /*        */ byte _gap_0x728[0x20];
    /*        */ byte _gap_0x748[0x4];
    /*        */ byte _gap_0x74C[0x2];
    /* 0x074E */ unsigned __int16 TerritoryId;
    /*        */ byte _gap_0x750[0x8F0];
};

struct StdVector::ClientGameObjectGameObjectID /* Size=0x18 */
{
    /* 0x00 */ Client::Game::Object::GameObjectID* First;
    /* 0x08 */ Client::Game::Object::GameObjectID* Last;
    /* 0x10 */ Client::Game::Object::GameObjectID* End;
};

struct Pointer::ClientGameFateFateContext /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdVector::PointerClientGameFateFateContext /* Size=0x18 */
{
    /* 0x00 */ Pointer::ClientGameFateFateContext* First;
    /* 0x08 */ Pointer::ClientGameFateFateContext* Last;
    /* 0x10 */ Pointer::ClientGameFateFateContext* End;
};

struct Client::Game::Fate::FateManager /* Size=0xB8 */
{
    /* 0x00 */ StdVector::ClientGameObjectGameObjectID Unk_Vector;
    /* 0x18 */ Client::System::String::Utf8String Unk_String;
    /* 0x80 */ Client::Game::Fate::FateDirector* FateDirector;
    /* 0x88 */ Client::Game::Fate::FateContext* CurrentFate;
    /* 0x90 */ StdVector::PointerClientGameFateFateContext Fates;
    /* 0xA8 */ unsigned __int16 SyncedFateId;
    /*      */ byte _gap_0xAA[0x2];
    /* 0xAC */ byte FateJoined;
    /*      */ byte _gap_0xAD;
    /*      */ byte _gap_0xAE[0x2];
    /*      */ byte _gap_0xB0[0x8];
};

struct Client::Game::Event::ModuleBase /* Size=0x40 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ Common::Lua::LuaState* LuaState;
    /*      */ byte _gap_0x10[0x30];
};

struct Pointer::ClientGameEventDirector /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdVector::PointerClientGameEventDirector /* Size=0x18 */
{
    /* 0x00 */ Pointer::ClientGameEventDirector* First;
    /* 0x08 */ Pointer::ClientGameEventDirector* Last;
    /* 0x10 */ Pointer::ClientGameEventDirector* End;
};

struct StdPair::SystemIntPtr::SystemIntPtr /* Size=0x10 */
{
    /* 0x00 */ __int64 Item1;
    /* 0x08 */ __int64 Item2;
};

struct StdPair::SystemUInt16::StdPairSystemIntPtrSystemIntPtr /* Size=0x18 */
{
    /* 0x00 */ unsigned __int16 Item1;
    /*      */ byte _gap_0x2[0x2];
    /*      */ byte _gap_0x4[0x4];
    /* 0x08 */ StdPair::SystemIntPtr::SystemIntPtr Item2;
};

struct StdMap::Node::SystemUInt16::StdPairSystemIntPtrSystemIntPtr /* Size=0x40 */
{
    /* 0x00 */ StdMap::Node::SystemUInt16::StdPairSystemIntPtrSystemIntPtr* Left;
    /* 0x08 */ StdMap::Node::SystemUInt16::StdPairSystemIntPtrSystemIntPtr* Parent;
    /* 0x10 */ StdMap::Node::SystemUInt16::StdPairSystemIntPtrSystemIntPtr* Right;
    /* 0x18 */ byte Color;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /* 0x1C */ bool IsNil;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ byte _18;
    /* 0x21 */ byte _19;
    /*      */ byte _gap_0x22[0x2];
    /*      */ byte _gap_0x24[0x4];
    /* 0x28 */ StdPair::SystemUInt16::StdPairSystemIntPtrSystemIntPtr KeyValuePair;
};

struct StdMap::SystemUInt16::StdPairSystemIntPtrSystemIntPtr /* Size=0x10 */
{
    /* 0x00 */ StdMap::Node::SystemUInt16::StdPairSystemIntPtrSystemIntPtr* Head;
    /* 0x08 */ unsigned __int64 Count;
};

struct Client::Game::Event::DirectorModule /* Size=0xA0 */
{
    /* 0x00 */ Client::Game::Event::ModuleBase ModuleBase;
    /* 0x40 */ StdVector::PointerClientGameEventDirector DirectorList;
    /* 0x58 */ StdMap::SystemUInt16::StdPairSystemIntPtrSystemIntPtr DirectorFactories;
    /*      */ byte _gap_0x68[0x30];
    /* 0x98 */ Client::Game::InstanceContent::ContentDirector* ActiveContentDirector;
};

struct Pointer::ClientGameEventEventHandler /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct StdPair::SystemUInt32::PointerClientGameEventEventHandler /* Size=0x10 */
{
    /* 0x00 */ unsigned __int32 Item1;
    /*      */ byte _gap_0x4[0x4];
    /* 0x08 */ Pointer::ClientGameEventEventHandler Item2;
};

struct StdMap::Node::SystemUInt32::PointerClientGameEventEventHandler /* Size=0x38 */
{
    /* 0x00 */ StdMap::Node::SystemUInt32::PointerClientGameEventEventHandler* Left;
    /* 0x08 */ StdMap::Node::SystemUInt32::PointerClientGameEventEventHandler* Parent;
    /* 0x10 */ StdMap::Node::SystemUInt32::PointerClientGameEventEventHandler* Right;
    /* 0x18 */ byte Color;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /* 0x1C */ bool IsNil;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ byte _18;
    /* 0x21 */ byte _19;
    /*      */ byte _gap_0x22[0x2];
    /*      */ byte _gap_0x24[0x4];
    /* 0x28 */ StdPair::SystemUInt32::PointerClientGameEventEventHandler KeyValuePair;
};

struct StdMap::SystemUInt32::PointerClientGameEventEventHandler /* Size=0x10 */
{
    /* 0x00 */ StdMap::Node::SystemUInt32::PointerClientGameEventEventHandler* Head;
    /* 0x08 */ unsigned __int64 Count;
};

struct Client::Game::Event::EventHandlerModule /* Size=0xC0 */
{
    /* 0x00 */ Client::Game::Event::ModuleBase ModuleBase;
    /* 0x40 */ StdMap::SystemUInt32::PointerClientGameEventEventHandler EventHandlerMap;
    /* 0x50 */ StdMap::SystemUInt16::StdPairSystemIntPtrSystemIntPtr EventHandlerFactories;
    /*      */ byte _gap_0x60[0x60];
};

struct StdPair::SystemInt64::ClientGameEventLuaActor /* Size=0x88 */
{
    /* 0x00 */ __int64 Item1;
    /* 0x08 */ Client::Game::Event::LuaActor Item2;
};

struct StdMap::Node::SystemInt64::ClientGameEventLuaActor /* Size=0xB0 */
{
    /* 0x00 */ StdMap::Node::SystemInt64::ClientGameEventLuaActor* Left;
    /* 0x08 */ StdMap::Node::SystemInt64::ClientGameEventLuaActor* Parent;
    /* 0x10 */ StdMap::Node::SystemInt64::ClientGameEventLuaActor* Right;
    /* 0x18 */ byte Color;
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
    /* 0x1C */ bool IsNil;
    /*      */ byte _gap_0x1D;
    /*      */ byte _gap_0x1E[0x2];
    /* 0x20 */ byte _18;
    /* 0x21 */ byte _19;
    /*      */ byte _gap_0x22[0x2];
    /*      */ byte _gap_0x24[0x4];
    /* 0x28 */ StdPair::SystemInt64::ClientGameEventLuaActor KeyValuePair;
};

struct StdMap::SystemInt64::ClientGameEventLuaActor /* Size=0x10 */
{
    /* 0x00 */ StdMap::Node::SystemInt64::ClientGameEventLuaActor* Head;
    /* 0x08 */ unsigned __int64 Count;
};

struct Client::Game::Event::LuaActorModule /* Size=0x50 */
{
    /* 0x00 */ Client::Game::Event::ModuleBase ModuleBase;
    /* 0x40 */ StdMap::SystemInt64::ClientGameEventLuaActor ActorMap;
};

struct Client::Game::Event::EventState /* Size=0x30 */
{
    /*      */ byte _gap_0x0[0x10];
    /* 0x10 */ Client::Game::Object::GameObjectID ObjectId;
    /*      */ byte _gap_0x18[0x18];
};

struct Client::Game::Event::EventFramework /* Size=0x3BC0 */
{
    /* 0x0000 */ Client::Game::Event::EventHandlerModule EventHandlerModule;
    /* 0x00C0 */ Client::Game::Event::DirectorModule DirectorModule;
    /* 0x0160 */ Client::Game::Event::LuaActorModule LuaActorModule;
    /* 0x01B0 */ Client::Game::Event::EventSceneModule EventSceneModule;
    /* 0x3350 */ __int32 LoadState;
    /*        */ byte _gap_0x3354[0x4];
    /* 0x3358 */ Common::Lua::LuaState* LuaState;
    /* 0x3360 */ Common::Lua::LuaThread LuaThread;
    /*        */ byte _gap_0x3388[0x30];
    /* 0x33B8 */ Client::Game::Event::EventState EventState1;
    /*        */ byte _gap_0x33E8[0x30];
    /* 0x3418 */ Client::Game::Event::EventState EventState2;
    /*        */ byte _gap_0x3448[0x778];
};

enum EventHandlerType: unsigned __int16
{
    Quest = 1,
    Warp = 2,
    GatheringPoint = 3,
    Shop = 4,
    Aetheryte = 5,
    GuildLeveAssignment = 6,
    DefaultTalk = 9,
    Craft = 10,
    CustomTalk = 11,
    CompanyLeveOfficer = 12,
    Array = 13,
    CraftLeve = 14,
    GimmickAccessor = 15,
    GimmickBill = 16,
    GimmickRect = 17,
    ChocoboTaxiStand = 18,
    Opening = 19,
    ExitRange = 20,
    Fishing = 21,
    GrandCompanyShop = 22,
    GuildOrderGuide = 23,
    GuildOrderOfficer = 24,
    ContentNpc = 25,
    Story = 26,
    SpecialShop = 27,
    ContentTalk = 28,
    InstanceContentGuide = 29,
    HousingAethernet = 30,
    FcTalk = 31,
    MobHunt = 32,
    Adventure = 33,
    DailyQuestSupply = 34,
    TripleTriad = 35,
    GoldSaucerArcadeMachine = 36,
    LotteryExchangeShop = 52,
    TripleTriadCompetition = 55,
    BattleLeveDirector = 32769,
    GatheringLeveDirector = 32770,
    InstanceContentDirector = 32771,
    PublicContentDirector = 32772,
    QuestBattleDirector = 32774,
    CompanyLeveDirector = 32775,
    TreasureHuntDirector = 32777,
    GoldSaucerDirector = 32778,
    CompanyCraftDirector = 32779,
    DpsChallengeDirector = 32781,
    FateDirector = 32794
};

struct Client::Game::Control::CameraManager /* Size=0x180 */
{
    /* 0x000 */ Client::Game::Camera* Camera;
    /* 0x008 */ Client::Game::LowCutCamera* LowCutCamera;
    /* 0x010 */ Client::Game::LobbyCamera* LobbCamera;
    /* 0x018 */ Client::Game::Camera3* Camera3;
    /* 0x020 */ Client::Game::Camera4* Camera4;
    /*       */ byte _gap_0x28[0x20];
    /* 0x048 */ __int32 ActiveCameraIndex;
    /* 0x04C */ __int32 PreviousCameraIndex;
    /*       */ byte _gap_0x50[0x10];
    /* 0x060 */ Client::Game::CameraBase UnkCamera;
    /*       */ byte _gap_0x170[0x10];
};

struct Client::Game::Control::GameObjectArray /* Size=0x12C0 */
{
    /* 0x0000 */ __int32 Length;
    /*        */ byte _gap_0x4[0x4];
    /* 0x0008 */ __int64 Objects[0x257];
};

struct Client::Game::Control::TargetSystem /* Size=0x52F0 */
{
    /*        */ byte _gap_0x0[0x80];
    /* 0x0080 */ Client::Game::Object::GameObject* Target;
    /* 0x0088 */ Client::Game::Object::GameObject* SoftTarget;
    /*        */ byte _gap_0x90[0x8];
    /* 0x0098 */ Client::Game::Object::GameObject* GPoseTarget;
    /*        */ byte _gap_0xA0[0x30];
    /* 0x00D0 */ Client::Game::Object::GameObject* MouseOverTarget;
    /*        */ byte _gap_0xD8[0x8];
    /* 0x00E0 */ Client::Game::Object::GameObject* MouseOverNameplateTarget;
    /*        */ byte _gap_0xE8[0x10];
    /* 0x00F8 */ Client::Game::Object::GameObject* FocusTarget;
    /*        */ byte _gap_0x100[0x10];
    /* 0x0110 */ Client::Game::Object::GameObject* PreviousTarget;
    /*        */ byte _gap_0x118[0x28];
    /* 0x0140 */ Client::Game::Object::GameObjectID TargetObjectId;
    /* 0x0148 */ Client::Game::Control::GameObjectArray ObjectFilterArray0;
    /*        */ byte _gap_0x1408[0x610];
    /* 0x1A18 */ Client::Game::Control::GameObjectArray ObjectFilterArray1;
    /* 0x2CD8 */ Client::Game::Control::GameObjectArray ObjectFilterArray2;
    /* 0x3F98 */ Client::Game::Control::GameObjectArray ObjectFilterArray3;
    /*        */ byte _gap_0x5258[0x98];
};

struct Client::Game::Control::Control /* Size=0x5A60 */
{
    /* 0x0000 */ Client::Game::Control::CameraManager CameraManager;
    /* 0x0180 */ Client::Game::Control::TargetSystem TargetSystem;
    /*        */ byte _gap_0x5470[0x5D8];
    /* 0x5A48 */ unsigned __int32 LocalPlayerObjectId;
    /*        */ byte _gap_0x5A4C[0x4];
    /* 0x5A50 */ Client::Game::Character::BattleChara* LocalPlayer;
    /*        */ byte _gap_0x5A58[0x8];
};

struct Client::Game::Control::InputManager /* Size=0x8 */
{
    /*     */ byte _gap_0x0[0x8];
};

struct Client::Game::Character::CharacterManager /* Size=0x338 */
{
    /* 0x000 */ __int64 BattleCharaArray[0x64];
    /* 0x320 */ Client::Game::Character::BattleChara* BattleCharaMemory;
    /* 0x328 */ Client::Game::Character::Companion* CompanionMemory;
    /* 0x330 */ __int32 CompanionClassSize;
    /* 0x334 */ __int32 UpdateIndex;
};

struct Client::Game::Character::Ornament /* Size=0x1B40 */
{
    /* 0x0000 */ Client::Game::Character::Character Character;
    /* 0x1B20 */ unsigned __int32 OrnamentId;
    /* 0x1B24 */ byte AttachmentPoint;
    /*        */ byte _gap_0x1B25;
    /*        */ byte _gap_0x1B26[0x2];
    /*        */ byte _gap_0x1B28[0x18];
};

struct Application::Network::WorkDefinitions::BeastReputationWork /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte Rank;
    /*      */ byte _gap_0x9;
    /* 0x0A */ unsigned __int16 Value;
    /*      */ byte _gap_0xC[0x4];
};

struct Application::Network::WorkDefinitions::DailyQuestWork /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ unsigned __int16 QuestId;
    /* 0x0A */ byte Flags;
    /*      */ byte _gap_0xB;
    /*      */ byte _gap_0xC[0x4];
};

struct Application::Network::WorkDefinitions::LeveWork /* Size=0x18 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ unsigned __int16 LeveId;
    /* 0x0A */ byte Sequence;
    /*      */ byte _gap_0xB;
    /* 0x0C */ unsigned __int16 Flags;
    /* 0x0E */ unsigned __int16 LeveSeed;
    /* 0x10 */ byte ClearClass;
    /*      */ byte _gap_0x11;
    /*      */ byte _gap_0x12[0x2];
    /*      */ byte _gap_0x14[0x4];
};

struct Application::Network::WorkDefinitions::QuestWork /* Size=0x18 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ unsigned __int16 QuestId;
    /* 0x0A */ byte Sequence;
    /* 0x0B */ byte Flags;
    /* 0x0C */ byte Variables[0x6];
    /* 0x12 */ byte AcceptClassJob;
    /*      */ byte _gap_0x13;
    /*      */ byte _gap_0x14[0x4];
};

struct Application::Network::WorkDefinitions::TrackingWork /* Size=0x10 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ byte QuestType;
    /* 0x09 */ byte Index;
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC[0x4];
};

struct Component::GUI::AtkLinkedList::Node; /* Size=unknown due to generic type with parameters */
enum AtkTooltipType: byte
{
    Text = 1,
    Item = 2,
    TextItem = 3,
    Action = 4
};

struct Component::GUI::AtkTooltipManager::AtkTooltipArgs /* Size=0x18 */
{
    /* 0x00 */ byte* Text;
    /* 0x08 */ unsigned __int64 TypeSpecificID;
    /* 0x10 */ unsigned __int32 Flags;
    /* 0x14 */ __int16 Unk_14;
    /* 0x16 */ byte Unk_16;
    /*      */ byte _gap_0x17;
};

struct Component::GUI::AtkTooltipManager::AtkTooltipInfo /* Size=0x20 */
{
    /* 0x00 */ Component::GUI::AtkTooltipManager::AtkTooltipArgs AtkTooltipArgs;
    /* 0x18 */ unsigned __int16 ParentID;
    /* 0x1A */ Component::GUI::AtkTooltipManager::AtkTooltipType Type;
    /*      */ byte _gap_0x1B;
    /*      */ byte _gap_0x1C[0x4];
};

struct Component::GUI::AtkUldManager::DuplicateObjectList /* Size=0x10 */
{
    /* 0x00 */ Component::GUI::AtkComponentNode* NodeList;
    /* 0x08 */ unsigned __int32 NodeCount;
    /*      */ byte _gap_0xC[0x4];
};

struct Client::UI::AddonContentsFinder::AddonContentsFinderVTable /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

struct Client::UI::AddonContentsFinderConfirm::AddonContentsFinderConfirmVTable /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

struct Client::UI::AddonNeedGreed::LootItemInfo /* Size=0x28 */
{
    /* 0x00 */ unsigned __int32 ItemId;
    /*      */ byte _gap_0x4[0x4];
    /*      */ byte _gap_0x8[0x20];
};

struct Client::UI::AddonRaceChocoboResult::AddonRaceChocoboResultVTable /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

struct Client::UI::AddonRetainerItemTransferList::AddonRetainerItemTransferListVTable /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

struct Client::UI::AddonRetainerItemTransferProgress::AddonRetainerItemTransferProgressVTable /* Size=0x1 */
{
    /*     */ byte _gap_0x0;
};

struct Client::UI::AddonSalvageItemSelector::SalvageItem /* Size=0x30 */
{
    /* 0x00 */ Client::Game::InventoryType Inventory;
    /* 0x04 */ __int32 Slot;
    /* 0x08 */ unsigned __int32 IconId;
    /*      */ byte _gap_0xC[0x4];
    /* 0x10 */ byte* NamePtr;
    /* 0x18 */ unsigned __int32 Quantity;
    /* 0x1C */ unsigned __int32 JobIconID;
    /* 0x20 */ byte* JobNamePtr;
    /* 0x28 */ byte Unknown28;
    /*      */ byte _gap_0x29;
    /*      */ byte _gap_0x2A[0x2];
    /*      */ byte _gap_0x2C[0x4];
};

struct Client::UI::RaptureAtkModule::NamePlateInfo /* Size=0x248 */
{
    /* 0x000 */ Client::Game::Object::GameObjectID ObjectID;
    /*       */ byte _gap_0x8[0x28];
    /* 0x030 */ Client::System::String::Utf8String Name;
    /* 0x098 */ Client::System::String::Utf8String FcName;
    /* 0x100 */ Client::System::String::Utf8String Title;
    /* 0x168 */ Client::System::String::Utf8String DisplayTitle;
    /* 0x1D0 */ Client::System::String::Utf8String LevelText;
    /*       */ byte _gap_0x238[0x8];
    /* 0x240 */ __int32 Flags;
    /*       */ byte _gap_0x244[0x4];
};

struct Client::UI::UI3DModule::MemberInfo /* Size=0x28 */
{
    /* 0x00 */ Client::UI::UI3DModule::MapInfo MapInfo;
    /* 0x18 */ Client::Game::Character::BattleChara* BattleChara;
    /* 0x20 */ byte Unk_20;
    /*      */ byte _gap_0x21;
    /*      */ byte _gap_0x22[0x2];
    /*      */ byte _gap_0x24[0x4];
};

struct Client::UI::UI3DModule::UnkInfo /* Size=0x40 */
{
    /* 0x00 */ Client::UI::UI3DModule::MapInfo MapInfo;
    /*      */ byte _gap_0x18[0x28];
};

enum UiFlags: __int32
{
    Shortcuts = 1,
    Hud = 2,
    Nameplates = 4,
    Chat = 8,
    ActionBars = 16,
    Unk32 = 32,
    TargetInfo = 64
};

struct Client::UI::Misc::ConfigModule::Option /* Size=0x20 */
{
    /* 0x00 */ void* Unk00;
    /* 0x08 */ unsigned __int64 Unk08;
    /* 0x10 */ Client::UI::Misc::ConfigOption OptionID;
    /*      */ byte _gap_0x12[0x2];
    /* 0x14 */ unsigned __int32 Unk14;
    /* 0x18 */ unsigned __int32 Unk18;
    /* 0x1C */ unsigned __int16 Unk1C;
    /*      */ byte _gap_0x1E[0x2];
};

enum GearsetFlag: byte
{
    None = 0,
    Exists = 1,
    Unknown02 = 2,
    Unknown04 = 4,
    HeadgearVisible = 8,
    WeaponsVisible = 16,
    VisorEnabled = 32,
    Unknown40 = 64,
    Unknown80 = 128
};

struct Client::UI::Misc::RaptureGearsetModule::GearsetItem /* Size=0x1C */
{
    /* 0x00 */ unsigned __int32 ItemID;
    /* 0x04 */ unsigned __int32 GlamourId;
    /* 0x08 */ byte Stain;
    /*      */ byte _gap_0x9;
    /* 0x0A */ unsigned __int16 Materia[0x5];
    /* 0x14 */ byte MateriaGrade[0x5];
    /*      */ byte _gap_0x19;
    /*      */ byte _gap_0x1A[0x2];
};

struct Client::UI::Misc::RaptureGearsetModule::GearsetEntry /* Size=0x1C0 */
{
    /* 0x000 */ byte ID;
    /* 0x001 */ byte Name[0x2F];
    /*       */ byte _gap_0x30;
    /* 0x031 */ byte ClassJob;
    /* 0x032 */ byte GlamourSetLink;
    /*       */ byte _gap_0x33;
    /* 0x034 */ __int16 ItemLevel;
    /*       */ byte _gap_0x36;
    /* 0x037 */ Client::UI::Misc::RaptureGearsetModule::GearsetFlag Flags;
    union {
    /* 0x038 */ byte ItemsData[0x188];
    /* 0x038 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem MainHand;
    } _union_0x38;
    /*       */ byte _gap_0x40[0x10];
    /*       */ byte _gap_0x50[0x4];
    /* 0x054 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem OffHand;
    /* 0x070 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem Head;
    /* 0x08C */ Client::UI::Misc::RaptureGearsetModule::GearsetItem Body;
    /* 0x0A8 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem Hands;
    /* 0x0C4 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem Belt;
    /* 0x0E0 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem Legs;
    /* 0x0FC */ Client::UI::Misc::RaptureGearsetModule::GearsetItem Feet;
    /* 0x118 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem Ears;
    /* 0x134 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem Neck;
    /* 0x150 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem Wrists;
    /* 0x16C */ Client::UI::Misc::RaptureGearsetModule::GearsetItem RingRight;
    /* 0x188 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem RightLeft;
    /* 0x1A4 */ Client::UI::Misc::RaptureGearsetModule::GearsetItem SoulStone;
};

struct Client::UI::Misc::SavedHotBars::SavedHotBarClassJobBars /* Size=0x5A0 */
{
    /*       */ byte _gap_0x0[0x5A0];
};

struct Client::UI::Misc::SavedHotBars::SavedHotBarClassJob /* Size=0x5A0 */
{
    /* 0x000 */ Client::UI::Misc::SavedHotBars::SavedHotBarClassJobBars Bar;
};

struct Client::UI::Misc::SavedHotBars::SavedHotBarClassJobSlots /* Size=0x50 */
{
    /*      */ byte _gap_0x0[0x50];
};

struct Client::UI::Misc::RaptureMacroModule::Macro::Lines /* Size=0x618 */
{
    /*       */ byte _gap_0x0[0x618];
};

struct Client::UI::Misc::RaptureMacroModule::Macro /* Size=0x688 */
{
    /* 0x000 */ unsigned __int32 IconId;
    /* 0x004 */ unsigned __int32 Unk;
    /* 0x008 */ Client::System::String::Utf8String Name;
    /* 0x070 */ Client::UI::Misc::RaptureMacroModule::Macro::Lines Line;
};

struct Client::UI::Misc::RetainerCommentModule::RetainerComment /* Size=0x68 */
{
    /* 0x00 */ unsigned __int64 ID;
    /*      */ byte _gap_0x8[0x60];
};

struct Client::UI::Info::InfoProxyCircle::Unk1 /* Size=0xF0 */
{
    /* 0x00 */ Client::System::String::Utf8String String0;
    /*      */ byte _gap_0x68[0x18];
    /* 0x80 */ Client::System::String::Utf8String String1;
    /*      */ byte _gap_0xE8[0x8];
};

struct Client::UI::Info::InfoProxyCommonList::CharacterDict /* Size=0x2000 */
{
    /* 0x0000 */ byte Entries[0x2000];
};

struct Client::UI::Info::InfoProxyCommonList::CharacterArray /* Size=0x4B00 */
{
    /* 0x0000 */ byte Entries[0x4B00];
};

struct Client::UI::Info::InfoProxyCrossWorldLinkShell::CWLSEntry /* Size=0x88 */
{
    /* 0x00 */ Client::System::String::Utf8String Name;
    /*      */ byte _gap_0x68[0x10];
    /* 0x78 */ unsigned __int32 FoundationTime;
    /*      */ byte _gap_0x7C[0x4];
    /*      */ byte _gap_0x80[0x4];
    /* 0x84 */ unsigned __int16 MembershipType;
    /*      */ byte _gap_0x86[0x2];
};

struct Client::UI::Info::InfoProxyFreeCompany::RankData /* Size=0x58 */
{
    /* 0x00 */ byte Permissions[0xA];
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC[0x4];
    /*      */ byte _gap_0x10[0x10];
    /* 0x20 */ unsigned __int16 MemberCount;
    /* 0x22 */ byte RankNumber;
    /* 0x23 */ byte Name[0x10];
    /*      */ byte _gap_0x33;
    /*      */ byte _gap_0x34[0x4];
    /*      */ byte _gap_0x38[0x20];
};

struct Client::UI::Info::InfoProxyFriendList::StrBuf /* Size=0x40 */
{
    /* 0x00 */ byte Data[0x40];
};

struct Client::UI::Info::InfoProxyItemSearch::Entry /* Size=0x8 */
{
    /* 0x0 */ unsigned __int32 ItemID;
    /* 0x4 */ unsigned __int32 Count;
};

struct Client::UI::Info::InfoProxyLetter::Letter /* Size=0xA0 */
{
    /* 0x00 */ __int64 SenderContentID;
    /* 0x08 */ unsigned __int32 Timestamp;
    /* 0x0C */ byte Attachments[0x28];
    /*      */ byte _gap_0x34[0x4];
    /* 0x38 */ unsigned __int32 Gil;
    /* 0x3C */ bool Read;
    /*      */ byte _gap_0x3D;
    /*      */ byte _gap_0x3E;
    /* 0x3F */ byte Sender[0x20];
    /* 0x5F */ byte MessagePreview[0x40];
    /*      */ byte _gap_0x9F;
};

struct Client::UI::Info::InfoProxyLinkShell::Entry /* Size=0x18 */
{
    /*      */ byte _gap_0x0[0x18];
};

enum IconFlagsTopRight: __int32
{
    None = 0,
    Dyeable = 1,
    Glamoured = 4
};

enum ItemDataFlags: __int32
{
    None = 0,
    Filled = 8
};

enum ReadyCheckStatus: byte
{
    Unknown = 0,
    AwaitingResponse = 1,
    Ready = 2,
    NotReady = 3,
    MemberNotPresent = 4
};

struct Client::UI::Agent::AgentReadyCheck::ReadyCheckEntry /* Size=0x10 */
{
    /* 0x00 */ __int64 ContentID;
    /* 0x08 */ Client::UI::Agent::AgentReadyCheck::ReadyCheckStatus Status;
    /*      */ byte _gap_0x9;
    /*      */ byte _gap_0xA[0x2];
    /*      */ byte _gap_0xC[0x4];
};

struct Client::UI::Agent::AgentRetainerItemTransferData::DuplicateItemEntry /* Size=0x78 */
{
    /* 0x00 */ Client::System::String::Utf8String Name;
    /* 0x68 */ bool Exists;
    /*      */ byte _gap_0x69;
    /*      */ byte _gap_0x6A[0x2];
    /* 0x6C */ bool IsEnabled;
    /*      */ byte _gap_0x6D;
    /*      */ byte _gap_0x6E[0x2];
    /* 0x70 */ unsigned __int32 ItemId;
    /* 0x74 */ unsigned __int32 UiCategoryIconId;
};

struct Client::UI::Agent::AgentSatisfactionSupply::ItemInfo /* Size=0x3C */
{
    /* 0x00 */ unsigned __int32 Id;
    /* 0x04 */ unsigned __int16 Collectability1;
    /* 0x06 */ unsigned __int16 Collectability2;
    /* 0x08 */ unsigned __int16 Collectability3;
    /* 0x0A */ unsigned __int16 Bonus;
    /* 0x0C */ unsigned __int32 Reward1Id;
    /* 0x10 */ unsigned __int32 Reward2Id;
    /*      */ byte _gap_0x14[0x4];
    /*      */ byte _gap_0x18[0x20];
    /* 0x38 */ unsigned __int16 FishingSpotId;
    /* 0x3A */ unsigned __int16 SpearFishingSpotId;
};

enum ModelType: byte
{
    Human = 1,
    DemiHuman = 2,
    Monster = 3,
    Weapon = 4
};

enum RenderViews: unsigned __int32
{
    OmniShadow0 = 0,
    OmniShadow1 = 1,
    OmniShadow2 = 2,
    OmniShadow3 = 3,
    OmniShadow4 = 4,
    OmniShadow5 = 5,
    OmniShadow6 = 6,
    OmniShadow7 = 7,
    OmniShadow8 = 8,
    OmniShadow9 = 9,
    OmniShadow10 = 10,
    OmniShadow11 = 11,
    OmniShadow12 = 12,
    OmniShadow13 = 13,
    OmniShadow14 = 14,
    OmniShadow15 = 15,
    OmniShadow16 = 16,
    OmniShadow17 = 17,
    OmniShadow18 = 18,
    OmniShadow19 = 19,
    OmniShadow20 = 20,
    OmniShadow21 = 21,
    OmniShadow22 = 22,
    OmniShadow23 = 23,
    Environment = 24,
    View25 = 25,
    OffscreenRenderer0 = 26,
    OffscreenRenderer1 = 27,
    OffscreenRenderer2 = 28,
    OffscreenRenderer3 = 29,
    Main = 30,
    Unused = 31
};

enum RenderSubViews: unsigned __int32
{
    Shadow0 = 0,
    Shadow1 = 1,
    Shadow2 = 2,
    Shadow3 = 3,
    Roof = 4,
    Cube1 = 5,
    Cube2 = 6,
    Cube3 = 7,
    Cube4 = 8,
    Cube5 = 9,
    OmniShadow0 = 10,
    OmniShadow1 = 11,
    OmniShadow2 = 12,
    OmniShadow3 = 13,
    Shadow = 14,
    Main = 15,
    Query = 16,
    Hud = 17
};

struct Client::Game::UI::Map::MapMarkerInfo /* Size=0x90 */
{
    /*      */ byte _gap_0x0[0x4];
    /* 0x04 */ unsigned __int32 QuestID;
    /* 0x08 */ Client::System::String::Utf8String Name;
    /*      */ byte _gap_0x70[0x18];
    /* 0x88 */ unsigned __int16 RecommendedLevel;
    /*      */ byte _gap_0x8A;
    /* 0x8B */ byte ShouldRender;
    /*      */ byte _gap_0x8C[0x4];
};

struct Client::Game::UI::MobHunt::KillCounts /* Size=0x14 */
{
    /* 0x00 */ __int32 Counts[0x5];
};

enum WeeklyBingoTaskStatus: __int32
{
    Open = 0,
    Claimable = 1,
    Claimed = 2
};

struct Client::Game::InstanceContent::InstanceContentDeepDungeon::DeepDungeonPartyInfo /* Size=0x8 */
{
    /* 0x0 */ unsigned __int32 ObjectId;
    /* 0x4 */ signed __int8 RoomIndex;
    /*     */ byte _gap_0x5;
    /*     */ byte _gap_0x6[0x2];
};

struct Client::Game::InstanceContent::InstanceContentDeepDungeon::DeepDungeonItemInfo /* Size=0x3 */
{
    /* 0x0 */ byte ItemId;
    /* 0x1 */ byte Count;
    /* 0x2 */ byte Flags;
};

struct Client::Game::InstanceContent::InstanceContentDeepDungeon::DeepDungeonChestInfo /* Size=0x2 */
{
    /* 0x0 */ byte ChestType;
    /* 0x1 */ signed __int8 RoomIndex;
};

struct Client::Game::Character::Character::OrnamentContainer /* Size=0x28 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ Client::Game::Character::BattleChara* OwnerObject;
    /* 0x10 */ Client::Game::Character::Ornament* OrnamentObject;
    /* 0x18 */ unsigned __int16 OrnamentId;
    /*      */ byte _gap_0x1A[0x2];
    /*      */ byte _gap_0x1C[0x4];
    /*      */ byte _gap_0x20[0x8];
};

enum CharacterModes: byte
{
    None = 0,
    Normal = 1,
    EmoteLoop = 3,
    Mounted = 4,
    AnimLock = 8,
    Carrying = 9,
    InPositionLoop = 11,
    Performance = 16
};

enum WeaponSlot: unsigned __int32
{
    MainHand = 0,
    OffHand = 1,
    Unk = 2
};

struct Client::UI::Misc::SavedHotBars::SavedHotBarClassJobBars::SavedHotBarClassJobBar /* Size=0x50 */
{
    /* 0x00 */ Client::UI::Misc::SavedHotBars::SavedHotBarClassJobSlots Slot;
};

struct Client::UI::Misc::SavedHotBars::SavedHotBarClassJobSlots::SavedHotBarClassJobSlot /* Size=0x5 */
{
    /* 0x0 */ Client::UI::Misc::HotbarSlotType Type;
    /* 0x1 */ unsigned __int32 ID;
};

struct Client::UI::Info::InfoProxyCommonList::CharacterDict::Entry /* Size=0x10 */
{
    /* 0x00 */ unsigned __int64 ContentID;
    /*      */ byte _gap_0x8[0x2];
    /* 0x0A */ unsigned __int16 HomeWorld;
    /*      */ byte _gap_0xC[0x4];
};

struct Client::UI::Info::InfoProxyCommonList::CharacterArray::Entry /* Size=0x60 */
{
    /* 0x00 */ unsigned __int64 ContentId;
    /*      */ byte _gap_0x8;
    /* 0x09 */ unsigned __int16 OnlineStatus;
    /* 0x0B */ byte MentorState;
    /* 0x0C */ byte PartyStatus;
    /* 0x0D */ byte DutyStatus;
    /*      */ byte _gap_0xE[0x2];
    /*      */ byte _gap_0x10[0x4];
    /* 0x14 */ byte DictIndex;
    /*      */ byte _gap_0x15;
    /* 0x16 */ unsigned __int16 CurrentWorld;
    /* 0x18 */ unsigned __int16 HomeWorld;
    /* 0x1A */ unsigned __int16 Location;
    /* 0x1C */ Client::UI::Agent::GrandCompany GrandCompany;
    /* 0x1D */ byte MainLanguage;
    /* 0x1E */ byte AvailableLanguages;
    /*      */ byte _gap_0x1F;
    /*      */ byte _gap_0x20;
    /* 0x21 */ byte Job;
    /* 0x22 */ byte Name[0x20];
    /* 0x42 */ byte FCTag[0x6];
    /*      */ byte _gap_0x48[0x18];
};

enum BasicSettings: unsigned __int16
{
    None = 0,
    CompanyProfile = 1,
    RankSettings = 4,
    CrestDetails = 8,
    Invitations = 32,
    Applications = 64,
    MemberDismissal = 128,
    PromotionDemotion = 256,
    CompanyBoard = 512,
    ShortMessage = 2048,
    CompanyCredists = 4096,
    ExecutingActions = 8192,
    DiscardingActions = 16384
};

enum ChestAccess: byte
{
    NoAccess = 1,
    ViewOnly = 2,
    FullAccess = 4,
    DepositOnly = 8
};

enum HousingAccess: unsigned __int32
{
    EstateHallAccess = 1,
    EstateRenameing = 2,
    GreetingCustomization = 4,
    PurchaseRelinquishLAnd = 8,
    HallConsructionRemoval = 16,
    HallRemodeling = 32,
    NoFurnishingPriv = 64,
    FurnishingPlacement = 128,
    FurnishingPlacementREmoval = 256,
    PaintFixturesFurnishings = 512,
    GuestAccess = 1024,
    MessageBook = 2048,
    Planting = 4096,
    Harvesting = 8192,
    CropDisposal = 16384,
    ChocoboStabling = 32768,
    TrainingChocobo = 65536,
    OrchestrionOperation = 131072
};

enum WorkshopAccess: unsigned __int16
{
    CosntructionRemoval = 1,
    ProjCommenceDisc = 2,
    ProjMatDelivery = 4,
    ProjectProgression = 8,
    ProjectItemCollection = 16,
    PrototypeCreation = 32,
    RegistrationDismantling = 64,
    Outfitting = 128,
    ColorCustomization = 256,
    Unk = 512,
    Renaming = 1024,
    VoyageDeploymentRecall = 2048,
    VoyageFinalization = 4096
};

struct Client::UI::Info::InfoProxyLetter::Letter::ItemAttachment /* Size=0x8 */
{
    /* 0x0 */ unsigned __int32 ItemID;
    /* 0x4 */ unsigned __int32 Count;
};

struct Client::UI::Agent::AgentBannerInterface::Storage::CharacterData /* Size=0x760 */
{
    /* 0x000 */ void** VTable;
    /*       */ byte _gap_0x8[0x10];
    /* 0x018 */ Client::System::String::Utf8String Name1;
    /* 0x080 */ Client::System::String::Utf8String Name2;
    /* 0x0E8 */ Client::System::String::Utf8String UnkString1;
    /* 0x150 */ Client::System::String::Utf8String UnkString2;
    /*       */ byte _gap_0x1B8[0x8];
    /* 0x1C0 */ Client::System::String::Utf8String Job;
    /*       */ byte _gap_0x228[0x10];
    /* 0x238 */ unsigned __int32 WorldId;
    /*       */ byte _gap_0x23C[0x4];
    /* 0x240 */ Client::System::String::Utf8String UnkString3;
    /*       */ byte _gap_0x2A8[0x8];
    /* 0x2B0 */ void* CharaView;
    /*       */ byte _gap_0x2B8[0x318];
    /* 0x5D0 */ Component::GUI::AtkTexture AtkTexture;
    /*       */ byte _gap_0x5E8[0xF8];
    /* 0x6E0 */ Client::System::String::Utf8String Title;
    /*       */ byte _gap_0x748[0x8];
    /* 0x750 */ void* SomePointer;
    /*       */ byte _gap_0x758[0x8];
};

struct Client::UI::Agent::AgentInspect::ItemData::ColorRGB /* Size=0x3 */
{
    /* 0x0 */ byte B;
    /* 0x1 */ byte G;
    /* 0x2 */ byte R;
};

enum QuestFlags: byte
{
    None = 0,
    Priority = 1,
    Hidden = 8
};

struct Client::Game::QuestManager::QuestListArray::Quest /* Size=0x18 */
{
    /*      */ byte _gap_0x0[0x8];
    /* 0x08 */ unsigned __int16 QuestID;
    /*      */ byte _gap_0xA;
    /* 0x0B */ Client::Game::QuestManager::QuestListArray::Quest::QuestFlags Flags;
    /*      */ byte _gap_0xC[0x4];
    /*      */ byte _gap_0x10[0x8];
};

