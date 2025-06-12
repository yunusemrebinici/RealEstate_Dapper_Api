using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }



        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var value = await _serviceRepository.GetAllServiceAsync();
            return Ok(value);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdServiceList(int id)
        {
            var value= await _serviceRepository.GetByIdService(id);
            return Ok(value);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult>DeleteService(int id)
        {
            await  _serviceRepository.DeleteService(id);
            return Ok("Silme İşlemi Başarılı");
           
        }

        [HttpPut]
        public async Task<IActionResult>UpdateService(UpdateServiceDto updateService)
        {
           await  _serviceRepository.UpdateService(updateService);
            return Ok("Güncelleme Başarılı");
        }

        [HttpPost]
        public async Task<IActionResult>CreateService(CreateServiceDto createServiceDto)
        {
          await   _serviceRepository.CreateService(createServiceDto);
            return Ok("İşlem Başarılı");
        }
    }
}
