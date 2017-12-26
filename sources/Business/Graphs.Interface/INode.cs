using System.Collections.Generic;

namespace Graphs.Interface
{
    public interface INode : INamed
    {
        IList<IArc> ArcBefore { get;  }
        IList<IArc> ArcAfter { get; }

        void AddArcAfter(IArc arc);
        void AddArcBefore(IArc arc);

        bool ExistArcAfter(IArc arcAB);
        bool ExistArcBefore(IArc arcAB);
    }
}
