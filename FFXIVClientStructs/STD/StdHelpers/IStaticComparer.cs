namespace FFXIVClientStructs.STD.StdHelpers;

public interface IStaticComparer<T> {
    public abstract static int Compare(in T left, in T right);
}
