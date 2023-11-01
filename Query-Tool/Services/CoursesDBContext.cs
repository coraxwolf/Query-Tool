using Microsoft.EntityFrameworkCore;
using Query_Tool.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Services
{
    public class CoursesDBContext : DbContext
    {

        public CoursesDBContext(DbContextOptions options) : base(options) { }

        public DbSet<CourseDTO> Courses { get; set; }
        public DbSet<FacultyDTO> Faculty { get; set; }
        public DbSet<FacultyAssignmentDTO> FacultyAssignment { get; set; }
    }
}
