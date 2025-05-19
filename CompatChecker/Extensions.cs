using System.Text;

namespace CompatChecker;

public static class Extensions {
    public static void WriteFile(this FileInfo file, string content) {
        using var stream = file.CreateText();
        stream.Write(content);
    }

    public static void Prepend(this StringBuilder builder, string text) => builder.Insert(0, text);

    public static void PrependLine(this StringBuilder builder, string text) => builder.Insert(0, text + Environment.NewLine);
}
