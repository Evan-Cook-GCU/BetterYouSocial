using System;

namespace BetterYouSocialAPI
{
  public class Metric
  {
    public int MetricId { get; set; }
        //foreign key to Metric types
    public int Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    public DateTime Date { get; set; }
  }
}