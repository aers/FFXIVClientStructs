using Microsoft.CodeAnalysis;

namespace InteropGenerator.Extensions;

public static class RefKindExtensions {
    public static string GetParameterPrefix(this RefKind refKind) {
        switch (refKind) {
            case RefKind.In:
                return "in ";
            case RefKind.Out:
                return "out ";
            case RefKind.Ref:
                return "ref ";
            case RefKind.RefReadOnlyParameter:
                return "ref readonly ";
            default:
                return "";
        }
    }
}
