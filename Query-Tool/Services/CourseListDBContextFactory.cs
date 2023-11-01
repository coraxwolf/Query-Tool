using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Services
{
    public class CourseListDBContextFactory : IDesignTimeDbContextFactory<CoursesDBContext>
    {
        public CoursesDBContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Course=CoursesDB").Options;
            return new CoursesDBContext(options);
        }
    }
}
