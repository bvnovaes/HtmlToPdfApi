using HtmlToPdfApi.Core.Interfaces;
using Moq;
using WkHtmlToPdfDotNet;

namespace HtmlToPdfApiTests
{
    public class HtmlToPdfServiceTests
    {
        [Fact]
        public async Task ConvertHtmlToPdf_ShouldReturnPdfBytes()
        {
            // Arrange
            var mockService = new Mock<IHtmlToPdfService>();
            var orientation = Orientation.Portrait;
            var paperKind = PaperKind.A4;
            var htmlContent = "<html><body><h1>Hello, world!</h1></body></html>";

            // Simule a conversão (substitua pelo comportamento real do DinkToPdf)
            var expectedPdfBytes = new byte[] { 1, 2, 3 };
            mockService.Setup(c => c.ConvertHtmlToPdfAsync(It.IsAny<string>(), orientation, paperKind)).ReturnsAsync(expectedPdfBytes);

            
            // Act
            var htmlConverter = mockService.Object;
            var pdfBytes = await htmlConverter.ConvertHtmlToPdfAsync(htmlContent, orientation, paperKind);

            // Assert
            Assert.NotNull(pdfBytes);
            Assert.Equal(expectedPdfBytes, pdfBytes);
        }
    }
}
