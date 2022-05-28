using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqCountry
    {
        public MbqCountry()
        {
            MbqRegions = new HashSet<MbqRegion>();
            MbqStates = new HashSet<MbqState>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortName { get; set; }

        public virtual ICollection<MbqRegion> MbqRegions { get; set; }
        public virtual ICollection<MbqState> MbqStates { get; set; }
    }
}
