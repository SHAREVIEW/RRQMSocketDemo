using RRQMSocket;
using RRQMSocket.RPC;
using Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class Program
    {
        static void Main(string[] args)
        {

           

            RRQMRPCService rpcService = new RRQMRPCService();

            BindSetting bindSetting = new BindSetting();
            bindSetting.IP = "127.0.0.1";
            bindSetting.Port = 7789;
            bindSetting.MultithreadThreadCount = 1;

            rpcService.Bind(bindSetting);

            RPCServerSetting setting = new RPCServerSetting();
            setting.RPCServerMode = RPCServerMode.Senior;
            setting.NameSpace = "RRQMTest";
            rpcService.OpenRPCServer(setting);


            //序列化方式选择自定义的时候，必须对SerializeConverter属性赋值
            //类似于DefineSerialize类，该类继承于SerializeConverter抽象类，并强制重写序列化和反序列化方法。
            //序列化方式应该让服务器端和客户端保持一致，当然不局限于同一个类，但是也要能对数据进行正确的序列化和反序列化。
            rpcService.SerializeConverter = new RRQMSocket_SerializeConverter.JsonSerializeConverter();


            Console.WriteLine("绑定成功");
            Console.WriteLine("按任意键测试反向调用");
            Console.ReadKey();

            // TestSerialize();

            string mes = ((RRQMRPCSocketClient)rpcService.SocketClients[0]).RPCInvoke<string>("Say");
            Console.WriteLine("返回：" + mes);
            Console.ReadKey();
        }

        static int a = 0;
        private static void FileService_ReceiveSystemMes(object sender, MesEventArgs e)
        {
            if (++a % 1000 == 0)
            {
                Console.WriteLine(a);
            }
        }



    }
}
