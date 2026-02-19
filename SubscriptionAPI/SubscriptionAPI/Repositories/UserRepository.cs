using Microsoft.EntityFrameworkCore;
using SubscriptionAPI.Data;
using SubscriptionAPI.Models;

namespace SubscriptionAPI.Repositories
{
    public class UserRepository
    {
        public UserRepository() { }
        private DataContext _dataContext;
        public UserRepository(DataContext dataContext) { _dataContext = dataContext; }

        public async Task Add(User user)
        {
            _dataContext.Add(user);
            await _dataContext.SaveChangesAsync(); 
        }

        public async Task<User> Update(User user)
        {
            _dataContext.Update(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

        public async Task Delete(int id)
        {
            _dataContext.Remove(id);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll() 
        {
            return await _dataContext.Set<User>().ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
           return await _dataContext.Set<User>().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetByA()
        {
            return await _dataContext.Set<User>().Where(u => u.Name[0] == 'A').ToListAsync();
        }

        public async Task<List<User>> GetBySubscription()
        {
            return await _dataContext.Set<User>().Where(u => u.subscriptions.Any()).ToListAsync();
        }

        public async Task<List<User>> GetByPremium()
        {
            return await _dataContext.Set<User>().Where(u => u.subscriptions.Any(s => s.Type == "Premium")).Take(5).ToListAsync();
        }

        public async Task<User> Get()
        {
            return await _dataContext.Set<User>().OrderByDescending(u => u.subscriptions.Count).FirstOrDefaultAsync();
        }
    }
}
