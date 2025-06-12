using Dapper;
using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
	public class PopularLocationRepository : IPopularLocationRepository
	{
		Context _context;

		public PopularLocationRepository(Context context)
		{
			_context = context;
		}

		public async Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
		{
			var query = "insert into PopularLocation (CityName,ImageUrl) values (@cityName,@imgUrl)";
			var paramaters = new DynamicParameters();
			paramaters.Add("@cityName", createPopularLocationDto.CityName);
			paramaters.Add("@imgUrl", createPopularLocationDto.ImageUrl);
			using (var connection = _context.CrateConnection())
			{
				await connection.ExecuteAsync(query,paramaters);
			}

		}

		public async Task DeletePopularLocation(int id)
		{
			var query = "Delete from PopularLocation where LocationID =@id";
			var paramaters = new DynamicParameters();
			paramaters.Add("@id", id);
			using (var connection = _context.CrateConnection())
			{
				await connection.ExecuteAsync(query, paramaters);
			}
			

		}

		public async Task<List<ResultPopularLocationDto>> GetAllPopularLocation()
		{
			string query = "select * from PopularLocation";
			using (var connection =  _context.CrateConnection())
			{
				var value= await connection.QueryAsync<ResultPopularLocationDto>(query);
				return value.ToList();
			}
						
		}

		public async Task<GetByIdPopularLocationDto> GetByIdPopularLocation(int id)
		{
			string query = "select * from PopularLocation where LocationID =@id";
			var paramaters = new DynamicParameters();
			paramaters.Add("@id", id);
			using (var connection = _context.CrateConnection())
			{
				var values= await connection.QueryFirstOrDefaultAsync<GetByIdPopularLocationDto>(query,paramaters);
				return values;
			}
		}
	
		public async Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
		{
			string query = "Update PopularLocation  set  CityName=@cityName,ImageUrl=@imgUrl where LocationID =@id";
			var paramaters = new DynamicParameters();
			paramaters.Add("@id", updatePopularLocationDto.LocationID);
			paramaters.Add("@cityName", updatePopularLocationDto.CityName);
			paramaters.Add("@imgUrl", updatePopularLocationDto.ImageUrl);
			using (var connection = _context.CrateConnection())
			{

				await connection.ExecuteAsync(query, paramaters);
			}
		}
	}
}
