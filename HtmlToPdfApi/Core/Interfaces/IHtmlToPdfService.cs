using WkHtmlToPdfDotNet;

namespace HtmlToPdfApi.Core.Interfaces
{
    public interface IHtmlToPdfService
    {
        Task<byte[]> ConvertHtmlToPdfAsync(string htmlContent, Orientation orientation, PaperKind paperKind);
    }
}
