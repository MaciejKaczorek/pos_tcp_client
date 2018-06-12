using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace tcpclient
{
    class Program
    {        
         static void Main(string[] args)
        {
            
            ClTcpClient.client();
        }

        
}
}