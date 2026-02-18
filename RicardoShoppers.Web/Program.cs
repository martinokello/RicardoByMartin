using Ricardo.Models;
using RicardoShoppers.Web.Components;
using RicardoShoppers.Web.Infrastructure;

namespace RicardoShoppers.Web
{
    public class Program
    {
        public static IEnumerable<Item> StoreProducts { get; set; } = new List<Item>
        {
            new Item
            {
                Id = 1,
                Name = "Gold Cross",
                Image = "",
                InventoryQuantity = 20,
                Price = 20
            },
            new Item
            {
                Id = 2,
                Name = "Clock",
                Image="",
                InventoryQuantity = 12,
                Price = 6
            },
            new Item
            {
                Id = 3,
                Name = "Globe",
                Image="",
                InventoryQuantity = 7,
                Price = 8
          },
            new Item
            {
                Id = 4,
                Name = "Watch",
                Image="",
                InventoryQuantity = 15,
                Price = 16
            },
            new Item
            {
                Id = 5,
                Name = "Parker Pen",
                Image="",
                InventoryQuantity = 15,
                Price = 12
            }
        };
        public static void Main(string[] args)
        {
            //Create New Products

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddSingleton<Basket>(option => { return new Basket(); });
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
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
