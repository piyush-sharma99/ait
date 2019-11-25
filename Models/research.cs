using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class research
    {

        private ICollection<research> _res;


        public research()
        {
            _res = new List<research>();
        }

        [Key]
        public int reID { get; set; }
        public String Name { get; set; }

        public String Date { get; set; }

        public String Topic { get; set; }
        public String Details { get; set; }


        public virtual ICollection<research> researches
        {
            get { return _res; }
            set { _res = value; }
        }
    }
}