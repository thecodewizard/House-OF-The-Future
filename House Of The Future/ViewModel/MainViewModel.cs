using GalaSoft.MvvmLight.Command;
using House_Of_The_Future.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace House_Of_The_Future.ViewModel
{
    public class MainViewModel : LLBaseClass
    {
        /*
        CORE STATUSSES TO BIND:
        LIGHTING: 
         - IsLightWoonkamerOn
         - IsLightKeukenOn
         - IsLightSlaapkamerOn
         - IsLightTuinOn

        TEMPERATURE:
         - IsAutoManaged
         - IsHeatingOn
         - IsAircoOn
         - TargetTemperature

        ALARM:
         - IsAlarmOn
         - IsAlarmSet

        GATE:
         - IsGateOpen
         
        SECURITY
        - Allowed
        - IsGUIUnlocked
        - IsDoorunlocked

        VM COMMANDS TO BIND:
        LIGHTNING:
         - ToggleLEDWoonkamer
         - ToggleLEDKeuken
         - ToggleLEDSlaapkamer
         - ToggleLEDTuin
         - TurnOnAllLights
         - TurnOffAllLights

        ALARM:
         - TurnOffAlarm
        */



        #region Properties

        private bool? _connectionSuccess;

        public bool ConnectionSuccess
        {
            get {
                if (!_connectionSuccess.HasValue) _connectionSuccess = true;
                return _connectionSuccess.Value;
            }
            private set
            {
                if (_connectionSuccess == value) return;
                _connectionSuccess = value;
                OnPropertyChanged();
            }
        }

        private LogicalLayer _core;

        public LogicalLayer Core
        {
            get
            {
                if (_core == null)
                {
                    try
                    {
                        _core = new LogicalLayer();
                    }
                    catch (NotConnectedException ex)
                    {
                        ConnectionSuccess = false;
                        Console.WriteLine(ex.InnerException);
                    }
                }
                return _core;
            }
        }

        #endregion

        #region LightCommands
        private RelayCommand _toggleLEDWoonkamer;
        private RelayCommand _toggleLEDKeuken;
        private RelayCommand _toggleLEDSlaapkamer;
        private RelayCommand _toggleLEDTuin;
        private RelayCommand _turnOnAllLights;
        private RelayCommand _turnOffAllLights;

        public RelayCommand CMDToggleLEDWoonkamer
        {
            get
            {
                return _toggleLEDWoonkamer ?? (_toggleLEDWoonkamer = new RelayCommand(
                    () => this.Core.ToggleLightWoonkamer()
                  ));
            }
        }
        public RelayCommand CMDToggleLEDKeuken
        {
            get
            {
                return _toggleLEDKeuken ?? (_toggleLEDKeuken = new RelayCommand(
                    () => this.Core.ToggleLightKeuken()
                  ));
            }
        }
        public RelayCommand CMDToggleLEDSlaapkamer
        {
            get
            {
                return _toggleLEDSlaapkamer ?? (_toggleLEDSlaapkamer = new RelayCommand(
                    () => this.Core.ToggleLightSlaapkamer()
                  ));
            }
        }
        public RelayCommand CMDToggleLEDTuin
        {
            get
            {
                return _toggleLEDTuin ?? (_toggleLEDTuin = new RelayCommand(
                    () => this.Core.ToggleLightTuin()
                  ));
            }
        }
        public RelayCommand CMDTurnOnAllLights
        {
            get
            {
                return _turnOnAllLights ?? (_turnOnAllLights = new RelayCommand(
                    () => this.Core.TurnOnAllLights()
                  ));
            }
        }
        public RelayCommand CMDTurnOffAllLights
        {
            get
            {
                return _turnOffAllLights ?? (_turnOffAllLights = new RelayCommand(
                    () => this.Core.TurnOffAllLights()
                  ));
            }
        }
        #endregion

        #region AlarmCommands

        private RelayCommand _turnOffAlarm;

        public RelayCommand TurnOffAlarm
        {
            get
            {
                return _turnOffAlarm ?? (_turnOffAlarm = new RelayCommand(
                    () => this.Core.TurnOffAlarm()
                  ));
            }
        }

        #endregion
    }
}
