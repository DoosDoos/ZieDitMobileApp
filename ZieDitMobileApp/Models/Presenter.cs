using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZieDitMobileApp.Models
{
    public class Presenter
    {
        public int Id { get; set; }
        public string PresenterFirstName { get; set; }
        public string PresenterLastName { get; set; }
        public string PresenterEmail { get; set; }
        public Poster Posters { get; set; }
    }
}
