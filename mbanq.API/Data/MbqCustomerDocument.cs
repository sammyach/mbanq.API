using System;
using System.Collections.Generic;

namespace mbanq.API.Data
{
    public partial class MbqCustomerDocument
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int DocumentTypeId { get; set; }
        public string? DocumentUrl { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }

        public virtual MbqCustomer Customer { get; set; } = null!;
        public virtual MbqDocumentType DocumentType { get; set; } = null!;
    }
}
