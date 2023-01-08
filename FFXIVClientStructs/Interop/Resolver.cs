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
        ReadOnlySpan<ulong> targetLocationAsUlong = MemoryMarshal.Cast<byte, ulong>(currentTargetLocation);

        Address matchedAddress = null;

        for (int location = 0; location < target.TextSectionSize; location++)
        {

            if (_preResolveArray[currentTargetLocation[0]] is not null)
            {
                List<Address> availableSignatures = _preResolveArray[currentTargetLocation[0]];
                
                foreach(Address signature in availableSignatures)
                {
                    int count;
                    int length = signature.Bytes.Length;

                    for (count = 0; count < length; count++)
                    {
                        if ((signature.Mask[count] & signature.Bytes[count]) != (signature.Mask[count] & targetLocationAsUlong[count]))
                            break;
                    }
                
                    if (count == length)
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

                    matchedAddress = null;
                }
            }
        
            currentTargetLocation = currentTargetLocation[1..];
            targetLocationAsUlong = MemoryMarshal.Cast<byte, ulong>(currentTargetLocation);
        }
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