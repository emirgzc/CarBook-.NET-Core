using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using UdemyCarBook.Dto.CarFeatureDtos;
using UdemyCarBook.Dto.CategoryDtos;
using UdemyCarBook.Dto.FeatureDtos;

namespace UdemyCarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminCarFeatureDetail")]
    public class AdminCarFeatureDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AdminCarFeatureDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7173/api/CarFeature?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto)
        {

            foreach (var item in resultCarFeatureByCarIdDto)
            {
                if (item.Available)
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7173/api/CarFeature/CarFeatureChangeAvailableToTrue?id=" + item.CarFeatureID);

                }
                else
                {
                    var client = _httpClientFactory.CreateClient();
                    await client.GetAsync("https://localhost:7173/api/CarFeature/CarFeatureChangeAvailableToFalse?id=" + item.CarFeatureID);
                }
            }
            return RedirectToAction("Index", "AdminCar");
        }
        [Route("CreateFeatureByCarId/{id}")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureByCarId(int id)
        {
            ViewBag.carId = id;

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7173/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureWithStatusDto>>(jsonData);
                CreateCarFeatureDto model = new CreateCarFeatureDto();
                model.CarID = id;
                model.Features = values;
                return View(model);
            }
            return View();
        }
        [Route("CreateFeatureByCarId/{id}")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureByCarId(CreateCarFeatureDto createCarFeatureDto)
        {
            CreateCarFeatureDetailDto model = new CreateCarFeatureDetailDto();
            model.CarID = createCarFeatureDto.CarID;
            var client = _httpClientFactory.CreateClient();

            foreach (var item in createCarFeatureDto.Features)
            {
                if (item.Status)
                {
                    model.FeatureID = item.FeatureID;
                    var jsonData = JsonConvert.SerializeObject(model);
                    StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                    var responseMessage = await client.PostAsync("https://localhost:7173/api/CarFeature", stringContent);
                }
            }
            return RedirectToAction("Index", "AdminCar", new { area = "Admin" });
        }
    }
}
