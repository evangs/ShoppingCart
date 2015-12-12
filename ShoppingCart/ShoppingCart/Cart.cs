using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Cart
    {
        private ArrayList items { get; set; }
        private ArrayList salesTaxExcludedTypes { get; set; }
        private Dictionary<Item,double> itemTax { get; set; }
        private double total { get; set; }
        private double taxTotal { get; set; }
        private double taxRate { get; set; }
        private double importTaxRate { get; set; }
        public Cart(double taxRate, double importTaxRate)
        {
            this.taxRate = taxRate;
            this.importTaxRate = importTaxRate;
            this.total = 0.0;
            this.taxTotal = 0.0;
            this.items = new ArrayList();
            this.salesTaxExcludedTypes = new ArrayList();
            this.itemTax = new Dictionary<Item, double>();
        }

        public void addItem(Item item)
        {
            this.items.Add(item);
            this.itemTax.Add(item, this.calculateItemTax(item));
            this.taxTotal += this.itemTax[item];
            this.total += (item.getQuantity() * item.getPrice()) + this.itemTax[item];
        }

        public void removeItem(Item item)
        {
            this.taxTotal -= this.itemTax[item];
            this.taxTotal -= (item.getQuantity() * item.getPrice()) + this.itemTax[item];
            this.items.Remove(item);
            if (this.itemTax.ContainsKey(item))
            {
                this.itemTax.Remove(item);
            }
        }

        public void addExcludeType(int type)
        {
            this.salesTaxExcludedTypes.Add(type);
        }

        public void removeExcludeType(int type)
        {
            this.salesTaxExcludedTypes.Remove(type);
        }

        public void setTaxRate(double taxRate)
        {
            this.taxRate = taxRate;
            this.recalculateTax();
            this.recalculateTotal();
        }

        public double getTaxRate()
        {
            return this.taxRate;
        }

        public void setImportTaxRate(double importTaxRate)
        {
            this.importTaxRate = importTaxRate;
            this.recalculateTax();
            this.recalculateTotal();
        }

        public double getImportTaxRate()
        {
            return this.importTaxRate;
        }

        public double getTotal()
        {
            return this.total;
        }

        public double getTaxTotal()
        {
            return this.taxTotal;
        }

        private double calcualteBasicTax(Item item)
        {
            if (this.salesTaxExcludedTypes.IndexOf(item.getType()) > -1)
            {
                return 0.0;
            }

            return Math.Round((item.getQuantity() * item.getPrice()) * this.taxRate, 2, MidpointRounding.AwayFromZero);
        }

        private double calculateImportTax(Item item)
        {
            if (!item.getImported())
            {
                return 0.0;
            }

            return Math.Round((item.getQuantity() * item.getPrice()) * this.importTaxRate, 2, MidpointRounding.AwayFromZero);
        }

        private double calculateItemTax(Item item)
        {
            double basicTax = this.calcualteBasicTax(item);
            double importTax = this.calculateImportTax(item);

            return basicTax + importTax;
        }

        public void recalculateTax()
        {
            this.taxTotal = 0;

            foreach (Item item in this.items)
            {
                double tax = this.calculateItemTax(item);
                if (this.itemTax.ContainsKey(item))
                {
                    this.itemTax[item] = tax;
                }
                else
                {
                    this.itemTax.Add(item, tax);
                }
                this.taxTotal += tax;
            }
        }

        public void recalculateTotal()
        {
            this.total = 0;

            foreach (Item item in this.items)
            {
                this.total += (item.getQuantity() * item.getPrice()) + this.itemTax[item];
            }
        }

        public void displayCart()
        {
            foreach (Item item in this.items)
            {
                Console.WriteLine(item.getQuantity() + " " + item.getName() + ": " + (item.getPrice() + this.itemTax[item]).ToString("F2"));
            }
            Console.WriteLine("Sales Taxes: " + this.taxTotal.ToString("F2"));
            Console.WriteLine("Total: " + this.total.ToString("F2"));
        }
    }
}
