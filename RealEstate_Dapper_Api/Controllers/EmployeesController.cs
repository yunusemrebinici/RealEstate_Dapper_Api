using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeRepository _employeeRepository;

		public EmployeesController(IEmployeeRepository employeeRepository)
		{
			_employeeRepository = employeeRepository;
		}

		[HttpGet]
		public async Task<IActionResult> EmployeeList()
		{
			var values = await _employeeRepository.GetAllEmployee();

			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var values = await _employeeRepository.GetByIdEmployee(id);
			return Ok(values);
		}

		[HttpPost]
		public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
		{
			await _employeeRepository.CreateEmployee(createEmployeeDto);	
			return Ok("Ekleme İşlemi Başarılı");
		}

		[HttpPut]
		public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
		{
			await _employeeRepository.UpdateEmployee(updateEmployeeDto);
			return Ok("Güncelleme Başarılı");
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteEmployee(int id)
		{
			await _employeeRepository.DeleteEmployee(id);
			return Ok("Silme Başarılı");
		}
	}
}
