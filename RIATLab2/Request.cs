using System;
using System.IO;
using System.Net;
using System.Text;

namespace RIATLab2
{
    public class Request
    {
        public ISerializer IsSerializer;
        public RequestCreate requestCreate;
        public string url;
        

        public Request(ISerializer iSerializer, string dom, int port)
        {
            url = string.Format("http://{0}", dom.IndexOf('/') != -1
                ? dom.Insert(dom.IndexOf('/'), string.Format(":{0}",port))
                : string.Format("{0}:{1}", dom, port));
            IsSerializer = iSerializer;
            requestCreate = new RequestCreate(iSerializer, url);
        }

       
        public void SendRequest(TypeRequest httpRequestType, string method, int timeoutMs = 1000)
        {
            while (true)
            {
                try
                {
                    requestCreate.Create(httpRequestType, method, timeoutMs);
                }
                catch (WebException e)
                {
                    if (e.Status != WebExceptionStatus.Timeout &&
                        e.Status != WebExceptionStatus.ReceiveFailure &&
                        e.Status != WebExceptionStatus.NameResolutionFailure)
                        throw;
                }
            }
        }

        public void SendRequest(TypeRequest httpRequestType, string method, object obj, int timeoutMs = 1000)
        {
            while (true)
            {
                try
                {
                    requestCreate.Create(httpRequestType, method, obj, timeoutMs);
                }
                catch (WebException e)
                {
                    if (e.Status != WebExceptionStatus.Timeout &&
                        e.Status != WebExceptionStatus.ReceiveFailure &&
                        e.Status != WebExceptionStatus.NameResolutionFailure)
                        throw;

                }
            }
        }

        public Input SendRequestInput(TypeRequest httpRequestType, string method,  ISerializer iSerializer, int timeoutMs = 1000)
        {
            while (true)
            {
                try
                {
                    var item = requestCreate.Create(httpRequestType, method, timeoutMs).GetResponseStream();
                    using (var streamReader = new StreamReader(item, Encoding.UTF8))
                            return iSerializer.Deserialize<Input>(Convert.ToString(Encoding.UTF8.GetBytes(streamReader.ReadToEnd())));
                }
                catch (WebException e)
                {
                    if (e.Status != WebExceptionStatus.Timeout &&
                        e.Status != WebExceptionStatus.ReceiveFailure &&
                        e.Status != WebExceptionStatus.NameResolutionFailure)
                        throw;
                }
            }
        }
    }

    
}