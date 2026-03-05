using DLL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repositoy
{
    public class CatRepository
    {
        private readonly CatContext _context;
        public CatRepository(CatContext context)
        {
            _context = context;
        }
        public async Task<Cat> Add(Cat cat)
        {
            _context.Cats.Add(cat);
            await _context.SaveChangesAsync();
            return cat;
        }
        public async Task<Cat> Delete(int id)
        {
            var cat = await GetById(id);
            if (cat == null)
            {
                return null;
            }
            _context.Cats.Remove(cat);
            await _context.SaveChangesAsync();
            return cat;
        }
        public async Task<Cat> Update(Cat cat)
        {
            _context.Cats.Update(cat);
            await _context.SaveChangesAsync();
            return cat;
        }
        public async Task<Cat> GetById(int id)
        {
            return await _context.Cats.FindAsync(id);
        }
        public async Task<List<Cat>> GetAll(int limit = 10, int offset = 0)
        {
            return await _context.Cats.ToListAsync();
        }
    }
}
