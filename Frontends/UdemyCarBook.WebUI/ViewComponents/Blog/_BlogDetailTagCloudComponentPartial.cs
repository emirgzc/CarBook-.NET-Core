using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.TagCloudDtos;

namespace UdemyCarBook.WebUI.ViewComponents.Blog
{
	public class _BlogDetailTagCloudComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _BlogDetailTagCloudComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7173/api/TagClouds/GetTagCloudByBlogID?id=" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTagCloudByBlogIdDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
