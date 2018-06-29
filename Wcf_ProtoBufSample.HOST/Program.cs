using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Wcf_ProtoBufSample.Service;

namespace Wcf_ProtoBufSample.HOST
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(GreeterService)))
            {
                host.Opened += delegate
                               {
                                   Console.WriteLine("CalculaorService已经启动，按任意键终止服务！");
                               };

                host.Open();
                Console.Read();
            }
        }
    }
}
