using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductRepositories
{
    public class Last5ProductRepository : ILast5ProductRepository
    {
        private readonly Context _context;
        
        public Last5ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5Product(int id)
        {
            string query = "select Top(5) ProductID,Title,Price,City,District,CategoryName,AdvertisementDate from Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeID=@employeeId order by ProductID desc";
            var paramaters = new DynamicParameters();
            paramaters.Add("@employeeId", id);
            using (var connect=_context.CrateConnection())
            {
                var values = await connect.QueryAsync<ResultLast5ProductWithCategoryDto>(query,paramaters);
                return values.ToList();
            }
        }
    }
}
