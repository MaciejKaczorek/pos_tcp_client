using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcpclient
{
    class ClRand
    {
        public static string GenerateStr()
        {
            string StrRand = Path.GetRandomFileName();
            StrRand = StrRand.Replace(".", ""); // Remove period.
            return StrRand;
        }
    }
}
