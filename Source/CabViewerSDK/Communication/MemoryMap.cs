using System;
using System.IO.MemoryMappedFiles;

namespace CabViewerSDK.Communication
{
    class MemoryMap
    {
        public class MemoryMapWriter
        {
            public string memoryMapName;
            public int maxStreamSize;
            private byte[] streamArray;
            private MemoryMappedFile memoryMap;
            private MemoryMappedViewStream viewStream;

            public MemoryMapWriter(string _memoryMapName, ref byte[] dataStream)
            {
                memoryMapName = _memoryMapName;
                if (dataStream != null)
                {
                    streamArray = dataStream;
                    maxStreamSize = streamArray.Length + 64;
                    memoryMap = MemoryMappedFile.CreateOrOpen(memoryMapName, maxStreamSize * sizeof(byte));
                    viewStream = memoryMap.CreateViewStream();
                }
            }

            public MemoryMapWriter(string _memoryMapName, string dataStream)
            {
                memoryMapName = _memoryMapName;
                if (dataStream != null)
                {
                    streamArray = Common.DataFormat.GetBytesFromString(dataStream);
                    maxStreamSize = streamArray.Length + 64;
                    memoryMap = MemoryMappedFile.CreateOrOpen(memoryMapName, maxStreamSize * sizeof(byte));
                    viewStream = memoryMap.CreateViewStream();
                }
            }

            public int GetStreamLength()
            {
                int retValue = 0;
                retValue = streamArray.Length;
                return retValue;
            }

            public void WriteStream()
            {
                try
                {
                    viewStream.Seek(0, System.IO.SeekOrigin.Begin);
                    viewStream.Write(streamArray, 0, streamArray.Length);
                }
                catch (Exception) { };
            }

            public void DisposeWriter()
            {
                if (viewStream != null)
                {
                    viewStream.Close();
                }
                if (memoryMap != null)
                {
                    memoryMap.Dispose();
                }
            }
        };

        public class MemoryMapReader
        {
            public string memoryMapName;
            public int streamSize;
            private MemoryMappedFile memoryMap;
            private MemoryMappedViewStream viewStream;

            public MemoryMapReader(string _memoryMapName, int _streamSize)
            {
                streamSize = _streamSize;
                memoryMapName = _memoryMapName;
                try
                {
                    memoryMap = MemoryMappedFile.OpenExisting(memoryMapName);
                    viewStream = memoryMap.CreateViewStream();
                }
                catch (Exception) { };
            }

            public void ReadStream(ref byte[] dataStream)
            {
                try
                {
                    viewStream.Read(dataStream, 0, streamSize);
                }
                catch (Exception) { };
            }

            public string ReadStream()
            {
                string retValue = string.Empty;
                byte[] dataStream = new byte[streamSize];
                try
                {
                    ReadStream(ref dataStream);
                    retValue = Common.DataFormat.GetStringFromBytes(dataStream);
                }
                catch (Exception) { };
                return retValue;
            }

            public void DisposeReader()
            {
                if (viewStream != null)
                {
                    viewStream.Close();
                }
                if (memoryMap != null)
                {
                    memoryMap.Dispose();
                }
            }
        }
    }
}
