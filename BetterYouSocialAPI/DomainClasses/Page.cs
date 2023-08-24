using System;
using System.Collections.Generic;

namespace BetterYouSocialAPI
{
    public class Page
    {
        public Page()
        {

        }
        public int PageId { get; set; }
        public List<int> AuthorizedUsers { get; set; }
        public List<Tuple<int,int,PageElement>> Layout { get; set; }
    }
}
