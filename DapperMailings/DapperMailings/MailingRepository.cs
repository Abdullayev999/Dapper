using Dapper;
using DapperMailings.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperMailings
{
    public class MailingRepository : IMailingRepository
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MailingsDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public void AddCategory(Category category)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Categories ([Name]) VALUES (@Name)";
            db.Execute(query, category);
        } 
        public void AddCategory(params Category[] categories)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Categories ([Name]) VALUES (@Name)";
            db.Execute(query, categories);
        } 
        public void AddCity(City city)
        { 
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Cities ([Name]) VALUES (@Name)";
            db.Execute(query, city);
        } 
        public void AddCity(params City[] cities)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Cities ([Name]) VALUES (@Name)";
            db.Execute(query, cities);
        } 
        public void AddClient(Client client)
        { 
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Clients (FullName, DateOfBith, Gender, Email, CountryId, CityId) values (@fullName, @dateOfBith, @gender, @email, @countryId, @cityId)";
            db.Execute(query, client); 
        } 
        public void AddCountry(Country country)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Countries ([Name]) VALUES (@Name)";
            db.Execute(query, country);
        } 
        public void AddCountry(params Country[] countries)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Countries ([Name]) VALUES (@Name)";
            db.Execute(query, countries);
        } 
        public void AddPromotion(Promotion promotion)
        {
            using var db = new SqlConnection(connectionString);
             
            var query = "INSERT INTO Promotions([Percent],[StartDate],[EndDate],CountryId,ProducId) VALUES (@Percent,@startDate,@endDate,@countryId,@productId)";

            var parametrs = new DynamicParameters();
            parametrs.Add("@Percent", promotion.Percent);
            parametrs.Add("@startDate", promotion.StartDate);
            parametrs.Add("@endDate", promotion.EndDate);
            parametrs.Add("@countryId", promotion.CountryId); 
            parametrs.Add("@productId", promotion.ProducId);

            db.Execute(query, parametrs);
        } 
        public void AddPromotion(params Promotion[] promotion)
        {
            using var db = new SqlConnection(connectionString);
            var query = "INSERT INTO Promotions ([Percent],[StartDate],[EndDate],CountryId) VALUES (@Percent,@StartDate,@EndDate,@CountryId)";
            db.Execute(query, promotion);
        }

        public void DeleteCategory(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = " DELETE FROM Categories WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public void DeleteCity(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = " DELETE FROM Cities WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public void DeleteClient(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = " DELETE FROM Clients WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public void DeleteCountry(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = " DELETE FROM Countries WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public void DeletePromotion(int id)
        {
            using var db = new SqlConnection(connectionString);
            var query = " DELETE FROM Promotions WHERE Id = @id";
            db.Execute(query, new { id });
        }

        public List<Category> GetCategories()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT Name FROM Categories";
            return db.Query<Category>(query).ToList();
        } 
        public List<Category> GetCategoriesByClient(string client)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"SELECT DISTINCT * FROM InterestedBuyers
                          JOIN Clients ON InterestedBuyers.ClientId = Clients.Id
                          JOIN Categories ON InterestedBuyers.CategoryId = Categories.Id
                          WHERE Clients.FullName = @client";

            return db.Query<Category>(query, new { client }).ToList();
        } 
        public List<City> GetCities()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Cities";
            return db.Query<City>(query).ToList();
        } 
        public List<City> GetCitiesByCountry(string country)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"SELECT DISTINCT Cities.Name FROM Clients
                          JOIN Cities ON Clients.CityId = Cities.Id
                          JOIN Countries ON Countries.Id = Clients.CountryId
                          WHERE Countries.Name LIKE @country";

           return  db.Query<City>(query, new { country }).ToList();
        } 
        public List<Client> GetClients()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Clients";
            return db.Query<Client>(query).ToList();
        } 
        public List<Client> GetClientsByCity(string city)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"SELECT Clients.* FROM Clients
                          JOIN Cities on Clients.CityId = Cities.Id
                          WHERE Cities.[Name] = @city";

            return db.Query<Client>(query, new { city }).ToList();
        } 
        public List<Client> GetClientsByCountry(string country)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"SELECT Clients.* FROM Clients
                          JOIN Countries on Clients.CountryId = Countries.Id
                          WHERE Countries.[Name] = @country";
              
            return db.Query<Client>(query, new { country }).ToList();  
        } 
        public List<string> GetClientsEmail()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT Email FROM Clients";
            return db.Query<string>(query).ToList();
        } 
        public List<Country> GetCountries()
        {
            using var db = new SqlConnection(connectionString);
            var query = "SELECT * FROM Countries";
            return db.Query<Country>(query).ToList();
        } 
        public List<Promotion> GetPromotionProductByCategory(string category)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"SELECT * FROM Promotions
                          JOIN Products ON Promotions.ProducId = Products.Id
                          JOIN Categories ON Products.CategoryId = Categories.Id
                          WHERE Categories.Name = @category";

            return db.Query<Promotion,Product,Category,Promotion>(query,(prom,prod,cat)=>
            {
                prom.Product = prod;
                prom.Product.Category = cat;
                return prom;
            },new { category }).ToList();
        } 
        public List<Promotion> GetPromotionProducts()
        {
            using var db = new SqlConnection(connectionString);
            var query = @"SELECT * FROM Promotions
                          JOIN Countries ON Promotions.CountryId = Countries.Id
                          JOIN Products ON Products.Id = Promotions.ProducId";

            return db.Query<Promotion, Country, Product, Promotion>(query,
            (promotion, country, product) =>
            {
                promotion.Country = country;
                promotion.Product = product;
                return promotion;

            }).ToList();
        } 
        public List<Promotion> GetPromotionsByCountry(string country)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"SELECT * FROM Promotions
                          JOIN Countries ON Promotions.CountryId = Countries.Id
                          JOIN Products ON Products.Id = Promotions.ProducId
                          WHERE Countries.Name = @country";

            return db.Query<Promotion, Country,Product, Promotion>(query,
            (promotion, country,product) =>
            {
                promotion.Country = country;
                promotion.Product = product;
                return promotion;

            },new { country} ).ToList();
        }

        public void UpdatingCategories(Category category)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Categories SET Name=@Name WHERE Id = @id ";
            db.Execute(query, category);
        }

        public void UpdatingCity(City city)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Cities SET Name=@Name WHERE Id = @id ";
            db.Execute(query, city);
        }

        public void UpdatingClient(Client client)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Clients SET FullName=@FullName, DateOfBith=@DateOfBith, Gender=@Gender, Email=@Email WHERE Id = @id ";
            db.Execute(query, client); 
        }

        public void UpdatingCountry(Country country)
        {
            using var db = new SqlConnection(connectionString);
            var query = @"UPDATE Countries SET Name=@Name WHERE Id = @id";
            db.Execute(query, country);
        }

        public void UpdatingPromotion(Promotion promotion)
        {
            using var db = new SqlConnection(connectionString);
            var query = @" UPDATE Promotions SET [Percent]=@Percent,[StartDate]=@StartDate,
                          [EndDate]=@EndDate,CountryId =@CountryId , ProducId = @ProducId WHERE Id = @id";
            db.Execute(query, promotion);
        }
    }
}
