using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandler.Write
{
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommands commands)
        {
            var values = await _repository.GetByIdAsync(commands.ContactID);
            values.Name = commands.Name;
            values.Email = commands.Email;
            values.Message = commands.Message;
            values.SendDate = commands.SendDate;
            values.Subject = commands.Subject;
            await _repository.UpdateAsync(values);
        }
    }
}
