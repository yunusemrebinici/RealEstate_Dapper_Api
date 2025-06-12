using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Net.Http;

namespace RealEstate_Dapper_Api.Hubs
{
	public class SignalRHub:Hub
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SignalRHub(IHttpClientFactory clientFactory)
		{
			_httpClientFactory = clientFactory;
		}

		public async Task SendCategoryCount()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44388/api/Statistics/CategoryCount");
		
			var values = await responseMessage.Content.ReadAsStringAsync();
			await Clients.All.SendAsync("ReceiveCategoryCount", values);

		}
	}
}
