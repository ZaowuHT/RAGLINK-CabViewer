using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabViewerSDK.OfficeOpenXml.Utils
{
    public interface IValidationResult
    {
        void IsTrue();
        void IsFalse();
    }
}
