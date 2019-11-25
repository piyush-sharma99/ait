using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class resolution
    {

        private ICollection<resolution> _resolution;


        public resolution()
        {
            _resolution = new List<resolution>();
        }

        [Key]
        public int resID { get; set; }
        public String Name { get; set; }

        public String Date { get; set; }

        public String Topic { get; set; }
        public String Details { get; set; }

        public virtual ICollection<resolution> resolutions
        {
            get { return _resolution; }
            set { _resolution = value; }
        }

    }
}