using RealEstate_Dapper_Api.Dtos.PopularLocationDtos;

namespace RealEstate_Dapper_Api.Repositories.PopularLocationRepositories
{
	public interface IPopularLocationRepository
	{
		Task<List<ResultPopularLocationDto>> GetAllPopularLocation();

		Task  DeletePopularLocation(int id);

		Task UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto);

		Task CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto);

		Task <GetByIdPopularLocationDto> GetByIdPopularLocation(int id);
		
	}
}
