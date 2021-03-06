﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace CoinWallet.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseKestrel(options =>
                    {
                        // Set properties and call methods on options
                    })
                    .UseUrls("http://0.0.0.0:7888")
                .UseStartup<Startup>();
    }
}
