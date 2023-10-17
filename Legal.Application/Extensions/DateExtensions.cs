﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Legal.Application.Extensions
{
    public static class DateExtensions
    {
        public static string ToShamsi(this DateTime date)
        {
            var persianCalender = new PersianCalendar();

            return $"{persianCalender.GetYear(date)}/{persianCalender.GetMonth(date).ToString("00")}/{persianCalender.GetDayOfMonth(date).ToString("00")}";
        }
        public static string FirstDayOfPersianMonth()
        {
            var pc = new PersianCalendar();
            var today = DateTime.Today;
            int year = pc.GetYear(today);
            int month = pc.GetMonth(today);
            int day = 01;
            return $"{year}/{month.ToString("00")}/{day.ToString("00")}";
        }

        public static DateTime ToMiladi(this string date)
        {
            var splitedDate = date.Split("/");

            var year = Convert.ToInt32(splitedDate[0]);
            var month = Convert.ToInt32(splitedDate[1]);
            var day = Convert.ToInt32(splitedDate[2]);

            return new DateTime(year, month, day, new PersianCalendar());
        }

    }
}
