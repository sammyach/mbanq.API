using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqLoanRepayment
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public int? PaymentMethodId { get; set; }
        public decimal? AmountPaid { get; set; }
        public DateTime? DateCollected { get; set; }
        public string? CollectedBy { get; set; }

        public virtual MbqLoan Loan { get; set; } = null!;
        public virtual MbqPaymentMethodType? PaymentMethod { get; set; }
    }
}
