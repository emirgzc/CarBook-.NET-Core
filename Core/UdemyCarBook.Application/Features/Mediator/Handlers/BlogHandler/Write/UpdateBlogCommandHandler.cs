﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.BlogCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.BlogHandler.Write
{
	public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
	{
		private readonly IRepository<Blog> _repository;

		public UpdateBlogCommandHandler(IRepository<Blog> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.BlogID);

			value.AuthorID = request.AuthorID;
			value.CategoryID = request.CategoryID;
			value.CoverImageUrl = request.CoverImageUrl;
			value.CreatedDate = request.CreatedDate;
			value.Title = request.Title;
			await _repository.UpdateAsync(value);
		}
	}
}
