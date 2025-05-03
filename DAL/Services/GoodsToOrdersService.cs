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
    public class GoodsToOrdersService : IGoodsToOrdersService
    {
        private readonly DB_Manager _context;
        public GoodsToOrdersService()
        {
            _context = new DB_Manager();
        }
        public async Task AddGoodsToOrder(int orderId, int goodsId, int quantity)
        {
            var exists = await _context.GoodsToOrders.AnyAsync(gs => gs.IdOrders == orderId && gs.IdGoods == goodsId);
            if (!exists)
            {
                var goodsToOrder = new GoodsToOrder
                {
                    IdOrders = orderId,
                    IdGoods = goodsId,
                    Quantity = quantity

                };
                _context.GoodsToOrders.Add(goodsToOrder);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Good>> GetGoodsToOrdersByOrderId(int orderId)
        {
            return await _context.GoodsToOrders.Where(gs => gs.IdOrders == orderId).Select(gs => gs.IdGoodsNavigation).ToListAsync();
        }
        public async Task<List<GoodsToOrder>> GetGoodsToOrdersDerailsByOrderId(int orderId)
        {
            return await _context.GoodsToOrders.Where(gs => gs.IdOrders == orderId).ToListAsync();
        }

    }
}
