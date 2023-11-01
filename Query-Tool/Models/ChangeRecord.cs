using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Models
{
    public class ChangeRecord : INotifyCollectionChanged
    {
        public enum ChangeTypes
        {
            NewCourse,
            CourseCanceled,
            FacultyAdded,
            FacultyRemoved,
        }
        public Guid RunId { get; }
        public Course CourseRecord { get; }
        public Faculty? FacultyRecord { get; }
        public Enum ChangeType { get; }
        public string Message { get; }
        public DateTime EventTime { get; }

        public ChangeRecord(Guid runId, Course courseRecord, Faculty? facultyRecord, Enum changeType, string message, DateTime eventTime)
        {
            RunId = runId;
            CourseRecord = courseRecord;
            FacultyRecord = facultyRecord ?? null;
            ChangeType = changeType;
            Message = message;
            EventTime = eventTime;
        }

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
    }
}
