using HtmlToPdfApi.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WkHtmlToPdfDotNet;

namespace HtmlToPdfApi.Controllers
{
    [ApiController]
    [Route("/v1/urlparapdf")]
    public class UrlToPdfController(IUrlToPdfService urlToPdfService) : Controller
    {
        private readonly IUrlToPdfService _urlToPdfService = urlToPdfService;

        [HttpPost]
        [Route("converter")]
        public async Task<IActionResult> ConvertUrlToPdf([FromBody] string url)
        {
            try
            {
                var orientation = Orientation.Portrait;
                var paperKind = PaperKind.A4;

                var pdfBytes = await _urlToPdfService.ConvertUrlToPdfAsync(url, orientation, paperKind);

                return File(pdfBytes, "application/pdf");
            }
            catch
            {
                return Problem(url);
            }
        }
    }
}
