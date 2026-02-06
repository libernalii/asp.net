using hw_2.Data;
using hw_2.Models;

namespace hw_2.Repositories
{
    public class BookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public List<Book> GetAll() => _context.Books.ToList();

        public Book? GetById(int id) => _context.Books.Find(id);

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }

        public void Delete(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
