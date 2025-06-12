using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace RealEstate_Dapper_UI.ViewComponents.Dashboard
{
	public class _DashboardStatisticsComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public  async Task<IViewComponentResult> InvokeAsync()
		{
			#region statistics1 ürün sayısı
			var client17 = _httpClientFactory.CreateClient();
			var responseMessage17 = await client17.GetAsync("https://localhost:44388/api/Statistics/ProductCount");
			var jsonData17 = await responseMessage17.Content.ReadAsStringAsync();


			ViewBag.productCount = jsonData17;

			#endregion

			#region statistics2  En Fazla Satış Yapan Personel
			var client12 = _httpClientFactory.CreateClient();
			var responseMessage12 = await client12.GetAsync("https://localhost:44388/api/Statistics/EmployeeCountByMaxProductCount");
			var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();


			ViewBag.employeeCountByMaxProductCount = jsonData12;

			#endregion

			#region statistics3 ilandaki Şehir Sayıları
			var client11 = _httpClientFactory.CreateClient();
			var responseMessage11 = await client11.GetAsync("https://localhost:44388/api/Statistics/DifferentCityCount");
			var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();


			ViewBag.differentCityCount = jsonData11;

			#endregion

			#region statistics4 Ortalama Kira Fiyatı
			var client4 = _httpClientFactory.CreateClient();
			var responseMessage4 = await client4.GetAsync("https://localhost:44388/api/Statistics/AvarageProductPriceByRent");
			var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
			decimal averagePrice = Convert.ToDecimal(jsonData4);
			var values = averagePrice / 1000000;
			ViewBag.avarageProductPriceByRent = values.ToString("0.00" + "₺");

			#endregion
			return View();
		}
	}
}
