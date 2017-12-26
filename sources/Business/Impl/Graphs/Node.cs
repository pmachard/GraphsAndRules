using System;
using System.Collections.Generic;
using Graphs.Interface;
using System.Linq;

namespace Graphs
{
    public class Node : INode
    {
        #region ---- Members ----
        private List<IArc> _arcBefore;

        private List<IArc> _arcAfter;
        #endregion

        #region ---- Properties ----
        public string Name  { get; set; }

        public IList<IArc> ArcBefore
        {
            get
            {
                return _arcBefore.Select(x => x).ToList();
            }
            private set
            {
                _arcBefore = value.ToList();
            }
        }

        public IList<IArc> ArcAfter
        {
            get
            {
                return _arcAfter.Select(x => x).ToList();
            }
            private set
            {
                _arcAfter = value.ToList();
            }
        }

        public Node(string name = "")
        {
            if (name == null)
            {
                throw new ArgumentNullException("name parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            else
            {
                Name = name;
                _arcBefore = new List<IArc>();
                _arcAfter = new List<IArc>();
            }
        }
        #endregion

        #region ---- Public Method ----
        public void AddArcAfter(IArc arc)
        {
            if (arc == null)
            {
                throw new ArgumentNullException("arc parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            _arcAfter.Add(arc);
        }

        public void AddArcBefore(IArc arc)
        {
            if (arc == null)
            {
                throw new ArgumentNullException("arc parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            _arcBefore.Add(arc);
        }

        public bool ExistArcAfter(IArc arc)
        {
            return _arcAfter.Contains(arc);
        }

        public bool ExistArcBefore(IArc arc)
        {
            return _arcBefore.Contains(arc);
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Node node = (Node)obj;
            return (Name == node.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }


        #endregion

        #region ---- Public Static ----
        public static bool CreateArc(INode nodeA, INode nodeB)
        {
            if (nodeA == null)
            {
                throw new ArgumentNullException("nodeA parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            if (nodeB == null)
            {
                throw new ArgumentNullException("nodeB parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            if (nodeA == nodeB)
            {
                throw new ArgumentException("nodeA and nodeB parameteris same object. Contact Your Admin/DevTeam to fix and add UnitTest");
            }

            bool result = false;

            IArc arcAB = new Arc("Arc : " + nodeA.Name + " -> " + nodeB.Name);

            if (nodeA.ExistArcAfter(arcAB) && nodeB.ExistArcBefore(arcAB))
            {
                result = false;
            }
            else
            {
                nodeA.AddArcAfter(arcAB);
                nodeB.AddArcBefore(arcAB);
                result = true;
            }

            return result;
        }
        #endregion
    }
}
