using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace tcpclient
{
    class Program
    {
        static void Main(string[] args)
        {
            String StrServAddr;
            Console.WriteLine("Podaj Adres IPv4 servera: ");
            StrServAddr = Console.ReadLine();
            byte[] data = new byte[1024];
            string input, stringData;
            TcpClient server;
            try
            {
                //server = new TcpClient("192.168.200.107", 55555);
                //server = new TcpClient("192.168.200.107", 55555);
                server = new TcpClient(StrServAddr, 55555);
            }
            catch (SocketException)
            {
                Console.WriteLine("Unable to connect to server");
                Console.ReadKey();
                return;
            }

            NetworkStream ns = server.GetStream();
            int recv = ns.Read(data, 0, data.Length);
            stringData = Encoding.ASCII.GetString(data, 0, recv);
            Console.WriteLine(stringData);

            while (true)
            {
                input = Console.ReadLine();
                if (input == "exit")
                    break;
                ns.Write(Encoding.ASCII.GetBytes(input), 0, input.Length);
                ns.Flush();
                data = new byte[1024];
                recv = ns.Read(data, 0, data.Length);
                stringData = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine(stringData);
            }
            Console.WriteLine("Disconnecting from server...");
            ns.Close();
            server.Close();
            Console.ReadKey();
        }
    }
}