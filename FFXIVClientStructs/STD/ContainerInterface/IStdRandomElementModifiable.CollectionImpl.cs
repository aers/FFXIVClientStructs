using System.Collections;

namespace FFXIVClientStructs.STD.ContainerInterface;

public partial interface IStdRandomElementModifiable<T> {
    bool ICollection<T>.IsReadOnly => false;
    bool IList.IsReadOnly => false;
}
