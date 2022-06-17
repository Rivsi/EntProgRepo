using System;
using System.Collections.Generic;

namespace Rivadenera___ENTPROG___OTIS2
{
    public partial class ProductsInv
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Qty { get; set; }
        public string? Unit { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
