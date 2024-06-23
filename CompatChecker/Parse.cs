using System.ComponentModel;
using System.Drawing;
using Pastel;

namespace CompatChecker;

/* Breaking changes has the format of 
CP0002: Member 'long FFXIVClientStructs.FFXIV.Client.Game.Object.GameObjectManager.<ObjectList3>e__FixedBuffer.FixedElementField' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0002: Member 'long FFXIVClientStructs.FFXIV.Client.Game.Object.GameObjectManager.<ObjectList>e__FixedBuffer.FixedElementField' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0002: Member 'long FFXIVClientStructs.FFXIV.Client.Game.Object.GameObjectManager.<ObjectListFiltered>e__FixedBuffer.FixedElementField' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0001: Type 'FFXIVClientStructs.STD.StdList<T>.Node' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0002: Member 'FFXIVClientStructs.STD.StdList<T>.Node* FFXIVClientStructs.STD.StdList<T>.Head' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0002: Member 'ulong FFXIVClientStructs.STD.StdList<T>.Size' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0001: Type 'FFXIVClientStructs.STD.StdMap<TKey, TValue>.Enumerator' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0001: Type 'FFXIVClientStructs.STD.StdMap<TKey, TValue>.Node' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0002: Member 'FFXIVClientStructs.STD.StdMap<TKey, TValue>.Node* FFXIVClientStructs.STD.StdMap<TKey, TValue>.Head' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0002: Member 'ulong FFXIVClientStructs.STD.StdMap<TKey, TValue>.Count' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0002: Member 'FFXIVClientStructs.STD.StdMap<TKey, TValue>.Node* FFXIVClientStructs.STD.StdMap<TKey, TValue>.SmallestValue.get' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0002: Member 'FFXIVClientStructs.STD.StdMap<TKey, TValue>.Node* FFXIVClientStructs.STD.StdMap<TKey, TValue>.LargestValue.get' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0002: Member 'FFXIVClientStructs.STD.StdMap<TKey, TValue>.Enumerator FFXIVClientStructs.STD.StdMap<TKey, TValue>.GetEnumerator()' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0001: Type 'FFXIVClientStructs.STD.StdSet<TKey>' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0002: Member 'System.ReadOnlySpan<byte> FFXIVClientStructs.STD.StdString.AsSpan()' exists on ida/cs-main/FFXIVClientStructs.dll but not on ida/cs-pr/FFXIVClientStructs.dll
CP0007: Type 'FFXIVClientStructs.FFXIV.Component.SteamApi.SteamTypes' does not inherit from base type 'System.Object' on D:\source\repos\dotnet-compat-checker\test_files\fail\FFXIVClientStructs-pr.dll but it does on D:\source\repos\dotnet-compat-checker\test_files\fail\FFXIVClientStructs-main.dll
 */
internal class Parse {
    public static ChangeType? ParseBreakingChange(string line) {
        if (line.Contains("e__FixedBuffer")) return null;
        var parts = line.Split(": ");
        var code = Enum.Parse<Code>(parts[0]);
        var type = Enum.Parse<Type>(parts[1].Split(' ')[0]);
        var message = parts[1][parts[1].IndexOf(' ')..].Trim();
        var change = message[..message.IndexOf(" on", StringComparison.Ordinal)];
        message = message[change.Length..].Trim();
        change = change.Replace("'", "").Replace("exists", "").Replace(", ", ",").Trim();

        return code switch {
            Code.CP0002 => ParseMember(code, type, change, message),
            Code.CP0007 => ParseNotInherit(code, type, change, message),
            Code.CP0001 => new ChangeType(code, type, new Change(null, GetLocation(change)), message),
            _ => new ChangeType(code, type, new Change(change), message)
        };

    }

    public static Location GetLocation(string location) {
        var count = location.IndexOf('(');
        string @namespace;
        string @class;
        if ((count == -1 ? location : location[..count]).Count(f => f == '.') == 1) {
            @namespace = location[..location.IndexOf('.')];
            @class = location[location.IndexOf('.')..];
            return new Location(@namespace.Trim('.').Replace(",", ", "), @class.Trim('.').Replace(",", ", "));
        }
        var field = count == -1 ? location[location.LastIndexOf('.')..] : location[location[..count].LastIndexOf('.')..];
        @namespace = count == -1 ? location[..location.LastIndexOf('.')] : location[..location[..count].LastIndexOf('.')];
        @class = @namespace[@namespace.LastIndexOf('.')..];
        @namespace = @namespace[..@namespace.LastIndexOf('.')];
        return new Location(@namespace.Trim('.').Replace(",", ", "), @class.Trim('.').Replace(",", ", "), field.Trim('.').Replace(",", ", "));
    }

    public static ChangeType ParseMember(Code code, Type type, string change, string message) {
        var count = change.IndexOf('(');
        var lastSpace = count == -1 ? change.LastIndexOf(' ') : change[..count].LastIndexOf(' ');
        var location = change[lastSpace..].Trim().Replace(".get", "");
        return new ChangeType(code, type, new Change(change[..lastSpace].Trim(), GetLocation(location)), message);
    }

    public static ChangeType ParseNotInherit(Code code, Type type, string change, string message) {
        var main = change[..change.IndexOf(' ')].Trim();
        var parent = change[change.LastIndexOf(' ')..].Trim();
        return new ChangeType(code, type, new Change(null, GetLocation(main), GetLocation(parent)), message);
    }
}

public enum Code {
    [Description("Type exists in left but not in right")]
    CP0001,
    [Description("Member exists in left but not in right")]
    CP0002,
    CP0003,
    CP0004,
    CP0005,
    CP0006,
    [Description("Type does not inherit from base type")]
    CP0007,
    CP0008,
    CP0009,
    CP0010,
    CP0011,
    CP0012,
    CP0013,
    CP0014,
    CP0015,
    CP0016,
    CP0017,
    CP0018,
    CP0019,
    CP0020
}

public enum Type {
    Type,
    Member
}

public record ChangeType(Code Code, Type Type, Change Change, string Message);

public record Change(string? Type, Location? Main = null, Location? Parent = null) {
    public override string ToString() => string.IsNullOrWhiteSpace(Type)
        ?
        $"{Main?.ToString() ?? ""} {(Parent != null ? $"does not inherit {Parent}" : "")}".Trim()
        :
        $"{Type.Pastel(Color.DarkMagenta)} {Main?.ToString() ?? ""} {(Parent != null ? $"does not inherit {Parent}" : "")}".Trim();
}

public record Location(string Namespace, string Class, string? Member = null) {
    public override string ToString() => !string.IsNullOrWhiteSpace(Member) ? Member.Pastel(Color.SkyBlue) : $"{Namespace}.{Class}".Pastel(Color.SkyBlue);
    public bool IsCompat() => !Namespace.Contains("FFXIVClientStructs.Interop") &&
                              Class != "Addresses" &&
                              Class != "MemberFunctionPointers" &&
                              Class != "StaticAddressPointers" &&
                              Class != "Delegates" &&
                              !Class.Contains("VirtualTable");
}
