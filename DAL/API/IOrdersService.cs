using DAL.Models;

namespace DAL.API
{
    public interface IOrdersService
    {
        Task AddOrder(Order order);
        Task<List<Order>> GetAllOrderBySupplierId(int SupplierId);
        Task<List<Order>> GetAllOrders();
        Task<Order> GetOrderById(int id);
        Task<List<Order>> GetOrderBySupplierId(int SupplierId);
        Task UpdateOrder(Order order);
        Task<bool> updateOrderStatus(string status, int id, int IdSuppliers);
}