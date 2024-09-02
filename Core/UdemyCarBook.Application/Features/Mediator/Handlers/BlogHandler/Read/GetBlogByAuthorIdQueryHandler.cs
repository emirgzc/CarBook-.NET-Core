using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.BlogQueries;
using UdemyCarBook.Application.Features.Mediator.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandler.Read
{
	public class GetBlogByAuthorIdQueryHandler : IRequestHandler<GetBlogByAuthorIdQuery, List<GetBlogByAuthorIdQueryResults>>
	{
		private readonly IBlogRepository _repository;

		public GetBlogByAuthorIdQueryHandler(IBlogRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetBlogByAuthorIdQueryResults>> Handle(GetBlogByAuthorIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetBlogByAuthorId(request.Id);
			return values.Select(x => new GetBlogByAuthorIdQueryResults
			{
				BlogID = x.BlogID,
				AuthorID = x.AuthorID,
				AuthorDescription = x.Author.Description,
				AuthorImageUrl = x.Author.ImageUrl,
				AuthorName = x.Author.Name
			}).ToList();
		}
	}
}