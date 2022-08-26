using ConverterWebApi.DataAccessLayer;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.Mvc;
using NCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConverterWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitConverterController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("Unit Converter API");
        }

        [Route("[action]")]
        [HttpPost]
        public IActionResult Convert(ConversionModel conversion)
        {
            try
            {
                if (string.IsNullOrEmpty(conversion.FromUnit))
                {
                    return Ok(new { Error = "Please Enter From Unit." });
                }
                else if (string.IsNullOrEmpty(conversion.ToUnit))
                {
                    return Ok(new { Error = "Please Enter To Unit." });
                }
                else
                {
                    ConversionDAL conversionDAL = new ConversionDAL();
                    string expression = conversionDAL.GetConversionFactor(conversion);
                    if (!string.IsNullOrEmpty(expression))
                    {
                        Expression e = new Expression(expression.Replace("input", conversion.Input));
                        var output = e.Evaluate();
                        return Ok(new { Result = output });
                    }
                    else
                    {
                        return Ok(new { Error = "Invalid FromUnit-ToUnit Combination for Conversion." });
                    }
                }
            }
            catch(Exception ex)
            {
                return Ok(new { Error = ex.Message });
            }
        }
    }
}
