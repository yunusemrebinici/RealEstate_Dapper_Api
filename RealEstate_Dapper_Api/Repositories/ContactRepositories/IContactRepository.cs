using RealEstate_Dapper_Api.Dtos.ContactDtos;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
	public interface IContactRepository
	{
		Task<List<ResultContactDto>> GetAllContact();

		Task<GetByIdContactDto> GetContact(int id);

		Task<List<Last4ContactResultDto>> GetLast4Contact();

		Task CreateContact(CreateContactDto createContactDto);

		Task DeleteContaact(int id);


	}
}
