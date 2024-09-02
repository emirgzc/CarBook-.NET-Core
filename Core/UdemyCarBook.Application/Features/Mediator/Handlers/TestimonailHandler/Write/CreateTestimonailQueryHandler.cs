using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.TestimonailHandler.Write
{
    public class CreateTestimonailQueryHandler : IRequestHandler<CreateTestimonailCommands>
    {
        private readonly IRepository<Testimonial> _repository;

        public CreateTestimonailQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTestimonailCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Testimonial
            {
                Comment = request.Comment,
                Title = request.Title,
                ImageUrl = request.ImageUrl,
                Name = request.Name,
            });
        }
    }
}
