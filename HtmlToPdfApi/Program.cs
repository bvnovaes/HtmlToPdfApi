using HtmlToPdfApi.Core.Interfaces;
using HtmlToPdfApi.Infrastructure.Services;
using WkHtmlToPdfDotNet;
using WkHtmlToPdfDotNet.Contracts;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//WkHtmlToPdfDotNet
builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
builder.Services.AddScoped<IHtmlToPdfService, HtmlToPdfService>();
builder.Services.AddScoped<IUrlToPdfService, UrlToPdfService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();