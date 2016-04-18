using House_Of_The_Future.Shared.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace House_Of_The_Future.Shared.Models
{
    public class LogicalLayer : LLBaseClass
    {
        private AdamBoard1 board1;
        private AdamBoard2 board2;
        private BackgroundWorker bgw;
        private const int _WAITTIME = 100;

        public LogicalLayer()
        {
            board1 = new AdamBoard1();
            board2 = new AdamBoard2();
            SetUpBackgroundworker();
        }

        #region BackgroundWorker
        private void SetUpBackgroundworker()
        {
            bgw = new BackgroundWorker();

            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += Bgw_DoWork;
            bgw.RunWorkerCompleted += Bgw_RunWorkerCompleted;
            bgw.RunWorkerAsync();
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(_WAITTIME);

            //if (board2 != null && board2.isConnected()) Allowed = board2.StatusRedSwitch();
            //else Allowed = new AdamBoard2().StatusRedSwitch();

            //UpdateProperties();

            if (Allowed)
            {
                //DoWorkAlarm();
                //DoWorkLight();
                //DoWorkTempManagement();
                //DoWorkGate();
                //DoLockingWork();
            }
        }

        private void Bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!bgw.IsBusy) bgw.RunWorkerAsync();
        }

        private void UpdateProperties()
        {
            //LIGHTING
            IsLightWoonkamerOn = board2.StatusLed1();
            IsLightKeukenOn = board2.StatusLed2();
            IsLightSlaapkamerOn = board2.StatusLed3();
            IsLightTuinOn = board2.StatusLed4();

            //TEMPERATURE
            IsAutoManaged = board1.StatusSwitch2();
            IsHeatingOn = board1.StatusVentilator();
            IsAircoOn = board2.StatusVentilator();
            TargetTemperature = TargetTemperatureCalculator.GetTemperature(board1.StatusPotentiometer2());

            //ALARM
            IsAlarmOn = StatusAlarm();
            IsAlarmSet = board1.StatusSwitch1();
        }
        #endregion

        #region Lighting - Threaded

        #region Properties

        private bool _isLightWoonkamerOn;
        private bool _isLightKeukenOn;
        private bool _isLightSlaapkamerOn;
        private bool _isLightTuinOn;

        public bool IsLightWoonkamerOn
        {
            get { return _isLightWoonkamerOn; }
            set {
                if (_isLightWoonkamerOn == value) return;
                _isLightWoonkamerOn = value;
                OnPropertyChanged();
            }
        }
        public bool IsLightKeukenOn
        {
            get { return _isLightKeukenOn; }
            set {
                if (_isLightKeukenOn == value) return;
                _isLightKeukenOn = value;
                OnPropertyChanged();
            }
        }
        public bool IsLightSlaapkamerOn
        {
            get { return _isLightSlaapkamerOn; }
            set {
                if (_isLightSlaapkamerOn == value) return;
                _isLightSlaapkamerOn = value;
                OnPropertyChanged();
            }
        }
        public bool IsLightTuinOn
        {
            get { return _isLightTuinOn; }
            set {
                if (_isLightTuinOn == value) return;
                _isLightTuinOn = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        public void TurnOffAllLights()
        {
            SetLightWoonkamer(board2, false);
            SetLightKeuken(board2, false);
            SetLightSlaapkamer(board2, false);
            SetLightTuin(board2, false);
        }

        public void TurnOnAllLights()
        {
            SetLightWoonkamer(board2, true);
            SetLightKeuken(board2, true);
            SetLightSlaapkamer(board2, true);
            SetLightTuin(board2, true);
        }

        public void ToggleLightWoonkamer()
        {
            if (board2.StatusLed1()) SetLightWoonkamer(board2, false);
            else SetLightWoonkamer(board2, true);
        }

        public void ToggleLightKeuken()
        {
            if (board2.StatusLed2()) SetLightKeuken(board2, false);
            else SetLightKeuken(board2, true);
        }

        public void ToggleLightSlaapkamer()
        {
            if (board2.StatusLed3()) SetLightSlaapkamer(board2, false);
            else SetLightSlaapkamer(board2, true);
        }

        public void ToggleLightTuin()
        {
            if (board2.StatusLed4()) SetLightTuin(board2, false);
            else SetLightTuin(board2, true);
        }

        #endregion

        #region PrivateMethods

        private void SetLightWoonkamer(AdamBoard2 board, bool status)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                if (!Allowed) return;
                bool lightOn = board.StatusLed1();
                if (lightOn && !status) board.TurnOffLed1();
                if (!lightOn && status) board.TurnOnLed1();

            }).Start();
        }

        private void SetLightKeuken(AdamBoard2 board, bool status)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                if (!Allowed) return;
                bool lightOn = board.StatusLed2();
                if (lightOn && !status) board.TurnOffLed2();
                if (!lightOn && status) board.TurnOnLed2();

            }).Start();
        }

        private void SetLightSlaapkamer(AdamBoard2 board, bool status)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                if (!Allowed) return;
                bool lightOn = board.StatusLed3();
                if (lightOn && !status) board.TurnOffLed3();
                if (!lightOn && status) board.TurnOnLed3();

            }).Start();
        }

        private void SetLightTuin(AdamBoard2 board, bool status)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                if (!Allowed) return;
                bool lightOn = board.StatusLed4();
                if (lightOn && !status) board.TurnOffLed4();
                if (!lightOn && status) board.TurnOnLed4();

            }).Start();
        }

        #endregion

        private bool blackButtonOverride = false;
        private void DoWorkLight()
        {
            bool btnStatus = board2.StatusBlackButton();
            if (!blackButtonOverride)
            {
                if (btnStatus)
                {
                    ToggleLightTuin();
                    blackButtonOverride = true; //Set the override lock.
                    //This to keep the port from opening and closing while the user keeps pressing the button
                }
            } else
            {
                if (!btnStatus)
                {
                    blackButtonOverride = false; //Lift the override when the user releases the button
                }
            }
        }

        #endregion

        #region Temperature Management - Threaded

        #region Properties

        private bool? _autoHeatManagement;
        private bool _isHeatingOn;
        private bool _isAircoOn;
        private double _targetTemperature;

        public bool IsAutoManaged
        {
            get
            {
                if (!_autoHeatManagement.HasValue) _autoHeatManagement = false;
                return _autoHeatManagement.Value;
            }
            set
            {
                if (_autoHeatManagement == value) return;
                _autoHeatManagement = value;
                OnPropertyChanged();
            }
        }
        public bool IsHeatingOn
        {
            get { return _isHeatingOn; }
            set {
                if (_isHeatingOn == value) return;
                _isHeatingOn = value;
                OnPropertyChanged();
            }
        }
        public bool IsAircoOn
        {
            get { return _isAircoOn; }
            set
            {
                if (_isAircoOn == value) return;
                _isAircoOn = value;
                OnPropertyChanged();
            }
        }
        public double TargetTemperature
        {
            get { return _targetTemperature; }
            set
            {
                if (_targetTemperature == value) return;
                _targetTemperature = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Private methods
        private void SetAirco(AdamBoard2 board, bool status)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                if (!Allowed) return;
                bool ventOn = board.StatusVentilator();
                if (ventOn && !status) board.TurnOffVentilator();
                if (!ventOn && status) board.TurnOnVentilator();

            }).Start();
        }

        private void SetHeating(AdamBoard1 board, bool status)
        {
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;

                if (!Allowed) return;
                bool ventOn = board.StatusVentilator();
                if (ventOn && !status) board.TurnOffVentilator();
                if (!ventOn && status) board.TurnOnVentilator();

            }).Start();
        }
        #endregion

        private void DoWorkTempManagement()
        {
            if (IsAutoManaged)
            {
                double targetTemp = TargetTemperatureCalculator.GetTemperature(board1.StatusPotentiometer2());
                double currentTemp = board1.StatusTemperatureSensor();
                double hysterese = 2.3;

                //Determine full heating/airo with hysterese to save resources
                if (currentTemp < (targetTemp - hysterese))
                {
                    SetAirco(board2, false);
                    SetHeating(board1, true);
                } else if (currentTemp > (targetTemp + hysterese))
                {
                    SetAirco(board2, true);
                    SetHeating(board1, false);
                } else
                {
                    //The temperature is between target + hysterese threshold.
                    //Turn off with calculated hysterese
                    if (board1.StatusVentilator())
                    {
                        //If the heating is on, turn off at target - threshold
                        if (currentTemp >= (targetTemp - (hysterese / 2))) SetHeating(board1, false);
                    }
                    if (board2.StatusVentilator())
                    {
                        //If the airco is on, turn off at target + threshold
                        if (currentTemp <= (targetTemp + (hysterese / 2))) SetAirco(board2, false);
                    }
                }
            } else
            {
                switch (board1.StatusPotentiometer1())
                {
                    case TemperatureEnum.AIRCO:
                        SetAirco(board2, true);
                        SetHeating(board1, false);
                        break;
                    case TemperatureEnum.HEATING:
                        SetAirco(board2, false);
                        SetHeating(board1, true);
                        break;
                    case TemperatureEnum.NONE:
                        SetAirco(board2, false);
                        SetHeating(board1, true);
                        break;
                }
            }
        }

        #endregion

        #region Alarm

        #region Properties

        private bool _isAlarmOn;

        public bool IsAlarmOn
        {
            get { return _isAlarmOn; }
            set
            {
                if (_isAlarmOn == value) return;
                _isAlarmOn = value;
                OnPropertyChanged();
            }
        }

        private bool _isAlarmSet;

        public bool IsAlarmSet
        {
            get { return _isAlarmSet; }
            set {
                if (_isAlarmSet == value) return;
                _isAlarmSet = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        public static void TurnOnAlarm()
        {
            AdamBoard1 board = new AdamBoard1();
            if (board.StatusLamp() == false)
                board.TurnOnLamp();
            board.CloseConnection();
        }

        public void TurnOffAlarm()
        {
            if (!Allowed) return;
            if (board1.StatusLamp()) board1.TurnOffLamp();
        }

        private bool StatusAlarm()
        {
            return board1.StatusLamp();
        }

        #endregion

        private void DoWorkAlarm()
        {
            if (board1.StatusSwitch1())
            {
                ProximityEnum proximity = board2.StatusProximity();
                if (proximity == ProximityEnum.CLOSEST || proximity == ProximityEnum.CLOSE || proximity == ProximityEnum.NEAR)
                    TurnOnAlarm();
                else TurnOffAlarm();
            }
        }

        #endregion

        #region Gate

        #region Properties

        private bool _isGateOpen;

        public bool IsGateOpen
        {
            get { return _isGateOpen; }
            set {
                if (_isGateOpen == value) return;
                _isGateOpen = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region private methods
        private void OpenGate()
        {
            if (!Allowed) return;
            if (!IsGateOpen) IsGateOpen = true;
        }

        private void CloseGate()
        {
            if (!Allowed) return;
            if (IsGateOpen) IsGateOpen = false;
        }
        #endregion

        private bool greenButtonOverride = false;
        private void DoWorkGate()
        {
            bool btnStatus = board2.StatusGreenButton();
            if (!greenButtonOverride)
            {
                if (btnStatus)
                {
                    if (!IsGateOpen) OpenGate();
                    else CloseGate();

                    //Set the override lock.
                    //This to keep the port from opening and closing while the user keeps pressing the button
                    greenButtonOverride = true;
                }
            } else
            {
                if (!btnStatus)
                {
                    //Lift the override when the user releases the button
                    greenButtonOverride = false;
                }
            }
        }

        #endregion

        #region Security

        #region Properties

        private bool _softwareAllowed;

        public bool Allowed
        {
            get { return _softwareAllowed; }
            set
            {
                if (_softwareAllowed == value) return;
                _softwareAllowed = value;
                OnPropertyChanged();
            }
        }

        private bool _isGuiUnlocked;

        public bool IsGuiUnlocked
        {
            get { return _isGuiUnlocked; }
            set
            {
                if (_isGuiUnlocked == value) return;
                _isGuiUnlocked = value;
                OnPropertyChanged();
            }
        }

        private bool _isDoorUnlocked;

        public bool IsDoorUnlocked
        {
            get { return _isDoorUnlocked; }
            set
            {
                if (_isDoorUnlocked == value) return;
                _isDoorUnlocked = value;
                OnPropertyChanged();
            }
        }
        #endregion

        private void DoLockingWork()
        {
            IsGuiUnlocked = true;
            IsDoorUnlocked = true;
        }

        #endregion

    }

    public class TargetTemperatureCalculator
    {
        public static Double GetTemperature(float buttonInput)
        {
            double targetTemp = (buttonInput / 255) * 20;
            return targetTemp;
        }
    }
}
