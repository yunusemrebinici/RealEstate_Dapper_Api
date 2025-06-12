using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.WhoWeAreRepository
{
    public class WhoWeAreDetailRepository : IWhoWeAreDetailRepository

    {
        private readonly Context _context;

        public WhoWeAreDetailRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetailDto)
        {
            string query = "insert into WhoWeAreDetail (Title,SubTitle,Description1,Description2) values (@title,@subtitle,@description1,@description2)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@title", createWhoWeAreDetailDto.Title);
            paramaters.Add("@subtitle", createWhoWeAreDetailDto.SubTitle);
            paramaters.Add("@description1", createWhoWeAreDetailDto.Description1);
            paramaters.Add("@description2", createWhoWeAreDetailDto.Description2);
            using (var connection = _context.CrateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }

        }

        public async Task DeleteWhoWeAreDetail(int id)
        {
            string query = "Delete from WhoWeAreDetail where WhoWeAreDetailID=@whowearedetailID";
            var paramaters = new DynamicParameters();
            paramaters.Add("whowearedetailID", id);
            using (var connection = _context.CrateConnection())
            {
                await connection.QueryAsync(query, paramaters);
            }
          
        }

        public async Task<List<ResultWhoWeAreDetailDto>> GetAllWhoWeAreDetail()
        {
            string query = "Select * from WhoWeAreDetail";
            using (var connection=_context.CrateConnection())
            {
                var values= await connection.QueryAsync<ResultWhoWeAreDetailDto>(query);

                return values.ToList();
            }
        }

        public async Task<GetByIDWhoWeAreDetailDto> GetWhoWeAreDetail(int id)
        {
            string query = "select * from WhoWeAreDetail where WhoWeAreDetailID=@ID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@ID", id);
            using (var connection = _context.CrateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<GetByIDWhoWeAreDetailDto>(query, paramaters);

                return values;
            }
        }

        public async Task UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            string query = "update WhoWeAreDetail set Title=@title , SubTitle=@subtitle ,Description1=@description1 ,Description2=@description2 where WhoWeAreDetailID=@whoweareID";
            var paramaters = new DynamicParameters();
            paramaters.Add("@whoweareID", updateWhoWeAreDetailDto.WhoWeAreDetailID);
            paramaters.Add("@title", updateWhoWeAreDetailDto.Title);
            paramaters.Add("@subtitle", updateWhoWeAreDetailDto.SubTitle);
            paramaters.Add("@description1", updateWhoWeAreDetailDto.Description1);
            paramaters.Add("@description2", updateWhoWeAreDetailDto.Description2);
            using (var connection = _context.CrateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
