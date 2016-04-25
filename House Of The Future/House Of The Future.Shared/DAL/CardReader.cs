using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House_Of_The_Future.Shared.DAL
{
    public class CardReader 
    {
        public CardReader()
        {
            //WriteTestToCard();
            ReadCard();
        }
        public void ReadCard()
        {
            int retCode, Protocol = 0, hContext = 0, hCard = 0, Readercount = 0;
            byte[] ReaderListBuff = new byte[262];
            byte[] ReaderGroupBuff = new byte[262];
            bool diFlag;
            ModWinsCard.SCARD_IO_REQUEST ioRequest = new ModWinsCard.SCARD_IO_REQUEST();
            int sendLen, recvLen;
            byte[] RecvBuff = new byte[262];
            byte[] SendBuff = new byte[262];
            Readercount = RecvBuff.Length;
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

            ModWinsCard.SCardListReaders(hContext, ReaderGroupBuff, ReaderListBuff, ref Readercount);
            String cardName = Encoding.UTF8.GetString(ReaderListBuff).Substring(0, Readercount);
            ModWinsCard.SCardConnect(hContext, cardName, ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0, ref hCard, ref Protocol);
            ModWinsCard.SCardBeginTransaction(hCard);

            ioRequest.dwProtocol = Protocol;
            ioRequest.cbPciLength = 8;

            Array.Clear(SendBuff, 0, SendBuff.Length);
            Array.Clear(RecvBuff, 0, RecvBuff.Length);
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0x04;
            SendBuff[2] = 0x0;
            SendBuff[3] = 0x0;
            SendBuff[4] = 0x01;
            SendBuff[5] = 0x1;
            sendLen = 6; recvLen = RecvBuff.Length;
            retCode = ModWinsCard.SCardTransmit(hCard, ref ioRequest, ref SendBuff[0], sendLen, ref ioRequest, ref RecvBuff[0], ref recvLen);

            Array.Clear(SendBuff, 0, SendBuff.Length);
            Array.Clear(RecvBuff, 0, RecvBuff.Length);
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0xB0;
            SendBuff[2] = 0x0;
            SendBuff[3] = 0x0;
            SendBuff[4] = 0x10;
            sendLen = 5; recvLen = RecvBuff.Length;
            retCode = ModWinsCard.SCardTransmit(hCard, ref ioRequest, ref SendBuff[0], sendLen, ref ioRequest, ref RecvBuff[0], ref recvLen);
            String read = GetString(RecvBuff);

            ModWinsCard.SCardDisconnect(hCard, 2);
            ModWinsCard.SCardReleaseContext(hContext);
        }

        public void WriteTestToCard()
        {
            int retCode, Protocol = 0, hContext = 0, hCard = 0, Readercount = 0;
            byte[] ReaderListBuff = new byte[262];
            byte[] ReaderGroupBuff = new byte[262];
            bool diFlag;
            ModWinsCard.SCARD_IO_REQUEST ioRequest = new ModWinsCard.SCARD_IO_REQUEST();
            int sendLen, recvLen;
            byte[] RecvBuff = new byte[262];
            byte[] SendBuff = new byte[262];
            Readercount = RecvBuff.Length;
            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);
            ioRequest.dwProtocol = Protocol;
            ioRequest.cbPciLength = 8;
            retCode = ModWinsCard.SCardListReaders(hContext, ReaderGroupBuff, ReaderListBuff, ref Readercount);
            String cardName = Encoding.UTF8.GetString(ReaderListBuff).Substring(0, Readercount-2);
            retCode = ModWinsCard.SCardConnect(hContext, cardName, ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0, ref hCard, ref Protocol);
            retCode = ModWinsCard.SCardBeginTransaction(hCard);

            ioRequest.dwProtocol = Protocol;
            ioRequest.cbPciLength = 8;

            Array.Clear(SendBuff, 0, SendBuff.Length);
            Array.Clear(RecvBuff, 0, RecvBuff.Length);
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0x04;
            SendBuff[2] = 0x0;
            SendBuff[3] = 0x0;
            SendBuff[4] = 0x01;
            SendBuff[5] = 0x1;
            sendLen = 6; recvLen = RecvBuff.Length;
            retCode = ModWinsCard.SCardTransmit(hCard, ref ioRequest, ref SendBuff[0], sendLen, ref ioRequest, ref RecvBuff[0], ref recvLen);

            Array.Clear(SendBuff, 0, SendBuff.Length);
            Array.Clear(RecvBuff, 0, RecvBuff.Length);
            SendBuff[0] = 0xFF;
            SendBuff[1] = 0xD0;
            SendBuff[2] = 0x0;
            SendBuff[3] = 0x0;
            SendBuff[4] = 0x2;
            SendBuff[5] = 65;
            SendBuff[6] = 66;
            //int i = 5;
            //foreach(byte b in GetBytes("abcabca"))
            //{
            //    SendBuff[i] = b;
            //    i++;
            //}
            sendLen = 7; recvLen = RecvBuff.Length;
            retCode = ModWinsCard.SCardTransmit(hCard, ref ioRequest, ref SendBuff[0], sendLen, ref ioRequest, ref RecvBuff[0], ref recvLen);

            ModWinsCard.SCardDisconnect(hCard, 2);
            ModWinsCard.SCardReleaseContext(hContext);
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
