using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqAppUserRole
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public DateTime? DateAssigned { get; set; }
        public string? AssignedBy { get; set; }

        public virtual MbqAppRole Role { get; set; } = null!;
        public virtual MbqAppUser User { get; set; } = null!;
    }
}
