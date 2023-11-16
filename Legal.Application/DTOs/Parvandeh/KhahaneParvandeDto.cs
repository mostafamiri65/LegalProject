using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Application.DTOs.Parvandeh
{
    public class KhahaneParvandeDto
    {
        public int TarafainId { get; set; }
        public int ParvandeId { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string? Mobile { get; set; }
        public string? CodeMeli { get; set; }


    }
}
