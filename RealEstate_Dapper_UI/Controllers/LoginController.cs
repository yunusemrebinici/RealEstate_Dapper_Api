﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_Api.Dtos.LoginDtos;
using RealEstate_Dapper_UI.Models;
using RealEstate_Dapper_UI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace RealEstate_Dapper_UI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		

       

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
           
        }

		[HttpGet]
        public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult>Index(CreateLoginDto createLoginDto)
		{
			var client = _httpClientFactory.CreateClient();
			var content =new StringContent(JsonConvert.SerializeObject(createLoginDto), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:44388/api/Login", content);
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				
				var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JwtResponseModel>(jsonData,new JsonSerializerOptions
				{
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase

                });
            
                if (tokenModel!=null)
				{
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
					var token = handler.ReadJwtToken(tokenModel.Token);
					var claims = token.Claims.ToList();

					if (tokenModel.Token !=null)
					{
						claims.Add(new Claim("realestatetoken", tokenModel.Token));
						var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
						var authProperties = new AuthenticationProperties
						{
							ExpiresUtc = tokenModel.ExpireDate,
							IsPersistent = true
						};
						await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
						return RedirectToAction("Index", "Employee");
                    }
					else
					{
						return RedirectToAction("Index", "Login");
					}
                }
            }
			return View();
        }
	}
}
