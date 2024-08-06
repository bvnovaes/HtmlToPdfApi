using HtmlToPdfApi.Infrastructure.Services;
using Moq;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;

namespace HtmlToPdfApiTests
{
    public class UrlToPdfServiceTests
    {
        [Fact]
        public async Task ConvertUrlToPdf_ShouldReturnPdfBytes()
        {
            // Arrange
            var mockConverter = new Mock<IConverter>();
            var urlToPdfService = new UrlToPdfService(mockConverter.Object);
            var orientation = Orientation.Portrait;
            var paperKind = PaperKind.A4;

            // Simule a conversão (substitua pelo comportamento real do DinkToPdf)
            var expectedPdfBytes = new byte[] { 1, 2, 3 };
            mockConverter.Setup(c => c.Convert(It.IsAny<HtmlToPdfDocument>()))
                         .Returns(expectedPdfBytes);

            var url = "https://www.google.com";

            // Act
            var pdfBytes = await urlToPdfService.ConvertUrlToPdfAsync(url, orientation, paperKind);

            // Assert
            Assert.NotNull(pdfBytes);
            Assert.Equal(expectedPdfBytes, pdfBytes);
        }
    }
}
