using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FluentApi4.Models
{
    public class CustomerViewModel
    {

        [Key]
        public int id { get; set; }
        public List<MProduct> products { get; set; }
        public List<MOrder> orders { get; set; }
        public MCustomer customers { get; set; }

    }
}