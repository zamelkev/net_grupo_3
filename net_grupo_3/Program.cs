using net_grupo_3.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MYSQL connection
// create MySQL DB setting

string url = "server=localhost;port=3306;user=root;password=admin;database=ecomerce";
builder.Services.AddDbContext<AppDbContext>
    (
        options => options.UseMySql(url, ServerVersion.AutoDetect(url))
    );

// Add repos
builder.Services.AddScoped<IProductRepository, ProductDbRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryDbRepository>();
builder.Services.AddScoped<IClientRepository, ClientDbRepository>();
builder.Services.AddScoped<IProductCommentReporitory, ProductCommentDbRepository>();
builder.Services.AddScoped<IOrderRepository, OrderDbRepository>();
builder.Services.AddScoped<IContainerRepository, ContainerDbRepository>();
builder.Services.AddScoped<IProductCommentReporitory, ProductCommentDbRepository>();

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
