using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandler.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandler.Write;
using UdemyCarBook.Application.Features.CQRS.Queries.ContactQueries;

namespace UdemyCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly GetContactByIdQueryHandler _getContactByIdQueryHandler;
        private readonly GetContactQueryHandler _getContactQueryHandler;
        private readonly CreateContactCommandHandler _createContactCommandHandler;
        private readonly RemoveContactCommandHandler _removeContactCommandHandler;
        private readonly UpdateContactCommandHandler _updateContactCommandHandler;

        public ContactsController(GetContactByIdQueryHandler getContactByIdQueryHandler, GetContactQueryHandler getContactQueryHandler, CreateContactCommandHandler createContactCommandHandler, RemoveContactCommandHandler removeContactCommandHandler, UpdateContactCommandHandler updateContactCommandHandler)
        {
            _getContactByIdQueryHandler = getContactByIdQueryHandler;
            _getContactQueryHandler = getContactQueryHandler;
            _createContactCommandHandler = createContactCommandHandler;
            _removeContactCommandHandler = removeContactCommandHandler;
            _updateContactCommandHandler = updateContactCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> ContactList()
        {
            var values = await _getContactQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContact(int id)
        {
            var value = await _getContactByIdQueryHandler.Handle(new GetContactByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactCommands command)
        {
            await _createContactCommandHandler.Handle(command);
            return Ok("Contact Bilgisi eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            await _removeContactCommandHandler.Handle(new RemoveContactCommands(id));
            return Ok("Contact Bilgisi silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactCommands command)
        {
            await _updateContactCommandHandler.Handle(command);
            return Ok("Contact Bilgisi güncellendi");
        }
    }
}
