using Query_Tool.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Stores
{
    public class QueryStore : INotifyCollectionChanged
    {
        private Dictionary<string, Course> CourseRecords;
        private List<ChangeRecord> ChangeRecords;

        public ObservableCollection<ChangeRecord> Changes
        {
            get
            {
                return new ObservableCollection<ChangeRecord>(ChangeRecords);
            }
        }

        public ObservableCollection<Course> Courses
        {
            get
            {
                return new ObservableCollection<Course>(CourseRecords.Values);
            }
        }

        public void AddCourse(Course course)
        {
            CourseRecords.Add(course.SisId, course);
            OnCollectonChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, course));
        }

        public bool ContainsKey(string id)
        {
            return CourseRecords.ContainsKey(id);
        }

        public Course GetCourse(string id)
        {
            return CourseRecords[id];
        }

        public void ClearRecords()
        {
            CourseRecords.Clear();
            OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(Courses)));
        }

        public void AddChangeEvent(ChangeRecord record)
        {
            ChangeRecords.Add(record);
            OnPropertyChanged(this, new PropertyChangedEventArgs(nameof(Changes)));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        protected void OnCollectonChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        protected void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        public QueryStore()
        {
            CourseRecords = new Dictionary<string, Course>();
            ChangeRecords = new List<ChangeRecord>();
        }
    }
}
