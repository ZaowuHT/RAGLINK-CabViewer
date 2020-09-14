using System;
using System.Text;

namespace CabViewerSDK.Common
{
    public class DataFormat
    {
        static public byte[] GetBytesFromString(string _str)
        {
            byte[] retValue = null;
            try
            {
                retValue = Encoding.UTF8.GetBytes(_str);
            }
            catch (Exception) { };
            return retValue;
        }

        static public string GetStringFromBytes(byte[] _stream)
        {
            string retValue = string.Empty;
            try
            {
                retValue = Encoding.UTF8.GetString(_stream);
            }
            catch (Exception) { };
            return retValue;
        }

        static public bool CompareControllerFloatNumber(float _a, float _b)
        {
            bool retValue = false;
            try
            {
                retValue = (Math.Abs(_a - _b) <= 0.005);
            }
            catch (Exception) { };
            return retValue;
        }
    }
}
