using System;
using RRQMSocket.RPC;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
namespace RRQMRPC.RRQMTest
{
    public static class RPC_Server
    {
        public static RRQMSocket.RPC.RPCClient RPCClient { get; set; }
        public static void SayHelloWait(out System.Int32 ac, int waitTime = 3)
        {
            if (RPCClient == null)
            {
                throw new RRQMRPCException("RPCClient为空，请先初始化或者进行赋值");
            }
            List<object> list = new List<object>();
            list.Add(default(System.Int32));
            object[] parameters = list.ToArray();
            RPCClient.RPCInvoke("SayHelloWait", ref parameters, waitTime);
            ac = default(System.Int32);
            if (parameters != null)
            {
                ac = (System.Int32)parameters[0];
            }
        }
        public static T SayHello02<T>(T ac, int waitTime = 3)
        {
            if (RPCClient == null)
            {
                throw new RRQMRPCException("RPCClient为空，请先初始化或者进行赋值");
            }
            List<object> list = new List<object>();
            list.Add(ac);
            object[] parameters = list.ToArray();
            T returnData = RPCClient.RPCInvoke<T>("SayHello02", ref parameters, waitTime);
            ac = default(T);
            if (parameters != null)
            {
                ac = (T)parameters[0];
            }
            return returnData;
        }
        public static async Task<T> BeginSayHello02<T>(T ac, int waitTime = 3)
        {
            if (RPCClient == null)
            {
                throw new RRQMRPCException("RPCClient为空，请先初始化或者进行赋值");
            }
            return await Task.Run(() => {
                return SayHello02(ac, waitTime);
            });
        }
        public static System.String SayHello(System.Int32 i, int waitTime = 3)
        {
            if (RPCClient == null)
            {
                throw new RRQMRPCException("RPCClient为空，请先初始化或者进行赋值");
            }
            List<object> list = new List<object>();
            list.Add(i);
            object[] parameters = list.ToArray();
            System.String returnData = RPCClient.RPCInvoke<System.String>("SayHello", ref parameters, waitTime);
            i = default(System.Int32);
            if (parameters != null)
            {
                i = (System.Int32)parameters[0];
            }
            return returnData;
        }
        public static async Task<System.String> BeginSayHello(System.Int32 i, int waitTime = 3)
        {
            if (RPCClient == null)
            {
                throw new RRQMRPCException("RPCClient为空，请先初始化或者进行赋值");
            }
            return await Task.Run(() => {
                return SayHello(i, waitTime);
            });
        }
    }
}