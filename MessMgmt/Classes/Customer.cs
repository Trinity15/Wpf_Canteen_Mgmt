using System;
using System.Collections.ObjectModel;

namespace MessMgmt
{
    public class Customer
    {
        public Guid Guid { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string FullName { get { return $"{this.FirstName} {this.LastName}"; } }
        public string EMailTel { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public ObservableCollection<Order> Order { get; set; } = new ObservableCollection<Order>();


    }


    public class Order
    {

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;
        public uint MealType { get; set; } = 0;
        public float Price { get; set; } = 0;
        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd'/'MM'/'yyyy");
        public uint PaymentStatus { get; set; } = 0;
        public uint Veg { get; set; } = 0;

    }


}
