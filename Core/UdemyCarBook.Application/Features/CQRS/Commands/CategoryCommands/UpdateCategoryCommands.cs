using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.CQRS.Commands.CategoryCommands
{
    public class UpdateCategoryCommands
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
    }
}
