using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SudheerKumar.Avula.DateCalculator.Models;

namespace SudheerKumar.Avula.DateCalculator.Repository
{
    public interface IDaysCalculatorRepository
    {
        int CalculatorDaysBetweenDates(DateModel date);
    }
}