using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class BookGenre
{
    public int Id { get; set; }

    public int? IdGenre { get; set; }

    public int? IdBook { get; set; }

    public virtual Book IdBookNavigation { get; set; }

    public virtual Genre IdGenreNavigation { get; set; }
}
