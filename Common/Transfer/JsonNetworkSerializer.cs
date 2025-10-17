using System;
using System.Net.Sockets;
using System.Text.Json;

namespace Common.Transfer
{
    public class JsonNetworkSerializer
    {
        private Socket socket;
        private NetworkStream stream;   
        private StreamReader reader;
        private StreamWriter writer;

        public JsonNetworkSerializer(Socket s)
        {
            socket = s;
            stream=new NetworkStream(socket);
            reader=new StreamReader(stream);
            writer=new StreamWriter(stream);
            writer.AutoFlush = true;
        }

        public void PosaljiPoruku(Object o)
        {
            if(stream==null || socket==null || !stream.CanWrite) return;
            writer.WriteLine(JsonSerializer.Serialize(o));  
        }

        public T PrimiPoruku<T>()
        {
            string json = reader.ReadLine();
            if (json == null) throw new Exception("Konekcija sa serverom je zatvorena");
            return JsonSerializer.Deserialize<T>(json);
        }

        public T ReadType<T>(Object o)
        {
            return JsonSerializer.Deserialize<T>((JsonElement)o);
        }
    }
}
