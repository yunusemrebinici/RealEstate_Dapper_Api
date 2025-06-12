using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProductDetailDtos;
using RealEstate_Dapper_UI.Dtos.ProductDtos;

namespace RealEstate_Dapper_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public PropertyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        
        public async Task <IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Product/GetAllWithCategoryName");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData= await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        public async Task< IActionResult> PropertyListWithSearch(string searchKeyValue, int propertyCategoryId, string city)
        {
            searchKeyValue = TempData["searchKeyValue"].ToString();
            propertyCategoryId = int.Parse(TempData["propertyCategoryId"].ToString());
            city = TempData["city"].ToString();
           
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44388/api/Product/ResultProductWithSearchList?searchKeyValue={searchKeyValue}&propertyCategoryId={propertyCategoryId}&city={city}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);
                return View(values);

            }
            return View();
        }

        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(int id,string slug)
        {
            ViewBag.i = id;

            //Product
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44388/api/Product/GetProductByProductId?id=" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<GetProductByProductIdDto>(jsonData);

            //ProductDetail
            var client1 = _httpClientFactory.CreateClient();
            var responseMessage1 = await client1.GetAsync("https://localhost:44388/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            var productDetails = JsonConvert.DeserializeObject<GetProductDetailByIdDto>(jsonData1);

            //Product
            ViewBag.Id = product.ProductID;
            ViewBag.title1 = product.Title;
            ViewBag.price = product.Price;
            ViewBag.city = product.City;
            ViewBag.district = product.District;
            ViewBag.address = product.Address;
            ViewBag.type = product.Type;
            ViewBag.description = product.Description;
            ViewBag.advertisementDate = product.AdvertisementDate.ToString("dd-MMM-yyyy");

            //ProductDetail
            ViewBag.beds = productDetails.BedRoomCount;
            ViewBag.baths = productDetails.BathCount;
            ViewBag.size = productDetails.ProductSize;
            ViewBag.productId = productDetails.ProductID;
            ViewBag.roomcount = productDetails.RoomCount;
            ViewBag.garagsize = productDetails.GarageSize;
            ViewBag.buildyear = productDetails.BuildYear;
            ViewBag.locationmap = productDetails.LocationMap;
            ViewBag.videourl = productDetails.VideoUrl;

            //DateTime 
            DateTime date1 = DateTime.Now;
            DateTime date2 = product.AdvertisementDate;
            TimeSpan timeSpan = date1 - date2;
            int days = timeSpan.Days;
            int month = days / 30;

            ViewBag.date = month;

            string slugFromTitle = CreateSlug(product.Title);

            ViewBag.slugUrl = slugFromTitle;

            return View();
        }

        private string CreateSlug(string title)
        {
           title =title.ToLowerInvariant(); // Küçük harfe çevir 
           title = title.Replace(" ", "-"); //Boşlukları * ile değiştir
            title = System.Text.RegularExpressions.Regex.Replace(title, @"[^a-z0-9\s-]","");// Geçersiz karakterleri kaldır.
            title=System.Text.RegularExpressions.Regex.Replace(title,@"\s+"," ").Trim(); //Birden fazla boşluğu tek boşluğa indir ve kenar boşluklarını kaldır.
            title = System.Text.RegularExpressions.Regex.Replace(title, @"\s", "-"); //Boşlukları tire ile değiştir.
            return title;


        }
    }
}
