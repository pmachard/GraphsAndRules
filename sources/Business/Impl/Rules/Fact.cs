using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndRules
{
    public class Fact : IFact
    {
        public string Name { get; set; }

        public static IFact Create(string name)
        {
            return new Fact(name);
        }

        private Fact(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            if (name == string.Empty)
            {
                throw new ArgumentNullException("name parameter", "is empty. Contact Your Admin/DevTeam to fix and add UnitTest");
            }

            Name = name;
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
    }
}
