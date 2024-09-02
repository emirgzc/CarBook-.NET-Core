using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AuthorQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AuthorResults;
using UdemyCarBook.Application.Features.Mediator.Results.FeatureResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AuthorHandler.Read
{
	public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, GetAuthorByIdQueryResults>
	{
		private readonly IRepository<Author> _repository;

		public GetAuthorByIdQueryHandler(IRepository<Author> repository)
		{
			_repository = repository;
		}

		public async Task<GetAuthorByIdQueryResults> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetByIdAsync(request.Id);
			return new GetAuthorByIdQueryResults
			{
				AuthorID = values.AuthorID,
				Description = values.Description,
				ImageUrl = values.ImageUrl,
				Name = values.Name,
			};
		}
	}
}
