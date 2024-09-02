using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReservationCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.ReservationHandler.Write
{
	public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand>
	{
		private readonly IRepository<Reservation> _repository;

		public CreateReservationCommandHandler(IRepository<Reservation> repository)
		{
			_repository = repository;
		}

		public async Task Handle(CreateReservationCommand request, CancellationToken cancellationToken)
		{
			await _repository.CreateAsync(new Reservation
			{
				Age = request.Age,
				CarID = request.CarID,
				Description = request.Description,
				DriverLicenseYear = request.DriverLicenseYear,
				Email = request.Email,
				Name = request.Name,
				Phone = request.Phone,
				Surname = request.Surname,
				PickUpLocationID = request.PickUpLocationID,
				DropOffLocationID = request.DropOffLocationID,
				Status = "Rezervasyon Alındı"
			});
		}
	}
}
