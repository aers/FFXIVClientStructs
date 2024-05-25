using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace InteropGenerator.Runtime;

[StackTraceHidden]
public static class ThrowHelper {

    [DoesNotReturn]
    public static void ThrowNullAddress(string name, string signature) {
        throw new InvalidOperationException($"Address for {name} is null. The resolver was either uninitialized or failed to resolve address with signature {signature}.");
    }
}
