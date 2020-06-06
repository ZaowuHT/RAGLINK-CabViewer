using CabViewerResources.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabViewerResources
{
    public class CabViewerResourcesManager
    {
        static public Object GetResourceByName(string resourceName)
        {
            Object retValue;
            try
            {
                retValue = Resources.ResourceManager.GetObject(resourceName);
            }
            catch(Exception)
            {
                retValue = null;
            }
            return retValue;
        }
    }
}
