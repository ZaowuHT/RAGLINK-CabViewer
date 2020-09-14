using Orts.Simulation;
using Orts.Viewer3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orts.Cabviewer.Proxy
{
    public class SimulatorMethods
    {
        static public bool GetSimulatorRunState()
        {
            bool retValue = false;
            try
            {
                if (TrainMethods.serviceLocomotive == null ||
                    TimetableMethods.serviceTrain == null)
                    retValue = false;
                else retValue = true;
            }
            catch (Exception) { };
            return retValue;
        }

        static public DateTime GetCurrentTime()
        {
            DateTime retValue = new DateTime(0);
            try
            {
                retValue = retValue.AddSeconds(Program.Simulator.ClockTime);
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetPauseValue()
        {
            int retValue = 0;
            try
            {
                retValue = Program.Simulator.Paused ? 1 : 0;
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetQuitOrderValue()
        {
            int retValue = 0;
            try
            {
                retValue = Program.Viewer.ActivityWindow.Activity.IsComplete ? 1 : 0;
            }
            catch (Exception) { };
            return retValue;
        }

        static public long GetSimulatorTime()
        {
            long retValue = 0;
            try
            {
                retValue = (long) Program.Simulator.GameTime;
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetSimulatorSeason()
        {
            int retValue = 0;
            try
            {
                retValue = (int)Program.Simulator.WeatherType;
            }
            catch (Exception) { };
            return retValue;
        }

        static public int GetSimulatorWeather()
        {
            int retValue = 0;
            try
            {
                retValue = (int)Program.Simulator.WeatherType;
            }
            catch (Exception) { };
            return retValue;
        }

        public class WeatherDetail
        {
            public float WindDirection;
            public float FogDistance;
            public float OvercastFactor;
            public float PrecipitationLiquidity;
            public float PricipitationIntensity;
            public float WindSpeed;
            public float InsideTemperature;
            public float OutsideTemperature;

            public WeatherDetail() { }
        };

        static public WeatherDetail GetSimulatorWeatherDetail()
        {
            WeatherDetail retValue = new WeatherDetail();
            try
            {
                retValue.WindDirection = Program.Simulator.Weather.WindDirection;
                retValue.FogDistance = Program.Simulator.Weather.FogDistance;
                retValue.OvercastFactor = Program.Simulator.Weather.OvercastFactor;
                retValue.PrecipitationLiquidity = Program.Simulator.Weather.PrecipitationLiquidity;
                retValue.PricipitationIntensity = Program.Simulator.Weather.PricipitationIntensityPPSPM2;
                retValue.WindSpeed = Program.Simulator.Weather.WindSpeed;
                retValue.InsideTemperature = Program.Viewer.PlayerTrain.TrainInsideTempC;
                retValue.OutsideTemperature = Program.Viewer.PlayerTrain.TrainOutsideTempC;
            }
            catch (Exception) { };
            return retValue;
        }
    }
}
