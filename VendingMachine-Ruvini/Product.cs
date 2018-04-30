using System.Globalization;

namespace VendingMachine_Ruvini
{
    /// <summary>
    /// Defines a product and its price
    /// </summary>
    public class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public override string ToString()
        {
            string value = string.Format("{0} - {1}", Name, Price.ToString("C", CultureInfo.CreateSpecificCulture("en-GB")));
            return value;
        }
    }
}
