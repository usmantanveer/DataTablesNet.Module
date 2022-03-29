using DataTablesNet.Module;
using DataTablesNet.Module.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DataTablesNet.Api.Controllers {
   [ApiController]
   [Route("[controller]")]
   public class DataTablesController : ControllerBase {
      [HttpPost]
      public IActionResult Index([FromForm] DTRequest request) {
         var data = PrepareSampleResponse(500);
         int recordsTotal = data.Count();
         int recordsFiltered = recordsTotal;

         if (!string.IsNullOrWhiteSpace(request.Search.Value)) {
          data = data.Where(d => d.ToString().IndexOf(request.Search.Value) > -1);
            recordsFiltered = data.Count();
         }
         return Ok(new DTResponse<WeatherForecast> {
            RecordsTotal = recordsTotal,
            RecordsFiltered = recordsFiltered,
            Draw = request.Draw,
            Data = data.Skip(request.Start).Take(request.Length)
         });
      }

      private IEnumerable<WeatherForecast> PrepareSampleResponse(int records) {
         for (int i = 1; i <= records; i++) {
            yield return new WeatherForecast {
               Date = System.DateTime.Now.AddDays(i).ToString("dd-MM-yyyy"),
               Summary = $"This is summary for - {i}.",
               TemperatureC = i,
            };
         }
      }
   }   
}
