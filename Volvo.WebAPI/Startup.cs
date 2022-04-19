using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volvo.Domain;
using Volvo.Repository;
using Volvo.Repository.Context;
using Volvo.Repository.Interface;
using Volvo.Repository.Query;
using Volvo.Services;
using Volvo.WebAPI.Models;

namespace Volvo.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration _configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<IConfiguration>(_configuration);
            services.AddSingleton<VolvoContext, VolvoContext>();

            services.AddTransient<ICommandHandler<CaminhaoModel>, CaminhaoService>();
            services.AddTransient<ICommand<CaminhaoModel>, CaminhaoCommand>();
            services.AddTransient<IQuery<CaminhaoModel>, CaminhaoQuery>();

            // automapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CaminhaoViewModel, CaminhaoModel>().ReverseMap();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // configuração do swagger
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // configuração do swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Volvo");
            });
        }
    }
}