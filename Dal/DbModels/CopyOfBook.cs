using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class CopyOfBook
{
    public int Id { get; set; }

    public int? IdBook { get; set; }

    public virtual Book IdBookNavigation { get; set; }

    public virtual ICollection<IssuedBook> IssuedBooks { get; set; } = new List<IssuedBook>();
}
