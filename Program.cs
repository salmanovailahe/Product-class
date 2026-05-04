using System;
using System.Collections.Generic;

class Product
{
    public string Name { get; set; }
    public string Category { get; set; }
    public double Price { get; set; }
    public DateTime ExpireDate { get; set; }

    public void Show()
    {
        Console.WriteLine("Ad: " + Name);
        Console.WriteLine("Kateqoriya: " + Category);
        Console.WriteLine("Qiymet: " + Price);
        Console.WriteLine("Bitme tarixi: " + ExpireDate.ToShortDateString());
        Console.WriteLine("----------------");
    }

    public bool IsExpired()
    {
        return DateTime.Now > ExpireDate;
    }
}

class Program
{
    static bool CheckProduct(List<Product> list, Product p)
    {
        foreach (var item in list)
            if (item.Name == p.Name)
                return true;

        return false;
    }

    static List<Product> Filter(List<Product> list, string category)
    {
        List<Product> result = new List<Product>();

        foreach (var item in list)
            if (item.Category == category)
                result.Add(item);

        return result;
    }

    static void RemoveExpired(List<Product> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
            if (list[i].IsExpired())
                list.RemoveAt(i);
    }

    static void Main()
    {
        List<Product> products = new List<Product>();

        products.Add(new Product { Name = "Milk", Category = "Dairy", Price = 2.5, ExpireDate = new DateTime(2026, 5, 1) });
        products.Add(new Product { Name = "Bread", Category = "Bakery", Price = 1.2, ExpireDate = new DateTime(2024, 1, 1) });
        products.Add(new Product { Name = "Cheese", Category = "Dairy", Price = 4.8, ExpireDate = new DateTime(2026, 6, 1) });

        Console.WriteLine("BUTUN MEHSULLAR:");
        foreach (var p in products)
            p.Show();

        Console.WriteLine("p1 varmi?");
        Console.WriteLine(CheckProduct(products, products[0]) ? "Beli" : "Xeyr");

        Console.WriteLine("DAIRY mehsullari:");
        foreach (var p in Filter(products, "Dairy"))
            p.Show();

        Console.WriteLine("Bitmis mehsullar silinir...");
        RemoveExpired(products);

        Console.WriteLine("QALAN:");
        foreach (var p in products)
            p.Show();
    }
}
