; Shipped analyzer releases
; https://github.com/dotnet/roslyn-analyzers/blob/main/src/Microsoft.CodeAnalysis.Analyzers/ReleaseTrackingAnalyzers.Help.md

| Rule ID  | Category                   | Severity | Notes                                                                                                               |
|----------|----------------------------|----------|---------------------------------------------------------------------------------------------------------------------|
| CSIG0001 | InteropGenerator.Struct    | Error    | Struct generation target is not marked partial                                                                      |
| CSIG0002 | InteropGenerator.Struct    | Error    | Struct generation target is nested in struct not marked partial                                                     |
| CSIG0003 | InteropGenerator.Struct    | Error    | Struct generation target is nested in a class                                                                       |
| CSIG0004 | InteropGenerator.Struct    | Error    | Struct generation target should use the StructLayout attribute                                                      |
| CSIG0005 | InteropGenerator.Struct    | Error    | Struct generation target should use LayoutKind.Explicit in the StructLayout attribute                               |
| CSIG0006 | InteropGenerator.Struct    | Error    | Struct generation target should have a defined size in the StructLayout attribute                                   |
| CSIG0007 | InteropGenerator.Struct    | Error    | Inheritance generation target is attempting to inherit a type that is not marked for inheritance.                   |
| CSIG0101 | InteropGenerator.Method    | Error    | Method generation target is not marked partial                                                                      |
| CSIG0102 | InteropGenerator.Method    | Error    | Method parameters of generation targets must be an unmanaged type                                                   |
| CSIG0103 | InteropGenerator.Method    | Error    | Method return value of a generation target must be an unmanaged type                                                |
| CSIG0104 | InteropGenerator.Method    | Error    | Method marked for static address generation cannot have parameters                                                  |
| CSIG0105 | InteropGenerator.Method    | Error    | Method marked for static address generation must be static                                                          |
| CSIG0106 | InteropGenerator.Method    | Error    | Method marked for static address generation must return a pointer type                                              |
| CSIG0107 | InteropGenerator.Method    | Error    | Method marked for virtual function generation must not be static                                                    |
| CSIG0108 | InteropGenerator.Method    | Error    | Method marked for string overload generation must have a valid parameter to overload                                |
| CSIG0109 | InteropGenerator.Method    | Error    | Parameter marked with string ignore is not a valid type                                                             |
| CSIG0110 | InteropGenerator.Method    | Error    | Method marked for virtual function generation has an index out of the bounds defined by the struct's virtual table  |
| CSIG0201 | InteropGenerator.Signature | Error    | Signature contains invalid characters (valid characters are A-F 0-9 ? and space)                                    |
| CSIG0202 | InteropGenerator.Signature | Error    | Signature format is invalid (must be 2 character bytes seperated by spaces with no leading or trailing space)       |
| CSIG0301 | InteropGenerator.Field     | Error    | Field marked for fixed size array generation must be internal                                                       |
| CSIG0302 | InteropGenerator.Field     | Error    | Field marked for fixed size array generation must have a proper type name (FixedSizeArray#\<T>)                     |
| CSIG0303 | InteropGenerator.Field     | Error    | Field marked for fixed size array generation must have a proper filed name                                          |
| CSIG0304 | InteropGenerotor.Field     | Error    | Field marked for fixed size array generation with isString set to true must use byte or char as the underlying type |