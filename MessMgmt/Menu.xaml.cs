using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace MessMgmt
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LBxMenu.ItemsSource = App._state;
            //Customer_Input.Visibility = Visibility.Hidden;
        }

        private void LBxMenu_Selected(object sender, SelectionChangedEventArgs e)
        {


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MenuItems meal = new MenuItems();
            meal.CreatedAt = "New";
           
        }

        private void BtnDeleteMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
