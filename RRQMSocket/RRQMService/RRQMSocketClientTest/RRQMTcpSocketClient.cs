using RRQMSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketClientLiberal
{
    /// <summary>
    /// 该类是经过封装的TCP的辅助类
    /// </summary>
    public class RRQMTcpSocketClient : RRQMSocketClient
    {
        int a;
        /// <summary>
        /// 该方法的主要作用是处理接收到的TCP流数据
        /// 该数据与发送方完全一致
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="r"></param>
        public override void RRQMTcpHandleBuffer(byte[] buffer, int index, int length)
        {
            lock (this)
            {
                if (++a % 1000 == 0)
                {
                    Console.WriteLine(a);
                }
            }

            string mes = Encoding.UTF8.GetString(buffer,index,length);
            this.Send(Encoding.UTF8.GetBytes(mes));//通过默认Send方法，把收到的数据原数返回，该数据完全和Client收到的数据一致
        }
    }
}
