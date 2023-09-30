using Minimal_API.Models;
using Minimal_API.Models.DTOs;

namespace Web_Book.Services
{
	public interface IBookService
	{
		Task<T> GetAll<T>();
		Task<T> GetById<T>(int id);
		Task<T> AddBookAsync<T>(BookDTO bookDTO);
		Task<T> UpdateBookAsync<T>(BookDTO bookDTO);
		Task<T> DeleteBookAsync<T>(int id);
	}
}
