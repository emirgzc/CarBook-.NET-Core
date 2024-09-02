﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyCarBook.Dto.BlogDtos;

namespace UdemyCarBook.WebUI.ViewComponents.Blog
{
	public class _BlogDetailMainComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _BlogDetailMainComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7173/api/Blogs/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultGetBlogByIdDto>(jsonData);
				return View(values);
			}			
			return View();
		}
	}
}
