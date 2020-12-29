using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace server
{
    class Program
    {
        static void Main(string[] args)
        {
            IP_TR theip = new IP_TR();
            File_container the_file = new File_container(theip);
            the_file.Refresh_file_list();
        }

        static void initial_class()
        {

        }

        static void test()
        {

        }

        static void old()
        {
            ResponseSocket responseSocket = new ResponseSocket("@tcp://*:5555");
            sqlserver_connecter sqlserver = new sqlserver_connecter();
            IP_TR ip_tr = new IP_TR();
            File_container file_container = new File_container(ip_tr);

            var timer = new NetMQTimer(TimeSpan.FromSeconds(3600));

            //using (var req = new RequestSocket(">tcp://127.0.0.1:5555"))
            using (var poller = new NetMQPoller { responseSocket, timer })
            {
                responseSocket.ReceiveReady += (s, a) =>
                {
                    //
                    bool more;
                    string messageIn = a.Socket.ReceiveFrameString(out more);
                    Console.WriteLine("messageIn = {0}", messageIn);
                    a.Socket.SendFrame("World");
                    for (int i = 0; i < 1000000000; i++)
                    {
                        long b = i * i;
                    }
                    Console.WriteLine("finish");
                };
                timer.Elapsed += (s, a) =>
                {
                    //
                    Console.WriteLine("start refresh the panel list");

                };
                poller.Run();
            }
        }
    }
}
