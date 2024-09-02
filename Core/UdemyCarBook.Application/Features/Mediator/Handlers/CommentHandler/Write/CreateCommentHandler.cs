using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.CommentCommands;
using UdemyCarBook.Application.Features.Mediator.Commands.FeatureCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.CommentHandler.Write
{
	public class CreateCommentHandler : IRequestHandler<CreateCommentCommand>
	{
		private readonly IRepository<Comment> _repository;

		public CreateCommentHandler(IRepository<Comment> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Comment
			{
				BlogID = request.BlogID,
				Content = request.Content,
				Name = request.Name,
				CreatedDate = DateTime.Parse(DateTime.Now.ToLongDateString()),
				Email = request.Email
			});
		}
	}
}
