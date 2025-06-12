using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.StatisticsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StatisticsController : ControllerBase
	{
		private readonly IStatisticsRepository _statisticsRepository;

		public StatisticsController (IStatisticsRepository statisticsRepository)
		{
			_statisticsRepository = statisticsRepository;
		}

		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			var values = _statisticsRepository.ActiveCategoryCount();
			return Ok(values);
		}

		[HttpGet("ActiveEmployeeCount")]
		public IActionResult ActiveEmployeeCount()
		{
			var values = _statisticsRepository.ActiveEmployeeCount();
			return Ok(values);
		}

		[HttpGet("ApartmentCount")]
		public IActionResult ApartmentCount()
		{
			var values = _statisticsRepository.ApartmentCount();
			return Ok(values);
		}

		[HttpGet("AvarageProductPriceByRent")]
		public IActionResult AvarageProductPriceByRent()
		{
			var values = _statisticsRepository.AvarageProductPriceByRent();
			return Ok(values);
		}

		[HttpGet("AvarageProductPriceBySale")]
		public IActionResult AvarageProductPriceBySale()
		{
			var values = _statisticsRepository.AvarageProductPriceBySale();
			return Ok(values);
		}

		[HttpGet("AvarageRoomCount")]
		public IActionResult AvarageRoomCount()
		{
			var values = _statisticsRepository.AvarageRoomCount();
			return Ok(values);
		}


		[HttpGet("CategoryCount")]
		public IActionResult CategoryCount()
		{
			var values = _statisticsRepository.CategoryCount();
			return Ok(values);
		}

		[HttpGet("CategoryNameByMaxProductCount")]
		public IActionResult CategoryNameByMaxProductCount()
		{
			var values = _statisticsRepository.CategoryNameByMaxProductCount();
			return Ok(values);
		}

		[HttpGet("CityNameByMaxProductCount")]
		public IActionResult CityNameByMaxProductCount()
		{
			var values = _statisticsRepository.CityNameByMaxProductCount();
			return Ok(values);
		}


		[HttpGet("DifferentCityCount")]
		public IActionResult DifferentCityCount()
		{
			var values = _statisticsRepository.DifferentCityCount();
			return Ok(values);
		}

		[HttpGet("EmployeeCountByMaxProductCount")]
		public IActionResult EmployeeCountByMaxProductCount()
		{
			var values = _statisticsRepository.EmployeeCountByMaxProductCount();
			return Ok(values);
		}

		[HttpGet("LastProductPrice")]
		public IActionResult LastProductPrice()
		{
			var values = _statisticsRepository.LastProductPrice();
			return Ok(values);
		}

		[HttpGet("NewsBuildingYear")]
		public IActionResult NewsBuildingYear()
		{
			var values = _statisticsRepository.NewsBuildingYear();
			return Ok(values);
		}

		[HttpGet("OldesBuildingYear")]
		public IActionResult OldesBuildingYear()
		{
			var values = _statisticsRepository.OldesBuildingYear();
			return Ok(values);
		}

		[HttpGet("PassiveCategoryCount")]
		public IActionResult PassiveCategoryCount()
		{
			var values = _statisticsRepository.PassiveCategoryCount();
			return Ok(values);
		}

		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			var values = _statisticsRepository.ProductCount();
			return Ok(values);
		}


	}
}
