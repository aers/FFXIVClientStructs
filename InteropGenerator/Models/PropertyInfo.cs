using InteropGenerator.Helpers;
using Microsoft.CodeAnalysis;

namespace InteropGenerator.Models;

internal sealed record PropertyInfo(
    string Name,
    string Type,
    RefKind RefKind,
    bool Get,
    bool Set,
    EquatableArray<string> InheritableAttributes);
