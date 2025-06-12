using Dapper;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
       

    {
        private readonly Context _context;
        public ProductRepository(Context context)
        {
            _context = context;
        }

		public async Task CreateProduct(CreateProductDto createProductDto)
		{
            string query = "insert into Product (Title,Price,City,District,CoverImage,Type,Description,Address,DealOfTheDay,AdvertisementDate,ProductStatus,ProductCategory,EmployeeID) values" +
                " (@title,@price,@city,@district,@coverImage,@type,@description,@address,@dealOfTheDay,@advertisementDate,@productStatus,@productCategory,@employeeID)";
            var paramaters = new DynamicParameters();
            paramaters.Add("@title",createProductDto.Title);
            paramaters.Add("@price",createProductDto.Price);
            paramaters.Add("@city",createProductDto.City);
            paramaters.Add("@district",createProductDto.District);
            paramaters.Add("@coverImage",createProductDto.CoverImage);
            paramaters.Add("@type",createProductDto.Type);
            paramaters.Add("@description",createProductDto.Description);
            paramaters.Add("@address",createProductDto.Address);
            paramaters.Add("@dealOfTheDay",createProductDto.DealOfTheDay);
            paramaters.Add("@advertisementDate",createProductDto.AdvertisementDate);
            paramaters.Add("@productStatus",createProductDto.ProductStatus);
            paramaters.Add("@productCategory",createProductDto.ProductCategory);
            paramaters.Add("@employeeID",createProductDto.EmployeeID);
            using (var connection = _context.CrateConnection())
            {
                await connection.ExecuteAsync(query, paramaters);
            }
		}

		public async Task DealOfTheDayStatusFalse(int id)
		{
			string query = "UPDATE Product SET DealOfTheDay = @status WHERE ProductID = @pid";
			var parameters = new DynamicParameters();
			parameters.Add("@pid", id);
			parameters.Add("@status", 0);
			using (var connection = _context.CrateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
		}

		public async Task DealOfTheDayStatusTrue(int id)
		{
			string query = "UPDATE Product SET DealOfTheDay = @status WHERE ProductID = @pid";
			var parameters = new DynamicParameters();
			parameters.Add("@pid", id);
			parameters.Add("@status", 1);			
			using (var connection = _context.CrateConnection())
			{
				await connection.ExecuteAsync(query, parameters);
			}
		}

		public async Task<List<ResultProductDto>> GetAllProduct()
        {
            string query = "select * from Product";
            using (var connection = _context.CrateConnection())
            {
                var value= await connection.QueryAsync<ResultProductDto>(query);
                return value.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory()
        {
            string query = "select ProductID,SlugUrl,Title,Price,City,District,CategoryName,DealOfTheDay,CoverImage,Address,Type from Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CrateConnection())
            {
                var value= await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return value.ToList();
            }
        }

		public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByFalse(int id)
		{
			string query = "select ProductID ,Title,Price,City,District,CategoryName,DealOfTheDay,CoverImage,Address,Type from Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeId=@id and ProductStatus=0";
			var paramaters = new DynamicParameters();
			paramaters.Add("@id", id);
			using (var connection = _context.CrateConnection())
			{
				var value = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, paramaters);
				return value.ToList();
			}
		}

		public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByTrue(int id)
        {
            string query = "select ProductID ,Title,Price,City,District,CategoryName,DealOfTheDay,CoverImage,Address,Type from Product inner join Category on Product.ProductCategory=Category.CategoryID where EmployeeId=@id and ProductStatus=1";
            var paramaters = new DynamicParameters();
            paramaters.Add("@id", id);
            using (var connection = _context.CrateConnection())
            {
                var value = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query,paramaters);
                return value.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategory()
        {
            string query = "select ProductID ,Title,Price,City,District,CategoryName,DealOfTheDay,CoverImage,Address,Type from Product inner join Category on Product.ProductCategory=Category.CategoryID where DealOfTheDay=1";
            using (var connection = _context.CrateConnection())
            {
                var value = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return value.ToList();
            }
        }

        public async Task<GetProductByProductIdDto> GetProductByProductId(int id)
        {
            string query = "select ProductID ,Title,SlugUrl,Price,City,District,AdvertisementDate,CategoryName,DealOfTheDay,CoverImage,Description,Address,Type from Product inner join Category on Product.ProductCategory=Category.CategoryID where ProductID=@id";
            var paramaters = new DynamicParameters();
            paramaters.Add("@id",id);
            using (var connection = _context.CrateConnection())
            {
                var value = await connection.QueryAsync<GetProductByProductIdDto>(query,paramaters);
                return value.FirstOrDefault();
            }
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id)
        {
            string query = "Select * from ProductDetails where ProductID=@id";
            var paramaters = new DynamicParameters();
            paramaters.Add("@id", id);
            using (var connection = _context.CrateConnection())
            {
                var value = await connection.QueryAsync<GetProductDetailByIdDto>(query, paramaters);
                return value.FirstOrDefault();
            }
        }

		public async Task<List<ResultLast3ProductWithCategoryDto>> GetResultLast3Product()
		{
			string query = "select top(3) ProductID ,Title,Price,City,District,Description,ProductCategory,CategoryName ,CoverImage,AdvertisementDate from Product inner join Category on Category.CategoryID=Product.ProductCategory  order by ProductID desc";
			using (var connection = _context.CrateConnection())
			{
				var values = await connection.QueryAsync<ResultLast3ProductWithCategoryDto>(query);
				return values.ToList();
			}
		}

		public async Task<List<ResultLast5ProductWithCategoryDto>> GetResultLast5Product()
		{
            string query = "select top(5) ProductID ,Title,Price,City,District,ProductCategory,CategoryName ,AdvertisementDate from Product inner join Category on Category.CategoryID=Product.ProductCategory where type ='kiralık' order by ProductID desc";
            using (var connection = _context.CrateConnection())
            {
                var values= await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
		}

        public async Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            string query = "select * from product where Title like '%"+searchKeyValue+"%' and ProductCategory=@productCategory and City=@city";
            var paramaters = new DynamicParameters();
           /* paramaters.Add("@searchKeyValue", searchKeyValue)*/;
            paramaters.Add("@productCategory", propertyCategoryId);
            paramaters.Add("@city", city);
            using (var connection = _context.CrateConnection())
            {
                var value = await connection.QueryAsync<ResultProductWithSearchListDto>(query, paramaters);
                return value.ToList();
            }
        }
    }
}
