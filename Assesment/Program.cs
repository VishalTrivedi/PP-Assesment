using Assesment.Data;
using Assesment.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMvc();

// Add app specific services
builder.Services.AddTransient<IAvatarImageRepository, AvatarImageRepository>();
builder.Services.AddTransient<IAvatarData, AvatarData>();
builder.Services.AddTransient<IRestClient, RestClient>();

builder.Services.AddEntityFrameworkSqlite()
    .AddDbContext<AvatarDatabaseContext>();

WebApplication app = builder.Build();

app.UseRouting();

app.UseStaticFiles();

app.MapControllers();

app.MapRazorPages();

app.Run();
