using Query_Tool.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.DTOs
{
    public class CourseDTO
    {
        [Key]
        public string SisId {  get; set; }
        public string Term { get; set; }
        public string ClassNo { get; set; }
        public string Semester { get; set; }
        public string Subject { get; set; }
        public string Catalog { get; set; }
        public string CourseName { get; set; }
        public string Campus { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Mode { get; set; }
        public Int32 Enrolled { get; set; }
        public Int32 Cap { get; set; }
        public string Status { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public Int32? CanvasCode { get; set; } = null;
        public string? CanvasName { get; set; } = null;
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

        public ICollection<FacultyAssignmentDTO> FacultyAssignments { get;} = new Collection<FacultyAssignmentDTO>();

        public CourseDTO(
            string id,
            string term,
            string classNo,
            string semester,
            string subject,
            string catalog,
            string campus,
            string location,
            string title,
            string mode,
            string status,
            Int32 enrolled,
            Int32 cap,
            DateOnly startDate,
            DateOnly endDate,
            string? canvasName,
            Int32? canvasCode,
            DateTime? created,
            DateTime? updated
        )
        {
            SisId = id;
            Term = term;
            ClassNo = classNo;
            Semester = semester;
            Subject = subject;
            Catalog = catalog;
            Campus = campus;
            Location = location;
            Title = title;
            Mode = mode;
            Enrolled = enrolled;
            Cap = cap;
            Mode = mode;
            StartDate = startDate;
            EndDate = endDate;
            Created = created ?? DateTime.Now;
            Updated = updated ?? DateTime.Now;
            CanvasName = canvasName ?? null;
            CanvasCode = canvasCode ?? null;

            CourseName = $"{subject} {catalog}";
            if (status == "A")
            {
                Status = "Active";
            } else if (status == "C")
            {
                Status = "Canceled";
            } else if (status == "S")
            {
                Status = "Stopped";
            } else
            {
                Status = "Invalid";
            }
        }

    }
}
