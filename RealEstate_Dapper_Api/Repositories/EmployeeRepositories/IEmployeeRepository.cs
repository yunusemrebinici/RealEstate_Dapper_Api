using RealEstate_Dapper_Api.Dtos.EmployeeDtos;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
	public interface IEmployeeRepository
	{
		Task CreateEmployee(CreateEmployeeDto createEmployeeDto);
		
		Task DeleteEmployee(int id);

		Task<List<ResultEmployeeDto>> GetAllEmployee();

		Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto);

		Task<GetByIdEmployeeDto> GetByIdEmployee(int id);

	}
}
