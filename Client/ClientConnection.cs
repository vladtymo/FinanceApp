using ServerTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Client
{
    static public class ClientConnection
    {
        static private TcpClient client;

        static public void Connect(string address, int port)
        {
            try
            {
                client = new TcpClient(address, port);
            }
            catch (Exception)
            {
                client = null;
            }
            
        }

        static public CommandResult Send(ICommand command, object parameters)
        {
            if(client == null)
            {
                return null;
            }

            try
            {
                NetworkStream stream = client.GetStream();

                byte[] buffer = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(new Command(parameters, command.GetType()), Formatting.Indented));

                stream.Write(buffer, 0, buffer.Length);

                buffer = new byte[64]; 
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(buffer, 0, buffer.Length);
                    builder.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
                }
                while (stream.DataAvailable);

                return JsonConvert.DeserializeObject<CommandResult>(builder.ToString());
            }
            catch (Exception)
            {
                Close();
                return null;
            }           
        }
        static public void Close()
        {
            client = null;
        }

    }
}
