using RRQMSocket;
using RRQMSocket.RPC;
using RRQMXml;
using Service;
using System;
using System.Diagnostics;
using System.Threading;
using TransferModels;

namespace RRQMTcpClient
{
    class Program
    {
        static RPCClient rpcClient;

        static void Main(string[] args)
        {

            Console.ReadKey();
            //TestMultipleClientTime();

            rpcClient = new RPCClient();
            rpcClient.SerializeType = SerializeType.Xml;
            ConnectSetting confirmSocket = new ConnectSetting();
            confirmSocket.TargetIP = "127.0.0.1";
            //confirmSocket.TargetIP = "47.98.255.233";
            confirmSocket.TargetPort = 7789;

            rpcClient.Connect(confirmSocket);

            //rpcClient.GetRPCReferencedAssemblies(@"C:\Users\17516\Desktop\新建文件夹\");
            // Console.WriteLine("连接成功");
            // Console.ReadKey();
         string s=   XmlTool.SerializeToXml(typeof(RPCMethod),new RPCMethod());
             RRQMRPC.RRQMTest.RPC_Server.RPCClient = rpcClient;
            RRQMRPC.RRQMTest.RPC_Server.BeginSayHello(new Test());
            //string mes= RRQMRPC.RRQMTest.RPC_Server.SayHello();
            ////for (int i = 0; i < 1000; i++)
            ////{

            ////    string mes = rpcClient.RPCInvoke<string>("SayHello");
            ////    Console.WriteLine(mes);
            ////}

            //string mes1 = rpcClient.RPCInvoke<string>("SayHello");
            //Console.WriteLine(mes1);
            //string mes2 = rpcClient.RPCInvoke<string>("SayHelloTwo");
            //Console.WriteLine(mes2);

            //RRQMRPC.RRQMTest.RPC_ServerTwo.RPCClient = rpcClient;


            //Test();




            // ThreadPool.QueueUserWorkItem(TestSayHello);
            //ThreadPool.QueueUserWorkItem(TestSayHelloWait);

            Console.ReadKey();

            Console.ReadKey();
        }

        //private async static void Test()
        //{
        //   // string s = await RRQMRPC.RRQMTest.RPC_ServerTwo.BeginSayHelloTwo();
        //}

        static Stopwatch stopwatchTestMultipleClientTime;
        static int TestMultipleClientTimeCount = 1;
        static int TestMultipleClientTimeFinishedCount;
        private static void TestMultipleClientTime()
        {
            stopwatchTestMultipleClientTime = new Stopwatch();
            stopwatchTestMultipleClientTime.Start();
            TestMultipleClientTimeFinishedCount = 0;
            for (int i = 0; i < TestMultipleClientTimeCount; i++)
            {
                ThreadPool.QueueUserWorkItem(TestMultipleClient, i);
            }
        }

        private static void TestMultipleClient(object o)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            RPCClient client = new RPCClient();

            client.SerializeType = SerializeType.Define;
            //序列化方式选择自定义的时候，必须对SerializeConverter属性赋值
            //类似于DefineSerialize类，该类继承于SerializeConverter抽象类，并强制重写序列化和反序列化方法。
            //序列化方式应该让服务器端和客户端保持一致，当然不局限于同一个类，但是也要能对数据进行正确的序列化和反序列化。
            client.SerializeConverter = new DefineSerialize();

            ConnectSetting confirmSocket = new ConnectSetting();
            confirmSocket.TargetIP = "127.0.0.1";

            confirmSocket.TargetPort = 7789;

            client.Connect(confirmSocket);

            for (int i = 0; i < 100000; i++)
            {
                client.RPCInvoke<string>("SayHello");
            }

            stopwatch.Stop();
            Console.WriteLine(o.ToString() + "->" + stopwatch.Elapsed);

            if (++TestMultipleClientTimeFinishedCount == TestMultipleClientTimeCount)
            {
                stopwatchTestMultipleClientTime.Stop();
                Console.WriteLine("总时间->" + stopwatchTestMultipleClientTime.Elapsed);
            }
        }

        private static void TestSayHello(object o)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100000; i++)
            {
                rpcClient.RPCInvoke<string>("SayHello", 10);
            }
            stopwatch.Stop();
            Console.WriteLine("SayHello->" + stopwatch.Elapsed);
        }

        private static void TestSayHelloWait(object o)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < 100; i++)
            {
                rpcClient.RPCInvoke<string>("SayHelloWait", 10);
            }
            stopwatch.Stop();
            Console.WriteLine("SayHelloWait->" + stopwatch.Elapsed);
        }



    }
}
