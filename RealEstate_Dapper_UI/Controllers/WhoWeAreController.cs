using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.WhoWeAreDetailDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
	public class WhoWeAreController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public WhoWeAreController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44388/api/WhoWeAreDetail");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values =JsonConvert.DeserializeObject<List<ResultWhoWeAreDetailDtos>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public  IActionResult CreateWhoWeAre()
		{
			return View();
		}
		

		[HttpPost]
		public async Task<IActionResult> CreateWhoWeAre(CreateWhoWeAreDto createWhoWeAreDto)
		{
			var client= _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createWhoWeAreDto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:44388/api/WhoWeAreDetail", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateWhoWeAre(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44388/api/WhoWeAreDetail/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
				var jsonData= await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateWhoWeAreDto>(jsonData);
				return View(values);
            }
            return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateWhoWeAre(UpdateWhoWeAreDto updateWhoWeAreDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateWhoWeAreDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44388/api/WhoWeAreDetail", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			
			return View();
		}

		public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44388/api/WhoWeAreDetail/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
