using GraphiQl;
using GraphQL;
using GraphQL.Server;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using RealEstateManager;
using RealEstateManager.DataAccess.Repositories;
using RealEstateManager.Database;
using RealEstateManager.Queries;
using RealEstateManager.Schema;
using RealEstateManager.Types;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RealEstateContext>(
    options => options.UseSqlServer(builder.Configuration["ConnectionStrings:ReasEstateDb"]));

builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<RealEstateSchema>();
builder.Services.AddGraphQL()
    .AddSystemTextJson()
    .AddGraphTypes(typeof(RealEstateSchema), ServiceLifetime.Scoped);

builder.Services.AddScoped<PropertyQuery>();
builder.Services.AddSingleton<PropertyType>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    RealEstateSeedData.EnsureSeedData(services); // Call your seed data method here
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//app.UseGraphQLAltair("/graphql2");
//app.UseGraphiQl("/graphql");
//app.UseGraphQLGraphiQL("/graphql");

app.UseGraphQL<RealEstateSchema>();
app.UseGraphQLPlayground();

app.UseHttpsRedirection();

app.UseMiddleware<GlobalExceptionMiddleware>();
app.UseAuthorization();
app.MapControllers();


app.Run();
