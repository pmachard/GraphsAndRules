using System;
using System.Collections.Generic;

namespace Graphs.Interface
{
    public interface INode : INamed, IDisposable
    {
        IList<IArc> ArcsBefore { get;  }
        IList<IArc> ArcsAfter { get; }

        bool ExistArcAfter(IArc arc);
        bool ExistArcBefore(IArc arc);

        void AddArcAfter(IArc arc);
        void AddArcBefore(IArc arc);

        void RemoveArcAfter(IArc arc);
        void RemoveAddArcBefore(IArc arc);

        IList<INode> Way(List<INode> resultBase = null);

    }
}
