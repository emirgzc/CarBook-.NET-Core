using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandler.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.AboutHandler.Write;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandler.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.BannerHandler.Write;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandler.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.BrandHandler.Write;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandler.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.CarHandler.Write;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandler.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.CategoryHandler.Write;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandler.Read;
using UdemyCarBook.Application.Features.CQRS.Handlers.ContactHandler.Write;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Persistence.Context;
using UdemyCarBook.Persistence.Repositories;
using UdemyCarBook.Persistence.Repositories.CarRepository;
using UdemyCarBook.Application.Services;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Persistence.Repositories.BlogRepositories;
using UdemyCarBook.Application.Interfaces.CarPricingInterfaces;
using UdemyCarBook.Persistence.Repositories.CarPricingRepositories;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Persistence.Repositories.TagCloudRepositories;
using UdemyCarBook.Application.Features.RepositoryPattern;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Repositories.CommentRepositories;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Persistence.Repositories.StatisticsRepositories;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Persistence.Repositories.RentACarRepositories;
using UdemyCarBook.Application.Interfaces.CarFeatureInterfaces;
using UdemyCarBook.Persistence.Repositories.CarFeatureRepositories;
using UdemyCarBook.Application.Interfaces.CarDescriptionInterfaces;
using UdemyCarBook.Persistence.Repositories.CarDescriptionRepositories;
using UdemyCarBook.Application.Interfaces.ReviewInterfaces;
using UdemyCarBook.Persistence.Repositories.ReviewRepositories;
using FluentValidation.AspNetCore;
using System.Reflection;
using UdemyCarBook.Application.Validators.ReviewValidators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UdemyCarBook.Application.Tools;
using UdemyCarBook.WebApi.Hubs;

var builder = WebApplication.CreateBuilder(args);

//signalr
builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", builder =>
	{
		builder.AllowAnyHeader()
		.AllowAnyMethod()
		.SetIsOriginAllowed((host) => true)
		.AllowCredentials();
	});
});
builder.Services.AddSignalR();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
	opt.RequireHttpsMetadata = false;
	opt.TokenValidationParameters = new TokenValidationParameters
	{
		ValidAudience = JwtTokenDefaults.ValidAudiance,
		ValidIssuer = JwtTokenDefaults.ValidIssuer,
		ClockSkew = TimeSpan.Zero,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true
	};
});

// Add services to the container.

builder.Services.AddScoped<CarBookContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
builder.Services.AddScoped(typeof(IBlogRepository), typeof(BlogRepository));
builder.Services.AddScoped(typeof(ICarPricingRepository), typeof(CarPricingRepository));
builder.Services.AddScoped(typeof(ITagCloudRepository), typeof(TagCloudRepository));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));
builder.Services.AddScoped(typeof(IStatisticsRepository), typeof(StatisticRepository));
builder.Services.AddScoped(typeof(IRentACarRepository), typeof(RentACarRepository));
builder.Services.AddScoped(typeof(ICarFeatureRepository), typeof(CarFeatureRepository));
builder.Services.AddScoped(typeof(ICarDescriptionRepository), typeof(CarDescriptionRepository));
builder.Services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));


builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLastFiveCarWithBrandQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddApplicationService(builder.Configuration);


#pragma warning disable CS0618 // Tür veya üye artýk kullanýlmýyor
// validator
builder.Services.AddControllers().AddFluentValidation(x =>
{
	x.ImplicitlyValidateChildProperties = true;
	x.ImplicitlyValidateRootCollectionElements = true;
	x.RegisterValidatorsFromAssemblyContaining<CreateReviewValidator>();
	x.RegisterValidatorsFromAssemblyContaining<UpdateReviewValidator>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//signalr
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

//signalr
app.MapHub<CarHub>("/carhub");

app.Run();
