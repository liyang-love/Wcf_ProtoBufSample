using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Wcf_ProtoBufSample.ClientViaReference
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IGreeterService> factory = new ChannelFactory<IGreeterService>("GreeterService");
            IGreeterService client = factory.CreateChannel();
            var res = client.Get(new Request() { Name = "liam", Age = 18 });
            Console.WriteLine(res.GreetInfo);
            Console.ReadKey();
        }
    }

    [ServiceContract, ProtoContract]
    public interface IGreeterService
    {
        [OperationContract]
        Reply Get(Request request);
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
