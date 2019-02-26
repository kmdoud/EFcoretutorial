using EFCoreTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreTutorial
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new AppDBContext())
            {
                var insOrder1 = new Order()
                {
                    Id = 0,
                    Date = DateTime.Now,
                    Description = " first order for Amazon",
                    CustomerId = db.Customers.SingleOrDefault(c => c.Name == "Amazon").Id,
                    Total = 1050.50
                };
                var insOrder2 = new Order()
                {
                    Id = 0,
                    Date = DateTime.Now,
                    Description = " first order for Steam",
                    CustomerId = db.Customers.SingleOrDefault(c => c.Name == "Steam").Id,
                    Total = 4351.55
                };
                var insOrder3 = new Order()
                {
                    Id = 0,
                    Date = DateTime.Now,
                    Description = " first order for Dell",
                    CustomerId = db.Customers.SingleOrDefault(c => c.Name == "Dell").Id,
                    Total = 5000
                };
                var insOrder4 = new Order()
                {
                    Id = 0,
                    Date = DateTime.Now,
                    Description = " first order for Gigabyte",
                    CustomerId = db.Customers.SingleOrDefault(c => c.Name == "Macys Retail").Id,
                    Total = 9999.99
                };
                var insOrder5 = new Order()
                {
                    Id = 0,
                    Date = DateTime.Now,
                    Description = " second order for Amazon",
                    CustomerId = db.Customers.SingleOrDefault(c => c.Name == "Amazon").Id,
                    Total = 10000
                };

                //db.Orders.AddRange(new[] { insOrder1, insOrder2, insOrder3, insOrder4, insOrder5 });

                var cust = "Amazon";
                var azntotal = db.Orders
                    .Where(o => o.Customer.Name == cust)
                    .Sum(o => o.Total);

                Console.WriteLine($"Name {cust} Total {azntotal}");
                
                    


                var orders = db.Orders
                    .OrderBy(o => o.Id)
                    .ToList();
                foreach(var order in orders)
                {
                    Console.WriteLine(order.Description);
                }

                var gt5k = db.Orders
                    .Where(o => o.Total > 5000)
                    .OrderByDescending(o => o.Total)
                    .ToList();
                foreach(var order in gt5k)
                {
                    Console.WriteLine(order);
                }

                var firstorder = db.Orders.Find(1);
                Console.WriteLine("PK result = " + firstorder.Description +" " + firstorder.Total);


                //compare to "Get all users"
                var customers = db.Customers
                 .Where(c => c.Active == true)
                 .OrderBy(c => c.Name)
                 .ToList();
                foreach (var customer in customers)
                {
                    Console.WriteLine(customer.Name);
                }

                //compare to "GetByPrimaryKey"

                var id = 5;
                var macys = db.Customers.Find(id);
                Console.WriteLine("PK result = " + macys.Name);

                //compare to "insert user"
                var insCustomer = new Customer()
                {
                    Id = 0, 
                    Name = "Kroger",
                    Active = true,
                    DateCreated = DateTime.Now,
                    Phone = "555-123-4567"

                };
                var haskroger = db.Customers.Any(c => c.Name == "Kroger");
                if (!haskroger)
                {
                    db.Customers.Add(insCustomer);
                }
                else
                    Console.WriteLine("Cannot duplicate user");

                //compare to "update user"

                var cMy = db.Customers.Find(5);
                cMy.Name = "Macys Retail";
                cMy.Phone = "555-321-9876";

                //compare to "delete user"
                var firstkroger = db.Customers.FirstOrDefault(c => c.Name == "Kroger");
                if(firstkroger != null)
                {
                    db.Customers.Remove(firstkroger);
                }

                db.SaveChanges();

            }
           

        }
    }
}
