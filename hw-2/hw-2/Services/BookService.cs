using hw_2.Models;
using hw_2.Repositories;

namespace hw_2.Services
{
    public class BookService
    {
        private readonly BookRepository _repository;
        private readonly DescriptionValidator _validator;

        public BookService(BookRepository repository, DescriptionValidator validator)
        {
            _repository = repository;
            _validator = validator;
        }

        public List<Book> GetAll() => _repository.GetAll();

        public Book? GetById(int id) => _repository.GetById(id);

        public bool Add(Book book)
        {
            if (!_validator.IsValid(book.Description))
                return false;

            _repository.Add(book);
            return true;
        }

        public bool Update(int id, Book updatedBook)
        {
            var book = _repository.GetById(id);
            if (book == null) return false;

            if (!_validator.IsValid(updatedBook.Description))
                return false;

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Year = updatedBook.Year;
            book.Description = updatedBook.Description;

            _repository.Update(book);
            return true;
        }

        public bool Delete(int id)
        {
            var book = _repository.GetById(id);
            if (book == null) return false;

            _repository.Delete(book);
            return true;
        }
    }
}
