using RRQMSocket;
using System;

namespace SocketClientLiberal
{
    /*
    若汝棋茗
    */

    /// <summary>
    /// 该类是简单TCP的辅助类
    /// </summary>
    public class SimpleTcpSocketClient : TcpSocketClient
    {
        int a = 0;
        #region Methods

        /// <summary>
        /// 该方法的主要作用是处理接收到的TCP流数据
        /// 该数据与发送方不完全一致，可能会发生粘包，分包等情况。
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="r"></param>
        public override void HandleBuffer(byte[] buffer, int r)
        {
            if (++a%100==0)
            {
                Console.WriteLine(a);
            }
            this.Send(buffer,0,r);//通过默认Send方法，把收到的数据原数返回，该数据亦不完全和Client收到的数据一致，可能会发生粘包，分包等情况。
        }

        #endregion Methods
    }
}
