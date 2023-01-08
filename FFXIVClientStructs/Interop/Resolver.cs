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
        ReadOnlySpan<byte> targetSpan = target.AsSpan()[target.TextSectionOffset..];

        for (int location = 0; location < target.TextSectionSize; location++)
        {
            if (_preResolveArray[targetSpan[location]] is not null)
            {
                List<Address> availableSignatures = _preResolveArray[targetSpan[location]];
                
                ReadOnlySpan<ulong> targetLocationAsUlong = MemoryMarshal.Cast<byte, ulong>(targetSpan[location..]);

                int avLen = availableSignatures.Count;
                
                for(int i = 0; i < avLen; i++)
                {
                    Address signature = availableSignatures[i];
                    
                    int count;
                    int length = signature.Bytes.Length;

                    for (count = 0; count < length; count++)
                    {
                        if ((signature.Mask[count] & signature.Bytes[count]) != (signature.Mask[count] & targetLocationAsUlong[count]))
                            break;
                    }

                    if (count == length)
                    {
                        signature.Value = (nuint) (4096 + location); // target.TargetSpace + target.TextSectionOffset + 
                        availableSignatures.Remove(signature);
                        if (availableSignatures.Count == 0)
                        {
                            _preResolveArray[targetSpan[location]] = null;
                            _totalBuckets--;
                            if (_totalBuckets == 0)
                                goto outLoop;
                        }

                        break;
                    }
                }
            }
        }
        outLoop: ;
    }
    
    private void RegisterAddress(Address address)
    {
        _signatures.Add(address);

        byte firstByte = (byte) (address.Bytes[0]);

        if (_preResolveArray[firstByte] is null)
        {
            _preResolveArray[firstByte] = new List<Address>();
            _totalBuckets++;
        }

        _preResolveArray[firstByte].Add(address);
    }
}