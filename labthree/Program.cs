
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();
// html
app.MapGet("/hello", () => Results.Content ("<h1> Hello world! </h1>", "text/html"));
// text
app.MapGet("/text", () => Results.Text("One two three", "text/plain"));
// json
app.MapGet("/json", () => new { Message = "Who are you?", Date = DateTime.Now });
// xml
app.MapGet("/xml", () =>
{
    var xml = "<note><message>Hello XML</message></note>";
    return Results.Content(xml, "application/xml");
});
// csv - exel
app.MapGet("/csv", () => Results.Text("Name,Age \nJohn,18 \n Lora,21", "text/csv"));
// binary - vs code
app.MapGet("/binary", () =>
{
    byte[] data = { 1, 2, 3, 4, 5 };
    return Results.File(data, "application/octet-stream", "file.bin");
});
// image from wwwroot
app.MapGet("/image", () => Results.File("wwwroot/image.png", "image.png", "image/png"));
// pdf
app.MapGet("/pdf", () => Results.File("wwwroot/file.pdf", "file.pdf", "application/pdf"));
// 302 and 301
app.MapGet("/redirect", () => Results.Redirect("/hello", permanent: false)); // 302
app.MapGet("/redirect-permanent", () => Results.Redirect("/hello", permanent: true)); // 301
app.Run();
