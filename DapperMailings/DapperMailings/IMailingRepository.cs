using DapperMailings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperMailings
{
    interface IMailingRepository
    {
         void AddClient(Client client);
         void AddCity(City city);
         void AddCountry(Country country);
         void AddCity(params City[] cities);
         void AddCountry(params Country[] countries);
         void AddCategory(Category category);
         void AddCategory(params Category[] categories);
         void AddPromotion(Promotion promotion);
         void AddPromotion(params Promotion[] promotions);

         //////////////////////////////////////////////////////////////////////////////////////////// 
        
         List<Client> GetClients();
         List<string> GetClientsEmail();
         List<Category> GetCategories();
         List<City> GetCities();
         List<Country> GetCountries();
         List<Client> GetClientsByCountry(string country);
         List<Client> GetClientsByCity(string city);
         List<Promotion> GetPromotionsByCountry(string country);
         List<City> GetCitiesByCountry(string country);
         List<Category> GetCategoriesByClient(string client);
         List<Promotion> GetPromotionProductByCategory(string category);
         List<Promotion> GetPromotionProducts();

        ////////////////////////////////////////////////////////////////////////////////////////

        void UpdatingClient(Client client);
        void UpdatingCountry(Country country);
        void UpdatingCity(City city);
        void UpdatingCategories(Category category);
        void UpdatingPromotion(Promotion promotion);

        //////////////////////////////////////////////////////////////////////////////////////// 
        void DeleteClient(int id);
        void DeleteCountry(int id);
        void DeleteCity(int id);
        void DeleteCategory(int id);
        void DeletePromotion(int id);
    }
}
