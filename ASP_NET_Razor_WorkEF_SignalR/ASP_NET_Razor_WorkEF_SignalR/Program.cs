using ASP_NET_Razor_WorkEF_SignalR.Hubs;
using ASP_NET_Razor_WorkEF_SignalR.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddDbContext<PRN221_DBSampleContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("StrConnection"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<SignalRServer>("/hub"); // Ánh xạ hoạt động của web app với Hub server của SignalR

app.Run();
