﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Tools
{
	public class JwtTokenDefaults
	{
		public const string ValidAudiance = "https://localhost";
		public const string ValidIssuer = "http://localhost";
		public const string Key = "CarBook+*010203CARBOOK01+*..020304CarBookProje";
		public const int Expire = 3;
	}
}
