using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using myClassLibServer;


namespace myClient
{
    class ClientAppValue
    {
        static void Main(string[] args)
        {
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan,false );
            ForwardMe objForwardMe = new ForwardMe();

            HelloServer objHelloServer;

            objHelloServer = (HelloServer)Activator.GetObject(
                    typeof(HelloServer),
                    "tcp://localhost:8085/RemoteTestRef");
            if (objHelloServer == null)
                Console.WriteLine("Server wurde nicht gefunden.");
            else
            {
                objHelloServer.HelloMethod(objForwardMe);
                Console.WriteLine("Methode wurde ausgeführt, Ausgabe erfolgt im Serverfenster.");
            }
            Console.WriteLine("Zum Beenden <EINGABETASTE> drücken...");
            Console.ReadLine(); 

        }
    }
}
