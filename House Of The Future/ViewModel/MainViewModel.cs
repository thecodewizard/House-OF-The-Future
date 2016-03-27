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
        CORE COMMANDS TO BIND:
        LIGHTNING: 
        */

        private LogicalLayer _core;

        public LogicalLayer Core
        {
            get {
                if (_core == null) _core = new LogicalLayer();
                return _core;
            }
        }

        #region RelayCommands

        #region LEDCommands
        private RelayCommand _toggleLEDWoonkamer;
        private RelayCommand _toggleLEDKeuken;
        private RelayCommand _toggleLEDSlaapkamer;
        private RelayCommand _toggleLEDTuin;

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
        #endregion

        #endregion
    }
}
