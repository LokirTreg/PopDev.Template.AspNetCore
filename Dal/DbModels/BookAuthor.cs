using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class BookAuthor
{
    public int Id { get; set; }

    public int? IdAuthor { get; set; }

    public int? IdBook { get; set; }

    public virtual Author IdAuthorNavigation { get; set; }

    public virtual Book IdBookNavigation { get; set; }
}
