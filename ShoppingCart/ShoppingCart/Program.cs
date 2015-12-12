using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    class Program
    {
        static void Main(string[] args)
        {

            const int BOOKS = 0;
            const int FOOD = 1;
            const int MEDICAL = 2;
            const int MEDIA = 3;
            const int COSMETICS = 4;

            Cart basket1 = new Cart(0.10, 0.05);
            basket1.addExcludeType(BOOKS);
            basket1.addExcludeType(FOOD);
            basket1.addExcludeType(MEDICAL);
            basket1.addItem(new Item("book", false, BOOKS, 12.49, 1));
            basket1.addItem(new Item("music CD", false, MEDIA, 14.99, 1));
            basket1.addItem(new Item("chocolate bar", false, FOOD, 0.85, 1));
            basket1.displayCart();
            Console.WriteLine();

            Cart basket2 = new Cart(0.10, 0.05);
            basket2.addExcludeType(BOOKS);
            basket2.addExcludeType(FOOD);
            basket2.addExcludeType(MEDICAL);
            basket2.addItem(new Item("imported box of chocolates", true, FOOD, 10.00, 1));
            basket2.addItem(new Item("imported bottle of perfume", true, COSMETICS, 47.50, 1));
            basket2.displayCart();
            Console.WriteLine();

            Cart basket3 = new Cart(0.10, 0.05);
            basket3.addExcludeType(BOOKS);
            basket3.addExcludeType(FOOD);
            basket3.addExcludeType(MEDICAL);
            basket3.addItem(new Item("imported bottle of perfume", true, COSMETICS, 27.99, 1));
            basket3.addItem(new Item("bottle of perfume", false, COSMETICS, 18.99, 1));
            basket3.addItem(new Item("packet of headache pills", false, MEDICAL, 9.75, 1));
            basket3.addItem(new Item("imported box of chocolates", true, FOOD, 11.25, 1));
            basket3.displayCart();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
