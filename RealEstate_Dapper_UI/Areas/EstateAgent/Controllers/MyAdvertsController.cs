﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.CategoryDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;
using RealEstate_Dapper_UI.Services;
using System.Text;

namespace RealEstate_Dapper_UI.Areas.EstateAgent.Controllers
{
	[Area("EstateAgent")]
	public class MyAdvertsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

		public MyAdvertsController(IHttpClientFactory httpClientFactory,ILoginService loginService)
        {
            _loginService = loginService;
            _httpClientFactory = httpClientFactory;
        }

       
        public async Task< IActionResult> ActiveAdverts()
		{
            var id = _loginService.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Product/GetProductAdvertListByEmployeeAsyncByTrue?id="+id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }

		public async Task<IActionResult> PassiveAdverts()
		{
			var id = _loginService.GetUserId;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44388/api/Product/GetProductAdvertListByEmployeeAsyncByFalse?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductAdvertListWithCategoryByEmployeeDto>>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> CreateAdvert()
		{
			var client = _httpClientFactory.CreateClient();
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
			ViewBag.v = categoryValues;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAdvert(CreateProductDto createProductDto)
		{
			var id = _loginService.GetUserId;
			createProductDto.EmployeeID = int.Parse(id);
			createProductDto.DealOfTheDay = false;
			createProductDto.ProductStatus = true;
			createProductDto.AdvertisementDate = DateTime.Now;

			var client =_httpClientFactory.CreateClient();
			var jsonData=JsonConvert.SerializeObject(createProductDto);
			var content= new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:44388/api/Product/CreateProduct", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			return View();
		}
	}
}
