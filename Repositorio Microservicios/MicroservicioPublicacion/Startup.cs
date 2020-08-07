using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APLICACION.SERVICIOS;
using DATOS;
using DATOS.COMANDOS;
using DATOS.QUERYS;
using DOMINIO.COMANDOS;
using DOMINIO.QUERYS;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SqlKata.Compilers;
using Newtonsoft.Json;

namespace MicroservicioPublicacion
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
            services.AddControllers();
            services.AddCors(c => {
                c.AddPolicy("AllowOrigin", options => options
                                                            .AllowAnyOrigin()
                                                            .AllowAnyMethod()
                                                            .AllowAnyHeader());
            });
            var connectionString = Configuration.GetSection("ConnectionString").Value;
           
            services.AddDbContext<Contexto>(opciones => opciones.UseSqlServer(connectionString));
        

            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });

            services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IGenericsRepository, GenericsRepository>();
            services.AddTransient<IPublicacionServicio, PublicacionServicio>();
            services.AddTransient<IComentarioServicio, ComentarioServicio>();
            services.AddTransient<IComentarioPublicacionServicio, ComentarioPublicacionServicio>();
            services.AddTransient<IQueryPublicacion, QueryPublicacion>();
            services.AddTransient<IQueryComentario, QueryComentario>();
            services.AddTransient<IQueryComentarioPublicacion, QueryComentarioPublicacion>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(options => options.AllowAnyOrigin()
                                          .AllowAnyHeader()
                                          .AllowAnyHeader());


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
