using Advantech.Adam;
using House_Of_The_Future.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace House_Of_The_Future.Shared.DAL
{
    public class AdamBoard1 : DAL
    {
        public const String IP = "172.23.49.101";
        public const int PORT = 502;

        #region 172.23.49.101

        /// <summary>
        /// Make a new Adamboard:
        /// 00017 - Lamp
        /// 00018 - Ventilator
        /// </summary>
        public AdamBoard1()
        {
            this.OpenConnection(IP, PORT);
        }

        #region ventilator1
        public void TurnOnVentilator()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00018, true);
            Console.WriteLine("Board 1 - ventilator turned on");
        }
        public void TurnOffVentilator()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00018, false);
            Console.WriteLine("Board 1 - ventilator turned off");
        }
        public bool StatusVentilator()
        {
            if (!isConnected()) throw new NotConnectedException("The Ventilator is not connected");

            bool[] status = new bool[1];
            Socket.Modbus().ReadCoilStatus(00018, 1, out status);
            return status.First<bool>();
        }
        #endregion

        #region lamp
        public void TurnOnLamp()
        {
            if(!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00017, true);
            Console.WriteLine("Board 1 - lamp turned on");
        }
        public void TurnOffLamp()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00017, false);
            Console.WriteLine("Board 1 - lamp turned off");
        }
        public bool StatusLamp()
        {
            if (!isConnected()) throw new NotConnectedException("The Lamp is not connected");

            bool[] status = new bool[1];
            Socket.Modbus().ReadCoilStatus(00017, 1, out status);
            return status.First<bool>();
        }
        #endregion

        #region inputs
        public short StatusPotentiometer1()
        {
            if (!isConnected()) throw new NotConnectedException("Potentiometer1 is not connected");

            //byte[] status = new byte[25];
            //Socket.Modbus().ReadInputRegs(00003, 250, out status);
            //return status.First<byte>();
            throw new NotImplementedException();
        }
        public short StatusPotentiometer2()
        {
            throw new NotImplementedException();
        }
        public short StatusPotentiometer3()
        {
            throw new NotImplementedException();
        }
        public bool StatusSwitch1()
        {
            throw new NotImplementedException();
        }
        public bool StatusSwitch2()
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
