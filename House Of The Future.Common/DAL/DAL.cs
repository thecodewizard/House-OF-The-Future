using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Of_The_Future.Common.DAL
{
    public interface DAL
    {
        #region 172.23.49.102

        #region general
        void OpenConnetion2();
        void CloseConnetion2();
        bool CheckConnetion2();
        #endregion

        #region leds
        #region led1
        void TurnOnLed1();
        void TurnOffLed1();
        bool StatusLed1();
        #endregion
        #region led2
        void TurnOnLed2();
        void TurnOffLed2();
        bool StatusLed2();
        #endregion
        #region led3
        void TurnOnLed3();
        void TurnOffLed3();
        bool StatusLed3();
        #endregion
        #region led4
        void TurnOnLed4();
        void TurnOffLed4();
        bool StatusLed4();
        #endregion
        #endregion

        #region ventilator2
        void TurnOnVentilator2();
        void TurnOffVentilator2();
        bool StatusVentilator2();
        #endregion

        #region inputs
        bool StatusRedSwitch();
        bool StatusGreenButton();
        bool StatusBlackButton();
        double StatusProximity();
        #endregion

        #endregion

        #region 172.23.49.101

        #region general
        void OpenConnetion1();
        void CloseConnetion1();
        bool CheckConnetion1();
        #endregion

        #region ventilator1
        void TurnOnVentilator1();
        void TurnOffVentilator1();
        bool StatusVentilator1();
        #endregion

        #region lamp
        void TurnOnLamp();
        void TurnOffLamp();
        bool StatusLamp();
        #endregion

        #region inputs
        short StatusPotentiometer1();
        short StatusPotentiometer2();
        short StatusPotentiometer3();
        bool StatusSwitch1();
        bool StatusSwitch2();
        #endregion

        #endregion
    }


}
