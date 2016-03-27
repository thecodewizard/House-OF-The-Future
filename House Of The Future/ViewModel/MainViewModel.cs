using GalaSoft.MvvmLight.Command;
using House_Of_The_Future.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Of_The_Future.ViewModel
{
    public class MainViewModel
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

        private LogicalLayer _core;

        public LogicalLayer Core
        {
            get {
                if (_core == null) _core = new LogicalLayer();
                return _core;
            }
        }

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
