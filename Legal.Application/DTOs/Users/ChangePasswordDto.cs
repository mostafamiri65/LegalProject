using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Application.DTOs.Users
{
    public class ChangePasswordDto
    {
        public long Id { get; set; }
        public string Password { get; set; } = string.Empty;
    }
}
