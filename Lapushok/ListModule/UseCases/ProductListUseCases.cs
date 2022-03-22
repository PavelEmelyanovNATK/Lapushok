using Lapushok.Models.DBEntities;
using Lapushok.Services.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lapushok.ListModule.UseCases
{
    public class ProductListUseCases
    {
        public static readonly string[] SortTypes = 
        {
            "По названию (возрастание)",
            "По названию (убывание)",
            "По цеху (убывание)",
            "По цеху (возрастание)",
            "По мин. стоимости (убывание)",
            "По мин. стоимости (возрастание)"
        };

        public async Task<List<Product>> GetProducts()
        {
            return await LapushokDAO.Context.Products.ToListAsync();
        }

        public async Task<List<Product>> GetProducts(string productSortType, Material material, string search = "")
        {
            
            var searched = LapushokDAO.Context.Products.Where(p => 
               (p.Title.Contains(search) || p.Description.Contains(search))
               &&
               (material.Title == "Все" || p.ProductMaterials.Any(m => m.MaterialID == material.ID))
            );

            if (productSortType == SortTypes[0])
                    searched = searched.OrderBy(p => p.Title);
            else if (productSortType == SortTypes[1])
                    searched = searched.OrderByDescending(p => p.Title);
            else if (productSortType == SortTypes[2])
                searched = searched.OrderBy(p => p.ArticleNumber);
            else if (productSortType == SortTypes[3])
                searched = searched.OrderByDescending(p => p.ArticleNumber);
            else if (productSortType == SortTypes[4])
                searched = searched.OrderBy(p => p.MinCostForAgent);
            else if (productSortType == SortTypes[5])
                searched = searched.OrderByDescending(p => p.MinCostForAgent);

            return await searched.ToListAsync();
        }

        public async Task<List<Material>> GetMaterials()
        {
            return await LapushokDAO.Context.Materials.ToListAsync();
        }
    }
}
