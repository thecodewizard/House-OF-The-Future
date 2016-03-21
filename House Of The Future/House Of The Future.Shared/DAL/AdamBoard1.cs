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
        public const String IP = "172.23.49.102";
        public const int PORT = 502;

        #region 172.23.49.101

        /// <summary>
        /// Make a new Adamboard:
        /// 00017 - Lamp
        /// 00018 - Ventilator
        /// </summary>
        public AdamBoard1()
        {
            this.OpenConnetion(IP, PORT);
        }

        #region ventilator1
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

        #region lamp
        public void TurnOnLamp()
        {
            if(!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00017, true);
            Socket.Modbus().ForceSingleCoil(00018, true);
            Console.WriteLine("Done");
        }
        public void TurnOffLamp()
        {
            throw new NotImplementedException();
        }
        public bool StatusLamp()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region inputs
        public short StatusPotentiometer1()
        {
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
