﻿using System.Collections.Generic;

namespace BetterYouSocialAPI
{
  public class Author
  {
    public Author()
    {
      Books = new List<Book>();
    }
    public int AuthorId { get; set; }
    public string Name { get; set; }
    public List<Book> Books { get; set; }
  }
}
