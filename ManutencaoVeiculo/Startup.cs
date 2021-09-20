using ManutencaoVeiculo.Application.Interfaces;
using ManutencaoVeiculo.Application.Services;
using ManutencaoVeiculo.Data;
using ManutencaoVeiculo.Infra.Interfaces;
using ManutencaoVeiculo.Infra.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace ManutencaoVeiculo
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
            services.AddDbContext<ManutencaoContext>(opts => opts.UseMySQL(Configuration.GetConnectionString("ManutencaoConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ManutencaoVeiculo", Version = "v1" });
            });

            services.AddScoped<IVeiculoService, VeiculoServices>();
            services.AddScoped<IPessoaService, PessoaServices>();
            services.AddScoped<IManutencaoService, ManutencaoServices>();
            services.AddScoped<IManutencaoRepository, ManutencaoRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Manutenção de Veículo v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
