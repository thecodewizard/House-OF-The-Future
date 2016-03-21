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
        private RelayCommand _toggleLED1;
        private RelayCommand _toggleLED2;
        private RelayCommand _toggleLED3;
        private RelayCommand _toggleLED4;

        public RelayCommand CMDToggleLED1
        {
            get
            {
                return _toggleLED1 ?? (_toggleLED1 = new RelayCommand(
                    () => this.ToggleLED(1)
                  ));
            }
        }
        public RelayCommand CMDToggleLED2
        {
            get
            {
                return _toggleLED2 ?? (_toggleLED2 = new RelayCommand(
                    () => this.ToggleLED(2)
                  ));
            }
        }
        public RelayCommand CMDToggleLED3
        {
            get
            {
                return _toggleLED3 ?? (_toggleLED3 = new RelayCommand(
                    () => this.ToggleLED(3)
                  ));
            }
        }
        public RelayCommand CMDToggleLED4
        {
            get
            {
                return _toggleLED4 ?? (_toggleLED4 = new RelayCommand(
                    () => this.ToggleLED(4)
                  ));
            }
        }
        #endregion

        #region LEDStatus
        public Boolean isOnLED1 { get; set; }
        public Boolean isOnLED2 { get; set; }
        public Boolean isOnLED3 { get; set; }
        public Boolean isOnLED4 { get; set; }
        #endregion

        #region ButtonCommands
        //private RelayCommand c;
        //public RelayCommand CMDToggleLED1
        //{
        //    get
        //    {
        //        return _toggleLED1 ?? (_toggleLED1 = new RelayCommand(
        //            () => this.ToggleLED(1)
        //          ));
        //    }
        //}
        #endregion

        #region ButtonStatus
        #endregion

        #region Sensor & Rotor Commands
        private RelayCommand _toggleHeatingVent;
        public RelayCommand CMDToggleHeatingVent
        {
            get
            {
                return _toggleHeatingVent ?? (_toggleHeatingVent = new RelayCommand(
                    () => this.ToggleHeating()
                  ));
            }
        }

        private RelayCommand _toggleAirco;
        public RelayCommand CMDToggleAirco
        {
            get
            {
                return _toggleAirco ?? (_toggleAirco = new RelayCommand(
                    () => this.ToggleAirco()
                  ));
            }
        }
        #endregion

        #region Sensor & Rotor Status

        #endregion

        #endregion

        #region Functions
        private void ToggleLED(int LED)
        {

        }

        private void ToggleHeating()
        {

        }

        private void ToggleAirco()
        {

        }
        #endregion
    }
}
