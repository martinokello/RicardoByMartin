using Ricardo.Plugins.BankAccount;
using Ricardo.Plugins.BankAccount.Interfaces;
using Ricardo.Plugins.Inventory;
using Ricardo.Plugins.Inventory.Interfaces;
using Ricardo.Plugins.Repositories.Interfaces;
using Ricardo.Plugins.Services;
using Ricardo.Plugins.Services.Interfaces;
using Ricardo.Plugins.Utility;
using Ricardo.Services.Repositories;
using Ricardo.Technical.Test.Utility;
using Ricardo.Technical.Test.Infrastructure;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession((configure) =>{});
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorBootstrap();
builder.Services.AddScoped<Navigation>();
builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ICustomerService,CustomerService>();
builder.Services.AddScoped<IBankAccountServices, BankAccount>();
builder.Services.AddScoped<IInventoryServices, Inventory>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<SessionManager>();
builder.Services.AddScoped<SignInOutState>();
builder.Services.AddScoped<LoggedInUserState>(); 
builder.Services.AddScoped(sp =>
	new HttpClient
	{
		BaseAddress = new Uri("https://localhost:7074/")
	});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
	endpoints.MapControllers();
});

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
