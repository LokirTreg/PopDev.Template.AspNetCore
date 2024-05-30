using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Publisher
{
    public int Id { get; set; }

    public string Title { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
