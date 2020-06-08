using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CabViewerSDK.OfficeOpenXml.FormulaParsing.ExcelUtilities
{
    public class LookupValueMatcher : ValueMatcher
    {
        protected override int CompareObjectToString(object o1, string o2)
        {
            return IncompatibleOperands;
        }
    }
}
