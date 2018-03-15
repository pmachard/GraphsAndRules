using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndRules
{
    public class Rule : IRule
    {
        public string Name { get; set; }
        public IPremise Premise { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IConclusion Conclusion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        internal Rule(string name)
        {
            if (!IsValidName(name))
            {
                throw new ArgumentException("name parameter", "is not valid. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            Name = name;
        }

        public bool IsValidName(string name)
        {
            return (name != null) && (name != string.Empty);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Fact fact = (Fact)obj;
            return (Name == fact.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public bool PremiseIsChecked(IFactBase factBaseSource)
        {
            throw new NotImplementedException();
        }

        public bool RunConclusion(IFactBase factBaseSource)
        {
            throw new NotImplementedException();
        }
    }
}
