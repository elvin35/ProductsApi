using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ProductsApi;

public class Programm
{
    static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }



    static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBulder =>
                webBulder.UseStartup<Startup>());



}