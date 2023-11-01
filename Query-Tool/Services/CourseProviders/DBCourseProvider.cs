using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Query_Tool.DTOs;
using Query_Tool.Models;
using Query_Tool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Services.CourseProviders
{
    public class DBCourseProvider
    {
        private CourseListDBContextFactory DBContextFacorty;

        public DBCourseProvider(CourseListDBContextFactory DBContextFactory)
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
    }
}
