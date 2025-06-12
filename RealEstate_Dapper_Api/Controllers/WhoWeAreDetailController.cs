using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.CategoryRepository;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _whoweAreRepository;

        public WhoWeAreDetailController(IWhoWeAreDetailRepository whoWeAreRepository)
        {
            _whoweAreRepository= whoWeAreRepository;
        }

        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetaiList()
        {
            var values = await _whoweAreRepository.GetAllWhoWeAreDetail();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDto)
        {
           await  _whoweAreRepository.CreateWhoWeAreDetail(createWhoWeAreDto);
            return Ok("Başarılı bir şekilde eklendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
           await  _whoweAreRepository.DeleteWhoWeAreDetail(id);
            return Ok("Silme İşlemi Başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
          await  _whoweAreRepository.UpdateWhoWeAreDetail(updateWhoWeAreDetailDto);
            return Ok("Güncelleme Başarılı");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _whoweAreRepository.GetWhoWeAreDetail(id);
            return Ok(value);
        }
    }
}
