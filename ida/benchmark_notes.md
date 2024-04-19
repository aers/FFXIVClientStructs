# Notes

## VTableAddressAttribute offset changes

- `Client.UI.RaptureAtkModule`: 5 => 3
- `Client.Game.Control.GazeController`: 4 => 3
- `Client.Game.Control.GazeController+Gaze+TargetInformation`: 6 => 3

## StaticAddressAttribute offset changes

- `Client.Game.Control.InputManager.GetMouseButtonHoldState`: 2 => 4
- `Client.UI.Agent.CharaSelectCharacterList.GetCurrentCharacter`: 3 => 5
- `Client.System.Framework.Framework.Instance`: 7 => 6
- `Client.Game.UI.RouletteController.Instance`: 3 => 6
- `Client.Game.MirageManager.Instance`: 3 => 5

## UIModule vfunc shifts

```yaml
# 41: some new helper?!
42: GetEmoteHistoryModule
43: GetMinionListModule
44: GetMountListModule
45: GetEmjModule
46: GetAozNoteModule
47: GetCrossWorldLinkShellModule
48: GetAchievementListModule
49: GetGroupPoseModule
50: GetFieldMarkerModule
51: GetUnkFieldMarkerModuleMap
52: GetMycNoteModule
53: GetOrnamentListModule
54: GetMycItemModule
55: GetGroupPoseStampModule
56: GetInputTimerModule
57: GetMcAggreModule
58: GetRetainerCommentModule
59: GetBannerModule
60: GetAdventureNoteModule
61: GetAkatsukiNoteModule
62: GetVVDNoteModule
63: GetVVDActionModule
64: GetTofuModule
65: GetFishingModule
66: GetUIInputData
67: GetUIInputModule
69: GetLogFilterConfig
71: EnableCutsceneInputMode
72: DisableCutsceneInputMode
77: EnterGPose
78: ExitGPose
79: IsInGPose
80: EnterIdleCam
81: ExitIdleCam
82: IsInIdleCam
88: ShowDeepDungeonHud
89: HideDeepDungeonHud
91: ShowEurekaHud
92: HideEurekaHud
98: OpenMycInfo
99: CloseMycInfo
100: CloseMiniMap
101: OpenMiniMap
102: IsGamePadInputActive
105: ToggleInputMode
107: IsUIHidden
108: AddAtkHistoryEntry
109: ClearAtkHistory
113: ShowContentIntroduction
114: IsContentIntroductionInvisible
115: HideContentIntroduction
124: SetCursorVisibility
125: ToggleCursor
139: ShowEventFadeIn
140: ShowEventFadeOut
144: ToggleUi
145: ToggleUi_2
147: LoadScreenHideUi
148: LoadScreenShowUi
150: AnnounceHowTo
152: HideHowTo
154: ShowGoldSaucerReward
155: HideGoldSaucerReward
156: ShowTextRelicAtma
158: HideGoldSaucerReward_2
164: ShowHousingHarvest
166: OpenMiniGame
167: HideHousingHarvest
168: ShowImage
169: ShowText
170: ShowTextChain
171: ShowWideText
172: ShowPoisonText
173: ShowErrorText
174: ShowTextClassChange
175: ShowGetAction
176: ShowLocationTitle
177: HideLocationTitle
180: ShowGrandCompany1
183: ShowStreak
184: ShowAddonKillStreakForManeuvers
185: ShowBaloonMessage
186: ShowBattleTalk
187: ShowBattleTalkImage
188: ShowBattleTalkUnknown
189: ShowBattleTalkSound
191: OpenInventory
192: CloseInventory
193: IsInventoryOpen
194: ExecuteMainCommand
195: IsMainCommandUnlocked
198: ShowRaceCountdownEnd
202: IsDutyRaidFinderOpen
229: ShowRaceCountdownStart
230: ShowRaceCountdownEnd_2
# 234: new vfunc
```

## EventSceneModuleImplBase vfunc shifts

```yaml
154: PlayBGMWithVolume # new
155: StopBGM
156: InvisibleStandCharacter
157: InvisibleStandObject
158: RevisibleStandObject
159: DOF
160: DisableDOF
161: ColorFilter
162: DisableColorFilter
163: Vignetting
164: DisableVignetting
165: Weather
166: WorldTime
167: GetHouseSize
168: PlayHousingCamera
169: WaitForFeedBuddy
170: WaitForIdleCamera
171: GroupPose
172: PlayEventVfx
173: StopEventVfx
174: KickTriggerEventVfx
175: WhiteFadeIn
176: WhiteFadeOut
177: WaitForWhiteFade
178: PlayTargetAimingCamera
179: PlayDirectionalAimingCamera
180: StopAimingCamera
181: Position
182: PositionCamera
183: ResetPosition
184: Visible
185: Direction
186: Distance
187: PlayActionTimeline
188: CancelActionTimeline
189: CancelActionTimelineAll
190: WaitForActionTimeline
191: PlayEmote
192: CancelEmote
193: WaitForEmote
194: TurnTo
195: TurnToObject
196: TurnToLayout
197: TurnToCamera
198: TurnToDefault
199: WaitForTurn
200: Idle
201: LookAt
202: LookAtLayout
203: LookAtCamera
204: LookAtDefault
205: WaitForLookAt
206: EyeLookAt
207: EyeLookAtYawPitch
208: Move
209: WaitForMove
210: PathMove
211: WaitForPathMove
212: FootStep
213: EndEventRollback
214: PlayVfx
216: EnableVfx
217: DisableVfx
218: Transparency
219: WaitForTransparency
220: WalkIn
221: WalkOut
222: PathWalkIn
223: PathWalkOut
224: PathCurveWalkOut # new
225: FlyIn # also "SwimIn"
226: FlyOut # also "SwimOut"
227: BattleMode
228: BattleModeEx
229: EquipWeapon
230: EquipArmor
231: Equip
232: EquipQuestModel
233: AutoShake
234: AutoShakeBugFix236127
235: SetMount
236: SetFlying
237: IsSwimming
238: SetLodHigh
239: SetGlassesAccessories # new
240: IsItemObtainable
241: CheckItemsObtainable
242: CheckItemsObtainableRareCheck
```

### Function changes

#### Client.Game.InventoryItem::GetStain

```diff
-byte GetStain(Client::Game::InventoryItem* this);
+byte GetStain(Client::Game::InventoryItem* this, int index);
```

#### Client.UI.Info.InfoProxyItemSearch::ProcessItemHistory

```diff
-void ProcessItemHistory(Client::UI::Info::InfoProxyItemSearch* a1, nint a2, unsigned __int32 a3);
+void ProcessItemHistory(Client::UI::Info::InfoProxyItemSearch* this, nint packet);
```
