using Microsoft.EntityFrameworkCore;
using Query_Tool.DTOs;
using Query_Tool.Models;
using Query_Tool.Services.Interfaces;
using Query_Tool.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Services.FacultyProviders
{
    public class DBFacultyProvider : IFacultyProvider
    {
        private CoursesDBContextFactory DBContextFactory;

        public DBFacultyProvider(CoursesDBContextFactory dbContextFactory)
        {
            DBContextFactory = dbContextFactory;
        }

        private static Faculty ToFacultyRecord(FacultyDTO facultyDTO)
        {
            Faculty faculty = new(
                facultyDTO.Name,
                facultyDTO.FacultyNo
                );
            faculty.CanvasName = facultyDTO.CanvasName ?? null;
            faculty.CanvasCode = facultyDTO.CanvasCode ?? null;
            return faculty;
        }
        public async Task<IEnumerable<Faculty>> GetAllFaculty()
        {
            using(CoursesDBContext dbContext = DBContextFactory.CreateDbContext())
            {
                IEnumerable<FacultyDTO> facultyDTOs = await dbContext.Faculty.ToListAsync();
                return facultyDTOs.Select(f => ToFacultyRecord(f));
                
            }
        }

        public async Task<Faculty> GetFacultyRecord(string facultyNo)
        {
            using(CoursesDBContext dbContext = DBContextFactory.CreateDbContext())
            {
                FacultyDTO facultyDTO = await dbContext.Faculty.FirstAsync((f) => f.FacultyNo == facultyNo);
                return ToFacultyRecord(facultyDTO);
                
            }
        }
    }
}
