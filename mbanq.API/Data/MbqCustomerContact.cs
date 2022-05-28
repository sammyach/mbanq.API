using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqCustomerContact
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? OtherPhone { get; set; }
        public string? Email { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? DigitalAddress { get; set; }
        public string? PostalAddress { get; set; }

        public virtual MbqCustomer? Customer { get; set; }
    }
}
