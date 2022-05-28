using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqOrganization
    {
        public MbqOrganization()
        {
            MbqBranches = new HashSet<MbqBranch>();
        }

        public int Id { get; set; }
        public string Uid { get; set; } = null!;
        public string Name { get; set; } = null!;

        public virtual ICollection<MbqBranch> MbqBranches { get; set; }
    }
}
