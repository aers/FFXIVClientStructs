namespace InteropGenerator.Models;

public record SignatureInfo(string Signature, byte Offset) {
    public string GetPaddedSignature() {
        int paddingNeeded = 8 - (Signature.Length / 3 + 1) % 8;
        if (paddingNeeded != 0) {
            var result = new Span<char>(new char[Signature.Length + paddingNeeded * 3]);
            Signature.AsSpan().CopyTo(result);

            ReadOnlySpan<char> repeated = " ??".AsSpan();

            for (var repeatIndex = 0; repeatIndex < paddingNeeded; repeatIndex++) {
                repeated.CopyTo(result.Slice(Signature.Length + repeatIndex * repeated.Length));
            }

            return result.ToString();
        }
        return Signature;
    }

    public byte GetRelCallAndJumpAdjustedOffset() {
        // handle E8 and E9 jumps automatically
        if ((Offset == 0 &&
             Signature.StartsWith("E8")) ||
            Signature.StartsWith("E9"))
            return 1;
        return Offset;
    }
}
