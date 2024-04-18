var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "",
    defaults: new { controller = "Home", action = "Index" });

app.MapControllerRoute(
    name: "graduateWork",
    pattern: "GraduateWork/GetPrice",
    defaults: new { controller = "GraduateWork", action = "GetPrice" });

app.MapControllerRoute(
    name: "default",
    pattern: "PassDiscipline/GetPriceForGrade",
    defaults: new { controller = "PassDiscipline", action = "GetPriceForGrade" });





app.Run();
