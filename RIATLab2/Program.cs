﻿using System;

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
            Input input = client.GetInputData();
            client.WriteAnswer(input.DoOutPut());
        }
    }
}
