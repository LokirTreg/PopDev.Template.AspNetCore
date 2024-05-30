using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class IssuedBook
{
    public int Id { get; set; }

    public DateTime? DateOfIssue { get; set; }

    public DateTime? DateOfPlannedDelivery { get; set; }

    public int? IdReader { get; set; }

    public int? IdLibrarian { get; set; }

    public int? IdCopyOfBook { get; set; }

    public virtual ICollection<Debtor> Debtors { get; set; } = new List<Debtor>();

    public virtual CopyOfBook IdCopyOfBookNavigation { get; set; }

    public virtual Librarian IdLibrarianNavigation { get; set; }

    public virtual Reader IdReaderNavigation { get; set; }
}
