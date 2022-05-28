using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqState
    {
        public MbqState()
        {
            MbqBranches = new HashSet<MbqBranch>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CountryId { get; set; }

        public virtual MbqCountry? Country { get; set; }
        public virtual ICollection<MbqBranch> MbqBranches { get; set; }
    }
}
