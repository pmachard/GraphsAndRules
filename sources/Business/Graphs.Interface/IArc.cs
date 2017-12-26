namespace Graphs.Interface
{
    public interface IArc : INamed
    {
        INode From { get; }
        INode To { get;  }
    }
}
