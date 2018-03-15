namespace GraphsAndRules
{
    public interface IRuleBase
    {
        IRule Create(string name);
        bool RuleExist(string name);

    }
}
