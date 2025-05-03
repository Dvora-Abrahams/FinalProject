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
    class MessagesService : IMessagesService
    {
        private readonly DB_Manager _context;
        public MessagesService()
        {
            _context = new DB_Manager();
        }
        public async Task AddMessage(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Message>> GetMessagesBetweenAsync(int supplierId)
        {
            return await _context.Messages
                .Where(m =>
                    (m.SupplierId == supplierId))
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }
        public async Task SendMessageAsync(Message message)
        {
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
        }

        public async Task MarkAsReadAsync(int messageId)
        {
            var message = await _context.Messages.FindAsync(messageId);
            if (message != null)
            {
                message.IsRead = true;
                await _context.SaveChangesAsync();
            }
        }
    }
}
