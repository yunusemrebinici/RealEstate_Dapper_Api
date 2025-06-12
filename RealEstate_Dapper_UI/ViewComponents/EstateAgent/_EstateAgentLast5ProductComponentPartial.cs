using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.EstateAgentDtos;
using RealEstate_Dapper_UI.Services;

namespace RealEstate_Dapper_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLast5ProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginservice;

        public _EstateAgentLast5ProductComponentPartial(IHttpClientFactory httpClientFactory,ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginservice = loginService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = _loginservice.GetUserId;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/EstateAgentLastProduct?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values =  JsonConvert.DeserializeObject<List<ResultEstateAgentDashboard5ProductListById>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
