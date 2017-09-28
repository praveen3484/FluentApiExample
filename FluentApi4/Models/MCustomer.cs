using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentApi4.Models
{
    public class MCustomer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public virtual List<MOrder> MOrder{ get; set; }
    }
}