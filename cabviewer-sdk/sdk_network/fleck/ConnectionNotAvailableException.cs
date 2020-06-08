using System;

namespace CabViewerSDK.Websocket
{
    public class ConnectionNotAvailableException : Exception
    {
        public ConnectionNotAvailableException() : base()
        {
        }

        public ConnectionNotAvailableException(string message) : base(message)
        {
        }

        public ConnectionNotAvailableException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
