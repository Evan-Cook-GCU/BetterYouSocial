using System.Collections.Generic;

namespace BetterYouSocialAPI
{
  public class Group
  {
    public int GroupId { get; set; }
        //foreign ket to a user who owns the group
    public int OwnerId { get; set; }
    public List<User> Memebers { get; set; }
    public int Rating { get; set; }
    public Page Layout { get; set; }
    public List<Metric> Metrics { get; set; }
    }
}