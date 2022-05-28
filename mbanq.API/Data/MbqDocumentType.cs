using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqDocumentType
    {
        public MbqDocumentType()
        {
            MbqCustomerDocuments = new HashSet<MbqCustomerDocument>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<MbqCustomerDocument> MbqCustomerDocuments { get; set; }
    }
}
