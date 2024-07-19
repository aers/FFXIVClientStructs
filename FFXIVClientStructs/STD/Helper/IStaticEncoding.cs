using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace FFXIVClientStructs.STD.Helper;

[SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
public partial interface IStaticEncoding {
    public abstract static Encoding Encoding { get; }

    public sealed partial class System : IStaticEncoding {
        private System() { }

        public static Encoding Encoding => GetAcp() switch {
            var x and (0 or 1200 or 1201 or 12000 or 12001 or 20127 or 28591 or 65000 or 65001) =>
                Encoding.GetEncoding(x),
            var x => CodePagesEncodingProvider.Instance.GetEncoding(x) ?? CustomSystem.Encoding,
        };

        [LibraryImport("kernel32", EntryPoint = "GetACP", SetLastError = true)]
        private static unsafe partial int GetAcp();
    }

    public sealed class Unicode : IStaticEncoding {
        private Unicode() { }

        public static Encoding Encoding => Encoding.Unicode;
    }

    public sealed partial class CustomSystem : IStaticEncoding {
        private CustomSystem() { }

        public static Encoding Encoding => CustomSystemEncoding.Instance;

        private sealed unsafe partial class CustomSystemEncoding : Encoding {
            public static readonly CustomSystemEncoding Instance = new();

            private CustomSystemEncoding() { }

            public override int GetByteCount(char* chars, int count) {
                if (count == 0)
                    return 0;

                ArgumentNullException.ThrowIfNull(chars);
                ArgumentOutOfRangeException.ThrowIfLessThan(count, 0);
                return WideCharToMultiByte(0, 0, chars, count, null, 0, null, null);
            }

            public override int GetByteCount(ReadOnlySpan<char> chars) {
                fixed (char* pc = chars)
                    return GetByteCount(pc, chars.Length);
            }

            public override int GetByteCount(char[] chars, int index, int count) =>
                GetByteCount(chars.AsSpan(index, count));

            public override int GetByteCount(string s) =>
                GetByteCount(s.AsSpan());

            public override int GetBytes(char* chars, int charCount, byte* bytes, int byteCount) {
                if (charCount == 0 || byteCount == 0)
                    return 0;

                ArgumentNullException.ThrowIfNull(chars);
                ArgumentOutOfRangeException.ThrowIfLessThan(charCount, 0);
                ArgumentNullException.ThrowIfNull(bytes);
                ArgumentOutOfRangeException.ThrowIfLessThan(byteCount, 0);
                return WideCharToMultiByte(0, 0, chars, charCount, bytes, byteCount, null, null);
            }

            public override int GetBytes(ReadOnlySpan<char> chars, Span<byte> bytes) {
                fixed (char* pc = chars) {
                    fixed (byte* pb = bytes) {
                        return GetBytes(pc, chars.Length, pb, bytes.Length);
                    }
                }
            }

            public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex) =>
                GetBytes(chars.AsSpan(charIndex, charCount), bytes.AsSpan(byteIndex));

            public override int GetBytes(string s, int charIndex, int charCount, byte[] bytes, int byteIndex) =>
                GetBytes(s.AsSpan(charIndex, charCount), bytes.AsSpan(byteIndex));

            public override int GetCharCount(byte* bytes, int count) {
                if (count == 0)
                    return 0;

                ArgumentNullException.ThrowIfNull(bytes);
                ArgumentOutOfRangeException.ThrowIfLessThan(count, 0);
                return MultiByteToWideChar(0, 0, bytes, count, null, 0);
            }

            public override int GetCharCount(ReadOnlySpan<byte> bytes) {
                fixed (byte* pb = bytes)
                    return GetCharCount(pb, bytes.Length);
            }

            public override int GetCharCount(byte[] bytes, int index, int count) =>
                GetCharCount(bytes.AsSpan(index, count));

            public override int GetChars(byte* bytes, int byteCount, char* chars, int charCount) {
                if (charCount == 0 || byteCount == 0)
                    return 0;

                ArgumentNullException.ThrowIfNull(chars);
                ArgumentOutOfRangeException.ThrowIfLessThan(charCount, 0);
                ArgumentNullException.ThrowIfNull(bytes);
                ArgumentOutOfRangeException.ThrowIfLessThan(byteCount, 0);
                return MultiByteToWideChar(0, 0, bytes, byteCount, chars, charCount);
            }

            public override int GetChars(ReadOnlySpan<byte> bytes, Span<char> chars) {
                fixed (char* pc = chars) {
                    fixed (byte* pb = bytes) {
                        return GetChars(pb, bytes.Length, pc, chars.Length);
                    }
                }
            }

            public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex) =>
                GetChars(bytes.AsSpan(byteIndex, byteCount), chars.AsSpan(charIndex));

            public override int GetMaxByteCount(int charCount) => 4 * charCount;

            public override int GetMaxCharCount(int byteCount) => 2 * byteCount;

            [LibraryImport("kernel32", SetLastError = true)]
            private static unsafe partial int WideCharToMultiByte(
                uint codePage,
                uint dwFlags,
                char* lpWideCharStr,
                int cchWideChar,
                byte* lpMultiByteStr,
                int cbMultiByte,
                byte* lpDefaultChar,
                int* lpUsedDefaultChar);

            [LibraryImport("kernel32", SetLastError = true)]
            private static unsafe partial int MultiByteToWideChar(
                uint codePage,
                uint dwFlags,
                byte* lpMultiByteStr,
                int cbMultiByte,
                char* lpWideCharStr,
                int cchWideChar);
        }
    }
}
