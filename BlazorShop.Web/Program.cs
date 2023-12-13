using BlazorShop.Web;
using BlazorShop.Web.Services;
using BlazorShop.Web.Services.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string baseUrl = "https://localhost:7155";

// Url base para servi�o de acesso via HttpCliente, usando a inje��o de dependencia do ASP .Net
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUrl) });

builder.Services.AddScoped<IProdutoService, ProdutoService>();

await builder.Build().RunAsync();
