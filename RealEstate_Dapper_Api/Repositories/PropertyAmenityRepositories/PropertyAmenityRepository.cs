using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;
        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenintyByStatusTrue(int id)
        {
            string query = "Select title ,PropertyAmenityId from PropertyAmenity inner join Amenity on PropertyAmenity.AmenityId=Amenity.AmenityId where status =1 and PropertyId=@propertyId";
            var paramaters = new DynamicParameters();
        
            paramaters.Add("@propertyId", id);
            using (var connection = _context.CrateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenityByStatusTrueDto>(query,paramaters);
                return values.ToList();
            }

        }
    }
}
