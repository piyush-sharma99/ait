using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class secureDTO
    {

        public int secID { get; set; }
        public String Name { get; set; }

        public String Date { get; set; }

        public String Topic { get; set; }
        public String Details { get; set; }
        public List<secureDTO> secures { get; set; }
    }
}