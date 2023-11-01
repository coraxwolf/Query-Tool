using EO_Tool.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Query_Tool.Commands;
using Query_Tool.Models;
using Query_Tool.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Query_Tool.ViewModels
{
    public class QueryViewModel : ViewModelBase
    {
        public ICommand LoadQueryCommand { get; }
        public ICommand ClearQueryCommand { get; }

        public QueryStore QueryData { get; }
        public ObservableCollection<Course> QueryRecords
        {
            get
            {
                return QueryData.Courses;
            }
        }
        public ObservableCollection<ChangeRecord> ChangeRecords
        {
            get
            {
                return QueryData.Changes;
            }
        }

        internal class ClearQuery : CommandBase
        {
            private readonly QueryStore Store;
            public ClearQuery(QueryStore store)
            {
                Store = store;
            }
            public override void Execute(object? parameter)
            {
                Store.ClearRecords();
            }
        }

        public QueryViewModel() {
            QueryData = new QueryStore();
            LoadQueryCommand = new LoadQuery(QueryData);
            ClearQueryCommand =new ClearQuery(QueryData);
            QueryData.CollectionChanged += OnQueryCollectionChanged;
        }

        private void OnQueryCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Reset)
            {
                OnPropertyChanged(nameof(QueryData));
            }
        }

        private void QueryData_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            OnPropertyChanged(e.PropertyName ?? "Query");
        }
    }
}
