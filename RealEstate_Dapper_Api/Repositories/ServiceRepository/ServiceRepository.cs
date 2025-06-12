using Dapper;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ServiceRepository
{
    public class ServiceRepository : IServiceRepository

    {
        private readonly Context _context;

        public ServiceRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateService(CreateServiceDto serviceDto)
        {
            var query = "insert into Service (ServiceName,ServiceStatus) values (@serviceName,@serviceStatus)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@serviceName", serviceDto.ServiceName);
            paramaters.Add("@serviceStatus", true);
            using (var connection=_context.CrateConnection())
            {
                var values= await connection.ExecuteAsync(query, paramaters);
               
            }
        }

        public async Task DeleteService(int id)
        {
            var query = "delete from service where ServiceID=@id";
            var paramaters = new DynamicParameters();
            paramaters.Add("id", id);
            using (var connection = _context.CrateConnection())
            {
                await connection.ExecuteAsync(query,paramaters);
            }
        }

        public async Task<List<ResultServiceDto>> GetAllServiceAsync()
        {
            string query = "select * from Service";
            using (var connection = _context.CrateConnection())
            {
                var value=await connection.QueryAsync<ResultServiceDto>(query);
                return value.ToList();
            }

        }

        public async Task<GetByIDServiceDto> GetByIdService(int id)
        {
            string query = "select * from Service where ServiceID=@id";
            var paramaters = new DynamicParameters();
            paramaters.Add("@id", id);
            using (var connection = _context.CrateConnection())
            {
                var value= await connection.QueryFirstOrDefaultAsync<GetByIDServiceDto>(query, paramaters);
                return value;
            }
        }

        public async Task UpdateService(UpdateServiceDto serviceDto)
        {
            string query = "update Service Set ServiceName=@serviceName,ServiceStatus=@serviceStatus where ServiceID=@id";
            var paramaters=new DynamicParameters();
            paramaters.Add("@serviceName",serviceDto.ServiceName);
            paramaters.Add("@serviceStatus", serviceDto.ServiceStatus);
            paramaters.Add("@id", serviceDto.ServiceID);
            using (var connection = _context.CrateConnection())
            {
                await connection.QueryAsync(query, paramaters);
            }
        }
    }
}
