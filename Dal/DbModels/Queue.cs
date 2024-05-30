using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Queue
{
    public int Id { get; set; }

    public int? NumberInQueue { get; set; }

    public int? IdReader { get; set; }

    public int? IdBook { get; set; }

    public virtual Book IdBookNavigation { get; set; }

    public virtual Reader IdReaderNavigation { get; set; }
}
