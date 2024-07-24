using Bloggie.Data;
using Bloggie.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register HttpClient for ChatGPTService
builder.Services.AddHttpClient<ChatGPTService>(client =>
{
    client.BaseAddress = new Uri("https://api.openai.com/v1/");
});

// Register ChatGPTService with API key
builder.Services.AddTransient<ChatGPTService>(sp =>
{
    var client = sp.GetRequiredService<HttpClient>();
    var apiKey = builder.Configuration["ChatGPT:ApiKey"];
    return new ChatGPTService(client, apiKey);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
