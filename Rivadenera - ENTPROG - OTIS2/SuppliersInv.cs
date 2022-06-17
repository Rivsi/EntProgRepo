using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Rivadenera___ENTPROG___OTIS2
{
    public partial class SuppliersInv
    {
        public int SupplierId { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }

        [RegularExpression(@"^[\sa-zA-Z0-9,.]*$", ErrorMessage = "Special and alphabet characters only!")]
        public string? Representative { get; set; }

        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid. Try something like this 012-345-6789.")]
        public string? ContactNo { get; set; }


        public DateTime? DateAdded { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
