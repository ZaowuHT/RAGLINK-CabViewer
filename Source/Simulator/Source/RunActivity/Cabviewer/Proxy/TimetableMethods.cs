using Orts.Formats.Msts;
using Orts.Simulation.Physics;
using Orts.Simulation.RollingStocks;
using Orts.Simulation.Timetables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Orts.Viewer3D.Popups;
using ORTS.Common;

namespace Orts.Cabviewer.Proxy
{
    public class TimetableMethods
    {
        static public Train serviceTrain = null;
        static public List<Train> trainList = new List<Train>();
        public delegate void TimetableUpdated();
        static public event TimetableUpdated TimetableUpdatedEvent;

        static public void UpdateTimetable(Train _serviceTrain, 
            List<Train> _trainList)
        {
            try
            {
                if (_serviceTrain == null || _trainList == null) return;
                serviceTrain = _serviceTrain;
                trainList = _trainList;
                foreach (Train _obj in trainList) UpdateTrainActualTime(_obj);
                TimetableUpdatedEvent?.Invoke();
            }
            catch (Exception) { };
        }

        public class StopInformation
        {
            public string Name;
            public int Passed;
            public int SideLeft;
            public int SideRight;
            public string ArriveScheduled;
            public string ArriveActual;
            public string DepartScheduled;
            public string DepartActual;
            public float Distance;

            public StopInformation()
            {
                Name = string.Empty;
                Passed = 0;
                SideLeft = 0;
                SideRight = 0;
                ArriveScheduled = string.Empty;
                ArriveActual = string.Empty;
                DepartScheduled = string.Empty;
                DepartActual = string.Empty;
                Distance = 0f;
            }
        };

        static public void UpdateTrainActualTime(Train _train)
        {
            DateTime timeRef = new DateTime(0);
            if (_train.PreviousStop != null)
            {
                if (_train.previousStationName != _train.PreviousStop.PlatformItem.Name)
                {
                    _train.previousStationName = _train.PreviousStop.PlatformItem.Name;
                    _train.PreviousStop.ActualDepart =
                        (int)((SimulatorMethods.GetCurrentTime().Ticks - timeRef.Ticks) /
                        (long)Math.Pow(10, 7));
                }
            }
            if (_train.StationStops.Count >= 1)
            {
                if (_train.CheckStationPosition(_train.StationStops[0].PlatformItem,
                    _train.StationStops[0].Direction, _train.StationStops[0].TCSectionIndex)
                    && _train.StationStops[0].ActualArrival < 0)
                {
                    _train.StationStops[0].ActualArrival =
                        (int)((SimulatorMethods.GetCurrentTime().Ticks - timeRef.Ticks) /
                        (long)Math.Pow(10, 7));
                }
            }
        }

        static public int GetTrainStopCount()
        {
            int retValue = 0;
            try
            {
                retValue = serviceTrain.StationStops.Count;
            }
            catch (Exception) { };
            return retValue;
        }

        static public StopInformation GetPreviousStopInfo(Train _train)
        {
            StopInformation retValue = new StopInformation();
            try
            {
                if (_train.PreviousStop != null)
                {
                    retValue.Name = _train.PreviousStop.PlatformItem.Name;
                    retValue.Passed = _train.PreviousStop.Passed ? 1 : 0;
                    retValue.SideLeft = _train.PreviousStop.PlatformItem.PlatformSide[0] ? 1 : 0;
                    retValue.SideRight = _train.PreviousStop.PlatformItem.PlatformSide[1] ? 1 : 0;
                    retValue.Distance = _train.PreviousStop.DistanceToTrainM;
                    retValue.ArriveScheduled = _train.PreviousStop.arrivalDT.ToString("HH:mm:ss");
                    retValue.DepartScheduled = _train.PreviousStop.departureDT.ToString("HH:mm:ss");
                    if (_train.PreviousStop.ActualArrival >= 0)
                    {
                        DateTime actArrDT = new DateTime((long)(Math.Pow(10, 7) * _train.PreviousStop.ActualArrival));
                        retValue.ArriveActual = actArrDT.ToString("HH:mm:ss");
                    }
                    if (_train.PreviousStop.ActualDepart >= 0)
                    {
                        DateTime actDepDT = new DateTime((long)(Math.Pow(10, 7) * _train.PreviousStop.ActualDepart));
                        retValue.DepartActual = actDepDT.ToString("HH:mm:ss");
                    }
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public StopInformation GetCurrentStopInfo(Train _train)
        {
            StopInformation retValue = new StopInformation();
            try
            {
                retValue = GetStopInfo(_train, 0);
            }
            catch (Exception) { };
            return retValue;
        }

        static public StopInformation GetNextStopInfo(Train _train)
        {
            StopInformation retValue = new StopInformation();
            try
            {
                retValue = GetStopInfo(_train, 1);
            }
            catch (Exception) { };
            return retValue;
        }

        static public StopInformation GetStopInfo(Train _train, int _index)
        {
            StopInformation retValue = new StopInformation();
            try
            {
                if (_train.StationStops.Count >= _index + 1)
                {
                    retValue.Name = _train.StationStops[_index].PlatformItem.Name;
                    retValue.Passed = _train.StationStops[_index].Passed ? 1 : 0;
                    retValue.SideLeft = _train.StationStops[_index].PlatformItem.PlatformSide[0] ? 1 : 0;
                    retValue.SideRight = _train.StationStops[_index].PlatformItem.PlatformSide[1] ? 1 : 0;
                    retValue.Distance = _train.StationStops[_index].DistanceToTrainM;
                    retValue.ArriveScheduled = _train.StationStops[_index].arrivalDT.ToString("HH:mm:ss");
                    retValue.DepartScheduled = _train.StationStops[_index].departureDT.ToString("HH:mm:ss");
                    if (_train.StationStops[_index].ActualArrival >= 0)
                    {
                        DateTime actArrDT = new DateTime((long)(Math.Pow(10, 7) * _train.StationStops[1].ActualArrival));
                        retValue.ArriveActual = actArrDT.ToString("HH:mm:ss");
                    }
                    if (_train.StationStops[_index].ActualDepart >= 0)
                    {
                        DateTime actDepDT = new DateTime((long)(Math.Pow(10, 7) * _train.StationStops[1].ActualDepart));
                        retValue.DepartActual = actDepDT.ToString("HH:mm:ss");
                    }
                }
            }
            catch (Exception) { };
            return retValue;
        }
    }
}
