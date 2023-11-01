using Query_Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Services.Interfaces
{
    public interface ICourseProvider
    {
        Task<IEnumerable<Course>> GetAllCourses();
        Task<IEnumerable<Course>> GetCoursesForTerm(string term);
    }
}
