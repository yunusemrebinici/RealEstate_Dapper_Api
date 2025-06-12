using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductController : ControllerBase
    {
        private readonly ILast5ProductRepository _last5ProductRepository;

        public EstateAgentLastProductController(ILast5ProductRepository last5Product)
        {
            _last5ProductRepository = last5Product;
        }

        [HttpGet]
        public async Task<IActionResult> GetLast5Product(int id)
        {
            var values = await _last5ProductRepository.GetLast5Product(id);
            return Ok(values);
        }
    }
}
