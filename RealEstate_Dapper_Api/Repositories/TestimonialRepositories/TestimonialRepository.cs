using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
	public class TestimonialRepository : ITestimonialRepository

	{
		private readonly Context _context;

		public TestimonialRepository(Context context)
		{
			_context = context;
		}

		public async Task<List<ResultTestimonialDto>> GetAllTestimonial()
		{
			var query = "select * from Testimonial";
			using (var connection = _context.CrateConnection())
			{
				var values= await connection.QueryAsync<ResultTestimonialDto>(query);
				return values.ToList();
			}
			
		}
	}
}
