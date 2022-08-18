using distributed_calculator.Controllers;
using distributed_calculator.CreateJob;
using distributed_calculator.Registration;
using distributed_calculator.Services;
using Emmersion.Http;
using HttpClient = Emmersion.Http.HttpClient;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("*")
                .AllowAnyHeader()
                .AllowAnyMethod();;
        });
});
builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddTransient<IRegistrationService, RegistrationService>();
builder.Services.AddTransient<ICreateJobService, CreateJobService>();
builder.Services.AddTransient<IHttpClient, HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
