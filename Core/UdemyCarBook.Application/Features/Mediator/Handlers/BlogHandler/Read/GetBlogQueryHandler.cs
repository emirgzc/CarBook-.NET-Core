﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandler.Read
{
	public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResults>>
	{
		private readonly IRepository<Blog> _repository;

		public GetBlogQueryHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBlogQueryResults>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetBlogQueryResults
			{
				BlogID = x.BlogID,
				AuthorID = x.AuthorID,
				CategoryID = x.CategoryID,
				CoverImageUrl = x.CoverImageUrl,
				CreatedDate = x.CreatedDate,
				Title = x.Title,
				
			}).ToList();
		}
	}
}
