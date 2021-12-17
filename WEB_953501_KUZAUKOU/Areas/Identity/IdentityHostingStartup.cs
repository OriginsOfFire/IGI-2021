using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WEB_953501_KUZAUKOU.Data;
using WEB_953501_KUZAUKOU.Entities;

[assembly: HostingStartup(typeof(WEB_953501_KUZAUKOU.Areas.Identity.IdentityHostingStartup))]
namespace WEB_953501_KUZAUKOU.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}