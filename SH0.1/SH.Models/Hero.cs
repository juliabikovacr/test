using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SH.Models
{
    public class Hero
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }

        public int StudioID { get; set; }
        public Studio Studio { get; set; }
    }
}
