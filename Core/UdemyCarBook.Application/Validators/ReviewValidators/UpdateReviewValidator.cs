using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commands.ReviewCommands;

namespace UdemyCarBook.Application.Validators.ReviewValidators
{
	public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
	{
        public UpdateReviewValidator()
        {
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz");
			RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen müşteri adını en az 5 karakter giriniz.");
			RuleFor(x => x.RatingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz.");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum değerini boş geçmeyiniz.");
			RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen yorum kısmını en az 50 karakter giriniz.");
			RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen yorum kısmını en fazla 500 karakter giriniz.");
			RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen müşteri görselini değerini boş geçmeyiniz.").MinimumLength(10).WithMessage("Lütfen resim kısmını en az 10 karakter giriniz.").MaximumLength(200).WithMessage("Lütfen resim kısmını en fazla 200 karakter giriniz.");
		}
    }
}
