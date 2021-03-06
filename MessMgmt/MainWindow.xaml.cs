using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Navigation;

namespace MessMgmt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CbxMealType.ItemsSource = new List<string> { "Breakfast", "Lunch", "Dinner", "Breakfast|Lunch|Dinner", "Breakfast|Lunch", "Lunch|Dinner", "Breakfast|Dinner" }.ToImmutableList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LBxCustomers.ItemsSource = App._state;
           
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.EMailTel = "NewCustomer@outlook.com";
            customer.FirstName = "New";
            customer.LastName = "Customer";

            App._state.Add(customer);
            LBxCustomers.SelectedItem = customer;
            LBxCustomers.ScrollIntoView(customer);
        }

        private void LBxCustomers_Selected(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {

            var customers = LBxCustomers.SelectedItems.Cast<Customer>().ToImmutableList();
            var deleteMessageBox = () => MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);

            if (customers == null)
            {
                deleteMessageBox();
                return;
            }
            else if (customers.Count() == 0)
            {
                deleteMessageBox();
                return;
            }
            var res = MessageBox.Show(
                $"Are you sure you want to remove {customers.FirstOrDefault().FirstName} {customers.FirstOrDefault().LastName} from the List of customers?",
                "Warning",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (res == MessageBoxResult.Yes)
            {
                customers.ForEach((customer) => App._state.Remove(customer));
                LBxCustomers.ItemsSource = filteredCustomers(TbxFilter.Text);
            }


        }
        private IEnumerable<Customer> filteredCustomers(string filterInput) => from m in App._state where m.FullName.ToLower().Contains(filterInput) orderby m.LastName.IndexOf(filterInput) select m;
        private DateTime RandomDate(int from, int to) => DateTime.Now.AddDays(new Random().Next(from, to));


        private void TbxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            var filter = TbxFilter.Text.ToLower();
            if (filter == "")
            {
                LBxCustomers.ItemsSource = App._state;
            }
            else
            {
                var list = filteredCustomers(filter);

                LBxCustomers.ItemsSource = list.ToList();
            }

        }
        private void BtnToCustomers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnToOrderDetails_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DaPiStart_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (LBxCustomers.SelectedItem == null)
            {
                return;
            }

            var selectedCustomer = LBxCustomers.SelectedItem as Customer;
            var newOrder = new Order();
            selectedCustomer.Order.Add(newOrder);
            LbxOrder.SelectedItem = newOrder;
            LbxOrder.ScrollIntoView(newOrder);


        }




        //<!-- Delete Orders -->
        private void BtnDeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            var orders = LbxOrder.SelectedItems.Cast<Order>().ToImmutableList();
            var selectedCustomer = LBxCustomers.SelectedItem as Customer;
            var deleteMessageBox = () => MessageBox.Show("Please select an item to delete.", "Error", MessageBoxButton.OK, MessageBoxImage.Stop);

            if (selectedCustomer == null)
            {
                return;
            }

            if (orders == null)
            {
                deleteMessageBox();
                return;
            }
            else if (orders.Count() == 0)
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
                orders.ForEach((order) => selectedCustomer.Order.Remove(order));

               
            }
        }

        private void BtnselectCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnUnselectOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DaPiEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btnmenu_Click(object sender, RoutedEventArgs e)
        {
            Menu win = new Menu();
            win.Show();
        }

        private void Btndelivery_Click(object sender, RoutedEventArgs e)
        {
          
            App.Delivery = new Delivery { DataContext = App.refreshDelivery() };
            App.Delivery.Owner = this;
            App.Delivery.Show();
           


        }

        private void CalcPrice(object sender, SelectionChangedEventArgs e)
        {
            if (LbxOrder.SelectedItem != null)
            {
                var selectedCustomer = LBxCustomers.SelectedItem as Customer;
                var index = LbxOrder.SelectedIndex;

                uint days = (uint)(selectedCustomer.Order.ElementAt(index).EndDate - selectedCustomer.Order.ElementAt(index).StartDate).TotalDays;

                var price = selectedCustomer.Order.ElementAt(index).Price;

                switch (CbxMealType.SelectedIndex)
                {
                    case 0:
                        price = 20 * days;
                        break;
                    case 1:
                        price = 20 * days;
                        break;
                    case 2:
                        price = 20 * days;
                        break;
                    case 3:
                        price = 60 * days;
                        break;
                    case 4:
                        price = 40 * days;
                        break;
                    case 5:
                        price = 40 * days;
                        break;
                    case 6:
                        price = 40 * days;
                        break;
                    default:
                        price = 0;
                        break;
                }

                selectedCustomer.Order.ElementAt(index).Price = price;

                PriceTB.Text = selectedCustomer.Order.ElementAt(index).Price.ToString();
            }
        }

        private void BtnCloseOrder(object sender, RoutedEventArgs e)
        {
            LbxOrder.SelectedItem = null;
        }

        private void LbxOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

