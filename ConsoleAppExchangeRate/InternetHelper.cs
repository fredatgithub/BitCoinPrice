using System.IO;
using System.Net;

namespace ConsoleAppExchangeRate
{
  public static class InternetHelper
  {
    public static string GetAPIFromUrl(string url)
    {
      ServicePointManager.Expect100Continue = true;
      ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
             | SecurityProtocolType.Tls11
             | SecurityProtocolType.Tls12
             | SecurityProtocolType.Ssl3;

      WebRequest request = (HttpWebRequest)WebRequest.Create(url);
      WebResponse response = request.GetResponse();
      Stream dataStream = response.GetResponseStream();
      StreamReader reader = new StreamReader(dataStream);
      string responseFromServer = reader.ReadToEnd();
      reader.Close();
      response.Close();
      return responseFromServer;
    }
  }
}
