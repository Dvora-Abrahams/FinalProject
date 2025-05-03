using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    class WarehouseService
    {
        private readonly DB_Manager _context;
        public WarehouseService()
        {
            _context = new DB_Manager();
        }
        public async Task AddWarehouse(Warehouse warehouse)
        {
            _context.Warehouses.Add(warehouse);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Warehouse>> GetAllWarehouses()
        {
            return await _context.Warehouses.ToListAsync();
        }
        public async Task<Warehouse> GetWarehouseById(int id)
        {
            var warehouse = await _context.Warehouses.FirstOrDefaultAsync(w => w.Id == id);
            if (warehouse == null)
            {
                throw new Exception("Warehouse not found");
            }
            return warehouse;
        }
       
      
    }
}
