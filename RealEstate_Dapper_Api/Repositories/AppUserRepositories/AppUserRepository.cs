using Dapper;
using RealEstate_Dapper_Api.Dtos.AppUserDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.AppUserRepositories
{
	public class AppUserRepository : IAppUserRepository
	{
		private readonly Context _context;

		public AppUserRepository(Context context)
		{
			_context = context;
		}

		public async Task<GetAppUserByProductIdDto> GetCategory(int id)
		{
			string query = "Select * from AppUser where UserId=@id ";
			var paramaters = new DynamicParameters();
			paramaters.Add("@id", id);
			using (var connection = _context.CrateConnection())
			{
				var values = await connection.QueryAsync<GetAppUserByProductIdDto>(query, paramaters);
				return values.FirstOrDefault();
			}
		}
	}
}
