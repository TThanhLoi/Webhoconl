using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webhoconl.Models
{
    public class ItemCart
    {
        public Subject subject { get; set; }

        public int Quantity { get; set; }

        public float LineTotal { get; set; }
    }
}