using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using API.Models;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalculatorController : ControllerBase
    {
        public readonly ILogger<CalculatorController> logger;

        public CalculatorController(ILogger<CalculatorController> _logger)
        {
            logger = _logger;
        }

        /**
         * Calculate
         * Performs an operation on a set of two numbers
         * Acceptable operations: +, -, *, /
         * 
         * @return Task<IActionResult>
         */
        [HttpPost]
        public IActionResult Calculate(Calculation calculation)
        {
            // Ensure both fields are present and are numbers
            if (!ModelState.IsValid)
            {
                return NotFound(new { 
                    message = "Please ensure all fields are present and contain valid values"
                });
            }

            // Perform operation on numbers
            decimal result;
            switch (calculation.operation)
            {
                case '+':
                    result = (decimal)(calculation.number1 + calculation.number2);
                    break;

                case '-':
                    result = (decimal)(calculation.number1 - calculation.number2);
                    break;

                case 'x':
                    result = (decimal)(calculation.number1 * calculation.number2);
                    break;

                case '%':
                    // Check pre-emptively for a divide by 0
                    if (calculation.number1 == 0 || calculation.number2 == 0)
                    {
                        return NotFound(new
                        {
                            message = "Please ensure both values do not contain 0 when performing division"
                        });
                    }

                    result = (decimal)(calculation.number1 / calculation.number2);
                    break;

                default:
                    return NotFound(new
                    {
                        message = "Invalid operation found. Please ensure operation is +|-|x|%"
                    });
            }

            return Ok(new{
                result = result
            });
        }
    }
}