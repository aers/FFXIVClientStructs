namespace FFXIVClientStructs.STD;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public unsafe struct Tm {
    public int tm_sec;
    public int tm_min;
    public int tm_hour;
    public int tm_mday;
    public int tm_mon;
    public int tm_year;
    public int tm_wday;
    public int tm_yday;
    public int tm_isdst;

    public void Reset() {
        tm_sec = 0;
        tm_min = 0;
        tm_hour = 0;
        tm_mday = 0;
        tm_mon = 0;
        tm_year = 0;
        tm_wday = 0;
        tm_yday = 0;
        tm_isdst = 0;
    }

    public void SetTime(DateTime dateTime) {
        tm_sec = dateTime.Second;
        tm_min = dateTime.Minute;
        tm_hour = dateTime.Hour;
        tm_mday = dateTime.Day;
        tm_mon = dateTime.Month - 1;
        tm_year = dateTime.Year - 1900;
        tm_wday = (int)dateTime.DayOfWeek;
        tm_yday = dateTime.DayOfYear - 1;
        tm_isdst = dateTime.IsDaylightSavingTime() ? 1 : 0;
    }

    public void SetTime(int timestamp)
        => SetTime(DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime);

    public DateTime AsDateTime()
        => new(
            tm_year + 1900,
            tm_mon + 1,
            tm_mday,
            tm_hour,
            tm_min,
            tm_sec
        );
}
