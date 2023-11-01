using Query_Tool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Stores
{
    public class NavigationStore
    {
        private ViewModelBase CurrentViewModel { get; set; }
        public ViewModelBase ViewModel
        {
            get => CurrentViewModel;
            set
            {
                CurrentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        public event Action? CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public NavigationStore(ViewModelBase? viewModel)
        {
            CurrentViewModel = viewModel ?? new MainViewModel(this);
        }
    }
}
