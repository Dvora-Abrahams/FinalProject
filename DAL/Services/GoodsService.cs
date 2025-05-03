using DAL.API;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class GoodsService : IGoodsService
    {
        DB_Manager _context;
        public GoodsService()
        {
            _context = new DB_Manager();
        }

        public async Task AddGood(Good good)
        {
            _context.Goods.Add(good);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Good>> GetAllGoods()
        {
            return await _context.Goods.ToListAsync();
        }
        public async Task<Good> GetGoodByName(string name)
        {
            var good = await _context.Goods.FirstOrDefaultAsync(g => g.ProductName == name);
            if (good == null)
            {
                throw new Exception("the good not found");
            }
            return good;
        }
        public async Task<Good> GetGoodByNameAndPrice(string name, double price)
        {
            var good = await _context.Goods.FirstOrDefaultAsync(g => g.ProductName == name && g.Price == price);
            if (good == null)
            {
                throw new Exception("the good not found");
            }
            return good;
        }

        public async Task<List<Good>> GetGoodsToSupplier(int IdSupplier)
        {
            var goods = await _context.Goods.ToListAsync();
            List<Good> l = goods.Where(g => g.IdSupplier == IdSupplier).ToList();
            if (l == null)
            {
                throw new Exception($"the goods to supllier {IdSupplier} not found");
            }
            return l;
        }
        
            

    }
}
