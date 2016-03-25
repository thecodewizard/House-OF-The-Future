using House_Of_The_Future.Shared.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Of_The_Future.Shared.Models
{
    public class LogicalLayer
    {
        /*
        * Methods:
        * TurnOffAllLights() -> LED
        * TurnOnAllLights() -> LED
        * ToggleLight() -> for each LED
        */

        private AdamBoard1 board1;
        private AdamBoard2 board2;
        private BackgroundWorker bgw;

        public LogicalLayer()
        {
            board1 = new AdamBoard1();
            board2 = new AdamBoard2();
            bgw = new BackgroundWorker();

            bgw.WorkerSupportsCancellation = true;
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += Bgw_DoWork;
        }

        #region Lightning

        public static void TurnOffAllLights()
        {
            AdamBoard2 board = new AdamBoard2();
            SetLightWoonkamer(board, false);
            SetLightKeuken(board, false);
            SetLightSlaapkamer(board, false);
            SetLightTuin(board, false);
            board.CloseConnection();
        }

        public static void TurnOnAllLights()
        {
            AdamBoard2 board = new AdamBoard2();
            SetLightWoonkamer(board, true);
            SetLightKeuken(board, true);
            SetLightSlaapkamer(board, true);
            SetLightTuin(board, true);
            board.CloseConnection();
        }

        public static void ToggleLightWoonkamer()
        {
            AdamBoard2 board = new AdamBoard2();
            if (board.StatusLed1()) SetLightWoonkamer(board, false);
            else SetLightWoonkamer(board, true);
            board.CloseConnection();
        }

        public static void ToggleLightKeuken()
        {
            AdamBoard2 board = new AdamBoard2();
            if (board.StatusLed2()) SetLightKeuken(board, false);
            else SetLightKeuken(board, true);
            board.CloseConnection();
        }

        public static void ToggleLightSlaapkamer()
        {
            AdamBoard2 board = new AdamBoard2();
            if (board.StatusLed3()) SetLightSlaapkamer(board, false);
            else SetLightSlaapkamer(board, true);
            board.CloseConnection();
        }

        public static void ToggleLightTuin()
        {
            AdamBoard2 board = new AdamBoard2();
            if (board.StatusLed4()) SetLightTuin(board, false);
            else SetLightTuin(board, true);
            board.CloseConnection();
        }

        #region PrivateMethods

        private static void SetLightWoonkamer(AdamBoard2 board, bool status)
        {
            bool lightOn = board.StatusLed1();
            if (lightOn && !status) board.TurnOffLed1();
            if (!lightOn && status) board.TurnOnLed1();
        }

        private static void SetLightKeuken(AdamBoard2 board, bool status)
        {
            bool lightOn = board.StatusLed2();
            if (lightOn && !status) board.TurnOffLed2();
            if (!lightOn && status) board.TurnOnLed2();
        }

        private static void SetLightSlaapkamer(AdamBoard2 board, bool status)
        {
            bool lightOn = board.StatusLed3();
            if (lightOn && !status) board.TurnOffLed3();
            if (!lightOn && status) board.TurnOnLed3();
        }

        private static void SetLightTuin(AdamBoard2 board, bool status)
        {
            bool lightOn = board.StatusLed4();
            if (lightOn && !status) board.TurnOffLed4();
            if (!lightOn && status) board.TurnOnLed4();
        }

        #endregion

        #endregion

        #region Temperature Management

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void SetAutomaticTemperatureManagement()
        {

        }

        public static void SetManualTemperatureManagement()
        {

        }

        #region Private methods
        private static void SetAirco(AdamBoard2 board, bool status)
        {
            bool ventOn = board.StatusVentilator();
            if (ventOn && !status) board.TurnOffVentilator();
            if (!ventOn && status) board.TurnOnVentilator();
        }

        private static void SetHeating(AdamBoard1 board, bool status)
        {
            bool ventOn = board.StatusVentilator();
            if (ventOn && !status) board.TurnOffVentilator();
            if (!ventOn && status) board.TurnOnVentilator();
        }
        #endregion

        #endregion
    }
}
