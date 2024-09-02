using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Commands.ContactCommands
{
    public class RemoveContactCommands
    {
        public RemoveContactCommands(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
