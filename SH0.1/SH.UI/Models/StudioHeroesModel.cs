using SH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SH.UI.Models
{
    public class StudioHeroesModel
    {
        public Studio Studio { get; set; }
        public List<Hero> Heroes { get; set; }
    }
}