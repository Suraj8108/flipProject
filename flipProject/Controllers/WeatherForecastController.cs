using flipProject.Interface;
using flipProject.Services;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace flipProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        //public TelemetryClient telemetry;
        public readonly IBookServices _bookservice;
        public readonly IFirstApi _firstapi;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBookServices bookService, IFirstApi firstapiservice)
        {
            _logger = logger;
            _bookservice = bookService;
            _firstapi = firstapiservice;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("[action]")]
        public string PostCheck(int BookId)
        {
            try
            {
                DataTable result = _bookservice.GetAllData(BookId);
                string json = JsonConvert.SerializeObject(result);
                return json;
            }
            catch(Exception e)
            { 
                return null;
            }
        }

        [HttpPost]
        [Route("[action]")]

        public string InsertBook(int BookId, string Title, string Author, string Description)
        {
            try
            {
                DataTable result = _bookservice.InsertData(BookId, Title, Author, Description);
                string json = JsonConvert.SerializeObject(result);
                return json;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpGet]
        [Route("[action]")]
        public string GetFirstData()
        {
            try
            {
                DataTable result = _firstapi.GetAllData();
                string json = JsonConvert.SerializeObject(result);
                return json;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        [Route("[action]")]

        public string InsertFirstData(string Daytime, string Domain, int Stpid, int Mtpid, string DomainExcelSheet, int Piaca_PartnerOneId, string piaca_DownloadExcelSheet)
        {
            try
            {
                DataTable result = _firstapi.InsertData( Daytime, Domain, Stpid, Mtpid, DomainExcelSheet, Piaca_PartnerOneId, piaca_DownloadExcelSheet);
                string json = JsonConvert.SerializeObject(result);
                return json;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}