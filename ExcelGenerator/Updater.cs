using System.Globalization;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace ExcelGenerator;

public class Updater : IDisposable {
    private const string LatestReleaseUrl = "https://api.github.com/repos/xivdev/EXDSchema/releases/latest";

    private readonly HttpClient _httpClient;
    private readonly string _gameVersion;
    private readonly string _definitionRoot;

    public Updater(string gamePath, string definitionPath) {
        _httpClient = new HttpClient();
        // this is just so github doesn't block this client without a User-Agent
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "ExcelGenerator");

        var versionPath = Path.Combine(gamePath, "game", "ffxivgame.ver");
        _gameVersion = File.Exists(versionPath) ? File.ReadAllText(versionPath).Trim() : "0000.00.00.0000.0000";
        _definitionRoot = definitionPath;
    }

    public void Dispose() {
        _httpClient.Dispose();
    }

    public string? TryUpdate() {
        if (!GetLatestRelease(out var release))
            return null;
        
        var path = Path.Combine(_definitionRoot, release.Version);
        if (Directory.Exists(path) && Directory.GetFiles(path, "*.yml").Length > 0) {
            Console.WriteLine($"Lates Release Directory already exists: {path}");
            return path;
        }
        var downloadDir = Path.Combine(_definitionRoot, release.Version);
        Console.WriteLine($"Downloading Latest Release {release.Version} into {downloadDir}");
        return DownloadRelease(release.Url) ? downloadDir : null;
    }

    public string? GetLatesLocalDirectory() {
        var directories = Directory.EnumerateDirectories(_definitionRoot, "*", SearchOption.TopDirectoryOnly);
        var dict = new SortedDictionary<DateTime, string>();
        foreach (var directory in directories) {
            var time = ParseVersion(Path.GetDirectoryName(directory)!);
            dict.Add(time, directory);
        }
        return dict.Count == 0 ? null : dict.Last().Value;
    }

    private bool DownloadRelease(string downloadUrl) {
        var request = new HttpRequestMessage(HttpMethod.Get, downloadUrl);
        var response = _httpClient.Send(request);
        if (!response.IsSuccessStatusCode)
            return false;

        var filePath = Path.Combine(_definitionRoot, Path.GetFileName(downloadUrl));
        if (!Directory.Exists(_definitionRoot))
            Directory.CreateDirectory(_definitionRoot);
        using (var stream = response.Content.ReadAsStream())
        using (var fileStream = File.Create(filePath))
            stream.CopyTo(fileStream);

        using (var zip = ZipFile.OpenRead(filePath))
            zip.ExtractToDirectory(_definitionRoot, true);
        return true;
    }

    public bool GetLatestRelease(out (string Version, string Url) release) {
        var current = ParseVersion(_gameVersion);
        var releases = GetReleases();
        if (releases.Count == 0) {
            release = (string.Empty, string.Empty);
            return false;
        }

        if (releases.TryGetValue(current, out var url)) {
            release = (_gameVersion, url);
            return true;
        }

        url = releases.Last().Value;
        release = (Path.GetFileNameWithoutExtension(url), url);
        return true;
    }

    private SortedDictionary<DateTime, string> GetReleases() {
        var request = new HttpRequestMessage(HttpMethod.Get, LatestReleaseUrl);
        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github+json"));
        var response = _httpClient.Send(request, HttpCompletionOption.ResponseContentRead);
        if (!response.IsSuccessStatusCode)
            return [];
        var json = JsonNode.Parse(response.Content.ReadAsStream());
        if (json?["assets"]?.AsArray() is not { Count: > 0 } array)
            return [];

        var dict = new SortedDictionary<DateTime, string>();
        foreach (var node in array) {
            if (node == null) continue;
            var url = node["browser_download_url"]!.ToString();
            var time = ParseVersion(Path.GetFileNameWithoutExtension(url));
            dict.Add(time, url);
        }
        return dict;
    }

    private static DateTime ParseVersion(string version) {
        const string format = "yyyy.MM.dd";
        if (version.Length < format.Length)
            return DateTime.MinValue;
        version = version[..format.Length];
        if (DateTime.TryParseExact(version, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
            return result;
        return DateTime.MinValue;
    }
}
