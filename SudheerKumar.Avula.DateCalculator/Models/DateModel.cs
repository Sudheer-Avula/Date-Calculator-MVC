using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace SudheerKumar.Avula.DateCalculator.Models
{
    public class DateModel
    {

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:mm/dd/yyyy}")]
        [DataType(DataType.Date)]
        public string StartDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:mm/dd/yyyy}")]
        [DataType(DataType.Date)]
        public string EndDate { get; set; }
    }
}