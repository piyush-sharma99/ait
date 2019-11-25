using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project.Models
{
    public class secure
    {

        private ICollection<secure> _secure;


        public secure()
        {
            _secure = new List<secure>();
        }

        [Key]
        public int secID { get; set; }
        public String Name { get; set; }

        public String Date { get; set; }

        public String Topic { get; set; }
        public String Details { get; set; }


        public virtual ICollection<secure> securess
        {
            get { return _secure; }
            set { _secure = value; }
        }
    }
}