using FFXIVClientStructs.FFXIV.Client.Graphics.Kernel;
using FFXIVClientStructs.FFXIV.Client.UI.Misc;
using FFXIVClientStructs.FFXIV.Component.GUI;
using static FFXIVClientStructs.FFXIV.Client.UI.Misc.RaptureGearsetModule;
using static FFXIVClientStructs.FFXIV.Client.UI.RaptureAtkModule;

namespace FFXIVClientStructs.FFXIV.Client.UI.Agent;

// Client::UI::Agent::AgentGearSet
//   Client::UI::Agent::AgentInterface
//     Component::GUI::AtkModuleInterface::AtkEventInterface
[Agent(AgentId.GearSet)]
[GenerateInterop]
[Inherits<AgentInterface>]
[StructLayout(LayoutKind.Explicit, Size = 0xBD0)]
public unsafe partial struct AgentGearSet {
    [FieldOffset(0x48), FixedSizeArray] internal FixedSizeArray14<ContextMenuParam> _contextMenuParams;

    [FieldOffset(0x114)] public byte OpenChildAddonId;
    [FieldOffset(0x118)] public byte GearsetIdOfDisplayAddon;
    [FieldOffset(0x11C)] public byte GearsetIdOfPreviewAddon;
    [FieldOffset(0x120), FixedSizeArray] internal FixedSizeArray13<ItemCache> _itemCaches;

    [FieldOffset(0x880)] public GearsetCharaView CharaView;

    [FieldOffset(0xBB0)] public Texture* GearsetPreviewTexture; // populated when preview open
    [FieldOffset(0xBB8)] public StdVector<int> GearSetIds;
    
    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 48 8B F9 8B DA 48 8B 49 10 48 8B 01 FF 50 70 4C 8D 44 24")]
    public partial void OpenBannerEditorForGearset(int gearsetId);

    /// <summary>
    /// Reassigns a gearset's ID to a specified ID number.
    /// </summary>
    /// <param name="gearsetId">The ID of the gearset to be changed.</param>
    /// <param name="newGearsetId">The new ID of the gearset to be changed to.</param>
    /// <returns>Always <see langword="false" /></returns>
    /// <remarks>Wrapper to <see cref="RaptureGearsetModule.ReassignGearsetId"/> and <see cref="RaptureHotbarModule.ReassignGearsetId"/>. <br/> 
    /// Also pushes an update to the GearSetList addon.</remarks>
    [MemberFunction("E9 ?? ?? ?? ?? 48 FF C9 48 3B D1")]
    public partial bool ReassignGearsetId(int gearsetId, int newGearsetId);

    /// <summary>
    /// Moves the gearset up or down in the Gearset List.
    /// </summary>
    /// <param name="gearsetId">The ID of the gearset to be changed</param>
    /// <param name="direction"><see langword="true" /> if moving gearset up, <see langword="false" /> if moving gearset down</param>
    /// <returns>Always <see langword="false" /></returns>
    [MemberFunction("4C 8B D1 44 8B CA")]
    public partial bool MoveGearsetUpOrDown(int gearsetId, bool direction);

    /// <summary>
    /// Changes the gearset's name at the specified ID.
    /// </summary>
    /// <param name="gearsetId">The gearset ID to rename</param>
    /// <param name="newGearsetName">The name to change the specified gearset to</param>
    [MemberFunction("48 89 5C 24 ?? 55 56 57 48 81 EC ?? ?? ?? ?? 48 8B 05 ?? ?? ?? ?? 48 33 C4 48 89 84 24 ?? ?? ?? ?? 48 8B F1 49 8B F8"), GenerateStringOverloads]
    public partial bool RenameGearset(int gearsetId, CStringPointer newGearsetName);

    /// <summary>
    /// Update the gearset at the specified ID with the currently equipped items.
    /// </summary>
    /// <param name="gearsetId">The gearset ID to update</param>
    [MemberFunction("E9 ?? ?? ?? ?? 8B D7 48 8B CE E8 ?? ?? ?? ?? 48 8B 5C 24")]
    public partial bool UpdateGearsetInternal(int gearsetId); // TODO: replace existing UpdateGearset

    /// <summary>
    /// Opens the dialog for deleting a gearset for the specified ID
    /// </summary>
    /// <param name="gearsetId">The gearset ID to open the delete dialog to</param>
    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 E9 ?? ?? ?? ?? 48 8B 03 48 8B CB FF 50 ?? 48 8B C8 8B D7 E8 ?? ?? ?? ?? 48 8B 13")]
    public partial void OpenDeleteDialog(int gearsetId);

    /// <summary>
    /// Opens the dialog for updating a gearset for the specified ID
    /// </summary>
    /// <param name="gearsetId">The gearset ID to open the reassign dialog to</param>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B D6 48 8B CB E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 8B D6 48 8B CB E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 B0")]
    public partial void ReassignGear(int gearsetId);

    /// <summary>
    /// Opens the dialog for updating the ID of the specified gearset
    /// </summary>
    /// <param name="gearsetId">The gearset ID to open the reassign set number dialog to</param>
    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 41 B0 ?? 8B D6 48 8B CB")]
    public partial void ReassignSetNumber(int gearsetId);

    /// <summary>
    /// Updates the gearset at the specified ID if the ID is not empty, if it is empty, creates a new gearset
    /// </summary>
    /// <param name="gearsetId">The gearset ID to update gearset or create new</param>
    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 E9 ?? ?? ?? ?? 48 8B 03 48 8B CB FF 50 ?? 48 8B C8 8B D7 E8 ?? ?? ?? ?? 84 C0")]
    public partial void UpdateGearsetIfExistsOrCreateNew(int gearsetId);

    /// <summary>
    /// Creates a gearset at first empty ID
    /// </summary>
    /// <remarks> Calls <see cref="CreateGearset(int, bool)"/> with gearset ID of <c>0xFF</c> and createAtFirstEmpty of <c>true</c></remarks>
    [MemberFunction("48 83 EC ?? 41 B0 ?? BA ?? ?? ?? ?? E8")]
    public partial bool CreateGearsetInternal();

    /// <summary>
    /// Creates a gearset at specified gearset ID
    /// </summary>
    /// <param name="gearsetId">The gearset ID to create the gearset at</param>
    /// <param name="createAtFirstEmpty">Whether it is created at the first empty ID or at the gearset ID specified.</param>
    /// <returns>The gearset ID of the created gearset</returns>
    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 E9 ?? ?? ?? ?? 8B D7")]
    public partial int CreateGearset(int gearsetId, bool createAtFirstEmpty); // TODO: replace existing CreateGearset

    /// <summary>
    /// Deletes the gearset as the specified ID
    /// </summary>
    /// <param name="gearsetId">The gearset ID to be deleted</param>
    /// <remarks>
    /// Calls <see cref="RaptureGearsetModule.DeleteGearset(int)"/>, <see cref="RaptureHotbarModule.DeleteGearsetSlots(int)"/> and updates the addon.
    /// </remarks>
    [MemberFunction("40 56 41 54 41 56 48 83 EC ?? 48 8B 05")]
    public partial bool DeleteGearset(int gearsetId);

    /// <summary>
    /// Opens the gearset viewer for the specified gearset ID
    /// </summary>
    /// <param name="gearsetId">The gearset ID to open the gearset viewer for</param>
    [MemberFunction("E8 ?? ?? ?? ?? 33 C0 EB ?? 83 F8")]
    public partial void OpenGearsetViewer(int gearsetId);

    public void CreateGearset()
        => SendEvent(1);

    // public void OpenDeleteDialog(int gearsetId)
    //     => SendEvent(2, gearsetId);

    public void EquipGearset(int gearsetId)
        => SendEvent(4, gearsetId);

    // public void ReassignGear(int gearsetId)
    //     => SendEvent(6, gearsetId);

    //public void ReassignSetNumber(int gearsetId)
    //    => SendEvent(7, gearsetId);

    public void MoveSetUp(int gearsetId)
        => MoveGearsetUpOrDown(gearsetId, true);
    //    => SendEvent(8, gearsetId);

    public void MoveSetDown(int gearsetId)
        => MoveGearsetUpOrDown(gearsetId, false);
    //    => SendEvent(9, gearsetId);

    public void OpenRenameDialog(int gearsetId)
        => SendEvent(10, gearsetId);

    public void OpenGearsetItemList(int gearsetId)
        => SendEvent(11, gearsetId);

    public void OpenGearsetPreview(int gearsetId)
        => SendEvent(12, gearsetId);

    /// <remarks> Only works when Cross Hotbars are enabled. </remarks>
    public void SetToHotbar(int gearsetId)
        => SendEvent(13, gearsetId);

    public void UpdateGearset(int gearsetId)
        => SendEvent(16, gearsetId);

    public void LinkToGlamourPlate(int gearsetId)
        => SendEvent(20, gearsetId);

    public void ChangeGlamourPlateLink(int gearsetId)
        => SendEvent(21, gearsetId);

    public void RemoveGlamourPlateLink(int gearsetId)
        => SendEvent(22, gearsetId);

    public void EditPortrait(int gearsetId)
        => SendEvent(23, gearsetId);

    private void SendEvent(int evt, int gearsetId = 0) {
        var result = stackalloc AtkValue[1];
        var values = stackalloc AtkValue[2];
        values[0].SetInt(evt); // case
        values[1].SetInt(gearsetId); // optional gearsetId
        ReceiveEvent(result, values, 2, 0);
    }

    [StructLayout(LayoutKind.Explicit, Size = 0x0C)]
    public struct ContextMenuParam {
        [FieldOffset(0x00)] private int Unk0;
        [FieldOffset(0x04)] public int EventId;
        [FieldOffset(0x08)] public int GearSetId;
    }

    // Client::UI::Agent::AgentGearSet::GearsetCharaView
    //   Client::UI::Misc::CharaView
    [GenerateInterop]
    [Inherits<CharaView>]
    [StructLayout(LayoutKind.Explicit, Size = 0x330)]
    public unsafe partial struct GearsetCharaView {
        [FieldOffset(0x318)] public bool UpdateVisibility;
        [FieldOffset(0x319)] public bool UpdateItems;
        [FieldOffset(0x31A)] public bool HideVisor;
        [FieldOffset(0x31B)] public bool HideWeapon;
        [FieldOffset(0x31C)] public bool CloseVisor;
        [FieldOffset(0x31F)] public bool DrawWeapon;
        [FieldOffset(0x320)] public bool CharacterDisplayMode;

        [FieldOffset(0x328)] public GearsetEntry* Gearset;
    }
}
