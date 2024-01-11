using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZieDitMobileApp.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public int VisitorCreditAmount { get; set; }
        public Event Event { get; set; }
    }
}
