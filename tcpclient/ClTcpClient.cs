using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcpclient
{
    class ClTcpClient
    {//string StrServAddr, int IntSocket
        public static void client()
        {


            try
            {
                TcpClient tcpclnt = new TcpClient();
                Console.WriteLine("Łączenie.....");

                tcpclnt.Connect("192.168.200.107", 55555);

                Console.WriteLine("Połączono");
                Console.WriteLine("wpisz:'exit' aby przerwać połączenie, tekst by wysłać.");
                while (true)
                {
                    String str = Console.ReadLine();
                    if (str == "exit")
                    {
                        break;
                    }
                    Stream stm = tcpclnt.GetStream();

                    ASCIIEncoding asen = new ASCIIEncoding();
                    byte[] ba = asen.GetBytes(str);
                    Console.WriteLine("Przesyłam tekst.....");

                    stm.Write(ba, 0, ba.Length);

                    byte[] bb = new byte[100];
                    int k = stm.Read(bb, 0, 100);

                    for (int i = 0; i < k; i++)
                        Console.Write(Convert.ToChar(bb[i]));
                }
                tcpclnt.Close();
            }

            catch (Exception e)
            {
                Console.WriteLine("błąd..... " + e.StackTrace);
            }
        }
    }
}
