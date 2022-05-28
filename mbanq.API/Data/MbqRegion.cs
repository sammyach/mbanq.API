using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqRegion
    {
        public MbqRegion()
        {
            MbqBranches = new HashSet<MbqBranch>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CountryId { get; set; }

        public virtual MbqCountry Country { get; set; } = null!;
        public virtual ICollection<MbqBranch> MbqBranches { get; set; }
    }
}
