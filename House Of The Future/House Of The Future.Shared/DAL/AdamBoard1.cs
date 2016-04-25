using Advantech.Adam;
using House_Of_The_Future.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace House_Of_The_Future.Shared.DAL
{
    public class AdamBoard1 : DAL
    {
        public const String IP = "172.23.49.101";
        public const int PORT = 502;
        public const double potentioTreshold = 1.812;
        public const double potentioMaximum = 4.837;

        #region 172.23.49.101

        /// <summary>
        /// Make a new Adamboard:
        /// 00017 - Lamp
        /// 00018 - Ventilator
        /// 
        /// FLOAT VALUES:
        /// 0 -
        /// 1 - Switch Naast Potentiometer
        /// 2 - Switch Naast LED op box 
        /// 3 - Temperatuur sensor (0 is warm, 4.837 is max) - 2 is lampwarm, 3 is ventilatorkoud
        /// 4 -
        /// 5 - Potentiometer Links (0 is min, 4.837 is max)
        /// 6 - Potentiometer Center (0 is min, 4.837 is max)
        /// 7 - Potentiometer Rechts (0 is min, 4.837 is max)
        /// </summary>
        public AdamBoard1()
        {
            this.OpenConnection(IP, PORT);
            Console.WriteLine(StatusPotentiometer2().ToString());
        }

        #region ventilator1
        public void TurnOnVentilator()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00018, true);
            Thread.Sleep(_waitTime);
            Console.WriteLine("Board 1 - ventilator turned on");
        }
        public void TurnOffVentilator()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00018, false);
            Thread.Sleep(_waitTime);
            Console.WriteLine("Board 1 - ventilator turned off");
        }
        public bool StatusVentilator()
        {
            if (!isConnected()) throw new NotConnectedException("The Ventilator is not connected");

            bool[] status = new bool[1];
            Socket.Modbus().ReadCoilStatus(00018, 1, out status);
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

        #region lamp
        public void TurnOnLamp()
        {
            if(!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00017, true);
            Thread.Sleep(_waitTime);
            Console.WriteLine("Board 1 - lamp turned on");
        }
        public void TurnOffLamp()
        {
            if (!isConnected()) return;
            Socket.Modbus().ForceSingleCoil(00017, false);
            Thread.Sleep(_waitTime);
            Console.WriteLine("Board 1 - lamp turned off");
        }
        public bool StatusLamp()
        {
            if (!isConnected()) throw new NotConnectedException("The Lamp is not connected");

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
        public TemperatureEnum StatusPotentiometer1()
        {
            if (!isConnected()) throw new NotConnectedException("Board 1 - Potentiometer 1 is not connected");

            Adam4000_ChannelStatus[] boardStatus;
            float[] inputValues = new float[100];
            bool success = Socket.AnalogInput().GetValues(8, out inputValues, out boardStatus);
            Thread.Sleep(_waitTime);
            float statusPotentiometer = inputValues[5];

            if (statusPotentiometer < potentioTreshold) return TemperatureEnum.AIRCO;
            else if (statusPotentiometer > (potentioMaximum - potentioTreshold)) return TemperatureEnum.HEATING;
            else return TemperatureEnum.NONE;
        }
        public float StatusPotentiometer2()
        {
            if (!isConnected()) throw new NotConnectedException("Board 1 - Potentiometer2 is not connected");

            Adam4000_ChannelStatus[] boardStatus;
            float[] inputValues = new float[100];
            bool success = Socket.AnalogInput().GetValues(8, out inputValues, out boardStatus);
            Thread.Sleep(_waitTime);
            float statusPotentiometer = inputValues[6];

            return statusPotentiometer;
        }
        public float StatusPotentiometer3()
        {
            Adam4000_ChannelStatus[] boardStatus;
            float[] inputValues = new float[100];
            bool success = Socket.AnalogInput().GetValues(8, out inputValues, out boardStatus);
            Thread.Sleep(_waitTime);
            float statusPotentiometer = inputValues[7];

            return statusPotentiometer;
        }
        public bool StatusSwitch1()
        {
            Adam4000_ChannelStatus[] boardStatus;
            float[] inputValues = new float[100];
            bool success = Socket.AnalogInput().GetValues(8, out inputValues, out boardStatus);
            Thread.Sleep(_waitTime);
            float statusSwitch = inputValues[1];

            if (statusSwitch >= (potentioMaximum / 2)) return true;
            else return false;
        }
        public bool StatusSwitch2()
        {
            Adam4000_ChannelStatus[] boardStatus;
            float[] inputValues = new float[100];
            bool success = Socket.AnalogInput().GetValues(8, out inputValues, out boardStatus);
            Thread.Sleep(_waitTime);
            float statusSwitch = inputValues[2];

            if (statusSwitch >= (potentioMaximum / 2)) return true;
            else return false;
        }
        public double StatusTemperatureSensor()
        {
            Adam4000_ChannelStatus[] boardStatus;
            float[] inputValues = new float[100];
            bool success = Socket.AnalogInput().GetValues(8, out inputValues, out boardStatus);
            Thread.Sleep(_waitTime);
            float tempStatus = inputValues[3];

            return tempStatus; //Returns the status in Volt.
        }
        #endregion

        #endregion
    }
}
