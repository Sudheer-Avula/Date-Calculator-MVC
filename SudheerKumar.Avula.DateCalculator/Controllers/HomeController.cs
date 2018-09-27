using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SudheerKumar.Avula.DateCalculator.Models;
using SudheerKumar.Avula.DateCalculator.Repository;

namespace SudheerKumar.Avula.DateCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDaysCalculatorRepository _repository;
        /// <summary>
        /// HomeController
        /// </summary>
        /// <param name="repository"></param>
        public HomeController(IDaysCalculatorRepository repository)
        {
            _repository = repository;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(DateModel date)
        {
            if (!ModelState.IsValid)
            {
                return View(date);
            }
            int result = _repository.CalculatorDaysBetweenDates(date);
            ViewBag.Message = string.Format("Days difference between two date is {0}", result); ;
            return View(date);
        }
      
    }
}