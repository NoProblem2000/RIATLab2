using System.IO;
using System.Net;
using System.Text;

namespace RIATLab2
{
    public class RequestCreate
    {
        public static ISerializer serializer;
        public static string url;
        public static HttpWebRequest httpWebRequest { get; set; }
        public HttpWebResponse HttpWebResponse;

        public RequestCreate(ISerializer serializer1, string url1)
        {
            serializer = serializer1;
            url = url1;
        }

        public void Create(TypeRequest type, string method, int timeout)
        {
            CreateHttpWebRequest(type,method, timeout);
        }

        public void Create<T>(TypeRequest type, string method, T obj, int timeout)
        {
            CreateHttpWebRequest(type, method, timeout);
            CreateHttpWebRequestWithBody(obj);
        }

        public void CreateHttpWebRequest(TypeRequest type,string method, int timeout)
        {
            
            httpWebRequest = (HttpWebRequest) WebRequest.Create(string.Format("{0}/{1}",url, method));
            httpWebRequest.Timeout = timeout;
            httpWebRequest.Method = type.ToString();
            if (type == TypeRequest.GET)
            {
                HttpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            }
        }

        public void CreateHttpWebRequestWithBody<T>(T obj)
        {
            var requestBody = serializer.Serialize(obj);
            byte[] array = Encoding.ASCII.GetBytes(requestBody);
            httpWebRequest.ContentLength = requestBody.Length;
            httpWebRequest.GetRequestStream().Write(array, 0, requestBody.Length);
            httpWebRequest.GetResponse();
        }

    }
}