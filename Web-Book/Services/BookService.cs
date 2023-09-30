using Minimal_API.Models;
using Minimal_API.Models.DTOs;

namespace Web_Book.Services
{
	public class BookService : BaseService, IBookService
	{
		private readonly IHttpClientFactory clientfactory;

        public BookService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
			clientfactory = clientFactory;
        }

        public async Task<T> AddBookAsync<T>(BookDTO bookDTO)
		{
			return await this.SendAsync<T>(new Models.ApiRequest
			{
				ApiType = StaticDetails.ApiType.POST,
				Data = bookDTO,
				Url = StaticDetails.WebApiBase + "/api/book",
				AccessToken = ""
			});
		}

		public async Task<T> DeleteBookAsync<T>(int id)
		{
			return await this.SendAsync<T>(new Models.ApiRequest
			{
				ApiType = StaticDetails.ApiType.DELETE,
				Url = StaticDetails.WebApiBase + "/api/book/" + id,
				AccessToken = ""
			});
		}

		public async Task<T> GetAll<T>()
		{
			return await this.SendAsync<T>(new Models.ApiRequest
			{
				ApiType = StaticDetails.ApiType.GET,
				Url = StaticDetails.WebApiBase + "/api/book",
				AccessToken = ""
			});
		}

		public async Task<T> GetById<T>(int id)
		{
			return await this.SendAsync<T>(new Models.ApiRequest
			{
				ApiType = StaticDetails.ApiType.GET,
				Url = StaticDetails.WebApiBase + "/api/book/" + id,
				AccessToken = ""
			});
		}

		public async Task<T> UpdateBookAsync<T>(BookDTO bookDTO)
		{
			return await this.SendAsync<T>(new Models.ApiRequest
			{
				ApiType = StaticDetails.ApiType.PUT,
				Data = bookDTO,
				Url = StaticDetails.WebApiBase + "/api/book",
				AccessToken = ""
			});
		}
	}
}
