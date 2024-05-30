using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();
}
