using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqPaymentMethodType
    {
        public MbqPaymentMethodType()
        {
            MbqLoanRepayments = new HashSet<MbqLoanRepayment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<MbqLoanRepayment> MbqLoanRepayments { get; set; }
    }
}
