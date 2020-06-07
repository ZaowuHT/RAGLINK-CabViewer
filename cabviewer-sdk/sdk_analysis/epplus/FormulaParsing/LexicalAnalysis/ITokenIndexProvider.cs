using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabViewerSDKOfficeOpenXml.FormulaParsing.LexicalAnalysis
{
    public interface ITokenIndexProvider
    {
        int Index { get;  }

        void MoveIndexPointerForward();
    }
}
