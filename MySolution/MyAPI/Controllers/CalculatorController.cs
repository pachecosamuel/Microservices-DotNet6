using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }


        //[Route("sum/{firstNumber}/{secondNumber}")]
        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum([FromRoute] string firstNumber, [FromRoute] string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input");
        }


        [HttpGet("square/{number}")]
        public IActionResult Square([FromRoute] string number)
        {
            if (IsNumeric(number))
            {
                var value = ConvertToDecimal(number);
                var square = Math.Sqrt((double)value);

                return Ok(square);
            }

            return BadRequest("Invalid input");
        }

        [HttpGet("average/{n1}/{n2}/{n3}")]
        public IActionResult Average([FromRoute] string n1, [FromRoute] string n2, [FromRoute] string n3)
        {
            if (IsNumeric(n1) && IsNumeric(n2) && IsNumeric(n3))
            {
                var sum = (ConvertToDecimal(n1) + ConvertToDecimal(n2) + ConvertToDecimal(n3)) / 3;

                return Ok(sum.ToString());
            }

            return BadRequest("Invalid input.");
        }

        private bool IsNumeric(string strNumber)
        {
            bool isNumber = double.TryParse(
                strNumber,
                NumberStyles.Any,
                NumberFormatInfo.InvariantInfo,
                out _);

            return isNumber;
        }


        private decimal ConvertToDecimal(string strNumber)
        {
            if (decimal.TryParse(strNumber, out decimal decimalValue))
            {
                return decimalValue;
            }

            return 0;
        }
    }
}