using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly INumberStore _numberStore;

        private readonly ICalculator _calculator;
        public CalculatorController(INumberStore numberStore)
        {
            _numberStore = numberStore;
            _calculator = new Calculator();
        }

        [HttpGet("add")]
        public IActionResult Add()
        {
            return Ok(_calculator.Add(_numberStore.get(1), _numberStore.get(2)));

        }
        [HttpGet("subtract")]
        public IActionResult Subtract()
        {
                return Ok(_calculator.Subtract(_numberStore.get(1), _numberStore.get(2)));
        }

        [HttpGet("multiply")]
        public IActionResult Multiply()
        {
                return Ok(_calculator.Multiply(_numberStore.get(1), _numberStore.get(2)));
        }

        [HttpGet("divide")]
        public IActionResult Divide()
        {
                if (_numberStore.get(2) == 0)
                {
                    return BadRequest("Division by zero is not allowed.");
                }
                    return Ok(_calculator.Divide(_numberStore.get(1), _numberStore.get(2)));
        }

        [HttpGet("position")]
        public IActionResult Position(int location)
        {
            return Ok(_numberStore.get(location));
        }

        [HttpGet("pos1")]
        public IActionResult Pos1(int number)
        {
            _numberStore.store(1, number);
            return Ok(_numberStore.get(1));
        }

        [HttpGet("pos2")]
        public IActionResult Pos2(int number)
        {
            _numberStore.store(2, number);
            return Ok(_numberStore.get(2));
        }

        [HttpGet("clear")]
        public IActionResult Clear(int location)
        {
            if (location == 1)
            {
                _numberStore.store(1,0);
                return Ok(_numberStore.get(1));
            }
            else
            {
                _numberStore.store(2, 0);
                return Ok(_numberStore.get(2));
            }

        }

        [HttpGet("get")]
        public IActionResult Get(int location)
        {
            if (location == 1)
            {
                return Ok(_numberStore.get(1));
            }
            else
            {
                return Ok(_numberStore.get(2));
            }

        }
    }
}
