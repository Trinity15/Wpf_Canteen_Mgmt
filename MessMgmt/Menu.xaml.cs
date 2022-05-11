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
            CbxMealType.ItemsSource = new List<string> { "Breakfast", "Lunch", "Dinner" }.ToImmutableList();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LBxMenu.ItemsSource = App._menu;
           
        }
        private DateTime RandomDate(int from, int to) => DateTime.Now.AddDays(new Random().Next(from, to));

        private void LBxMenu_Selected(object sender, SelectionChangedEventArgs e)
        {


        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            MenuItems m1 = new MenuItems();
            App._menu.Add(m1);
            LBxMenu.SelectedItem = m1;
            LBxMenu.ScrollIntoView(m1);

        }

        private void BtnDeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            var m1 = LBxMenu.SelectedItems.Cast<MenuItems>().ToImmutableList();
            var deleteMessageBox = () => MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);

            if (m1 == null)
            {
                deleteMessageBox();
                return;
            }
            else if (m1.Count() == 0)
            {
                deleteMessageBox();
                return;
            }
            var res = MessageBox.Show(
                $"Are you sure you want to remove the menu from the List ?",
                "Warning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (res == MessageBoxResult.Yes)
            {
                m1.ForEach((m1) => App._menu.Remove(m1));
               /* LBxCustomers.ItemsSource = filteredCustomers(TbxFilter.Text)*/;
            }

        }

        private void DaPreparedDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddDish_Click(object sender, RoutedEventArgs e)
        {
            if (LBxMenu.SelectedItem == null)
            {
                return;
            }

            var selecteddish = LBxMenu.SelectedItem as MenuItems;
            var d1 = new Dish();
            selecteddish.Dish.Add(d1);
            LbxDish.SelectedItem = d1;
            LbxDish.ScrollIntoView(d1);
        }

        private void BtnDeletDish_Click(object sender, RoutedEventArgs e)
        {
            var d1 = LbxDish.SelectedItems.Cast<Dish>().ToImmutableList();
            var selectedMenu = LBxMenu.SelectedItem as MenuItems;
            var deleteMessageBox = () => MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);

            if (selectedMenu == null)
            {
                return;
            }

            if (d1 == null)
            {
                deleteMessageBox();
                return;
            }
            else if (d1.Count() == 0)
            {
                deleteMessageBox();
                return;
            }
            
            var res = MessageBox.Show(
                $"Are you sure you want to remove ?",
                "Warning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (res == MessageBoxResult.Yes)
            {
                d1.ForEach((Dish) => selectedMenu.Dish.Remove(Dish));

                //var d2 = selectedMenu.d1.FirstOrDefault();
                //LbxRepairs.SelectedItem = lastRepair;
                //LbxRepairs.ScrollIntoView(lastRepair);
            }
        }
    }
    }

