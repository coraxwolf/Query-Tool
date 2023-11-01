using Query_Tool.Services;
using Query_Tool.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace Query_Tool.Commands
{
    public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly NavigationService<TViewModel> NavigationService;

        public NavigateCommand(NavigationService<TViewModel> navigationService)
        {
            NavigationService = navigationService;
        }

        public override void Execute(object? parameter)
        {
            NavigationService.Navigate();
        }
    }
}
