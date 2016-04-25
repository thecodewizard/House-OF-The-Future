using Advantech.Adam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using House_Of_The_Future.Shared.Models;
using System.Threading;

namespace House_Of_The_Future.Shared.DAL
{
    public class AdamBoard2 : DAL
    {
        public const String IP = "172.23.49.102";
        public const int PORT = 502;

        #region 172.23.49.102

        /// <summary>
        /// Make a new Adamboard:
        /// 00001 & 00002 - Rode switch
        /// 00003 - Groene Knop
        /// 00004 - Zwarte Knop
        /// 00005 - 00006 - 00007 - 00008 - Proximity Sensor
        /// 00017 - Ventilator
        /// 00018 - LED 1
        /// 00019 - LED 2
        /// 00020 - LED 3
        /// 00021 - LED 4
        /// </summary>
        public AdamBoard2()
        {
            this.OpenConnection(IP, PORT);
            //StatusProximity();
            //Socket.Modbus().ForceSingleCoil(00017, false);
            //socket.Modbus().ForceSingleCoil(00018, false);
            //socket.Modbus().ForceSingleCoil(00019, false);
            //socket.Modbus().ForceSingleCoil(00020, false);
            //socket.Modbus().ForceSingleCoil(00021, false);
        }

        #region leds
        #region led1
        public void TurnOnLed1()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00018, true);
            Thread.Sleep(_waitTime);
        }
        public void TurnOffLed1()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00018, false);
            Thread.Sleep(_waitTime);
        }
        public bool StatusLed1()
        {
            if (!isConnected()) throw new NotConnectedException("Board 2 - Led1 is not connected.");
            bool[] status = new bool[1];
            Socket.Modbus().ReadCoilStatus(00018, 1, out status);
            Thread.Sleep(_waitTime);

            bool result;
            try
            {
                result = status.First<bool>();
            } catch
            {
                result = false;
            }
            return result;
        }
        #endregion
        #region led2
        public void TurnOnLed2()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00019, true);
            Thread.Sleep(_waitTime);
        }
        public void TurnOffLed2()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00019, false);
            Thread.Sleep(_waitTime);
        }
        public bool StatusLed2()
        {
            if (!isConnected()) throw new NotConnectedException("Board 2 - Led2 is not connected.");
            bool[] status = new bool[1];
            Socket.Modbus().ReadCoilStatus(00019, 1, out status);
            Thread.Sleep(_waitTime);

            bool result;
            try
            {
                result = status.First<bool>();
            }
            catch
            {
                result = false;
            }
            return result;
        }
        #endregion
        #region led3
        public void TurnOnLed3()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00020, true);
            Thread.Sleep(_waitTime);
        }
        public void TurnOffLed3()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00020, false);
            Thread.Sleep(_waitTime);
        }
        public bool StatusLed3()
        {
            if (!isConnected()) throw new NotConnectedException("Board 2 - Led3 is not connected.");
            bool[] status = new bool[1];
            Socket.Modbus().ReadCoilStatus(00020, 1, out status);
            Thread.Sleep(_waitTime);

            bool result;
            try
            {
                result = status.First<bool>();
            }
            catch
            {
                result = false;
            }
            return result;
        }
        #endregion
        #region led4
        public void TurnOnLed4()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00021, true);
            Thread.Sleep(_waitTime);
        }
        public void TurnOffLed4()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00021, false);
            Thread.Sleep(_waitTime);
        }
        public bool StatusLed4()
        {
            if (!isConnected()) throw new NotConnectedException("Board 2 - Led4 is not connected.");
            bool[] status = new bool[1];
            Socket.Modbus().ReadCoilStatus(00021, 1, out status);
            Thread.Sleep(_waitTime);

            bool result;
            try
            {
                result = status.First<bool>();
            }
            catch
            {
                result = false;
            }
            return result;
        }
        #endregion
        #endregion

        #region ventilator
        public void TurnOnVentilator()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00017, true);
            Thread.Sleep(_waitTime);
        }
        public void TurnOffVentilator()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00017, false);
            Thread.Sleep(_waitTime);
        }
        public bool StatusVentilator()
        {
            if (!isConnected()) throw new NotConnectedException("Board 2 - ventilator is not connected.");
            bool[] status = new bool[1];
            Socket.Modbus().ReadCoilStatus(00017, 1, out status);
            Thread.Sleep(_waitTime);

            bool result;
            try
            {
                result = status.First<bool>();
            }
            catch
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region inputs
        public bool StatusRedSwitch()
        {
            //Board 1
            /* If red switch on -> return 3. If gb -> return 4. If bb -> return 8; ... */

            if (!isConnected()) throw new NotConnectedException("Board 2 - Red switch is not connected.");

            bool[] status = new bool[1];
            Socket.Modbus().ReadInputStatus(00001, 1, out status);
            Thread.Sleep(_waitTime);

            bool result;
            try
            {
                result = status.First<bool>();
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public bool StatusGreenButton()
        {
            if (!isConnected()) throw new NotConnectedException("Board 2 - Green button is not connected.");
            bool[] status = new bool[1];
            Socket.Modbus().ReadInputStatus(00003, 1, out status);
            Thread.Sleep(_waitTime);

            bool result;
            try
            {
                result = status.First<bool>();
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public bool StatusBlackButton()
        {
            if (!isConnected()) throw new NotConnectedException("Board 2 - Black button is not connected.");
            bool[] status = new bool[1];
            Socket.Modbus().ReadInputStatus(00004, 1, out status);
            Thread.Sleep(_waitTime);

            bool result;
            try
            {
                result = status.First<bool>();
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public ProximityEnum StatusProximity()
        {
            if (!isConnected()) throw new NotConnectedException("Board 2 - Proximity sensor is not connected.");
            bool[] status = new bool[4];
            Socket.Modbus().ReadInputStatus(00005, 4, out status);
            Thread.Sleep(_waitTime);

            ProximityEnum result;
            try
            {
                if (status[3]) result = ProximityEnum.CLOSEST;
                else if (status[2]) result = ProximityEnum.CLOSE;
                else if (status[1]) result = ProximityEnum.NEAR;
                else if (status[0]) result = ProximityEnum.FAR;
                else result = ProximityEnum.DISTANT;
            } catch
            {
                result = ProximityEnum.DISTANT;
            }
            return result;

        }
        #endregion

        #endregion

    }
}
