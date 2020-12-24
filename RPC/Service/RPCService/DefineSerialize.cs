using RRQMSocket;
using RRQMSocket.RPC;

namespace Service
{
    /*
    若汝棋茗
    */
    /// <summary>
    /// 自定义序列化类
    /// </summary>
    public class DefineSerialize : SerializeConverter
    {
        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public  RPCMethod Deserialize(byte[] buffer)
        {
            //用RRQMSocket自带的反序列化方法模拟
            //使用者可以根据自身需要，选择json等反序列化。
            return SerializeConvert.DeserializeWithBinary<RPCMethod>(buffer, 0, buffer.Length);
        }

        public override RPCMethod Deserialize(byte[] buffer, int index, int length)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="waitResult"></param>
        /// <returns></returns>
        public override byte[] Serialize(RPCMethod waitResult)
        {
            //用RRQMSocket自带的序列化方法模拟
            //使用者可以根据自身需要，选择json等序列化。
            return SerializeConvert.SerializeToBinary(waitResult);
        }
    }
}