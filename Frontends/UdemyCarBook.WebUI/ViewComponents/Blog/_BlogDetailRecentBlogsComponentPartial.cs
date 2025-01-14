﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;
using UdemyCarBook.Dto.CategoryDtos;

namespace UdemyCarBook.WebUI.ViewComponents.Blog
{
    public class _BlogDetailRecentBlogsComponentPartial : ViewComponent
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public _BlogDetailRecentBlogsComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7173/api/Blogs/BlogLastThreeListWithAuthor");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultLastThreeBlogsWithAuthors>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
