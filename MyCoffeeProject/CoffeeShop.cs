using MyCoffeeProject.Classes;
using System;
using System.Collections;
using System.Windows.Forms;
using System.Linq;

namespace MyCoffeeProject
{

    public partial class CoffeeShop : Form
    {

        ArrayList yodaCustomerList = new ArrayList();
        ArrayList coffeesOrdered = new ArrayList();

        public CoffeeShop()
        {
            InitializeComponent();
        }

        private void saveCustBtn_Click(object sender, EventArgs e)
        {
            Random _randInteger = new Random();
            int CustomerID = _randInteger.Next(1000000);

            Customer YodasCustomer = new Customer(CustomerID, fNametextBox.Text, lastNametextBox.Text, phoneNumtextBox.Text, favCoffeeTxtBox.Text);
            yodaCustomerList.Add(YodasCustomer);

            MessageBox.Show("New Customer: " + YodasCustomer.GetFullName(), "New Customer", MessageBoxButtons.OK);
        }

        private void displayCustBtn_Click(object sender, EventArgs e)
        {
            outputListBox.Items.Clear();
            foreach (Customer cust in yodaCustomerList)
            {
                outputListBox.Items.Add(cust.DisplayCustomer());
                outPutLabel.Text = cust.DisplayCustomer();
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        #region Clear All Method
        private void ClearAll()
        {
            fNametextBox.Text = "";
            lastNametextBox.Text = "";
            phoneNumtextBox.Text = "";
            favCoffeeTxtBox.Text = "";

            outPutLabel.Text = string.Empty;
            //clear the list box
            outputListBox.Items.Clear();

            priceLabel.Text = "Price:";

            smRadioBtn.Checked = false;
            medRadioBtn.Checked = false;
            lgRadioBtn.Checked = false;

            icedCoffeeRdBtn.Checked = false;
            icedLatteRdBtn.Checked = false;
        }
        #endregion

        #region Calculate Cost Button Click
        private void calcCostBtn_Click(object sender, EventArgs e)
        {

            var buttons = this.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            string size;
            double CoffeePrice;
            string iceamt = CoffeeIceAmount.Text;

            if (icedCoffeeRdBtn.Checked == true)
            {
                string bTime = "long";
                if (smRadioBtn.Checked == true)
                {
                    size = "Small";
                    CoffeePrice = 140;
                }
                else if (medRadioBtn.Checked == true)
                {
                    size = "Medium";
                    CoffeePrice = 180;
                }
                else
                {
                    size = "Large";
                    CoffeePrice = 240;
                }

                IcedCoffee custsCoffee = new IcedCoffee(size, bTime, iceamt, CoffeePrice);
                priceLabel.Text = "Price: " + custsCoffee.CalculateCoffeePrice(CoffeePrice).ToString("C2");
                coffeesOrdered.Add(custsCoffee);
                ttlCoffeesLabel.Text = "Total:" + coffeesOrdered.Count.ToString();
            }
            else if (icedLatteRdBtn.Checked == true)
            {
                string bTime = "short";
                string icea = CoffeeIceAmount.Text;
                string milkAmount = CoffeeMilkAmnt.Text;

                if (smRadioBtn.Checked == true)
                {
                    size = "Small";
                    CoffeePrice = 140;
                }
                else if (medRadioBtn.Checked == true)
                {
                    size = "Medium";
                    CoffeePrice = 180;
                }
                else
                {
                    size = "Large";
                    CoffeePrice = 240;
                }

                IcedLatte custsCoffee = new IcedLatte(size, bTime, icea, milkAmount, 5.35);
                priceLabel.Text = "Price: " + custsCoffee.CalculateCoffeePrice(CoffeePrice).ToString("C2");
                coffeesOrdered.Add(custsCoffee);
                ttlCoffeesLabel.Text = "Total:" + coffeesOrdered.Capacity.ToString();
            }

        }
        #endregion

        private void icedLatteRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (icedLatteRdBtn.Checked == true)
            {
                CoffeeMilkAmnt.Visible = true;
                MilkAmountLbl.Visible = true;
            }
            else
            {
                CoffeeMilkAmnt.Visible = false;
                MilkAmountLbl.Visible = false;
            }
        }

        private void outputListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            outPutLabel.Text= outputListBox.SelectedItem.ToString();
        }
    }
}
