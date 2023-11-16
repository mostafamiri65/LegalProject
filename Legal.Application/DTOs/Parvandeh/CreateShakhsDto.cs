using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Application.DTOs.Parvandeh
{
    public class CreateShakhsDto
    {
        public int ParvandeId { get; set; }
        [Display(Name = "نام")]
        public string Name { get; set; } = null!;
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; } = null!;
        [Display(Name = "نام پدر")]
        public string? NamePedar { get; set; }
        [Display(Name = "شغل")]
        public string? Pisheh { get; set; }
        [Display(Name = "آدرس")]
        public string? Address { get; set; }
        [Display(Name = "تلفن ثابت")]
        public string? Tel { get; set; }
        [Display(Name = "موبایل")]
        public string? Mobile { get; set; }
        [Display(Name = "فکس")]
        public string? Faks { get; set; }
        [Display(Name = "سایت")]
        public string? Site { get; set; }
        [Display(Name = "ایمیل")]
        public string? Email { get; set; }
        [Display(Name = "جنسیت")]
        public byte? Jens { get; set; }

        public byte? NoehAshkhasCode { get; set; }
        [Display(Name = "تاریخ تولد / ثبت")]
        public string? DateTavalod { get; set; }
        [Display(Name = "سمت")]
        public string? Semat { get; set; }
        [Display(Name = "کد ملی")]
        public string? CodeMeli { get; set; }
        [Display(Name = "کد پستی")]
        public string? CodePosti { get; set; }
    }
}
