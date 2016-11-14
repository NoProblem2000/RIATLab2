using System.Text;

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

        public Input GetInputData()
        {
            return request.SendRequestInput(TypeRequest.GET, "GetInputData");
        }

        public void WriteAnswer(Output output)
        {
           request.SendRequest(TypeRequest.POST, "WriteAnswer", output);
        }
    }
}