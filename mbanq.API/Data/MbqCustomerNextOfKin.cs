using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqCustomerNextOfKin
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public string? Surname { get; set; }
        public string? Forename { get; set; }
        public byte[]? OtherNames { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? OtherPhone { get; set; }
        public string? Email { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? DigitalAddress { get; set; }
        public byte[]? PhotoUrl { get; set; }

        public virtual MbqCustomer? Customer { get; set; }
    }
}
