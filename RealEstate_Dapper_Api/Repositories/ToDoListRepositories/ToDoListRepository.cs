using Dapper;
using RealEstate_Dapper_Api.Dtos.ToDoListDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
	public class ToDoListRepository : IToDoListRepository
	{
		private readonly Context _context;
		public ToDoListRepository(Context context)
		{
			_context = context;
		}

		public  async Task CreateToDoList(CreateToDoListDto createToDoListDto)
		{
			string query = "insert into ToDoList  (Description,ToDoListStatus) values (@description,@status)";
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@description", createToDoListDto.Description);		
			parameters.Add("@status", true);
			using (var connection = _context.CrateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task DeleteToDoList(int id)
		{
			var query = "delete from ToDoList where ToDoListID=@id";
			DynamicParameters parameters = new DynamicParameters();
			parameters.Add("@id", id);
			using (var connection = _context.CrateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultToDoListDto>> GetAllToDoList()
		{
			var query = "Select * from ToDoList";
			using (var connectin = _context.CrateConnection())
			{
				var values = await connectin.QueryAsync<ResultToDoListDto>(query);
				return values.ToList();
			}
		}

		public async Task<GetByIDToDoListDto> GetToDoList(int id)
		{

			var query = "select * from ToDoList where ToDoListID=@id";
			var parameters = new DynamicParameters();
			parameters.Add("@id", id);
			using (var connection = _context.CrateConnection())
			{
				var values = await connection.QueryFirstOrDefaultAsync<GetByIDToDoListDto>(query, parameters);
				return values;
			}
		}
	}
}
