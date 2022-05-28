using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqLoan
    {
        public MbqLoan()
        {
            MbqLoanRepayments = new HashSet<MbqLoanRepayment>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime? DateApplied { get; set; }
        public DateTime? DateReleased { get; set; }
        public DateTime? MaturityDate { get; set; }
        public string? RepaymentFrequency { get; set; }
        public decimal? Principal { get; set; }
        public decimal? Fee { get; set; }
        public decimal? Penalty { get; set; }
        public decimal? AmountDue { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? Balance { get; set; }
        public int? StatusId { get; set; }

        public virtual MbqCustomer Customer { get; set; } = null!;
        public virtual MbqLoanStatus? Status { get; set; }
        public virtual ICollection<MbqLoanRepayment> MbqLoanRepayments { get; set; }
    }
}
