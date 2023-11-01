using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Models
{
    public class Course : INotifyCollectionChanged
    {
        public string SisId { get; }
        public string Term { get; }
        public string ClassNo { get; }
        public string Semester { get; }
        public string Subject { get; }
        public string Catalog { get; }
        public string CourseName { get { return Subject + " " + Catalog; } }
        public string Campus { get; }
        public string Location { get; }
        public string Title { get; }
        public string Mode { get; }
        public Int32 Enrolled { get; }
        public Int32 Cap { get; }
        public string Status;
        public DateOnly StartDate;
        public DateOnly EndDate;
        public Int32? CanvasCode { get; set; } = null;
        public string? CanvasName { get; set; } = null;
        public DateTime Created;
        public DateTime Updated;
        private List<Faculty> FacultyList = new();

        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public Course(
                string id,
                string term,
                string crn,
                string semester,
                string subject,
                string catalog,
                string campus,
                string location,
                string title,
                string mode,
                int enrolled,
                int cap,
                string status,
                DateOnly startDate,
                DateOnly endDate
            )
        {
            SisId = id;
            Term = term;
            ClassNo = crn;
            Semester = semester;
            Subject = subject;
            Catalog = catalog;
            Campus = campus;
            Location = location;
            Title = title;
            Mode = mode;
            Enrolled = enrolled;
            Cap = cap;
            StartDate = startDate;
            EndDate = endDate;

            if (status == "A")
            {
                Status = "Active";
            } else if (status == "S")
            {
                Status = "Stopped";
            } else if (status == "X")
            {
                Status = "Canceled";
            } else
            {
                Status = $"Invalid ({status})";
            }
            Created = new DateTime();
            FacultyList = new List<Faculty>();

        }

        public void AddFaculty(Faculty faculty)
        {
            FacultyList.Add( faculty );
        }

        public List<Faculty> GetFaculty()
        {
            return FacultyList;
        }


    }
}
