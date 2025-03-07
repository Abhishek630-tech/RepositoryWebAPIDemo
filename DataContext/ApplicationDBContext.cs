using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebAPICRUDCodeFirstEF.Models;

namespace WebAPICRUDCodeFirstEF.DataContext
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext():base("DBConnection")
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}