using RealEstate_Dapper_Api.Dtos.ToDoListDtos;

namespace RealEstate_Dapper_Api.Repositories.ToDoListRepositories
{
	public interface IToDoListRepository
	{
		Task<List<ResultToDoListDto>> GetAllToDoList();

		Task<GetByIDToDoListDto> GetToDoList(int id);
	
		Task CreateToDoList(CreateToDoListDto createToDoListDto);

		Task DeleteToDoList(int id);
	}
}
