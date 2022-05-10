using MessMgmt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MessMgmt
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ObservableCollection<Customer> _state = new();

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _state = Storage.LoadXml<ObservableCollection<Customer>>("AppState.xml");
            if (_state == null) _state = new ObservableCollection<Customer>();
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Storage.WriteXml(_state, "AppState.xml");
        }
    }
}
