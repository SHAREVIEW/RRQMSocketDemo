using RRQMSocket.RPC;
using System;
using System.Threading;
using System.Xml.Serialization;

namespace Service
{
    /*
    若汝棋茗
    */

    public class ServerTwo : ServerProvider
    {
        [RRQMRPCMethod]
        public void TestServerTwo_NullReturnNullParameter()
        {
            Console.WriteLine("TestServerTwo_NullReturnNullParameter");
        }
    }
    public class Server : ServerProvider
    {

        [RRQMRPCMethod]
        public void TestNullReturnNullParameter()
        {
            Console.WriteLine("TestNullReturnNullParameter");
        }
        
        [RRQMRPCMethod]
        public string TestStringReturnNullParameter()
        {
            Console.WriteLine("TestStringReturnNullParameter");
            return "若汝棋茗";
        }
        
        [RRQMRPCMethod]
        public void TestNullReturnStringParameter(string name)
        {
            Console.WriteLine($"TestNullReturnStringParameter,String:{name}");
        }
        
        [RRQMRPCMethod]
        public void TestNullReturnOutStringParameter(out string name)
        {
            Console.WriteLine($"TestNullReturnOutStringParameter");
            name = "若汝棋茗";
        }
        
        [RRQMRPCMethod]
        public string TestStringReturnOutStringParameter(out string name)
        {
            Console.WriteLine($"TestStringReturnOutStringParameter");
            name = "若汝棋茗";
            return name;
        }
        
        [RRQMRPCMethod]
        public void TestNullReturnRefStringParameter(ref string name)
        {
            Console.WriteLine($"TestStringReturnOutStringParameter,String:{name}");
            name = "若汝棋茗";
        }
        
        [RRQMRPCMethod]
        public void TestNullReturnOutParameters(out string name, out int age, out string occupation)
        {
            Console.WriteLine($"TestNullReturnOutParameters");
            name = "若汝棋茗";
            age = 23;
            occupation = "搬砖工程师";
        }
        
        [RRQMRPCMethod]
        public T TestTReturnTParameter<T>(T t)
        {
            Console.WriteLine($"TestTReturnTParameter");
            return t;
        }
        
       
        [RRQMRPCMethod]
        public T TestTReturnRefTParameter<T>(ref T t)
        {
            Console.WriteLine($"TestTReturnRefTParameter");
            T tt = t;
            t = default(T);
            return tt;
        }
        
       
        int a;
        /// <summary>
        /// 测试性能
        /// </summary>
        [RRQMRPCMethod]
        public void TestPerformance()
        {
            if (++a % 1000 == 0)
            {
                Console.WriteLine($"TestPerformance,a={a}");
            }
        }
    }

}
