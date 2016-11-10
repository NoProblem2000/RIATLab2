using System;

namespace RIATLab2
{
    public  class Program
    {
        public static void  Main(string[] args)
        {
            ISerializer iSerializer = new JsonSerializer();
            var dom = "127.0.0.1";
            var port = int.Parse(Console.ReadLine());

            Client client = new Client(iSerializer, dom, port);
            client.Ping();
            Input input = iSerializer.Deserialize<Input>(Convert.ToString(client.GetInputData()));
            client.Create(input);
            client.WriteAnswer(input.DoOutPut());
        }
    }
}
