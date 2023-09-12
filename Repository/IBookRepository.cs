using Minimal_API.Models;

namespace Minimal_API.Repository
{
    public interface IBookRepository<T>
    {
        Task<IEnumerable<Book>> GetAll();
        Task<T> GetById(int id);
        Task<Book> Add(Book book);
        Task<Book> Update(Book book);
        Task<Book> Delete(Book book);

    }
}
