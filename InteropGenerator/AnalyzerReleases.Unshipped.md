; Unshipped analyzer release
; https://github.com/dotnet/roslyn-analyzers/blob/main/src/Microsoft.CodeAnalysis.Analyzers/ReleaseTrackingAnalyzers.Help.md

### New Rules

| Rule ID  | Category                | Severity | Notes                                                                |
|----------|-------------------------|----------|----------------------------------------------------------------------|
| CSIG0001 | InteropGenerator.Struct | Error    | Struct generation target is not marked partial                       |
| CSIG0002 | InteropGenerator.Struct | Error    | Struct generation target is nested in struct not marked partial      |
| CSIG0003 | InteropGenerator.Struct | Error    | Struct generation target is nested in a class                        |
| CSIG0101 | InteropGenerator.Method | Error    | Method generation target is not marked partial                       |
| CSIG0102 | InteropGenerator.Method | Error    | Method parameters of generation targets must be an unmanaged type    |
| CSIG0103 | InteropGenerator.Method | Error    | Method return value of a generation target must be an unmanaged type |
| CSIG0201 | InteropGenerator.Signature | Error | Signature contains invalid characters (valid characters are A-F 0-9 ? and space) |
| CSIG0202 | InteropGenerator.Signature | Error | Signature format is invalid (must be 2 character bytes seperated by spaces) |