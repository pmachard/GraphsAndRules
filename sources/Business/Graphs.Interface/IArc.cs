namespace GraphsAndRules
{
    public interface IArc : INamed
    {
        INode From { get; }
        INode To { get;  }
    }
}
