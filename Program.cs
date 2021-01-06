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
            old();
            //test();
        }

        static void test()
        {
            SqlServerConnector sqlserver = new SqlServerConnector();
            sqlserver.get_oninspect_mission();
        }

        static void old()
        {
            var timer = new NetMQTimer(TimeSpan.FromSeconds(1800));
            ResponseSocket responseSocket = new ResponseSocket("@tcp://*:5555");
            //using (var req = new RequestSocket(">tcp://127.0.0.1:5555"))
            using (var poller = new NetMQPoller { responseSocket, timer })
            {
                
                SqlServerConnector sqlserver = new SqlServerConnector();
                IP_TR ip_tr = new IP_TR();
                Filecontainer file_container = new Filecontainer(ip_tr);
                OnInspectPanelContainer MissionManager = new OnInspectPanelContainer(sqlserver, file_container);

                responseSocket.ReceiveReady += (s, a) =>
                {
                    bool more;
                    string messageIn = a.Socket.ReceiveFrameString(out more);
                    if (messageIn == "AddMisionByServer")
                    {
                        Console.WriteLine("start add mission");
                        MissionManager.AddMisionByServer();
                        a.Socket.SendFrame("end add");
                    }
                    else if (messageIn == "CleanMission")
                    {
                        // do something else.
                        Console.WriteLine("start clean");
                        MissionManager.MissionQueue.Clear();
                        a.Socket.SendFrame("end clean");
                    }
                    else if (messageIn == "GetMission")
                    {
                        // do something else.
                        Console.WriteLine("start send mission");
                        a.Socket.SendFrame(MissionManager.GetMission().PanelId);
                    }
                    Console.WriteLine("count = {0}", MissionManager.MissionQueue.Count);
                    Console.WriteLine("finish");
                };

                timer.Elapsed += (s, a) =>
                {
                    //
                    Console.WriteLine("start refresh the panel list");
                    file_container.Refresh_file_list();
                };
                poller.Run();
            }
        }
    }
}
