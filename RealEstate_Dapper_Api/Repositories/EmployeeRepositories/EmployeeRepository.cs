using Dapper;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EmployeeRepositories
{
	public class EmployeeRepository : IEmployeeRepository
	{
		Context _context;

		public EmployeeRepository(Context context)
		{
			_context = context;
		}

		public async Task CreateEmployee(CreateEmployeeDto createEmployeeDto)
		{
			string query = "insert into Employee  (Name,Title,Mail,PhoneNumber,ImageUrl,Status) values (@name,@title,@mail,@phoneNumber,@ImageUrl,@status)";
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@name",createEmployeeDto.Name);
			parameters.Add("@title",createEmployeeDto.Title);
			parameters.Add("@mail",createEmployeeDto.Mail);
			parameters.Add("@phoneNumber",createEmployeeDto.PhoneNumber);
			parameters.Add("@ImageUrl",createEmployeeDto.ImageUrl);
			parameters.Add("@status",true);
			using (var connection = _context.CrateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteEmployee(int id)
		{
			var query = "delete from Employee where EmployeeID=@id";
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@id", id);
			using (var connection = _context.CrateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultEmployeeDto>> GetAllEmployee()
		{
			var query = "Select * from Employee";
			using (var connectin= _context.CrateConnection())
			{
				var values = await connectin.QueryAsync<ResultEmployeeDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIdEmployeeDto> GetByIdEmployee(int id)
		{
			var query = "select * from Employee where EmployeeID=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);
			using (var connection = _context.CrateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIdEmployeeDto>(query,parameters);
				return values;
			}
		}

		public async Task UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
		{
			string query = "update Employee set Name=@name , Title=@title , Mail=@mail ,PhoneNumber=@number , ImageUrl=@url, Status=@status where EmployeeID=@Id";
			var paramaters = new DynamicParameters();
			paramaters.Add("@name", updateEmployeeDto.Name);
			paramaters.Add("@title", updateEmployeeDto.Title);
			paramaters.Add("@mail", updateEmployeeDto.Mail);
			paramaters.Add("@number", updateEmployeeDto.PhoneNumber);
			paramaters.Add("@url", updateEmployeeDto.ImageUrl);
			paramaters.Add("@status", true);
			paramaters.Add("@Id", updateEmployeeDto.EmployeeID);
			using (var connection = _context.CrateConnection())
			{
				await connection.ExecuteAsync(query, paramaters);
			}


		}
	}
}
