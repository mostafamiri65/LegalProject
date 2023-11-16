using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Application.DTOs.Parvandeh
{
    public class ParvandeDto
    {
        public int Id { get; set; }

        public int? ParvandehId { get; set; }

        public string? DateIjad { get; set; }

        public int? ShahrestanId { get; set; }

        public byte? NoyehParvandehCode { get; set; }

        public string? ShParvandeh24 { get; set; }

        public string? ShParvandeh { get; set; }

        public string? MarjaName { get; set; }

        public int? ShShobeh { get; set; }

        public int? Khahan { get; set; }

        public int? Jaryan { get; set; }

        public int? Maly { get; set; }

        public bool? Lah { get; set; }

        public string? Khasteh { get; set; }

        public string? Search1 { get; set; }

        public string? Search2 { get; set; }

        public string? DateRay { get; set; }

        public decimal? HagVekalat { get; set; }

        public decimal? HazinehDadresi { get; set; }

        public bool? TajdidIs { get; set; }

        public string? TajdidDate { get; set; }

        public bool? TajdidKhahan { get; set; }

        public bool? RayTajdidOk { get; set; }

        public string? RayTajdidDate { get; set; }

        public decimal? TajdidHagVekalat { get; set; }

        public decimal? TajdidHazinehDadresi { get; set; }

        public bool? EjraIs { get; set; }

        public string? EjraDate { get; set; }

        public string? MakhtoomeDalil { get; set; }

        public string? MakhtoomeDate { get; set; }

        public bool? MakhtoomeIs { get; set; }

        public string? RakedDalil { get; set; }

        public string? RakedDate { get; set; }

        public bool? RakedIs { get; set; }
    }
}
