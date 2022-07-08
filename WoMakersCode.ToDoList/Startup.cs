using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMakersCode.ToDoList.Application.Mappings;
using WoMakersCode.ToDoList.Application.Models;
using WoMakersCode.ToDoList.Application.UseCases;
using WoMakersCode.ToDoList.Core.DTOs;
using WoMakersCode.ToDoList.Core.Filters;
using WoMakersCode.ToDoList.Core.Repositories;
using WoMakersCode.ToDoList.Core.Services;
using WoMakersCode.ToDoList.Infra.Database;
using WoMakersCode.ToDoList.Infra.Repositories;
using WoMakersCode.ToDoList.Infra.Services;

namespace WoMakersCode.ToDoList
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
            services.AddTransient<IUseCaseAsync<TaskListRequest, TaskListResponse>, InsertTodoListUseCase>();
            services.AddTransient<IUseCaseAsync<GetFilter, TaskListResponse>, GetTodoListUseCase>();
            services.AddTransient<IUseCaseAsync<TaskRequest, TaskResponse>, InsertTaskDetailUseCase>();
            services.AddTransient<IUseCaseAsync<TaskListRequest, TaskListResponse>, UpdateTaskListUseCase>();
            services.AddTransient<IRepository, ToDoListRepository>();
            services.AddTransient<ApplicationContext>();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<IWeatherService, WeatherService>();
            services.AddTransient<IUseCaseAsync<string, WeatherDTO>, GetWeatherForecastUseCase>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WoMakersCode.ToDoList", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WoMakersCode.ToDoList v1"));
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
