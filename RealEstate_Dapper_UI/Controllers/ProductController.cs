﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using System.Text;

namespace RealEstate_Dapper_UI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task< IActionResult> Index()
		{
			var client =_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44388/api/Product/GetAllWithCategoryName");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateProduct()
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44388/api/Categories");
			
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

			List<SelectListItem> categoryValues = (from x in values.ToList()
												   select new SelectListItem
												   {
													   Text = x.CategoryName,
													   Value = x.CategoryID.ToString()
												   }
												 ).ToList();
			ViewBag.v=categoryValues;
			
			return View();
		}

		
		public async Task<IActionResult> DealOfTheDayStatusFalse(int id)
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44388/api/Product/DealOfTheDayStatusFalse/{id}" );
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DealOfTheDayStatusTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44388/api/Product/DealOfTheDayStatusTrue/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
