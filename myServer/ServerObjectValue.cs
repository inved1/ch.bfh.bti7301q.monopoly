using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace myServer
{
    class ServerObjectValue
    {
        static void Main(string[] args)
        {
            TcpChannel chan = new TcpChannel(8085);
            ChannelServices.RegisterChannel(chan,false );

            RemotingConfiguration.RegisterWellKnownServiceType(Type.GetType("myClassLibServer.HelloServer, myClassLibServer"), "RemoteTestRef", WellKnownObjectMode.SingleCall);
            
            Console.WriteLine("Zum Beenden <Eingabetaste> drücken");
            Console.ReadLine();
        }
    }
}
