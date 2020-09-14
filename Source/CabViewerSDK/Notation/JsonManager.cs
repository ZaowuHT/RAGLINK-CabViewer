using CabViewerSDK.Json;
using System;
using System.IO;
using System.Text;

namespace CabViewerSDK.Notation
{
    public class JsonManager
    {
        static public T GetObjectFromJsonString<T>(string stringJson)
        {
            T retValue = default(T);
            try
            {
                retValue = JSON.ToObject<T>(stringJson);
            }
            catch (Exception) { };
            return retValue;
        }

        static public T GetObjectFromJsonFile<T>(string pathJson)
        {
            T retValue = default(T);
            try
            {
                if (File.Exists(pathJson))
                    retValue = GetObjectFromJsonString<T>(
                        File.ReadAllText(pathJson, Encoding.UTF8));
            }
            catch (Exception) { };
            return retValue;
        }

        static public T GetObjectFromMemory<T>(string memoryMapName, int streamSize)
        {
            T retValue = default(T);
            try
            {
                Communication.MemoryMap.MemoryMapReader _reader =
                    new Communication.MemoryMap.MemoryMapReader(memoryMapName, streamSize);
                retValue = GetObjectFromJsonString<T>(
                    _reader.ReadStream());
                _reader.DisposeReader();
            }
            catch (Exception) { };
            return retValue;
        }

        static public string WriteJsonToString<T>(T _obj, bool _beautify)
        {
            string retValue = string.Empty;
            try
            {
                JSONParameters _parameters = new JSONParameters();
                _parameters.UseExtensions = false;
                retValue = _beautify ? JSON.ToNiceJSON(_obj, _parameters) : JSON.ToJSON(_obj, _parameters);
            }
            catch (Exception) { };
            return retValue;
        }

        static public string WriteJsonToFile<T>(T _obj, 
            string _filename, bool _beautify)
        {
            string retValue = string.Empty;
            try
            {
                JSONParameters _parameters = new JSONParameters();
                _parameters.UseExtensions = false;
                retValue = WriteJsonToString(_obj, _beautify);
                if (retValue != string.Empty)
                {
                    FileInfo _fileinfo = new FileInfo(_filename);
                    if (!_fileinfo.Directory.Exists) _fileinfo.Directory.Create();
                    if (File.Exists(_filename)) File.Delete(_filename);
                    File.WriteAllText(_filename, retValue);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public int WriteJsonToMemory<T>(T _obj, string memoryMapName, bool _beautify)
        {
            int retValue = 0;
            try
            {
                JSONParameters _parameters = new JSONParameters();
                _parameters.UseExtensions = false;
                Communication.MemoryMap.MemoryMapWriter _writer =
                    new Communication.MemoryMap.MemoryMapWriter(memoryMapName,
                    _beautify ? JSON.ToNiceJSON(_obj, _parameters) : JSON.ToJSON(_obj, _parameters));
                retValue = _writer.GetStreamLength();
                _writer.WriteStream();
            }
            catch (Exception) { };
            return retValue;
        }
    }
}
