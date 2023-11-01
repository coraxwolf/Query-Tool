using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Models
{
    public class QueryResultsList : INotifyCollectionChanged
    {
        private Dictionary<string, Course> QueryResults;

        public IEnumerable<Course> Results
        {
            get
            {
                List<Course> courses = new();
                foreach (Course course in QueryResults.Values)
                {
                    courses.Add(course);
                }
                return courses;
            }
        }
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        public QueryResultsList()
        {
            QueryResults = new Dictionary<string, Course>();
            CollectionChanged += OnCollectionChanged;
        }

        protected void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CollectionChanged?.Invoke(this, e);
        }

        public void Clear()
        {
            QueryResults.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public void Add(Course course)
        {
            QueryResults.Add(course.SisId, course);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, course.SisId));
        }

        public bool Contains(string id)
        {
            return QueryResults.ContainsKey(id);
        }

        public Course GetCourse(string id)
        {
            return QueryResults[id];
        }
    }
}
