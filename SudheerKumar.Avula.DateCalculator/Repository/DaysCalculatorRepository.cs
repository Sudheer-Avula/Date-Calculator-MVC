﻿using System;
using SudheerKumar.Avula.DateCalculator.BLL;
using SudheerKumar.Avula.DateCalculator.Models;

namespace SudheerKumar.Avula.DateCalculator.Repository
{
    public class DaysCalculatorRepository : IDaysCalculatorRepository
    {
        private static readonly int[] DaysPerMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 }; //number of days for eatch month for 12 months
        public int CalculatorDaysBetweenDates(DateModel date)
        {
            string[] readStartDate = date.StartDate.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            string[] readEndDate = date.EndDate.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            DaysCaliculator caliculator=new DaysCaliculator();
           return caliculator.CaliculateDays(Convert.ToInt32(readStartDate[0]), Convert.ToInt32(readStartDate[1]),
                Convert.ToInt32(readStartDate[2]),
                Convert.ToInt32(readEndDate[0]), Convert.ToInt32(readEndDate[1]), Convert.ToInt32(readEndDate[2]));
        }

        private int CaliculateDays(int iFromday, int iFromMonth, int iFromYear, int iToday, int iToMonth, int iToyear)
        {
            //Set February days based on year, if Leap year then 29 else get from static variable "DaysPerMonth" value of February i.e 28
            var iDifference = (iFromMonth == 2 && LeapYearCheck(iFromYear)) ? 29 - iFromday : DaysPerMonth[iFromMonth] - iFromday;

            //if same year and month then just get days difference 
            if (iFromYear == iToyear && iFromMonth == iToMonth) // Note: This can moved to client side
                return Math.Abs(iFromday - iToday);

            return CalculateDaysOfDifferentYearsInput(iFromMonth, iFromYear, iToday, iToMonth, iToyear, ref iDifference);
        }

        private int CalculateDaysOfDifferentYearsInput(int iFromMonth, int iFromYear, int iToday, int iToMonth, int iToyear, ref int iDifference)
        {
            var i = iFromMonth + 1;

            while (true)
            {
                while (i <= 12)
                {
                    if (iFromYear == iToyear && i == iToMonth) //calculation over since both years same
                    {
                        iDifference += iToday;//inlcude given desination month days too
                        return iDifference;
                    }

                    iDifference += (i == 2 && LeapYearCheck(iFromYear)) ? 29 : DaysPerMonth[i];//Assign days in loop for February leap year
                    i++;
                }
                i = 1;// set to 1 to loop month days for eatch year
                iFromYear++;// increment year till it reach desination year
            }
        }

        private bool LeapYearCheck(int iYear)
        {
            return (iYear % 4 == 0 || iYear % 100 == 0) && iYear % 400 != 0; // find input year is leapYear
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iFromday"></param>
        /// <param name="iFromMonth"></param>
        /// <param name="iFromYear"></param>
        /// <param name="iToday"></param>
        /// <param name="iToMonth"></param>
        /// <param name="iToyear"></param>
        /// <returns></returns>
        private int Test(int iFromday, int iFromMonth, int iFromYear, int iToday, int iToMonth, int iToyear)
        {
            if (iFromYear > iToyear)
                return CaliculateDays(iToday, iToMonth, iToyear, iFromday, iFromMonth, iFromYear);
            return CaliculateDays(iFromday, iFromMonth, iFromYear, iToday, iToMonth, iToyear);
        }
    }
}