using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.BottomGridDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.BottomGridRepositories
{
    public class BottomGridRepository : IBottomGridRepository
    {
        private readonly Context _context;

        public BottomGridRepository(Context context) 
        {
            _context = context;
        }

        public async Task CreateBottomGrid(CreateBottomGridDto createBottomGridDto)
        {
            string query = "insert into BottomGrid (Icon,Title,Description) values (@icon,@title,@description)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@icon", createBottomGridDto.Icon);
            paramaters.Add("@title", createBottomGridDto.Title);
            paramaters.Add("@description", createBottomGridDto.Description);
            using (var connection = _context.CrateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task DeleteBottomGrid(int id)
        {
            string query = "Delete from BottomGrid where BottomGridID=@id";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CrateConnection())
            {
                var values = await connection.ExecuteAsync(query, parameters);
                
            }
        }

        public async Task<List<ResultBottomGridDto>> GetAllBottomGridAsync()
        {
            string query = "select * from BottomGrid ";
            using (var connection = _context.CrateConnection())
            {
                var values= await connection.QueryAsync<ResultBottomGridDto>(query);
                return values.ToList(); 
            }
        }

        public async Task<GetBottomGridDto> GetBottomGrid(int id)
        {
            string query = "select * from BottomGrid where BottomGridID=@id ";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CrateConnection())
            {
                var values = connection.QueryFirstOrDefault<GetBottomGridDto>(query,parameters);
                return values;
            }
        }

        public async Task UpdaterBottomGrid(UpdateBottomGridDto updateBottomGridDto)
        {
            string query = "update BottomGrid set Icon=@icon,Title=@title,Description=@description where BottomGridID=@id";
            var paramaters = new DynamicParameters();
            paramaters.Add("@id", updateBottomGridDto.BottomGridID);
            paramaters.Add("@icon", updateBottomGridDto.Icon);
            paramaters.Add("@title", updateBottomGridDto.Title);
            paramaters.Add("@description", updateBottomGridDto.Description);
            using (var connection = _context.CrateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
