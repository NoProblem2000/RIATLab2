namespace RIATLab2
{
    class Client
    {
        public Request Request;

        public Client(ISerializer iSerializer, string dom, int port)
        {
            Request = new Request(iSerializer, dom, port);
        }

        public void Ping()
        {
            Request.SendRequest(TypeRequest.GET, "Ping");
        }

        public Input GetInputData()
        {
            return Request.SendRequestInput(TypeRequest.GET, "GetInputData");
        }

        public void WriteAnswer(Output output)
        {
           Request.SendRequest(TypeRequest.POST, "WriteAnswer", output);
        }
    }
}