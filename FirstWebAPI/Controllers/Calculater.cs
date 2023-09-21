using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Calculater : ControllerBase
    {
        //api/calculater/add?x=10&y=20
        [HttpGet("/add")]
        public int Add(int x, int y)
        {
            return x + y;   
        }
        [HttpGet("/sum")]
        public int Sum(int x, int y)
        {
            return x + y +1000;
        }
        //api/calculater/subtract?x=200&y=10
        [HttpPut]
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        //api/calculater/Multily?x=200&y=10
        [HttpPost]
        public int Multiply(int x, int y)
        {
            return x * y;
        }
        [HttpDelete]
        //api/calculater/Divide?x=10&y=10
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
