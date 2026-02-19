using Microsoft.EntityFrameworkCore;
using SubscriptionAPI.Data;
using SubscriptionAPI.Models;

namespace SubscriptionAPI.Repositories
{
    public class SubscriptionRepository
    {
        public SubscriptionRepository() { }
        private DataContext _dataContext;
        public SubscriptionRepository(DataContext dataContext) { _dataContext = dataContext; }

        public async Task Add(Subscription subscription)
        {
            _dataContext.Add(subscription);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Subscription> Update(Subscription subscription)
        {
            _dataContext.Update(subscription);
            await _dataContext.SaveChangesAsync();
            return subscription;
        }

        public async Task Delete(int id)
        {
            _dataContext.Remove(id);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<Subscription>> GetAll()
        {
            return await _dataContext.Set<Subscription>().ToListAsync();
        }

        public async Task<Subscription> GetById(int id)
        {
            return await _dataContext.Set<Subscription>().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<Subscription> GetFree()
        {
            return await _dataContext.Set<Subscription>().Where(s => s.Type == "Free").Where(s => s.FinishedDate != DateTime.Now).FirstOrDefaultAsync();
        }
    }
}
