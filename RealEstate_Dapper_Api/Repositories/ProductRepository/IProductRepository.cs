using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProduct();

        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategory();

        Task DealOfTheDayStatusTrue(int id);

        Task DealOfTheDayStatusFalse(int id);

        Task<List<ResultLast5ProductWithCategoryDto>> GetResultLast5Product();

        Task<List<ResultLast3ProductWithCategoryDto>> GetResultLast3Product();

        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByTrue(int id );

        Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeByFalse(int id );

        Task CreateProduct(CreateProductDto createProductDto);

        Task <GetProductByProductIdDto>GetProductByProductId(int id);

        Task <GetProductDetailByIdDto>GetProductDetailByProductId(int id);
       
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string searchKeyValue,int propertyCategoryId,string city);

        Task<List<ResultProductWithCategoryDto>> GetProductByDealOfTheDayTrueWithCategory();
    }
}
