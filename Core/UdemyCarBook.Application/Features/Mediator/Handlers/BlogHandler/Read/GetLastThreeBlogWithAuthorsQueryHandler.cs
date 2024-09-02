using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Results.CarResults;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandler.Read
{
	public class GetLastThreeBlogWithAuthorsQueryHandler : IRequestHandler<GetLastThreeBlogsWithAuthorsQuery, List<GetLastThreeBlogWithAuthorsQueryResults>>
	{
		private readonly IBlogRepository _repository;

		public GetLastThreeBlogWithAuthorsQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetLastThreeBlogWithAuthorsQueryResults>> Handle(GetLastThreeBlogsWithAuthorsQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetLastThreeBlogsWithAuthors();
			return values.Select(x => new GetLastThreeBlogWithAuthorsQueryResults
			{
				AuthorID = x.AuthorID,
				BlogID = x.BlogID,
				CategoryID = x.CategoryID,
				CoverImageUrl = x.CoverImageUrl,
				CreatedDate = x.CreatedDate,
				Title = x.Title,
				AuthorName = x.Author.Name
			}).ToList();
		}
	}
}
