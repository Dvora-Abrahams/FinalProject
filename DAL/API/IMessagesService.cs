using DAL.Models;

namespace DAL.API
{
    internal interface IMessagesService
    {
        Task AddMessage(Message message);
        Task<List<Message>> GetMessagesBetweenAsync(int supplierId);
        Task MarkAsReadAsync(int messageId);
        Task SendMessageAsync(Message message);
    }
}