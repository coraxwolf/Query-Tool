using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Services.Interfaces
{
    public interface IAssignmentCreator
    {
        Task CreateCourseAssignment(string facultyNo, string courseId);
    }
}
