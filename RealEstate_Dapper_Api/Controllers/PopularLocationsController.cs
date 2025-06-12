﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Repositories.PopularLocationRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PopularLocationsController : ControllerBase
	{
		private readonly IPopularLocationRepository _popularLocationRepository;

		public PopularLocationsController (IPopularLocationRepository popularLocationRepository)
		{
			 _popularLocationRepository = popularLocationRepository;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllPopularResult()
		{
			var value = await _popularLocationRepository.GetAllPopularLocation();
			return Ok(value);	
		}

		[HttpPost]
		public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
		{
			 await  _popularLocationRepository.CreatePopularLocation(createPopularLocationDto);

			   return Ok("Ekleme İşlemi Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task <IActionResult> DeletePopularLocation(int id)
		{
			 await _popularLocationRepository.DeletePopularLocation(id);

			return Ok("Silme İşlemi Başarılı");
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetByIdPopularLocationAsync(int id)
		{
			var values = await _popularLocationRepository.GetByIdPopularLocation(id);
			return Ok(values);
		}

		[HttpPut]
		public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
		{
			await _popularLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
			return Ok("Güncelleme İşlemi Başarılı");
		}
	}
}
