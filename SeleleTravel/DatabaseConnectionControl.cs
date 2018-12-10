using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace SeleleTravel
{
   public class DatabaseConnectionControl<T> : DbContext where T: class 
    {
       public DatabaseConnectionControl(T thing) : base("name = DatabaseConnectionControl")
        { }
       // Provider=PostgreSQL OLE DB Provider; Data Source = 127.0.0.1; location=Selele;User ID = postgres; password=Linomtha ;timeout=1000;
        //Defining lists/tables
        public virtual DbSet <T> table { get; set; }
    }
}
