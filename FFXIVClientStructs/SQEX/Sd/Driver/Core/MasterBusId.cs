namespace FFXIVClientStructs.SQEX.Sd.Driver.Core;

/// <summary> The ids of the <see cref="CoreMasterVoice"/>s of the software mixer, the names are the ones the game gives them. </summary>
public enum MasterBusId {
    /// <summary> "Master bed". </summary>
    Bed = 2,

    /// <summary> "Master ambisonics", the Premaster submix sends its output here. </summary>
    Ambisonics = 4,

    /// <summary> "Master pad speaker". </summary>
    PadSpeaker = 8,

    /// <summary> "Master pad vibration". </summary>
    PadVibration = 128,

    /// <summary> "Master pad". </summary>
    Pad = 2049,
}
