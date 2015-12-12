using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Item
    {
        private string name { get; set; }
        private bool imported { get; set; }
        private int type { get; set; }
        private double price { get; set; }
        private int quantity { get; set; }
        public Item(string name, bool imported, int type, double price, int quantity)
        {
            this.name = name;
            this.imported = imported;
            this.type = type;
            this.price = price;
            this.quantity = quantity;
        }

        public string getName()
        {
            return this.name;
        }

        public bool getImported()
        {
            return this.imported;
        }

        public int getType()
        {
            return this.type;
        }

        public double getPrice()
        {
            return this.price;
        }

        public int getQuantity()
        {
            return this.quantity;
        }

        public void setQuantity(int quantity)
        {
            this.quantity = quantity;
        }
    }
}
