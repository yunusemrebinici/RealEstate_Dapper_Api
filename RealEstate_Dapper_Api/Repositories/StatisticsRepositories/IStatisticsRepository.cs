namespace RealEstate_Dapper_Api.Repositories.StatisticsRepositories
{
	public interface IStatisticsRepository
	{
		int CategoryCount();

		int ActiveCategoryCount();

		int PassiveCategoryCount();

		int ProductCount();	

		int ApartmentCount();

		string EmployeeCountByMaxProductCount();

		string CategoryNameByMaxProductCount();

		decimal AvarageProductPriceByRent();

		decimal AvarageProductPriceBySale();

		string CityNameByMaxProductCount();	

		int DifferentCityCount();

		decimal LastProductPrice();

		string NewsBuildingYear();

		string OldesBuildingYear();

		int AvarageRoomCount();

		int ActiveEmployeeCount();

	}
}
