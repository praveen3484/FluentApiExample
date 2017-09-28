using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentApi4.Models
{
    public class MOrder
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public virtual MCustomer MCustomer { get; set; }
        public virtual List<MProduct> MProduct { get; set; }
    }
}