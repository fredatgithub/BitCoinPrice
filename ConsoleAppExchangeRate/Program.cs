using ConsoleAppExchangeRate.Controller;
using Newtonsoft.Json;
using System;
using System.Threading;

namespace ConsoleAppExchangeRate
{
  class Program
  {
    static void Main()
    {
      Action<string> display = Console.WriteLine;
      string apiUrl = "https://api.coindesk.com/v1/bpi/currentprice.json";
      var myJsonResponse = InternetHelper.GetAPIFromUrl(apiUrl);
      Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
      DateTime theDate = myDeserializedClass.Time.UpdatedISO;
      double rateEuros = myDeserializedClass.Bpi.EUR.Rate_float;
      double rateDollar = myDeserializedClass.Bpi.USD.Rate_float;
      var latestDate = DALHelper.GetLatestDate();
      DateTime latestDateFromDB = DateTime.Parse(latestDate);
      // commit new rates if not recorded yet.
      bool insertResult = false;
      while (true)
      {
        myJsonResponse = InternetHelper.GetAPIFromUrl(apiUrl);
        myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        theDate = myDeserializedClass.Time.UpdatedISO;
        rateEuros = myDeserializedClass.Bpi.EUR.Rate_float;
        rateDollar = myDeserializedClass.Bpi.USD.Rate_float;
        display($"Date : {theDate} - EUR : {rateEuros}");
        latestDate = DALHelper.GetLatestDate();
        latestDateFromDB = DateTime.Parse(latestDate);

        if (latestDateFromDB < DateTime.Now.AddMinutes(-1))
        {
          insertResult = DALHelper.WriteToDatabase(theDate, rateEuros, rateDollar);
        }

        Thread.Sleep(1000 * 60);
      }
    }
  }
}
