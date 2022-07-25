using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using TallerTest.Domain.Aggregations.CarAgg;
using TallerTest.Domain.Seedwork;
using TallerTest.Infra.Repositories;
using TallerTest.Domain.Aggregations.MakeAgg;
using System.Text.Json.Serialization;
using TallerTest.WebApi.Infra;
using AutoMapper;
using TallerTest.Domain.Services;

namespace TallerTest.WebApi
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
            services.AddAutoMapper(typeof(Startup));

            var mapperConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new DtoToEntityProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());


            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<UnitOfWork>(o => {
                o.UseInMemoryDatabase("tallerDb", a =>
                {
                });
            });

            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IMakeRepository, MakeRepository>();
            services.AddScoped<IUserService, UserService>();


            

            var uow = services.BuildServiceProvider().GetRequiredService<UnitOfWork>();
            uow.Car.AddRange(
                 new Car { Id = 1, MakeId = 1, Name = "R8", Year = 2018, Doors = 2, Color = "Red", Price = 79995 },
                new Car { Id = 2, MakeId = 2, Name = "3", Year = 2018, Doors = 4, Color = "Black", Price = 54995 },
                new Car { Id = 3, MakeId = 3, Name = "911 991", Year = 2020, Doors = 2, Color = "White", Price = 155000 },
                new Car { Id = 4, MakeId = 4, Name = "GLE 63S", Year = 2021, Doors = 5, Color = "Blue", Price = 83995 },
                new Car { Id = 5, MakeId = 5, Name = "X6 M", Year = 2020, Doors = 5, Color = "Silver", Price = 62995 }
                );

            uow.Make.AddRange(
                      new Make { Id = 1, Name = "Audi" },
                new Make { Id = 2, Name = "Tesla" },
                new Make { Id = 3, Name = "Porsche" },
                new Make { Id = 4, Name = "Mercedes-Benz" },
                new Make { Id = 5, Name = "BMW" }
                );

            uow.SaveChanges();




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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "taller test");
            });

            app.UseRouting();

            app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials());


        app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
