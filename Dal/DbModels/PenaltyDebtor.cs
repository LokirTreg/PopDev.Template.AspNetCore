using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class PenaltyDebtor
{
    public int Id { get; set; }

    public int? IdPenalty { get; set; }

    public int? IdDebtor { get; set; }

    public virtual Debtor IdDebtorNavigation { get; set; }

    public virtual Penalty IdPenaltyNavigation { get; set; }
}
