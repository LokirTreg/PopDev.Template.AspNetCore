using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Reader
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual ICollection<IssuedBook> IssuedBooks { get; set; } = new List<IssuedBook>();

    public virtual ICollection<Queue> Queues { get; set; } = new List<Queue>();
}
