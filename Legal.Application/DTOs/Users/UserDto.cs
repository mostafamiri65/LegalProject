using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Application.DTOs.Users
{
    public class UserDto
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string? Username { get; set; }      

        public string? Mobile { get; set; }

        public string? FullName { get; set; }  

        public int? RegionId { get; set; }

        public int? OstanId { get; set; }

        public int? ShahrestanId { get; set; }
    }
}
