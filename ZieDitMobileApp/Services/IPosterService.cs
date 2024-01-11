using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitMobileApp.Models;

namespace ZieDitMobileApp.Services
{
    public interface IPosterService
    {
        Task<List<Poster>> GetPosters();
    }
}
