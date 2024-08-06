using WkHtmlToPdfDotNet;

namespace HtmlToPdfApi.Core.Interfaces
{
    public interface IUrlToPdfService
    {
        Task<byte[]> ConvertUrlToPdfAsync(string page, Orientation orientation, PaperKind paperKind);
    }
}
