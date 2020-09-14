using Orts.Common;
using Orts.Formats.Msts;
using Orts.Simulation;
using Orts.Simulation.Physics;
using Orts.Simulation.RollingStocks;
using Orts.Viewer3D;
using Orts.Viewer3D.Popups;
using ORTS.Scripting.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orts.Cabviewer.Proxy
{
    public class TrainMethods
    {
        static public Train serviceTrain = null;
        static public MSTSLocomotive serviceLocomotive = null;
        static public List<Train> trainList = new List<Train>();
        public delegate void TrainUpdated();
        static public event TrainUpdated TrainUpdatedEvent;

        static public void UpdateTrains(Train _serviceTrain, 
            TrainCar _serviceLocomotive, List<Train> _trainList)
        {
            try
            {
                if (_serviceTrain == null || _serviceLocomotive == null
                    || _trainList == null) return;
                serviceTrain = _serviceTrain;
                serviceLocomotive = (MSTSLocomotive) _serviceLocomotive;
                trainList = _trainList;
                TrainUpdatedEvent?.Invoke();
            }
            catch (Exception) { };
        }

        static public MSTSLocomotive GetTrainLeadLocomotive(Train _train)
        {
            MSTSLocomotive leadLocomotive = null;
            try
            {
                leadLocomotive = (MSTSLocomotive) _train.LeadLocomotive;
            }
            catch (Exception) { };
            return leadLocomotive;
        }

        // Get & Set For Data

        // Commons
        static public float GetSpeedOmeter(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.Units = CABViewControlUnits.KM_PER_HOUR;
                virtualControl.ControlType = CABViewControlTypes.SPEEDOMETER;
                retValue = _locomotive.GetDataOf(virtualControl) / 3.6f;
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetSpeedProjected(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.Units = CABViewControlUnits.KM_PER_HOUR;
                virtualControl.ControlType = CABViewControlTypes.SPEED_PROJECTED;
                retValue = _locomotive.GetDataOf(virtualControl) / 3.6f;
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetAccelerometer(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.Units = CABViewControlUnits.METRES_SEC_SEC;
                virtualControl.ControlType = CABViewControlTypes.ACCELEROMETER;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetAmmeter(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.MinValue = -1 * _locomotive.MaxCurrentA;
                virtualControl.MaxValue = _locomotive.MaxCurrentA;
                virtualControl.ControlType = CABViewControlTypes.AMMETER_ABS;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetLoadMeter(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.MinValue = -1 * _locomotive.MaxCurrentA;
                virtualControl.MaxValue = _locomotive.MaxCurrentA;
                virtualControl.ControlType = CABViewControlTypes.LOAD_METER;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetTractionBrakingAmps(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.MinValue = 0;
                virtualControl.MaxValue = _locomotive.MaxCurrentA;
                virtualControl.Units = CABViewControlUnits.AMPS;
                virtualControl.ControlType = CABViewControlTypes.TRACTION_BRAKING;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetTractionBrakingForce(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.Units = CABViewControlUnits.NEWTONS;
                virtualControl.ControlType = CABViewControlTypes.TRACTION_BRAKING;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetDynamicBrakeAmps(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.MinValue = -1 * _locomotive.MaxCurrentA;
                virtualControl.MaxValue = _locomotive.MaxCurrentA;
                virtualControl.Units = CABViewControlUnits.AMPS;
                virtualControl.ControlType = CABViewControlTypes.DYNAMIC_BRAKE_FORCE;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetDynamicBrakeForce(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.MinValue = -1 * _locomotive.MaxDynamicBrakeForceN;
                virtualControl.MaxValue = _locomotive.MaxDynamicBrakeForceN;
                virtualControl.Units = CABViewControlUnits.NEWTONS;
                virtualControl.ControlType = CABViewControlTypes.DYNAMIC_BRAKE_FORCE;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetMainResPressure(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.Units = CABViewControlUnits.KILOPASCALS;
                virtualControl.ControlType = CABViewControlTypes.MAIN_RES;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetBrakePipePressure(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.Units = CABViewControlUnits.KILOPASCALS;
                virtualControl.ControlType = CABViewControlTypes.BRAKE_PIPE;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetEQResPressure(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.Units = CABViewControlUnits.KILOPASCALS;
                virtualControl.ControlType = CABViewControlTypes.EQ_RES;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetBrakeCylPressure(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.Units = CABViewControlUnits.KILOPASCALS;
                virtualControl.ControlType = CABViewControlTypes.BRAKE_CYL;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetVacuumReservoirPressure(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.Units = CABViewControlUnits.KILOPASCALS;
                virtualControl.ControlType = CABViewControlTypes.VACUUM_RESERVOIR_PRESSURE;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetDieselEngineRPM(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSDieselLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.RPM;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetDieselEngineTemperature(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                if (_locomotive is MSTSDieselLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.ORTS_DIESEL_TEMPERATURE;
                    retValue = _locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetDieselEngineOilPresssure(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                if (_locomotive is MSTSDieselLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.ORTS_OIL_PRESSURE;
                    retValue = _locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetThrottleValue(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.THROTTLE;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        // Throttle Start
        static public int GetThrottleNotch(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                retValue = _locomotive.ThrottleController.CurrentNotch;
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetThrottleValue(MSTSLocomotive _locomotive, float _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.SetThrottleValue(_value);
            }
            catch (Exception) { };
        }
        // Throttle End

        // EngineBrake Start
        static public float GetEngineBrakeValue(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.ENGINE_BRAKE;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetEngineBrakeNotch(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                retValue = _locomotive.EngineBrakeController.CurrentNotch;
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetEngineBrakeValue(MSTSLocomotive _locomotive, float _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.SetEngineBrakeValue(_value);
            }
            catch (Exception) { };
        }
        // EngineBrake End

        // TrainBrake Start
        static public float GetTrainBrakeValue(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.TRAIN_BRAKE;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetTrainBrakeNotch(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                retValue = _locomotive.TrainBrakeController.CurrentNotch;
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetTrainBrakeValue(MSTSLocomotive _locomotive, float _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.SetTrainBrakeValue(_value);
            }
            catch (Exception) { };
        }
        // TrainBrake End

        // DynamicBrake Start
        static public float GetDynamicBrakeValue(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.DYNAMIC_BRAKE;
                retValue = _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetDynamicBrakeNotch(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                retValue = _locomotive.DynamicBrakeController.CurrentNotch;
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetDynamicBrakeValue(MSTSLocomotive _locomotive, float _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.SetDynamicBrakeValue(_value);
            }
            catch (Exception) { };
        }
        // DynamicBrake End

        // HandBrake Start
        static public int GetHandBrakeValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                retValue = _locomotive.HandBrakePresent ? 1 : 0;
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetHandBrakeValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.SetTrainHandbrake(_value == 1 ? true : false);
            }
            catch (Exception) { };
        }
        // HandBrake End

        // Wipers Start
        static public int GetWipersValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.WIPERS;
                retValue = (int) _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetWipersValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.Train.SignalEvent(_value == 1 ? Common.Event.WiperOn : Common.Event.WiperOff);
            }
            catch (Exception) { };
        }
        // Wipers End

        // Horn Start
        static public int GetHornValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.HORN;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetHornValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.Train.SignalEvent(_value == 1 ? Common.Event.HornOn : Common.Event.HornOff);
            }
            catch (Exception) { };
        }
        // Horn End

        // Bell Start
        static public int GetBellValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.BELL;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetBellValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.Train.SignalEvent(_value == 1 ? Common.Event.BellOn : Common.Event.BellOff);
            }
            catch (Exception) { };
        }
        // Bell End

        // ResetButton Start
        static public int GetResetButtonValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.RESET;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetResetButtonValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.TrainControlSystem.AlerterPressed(_value == 1 ? true : false);
            }
            catch (Exception) { };
        }
        // ResetButton End

        // AlerterReset Start
        static public int GetAlerterValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.ALERTER_DISPLAY;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetAlerterValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                if (_value ==  1)
                    _locomotive.TrainControlSystem.AlerterReset();
            }
            catch (Exception) { };
        }
        // AlerterReset End

        static public int GetOverspeedValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.OVERSPEED;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetPenaltyBrakeValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.PENALTY_APP;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        // EmergencyBrake Start
        static public int GetEmergencyBrakeValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.EMERGENCY_BRAKE;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetEmergencyBrakeValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.SetEmergency(_value == 1 ? true : false);
            }
            catch (Exception) { };
        }
        // EmergencyBrake End

        // Sander Start
        static public int GetSanderValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl0 = new CabViewControl();
                virtualControl0.ControlType = CABViewControlTypes.SANDERS;
                CabViewControl virtualControl1 = new CabViewControl();
                virtualControl1.ControlType = CABViewControlTypes.SANDING;
                retValue = (int)_locomotive.GetDataOf(virtualControl0) |
                    (int)_locomotive.GetDataOf(virtualControl1);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetSanderValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 1 ? 1 : _value);
                _locomotive.SignalEvent(_value == 1 ? Common.Event.SanderOn : Common.Event.SanderOff);
            }
            catch (Exception) { };
        }
        // Sander End

        // Headlight Start
        static public int GetHeadlightValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.FRONT_HLIGHT;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetHeadlightValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 2 ? 2 : _value);
                _locomotive.SignalEvent(_value == 0 ? Common.Event._HeadlightOff : 
                    (_value == 1 ? Common.Event._HeadlightDim : Common.Event._HeadlightOn));
            }
            catch (Exception) { };
        }
        // Headlight End

        static public int GetWheelslipValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.WHEELSLIP;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        // Reverser Start
        static public int GetDirectionValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.DIRECTION;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetDirectionValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _value = _value < 0 ? 0 : (_value > 2 ? 2 : _value);
                _locomotive.SetDirection(_value == 0 ? ORTS.Common.Direction.Reverse :
                    (_value == 1 ? ORTS.Common.Direction.N : ORTS.Common.Direction.Forward));
            }
            catch (Exception) { };
        }
        // Reverser End

        static public int GetNextSignalAspectValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.ASPECT_DISPLAY;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetSpeedLimit(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.Units = CABViewControlUnits.KM_PER_HOUR;
                virtualControl.ControlType = CABViewControlTypes.SPEEDLIMIT;
                retValue = (int) _locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetNextSpeedLimit(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                retValue = (int) (_locomotive.TrainControlSystem.NextSpeedLimitMpS * 3.6f);
            }
            catch (Exception) { };
            return retValue;
        }

        // DieselGearbox Start
        static public int GetDieselGearboxValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSDieselLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.GEARS_DISPLAY;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetDieselGearboxValue(MSTSLocomotive _locomotive, float _value)
        {
            try
            {
                if (_locomotive is MSTSDieselLocomotive)
                    _locomotive.SetGearBoxValue(_value);
            }
            catch (Exception) { };
        }
        // DieselGearbox End

        // CabRadio Start
        static public int GetCabRadioValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.CAB_RADIO;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetCabRadioValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _locomotive.ToggleCabRadio(_value == 1 ? true : false);
            }
            catch (Exception) { };
        }
        // CabRadio End

        // ServiceDieselEngine Start
        static public int GetServiceDieselEngineState(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSDieselLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.ORTS_PLAYER_DIESEL_ENGINE_STATE;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetServiceDieselEngineState(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                if (_locomotive is MSTSDieselLocomotive)
                {
                    ((MSTSDieselLocomotive) _locomotive).SetPower(_value == 1 ? true : false);
                }
            }
            catch (Exception) { };
        }
        // ServiceDieselEngine End

        static public int GetHelpersDieselEngineState(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSDieselLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.ORTS_HELPERS_DIESEL_ENGINES;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        // Cablight Start
        static public int GetCablightValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.ORTS_CABLIGHT;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetCablightState(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                if (_locomotive.CabLightOn != (_value == 1 ? true : false))
                    _locomotive.ToggleCabLight();
            }
            catch (Exception) { };
        }
        // Cablight End

        // LeftDoor Start
        static public int GetLeftDoorValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.ORTS_LEFTDOOR;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetLeftDoorValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                if (_locomotive.DoorLeftOpen != (_value == 1 ? true : false))
                    _locomotive.ToggleDoorsLeft();
            }
            catch (Exception) { };
        }
        // LeftDoor End

        // RightDoor Start
        static public int GetRightDoorValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.ORTS_RIGHTDOOR;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetRightDoorValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                if (_locomotive.DoorRightOpen != (_value == 1 ? true : false))
                    _locomotive.ToggleDoorsRight();
            }
            catch (Exception) { };
        }
        // RightDoor End

        // Visor Start
        static public int GetVisorValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                CabViewControl virtualControl = new CabViewControl();
                virtualControl.ControlType = CABViewControlTypes.ORTS_MIRRORS;
                retValue = (int)_locomotive.GetDataOf(virtualControl);
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetVisorValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                if (_locomotive.MirrorOpen != (_value == 1 ? true : false))
                    _locomotive.ToggleMirrors();
            }
            catch (Exception) { };
        }
        // Visor End

        static public float GetLineVoltage(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                if (_locomotive is MSTSElectricLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.LINE_VOLTAGE;
                    retValue = _locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        // Pantograph Start
        static public int GetPantographValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSElectricLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.PANTO_DISPLAY;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetPantograph1Value(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSElectricLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.PANTOGRAPH;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetPantograph1Value(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _locomotive.SignalEvent(_value == 1 ? Common.Event.Pantograph1Up : Common.Event.Pantograph1Down);
            }
            catch (Exception) { };
        }

        static public int GetPantograph2Value(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSElectricLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.PANTOGRAPH2;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetPantograph2Value(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _locomotive.SignalEvent(_value == 1 ? Common.Event.Pantograph2Up : Common.Event.Pantograph2Up);
            }
            catch (Exception) { };
        }
        // Pantograph End

        // Breaker Start
        static public int GetCircuitBreakerOrderClosingValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSElectricLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.ORTS_CIRCUIT_BREAKER_DRIVER_CLOSING_ORDER;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetCircuitBreakerOrderClosingValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _locomotive.Train.SignalEvent(_value == 1 ? PowerSupplyEvent.CloseCircuitBreaker : 
                    PowerSupplyEvent.OpenCircuitBreaker);
            }
            catch (Exception) { };
        }

        static public void SetCircuitBreakerOrderClosingButtonPressedValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _locomotive.Train.SignalEvent(_value == 1 ? PowerSupplyEvent.CloseCircuitBreakerButtonPressed : 
                    PowerSupplyEvent.CloseCircuitBreakerButtonReleased);
            }
            catch (Exception) { };
        }

        static public int GetCircuitBreakerOrderOpeningValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSElectricLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.ORTS_CIRCUIT_BREAKER_DRIVER_OPENING_ORDER;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetCircuitBreakerOrderOpeningValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _locomotive.Train.SignalEvent(_value == 1 ? PowerSupplyEvent.OpenCircuitBreaker : 
                    PowerSupplyEvent.CloseCircuitBreaker);
            }
            catch (Exception) { };
        }

        static public void SetCircuitBreakerOrderOpenButtonPressedValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _locomotive.Train.SignalEvent(_value == 1 ? PowerSupplyEvent.OpenCircuitBreakerButtonPressed :
                    PowerSupplyEvent.OpenCircuitBreakerButtonReleased);
            }
            catch (Exception) { };
        }

        static public int GetCircuitBreakerClosingAuthValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSElectricLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.ORTS_CIRCUIT_BREAKER_DRIVER_CLOSING_AUTHORIZATION;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetCircuitBreakerClosingAuthValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _locomotive.Train.SignalEvent(_value == 1 ? PowerSupplyEvent.GiveCircuitBreakerClosingAuthorization :
                    PowerSupplyEvent.RemoveCircuitBreakerClosingAuthorization);
            }
            catch (Exception) { };
        }

        static public int GetCircuitBreakerValue(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSElectricLocomotive)
                {
                    CabViewControl virtualControl = new CabViewControl();
                    virtualControl.ControlType = CABViewControlTypes.ORTS_CIRCUIT_BREAKER_STATE;
                    retValue = (int)_locomotive.GetDataOf(virtualControl);
                }
            }
            catch (Exception) { };
            return retValue;
        }

        static public void SetCircuitBreakerValue(MSTSLocomotive _locomotive, int _value)
        {
            try
            {
                _locomotive.Train.SignalEvent(_value == 1 ? PowerSupplyEvent.OpenCircuitBreaker :
                    PowerSupplyEvent.CloseCircuitBreaker);
            }
            catch (Exception) { };
        }
        // Brake End

        static public float GetNextSignalDistance(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                retValue = _locomotive.Train.distanceToSignal;
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetDistanceTravelled(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                retValue = _locomotive.Train.DistanceTravelledM;
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetTrainWeight(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                retValue = _locomotive.Train.MassKg ;
            }
            catch (Exception) { };
            return retValue;
        }

        static public float GetTrainLength(MSTSLocomotive _locomotive)
        {
            float retValue = 0f;
            try
            {
                retValue = _locomotive.Train.Length;
            }
            catch (Exception) { };
            return retValue;
        }

        static public string GetTrainName(MSTSLocomotive _locomotive)
        {
            string retValue = string.Empty;
            try
            {
                retValue = _locomotive.Train.Name;
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetLocomotiveType(MSTSLocomotive _locomotive)
        {
            int retValue = 0;
            try
            {
                if (_locomotive is MSTSElectricLocomotive)
                    retValue = 1;
            }
            catch (Exception) { };
            return retValue;
        }
    }
}
