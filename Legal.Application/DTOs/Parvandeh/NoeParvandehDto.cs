using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Application.DTOs.Parvandeh
{
    public class NoeParvandehDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? KhahanBadvi { get; set; }

        public string? KhandehBadvi { get; set; }

        public string? KhahanTajdid { get; set; }

        public string? KhandehTajdid { get; set; }
    }
}
