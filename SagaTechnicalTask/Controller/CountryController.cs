using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SagaTechnicalTask.Models;
using System.Diagnostics.Metrics;

namespace SagaTechnicalTask.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {

        private static List<Countries> countryList = new List<Countries>
            {
                new Countries
                {
                    Country = "United Kingdom",
                    Code = "UK"
                },
                new Countries
                {
                    Country = "America",
                    Code = "USA"
                },
                new Countries
                {
                    Country = "Australia",
                    Code = "AUS"
                },
                new Countries
                {
                    Country = "Canada",
                    Code = "CA"
                },
                new Countries
                {
                    Country = "Belgium",
                    Code = "BE"
                },
                new Countries
                {
                    Country = "Denmark",
                    Code = "DK"
                },
                new Countries
                {
                    Country = "France",
                    Code = "FR"
                },
                new Countries
                {
                    Country = "Germany",
                    Code = "DEU"
                },
            };


        [HttpGet]
        public ActionResult<List<Countries>> GetListOfCountries()
        {
            return Ok(countryList); // gives status code 200
        }

        
        [HttpGet("{countryCode}")] // retrieving a country by country code
        public ActionResult<List<Countries>> GetCountryByCode(string countryCode)
        {
            var code = countryList.Find(x => x.Code == countryCode);
            if (code == null)
            {
                return NotFound("The entered country doesn't exist");
            }
            return Ok(code);
        }

        [HttpPost]
        public ActionResult<List<Countries>> AddCountry(Countries newCountry)
        {
            countryList.Add(newCountry);
            return Ok(countryList); // gives status code 200
        }

        [HttpPut("{countryCode}")] // retrieving a country by country code
        public ActionResult<List<Countries>> UpdateCountry(string countryCode, Countries request)
        {
            var name = countryList.Find(x => x.Code == countryCode);
            if (name == null)
            {
                return NotFound("The entered country doesn't exist");
            }

            name.Country = request.Country;
            name.Code = request.Code;
            
            return Ok(countryList);
        }

        [HttpDelete("{countryCode}")] // removes a country from the list
        public ActionResult<List<Countries>> DeleteCountry(string countryCode)
        {
            var name = countryList.Find(x => x.Code == countryCode);
            if (name == null)
            {
                return NotFound("The entered country doesn't exist");
            }

            countryList.Remove(name);
            return Ok(countryList);
        }
    }
}
