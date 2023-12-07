using ApplicationWeb;
using ApplicationWeb.Data;
using ApplicationWeb.Repository;
using ApplicationWeb.Service.Implements;
using ApplicationWeb.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Service.IService;
using Service.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("ApplicationWebBearerAuth", new OpenApiSecurityScheme()
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Pegar Token Generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "ApplicationWebBearerAuth" }
            }, new List<string>() }
    });
});

#region Inyeccion de dependencia
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISellOrderService, SellOrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<SellOrderRepository>();
builder.Services.AddScoped<ProductsRepository>();
#endregion

#region Data Base
builder.Services.AddDbContext<TiendaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WebConnection"))
);
#endregion

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

#region Migration
using (var scope = app.Services.CreateScope())
{
   var context = scope.ServiceProvider.GetRequiredService<TiendaContext>();
    context.Database.Migrate();
}

#endregion

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
