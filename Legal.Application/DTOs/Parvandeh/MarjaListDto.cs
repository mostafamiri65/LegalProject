using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Application.DTOs.Parvandeh
{
    public class MarjaListDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int? NoeId { get; set; }
        public int? Lev { get; set; }
    }
}
