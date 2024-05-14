using Business.Abstract;
using Business.Concrete;
using Core.Repository;
using Core.Repository.EntityFramework;
using Core.Security;
using Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Service.Context;
using Service.Services.Abstract;
using Service.Services.Concrete;
using System.Text;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<IEntityRepositoryBase<Product>, EfEntityRepositoryBase<Product, ECommerceDbContext>>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductBusiness, ProductBusiness>();
            

            builder.Services.AddScoped<IEntityRepositoryBase<Categorie>, EfEntityRepositoryBase<Categorie, ECommerceDbContext>>();
            builder.Services.AddScoped<ICategorieService, CategorieService>();
            builder.Services.AddScoped<ICategorieBusiness, CategorieBusiness>();

            builder.Services.AddScoped<IEntityRepositoryBase<Favorite>, EfEntityRepositoryBase<Favorite, ECommerceDbContext>>();
            builder.Services.AddScoped<IFavoriteService, FavoriteService>();
            builder.Services.AddScoped<IFavoriteBusiness, FavoriteBusiness>();
            
            builder.Services.AddScoped<IEntityRepositoryBase<User>, EfEntityRepositoryBase<User, ECommerceDbContext>>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserBusiness, UserBusiness>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenHandler, Core.Security.TokenHandler>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
              options =>
              {
                  options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                  {
                      ValidateAudience = true,
                      ValidateIssuer = true,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ValidIssuer = builder.Configuration["Token:Issuer"],
                      ValidAudience = builder.Configuration["Token:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
                      ClockSkew = TimeSpan.Zero
                  };
              });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}