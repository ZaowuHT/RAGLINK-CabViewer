using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace CabViewerSDK.Communication
{
    public class SerialManager
    {
        public enum SerialDeviceState
        { OFFLINE = 0, IDLE = 1, COMMUNICATING = 2 };

        public enum StreamMode
        { STRING = 0, BYTE = 1 };

        private List<string> serialDeviceName;
        private List<string> serialDevicePort;
        private List<int> serialDeviceBaudrate;
        private List<SerialPort> serialPort;
        private List<StreamMode> serialDeviceStreamMode;
        private List<SerialDeviceState> serialDeviceState;
        
        public class SerialEventManager<T>
        {
            public delegate void SerialRecieved(T _payload);
            public event SerialRecieved serialRecievedEvent;

            public SerialEventManager(SerialRecieved _callback)
            {
                AddCallBack(_callback);
            }

            public void AddCallBack(SerialRecieved _callback)
            {
                try
                {
                    serialRecievedEvent += _callback;
                }
                catch (Exception) { };
            }


            public void DeleteCallBack(SerialRecieved _callback)
            {
                try
                {
                    serialRecievedEvent -= _callback;
                }
                catch (Exception) { };
            }

            public void Invoke(T _payload)
            {
                serialRecievedEvent?.Invoke(_payload);
            }
        };

        public List<object> serialRecievedEvent;

        public SerialManager()
        {
            serialDeviceName = new List<string>();
            serialDevicePort = new List<string>();
            serialDeviceBaudrate = new List<int>();
            serialPort = new List<SerialPort>();
            serialDeviceState = new List<SerialDeviceState>();
            serialRecievedEvent = new List<object>();
            serialDeviceStreamMode = new List<StreamMode>();
        }

        public int GetSerialDeviceIndexByName(string _name)
        {
            int retValue = -1;
            try
            {
                retValue = serialDeviceName.IndexOf(_name);
            }
            catch (Exception) { };
            return retValue;
        }

        public int GetSerialDeviceIndexByPort(string _port)
        {
            int retValue = -1;
            try
            {
                retValue = serialDevicePort.IndexOf(_port);
            }
            catch (Exception) { };
            return retValue;
        }

        public int AddSerialDevice(string _name, string _port, 
            int _baud, SerialEventManager<byte>.SerialRecieved _callback)
        {
            int retValue = -1;
            try
            {
                retValue = GetSerialDeviceIndexByPort(_port);
                if (GetSerialDeviceIndexByName(_name) == -1 &&
                    retValue == -1)
                {
                    serialDeviceName.Add(_name);
                    serialDevicePort.Add(_port);
                    serialDeviceBaudrate.Add(_baud);
                    SerialEventManager<byte> _event = new SerialEventManager<byte>(_callback);
                    serialRecievedEvent.Add(_event);
                    SerialPort _serial = new SerialPort(_port, _baud);
                    _serial.DataReceived +=
                        new SerialDataReceivedEventHandler((sender, e) =>
                        {
                            while (((SerialPort)sender).BytesToRead > 0)
                                _event.Invoke((byte)((SerialPort)sender).ReadByte());
                        });
                    _serial.ReadBufferSize = 8192;
                    _serial.WriteBufferSize = 8192;
                    serialPort.Add(_serial);
                    serialDeviceStreamMode.Add(StreamMode.BYTE);
                    serialDeviceState.Add(SerialDeviceState.OFFLINE);
                    retValue = serialDevicePort.Count - 1;
                }
            }
            catch (Exception) { };
            return retValue;
        }

        public int AddSerialDevice(string _name, string _port,
            int _baud, SerialEventManager<string>.SerialRecieved _callback)
        {
            int retValue = -1;
            try
            {
                retValue = GetSerialDeviceIndexByPort(_port);
                if (GetSerialDeviceIndexByName(_name) == -1 &&
                    retValue == -1)
                {
                    serialDeviceName.Add(_name);
                    serialDevicePort.Add(_port);
                    serialDeviceBaudrate.Add(_baud);
                    SerialEventManager<string> _event = new SerialEventManager<string>(_callback);
                    serialRecievedEvent.Add(_event);
                    SerialPort _serial = new SerialPort(_port, _baud);
                    _serial.DataReceived +=
                        new SerialDataReceivedEventHandler((sender, e) =>
                        {
                            while (((SerialPort)sender).BytesToRead > 0)
                                _event.Invoke(((SerialPort)sender).ReadExisting());
                        });
                    _serial.ReadBufferSize = 8192;
                    _serial.WriteBufferSize = 8192;
                    serialPort.Add(_serial);
                    serialDeviceStreamMode.Add(StreamMode.STRING);
                    serialDeviceState.Add(SerialDeviceState.OFFLINE);
                    retValue = serialDevicePort.Count - 1;
                }
            }
            catch (Exception) { };
            return retValue;
        }

        public bool DeleteSerialDevice(int _index)
        {
            bool retValue = false;
            try
            {
                if (_index >=0 && _index < serialPort.Count)
                {
                    if (serialPort[_index].IsOpen) serialPort[_index].Close();
                    serialDeviceName.RemoveAt(_index);
                    serialDevicePort.RemoveAt(_index);
                    serialDeviceBaudrate.RemoveAt(_index);
                    serialRecievedEvent.RemoveAt(_index);
                    serialPort.RemoveAt(_index);
                    serialDeviceStreamMode.RemoveAt(_index);
                    serialDeviceState.RemoveAt(_index);
                    retValue = true;
                }
            }
            catch (Exception) { };
            return retValue;
        }
    }
}
