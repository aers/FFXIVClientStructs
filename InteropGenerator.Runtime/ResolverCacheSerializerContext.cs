using System.Text.Json.Serialization;

namespace InteropGenerator.Runtime;

[JsonSerializable(typeof(ResolverCache))]
[JsonSourceGenerationOptions(WriteIndented = true)]
internal partial class ResolverCacheSerializerContext : JsonSerializerContext {
}
