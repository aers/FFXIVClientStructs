using System.Collections.Concurrent;

namespace InteropGenerator.Runtime;

internal sealed record ResolverCache(string Version, ConcurrentDictionary<string, long> Cache);
