using System;
using System.ComponentModel.DataAnnotations;

namespace Restraunt.Core.Dto
{
	public class LoginDto
	{
		[Required]
		public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
		public string ReturnUrl { get; set; }
	}
}

