using System;
using System.Net.Sockets;
using System.Text;
using ServerTypes;
using Newtonsoft.Json;

namespace Server
{
    public class ClientObject
    {
        public TcpClient client;
        public ClientObject(TcpClient tcpClient)
        {
            client = tcpClient;
        }

        public void Process()
        {
            NetworkStream stream = null;
            try
            {
                stream = client.GetStream();           
                while (true)
                {
                    byte[] buffer = new byte[64];

                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(buffer, 0, buffer.Length);
                        builder.Append(Encoding.UTF8.GetString(buffer, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    Command command = JsonConvert.DeserializeObject<Command>(builder.ToString());    

                    string result = JsonConvert.SerializeObject((Activator.CreateInstance(command.CommandType) as ICommand).Execute(command.Parameters), Formatting.Indented);

                    buffer = Encoding.UTF8.GetBytes(result);

                    stream.Write(buffer, 0, buffer.Length);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (stream != null)
                    stream.Close();
                if (client != null)
                    client.Close();
            }
        }
    }
}
