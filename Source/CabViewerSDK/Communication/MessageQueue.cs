using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabViewerSDK.Communication
{
    public class MessageQueue<T>
    {
        private bool messageQueueAvailable;
        private int messsageQueueLength;
        private List<T> messsageQueue;
        private int messageQueueMaxLenght;

        public MessageQueue(int _maxLength)
        {
            messageQueueAvailable = false;
            messsageQueueLength = 0;
            messsageQueue = new List<T>();
            messsageQueue.Clear();
            messageQueueMaxLenght = _maxLength;
        }

        public int GetMessageQueueLength()
        {
            messsageQueueLength = messsageQueue.Count;
            return messsageQueueLength;
        }

        public bool MessageQueueAvailable()
        {
            return messageQueueAvailable;
        }

        public void AddToMessageQueue(T _str, bool _forceReload)
        {
            if (messsageQueue.Count < messageQueueMaxLenght)
            {
                messsageQueue.Add(_str);
                messsageQueueLength = messsageQueue.Count;
                if (messsageQueue.Count >= messageQueueMaxLenght)
                    messageQueueAvailable = false;
            }
            else if (_forceReload)
            {
                messageQueueAvailable = false;
                ClearMessageQueue();
                AddToMessageQueue(_str, false);
            }
        }

        public List<T> GetAllMessage()
        {
            List<T> retValue = new List<T>(messsageQueue.ToArray());
            return retValue;
        }

        public T PopMessage()
        {
            T retValue = default(T);
            if (messsageQueue.Count >= 1)
            {
                retValue = messsageQueue[0];
                messsageQueue.RemoveAt(0);
                messsageQueueLength = messsageQueue.Count;
                messageQueueAvailable = true;
            }
            return retValue;
        }

        public T PeekMessage()
        {
            T retValue = default(T);
            if (messsageQueue.Count >= 1)
                retValue = messsageQueue[0];
            return retValue;
        }

        public void ClearMessageQueue()
        {
            messsageQueue.Clear();
            messsageQueueLength = 0;
            messageQueueAvailable = true;
        }
    };
}
