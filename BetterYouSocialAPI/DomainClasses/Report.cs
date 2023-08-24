using System.Collections.Generic;

namespace BetterYouSocialAPI
{
  public class Report
  {
    public int ReportId { get; set; }
    public int GroupId { get; set; }
    public List<Metric> Metrics { get; set; }
  }
}