; Unshipped analyzer release
; https://github.com/dotnet/roslyn-analyzers/blob/main/src/Microsoft.CodeAnalysis.Analyzers/ReleaseTrackingAnalyzers.Help.md

### New Rules

| Rule ID  | Category                 | Severity | Notes                                                           |
|----------|--------------------------|----------|-----------------------------------------------------------------|
| CSIG0001 | InteropGenerator.General | Error    | Struct generation target is not marked partial                  |
| CSIG0002 | InteropGenerator.General | Error    | Struct generation target is nested in struct not marked partial |
| CSIG0003 | InteropGenerator.General | Error    | Struct generation target is nested in a class                   |
| CSIG0101 | InteropGenerator.Methods | Error | Method generation target is not marked partial |
| CSIG0102 | InteropGenerator.Methods | Error | Method parameters of generation targets must be an unmanaged type
{ CSIG0103 | InteropGenerator.Methods | Error | Method return value of a generation target must be an unmanaged type |