﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.AppUserDtos;

namespace RealEstate_Dapper_UI.ViewComponents.PropertySingle
{
	public class _PropertyAppUserComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _PropertyAppUserComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44388/api/AppUser?id=1");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<GetAppUserByProductIdDto>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
