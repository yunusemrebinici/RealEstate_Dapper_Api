using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Repositories.BottomGridRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BottomGridsController : ControllerBase
    {
        private readonly IBottomGridRepository _bottomGridRepository;

        public BottomGridsController(IBottomGridRepository bottomGridRepository)
        {
            _bottomGridRepository = bottomGridRepository;
        }

        [HttpGet]
        public async Task<IActionResult> BottomGridList()
        {
            var values = await _bottomGridRepository.GetAllBottomGridAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            await _bottomGridRepository.CreateBottomGrid(createBottomGridDto);
            return Ok("Kategori Başarılı bir şekilde eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBottomGrid(int id)
        {
			await _bottomGridRepository.DeleteBottomGrid(id);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateBottomGridDto updateBottomGridDto)
        {
			await _bottomGridRepository.UpdaterBottomGrid(updateBottomGridDto);
            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var values = await _bottomGridRepository.GetBottomGrid(id);
            return Ok(values);
        }
    }
}
