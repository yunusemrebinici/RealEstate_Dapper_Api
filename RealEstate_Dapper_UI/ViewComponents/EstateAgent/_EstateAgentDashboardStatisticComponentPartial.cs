using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
	public class _EstateAgentDashboardStatisticComponentPartial:ViewComponent
	{

		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginService _loginService;

		public _EstateAgentDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory , ILoginService loginService)
		{
			_httpClientFactory = httpClientFactory;
			_loginService= loginService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var id = _loginService.GetUserId;
			#region statistics1 Toplam ürün sayısı
			var client17 = _httpClientFactory.CreateClient();
			var responseMessage17 = await client17.GetAsync("https://localhost:44388/api/EstateAgentDashboardStatistic/AllProductCount");
			var jsonData17 = await responseMessage17.Content.ReadAsStringAsync();


			ViewBag.allproductCount = jsonData17;

			#endregion

			#region statistics2  emlakçının toplam ilan sayısı
			var client12 = _httpClientFactory.CreateClient();
			var responseMessage12 = await client12.GetAsync("https://localhost:44388/api/EstateAgentDashboardStatistic/ProductCountByEmployeeId?id="+id);
			var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();


			ViewBag.productCountByEmployee = jsonData12;

			#endregion

			#region statistics3 emlakçının toplam aktif ilan sayısı
			var client11 = _httpClientFactory.CreateClient();
			var responseMessage11 = await client11.GetAsync("https://localhost:44388/api/EstateAgentDashboardStatistic/ProductCountByStatusTrue?id="+id);
			var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();


			ViewBag.productCountByEmployeeByStatusTrue = jsonData11;

			#endregion
			
			#region statistics4 emlakçının toplam pasif ilan sayısı
			var client4 = _httpClientFactory.CreateClient();
			var responseMessage4 = await client4.GetAsync("https://localhost:44388/api/EstateAgentDashboardStatistic/ProductCountByStatusFalse?id="+id);
			var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
			
			ViewBag.productCountByEmployeeByStatusFalse = jsonData4;

			#endregion
			return View();
		}

	}
}
