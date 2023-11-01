using Query_Tool.Commands;
using Query_Tool.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Query_Tool.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore NavStore;
        public ViewModelBase CurrentViewModel { get => NavStore.ViewModel; }

        private string Term = string.Empty;
        public static QueryViewModel MakeQueryViewModelNavService()
        {
            return new QueryViewModel();
        }
        public static CourseListViewModel MakeCourseListViewModelNavService()
        {
            return new CourseListViewModel();
        }
        public string SelectedTerm
        {
            get
            {
                return Term ?? string.Empty;
            }
            set
            {
                Term = value;
                OnPropertyChanged(nameof(SelectedTerm));
            }
        }

        public ICommand GoToQueryView { get;  }
        public ICommand GoToCourseListView { get;  }

        public void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        public MainViewModel(NavigationStore navigationStore)
        {
            NavStore = navigationStore;
            NavStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
            GoToQueryView = new NavigateCommand<QueryViewModel>(
                new Services.NavigationService<QueryViewModel>(NavStore, MakeQueryViewModelNavService)
                );
            GoToCourseListView = new NavigateCommand<CourseListViewModel>(
                new Services.NavigationService<CourseListViewModel>(NavStore, MakeCourseListViewModelNavService)
                );
        }
    }
}
