using flipProject.Helpers;
using flipProject.Interface;
using flipProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IBookServices, BookServices>();
builder.Services.AddScoped<IFirstApi, FirstApiServices>();
builder.Services.AddTransient(typeof(SQLHelper));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
    builder => builder.AllowAnyOrigin()
    .AllowAnyMethod()
   .AllowAnyHeader()
   );
});

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
