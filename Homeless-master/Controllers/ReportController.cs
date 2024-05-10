using Microsoft.AspNetCore.Mvc;
using Homeless.Repositories;
using Homeless.Database.Models;
using ClosedXML.Excel;

namespace Homeless.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : Controller
    {
        private readonly IHomelessMessageRepository _homelessRepository;

        public ReportController(IHomelessMessageRepository homelessRepository)
        {
            _homelessRepository = homelessRepository;
        }

        [HttpGet]
        [Route("homeless-report")]
        public IActionResult HomelessMessageCount()
        {
            var messagesCount = _homelessRepository.GetAll().Count();
            var reportModel = new ReportModel
            {
                HomelessMessageCount = messagesCount
            };

            using (XLWorkbook workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Информация о бездомных");
                worksheet.Cell("A1").Value = "Количество сообщений о бездомных";         
                worksheet.Row(1).Style.Font.Bold = true;
                worksheet.Cell("A2").Value = reportModel.HomelessMessageCount;

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    stream.Flush();

                    return File(stream.ToArray(),
                        "application/vnd.ms-excel",
                    "homelessInfo_{DateTime.UtcNow.ToShortDateString()}.xlsx");

                }
            }

        }

        
    }
}
