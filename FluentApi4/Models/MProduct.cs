using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FluentApi4.Models
{
    public class MProduct
    {
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public virtual MOrder MOrder { get; set; }
    }
}