using System;
namespace AstroScreen_Cinema.Models.EntitiesDto
{
	public class LoginDto
	{
		public string Login { get; set; }


		public string Password { get; set; }


		public string IsLogged { get; set; } = "NOTLOGGED";
	}
}

