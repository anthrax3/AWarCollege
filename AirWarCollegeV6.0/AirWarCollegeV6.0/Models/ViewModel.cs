using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AirWarCollegeV6._0.Models
{
    public class ViewModel
    {
        public IEnumerable<Announcement> Announcement { get; set; }
        public IEnumerable<cyberAlert> cyberAlert { get; set; }
    }
}