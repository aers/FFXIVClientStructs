namespace FFXIVClientStructs.FFXIV.Client.Game;

// Client::Game::WeatherManager
/// <remarks>
/// The weather changes every 8 hours.
/// </remarks>
[StructLayout(LayoutKind.Explicit, Size = 0x70)]
public unsafe partial struct WeatherManager {
    [StaticAddress("48 8D 0D ?? ?? ?? ?? 44 0F B7 45", 3, true)]
    public static partial WeatherManager* Instance();

    /// <summary>
    /// Checks if the specified TerritoryType has individual weather.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 44 0F B6 F0 48 8D 73 04")]
    public partial bool HasIndividualWeather(ushort territoryTypeId);

    /// <summary>
    /// Gets the IndividualWeather id for the specified TerritoryType, if it has one.
    /// </summary>
    [MemberFunction("E8 ?? ?? ?? ?? 0F B6 C0 33 DB")]
    public partial byte GetIndividualWeather(ushort territoryTypeId);

    /// <summary>
    /// Gets the Weather id for the specified TerritoryType and hour.
    /// </summary>
    /// <param name="territoryTypeId"> The id of the TerritoryType to check the weather for. </param>
    /// <param name="hourOffset"> An hour offset. (0 = Now, 8 = some time after the next weather change) </param>
    /// <returns> The id of a row in the Weather sheet. </returns>
    [MemberFunction("40 57 48 83 EC 20 0F B7 CA")]
    public partial byte GetWeatherForHour(ushort territoryTypeId, int hourOffset);

    /// <summary>
    /// Gets the Weather id for the specified TerritoryType and daytime.
    /// </summary>
    /// <param name="territoryTypeId"> The id of the TerritoryType to check the weather for. </param>
    /// <param name="daytimeOffset">
    /// A daytime offset.<br/>
    /// 0 = Now<br/>
    /// 1 = In 8 hours (some time after the next weather change)<br/>
    /// 2 = In 16 hours<br/>
    /// 3 = In 24 hours
    /// </param>
    /// <remarks> All this function does, is to call <see cref="GetWeatherForHour"/> with daytimeIndex * 8 as offset. </remarks>
    /// <returns> The id of a row in the Weather sheet. </returns>
    [MemberFunction("46 8D 04 C5 ?? ?? ?? ?? E9")]
    public partial byte GetWeatherForDaytime(ushort territoryTypeId, int daytimeOffset);
}
