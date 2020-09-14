using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabViewerSDK.Common
{
    public class IdentifierGenerator
    {
        static public string GenerateGUID()
        {
            string retValue = string.Empty;
            retValue = Guid.NewGuid().ToString();
            return retValue;
        }

        static public string GenerateShortID()
        {
            string retValue = string.Empty;
            string _guid = GenerateGUID();
            long _iter = 1;
            foreach (byte b in DataFormat.GetBytesFromString(_guid))
                _iter *= (b + 1);
            retValue = string.Format("{0:x}", _iter - DateTime.Now.Ticks);
            return retValue;
        }
    }
}
