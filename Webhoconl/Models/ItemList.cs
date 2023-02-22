using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webhoconl.Models
{
    public class ItemList
    {
        public List<Oder> ListOder { get; set; }
        public List<OderDetail> ListDetail { get; set; }
        public List<Subject> ListSubject { get; set; }
    }
}