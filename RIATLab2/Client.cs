using System;
using System.Security.Cryptography.X509Certificates;

namespace RIATLab2
{
    class Client
    {
        public Request request;

        public Client(ISerializer iSerializer, string dom, int port)
        {
            request = new Request(iSerializer, dom, port);
        }

        public void Ping()
        {
            request.SendRequest(TypeRequest.GET, "Ping");
        }

        public void Find(DictionaryLab2 keyvalue)
        {
            request.SendRequest(TypeRequest.GET, CreateFindDictionary(keyvalue));
        }

        public void Create<T>(T obj)
        {
            request.SendRequest(TypeRequest.POST, "Create", obj);
        }

        public Input GetInputData()
        {
            return request.SendRequestInput(TypeRequest.GET, "GetInputData");
        }

        public void WriteAnswer(Output output)
        {
            request.SendRequest(TypeRequest.POST, "WriteAnswer");
        }

        public string CreateFindDictionary(DictionaryLab2 keyvalue)
        {
            return string.Format("Find?{0} = {1}", keyvalue.Key, keyvalue.Value);
        }
    }
}