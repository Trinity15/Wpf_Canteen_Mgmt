using MessMgmt;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
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
        public static ObservableCollection<MenuItems> _menu = new();
        public static Delivery? Delivery;
        public static Overview_Menu? Overview_Menu;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (File.Exists("AppState.xml"))
                _state = Storage.LoadXml<ObservableCollection<Customer>>("AppState.xml");
            if (_state == null) _state = new ObservableCollection<Customer>();

            if(File.Exists("Menu.xml"))
                _menu = Storage.LoadXml<ObservableCollection<MenuItems>>("Menu.xml");
            if (_menu == null) _menu = new ObservableCollection<MenuItems>();

            refreshDelivery();
            refreshMenu();
        }

        public static ObservableCollection<object> refreshDelivery()
        {
            var customers = _state.ToList().ToImmutableList();
            var delivery = customers.Select(customer => customer.Order.Select(order => new {
                FullName = customer.FullName,
                Address = customer.Address,
                Price = order.Price,
                StartDate = order.StartDate,
                EndDate = order.EndDate,
                MealType = order.MealType,
                Veg = order.Veg
            }))
                .SelectMany(i => i)
                .OrderBy(item => item.FullName);

            return new ObservableCollection<object>(delivery);
        }

        public static ObservableCollection<object> refreshMenu()
        {
            var menu = _menu.ToList().ToImmutableList();
            var overview = menu.Select(menu => menu.Dish.Select(dish => new {
                DishName = dish.DishName,
                Description = dish.Description ,
                PreparedDate = menu.PreparedDate,
                MealType = menu.MealType,
                Veg = dish.Veg
            }))
                .SelectMany(i => i)
                .OrderBy(item => item.PreparedDate);

            return new ObservableCollection<object>(overview);
        }
        private void Application_Exit(object sender, ExitEventArgs e)
        {
            Storage.WriteXml(_state, "AppState.xml");
            Storage.WriteXml(_menu, "Menu.xml");
        }
    }
}
