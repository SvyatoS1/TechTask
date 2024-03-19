using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(TaskDbContext context) 
        {
            context.Database.EnsureCreated();
        }
    }
}
