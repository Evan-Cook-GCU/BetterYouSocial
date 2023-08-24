using System.Collections.Generic;

namespace BetterYouSocialAPI
{
    public class User
    {
        public User()
        {

        }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Group> Groups { get; set; }
    }
}
