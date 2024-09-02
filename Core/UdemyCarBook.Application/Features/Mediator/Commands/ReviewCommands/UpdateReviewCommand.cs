﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands
{
	public class UpdateReviewCommand : IRequest
	{
        public int ReviewID { get; set; }
        public string CustomerName { get; set; }
		public string CustomerImage { get; set; }
		public string Comment { get; set; }
		public string RatingValue { get; set; }
		public DateTime ReviewDate { get; set; }
		public int CarID { get; set; }
	}
}
