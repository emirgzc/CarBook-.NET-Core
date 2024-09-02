using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using UdemyCarBook.Dto.CommentDtos;
using UdemyCarBook.Dto.StatisticsDtos;

namespace UdemyCarBook.WebUI.ViewComponents.Dashboard
{
	public class _AdminDashboardStatisticsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();

			#region İstatistik1
			var responseMessage = await client.GetAsync("https://localhost:7173/api/Statistics/GetCarCount");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
				ViewBag.carCount = values.getCarCount;
			}
			#endregion

			#region İstatistik2
			var responseMessage2 = await client.GetAsync("https://localhost:7173/api/Statistics/GetLocationCount");
			if (responseMessage2.IsSuccessStatusCode)
			{
				var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
				var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
				ViewBag.locationCount = values2.getLocationCount;
			}
			#endregion

			#region İstatistik5
			var responseMessage5 = await client.GetAsync("https://localhost:7173/api/Statistics/GetBrandCount");
			if (responseMessage5.IsSuccessStatusCode)
			{
				var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
				var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
				ViewBag.brandCount = values5.getBrandCount;
			}
			#endregion

			#region İstatistik6
			var responseMessage6 = await client.GetAsync("https://localhost:7173/api/Statistics/GetAvgRentPriceForDaily");
			if (responseMessage6.IsSuccessStatusCode)
			{
				var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
				var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
				ViewBag.avgRentPriceForDaily = values6.getAvgRentPriceForDaily;
			}
			#endregion

			return View();
		}
	}
}
