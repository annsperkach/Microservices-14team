using Microsoft.EntityFrameworkCore;
using PostService.Models;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Newtonsoft.Json.Linq;
using System.Text;
namespace PostService
{
    public class Program
    {
        public static void Main(string[] args)
        {
           // ListenForIntegrationEvents();
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<PostServiceContext>(options =>
              options.UseSqlServer(builder.Configuration.GetConnectionString("PostServiceContext")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //        builder.Services.AddDbContext<UserServiceContext>(options =>
            //options.UseSqlite(@"Data Source=user.db"));
            builder.Services.AddCors(options => options.AddPolicy(name: "PurchaseOrigins",
               policy =>
               {
                   policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
               }));
            //       builder.Services.AddDbContext<PostServiceContext>(options =>
            //options.UseSqlite(@"Data Source=post.db"));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
    }}

    