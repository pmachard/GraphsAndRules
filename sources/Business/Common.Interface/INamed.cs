namespace GraphsAndRules
{
    public interface INamed
    {
        string Name { get; }
        bool   IsValidName(string name);
    }
}
