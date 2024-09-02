using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.TagCloudQueries;
using UdemyCarBook.Application.Features.Mediator.Results.TagCloudResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TagCloudHandler.Read
{
	public class GetTagCloudByBlogIDQueryHandler : IRequestHandler<GetTagCloudByBlogIDQuery, List<GetTagCloudByBlogIDQueryResult>>
	{
		private readonly ITagCloudRepository _repository;

		public GetTagCloudByBlogIDQueryHandler(ITagCloudRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetTagCloudByBlogIDQueryResult>> Handle(GetTagCloudByBlogIDQuery request, CancellationToken cancellationToken)
		{
			var values = await _repository.GetTagCloudsByBlogID(request.Id);
			return values.Select(x => new GetTagCloudByBlogIDQueryResult
			{
				TagCloudID = x.TagCloudID,
				BlogID = x.BlogID,
				Title = x.Title
			}).ToList();
		}
	}
}
