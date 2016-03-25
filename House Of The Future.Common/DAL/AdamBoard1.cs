using Advantech.Adam;
using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Of_The_Future.Common.DAL
{
    public class AdamBoard1
    {
        public const String IP = "172.23.49.101";
        public const int PORT = 502;
        #region 172.23.49.101

        #region general
        public static void OpenConnetion1()
        {
            AdamSocket socket = new AdamSocket();
            socket.Connect(AdamType.Adam6000, IP, ProtocolType)
        }
        public static void CloseConnetion1()
        {
            throw new NotImplementedException();
        }
        public static bool CheckConnetion1()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ventilator1
        public static void TurnOnVentilator1()
        {
            throw new NotImplementedException();
        }
        public static void TurnOffVentilator1()
        {
            throw new NotImplementedException();
        }
        public static bool StatusVentilator1()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region lamp
        public static void TurnOnLamp()
        {
            throw new NotImplementedException();
        }
        public static void TurnOffLamp()
        {
            throw new NotImplementedException();
        }
        public static bool StatusLamp()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region inputs
        public static short StatusPotentiometer1()
        {
            throw new NotImplementedException();
        }
        public static short StatusPotentiometer2()
        {
            throw new NotImplementedException();
        }
        public static short StatusPotentiometer3()
        {
            throw new NotImplementedException();
        }
        public static bool StatusSwitch1()
        {
            throw new NotImplementedException();
        }
        public static bool StatusSwitch2()
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
