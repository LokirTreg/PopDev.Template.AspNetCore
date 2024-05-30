using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Book
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string YearOfPublish { get; set; }

    public int? Circulation { get; set; }

    public int? IdPublisher { get; set; }

    public virtual ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();

    public virtual ICollection<BookGenre> BookGenres { get; set; } = new List<BookGenre>();

    public virtual ICollection<CopyOfBook> CopyOfBooks { get; set; } = new List<CopyOfBook>();

    public virtual Publisher IdPublisherNavigation { get; set; }

    public virtual ICollection<Queue> Queues { get; set; } = new List<Queue>();
}
