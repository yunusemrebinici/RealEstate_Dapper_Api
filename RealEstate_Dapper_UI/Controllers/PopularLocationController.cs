using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.PopularLocationDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
	public class PopularLocationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public PopularLocationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responeMessage = await client.GetAsync("https://localhost:44388/api/PopularLocations");
			if (responeMessage.IsSuccessStatusCode)
			{
				var jsonData= await responeMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultPopularLocationDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdatePopularLocation(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44388/api/PopularLocations/{id}");
			if (responseMessage.IsSuccessStatusCode) 
			{ 
				var jsonData= await responseMessage.Content.ReadAsStringAsync();	
				var values = JsonConvert.DeserializeObject<UpdatePopularLocationDto>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto popularLocationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData= JsonConvert.SerializeObject(popularLocationDto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:44388/api/PopularLocations", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> CreatePopularLocation()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createPopularLocationDto);
			StringContent content= new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:44388/api/PopularLocations", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult>DeletePopularLocation(int id)
		{
			var client= _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44388/api/PopularLocations/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

	}
}
