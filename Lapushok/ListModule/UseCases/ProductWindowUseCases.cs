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
    public class ProductWindowUseCases
    {
        public async Task<List<Material>> GetMaterials()
        {
            return await LapushokDAO.Context.Materials.ToListAsync();
        }

        public List<Material> FilterMaterials(List<Material> materials, string filter)
        {
            return materials.Where(m => m.Title.Contains(filter)).ToList();
        }
    }
}
