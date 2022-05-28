using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqCustomer
    {
        public MbqCustomer()
        {
            MbqCustomerContacts = new HashSet<MbqCustomerContact>();
            MbqCustomerDocuments = new HashSet<MbqCustomerDocument>();
            MbqCustomerGuarantors = new HashSet<MbqCustomerGuarantor>();
            MbqCustomerNextOfKins = new HashSet<MbqCustomerNextOfKin>();
            MbqLoans = new HashSet<MbqLoan>();
        }

        public int Id { get; set; }
        public string Uid { get; set; } = null!;
        public string? Surname { get; set; }
        public string? Forename { get; set; }
        public string? OtherNames { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public bool? Verified { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public int? BranchId { get; set; }
        public string? Occupation { get; set; }
        public string? Employer { get; set; }
        public string? EmployerContact { get; set; }

        public virtual ICollection<MbqCustomerContact> MbqCustomerContacts { get; set; }
        public virtual ICollection<MbqCustomerDocument> MbqCustomerDocuments { get; set; }
        public virtual ICollection<MbqCustomerGuarantor> MbqCustomerGuarantors { get; set; }
        public virtual ICollection<MbqCustomerNextOfKin> MbqCustomerNextOfKins { get; set; }
        public virtual ICollection<MbqLoan> MbqLoans { get; set; }
    }
}
