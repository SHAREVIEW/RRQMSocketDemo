using RRQMSocket;
using RRQMSocket.RPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    /*
    若汝棋茗
    */
    public class ClientServer : ClientProvider
    {
        [RRQMRPCMethod]
        public string Say()
        {
            return "若汝棋茗";
        }
    }
}
