﻿using Advantech.Adam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using House_Of_The_Future.Shared.Models;

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
            //socket.Modbus().ForceSingleCoil(00017, false);
            //socket.Modbus().ForceSingleCoil(00018, false);
            //socket.Modbus().ForceSingleCoil(00019, false);
            //socket.Modbus().ForceSingleCoil(00020, false);
            //socket.Modbus().ForceSingleCoil(00021, false);
        }

        #region leds
        #region led1
        public void TurnOnLed1()
        {
            throw new NotImplementedException();
        }
        public void TurnOffLed1()
        {
            throw new NotImplementedException();
        }
        public bool StatusLed1()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region led2
        public void TurnOnLed2()
        {
            throw new NotImplementedException();
        }
        public void TurnOffLed2()
        {
            throw new NotImplementedException();
        }
        public bool StatusLed2()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region led3
        public void TurnOnLed3()
        {
            throw new NotImplementedException();
        }
        public void TurnOffLed3()
        {
            throw new NotImplementedException();
        }
        public bool StatusLed3()
        {
            throw new NotImplementedException();
        }
        #endregion
        #region led4
        public void TurnOnLed4()
        {
            throw new NotImplementedException();
        }
        public void TurnOffLed4()
        {
            throw new NotImplementedException();
        }
        public bool StatusLed4()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion

        #region ventilator
        public void TurnOnVentilator()
        {
            throw new NotImplementedException();
        }
        public void TurnOffVentilator()
        {
            throw new NotImplementedException();
        }
        public bool StatusVentilator()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region inputs
        public bool StatusRedSwitch()
        {

            //byte[] status = new byte[1];
            //Socket.Modbus().ReadCoilStatus(00001, 1, out status);
            //return status.First<byte>();

            //Board 1
            /* If red switch on -> return 3. If gb -> return 4. If bb -> return 8; ... */
            throw new NotImplementedException();
        }
        public bool StatusGreenButton()
        {
            throw new NotImplementedException();
        }
        public bool StatusBlackButton()
        {
            throw new NotImplementedException();
        }
        public double StatusProximity()
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
