using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZieDitMobileApp.Models
{
    public class Poster
    {
        public int Id { get; set; }
        public string PosterImagePath { get; set; }
        public int ReceivedCredits { get; set; }
        public ICollection<Presenter> Presenters { get; set; }
        public Event Event { get; set; }
    }
}
