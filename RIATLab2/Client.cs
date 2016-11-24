namespace RIATLab2
{
    class Client
    {
        public Request Request;
        private ISerializer iSerializer;

        public Client(ISerializer iSerializer, string dom, int port)
        {
            this.iSerializer = iSerializer;
            Request = new Request(iSerializer, dom, port);
        }

        public void Ping()
        {
            Request.SendRequest(TypeRequest.GET, "Ping");
        }

        public Input GetInputData()
        {
            return Request.SendRequestInput(TypeRequest.GET, "GetInputData", iSerializer);
        }

        public void WriteAnswer(Output output)
        {
           Request.SendRequest(TypeRequest.POST, "WriteAnswer", output);
        }
    }
}