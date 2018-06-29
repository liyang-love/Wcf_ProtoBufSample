using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_ProtoBufSample.Service
{
    [ServiceContract, ProtoContract]
    public interface IGreeterService
    {
        [OperationContract]
        Reply Get(Request request);
    }
    public class GreeterService : IGreeterService
    {
        public Reply Get(Request request)
        {
            Reply reply = new Reply() { GreetInfo = "你好！" + request.Name + ",恭喜你" + request.Age + "岁了！" };
            return reply;
        }
    }
    [DataContract]
    [ProtoContract]
    public class Request
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public string Name { set; get; }
        [DataMember(Order = 1)]
        [ProtoMember(2)]
        public int Age { set; get; }
    }
    [DataContract]
    [ProtoContract]
    public class Reply
    {
        [DataMember(Order = 0)]
        [ProtoMember(1)]
        public string GreetInfo { set; get; }
    }
}
