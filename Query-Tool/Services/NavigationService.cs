using Query_Tool.Stores;
using Query_Tool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Query_Tool.Services
{
    public class NavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        private readonly NavigationStore Store;
        private readonly Func<TViewModel> CreateView;

        public NavigationService(NavigationStore navigationStore, Func<TViewModel> createViewModel)
        {
            Store = navigationStore;
            CreateView = createViewModel;
        }

        public void Navigate()
        {
            Store.ViewModel = CreateView();
        }
    }
}
