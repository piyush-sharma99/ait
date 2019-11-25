using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class researchDTO
    {
        public int reID { get; set; }
        public String Name { get; set; }

        public String Date { get; set; }

        public String Topic { get; set; }
        public String Details { get; set; }
        public List<researchDTO> researches { get; set; }
    }
}