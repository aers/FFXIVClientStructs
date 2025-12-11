using System.IO.Compression;

namespace ExcelGenerator;

public static class Updater {
    private const string LatestReleaseUrl = "https://github.com/xivdev/EXDSchema/archive/refs/heads/latest.zip";

    public static string? TryUpdate(string definitionPath) {
        Console.WriteLine($"Downloading Latest Release into {definitionPath}");
        if (!DownloadRelease(LatestReleaseUrl, definitionPath, out var filePath)) {
            Console.WriteLine("Download Failed");
            return null;
        }
        Console.WriteLine($"Successfully downloaded to {filePath}");
        return filePath;
    }

    private static bool DownloadRelease(string downloadUrl, string root, out string filePath) {
        using var httpClient = new HttpClient();
        httpClient.DefaultRequestHeaders.Add("User-Agent", "ExcelGenerator");

        var request = new HttpRequestMessage(HttpMethod.Get, downloadUrl);
        var response = httpClient.Send(request);
        if (!response.IsSuccessStatusCode) {
            filePath = string.Empty;
            return false;
        }
        if (!Directory.Exists(root))
            Directory.CreateDirectory(root);

        var fileName = Path.GetFileNameWithoutExtension(response.Content.Headers.ContentDisposition?.FileName?.Trim() ?? downloadUrl);
        filePath = Path.Combine(root, fileName);

        using (var stream = response.Content.ReadAsStream())
        using (var zip = new ZipArchive(stream, ZipArchiveMode.Read))
            zip.ExtractToDirectory(root, true);
        return true;
    }
}
