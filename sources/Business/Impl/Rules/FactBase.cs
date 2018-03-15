using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndRules
{
    public class FactBase : IFactBase
    {
        private Dictionary<string, IFact> _dicoNameFact = new Dictionary<string, IFact>();

        public IFact Create(string name, string value="")
        {
            if (FactExist(name))
            {
                throw new ArgumentException("name parameter", "is allready exist. Contact Your Admin/DevTeam to fix and add UnitTest");
            }

            var result = new Fact(name,value);
            _dicoNameFact.Add(name, result);
            return result;
        }

        public bool FactExist(string name)
        {
            return _dicoNameFact.ContainsKey(name);
        }        
    }
}
