using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;

namespace GraphsAndRules
{
    public class Node : INode
    {
        #region ---- Cstr ----

        private Node(string name = "")
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

        #region ---- Implement IDisposable ----
         
        // REF : https://docs.microsoft.com/fr-fr/dotnet/standard/garbage-collection/implementing-dispose       

        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
                Node.Delete(this);
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }

        #endregion

        #region ---- Members ----

        private List<IArc> _arcBefore;

        private List<IArc> _arcAfter;

        #endregion

        #region ---- Properties ----

        public string Name  { get; private set; }

        public IList<IArc> ArcsBefore
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

        public IList<IArc> ArcsAfter
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

        #endregion

        #region ---- Public Method ----

        public void AddArcAfter(IArc arc)
        {
            if (arc == null)
            {
                throw new ArgumentNullException("arc parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            if (ExistArcAfter(arc))
            {
                throw new ArgumentException("arc parameter", "allready exist in after list. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            _arcAfter.Add(arc);
        }

        public void AddArcBefore(IArc arc)
        {
            if (arc == null)
            {
                throw new ArgumentNullException("arc parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            if (ExistArcBefore(arc))
            {
                throw new ArgumentException("arc parameter", "allready exist in before list. Contact Your Admin/DevTeam to fix and add UnitTest");
            }

            _arcBefore.Add(arc);
        }

        public void RemoveArcAfter(IArc arc)
        {
            if (arc == null)
            {
                throw new ArgumentNullException("arc parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            if (!ExistArcAfter(arc))
            {
                throw new ArgumentException("arc parameter", "not exist in after list. Contact Your Admin/DevTeam to fix and add UnitTest");
            }

            _arcAfter.Remove(arc);
        }

        public void RemoveAddArcBefore(IArc arc)
        {
            if (arc == null)
            {
                throw new ArgumentNullException("arc parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            if (!ExistArcBefore(arc))
            {
                throw new ArgumentException("arc parameter", "not exist in before list. Contact Your Admin/DevTeam to fix and add UnitTest");
            }

            _arcBefore.Remove(arc);
        }

        public bool ExistArcAfter(IArc arc)
        {
            if (arc == null)
            {
                throw new ArgumentNullException("arc parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            return _arcAfter.Contains(arc);
        }

        public bool ExistArcBefore(IArc arc)
        {
            if (arc == null)
            {
                throw new ArgumentNullException("arc parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
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

        private static Dictionary<string, INode> _NodesNameToNode = new Dictionary<string, INode>();

        public static INode Create(string sName)
        {
            if (sName == null)
            {
                throw new ArgumentNullException("sName parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            if (sName == string.Empty)
            {
                throw new ArgumentException("sName is empty. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            if (_NodesNameToNode.ContainsKey(sName))
            {
                throw new ArgumentException("sName already exist. Contact Your Admin/DevTeam to fix and add UnitTest");
            }

            INode result = new Node(sName);
            _NodesNameToNode.Add(sName, result);

            return result;
        }

        private static void Delete(Node node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node parameter", "is null. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            if (!_NodesNameToNode.ContainsValue(node))
            {
                throw new ArgumentException("node is unknow. Contact Your Admin/DevTeam to fix and add UnitTest");
            }
            
            _NodesNameToNode.Remove(node.Name);
        }

        public static void Clean()
        {
            _NodesNameToNode.Clear();
        }

        public IList<INode> Way(List<INode> resultBase = null)
        {
            if (resultBase==null)
            {
                resultBase = new List<INode>();
            }

            List<INode> result = new List<INode>();
            result.AddRange(resultBase);
            result.Add(this);

            foreach (Arc arcAfter in _arcAfter)
            {
                if (!result.Contains(arcAfter.To))
                {
                    Node arcAfterTo = arcAfter.To as Node;
                    IList<INode> resultInter = arcAfterTo.Way(result);
                    result.AddRange(resultInter.Where(x => !result.Contains(x)));
                }
            }
            return result;
        }

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

            IArc arcAB = Arc.Create("Arc : " + nodeA.Name + " -> " + nodeB.Name, nodeA, nodeB);

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
