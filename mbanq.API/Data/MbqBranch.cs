using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqBranch
    {
        public MbqBranch()
        {
            MbqAppUsers = new HashSet<MbqAppUser>();
        }

        public int Id { get; set; }
        public int OrganizationId { get; set; }
        public string? ResidentialAddress { get; set; }
        public string? DigitalAddress { get; set; }
        public string? City { get; set; }
        public int? RegionId { get; set; }
        public int? StateId { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

        public virtual MbqOrganization Organization { get; set; } = null!;
        public virtual MbqRegion? Region { get; set; }
        public virtual MbqState? State { get; set; }
        public virtual ICollection<MbqAppUser> MbqAppUsers { get; set; }
    }
}
