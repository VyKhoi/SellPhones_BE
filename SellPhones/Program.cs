using log4net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using SellPhones.API.Authentication;
using SellPhones.Data.DI;
using SellPhones.Data.EF;
using SellPhones.DTO.Commons;
using SellPhones.Services.DI;
using System.Net;
using System.Reflection;
using System.Text;
using System.Xml;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// setup connect
builder.Services.AddDbContext<SellPhonesContext>(option =>
option.UseLazyLoadingProxies()
.UseNpgsql(builder.Configuration.GetConnectionString("MyDB"))
).AddUnitOfWork<SellPhonesContext>();


builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                        new HeaderApiVersionReader("x-api-version"),
                                                        new MediaTypeApiVersionReader("x-api-version"));
});
// add cors
builder.Services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                                                              .AllowAnyMethod()
                                                               .AllowAnyHeader()));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();

// Register the Swagger generator, defining 1 or more Swagger documents
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "SellPhones",
        Version = "v1",
        Description = "SellPhones Web API",
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                       {
                             new OpenApiSecurityScheme
                             {
                               Reference = new OpenApiReference
                               {
                                   Id = "Bearer",
                                 Type = ReferenceType.SecurityScheme
                               }
                            },
                          new string[] { }
                        }
                      });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})  // Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddAuthorization();

//Dependence Injection
builder.Services.AddServiceCollection();
SellPhones.Security.Startup.ConfigureAuth(builder.Services, builder.Configuration, builder.Configuration.GetConnectionString("MyDB"));
//route
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<AuthResponsesOperationFilter>();
});

builder.Services.AddMvc(config =>
{
    config.RespectBrowserAcceptHeader = true;
});

// logger
XmlDocument log4netConfig = new XmlDocument();
log4netConfig.Load(File.OpenRead("log4net.config"));
var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStatusCodePages();
app.UseStatusCodePages(async (StatusCodeContext context) =>
{
    var request = context.HttpContext.Request;
    var response = context.HttpContext.Response;

    if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
    {
        var body = new ResponseData(HttpStatusCode.Unauthorized, true, "Unauthorized");
        string str = JsonConvert.SerializeObject(body);
        response.ContentType = "application/json";   //add this line.....
        await response.WriteAsync(str);
        return;

    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();