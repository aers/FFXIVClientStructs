using LanguageExt;
using Microsoft.CodeAnalysis;
using static LanguageExt.Prelude;

namespace FFXIVClientStructs.InteropSourceGenerators.Extensions;

internal static class IncrementalValuesProviderExtensions
{
    public static IncrementalValuesProvider<(Validation<TErr, TKey>, Validation<TErr, Seq<TElement>>)>
        TupleGroupByValidation<TKey, TErr, TElement>(
            this IncrementalValuesProvider<(Validation<TErr, TKey>, Validation<TErr, TElement>)> source)
    {
        return source.Collect().SelectMany(static (item, _) =>
            item.GroupBy(static items => items.Item1,
                    static items => items.Item2)
                .Select(grouping => (grouping.Key, Seq(grouping).Sequence())));
    }
}