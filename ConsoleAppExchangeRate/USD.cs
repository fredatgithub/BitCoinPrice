using System;

namespace ConsoleAppExchangeRate
{
  // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
  public class Time
  {
    public string Updated { get; set; }
    public DateTime UpdatedISO { get; set; }
    public string Updateduk { get; set; }

  }

  public class USD
  {
    public string Code { get; set; }
    public string Symbol { get; set; }
    public string Rate { get; set; }
    public string Description { get; set; }
    public double Rate_float { get; set; }

  }

  public class GBP
  {
    public string Code { get; set; }
    public string Symbol { get; set; }
    public string Rate { get; set; }
    public string Description { get; set; }
    public double Rate_float { get; set; }

  }

  public class EUR
  {
    public string Code { get; set; }
    public string Symbol { get; set; }
    public string Rate { get; set; }
    public string Description { get; set; }
    public double Rate_float { get; set; }

  }

  public class Bpi
  {
    public USD USD { get; set; }
    public GBP GBP { get; set; }
    public EUR EUR { get; set; }

  }

  public class Root
  {
    public Time Time { get; set; }
    public string Disclaimer { get; set; }
    public string ChartName { get; set; }
    public Bpi Bpi { get; set; }
  }
}
