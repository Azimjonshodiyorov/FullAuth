
using Auth.Application;
using Auth.Application.MappingProfils;
using Auth.Infrastructure;
using Auth.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Auth.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddControllers();
            builder.Services.AddApplication(builder.Configuration);
            builder.Services.AddDbContext<AuthDbContext>(optionsAction =>
            {
                optionsAction.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddAutoMapper(typeof(AutoMap));
            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {{
                    new OpenApiSecurityScheme()
                    {
                       Reference=new OpenApiReference()
                       {
                           Id="Bearer",
                           Type=ReferenceType.SecurityScheme
                       }
                    },
                    new string[]{}
                }});
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
