using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqAppRole
    {
        public MbqAppRole()
        {
            MbqAppUserRoles = new HashSet<MbqAppUserRole>();
        }

        public int Id { get; set; }
        public string Role { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<MbqAppUserRole> MbqAppUserRoles { get; set; }
    }
}
