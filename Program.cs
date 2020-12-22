using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace server
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //ResponseSocket responseSocket = new ResponseSocket("@tcp://*:5555");

            //var timer = new NetMQTimer(TimeSpan.FromSeconds(2));
            //Console.WriteLine("start the poller");
            //using (var req = new RequestSocket(">tcp://127.0.0.1:5555"))
            //using (var poller = new NetMQPoller { responseSocket, timer })
            //{
            //    responseSocket.ReceiveReady += (s, a) => 
            //    {
            //        //
            //        bool more;
            //        string messageIn = a.Socket.ReceiveFrameString(out more);
            //        Console.WriteLine("messageIn = {0}", messageIn);
            //        a.Socket.SendFrame("World");
            //        for (int i = 0; i < 1000000000; i++)
            //        {
            //            long b = i * i;
            //        }
            //        Console.WriteLine("finish");
            //    };
            //    timer.Elapsed += (s, a) =>
            //    {
            //        //
            //        Console.WriteLine("start refresh the panel list");
            //    };
            //    poller.Run();
            //}
            IP_TR asd = new IP_TR();
            List<string>bb = asd.get_ip_byeq(PC_name.AVI, new List<int> { 1, 2, 3 });
        }
    }
}
