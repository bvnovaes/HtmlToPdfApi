using HtmlToPdfApi.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WkHtmlToPdfDotNet;

namespace HtmlToPdfApi.Controllers
{
    [ApiController]
    [Route("/v1/htmlparapdf")]
    public class HtmlToPdfController(IHtmlToPdfService htmlToPdfService) : ControllerBase
    {
        private readonly IHtmlToPdfService _htmlToPdfService = htmlToPdfService;

        [HttpPost]
        [Route("converter")]
        public async Task<IActionResult> ConvertHtmlToPdf([FromBody] string html)
        {
            try
            {
                var orientation = Orientation.Portrait;
                var paperKind = PaperKind.A4;

                var pdfBytes = await _htmlToPdfService.ConvertHtmlToPdfAsync(html, orientation, paperKind);

                return File(pdfBytes, "application/pdf");
            }
            catch
            {
                return Problem(html);
            }
        }
    }
}
