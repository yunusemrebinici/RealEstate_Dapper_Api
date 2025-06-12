using Dapper;
using RealEstate_Dapper_Api.Models.DapperContext;
using System.Collections;

namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
	public class StatisticsRepository : IStatisticsRepository
	{
		private readonly Context _context;

		public StatisticsRepository(Context context) 
		{ 
			_context = context;
		}

		public int ActiveCategoryCount()
		{
			var query = "Select Count(*) from Category where CategoryStatus=1";
			using (var connection = _context.CrateConnection())
			{
				var values= connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ActiveEmployeeCount()
		{
			var query = "select count(*) from Employee where Status=1";
			using (var connection = _context.CrateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ApartmentCount()
		{
			var query = "SELECT COUNT(*) FROM Product WHERE Title LIKE '%Daire%'";
			using (var connection = _context.CrateConnection())
			{
				var values=connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public decimal AvarageProductPriceByRent()
		{
			var query = "SELECT avg(Price) from Product where Type ='Kiralık'";
			using (var connection = _context.CrateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public decimal AvarageProductPriceBySale()
		{
			var query = "SELECT avg(Price) from Product where Type ='Satılık'";
			using (var connection = _context.CrateConnection())
			{
				var values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public int AvarageRoomCount()
		{
			string query = "SELECT avg(RoomCount) from ProductDetails";
			using (var connection= _context.CrateConnection())
			{
				var values =connection.QueryFirstOrDefault<int>(query);
				return values;
			}

		}

		public int CategoryCount()
		{
			string query = "SELECT COUNT(DISTINCT CategoryName) FROM Category";
			using (var connection= _context.CrateConnection())
			{
				int values =connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public string CategoryNameByMaxProductCount()
		{
			string query = "SELECT top(1) CategoryName ,Count(*) From Product inner join Category on Product.ProductCategory=Category.CategoryID Group By CategoryName order by Count(*) Desc";
			using (var connection=_context.CrateConnection())
			{
				string values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public string CityNameByMaxProductCount()
		{
			string query = "select top(1) City ,Count(*) as 'ilan_sayisi' from Product  group by  City  order by count(*) desc";
			using (var connection = _context.CrateConnection())
			{
				string values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public int DifferentCityCount()
		{
			string query = "select Count(Distinct (City))  from Product";
			using (var connection = _context.CrateConnection())
			{
				int values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public string EmployeeCountByMaxProductCount()
		{
			string query = "select top(1) Name ,COUNT(*) as 'product_count' from Product inner join AppUser on Product.AppUserId=AppUser.UserId group by Name order by product_count desc";
			using (var connection = _context.CrateConnection())
			{
				string values = connection.QueryFirstOrDefault<string>(query);
				return values;
			}
		}

		public decimal LastProductPrice()
		{
			string query = "SELECT TOP 1 Price FROM Product ORDER BY ProductID desc";
			using (var connection = _context.CrateConnection())
			{
				decimal values = connection.QueryFirstOrDefault<decimal>(query);
				return values;
			}
		}

		public string NewsBuildingYear()
		{
			
			string query = "SELECT TOP 1 Location,BuildYear  FROM ProductDetails ORDER BY BuildYear desc";
			using (var connection = _context.CrateConnection())
			{
				var values = connection.QueryFirstOrDefault<(string Location ,int BuilYear)>(query);
				return values != default ? $"{values.Location} - {values.BuilYear}" : "No data found";
			}
		}

		public string OldesBuildingYear()
		{
			string query = "SELECT TOP 1 Location,BuildYear  FROM ProductDetails ORDER BY BuildYear asc";
			using (var connection = _context.CrateConnection())
			{
				var values = connection.QueryFirstOrDefault<(string Location, int BuilYear)>(query);
				return values != default ? $"{values.Location} - {values.BuilYear}" : "No data found";
			}
		}

		public int PassiveCategoryCount()
		{

			string query = "select count(*) from Category where CategoryStatus=0";
			using (var connection = _context.CrateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values;
			}
		}

		public int ProductCount()
		{

			string query = "select count(*) from Product";
			using (var connection = _context.CrateConnection())
			{
				var values = connection.QueryFirstOrDefault<int>(query);
				return values ;
			}
		}
	}
}
