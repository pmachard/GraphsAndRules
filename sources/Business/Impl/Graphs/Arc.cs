using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Graphs.Interface;

namespace Graphs
{
    public class Arc : IArc
    {
        public string Name { get; set; }

        public INode From { get; set; }
        public INode To { get; set; }

        public static IArc Create(string name, INode from, INode to)
        {
            return new Arc(name, from, to);
        }

        private Arc(string name = "", INode from = null, INode to = null)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }

            Name    = name;
            From    = from;
            To      = to;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Arc arc = (Arc)obj;
            return (Name == arc.Name) && (From == arc.From) && (To == arc.To);
        }

        public override int GetHashCode()
        {
            return From.GetHashCode() ^ To.GetHashCode() ^ Name.GetHashCode();
        }

    }
}
