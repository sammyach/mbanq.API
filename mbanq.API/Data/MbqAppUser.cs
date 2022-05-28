using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqAppUser
    {
        public MbqAppUser()
        {
            MbqAppUserRoles = new HashSet<MbqAppUserRole>();
        }

        public int Id { get; set; }
        public string Uid { get; set; } = null!;
        public string? Email { get; set; }
        public string? Surname { get; set; }
        public string? Forename { get; set; }
        public string? Othernames { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? OtherPhone { get; set; }
        public byte[]? PasswordHash { get; set; }
        public int? BranchId { get; set; }
        public bool? Enabled { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public byte[]? Nacl { get; set; }

        public virtual MbqBranch? Branch { get; set; }
        public virtual ICollection<MbqAppUserRole> MbqAppUserRoles { get; set; }
    }
}
