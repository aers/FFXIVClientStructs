using InteropGenerator.Helpers;

namespace InteropGenerator.Models;

internal sealed record StringOverloadInfo(
    MethodInfo MethodInfo,
    EquatableArray<string> IgnoredParameters);
