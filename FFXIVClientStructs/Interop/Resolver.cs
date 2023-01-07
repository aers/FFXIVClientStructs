namespace FFXIVClientStructs.Interop;

public unsafe sealed partial class Resolver
{
    private static readonly Lazy<Resolver> Instance = new Lazy<Resolver>(() => new Resolver());

    private Resolver()
    {
    }
    
    public static Resolver GetInstance => Instance.Value;

    private readonly List<Signature> _signatures = new();
    private readonly Dictionary<byte, List<Signature>> _preResolveCache = new();

    public IReadOnlyList<Signature> Signatures => _signatures.AsReadOnly();

    internal void RegisterSignature(Signature signature)
    {
        _signatures.Add(signature);

        if (!_preResolveCache.TryGetValue(signature.Bytes[0], out List<Signature> cacheList))
        {
            cacheList = new List<Signature>();
            
            _preResolveCache.Add(signature.Bytes[0], cacheList);
        }
        
        cacheList.Add(signature);
    }
}