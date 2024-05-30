using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Debtor
{
    public int Id { get; set; }

    public int? IdIssuedBook { get; set; }

    public virtual IssuedBook IdIssuedBookNavigation { get; set; }

    public virtual ICollection<PenaltyDebtor> PenaltyDebtors { get; set; } = new List<PenaltyDebtor>();
}
