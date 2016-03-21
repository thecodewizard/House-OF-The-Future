using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Of_The_Future.ViewModel
{
    public class MainViewModel
    {
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
                    () => this.TurnOnLedWoonkamer()
                  ));
            }
        }
        public RelayCommand CMDToggleLEDKeuken
        {
            get
            {
                return _toggleLEDKeuken ?? (_toggleLEDKeuken = new RelayCommand(
                    () => this.TurnOnLedKeuken()
                  ));
            }
        }
        public RelayCommand CMDToggleLEDSlaapkamer
        {
            get
            {
                return _toggleLEDSlaapkamer ?? (_toggleLEDSlaapkamer = new RelayCommand(
                    () => this.TurnOnLedSlaapkamer()
                  ));
            }
        }
        public RelayCommand CMDToggleLEDTuin
        {
            get
            {
                return _toggleLEDTuin ?? (_toggleLEDTuin = new RelayCommand(
                    () => this.TurnOnLedTuin()
                  ));
            }
        }
        #endregion

        #region LEDStatus
        public Boolean isOnLEDWoonkamer { get; set; }
        public Boolean isOnLEDKeuken { get; set; }
        public Boolean isOnLEDSlaapkamer { get; set; }
        public Boolean isOnLEDTuin { get; set; }
        #endregion

        #endregion

        #region Functions

        #region LEDFunctions
        private void TurnOnLedWoonkamer()
        {

        }

        private void TurnOnLedKeuken()
        {

        }
        private void TurnOnLedSlaapkamer()
        {

        }

        private void TurnOnLedTuin()
        {

        }
        #endregion

        #endregion
    }
}
