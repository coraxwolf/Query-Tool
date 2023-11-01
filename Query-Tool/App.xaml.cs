using Microsoft.EntityFrameworkCore;
using Query_Tool.Commands;
using Query_Tool.Services;
using Query_Tool.Stores;
using Query_Tool.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;

namespace Query_Tool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore NavStore;
        private const string CONNECTION_STRING = "Data Source=CoursesDB";

        public App()
        {
            NavStore = new NavigationStore(null);
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (CoursesDBContext dbContext = new CoursesDBContextFactory(CONNECTION_STRING).CreateDbContext())
            {
                dbContext.Database.Migrate();
            }
            
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(NavStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
