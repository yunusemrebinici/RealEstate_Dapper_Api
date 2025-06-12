using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context _context;

        public CategoryRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateCategory(CreateCategoryDto categoryDto)
        {
            string query = "insert into Category (CategoryName,CategoryStatus) values (@categoryName,@categoryStatus)";
            var paramaters = new DynamicParameters();        
                paramaters.Add("@categoryName",categoryDto.CategoryName);
                paramaters.Add("@categoryStatus",true);
            using (var connection = _context.CrateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
            

        }

        public async Task DeleteCategory(int id)
        {
            string query = "Delete from Category where CategoryID=@categoryId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryId", id);
            using (var connection = _context.CrateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
        }

        public async Task<List<ResultCategoryDto>> GetAllCategory()
        {
            string query = "Select * from Category";
            using (var connection = _context.CrateConnection())
            {
                var values = await connection.QueryAsync<ResultCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdCetegoryDto> GetByIdCategory(int id)
        {
            string query = "select * from Category where CategoryID=@categoryId";
            var paramaters= new DynamicParameters();
            paramaters.Add("@categoryId", id);
            using (var connection = _context.CrateConnection())
            {
                var values= await connection.QueryFirstOrDefaultAsync<GetByIdCetegoryDto>(query,paramaters);
                return values;
              
            }

        }

        public async Task UpdateCategory(UpdateCategoryDto categoryDto)
        {
            string query = "update Category set CategoryName=@categoryName , CategoryStatus=@categoryStatus where CategoryID=@categoryId";
            var paramaters = new DynamicParameters();
            paramaters.Add("@categoryId",categoryDto.CategoryID);
            paramaters.Add("@categoryName", categoryDto.CategoryName);
            paramaters.Add("@categoryStatus", true);
            using (var connection = _context.CrateConnection())
            {
               await connection.ExecuteAsync(query, paramaters);
            }
        }
    }
}
