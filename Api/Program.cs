
using Abstractions.Interface;
using Api.Controllers.Movies;
using Application.Features.CQRS_DesignPattern.Command.CategoryCommand;
using Application.Features.CQRS_DesignPattern.Handlers.CategoryHandlers;
using Application.Features.CQRS_DesignPattern.Handlers.MovieHandlers;
using Application.Features.MediatorDesignPattern.Handlers.MovieHandlers;
using Application.Features.MediatorDesignPattern.Handlers.TagHandlers;
using Application.Interface;
using Application.Mapping;
using ExternalService.Service;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Persistence.Context;
using Persistence.Interface;
using Persistence.Repository;
using System.Reflection;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MyContext>();
            

            builder.Services.AddScoped<CreateMovieCommandHandler>();
            builder.Services.AddScoped<DeleteMovieCommandHandler>();
            builder.Services.AddScoped<UpdateMovieCommandHandler>();
            builder.Services.AddScoped<GetMovieByIdQueryHandler>();
            builder.Services.AddScoped<GetMovieQueryHandler>();

            builder.Services.AddScoped<CreateCategoryCommandHandler>();
            builder.Services.AddScoped<DeleteCategoryCommandHandler>();
            builder.Services.AddScoped<UpdateCategoryCommandHandler>();
            builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
            builder.Services.AddScoped<GetCategoryQueryHandler>();
            builder.Services.AddScoped<IExternalApiService, ExternalApiService>();
            builder.Services.AddHttpClient<IExternalApiService, ExternalApiService>();
            builder.Services.AddAutoMapper(typeof(GetMovieListQueryHandler).Assembly);

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            
           

            


            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTagQueryHandler).Assembly));
            

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>

                c.SwaggerDoc("v1",new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title ="MyApi"
                })

            );
            

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
               app.UseSwagger();
                app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json","MyApiV1")

                );

            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
