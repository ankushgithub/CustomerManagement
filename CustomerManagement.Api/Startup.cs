using CustomerManagement.Application;
using CustomerManagement.Application.Exceptions;
using CustomerManagement.Db;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CustomerManagement.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddDatabaseServices();
            services.AddValidationServices();
            services.AddControllers().AddFluentValidation();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "CustomerManagement.Api", Version = "v1.0" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "CustomerManagement.Api v1.0"));
            }

            app.UseHttpsRedirection();

            app.UseExceptionHandler(options => options.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerPathFeature>();
                await context.Response.WriteAsJsonAsync(new { error = exception.Error.Message });
            }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}