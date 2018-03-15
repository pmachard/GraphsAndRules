using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphsAndRules
{
    public class RuleBase : IRuleBase
    {
        private Dictionary<string, IRule> _dicoNameRule = new Dictionary<string, IRule>();

        public IRule Create(string name)
        {
            if (RuleExist(name))
            {
                throw new ArgumentException("name parameter", "is allready exist. Contact Your Admin/DevTeam to fix and add UnitTest");
            }

            var result = new Rule(name);
            _dicoNameRule.Add(name, result);
            return result;
        }

        public bool RuleExist(string name)
        {
            return _dicoNameRule.ContainsKey(name);
        }        
    }
}
