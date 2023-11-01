using Microsoft.EntityFrameworkCore;
using Query_Tool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Stores
{
    public class CoursesDBContextFactory
    {
        private readonly string ConnectionString;

        public CoursesDBContextFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public CoursesDBContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(ConnectionString).Options;
            return new CoursesDBContext(options);
        }
    }
}
