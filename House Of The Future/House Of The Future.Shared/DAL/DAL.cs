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
    public abstract class DAL
    {
        public AdamSocket Socket { get; private set; }

        public void OpenConnection(String IP, int PORT)
        {
            AdamSocket socket = new AdamSocket();
            socket.Connect(IP, ProtocolType.Tcp, PORT);
            if (socket.Connected) this.Socket = socket;
            else
                throw new NoSocketException("Could not open Connection in Board 1");
        }
        public void CloseConnection()
        {
            if (isConnected()) Socket.Disconnect();
        }
        public bool isConnected()
        {
            if (Socket == null) return false;
            return Socket.Connected;
        }
    }
}
