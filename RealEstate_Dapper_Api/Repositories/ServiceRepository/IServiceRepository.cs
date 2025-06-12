using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public interface IServiceRepository
    {
        Task<List<ResultServiceDto>> GetAllServiceAsync();

        Task CreateService(CreateServiceDto serviceDto);

        Task DeleteService(int id);

        Task UpdateService(UpdateServiceDto serviceDto);

        Task<GetByIDServiceDto> GetByIdService(int id);
    }
}
