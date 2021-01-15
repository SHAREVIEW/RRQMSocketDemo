using RRQMSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRQMClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();

            // SimpleTcpClientTest();
           RRQMTcpClientTest();

            Console.ReadKey();
        }

        static void SimpleTcpClientTest()
        {
            SimpleTcpClient client = new SimpleTcpClient();

            ConnectSetting connectSetting = new ConnectSetting();
            connectSetting.TargetIP = "127.0.0.1";
            connectSetting.TargetPort = 7789;

            client.Connect(connectSetting);
            Console.WriteLine("连接成功");

            for (int i = 0; i < 10000; i++)
            {
                // Console.ReadKey();
                client.Send(Encoding.UTF8.GetBytes("若汝棋茗"));
            }
        }

        static void RRQMTcpClientTest()
        {
            RRQMTcpClient client = new RRQMTcpClient();

            ConnectSetting connectSetting = new ConnectSetting();
            connectSetting.TargetIP = "127.0.0.1";
            connectSetting.TargetPort = 7789;
            connectSetting.MultithreadThreadCount = 1;
            client.Connect(connectSetting);
            Console.WriteLine("连接成功");

            for (int i = 0; i < 100000000; i++)
            {
                if (i%10000==0)
                {
                    Console.WriteLine(i);
                }
                
                byte[] vs = Encoding.UTF8.GetBytes("若汝棋茗");
                client.Send(vs);
            }
        }
    }
}
