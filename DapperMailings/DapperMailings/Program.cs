using DapperMailings.Models;
using System;
using System.Linq;

namespace DapperMailings
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            var db = new MailingRepository();
            Client client = new Client(); ;
            Country country = new Country();
            City city = new City();
            Category category = new Category();
            Product product = new Product();
            InterestedBuyer interestedBuyer = new InterestedBuyer();
            Promotion promotion = new Promotion(); ;


            do
            { 
                 Console.WriteLine( "1  + Вставка информации о новых покупателях"
                                + "\n2  + Вставка новых стран" 
                                + "\n3  + Вставка новых городов"
                                + "\n4  + Вставка информации о новых разделах"
                                + "\n5  + Вставка информации о новых акционных товарах"
                                + "\n6  + Обновление информации о покупателях"
                                + "\n7  + Обновление информации о странах"
                                + "\n8  + Обновление информации о городах"
                                + "\n9  + Обновление информации о разделах"
                                + "\n10 + Обновление информации об акционных товарах"
                                + "\n11 + Удаление информации о покупателях"
                                + "\n12 + Удаление информации о странах"
                                + "\n13 + Удаление информации о городах"
                                + "\n14 + Удаление информации о разделах"
                                + "\n15 + Удаление информации об акционных товарах\n"

                                + "\n16 + Отображение всех покупателей"
                                + "\n17 + Отображение email всех покупателей"
                                + "\n18 + Отображение списка разделов"
                                + "\n19 + Отображение списка акционных товаров"
                                + "\n20 + Отображение всех городов"
                                + "\n21 + Отображение всех стран"
                                + "\n22 + Отображение всех покупателей из конкретного города"
                                + "\n23 + Отображение всех покупателей из конкретной страны"
                                + "\n24 + Отображение всех акций для конкретной страны"
                                + "\n25 + Отображение списка городов конкретной страны"
                                + "\n26 + Отображение списка разделов конкретного покупателя"
                                + "\n27 + Отображение списка акционных товаров конкретного раздела"
                                + "\n28 + Выход\n");


                int.TryParse(Console.ReadLine(), out int action);
                Console.Clear();
                if (action == 1)
                {
                    client = new Client();
                    client.CityId = 1;
                    client.CountryId = 1;
                    client.DateOfBith = DateTime.Now.AddYears(-30);
                    client.Email = "test@mail.ru";
                    client.Gender = "Male";

                    Console.Write("Enter Fullname : ");
                    string fullName = Console.ReadLine();

                    client.FullName = fullName;

                    try
                    {
                        db.AddClient(client);
                        Console.WriteLine("Client added");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 2)
                { 
                    Console.Write("Enter Country Name : ");
                    country.Name = Console.ReadLine();
                    
                    try
                    {
                        db.AddCountry(country);
                        Console.WriteLine("Country added");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 3)
                { 
                    Console.Write("Enter City Name : ");
                    city.Name = Console.ReadLine();
                    
                    try
                    {
                        db.AddCity(city);
                        Console.WriteLine("City added");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 4)
                { 
                    Console.Write("Enter Category Name : ");
                    category.Name = Console.ReadLine();
                    
                    try
                    {
                        db.AddCategory(category);
                        Console.WriteLine("Category added");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 5)
                { 
                    promotion = new Promotion();

                    Console.Write("Enter Percent : ");
                    int.TryParse(Console.ReadLine(), out int percent);
                    promotion.Percent = percent;
                    promotion.CountryId = 1;//rand
                    promotion.ProducId = 1;//rand
                    promotion.StartDate = DateTime.Now;
                    promotion.EndDate = DateTime.Now.AddMonths(1);   

                    try
                    {
                         db.AddPromotion(promotion);
                         Console.WriteLine("Add succesful");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 6)
                {
                    client = new Client();
                    //znacenie randomniie
                    client.CityId = 1;
                    client.CityId = 1;
                    client.CountryId = 1;
                    client.DateOfBith = DateTime.Now.AddYears(-30);
                    client.Email = "test@mail.ru";
                    client.Gender = "Male";

                    Console.Write("Enter Fullname : ");
                    string fullName = Console.ReadLine();

                    client.FullName = fullName;
                     
                    try
                    {
                         db.UpdatingClient(client);
                         Console.WriteLine("Client updated");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 7)
                {
                    count = 1;
                    var size = db.GetCountries().Count;
                    foreach (var item in db.GetCountries())
                    {
                        Console.WriteLine((count++) + ". " + item);
                    }

                    country = new Country(); 
                    Console.Write("\nEnter index for change : ");

                    int.TryParse(Console.ReadLine(), out int num);

                    country.Id = num;


                    Console.Write("Enter name : ");
                    country.Name = Console.ReadLine(); 

                  
                    try
                    {
                        db.UpdatingCountry(country);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    if (size < db.GetCountries().Count)
                    {
                        Console.WriteLine("Country updated");
                    }
                    else
                    {
                        Console.WriteLine("Country not updated");
                    }
                }
                else if (action == 8)
                {
                    count = 1;
                    var size = db.GetCities().Count;
                    foreach (var item in db.GetCities())
                    {
                        Console.WriteLine((count++) + ". " + item);
                    }

                    city = new City();
                    Console.Write("\nEnter index for change : ");

                    int.TryParse(Console.ReadLine(), out int num);
                     
                    city.Id = num;
                    Console.Write("\nEnter name : ");
                    city.Name = Console.ReadLine();
                    
                    try
                    {
                        db.UpdatingCity(city);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    if (size < db.GetCities().Count)
                    {
                        Console.WriteLine("City updated");
                    }
                    else
                    {
                        Console.WriteLine("City not updated");
                    }
                   
                }
                else if (action == 9)
                {
                    count = 1;
                    var size = db.GetCategories().Count;
                    foreach (var item in db.GetCategories())
                    {
                        Console.WriteLine((count++) + ". " + item);
                    }

                    category = new Category();
                    Console.Write("\nEnter index for change : ");

                    int.TryParse(Console.ReadLine(), out int num);

                    category.Id = num;
                    Console.Write("\nEnter name : ");
                    category.Name = Console.ReadLine();

                    try
                    {
                        db.UpdatingCategories(category);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    if (size < db.GetCategories().Count)
                    {
                        Console.WriteLine("Category updated");
                    }
                    else
                    {
                        Console.WriteLine("Category not updated");
                    }
                }
                else if (action == 10)
                { 
                    promotion = new Promotion();

                    Console.Write("Enter Percent : ");
                    int.TryParse(Console.ReadLine(), out int percent);
                    promotion.Percent = percent;
                    promotion.CountryId = 1;//rand
                    promotion.Id = 1;
                    promotion.ProducId = 1;//rand
                    promotion.StartDate = DateTime.Now;
                    promotion.EndDate = DateTime.Now.AddMonths(1);  
                     
                    try
                    {
                        db.UpdatingPromotion(promotion); 
                        Console.WriteLine("Promotion updated");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 11)
                {
                    count = 1; 
                    foreach (var item in db.GetClients())
                    {
                        Console.WriteLine((count++) + ". " + item);
                    }
                    Console.Write("\nEnter index for change : ");

                    int.TryParse(Console.ReadLine(), out int num);

                    try
                    {
                        db.DeleteClient(num);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 12)
                {
                    count = 1;
                    foreach (var item in db.GetCountries())
                    {
                        Console.WriteLine((count++) + ". " + item);
                    }
                    Console.Write("\nEnter index for change : ");

                    int.TryParse(Console.ReadLine(), out int num);

                    try
                    {
                        db.DeleteCountry(num);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 13)
                {
                    count = 1;
                    foreach (var item in db.GetCities())
                    {
                        Console.WriteLine((count++) + ". " + item);
                    }
                    Console.Write("\nEnter index for change : ");

                    int.TryParse(Console.ReadLine(), out int num);

                    try
                    {
                        db.DeleteCity(num);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 14)
                {
                    count = 1;
                    foreach (var item in db.GetCategories())
                    {
                        Console.WriteLine((count++) + ". " + item);
                    }
                    Console.Write("\nEnter index for change : ");

                    int.TryParse(Console.ReadLine(), out int num);

                    try
                    {
                        db.DeleteCategory(num);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 15)
                { 
                    try
                    {
                        db.DeletePromotion(1);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (action == 16)
                { 
                    foreach (var item in db.GetClients())
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (action == 17)
                {
                    foreach (var item in db.GetClientsEmail())
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (action == 18)
                {
                    foreach (var item in db.GetCategories())
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (action == 19)
                { 
                    var results = db.GetPromotionProducts();

                    if (results.Count > 0)
                        foreach (var item in results)
                            Console.WriteLine(item + "\t" + item.Product.Name.PadRight(19, ' '));
                    else
                        Console.WriteLine("No data!");
                }
                else if (action == 20)
                {
                    foreach (var item in db.GetCities())
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (action == 21)
                {
                    foreach (var item in db.GetCountries())
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (action == 22)
                {
                    Console.Write("Enter City Name : ");
                    string name = Console.ReadLine();

                    var results = db.GetClientsByCity(name);

                    if (results.Count > 0)
                        foreach (var item in results)
                            Console.WriteLine(item);
                    else
                        Console.WriteLine("No data!");
                }
                else if (action == 23)
                {
                    Console.Write("Enter Country Name : ");
                    string name = Console.ReadLine();

                    var results = db.GetClientsByCountry(name);
                    
                    if (results.Count>0)
                           foreach (var item in results)  
                               Console.WriteLine(item);
                    else
                           Console.WriteLine("No data!"); 
                }
                else if (action == 24)
                {
                    Console.Write("Enter Country Name : ");
                    string name = Console.ReadLine();

                    var results = db.GetPromotionsByCountry(name);

                    if (results.Count > 0)
                        foreach (var item in results)
                            Console.WriteLine(item+"\t"+item.Product.Name.PadRight(15,' ')+" "+item.Country.Name);
                    else
                        Console.WriteLine("No data!");
                }
                else if (action == 25)
                {
                    Console.Write("Enter Country Name : ");
                    string name = Console.ReadLine();

                    var results = db.GetCitiesByCountry(name);

                    if (results.Count > 0)
                        foreach (var item in results)
                            Console.WriteLine(item);
                    else
                        Console.WriteLine("No data!");
                }
                else if (action == 26)
                {
                    Console.Write("Enter Client FullName : ");
                    string name = Console.ReadLine(); 

                    var results = db.GetCategoriesByClient(name);

                    if (results.Count > 0)
                        foreach (var item in results)
                            Console.WriteLine(item);
                    else
                        Console.WriteLine("No data!");
                }
                else if (action == 27)
                {
                    Console.Write("Enter Category Name : ");
                    string name = Console.ReadLine();

                    var results = db.GetPromotionProductByCategory(name);

                    if (results.Count > 0)
                        foreach (var item in results)
                            Console.WriteLine(item+"\t"+item.Product.Name.PadRight(19,' ')+"\t" + item.Product.Category.Name);
                    else
                        Console.WriteLine("No data!");
                }
                else if (action == 28) 
                { 
                    return;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();

                Console.Clear();
            } while (true);

        }
    }
}
