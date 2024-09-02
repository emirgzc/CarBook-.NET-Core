using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Authors.Mediator.Handlers.AuthorHandler.Read
{
	public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResults>>
	{
		private readonly IRepository<Author> _repository;

		public GetAuthorQueryHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetAuthorQueryResults>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetAuthorQueryResults
			{
				AuthorID = x.AuthorID,
				Description = x.Description,
				Name = x.Name,
				ImageUrl = x.ImageUrl
			}).ToList();
		}
	}
}
