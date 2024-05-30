using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Author
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
}
