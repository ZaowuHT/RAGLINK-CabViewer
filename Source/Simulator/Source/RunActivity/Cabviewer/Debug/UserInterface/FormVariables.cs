using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CabViewerSDK.UI;
using CabViewerSDK.UI.Controls;
using CabViewerSDK.UI.Forms;
using Orts.Cabviewer.Proxy;
using static Orts.Cabviewer.Proxy.TimetableMethods;

namespace Orts.Cabviewer.Debug
{
    public partial class FormVariables : DarkForm
    {
        public FormVariables()
        {
            InitializeComponent();
        }

        private void CreateVariableViewer()
        {
            try
            {
                listviewVariables.Invoke(new EventHandler(delegate
                {
                    // Class TrainMethods
                    DarkListItem itemTrainMethods = new DarkListItem();
                    itemTrainMethods.Text = "TrainMethods.";
                    listviewVariables.Items.Add(itemTrainMethods);

                    // SpeedOmeter
                    DarkListItem itemSpeed = new DarkListItem();
                    itemSpeed.Text = " SpeedOmeter = 0 [Float][R]";
                    listviewVariables.Items.Add(itemSpeed);

                    // SpeedProjected
                    DarkListItem itemSpeedProjected = new DarkListItem();
                    itemSpeedProjected.Text = " SpeedProjected = 0 [Float][R]";
                    listviewVariables.Items.Add(itemSpeedProjected);

                    // Accelerometer
                    DarkListItem itemAccelerometer = new DarkListItem();
                    itemAccelerometer.Text = " Accelerometer = 0 [Float][R]";
                    listviewVariables.Items.Add(itemAccelerometer);

                    // Ammeter
                    DarkListItem itemAmmeter = new DarkListItem();
                    itemAmmeter.Text = " Ammeter = 0 [Float][R]";
                    listviewVariables.Items.Add(itemAmmeter);

                    // LoadMeter
                    DarkListItem itemLoadMeter = new DarkListItem();
                    itemLoadMeter.Text = " LoadMeter = 0 [Float][R]";
                    listviewVariables.Items.Add(itemLoadMeter);

                    // TractionBrakingAmps
                    DarkListItem itemTractionBrakingAmps = new DarkListItem();
                    itemTractionBrakingAmps.Text = " TractionBrakingAmps = 0 [Float][R]";
                    listviewVariables.Items.Add(itemTractionBrakingAmps);

                    // TractionBrakingForce
                    DarkListItem itemTractionBrakingForce = new DarkListItem();
                    itemTractionBrakingForce.Text = " TractionBrakingForce = 0 [Float][R]";
                    listviewVariables.Items.Add(itemTractionBrakingForce);

                    // DynamicBrakeAmps
                    DarkListItem itemDynamicBrakeAmps = new DarkListItem();
                    itemDynamicBrakeAmps.Text = " DynamicBrakeAmps = 0 [Float][R]";
                    listviewVariables.Items.Add(itemDynamicBrakeAmps);

                    // DynamicBrakeForce
                    DarkListItem itemDynamicBrakeForce = new DarkListItem();
                    itemDynamicBrakeForce.Text = " DynamicBrakeForce = 0 [Float][R]";
                    listviewVariables.Items.Add(itemDynamicBrakeForce);

                    // MainResPressure
                    DarkListItem itemMainResPressure = new DarkListItem();
                    itemMainResPressure.Text = " MainResPressure = 0 [Float][R]";
                    listviewVariables.Items.Add(itemMainResPressure);

                    // BrakePipePressure
                    DarkListItem itemBrakePipePressure = new DarkListItem();
                    itemBrakePipePressure.Text = " BrakePipePressure = 0 [Float][R]";
                    listviewVariables.Items.Add(itemBrakePipePressure);

                    // EQResPressure
                    DarkListItem itemEQResPressure = new DarkListItem();
                    itemEQResPressure.Text = " EQResPressure = 0 [Float][R]";
                    listviewVariables.Items.Add(itemEQResPressure);

                    // BrakeCylPressure
                    DarkListItem itemBrakeCylPressure = new DarkListItem();
                    itemBrakeCylPressure.Text = " BrakeCylPressure = 0 [Float][R]";
                    listviewVariables.Items.Add(itemBrakeCylPressure);

                    // VacuumReservoirPressure
                    DarkListItem itemVacuumReservoirPressure = new DarkListItem();
                    itemVacuumReservoirPressure.Text = " VacuumReservoirPressure = 0 [Float][R]";
                    listviewVariables.Items.Add(itemVacuumReservoirPressure);

                    // DieselEngineRPM
                    DarkListItem itemDieselEngineRPM = new DarkListItem();
                    itemDieselEngineRPM.Text = " DieselEngineRPM = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemDieselEngineRPM);

                    // DieselEngineTemperature
                    DarkListItem itemDieselEngineTemperature = new DarkListItem();
                    itemDieselEngineTemperature.Text = " DieselEngineTemperature = 0 [Float][R]";
                    listviewVariables.Items.Add(itemDieselEngineTemperature);

                    // DieselEngineOilPresssure
                    DarkListItem itemDieselEngineOilPresssure = new DarkListItem();
                    itemDieselEngineOilPresssure.Text = " DieselEngineOilPresssure = 0 [Float][R]";
                    listviewVariables.Items.Add(itemDieselEngineOilPresssure);

                    // ThrottleValue
                    DarkListItem itemThrottleValue = new DarkListItem();
                    itemThrottleValue.Text = " ThrottleValue = 0 [Float][R/W]";
                    listviewVariables.Items.Add(itemThrottleValue);

                    // EngineBrakeValue
                    DarkListItem itemEngineBrakeValue = new DarkListItem();
                    itemEngineBrakeValue.Text = " EngineBrakeValue = 0 [Float][R/W]";
                    listviewVariables.Items.Add(itemEngineBrakeValue);

                    // TrainBrakeValue
                    DarkListItem itemTrainBrakeValue = new DarkListItem();
                    itemTrainBrakeValue.Text = " TrainBrakeValue = 0 [Float][R/W]";
                    listviewVariables.Items.Add(itemTrainBrakeValue);

                    // DynamicBrakeValue
                    DarkListItem itemDynamicBrakeValue = new DarkListItem();
                    itemDynamicBrakeValue.Text = " DynamicBrakeValue = 0 [Float][R/W]";
                    listviewVariables.Items.Add(itemDynamicBrakeValue);

                    // WipersValue
                    DarkListItem itemWipersValue = new DarkListItem();
                    itemWipersValue.Text = " WipersValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemWipersValue);

                    // HornValue
                    DarkListItem itemHornValue = new DarkListItem();
                    itemHornValue.Text = " HornValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemHornValue);

                    // BellValue
                    DarkListItem itemBellValue = new DarkListItem();
                    itemBellValue.Text = " BellValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemBellValue);

                    // ResetButtonValue
                    DarkListItem itemResetButtonValue = new DarkListItem();
                    itemResetButtonValue.Text = " ResetButtonValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemResetButtonValue);

                    // AlerterValue
                    DarkListItem itemAlerterValue = new DarkListItem();
                    itemAlerterValue.Text = " AlerterValue = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemAlerterValue);

                    // OverspeedValue
                    DarkListItem itemOverspeedValue = new DarkListItem();
                    itemOverspeedValue.Text = " OverspeedValue = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemOverspeedValue);

                    // PenaltyBrakeValue
                    DarkListItem itemPenaltyBrakeValue = new DarkListItem();
                    itemPenaltyBrakeValue.Text = " PenaltyBrakeValue = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemPenaltyBrakeValue);

                    // EmergencyBrakeValue
                    DarkListItem itemEmergencyBrakeValue = new DarkListItem();
                    itemEmergencyBrakeValue.Text = " EmergencyBrakeValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemEmergencyBrakeValue);

                    // SanderValue
                    DarkListItem itemSanderValue = new DarkListItem();
                    itemSanderValue.Text = " SanderValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemSanderValue);

                    // HeadlightValue
                    DarkListItem itemHeadlightValue = new DarkListItem();
                    itemHeadlightValue.Text = " HeadlightValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemHeadlightValue);

                    // WheelslipValue
                    DarkListItem itemWheelslipValue = new DarkListItem();
                    itemWheelslipValue.Text = " WheelslipValue = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemWheelslipValue);

                    // DirectionValue
                    DarkListItem itemDirectionValue = new DarkListItem();
                    itemDirectionValue.Text = " DirectionValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemDirectionValue);

                    // NextSignalAspectValue
                    DarkListItem itemNextSignalAspectValue = new DarkListItem();
                    itemNextSignalAspectValue.Text = " NextSignalAspectValue = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemNextSignalAspectValue);

                    // SpeedLimit
                    DarkListItem itemSpeedLimit = new DarkListItem();
                    itemSpeedLimit.Text = " SpeedLimit = 0 [Float][R]";
                    listviewVariables.Items.Add(itemSpeedLimit);

                    // DieselGearboxValue
                    DarkListItem itemDieselGearboxValue = new DarkListItem();
                    itemDieselGearboxValue.Text = " DieselGearboxValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemDieselGearboxValue);

                    // CabRadioValue
                    DarkListItem itemCabRadioValue = new DarkListItem();
                    itemCabRadioValue.Text = " CabRadioValue = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemCabRadioValue);

                    // ServiceDieselEngineState
                    DarkListItem itemServiceDieselEngineState = new DarkListItem();
                    itemServiceDieselEngineState.Text = " ServiceDieselEngineState = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemServiceDieselEngineState);

                    // HelpersDieselEngineState
                    DarkListItem itemHelpersDieselEngineState = new DarkListItem();
                    itemHelpersDieselEngineState.Text = " HelpersDieselEngineState = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemHelpersDieselEngineState);

                    // CablightValue
                    DarkListItem itemCablightValue = new DarkListItem();
                    itemCablightValue.Text = " CablightValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemCablightValue);

                    // LeftDoorValue
                    DarkListItem itemLeftDoorValue = new DarkListItem();
                    itemLeftDoorValue.Text = " LeftDoorValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemLeftDoorValue);

                    // RightDoorValue
                    DarkListItem itemRightDoorValue = new DarkListItem();
                    itemRightDoorValue.Text = " RightDoorValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemRightDoorValue);

                    // VisorValue
                    DarkListItem itemVisorValue = new DarkListItem();
                    itemVisorValue.Text = " VisorValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemVisorValue);

                    // LineVoltage
                    DarkListItem itemLineVoltage = new DarkListItem();
                    itemLineVoltage.Text = " LineVoltage = 0 [Float][R]";
                    listviewVariables.Items.Add(itemLineVoltage);

                    // PantographValue
                    DarkListItem itemPantographValue = new DarkListItem();
                    itemPantographValue.Text = " PantographValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemPantographValue);

                    // Pantograph1Value
                    DarkListItem itemPantograph1Value = new DarkListItem();
                    itemPantograph1Value.Text = " Pantograph1Value = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemPantograph1Value);

                    // Pantograph2Value
                    DarkListItem itemPantograph2Value = new DarkListItem();
                    itemPantograph2Value.Text = " Pantograph2Value = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemPantograph2Value);

                    // CircuitBreakerOrderClosingValue
                    DarkListItem itemCircuitBreakerOrderClosingValue = new DarkListItem();
                    itemCircuitBreakerOrderClosingValue.Text = " CircuitBreakerOrderClosingValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemCircuitBreakerOrderClosingValue);

                    // CircuitBreakerOrderOpeningValue
                    DarkListItem itemCircuitBreakerOrderOpeningValue = new DarkListItem();
                    itemCircuitBreakerOrderOpeningValue.Text = " CircuitBreakerOrderOpeningValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemCircuitBreakerOrderOpeningValue);

                    // CircuitBreakerClosingAuthValue
                    DarkListItem itemCircuitBreakerClosingAuthValue = new DarkListItem();
                    itemCircuitBreakerClosingAuthValue.Text = " CircuitBreakerClosingAuthValue = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemCircuitBreakerClosingAuthValue);

                    // CircuitBreakerValue
                    DarkListItem itemCircuitBreakerValue = new DarkListItem();
                    itemCircuitBreakerValue.Text = " CircuitBreakerValue = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemCircuitBreakerValue);

                    // NextSignalDistance
                    DarkListItem itemNextSignalDistance = new DarkListItem();
                    itemNextSignalDistance.Text = " NextSignalDistance = 0 [Float][R]";
                    listviewVariables.Items.Add(itemNextSignalDistance);

                    // DistanceTravelled
                    DarkListItem itemDistanceTravelled = new DarkListItem();
                    itemDistanceTravelled.Text = " DistanceTravelled = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemDistanceTravelled);

                    // TrainWeight
                    DarkListItem itemTrainWeight = new DarkListItem();
                    itemTrainWeight.Text = " TrainWeight = 0 [Float][R]";
                    listviewVariables.Items.Add(itemTrainWeight);

                    // TrainLength
                    DarkListItem itemTrainLength = new DarkListItem();
                    itemTrainLength.Text = " TrainLength = 0 [Float][R]";
                    listviewVariables.Items.Add(itemTrainLength);

                    // TrainName
                    DarkListItem itemTrainName = new DarkListItem();
                    itemTrainName.Text = " TrainName = \"\" [String][R]";
                    listviewVariables.Items.Add(itemTrainName);

                    // LocomotiveType
                    DarkListItem itemLocomotiveType = new DarkListItem();
                    itemLocomotiveType.Text = " LocomotiveType = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemLocomotiveType);

                    // TimetableMethods.
                    DarkListItem itemTimetableMethods = new DarkListItem();
                    itemTimetableMethods.Text = "TimetableMethods.";
                    listviewVariables.Items.Add(itemTimetableMethods);

                    // TrainStopCount
                    DarkListItem itemTrainStopCount = new DarkListItem();
                    itemTrainStopCount.Text = " TrainStopCount = 0 [Int32][R]";
                    listviewVariables.Items.Add(itemTrainStopCount);

                    // PreviousStopInfo.
                    DarkListItem itemPreviousStopInfo = new DarkListItem();
                    itemPreviousStopInfo.Text = " PreviousStopInfo.";
                    listviewVariables.Items.Add(itemPreviousStopInfo);

                    // PreviousStopName
                    DarkListItem itemPreviousStopName = new DarkListItem();
                    itemPreviousStopName.Text = "  PreviousStopName = \"\" [String][R]";
                    listviewVariables.Items.Add(itemPreviousStopName);

                    // PreviousStopPassed
                    DarkListItem itemPreviousStopPassed = new DarkListItem();
                    itemPreviousStopPassed.Text = "  PreviousStopPassed = True [Int32][R]";
                    listviewVariables.Items.Add(itemPreviousStopPassed);

                    // PreviousStopSideLeft
                    DarkListItem itemPreviousStopSideLeft = new DarkListItem();
                    itemPreviousStopSideLeft.Text = "  PreviousStopSideLeft = True [Int32][R]";
                    listviewVariables.Items.Add(itemPreviousStopSideLeft);

                    // PreviousStopSideRight
                    DarkListItem itemPreviousStopSideRight = new DarkListItem();
                    itemPreviousStopSideRight.Text = "  PreviousStopSideRight = True [Int32][R]";
                    listviewVariables.Items.Add(itemPreviousStopSideRight);

                    // PreviousStopArriveScheduled
                    DarkListItem itemPreviousStopArriveScheduled = new DarkListItem();
                    itemPreviousStopArriveScheduled.Text = "  PreviousStopArriveScheduled = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemPreviousStopArriveScheduled);

                    // PreviousStopArriveActual
                    DarkListItem itemPreviousStopArriveActual = new DarkListItem();
                    itemPreviousStopArriveActual.Text = "  PreviousStopArriveActual = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemPreviousStopArriveActual);

                    // PreviousStopDepartScheduled
                    DarkListItem itemPreviousStopDepartScheduled = new DarkListItem();
                    itemPreviousStopDepartScheduled.Text = "  PreviousStopDepartScheduled = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemPreviousStopDepartScheduled);

                    // PreviousStopDepartActual
                    DarkListItem itemPreviousStopDepartActual = new DarkListItem();
                    itemPreviousStopDepartActual.Text = "  PreviousStopDepartActual = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemPreviousStopDepartActual);

                    // PreviousStopDistance
                    DarkListItem itemPreviousStopDistance = new DarkListItem();
                    itemPreviousStopDistance.Text = "  PreviousStopDistance = 0 [Float][R]";
                    listviewVariables.Items.Add(itemPreviousStopDistance);


                    // CurrentStopInfo.
                    DarkListItem itemCurrentStopInfo = new DarkListItem();
                    itemCurrentStopInfo.Text = " CurrentStopInfo.";
                    listviewVariables.Items.Add(itemCurrentStopInfo);

                    // CurrentStopName
                    DarkListItem itemCurrentStopName = new DarkListItem();
                    itemCurrentStopName.Text = "  CurrentStopName = \"\" [String][R]";
                    listviewVariables.Items.Add(itemCurrentStopName);

                    // CurrentStopPassed
                    DarkListItem itemCurrentStopPassed = new DarkListItem();
                    itemCurrentStopPassed.Text = "  CurrentStopPassed = True [Int32][R]";
                    listviewVariables.Items.Add(itemCurrentStopPassed);

                    // CurrentStopSideLeft
                    DarkListItem itemCurrentStopSideLeft = new DarkListItem();
                    itemCurrentStopSideLeft.Text = "  CurrentStopSideLeft = True [Int32][R]";
                    listviewVariables.Items.Add(itemCurrentStopSideLeft);

                    // CurrentStopSideRight
                    DarkListItem itemCurrentStopSideRight = new DarkListItem();
                    itemCurrentStopSideRight.Text = "  CurrentStopSideRight = True [Int32][R]";
                    listviewVariables.Items.Add(itemCurrentStopSideRight);

                    // CurrentStopArriveScheduled
                    DarkListItem itemCurrentStopArriveScheduled = new DarkListItem();
                    itemCurrentStopArriveScheduled.Text = "  CurrentStopArriveScheduled = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemCurrentStopArriveScheduled);

                    // CurrentStopArriveActual
                    DarkListItem itemCurrentStopArriveActual = new DarkListItem();
                    itemCurrentStopArriveActual.Text = "  CurrentStopArriveActual = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemCurrentStopArriveActual);

                    // CurrentStopDepartScheduled
                    DarkListItem itemCurrentStopDepartScheduled = new DarkListItem();
                    itemCurrentStopDepartScheduled.Text = "  CurrentStopDepartScheduled = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemCurrentStopDepartScheduled);

                    // CurrentStopDepartActual
                    DarkListItem itemCurrentStopDepartActual = new DarkListItem();
                    itemCurrentStopDepartActual.Text = "  CurrentStopDepartActual = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemCurrentStopDepartActual);

                    // CurrentStopDistance
                    DarkListItem itemCurrentStopDistance = new DarkListItem();
                    itemCurrentStopDistance.Text = "  CurrentStopDistance = 0 [Float][R]";
                    listviewVariables.Items.Add(itemCurrentStopDistance);

                    // NextStopInfo.
                    DarkListItem itemNextStopInfo = new DarkListItem();
                    itemNextStopInfo.Text = " NextStopInfo.";
                    listviewVariables.Items.Add(itemNextStopInfo);

                    // NextStopName
                    DarkListItem itemNextStopName = new DarkListItem();
                    itemNextStopName.Text = "  NextStopName = \"\" [String][R]";
                    listviewVariables.Items.Add(itemNextStopName);

                    // NextStopPassed
                    DarkListItem itemNextStopPassed = new DarkListItem();
                    itemNextStopPassed.Text = "  NextStopPassed = True [Int32][R]";
                    listviewVariables.Items.Add(itemNextStopPassed);

                    // NextStopSideLeft
                    DarkListItem itemNextStopSideLeft = new DarkListItem();
                    itemNextStopSideLeft.Text = "  NextStopSideLeft = True [Int32][R]";
                    listviewVariables.Items.Add(itemNextStopSideLeft);

                    // NextStopSideRight
                    DarkListItem itemNextStopSideRight = new DarkListItem();
                    itemNextStopSideRight.Text = "  NextStopSideRight = True [Int32][R]";
                    listviewVariables.Items.Add(itemNextStopSideRight);

                    // NextStopArriveScheduled
                    DarkListItem itemNextStopArriveScheduled = new DarkListItem();
                    itemNextStopArriveScheduled.Text = "  NextStopArriveScheduled = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemNextStopArriveScheduled);

                    // NextStopArriveActual
                    DarkListItem itemNextStopArriveActual = new DarkListItem();
                    itemNextStopArriveActual.Text = "  NextStopArriveActual = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemNextStopArriveActual);

                    // NextStopDepartScheduled
                    DarkListItem itemNextStopDepartScheduled = new DarkListItem();
                    itemNextStopDepartScheduled.Text = "  NextStopDepartScheduled = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemNextStopDepartScheduled);

                    // NextStopDepartActual
                    DarkListItem itemNextStopDepartActual = new DarkListItem();
                    itemNextStopDepartActual.Text = "  NextStopDepartActual = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemNextStopDepartActual);

                    // NextStopDistance
                    DarkListItem itemNextStopDistance = new DarkListItem();
                    itemNextStopDistance.Text = "  NextStopDistance = 0 [Float][R]";
                    listviewVariables.Items.Add(itemNextStopDistance);

                    // SimulatorMethods.
                    DarkListItem itemSimulatorMethods = new DarkListItem();
                    itemSimulatorMethods.Text = "SimulatorMethods.";
                    listviewVariables.Items.Add(itemSimulatorMethods);

                    // CurrentTime
                    DarkListItem itemCurrentTime = new DarkListItem();
                    itemCurrentTime.Text = " CurrentTime = \"\" [DateTime][R]";
                    listviewVariables.Items.Add(itemCurrentTime);

                    // PauseValue
                    DarkListItem itemPauseValue = new DarkListItem();
                    itemPauseValue.Text = " PauseValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemPauseValue);

                    // QuitOrderValue
                    DarkListItem itemOrderValue = new DarkListItem();
                    itemOrderValue.Text = " OrderValue = 0 [Int32][R/W]";
                    listviewVariables.Items.Add(itemOrderValue);

                    // SimulatorTime
                    DarkListItem itemSimulatorTime = new DarkListItem();
                    itemSimulatorTime.Text = " SimulatorTime = 0 [Float][R/W]";
                    listviewVariables.Items.Add(itemSimulatorTime);

                    // SimulatorSeason
                    DarkListItem itemSimulatorSeason = new DarkListItem();
                    itemSimulatorSeason.Text = " SimulatorSeason = 0 [Int][R]";
                    listviewVariables.Items.Add(itemSimulatorSeason);

                    // SimulatorSeason
                    DarkListItem itemSimulatorWeather = new DarkListItem();
                    itemSimulatorWeather.Text = " SimulatorWeather = 0 [Int][R]";
                    listviewVariables.Items.Add(itemSimulatorWeather);

                    // WeatherDetail.
                    DarkListItem itemWeatherDetail = new DarkListItem();
                    itemWeatherDetail.Text = " WeatherDetail.";
                    listviewVariables.Items.Add(itemWeatherDetail);

                    // WindDirection
                    DarkListItem itemWindDirection = new DarkListItem();
                    itemWindDirection.Text = "  WindDirection = 0 [Float][R]";
                    listviewVariables.Items.Add(itemWindDirection);

                    // FogDistance
                    DarkListItem itemFogDistance = new DarkListItem();
                    itemFogDistance.Text = "  FogDistance = 0 [Float][R]";
                    listviewVariables.Items.Add(itemFogDistance);

                    // OvercastFactor
                    DarkListItem itemOvercastFactor = new DarkListItem();
                    itemOvercastFactor.Text = "  OvercastFactor = 0 [Float][R]";
                    listviewVariables.Items.Add(itemOvercastFactor);

                    // PrecipitationLiquidity
                    DarkListItem itemPrecipitationLiquidity = new DarkListItem();
                    itemPrecipitationLiquidity.Text = "  PrecipitationLiquidity = 0 [Float][R]";
                    listviewVariables.Items.Add(itemPrecipitationLiquidity);

                    // PricipitationIntensity
                    DarkListItem itemPricipitationIntensity = new DarkListItem();
                    itemPricipitationIntensity.Text = "  PricipitationIntensity = 0 [Float][R]";
                    listviewVariables.Items.Add(itemPricipitationIntensity);

                    // WindSpeed
                    DarkListItem itemWindSpeed = new DarkListItem();
                    itemWindSpeed.Text = "  WindSpeed = 0 [Float][R]";
                    listviewVariables.Items.Add(itemWindSpeed);

                    // InsideTemperature
                    DarkListItem itemInsideTemperature = new DarkListItem();
                    itemInsideTemperature.Text = "  InsideTemperature = 0 [Float][R]";
                    listviewVariables.Items.Add(itemInsideTemperature);

                    // OutsideTemperature
                    DarkListItem itemOutsideTemperature = new DarkListItem();
                    itemOutsideTemperature.Text = "  OutsideTemperature = 0 [Float][R]";
                    listviewVariables.Items.Add(itemOutsideTemperature);
                }));
            }
            catch (Exception) { };
        }

        private void UpdateVariableViewer()
        {
            try
            {
                listviewVariables.Invoke(new EventHandler(delegate
                {
                    // SpeedOmeter
                    listviewVariables.Items[1].Text = " SpeedOmeter = " +
                        TrainMethods.GetSpeedOmeter(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // SpeedProjected
                    listviewVariables.Items[2].Text = " SpeedProjected = " +
                        TrainMethods.GetSpeedProjected(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // Accelerometer
                    listviewVariables.Items[3].Text = " Accelerometer = " +
                        TrainMethods.GetAccelerometer(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // Ammeter
                    listviewVariables.Items[4].Text = " Ammeter = " +
                        TrainMethods.GetAmmeter(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // LoadMeter
                    listviewVariables.Items[5].Text = " LoadMeter = " +
                        TrainMethods.GetLoadMeter(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // TractionBrakingAmps
                    listviewVariables.Items[6].Text = " TractionBrakingAmps = " +
                        TrainMethods.GetTractionBrakingAmps(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // TractionBrakingForce
                    listviewVariables.Items[7].Text = " TractionBrakingForce = " +
                        TrainMethods.GetTractionBrakingForce(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // DynamicBrakeAmps
                    listviewVariables.Items[8].Text = " DynamicBrakeAmps = " +
                        TrainMethods.GetDynamicBrakeAmps(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // DynamicBrakeForce
                    listviewVariables.Items[9].Text = " DynamicBrakeForce = " +
                        TrainMethods.GetDynamicBrakeForce(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // MainResPressure
                    listviewVariables.Items[10].Text = " MainResPressure = " +
                        TrainMethods.GetMainResPressure(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // BrakePipePressure
                    listviewVariables.Items[11].Text = " BrakePipePressure = " +
                        TrainMethods.GetBrakePipePressure(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // EQResPressure
                    listviewVariables.Items[12].Text = " EQResPressure = " +
                        TrainMethods.GetEQResPressure(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // BrakeCylPressure
                    listviewVariables.Items[13].Text = " BrakeCylPressure = " +
                        TrainMethods.GetBrakeCylPressure(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // VacuumReservoirPressure
                    listviewVariables.Items[14].Text = " VacuumReservoirPressure = " +
                        TrainMethods.GetVacuumReservoirPressure(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // DieselEngineRPM
                    listviewVariables.Items[15].Text = " DieselEngineRPM = " +
                        TrainMethods.GetDieselEngineRPM(TrainMethods.serviceLocomotive).ToString() + " [Int32][R]";

                    // DieselEngineTemperature
                    listviewVariables.Items[16].Text = " DieselEngineTemperature = " +
                        TrainMethods.GetDieselEngineTemperature(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // DieselEngineOilPresssure
                    listviewVariables.Items[17].Text = " DieselEngineOilPresssure = " +
                        TrainMethods.GetDieselEngineOilPresssure(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // ThrottleValue
                    listviewVariables.Items[18].Text = " ThrottleValue = " +
                        TrainMethods.GetThrottleValue(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R/W]";

                    // EngineBrakeValue
                    listviewVariables.Items[19].Text = " EngineBrakeValue = " +
                        TrainMethods.GetEngineBrakeValue(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R/W]";

                    // TrainBrakeValue
                    listviewVariables.Items[20].Text = " TrainBrakeValue = " +
                        TrainMethods.GetTrainBrakeValue(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R/W]";

                    // DynamicBrakeValue
                    listviewVariables.Items[21].Text = " DynamicBrakeValue = " +
                        TrainMethods.GetDynamicBrakeValue(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R/W]";

                    // WipersValue
                    listviewVariables.Items[22].Text = " WipersValue = " +
                        TrainMethods.GetWipersValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // HornValue
                    listviewVariables.Items[23].Text = " HornValue = " +
                        TrainMethods.GetHornValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // BellValue
                    listviewVariables.Items[24].Text = " BellValue = " +
                        TrainMethods.GetBellValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // ResetButtonValue
                    listviewVariables.Items[25].Text = " ResetButtonValue = " +
                        TrainMethods.GetResetButtonValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // WipersValue
                    listviewVariables.Items[26].Text = " AlerterValue = " +
                        TrainMethods.GetAlerterValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R]";

                    // OverspeedValue
                    listviewVariables.Items[27].Text = " OverspeedValue = " +
                        TrainMethods.GetOverspeedValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R]";

                    // PenaltyBrakeValue
                    listviewVariables.Items[28].Text = " PenaltyBrakeValue = " +
                        TrainMethods.GetPenaltyBrakeValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R]";

                    // EmergencyBrakeValue
                    listviewVariables.Items[29].Text = " EmergencyBrakeValue = " +
                        TrainMethods.GetEmergencyBrakeValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // SanderValue
                    listviewVariables.Items[30].Text = " SanderValue = " +
                        TrainMethods.GetSanderValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // HeadlightValue
                    listviewVariables.Items[31].Text = " HeadlightValue = " +
                        TrainMethods.GetHeadlightValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // WheelslipValue
                    listviewVariables.Items[32].Text = " WheelslipValue = " +
                        TrainMethods.GetWheelslipValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R]";

                    // DirectionValue
                    listviewVariables.Items[33].Text = " DirectionValue = " +
                        TrainMethods.GetDirectionValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // NextSignalAspectValue
                    listviewVariables.Items[34].Text = " NextSignalAspectValue = " +
                        TrainMethods.GetNextSignalAspectValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // SpeedLimit
                    listviewVariables.Items[35].Text = " SpeedLimit = " +
                        TrainMethods.GetSpeedLimit(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // DieselGearboxValue
                    listviewVariables.Items[36].Text = " DieselGearboxValue = " +
                        TrainMethods.GetDieselGearboxValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // CabRadioValue
                    listviewVariables.Items[37].Text = " CabRadioValue = " +
                        TrainMethods.GetCabRadioValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // ServiceDieselEngineState
                    listviewVariables.Items[38].Text = " ServiceDieselEngineState = " +
                        TrainMethods.GetServiceDieselEngineState(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // HelpersDieselEngineState
                    listviewVariables.Items[39].Text = " HelpersDieselEngineState = " +
                        TrainMethods.GetHelpersDieselEngineState(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // CablightValue
                    listviewVariables.Items[40].Text = " CablightValue = " +
                        TrainMethods.GetCablightValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // LeftDoorValue
                    listviewVariables.Items[41].Text = " LeftDoorValue = " +
                        TrainMethods.GetLeftDoorValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // RightDoorValue
                    listviewVariables.Items[42].Text = " RightDoorValue = " +
                        TrainMethods.GetRightDoorValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // VisorValue
                    listviewVariables.Items[43].Text = " VisorValue = " +
                        TrainMethods.GetVisorValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // LineVoltage
                    listviewVariables.Items[44].Text = " LineVoltage = " +
                        TrainMethods.GetLineVoltage(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R/W]";

                    // PantographValue
                    listviewVariables.Items[45].Text = " PantographValue = " +
                        TrainMethods.GetPantographValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // Pantograph1Value
                    listviewVariables.Items[46].Text = " Pantograph1Value = " +
                        TrainMethods.GetPantograph1Value(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // Pantograph2Value
                    listviewVariables.Items[47].Text = " Pantograph2Value = " +
                        TrainMethods.GetPantograph2Value(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // CircuitBreakerOrderClosingValue
                    listviewVariables.Items[48].Text = " CircuitBreakerOrderClosingValue = " +
                        TrainMethods.GetCircuitBreakerOrderClosingValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // CircuitBreakerOrderOpeningValue
                    listviewVariables.Items[49].Text = " CircuitBreakerOrderOpeningValue = " +
                        TrainMethods.GetCircuitBreakerOrderOpeningValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R/W]";

                    // CircuitBreakerClosingAuthValue
                    listviewVariables.Items[50].Text = " CircuitBreakerClosingAuthValue = " +
                        TrainMethods.GetCircuitBreakerClosingAuthValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R]";

                    // CircuitBreakerValue
                    listviewVariables.Items[51].Text = " CircuitBreakerValue = " +
                        TrainMethods.GetCircuitBreakerValue(TrainMethods.serviceLocomotive).ToString() + " [Int32][R]";

                    // NextSignalDistance
                    listviewVariables.Items[52].Text = " NextSignalDistance = " +
                        TrainMethods.GetNextSignalDistance(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // DistanceTravelled
                    listviewVariables.Items[53].Text = " DistanceTravelled = " +
                        TrainMethods.GetDistanceTravelled(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // TrainWeight
                    listviewVariables.Items[54].Text = " TrainWeight = " +
                        TrainMethods.GetTrainWeight(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // TrainLength
                    listviewVariables.Items[55].Text = " TrainLength = " +
                        TrainMethods.GetTrainLength(TrainMethods.serviceLocomotive).ToString("f4") + " [Float][R]";

                    // TrainName
                    listviewVariables.Items[56].Text = " TrainName = \"" +
                        TrainMethods.GetTrainName(TrainMethods.serviceLocomotive) + "\" [String][R]";

                    // LocomotiveType
                    listviewVariables.Items[57].Text = " LocomotiveType = " +
                        TrainMethods.GetLocomotiveType(TrainMethods.serviceLocomotive).ToString() + " [Int32][R]";

                    // TrainStopCount
                    listviewVariables.Items[59].Text = " TrainStopCount = " +
                       TimetableMethods.GetTrainStopCount().ToString() + " [Int32][R]";

                    StopInformation previousStopInfo = 
                        TimetableMethods.GetPreviousStopInfo(TimetableMethods.serviceTrain);

                    // PreviousStopName
                    listviewVariables.Items[61].Text = "  PreviousStopName = \"" +
                        previousStopInfo.Name + "\" [String][R]";

                    // PreviousStopPassed
                    listviewVariables.Items[62].Text = "  PreviousStopPassed = " +
                        previousStopInfo.Passed.ToString() + " [Int32][R]";

                    // PreviousStopSideLeft
                    listviewVariables.Items[63].Text = "  PreviousStopSideLeft = " +
                        previousStopInfo.SideLeft.ToString() + " [Int32][R]";

                    // PreviousStopSideRight
                    listviewVariables.Items[64].Text = "  PreviousStopSideRight = " +
                        previousStopInfo.SideRight.ToString() + " [Int32][R]";

                    // PreviousStopArriveScheduled
                    listviewVariables.Items[65].Text = "  PreviousStopArriveScheduled = \"" +
                        previousStopInfo.ArriveScheduled + "\" [DateTime][R]";

                    // PreviousStopArriveActual
                    listviewVariables.Items[66].Text = "  PreviousStopArriveActual = \"" +
                        previousStopInfo.ArriveActual + "\" [DateTime][R]";

                    // PreviousStopDepartScheduled
                    listviewVariables.Items[67].Text = "  PreviousStopDepartScheduled = \"" +
                        previousStopInfo.DepartScheduled + "\" [DateTime][R]";

                    // PreviousStopDepartActual
                    listviewVariables.Items[68].Text = "  PreviousStopDepartActual = \"" +
                        previousStopInfo.DepartActual + "\" [DateTime][R]";

                    // PreviousStopDistance
                    listviewVariables.Items[69].Text = "  PreviousStopDistance = " +
                        previousStopInfo.Distance.ToString("f4") + " [Float][R]";

                    StopInformation currentStopInfo =
                        TimetableMethods.GetCurrentStopInfo(TimetableMethods.serviceTrain);

                    // CurrentStopName
                    listviewVariables.Items[71].Text = "  CurrentStopName = \"" +
                        currentStopInfo.Name + "\" [String][R]";

                    // CurrentStopPassed
                    listviewVariables.Items[72].Text = "  CurrentStopPassed = " +
                        currentStopInfo.Passed.ToString() + " [Int32][R]";

                    // CurrentStopSideLeft
                    listviewVariables.Items[73].Text = "  CurrentStopSideLeft = " +
                        currentStopInfo.SideLeft.ToString() + " [Int32][R]";

                    // CurrentStopSideRight
                    listviewVariables.Items[74].Text = "  CurrentStopSideRight = " +
                        currentStopInfo.SideRight.ToString() + " [Int32][R]";

                    // CurrentStopArriveScheduled
                    listviewVariables.Items[75].Text = "  CurrentStopArriveScheduled = \"" +
                        currentStopInfo.ArriveScheduled + "\" [DateTime][R]";

                    // CurrentStopArriveActual
                    listviewVariables.Items[76].Text = "  CurrentStopArriveActual = \"" +
                        currentStopInfo.ArriveActual + "\" [DateTime][R]";

                    // CurrentStopDepartScheduled
                    listviewVariables.Items[77].Text = "  CurrentStopDepartScheduled = \"" +
                        currentStopInfo.DepartScheduled + "\" [DateTime][R]";

                    // CurrentStopDepartActual
                    listviewVariables.Items[78].Text = "  CurrentStopDepartActual = \"" +
                        currentStopInfo.DepartActual + "\" [DateTime][R]";

                    // CurrentStopDistance
                    listviewVariables.Items[79].Text = "  CurrentStopDistance = " +
                        currentStopInfo.Distance.ToString("f4") + " [Float][R]";

                    StopInformation nextStopInfo =
                        TimetableMethods.GetNextStopInfo(TimetableMethods.serviceTrain);

                    // NextStopName
                    listviewVariables.Items[81].Text = "  NextStopName = \"" +
                        nextStopInfo.Name + "\" [String][R]";

                    // NextStopPassed
                    listviewVariables.Items[82].Text = "  NextStopPassed = " +
                        nextStopInfo.Passed.ToString() + " [Int32][R]";

                    // NextStopSideLeft
                    listviewVariables.Items[83].Text = "  NextStopSideLeft = " +
                        nextStopInfo.SideLeft.ToString() + " [Int32][R]";

                    // NextStopSideRight
                    listviewVariables.Items[84].Text = "  NextStopSideRight = " +
                        nextStopInfo.SideRight.ToString() + " [Int32][R]";

                    // NextStopArriveScheduled
                    listviewVariables.Items[85].Text = "  NextStopArriveScheduled = \"" +
                        nextStopInfo.ArriveScheduled + "\" [DateTime][R]";

                    // NextStopArriveActual
                    listviewVariables.Items[86].Text = "  NextStopArriveActual = \"" +
                        nextStopInfo.ArriveActual + "\" [DateTime][R]";

                    // NextStopDepartScheduled
                    listviewVariables.Items[87].Text = "  NextStopDepartScheduled = \"" +
                        nextStopInfo.DepartScheduled + "\" [DateTime][R]";

                    // NextStopDepartActual
                    listviewVariables.Items[88].Text = "  NextStopDepartActual = \"" +
                        nextStopInfo.DepartActual + "\" [DateTime][R]";

                    // NextStopDistance
                    listviewVariables.Items[89].Text = "  NextStopDistance = " +
                        nextStopInfo.Distance.ToString("f4") + " [Float][R]";

                    // CurrentTime
                    listviewVariables.Items[91].Text = "  CurrentTime = " +
                        SimulatorMethods.GetCurrentTime().ToString("HH:mm:ss") + "\" [DateTime][R]";

                    // PauseValue
                    listviewVariables.Items[92].Text = "  PauseValue = " +
                        SimulatorMethods.GetPauseValue().ToString() + " [Int32][R/W]";

                    // QuitOrderValue
                    listviewVariables.Items[93].Text = "  QuitOrderValue = " +
                        SimulatorMethods.GetQuitOrderValue().ToString() + " [Int32][R/W]";

                    // SimulatorTime
                    listviewVariables.Items[94].Text = "  SimulatorTime = " +
                        SimulatorMethods.GetSimulatorTime().ToString("f4") + " [Float][R]";

                    // SimulatorSeason
                    listviewVariables.Items[95].Text = "  SimulatorSeason = " +
                        SimulatorMethods.GetSimulatorSeason().ToString() + " [Int][R]";

                    // SimulatorWeather
                    listviewVariables.Items[96].Text = "  SimulatorWeather = " +
                        SimulatorMethods.GetSimulatorWeather().ToString() + " [Int][R]";

                    SimulatorMethods.WeatherDetail weatherDetail = SimulatorMethods.GetSimulatorWeatherDetail();

                    // WindDirection
                    listviewVariables.Items[98].Text = "   WindDirection = " +
                        weatherDetail.WindDirection.ToString("f4") + " [Float][R]";

                    // FogDistance
                    listviewVariables.Items[99].Text = "   FogDistance = " +
                        weatherDetail.FogDistance.ToString("f4") + " [Float][R]";

                    // OvercastFactor
                    listviewVariables.Items[100].Text = "   OvercastFactor = " +
                        weatherDetail.OvercastFactor.ToString("f4") + " [Float][R]";

                    // PrecipitationLiquidity
                    listviewVariables.Items[101].Text = "   PrecipitationLiquidity = " +
                        weatherDetail.PrecipitationLiquidity.ToString("f4") + " [Float][R]";

                    // PricipitationIntensity
                    listviewVariables.Items[102].Text = "   PricipitationIntensity = " +
                        weatherDetail.PricipitationIntensity.ToString("f4") + " [Float][R]";

                    // WindSpeed
                    listviewVariables.Items[103].Text = "   WindSpeed = " +
                        weatherDetail.WindSpeed.ToString("f4") + " [Float][R]";

                    // InsideTemperature
                    listviewVariables.Items[104].Text = "   InsideTemperature = " +
                        weatherDetail.InsideTemperature.ToString("f4") + " [Float][R]";

                    // WindDirection
                    listviewVariables.Items[105].Text = "   OutsideTemperature = " +
                        weatherDetail.OutsideTemperature.ToString("f4") + " [Float][R]";
                }));
            }
            catch (Exception) { };
        }

        private void StartRefreshVariables()
        {
            if (timerRefreshVars.Enabled == false)
                timerRefreshVars.Enabled = true;
        }

        private void FormSimDebug_Load(object sender, EventArgs e)
        {
            CreateVariableViewer();
            TrainMethods.TrainUpdatedEvent += StartRefreshVariables;
        }

        private void timerRefreshVars_Tick(object sender, EventArgs e)
        {
            try
            {
                if (SimulatorMethods.GetSimulatorRunState())
                    UpdateVariableViewer();
            }
            catch (Exception) { };
        }

        static float currentValue = 0.0f;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            currentValue += 0.1f;
            // TrainMethods.SetTrainBrakeValue(TrainMethods.serviceLocomotive, currentValue);
            TrainMethods.SetCircuitBreakerOrderClosingButtonPressedValue(TrainMethods.serviceLocomotive, 1);
            TrainMethods.SetDirectionValue(TrainMethods.serviceLocomotive, 2);
        }

        private void buttonLess_Click(object sender, EventArgs e)
        {
            currentValue -= 0.1f;
            // TrainMethods.SetTrainBrakeValue(TrainMethods.serviceLocomotive, currentValue);
            TrainMethods.SetCircuitBreakerOrderClosingButtonPressedValue(TrainMethods.serviceLocomotive, 0);
            TrainMethods.SetDirectionValue(TrainMethods.serviceLocomotive, 0);
        }
    }
}
