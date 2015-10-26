using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace connection_memoryleak_test
{
    class Program
    {
        static void Main(string[] args)
        {
            int total_count = 100000;
            int cur_count = 0;

            while(cur_count < total_count)
            {
                cur_count++;

                Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 90));

                Thread.Sleep(1000);

                sock.Disconnect(true);
                sock.Close();
                sock = null;
            }
        }
    }
}
