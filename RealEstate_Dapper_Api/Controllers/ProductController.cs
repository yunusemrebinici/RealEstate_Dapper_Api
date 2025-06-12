using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Repositories.ProductRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var value = await _productRepository.GetAllProduct();
            return Ok(value);
        }
        [HttpGet("GetAllWithCategoryName")]
        public async Task<IActionResult> GetAllWithCategoryNameAsync()
        {
            var values= await _productRepository.GetAllProductWithCategory();
            return Ok(values);
        }

		[HttpGet("DealOfTheDayStatusFalse/{id}")]
		public async Task<IActionResult> DealOfTheDayStatusFalse(int id)
		{
			await  _productRepository.DealOfTheDayStatusFalse(id);
			return Ok("Pasif işlemi başarılı");
		}
		[HttpGet("DealOfTheDayStatusTrue/{id}")]
		public async Task<IActionResult> DealOfTheDayStatusTrue(int id)
		{
			await _productRepository.DealOfTheDayStatusTrue(id);
			return Ok("Aktif işlemi başarılı");
		}
        [HttpGet("GetResultLast5Product")]
        public async Task<IActionResult> GetResultLast5ProductAsync()
        {
            var values = await _productRepository.GetResultLast5Product();
            return Ok(values);
        }
        [HttpGet("GetProductAdvertListByEmployeeByTrue")]
        public async Task<IActionResult> GetProductAdvertListByEmployeeByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertListByEmployeeByTrue( id);
            return Ok(values);
        }
		[HttpGet("GetProductAdvertListByEmployeeByFalse")]
		public async Task<IActionResult> GetProductAdvertListByEmployeeAsyncByFalse(int id)
		{
			var values = await _productRepository.GetProductAdvertListByEmployeeByFalse(id);
			return Ok(values);
		}
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProduct)
        {
            await _productRepository.CreateProduct(createProduct);
            return Ok("Ekleme Başarılı");    
        }
        [HttpGet("GetProductByProductId")]
        public async Task<IActionResult> GetProductByProductId(int id)
        {
            var values = await _productRepository.GetProductByProductId(id);
            return Ok(values);
        }
        [HttpGet("GetProductDetailByProductId")]
        public async Task<IActionResult> GetProductDetailByProductId(int id)
        {
            var values = await _productRepository.GetProductDetailByProductId(id);
            return Ok(values);
        }
        [HttpGet("ResultProductWithSearchList")]
        public async Task<IActionResult> ResultProductWithSearchList(string searchKeyValue, int propertyCategoryId, string city)
        {
            var values = await _productRepository.ResultProductWithSearchList(searchKeyValue,propertyCategoryId,city);
            return Ok(values);
        } 
        
        [HttpGet("GetProductByDealOfTheDayTrueWithCategory")]
        public async Task<IActionResult> GetProductByDealOfTheDayTrueWithCategory()
        {
            var values = await _productRepository.GetProductByDealOfTheDayTrueWithCategory();
            return Ok(values);
        }

        [HttpGet("GetResultLast3Product")]
        public async Task<IActionResult> GetResultLast3Product()
        {
            var values = await _productRepository.GetResultLast3Product();
            return Ok(values);
        }
    }
}
