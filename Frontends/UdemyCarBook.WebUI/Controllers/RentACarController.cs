using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using UdemyCarBook.Dto.BrandDto;
using UdemyCarBook.Dto.RentACarDtos;

namespace UdemyCarBook.WebUI.Controllers
{
	public class RentACarController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public RentACarController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var locationID = TempData["locationID"];

			int locID = int.Parse(locationID.ToString());

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7173/api/RentACar?locationID={locID}&available=true");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
