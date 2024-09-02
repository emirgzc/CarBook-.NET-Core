using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using UdemyCarBook.Dto.LocationDtos;

namespace UdemyCarBook.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public DefaultController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var token = User.Claims.FirstOrDefault(x => x.Type == "accessToken")?.Value;
			if (token != null)
			{
				var client = _httpClientFactory.CreateClient();
				client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var responseMessage = await client.GetAsync("https://localhost:7173/api/Locations");

				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);

				List<SelectListItem> values2 = (from x in values
												select new SelectListItem
												{
													Text = x.LocationName,
													Value = x.LocationID.ToString()
												}).ToList();
				ViewBag.locationList = values2;
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(string locationID)
		{
			TempData["locationID"] = locationID;
			return RedirectToAction("Index", "RentACar");
		}
	}
}
