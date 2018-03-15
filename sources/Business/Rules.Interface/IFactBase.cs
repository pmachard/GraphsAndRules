namespace GraphsAndRules
{
    public interface IFactBase
    {
        IFact Create(string name, string value="");

        bool FactExist(string name);
    }
}
