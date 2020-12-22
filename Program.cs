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
            //IP_TR asd = new IP_TR();
            //SqlConnection data_base = new SqlConnection("server=172.16.150.200;UID=sa;PWD=1qaz@WSX;Database=EDIAS_DB;Trusted_connection=False");
            //SqlCommand newcommand = new SqlCommand(@"SELECT [EqpID],
            //                                                  [InspDate]
            //                                                  ,[ModelID]
            //                                                  ,[InnerID]
            //                                                  ,[VcrID]
            //                                                  ,[MviUser]
            //                                                  ,[LastResult]
            //                                                  ,[LastJudge]
            //                                                  ,[DbInTime]
            //                                                  ,[OperationID]
            //                                                  ,[StageID]
            //                                                  ,[LastResultName]
            //                                                  ,[ProductType]
            //                                                  ,[MergeToolJudge]
            //                                                  ,[DefectName]
            //                                              FROM[EDIAS_DB].[dbo].[TAX_PRODUCT_TEST]
            //                                              WHERE InspDate BETWEEN '20201221000000' AND '20201221010000'", data_base);
            //data_base.Open();
            //SqlDataReader reader = newcommand.ExecuteReader();

            //while (reader.Read())
            //{
            //    Console.WriteLine("{0}\t{1}", reader.GetString(0),reader.GetString(1));
            //    string a = reader.GetString(1);
            //    char[] b = a.ToCharArray();
            //    int c = (int)b[0];
            //}
            //reader.Close();
            ////SqlDataAdapter selectadapter = new SqlDataAdapter();
            ////selectadapter.SelectCommand = newcommand;

            //DataSet newdata = new DataSet();


            ////selectadapter.SelectCommand.ExecuteNonQuery();
            ////selectadapter.Fill(newdata);
            //data_base.Close();
            Operator a = new Operator();
            a.name = "asdasd";
            Console.WriteLine(a.name);
        }
    }
}
