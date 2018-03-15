namespace GraphsAndRules
{
    public interface IRule : INamed
    {
        IPremise Premise { get; set; }
        IConclusion Conclusion { get; set; }

        bool PremiseIsChecked(IFactBase factBaseSource);
        bool RunConclusion(IFactBase factBaseSource);

    }
}
