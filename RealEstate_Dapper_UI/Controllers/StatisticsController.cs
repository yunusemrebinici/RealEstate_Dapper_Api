using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace RealEstate_Dapper_UI.Controllers
{
	public class StatisticsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
	    
		public StatisticsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}	

		public async Task<IActionResult> Index()
		{
            #region statistics1
            var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44388/api/Statistics/ActiveCategoryCount");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			ViewBag.activeCategoryCount = jsonData;
            #endregion

            #region statistics2
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:44388/api/Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion

            #region statistics3
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:44388/api/Statistics/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData3;
            #endregion

            #region statistics4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync("https://localhost:44388/api/Statistics/AvarageProductPriceByRent");     
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();      
            decimal averagePrice = Convert.ToDecimal(jsonData4);
            var values = averagePrice / 1000000;            
            ViewBag.avarageProductPriceByRent = values.ToString("0.00"+"₺"); 

            #endregion

            #region statistics5
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync("https://localhost:44388/api/Statistics/AvarageProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            decimal values5 = Convert.ToDecimal(jsonData5)/1000000;

            ViewBag.avarageProductPriceBySale = values5.ToString("0.00"+"₺");
            #endregion

            #region statistics6
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync("https://localhost:44388/api/Statistics/AvarageRoomCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();


            ViewBag.avarageRoomCount = jsonData6;

            #endregion

            #region statistics8
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync("https://localhost:44388/api/Statistics/CategoryCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();


            ViewBag.categoryCount = jsonData8;

            #endregion

            #region statistics9
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync("https://localhost:44388/api/Statistics/CategoryNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();


            ViewBag.categoryNameByMaxProductCount = jsonData9;

			#endregion

			#region statistics10
			var client10 = _httpClientFactory.CreateClient();
			var responseMessage10 = await client10.GetAsync("https://localhost:44388/api/Statistics/CityNameByMaxProductCount");
			var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();


			ViewBag.cityNameByMaxProductCount = jsonData10;

			#endregion
            
			#region statistics11
			var client11 = _httpClientFactory.CreateClient();
			var responseMessage11 = await client11.GetAsync("https://localhost:44388/api/Statistics/DifferentCityCount");
			var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();


			ViewBag.differentCityCount = jsonData11;

			#endregion

			#region statistics12
			var client12 = _httpClientFactory.CreateClient();
			var responseMessage12 = await client12.GetAsync("https://localhost:44388/api/Statistics/EmployeeCountByMaxProductCount");
			var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();


			ViewBag.employeeCountByMaxProductCount = jsonData12;

			#endregion

			#region statistics13
			var client13 = _httpClientFactory.CreateClient();
			var responseMessage13 = await client13.GetAsync("https://localhost:44388/api/Statistics/LastProductPrice");
			var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();


			ViewBag.LastProductPrice = jsonData13.ToString();

			#endregion

			#region statistics14
			var client14 = _httpClientFactory.CreateClient();
			var responseMessage14 = await client14.GetAsync("https://localhost:44388/api/Statistics/NewsBuildingYear");
			var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();


			ViewBag.newsBuildingYear = jsonData14.ToString();

			#endregion

			#region statistics15
			var client15 = _httpClientFactory.CreateClient();
			var responseMessage15 = await client15.GetAsync("https://localhost:44388/api/Statistics/OldesBuildingYear");
			var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();


			ViewBag.oldesBuildingYear = jsonData15.ToString();

			#endregion

            #region statistics16
			var client16 = _httpClientFactory.CreateClient();
			var responseMessage16 = await client16.GetAsync("https://localhost:44388/api/Statistics/PassiveCategoryCount");
			var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();


			ViewBag.passiveCategoryCount = jsonData16;

			#endregion

			#region statistics17
			var client17 = _httpClientFactory.CreateClient();
			var responseMessage17 = await client17.GetAsync("https://localhost:44388/api/Statistics/ProductCount");
			var jsonData17 = await responseMessage17.Content.ReadAsStringAsync();


			ViewBag.productCount = jsonData17;

			#endregion

			return View();
		}
	}
}
