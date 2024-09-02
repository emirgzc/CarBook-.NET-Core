using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Results.TestimonialResults;

namespace UdemyCarBook.Application.Features.Mediator.Queries.TestimonailQueries
{
    public class GetTestimonaiByIdlQuery : IRequest<GetTestimonialByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTestimonaiByIdlQuery(int id)
        {
            Id = id;
        }
    }
}
