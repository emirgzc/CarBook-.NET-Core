using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.AppUserQueries;
using UdemyCarBook.Application.Features.Mediator.Results.AppUserResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.AppUserHandler.Write
{
	public class GetCheckAppUserQueryHandler : IRequestHandler<GetCheckAppUserQuery, GetCheckAppUserQueryResult>
	{
		private readonly IRepository<AppUser> _appUserRepositroy;
		private readonly IRepository<AppRole> _appRoleRepositroy;

		public GetCheckAppUserQueryHandler(IRepository<AppRole> appRoleRepositroy, IRepository<AppUser> appUserRepositroy)
		{
			_appRoleRepositroy = appRoleRepositroy;
			_appUserRepositroy = appUserRepositroy;
		}

		public async Task<GetCheckAppUserQueryResult> Handle(GetCheckAppUserQuery request, CancellationToken cancellationToken)
		{
			var values = new GetCheckAppUserQueryResult();
			var user = await _appUserRepositroy.GetByFilterAsync(x=>x.Username == request.Username && x.Password == request.Password);
			if (user==null)
			{
				values.IsExist = false;
			}
			else
			{
				values.IsExist = true;
				values.Username = user.Username;
				values.Role = (await _appRoleRepositroy.GetByFilterAsync(x => x.AppRoleID == user.AppRoleID)).AppRoleName;
				values.Id = user.AppUserID;
			}
			return values;
		}
	}
}
