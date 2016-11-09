using System.IO;
using System.Net;

namespace RIATLab2
{
    public class RequestCreate
    {
        public static ISerializer serializer;
        public static string url;
        public static HttpWebRequest httpWebRequest { get; set; }

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
        }

        public void CreateHttpWebRequestWithBody<T>(T obj)
        {
            var requestBody = serializer.Serialize(obj);
            httpWebRequest.ContentLength = requestBody.Length;
            using (Stream stream = httpWebRequest.GetRequestStream())
                stream.Write(requestBody, 0, requestBody.Length);
        }

    }
}