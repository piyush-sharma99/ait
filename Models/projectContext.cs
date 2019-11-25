using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Project.Models
{


        public class projectContext : DbContext
        {

            public projectContext() : base("projectContext")
            {

            }

            public DbSet<secure> secures { get; set; }
            public DbSet<resolution> resolutions { get; set; }
            public DbSet<research> researches { get; set; }
            public DbSet<vulnerability> vulnerabilities { get; set; }

        }
    
}