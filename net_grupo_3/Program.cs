using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using net_grupo_3.Controllers;
using net_grupo_3.Repositories;
using Microsoft.OpenApi.Models;
using System.Text;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// CORS
builder.Services.AddCors(options => {
    /* options.AddPolicy("AllowAll", builder => {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();

    });*/
    options.AddPolicy(name: "frontend", policy => {
        policy.WithOrigins("http://localhost:4200", "http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

// JWT Authorization service (requires NuGet package)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// MYSQL connection
// create MySQL DB setting

string url = builder.Configuration.GetConnectionString("DbContext");
builder.Services.AddDbContext<AppDbContext>
    (
        options => options.UseMySql(url, ServerVersion.AutoDetect(url))
    );

// Add repos
builder.Services.AddScoped<IProductRepository, ProductDbRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryDbRepository>();
builder.Services.AddScoped<IUserRepository, UserDbRepository>();
builder.Services.AddScoped<IProductCommentReporitory, ProductCommentDbRepository>();
builder.Services.AddScoped<IOrderRepository, OrderDbRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailDbRepository>();
builder.Services.AddScoped<IContainerRepository, ContainerDbRepository>();
builder.Services.AddScoped<IShopRepository, ShopDbRepository>();
builder.Services.AddScoped<IManufacturerRepository, ManufacturerDbRepository>();
builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenDbRepository>();
// Services
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IAccountService, AccountService>();
// Seeder
builder.Services.AddScoped<ISeederRepository, SeederDbRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("frontend");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// seeding
AppDbContext context = new AppDbContextFactory().CreateDbContext(null);
ISeederRepository authorRepo = new SeederDbRepository(context);
authorRepo.SeedHardcodedUser();


app.Run();


