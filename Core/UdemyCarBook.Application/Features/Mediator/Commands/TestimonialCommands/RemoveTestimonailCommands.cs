using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonailCommands : IRequest
    {
        public int Id { get; set; }

        public RemoveTestimonailCommands(int id)
        {
            Id = id;
        }
    }
}
