using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqLoanStatus
    {
        public MbqLoanStatus()
        {
            MbqLoans = new HashSet<MbqLoan>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<MbqLoan> MbqLoans { get; set; }
    }
}
