using BookStore.Models;
using System.Xml.Linq;

namespace BookStore.Services
{
    public class BookService
    {
        private List<Book> books = new List<Book>()
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", Price = 300, Description="Антиутопія" },
            new Book { Id = 2, Title = "Маленький принц", Author = "Антуан де Сент-Екзюпері", Price = 250, Description="Філософська казка" },
            new Book { Id = 3, Title = "Гаррі Поттер", Author = "Дж. Роулінг", Price = 400, Description="Фентезі" },
            new Book { Id = 4, Title = "Кобзар", Author = "Тарас Шевченко", Price = 200, Description="Поезія" }
        };

        public List<Book> GetAll() => books;

        public Book? GetById(int id) =>
            books.FirstOrDefault(b => b.Id == id);

        public void Delete(int id)
        {
            var book = GetById(id);
            if (book != null)
                books.Remove(book);
        }

        public void Update(Book updatedBook)
        {
            var book = GetById(updatedBook.Id);
            if (book != null)
            {
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.Price = updatedBook.Price;
                book.Description = updatedBook.Description;
            }
        }
    }
}
