using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.AppUserRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppUserController : ControllerBase
	{
		private readonly IAppUserRepository _appUserRepository;

		public AppUserController(IAppUserRepository appUserRepository) 
		{
			_appUserRepository = appUserRepository;
		}
		[HttpGet]
		public async Task<IActionResult> GetCategory(int id)
		{
			var values = await _appUserRepository.GetCategory(id);
			return Ok(values);
		}

	}
}
