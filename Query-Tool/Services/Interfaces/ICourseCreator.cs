using Query_Tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Services.Interfaces
{
    public interface ICourseCreator
    {
        Task CreateCourseRecord(Course course);
    }
}
