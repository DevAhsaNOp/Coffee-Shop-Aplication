using System;

namespace MyCoffeeProject.Classes
{
    class Customer
    {

        private string _Customerfirstname;
        private string _Customerlastname;
        private string _CustomerfavCoffee;
        private string _CustomerphoneNumber;
        private int _CustomerId;

        public string CustomerFavCoffee { get => _CustomerfavCoffee; set=> _CustomerfavCoffee = value; }
        public string CustomerPhoneNumber { set => _CustomerphoneNumber = value; get => _CustomerphoneNumber; }
        public string CustomerFirstname { get => _Customerfirstname; set => _Customerfirstname = value; }
        public string CustomerLastname { get => _Customerlastname; set => _Customerlastname = value; }
        public int CustomerId { get => _CustomerId; set => _CustomerId = value; }

        public Customer(int id, string firstname, string lastname, string phone, string favCoffee)
        {
            CustomerId = id;
            CustomerFavCoffee = favCoffee;
            CustomerPhoneNumber = phone;
            CustomerFirstname = firstname;
            CustomerLastname = lastname;
        }

        public string DisplayCustomer()
        {
            return "Name: "+this.CustomerFirstname + " " + this.CustomerLastname + " " + " Phone Number: " + this.CustomerPhoneNumber + Environment.NewLine + "Favorite Coffee: " + this.CustomerFavCoffee;
        }

        public string GetFullName()
        {
            return this.CustomerFirstname + " " + this.CustomerLastname;
        }
    }
}
