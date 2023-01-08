namespace FFXIVClientStructs.Interop;

public sealed partial class Resolver
{
    private static readonly Lazy<Resolver> Instance = new(() => new Resolver());

    private Resolver()
    {
    }
    
    public static Resolver GetInstance => Instance.Value;

    private readonly List<Address> _signatures = new();
    private readonly List<Address>[] _preResolveArray = new List<Address>[256];
    private int _totalBuckets = 0;

    public IReadOnlyList<Address> Signatures => _signatures.AsReadOnly();

    public void ResolveWithTarget(ResolverTarget target)
    {
        ReadOnlySpan<byte> currentTargetLocation = target.AsSpan()[target.TextSectionOffset..];
        for (int location = 0; location < target.TextSectionSize; location++)
        {
            Address matchedAddress = null;
            
            if (_preResolveArray[currentTargetLocation[0]] is not null)
            {
                List<Address> availableSignatures = _preResolveArray[currentTargetLocation[0]];
                
                foreach(Address signature in availableSignatures)
                {
                    int count;
                    
                    for (count = signature.Bytes.Length - 1; count > -1; count--)
                    {
                        if (signature.Mask[count] && signature.Bytes[count] != currentTargetLocation[count])
                            break;
                    }
                
                    if (count == -1)
                    {
                        matchedAddress = signature;
                        break;
                    }
                }
                
                if (matchedAddress is not null)
                {
                    matchedAddress.Value = (nuint)(4096 + location); // target.TargetSpace + target.TextSectionOffset + 
                    availableSignatures.Remove(matchedAddress);
                    if (availableSignatures.Count == 0)
                    {
                        _preResolveArray[currentTargetLocation[0]] = null;
                        _totalBuckets--;
                        if (_totalBuckets == 0)
                            break;
                    }
                }
            }
        
            currentTargetLocation = currentTargetLocation[1..];
        }
    }
    
    private void RegisterAddress(Address address)
    {
        _signatures.Add(address);

        if (_preResolveArray[address.Bytes[0]] is null)
        {
            _preResolveArray[address.Bytes[0]] = new List<Address>();
            _totalBuckets++;
        }

        _preResolveArray[address.Bytes[0]].Add(address);
    }
}