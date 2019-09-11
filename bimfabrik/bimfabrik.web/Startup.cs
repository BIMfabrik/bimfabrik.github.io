using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SpaServices.Webpack;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.AspNetCore.Http.Features;

namespace bimfabrik
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.Configure<IISServerOptions>(options =>
            //{
            //    options.AutomaticAuthentication = false;
            //});

            services.AddHttpClient();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration config)
        {
            app.UseDeveloperExceptionPage();
            /*if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }*/

            //if (env.IsDevelopment())
            //{
            //    app.Run(async (context) =>
            //    {
            //        var sb = new StringBuilder();
            //        var nl = System.Environment.NewLine;
            //        var rule = string.Concat(nl, new string('-', 40), nl);
            //        var authSchemeProvider = app.ApplicationServices
            //            .GetRequiredService<IAuthenticationSchemeProvider>();

            //        sb.Append($"Request{rule}");
            //        sb.Append($"{DateTimeOffset.Now}{nl}");
            //        sb.Append($"{context.Request.Method} {context.Request.Path}{nl}");
            //        sb.Append($"Scheme: {context.Request.Scheme}{nl}");
            //        sb.Append($"Host: {context.Request.Headers["Host"]}{nl}");
            //        sb.Append($"PathBase: {context.Request.PathBase.Value}{nl}");
            //        sb.Append($"Path: {context.Request.Path.Value}{nl}");
            //        sb.Append($"Query: {context.Request.QueryString.Value}{nl}{nl}");

            //        sb.Append($"Connection{rule}");
            //        sb.Append($"RemoteIp: {context.Connection.RemoteIpAddress}{nl}");
            //        sb.Append($"RemotePort: {context.Connection.RemotePort}{nl}");
            //        sb.Append($"LocalIp: {context.Connection.LocalIpAddress}{nl}");
            //        sb.Append($"LocalPort: {context.Connection.LocalPort}{nl}");
            //        sb.Append($"ClientCert: {context.Connection.ClientCertificate}{nl}{nl}");

            //        sb.Append($"Identity{rule}");
            //        sb.Append($"User: {context.User.Identity.Name}{nl}");
            //        var scheme = await authSchemeProvider
            //            .GetSchemeAsync(IISDefaults.AuthenticationScheme);
            //        sb.Append($"DisplayName: {scheme?.DisplayName}{nl}{nl}");

            //        sb.Append($"Headers{rule}");
            //        foreach (var header in context.Request.Headers)
            //        {
            //            sb.Append($"{header.Key}: {header.Value}{nl}");
            //        }
            //        sb.Append(nl);

            //        sb.Append($"Websockets{rule}");
            //        if (context.Features.Get<IHttpUpgradeFeature>() != null)
            //        {
            //            sb.Append($"Status: Enabled{nl}{nl}");
            //        }
            //        else
            //        {
            //            sb.Append($"Status: Disabled{nl}{nl}");
            //        }

            //        sb.Append($"Configuration{rule}");
            //        foreach (var pair in config.AsEnumerable())
            //        {
            //            sb.Append($"{pair.Key}: {pair.Value}{nl}");
            //        }
            //        sb.Append(nl);

            //        sb.Append($"Environment Variables{rule}");
            //        var vars = System.Environment.GetEnvironmentVariables();
            //        foreach (var key in vars.Keys.Cast<string>().OrderBy(key => key,
            //            StringComparer.OrdinalIgnoreCase))
            //        {
            //            var value = vars[key];
            //            sb.Append($"{key}: {value}{nl}");
            //        }

            //        context.Response.ContentType = "text/plain";
            //        await context.Response.WriteAsync(sb.ToString());
            //    });
            //}

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
