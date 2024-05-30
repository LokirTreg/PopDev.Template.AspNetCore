using System;
using System.Collections.Generic;

namespace Dal.DbModels;

public partial class Penalty
{
    public int Id { get; set; }

    public int? SizeOfPenalty { get; set; }

    public virtual ICollection<PenaltyDebtor> PenaltyDebtors { get; set; } = new List<PenaltyDebtor>();
}
