using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Application.DTOs.Users
{
    public class UsersListDto
    {
        public long Id { get; set; }
        public string? RoleTitle { get; set; }
        public string? Username { get; set; }
      
        public string? Mobile { get; set; }

        public string? FullName { get; set; }
        public string? OstanTitle { get; set; }
        public string? ShahrestanTitle { get; set; }
        public string? RegionTitle { get; set; }

    }
}
