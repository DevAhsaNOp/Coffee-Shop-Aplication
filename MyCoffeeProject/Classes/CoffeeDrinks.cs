namespace MyCoffeeProject.Classes
{
    public abstract class CoffeeDrinks
    {
        public string CupSize { get; set; }
        public string brewTime { get; set; }
        public double CoffeePrice { get; set; }

        protected const double STOREPOSFEE = 35;

        public abstract double CalculateCoffeePrice(double CoffeePrice, double StorePosFee = STOREPOSFEE, double GeneralSalestax = 135.7);
    }

    class IcedLatte : CoffeeDrinks
    {
        public string IceAmount { get; set; }
        public string MilkAmount { get; set; }
        public IcedLatte(string siz, string brewTi, string iceAmt, string milkA, double pric)
        {
            CupSize = siz;
            brewTime = brewTi;
            IceAmount = iceAmt;
            MilkAmount = milkA;
            CoffeePrice = pric;
        }

        public override double CalculateCoffeePrice(double CoffeePrice, double StorePosFee = 35, double GeneralSalestax = 135.7)
        {
            return CoffeePrice + StorePosFee + GeneralSalestax + 40;
        }
    }

    class IcedCoffee : CoffeeDrinks
    {
        public string iceAmount { get; set; }

        public IcedCoffee(string siz, string brewTi, string iceAmt, double pric)
        {
            CupSize = siz;
            brewTime = brewTi;
            iceAmount = iceAmt;
            CoffeePrice = pric;
        }

        public override double CalculateCoffeePrice(double CoffeePrice, double StorePosFee = 35, double GeneralSalestax = 135.7)
        {
            return CoffeePrice + StorePosFee + GeneralSalestax;
        }
    }
}
