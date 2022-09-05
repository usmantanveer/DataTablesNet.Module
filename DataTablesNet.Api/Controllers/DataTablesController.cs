using DataTablesNet.Module;
using DataTablesNet.Module.Helpers;
using DataTablesNet.Module.Response;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DataTablesNet.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class DataTablesController : ControllerBase {
        [HttpPost]
        public IActionResult Index([FromForm] DTRequest request) {
            var data = PrepareSampleResponse(500);
            data = DTHelper.PrepareResult(data, request, out int totalRecords, out int filteredRecords);

            return Ok(new DTResponse<WeatherForecast> {
                RecordsTotal = totalRecords,
                RecordsFiltered = filteredRecords,
                Draw = request.Draw,
                Data = data
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
