using AutoMapper;
using InimcoBackend.Configuration.Options;
using InimcoBackend.Profiles;
using InimcoBackend.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.AllowAnyHeader();
            builder.WithOrigins("http://localhost:4200");
        });
});

var mapperConfig = new MapperConfiguration(mapperConfig =>
{
    mapperConfig.AddProfile(new ProfileMappingProfile());
});

var mapper = mapperConfig.CreateMapper();

builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection("ConnectionStrings"));

builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<IProfileRepository, ProfileRepository>();

var app = builder.Build();

// Fetch the service so caching is done on startup
_ = app.Services.GetService<IProfileRepository>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
}
else
{
    app.UseExceptionHandler(appBuilder =>
    {
        appBuilder.Run(async context =>
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
        });
    });
}

// Both release & development will allow localhost:4200
// Can be changed by using different policies.
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
