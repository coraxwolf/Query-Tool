using Query_Tool.DTOs;
using Query_Tool.Models;
using Query_Tool.Services;
using Query_Tool.Services.Interfaces;
using Query_Tool.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Services.CourseCreators
{
    public class DBCourseCreator : ICourseCreator
    {
        private readonly CoursesDBContextFactory DBContextFactory;

        public DBCourseCreator(CoursesDBContextFactory dBContextFactory)
        {
            DBContextFactory = dBContextFactory;
        }

        public async Task CreateCourseRecord(Course course)
        {
            using (CoursesDBContext context = DBContextFactory.CreateDbContext())
            {
                CourseDTO courseDTO = ToCourseDTORecord(course);
                context.Courses.Add(courseDTO);
                await context.SaveChangesAsync();
            }
        }

        private CourseDTO ToCourseDTORecord(Course course)
        {
            return new CourseDTO(
              course.SisId,
              course.Term,
              course.ClassNo,
              course.Semester,
              course.Subject,
              course.Catalog,
              course.Campus,
              course.Location,
              course.Title,
              course.Mode,
              course.Status,
              course.Enrolled,
              course.Cap,
              course.StartDate,
              course.EndDate,
              course.CanvasName,
              course.CanvasCode,
              course.Created,
              course.Updated
           );
        }
    }
}
