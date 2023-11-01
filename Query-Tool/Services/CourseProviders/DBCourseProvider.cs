using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Query_Tool.DTOs;
using Query_Tool.Models;
using Query_Tool.Services;
using Query_Tool.Services.Interfaces;
using Query_Tool.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Services.CourseProviders
{
    public class DBCourseProvider : ICourseProvider
    {
        private readonly CoursesDBContextFactory DBContextFacorty;

        public DBCourseProvider(CoursesDBContextFactory DBContextFactory)
        {
            DBContextFacorty = DBContextFactory;
        }


        private static Course ToCourseRecord(CourseDTO dbRecord)
        {
            return new Course(
                dbRecord.SisId,
                dbRecord.Term,
                dbRecord.ClassNo,
                dbRecord.Semester,
                dbRecord.Subject,
                dbRecord.Catalog,
                dbRecord.Campus,
                dbRecord.Location,
                dbRecord.Title,
                dbRecord.Mode,
                dbRecord.Enrolled,
                dbRecord.Cap,
                dbRecord.Status,
                dbRecord.StartDate,
                dbRecord.EndDate
            );
        }

        public async Task<IEnumerable<Course>> GetAllCourses()
        {
            using (CoursesDBContext dbContext = DBContextFacorty.CreateDbContext())
            {
                IEnumerable<CourseDTO> courseDTOs = await dbContext.Courses.ToListAsync();
                return courseDTOs.Select(c => ToCourseRecord(c));
            }
        }

        public async Task<IEnumerable<Course>> GetCoursesForTerm(string term)
        {
            using (CoursesDBContext dBContext = DBContextFacorty.CreateDbContext())
            {
                IEnumerable<CourseDTO> courseDTOs = await dBContext.Courses.Where((c) => c.Term == term).ToListAsync();
                return courseDTOs.Select(c => ToCourseRecord(c));
            }
        }
    }
}
