using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Models
{
    public class CourseList : INotifyCollectionChanged
    {
        private readonly Dictionary<string, Course> courses;
        public string Term { get; set; } = string.Empty;
        
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public ObservableCollection<Course> CourseListing
        {
            get
            {
                return new ObservableCollection<Course>(courses.Values);
            }
        }

        public CourseList()
        {
            courses = new Dictionary<string, Course>();
        }

        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (CollectionChanged != null)
            {
                CollectionChanged?.Invoke(this, e);
            }
        }


        public Course? GetCourseById(string id)
        {
            if (courses.ContainsKey(id))
            {
                return courses[id];
            }
            else
            {
                 return null;
            }
        }

        public void AddCourse(Course course)
        {
            if (courses.ContainsKey((string) course.SisId))
            {
                courses[course.SisId] = course;
            } else
            {
                courses.Add(course.SisId, course);
            }
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, course.SisId));
        }

        public void RemoveCourse(string id)
        {
            courses.Remove(id);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, id));
        }
    }
}
