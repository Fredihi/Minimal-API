using Newtonsoft.Json;
using System.Text;
using Web_Book.Models;

namespace Web_Book.Services
{
	public class BaseService : IBaseService
	{
		public ResponseDTO responseModel { get; set; }

		public IHttpClientFactory httpClient { get; set; }


		public BaseService(IHttpClientFactory _httpClient)
        {
            this.httpClient = _httpClient;
			this.responseModel = new ResponseDTO();
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
		{
			try
			{
				var client = httpClient.CreateClient("BookApi");
				HttpRequestMessage message = new HttpRequestMessage();
				message.Headers.Add("Accept", "application/json");
				message.RequestUri = new Uri(apiRequest.Url);
				client.DefaultRequestHeaders.Clear();
				if (apiRequest.Data != null)
				{
					message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
				}

				HttpResponseMessage apiResp = null;
				switch (apiRequest.ApiType)
				{
					case StaticDetails.ApiType.GET:
						message.Method = HttpMethod.Get;
						break;
					case StaticDetails.ApiType.POST:
						message.Method = HttpMethod.Post;
						break;
					case StaticDetails.ApiType.PUT:
						message.Method = HttpMethod.Put;
						break;
					case StaticDetails.ApiType.DELETE:
						message.Method = HttpMethod.Delete;
						break;
				}
				apiResp = await client.SendAsync(message);

				var apiContent = await apiResp.Content.ReadAsStringAsync();
				var apiResponseDTO = JsonConvert.DeserializeObject<T>(apiContent);
				return apiResponseDTO;
			}
			catch (Exception e)
			{

				var dto = new ResponseDTO
				{
					DisplayMessage = "Error",
					ErrorMessage = new List<string> { Convert.ToString(e.Message) },
					IsSuccess = false
				};
				var res = JsonConvert.SerializeObject(dto);
				var apiResponseDTO = JsonConvert.DeserializeObject<T>(res);
				return apiResponseDTO;
			}
		}

		public void Dispose()
		{
			GC.SuppressFinalize(true);
		}
	}
}
