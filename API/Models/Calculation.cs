using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Calculation
    {
        [Required]
        public decimal? number1 { get; set; }
        [Required]
        public decimal? number2 { get; set; }
        [Required]
        [RegularExpression("\\+|-|x|%", ErrorMessage = "Invalid operator present, please ensure property only contains values from range: +|-|*|/")]
        public char? operation { get; set; }
    }
}
