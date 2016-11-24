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

        public HttpWebResponse Create(TypeRequest type, string method, int timeout)
        {
            CreateHttpWebRequest(type,method, timeout);
            return HttpWebResponse;
        }

        public HttpWebResponse Create(TypeRequest type, string method, object obj, int timeout)
        {
            CreateHttpWebRequest(type, method, timeout);
            CreateHttpWebRequestWithBody(obj);
            return HttpWebResponse;
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

        public void CreateHttpWebRequestWithBody(object obj)
        {
            var requestBody = serializer.Serialize(obj);
            byte[] array = Encoding.UTF8.GetBytes(requestBody);
            httpWebRequest.ContentLength = requestBody.Length;
            httpWebRequest.GetRequestStream().Write(array, 0, requestBody.Length);
            httpWebRequest.GetResponse();
        }

    }
}