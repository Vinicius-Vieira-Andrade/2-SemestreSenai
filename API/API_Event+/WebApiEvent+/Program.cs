using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Adiciona serviço de autenticação JWT Bearer
builder.Services.AddAuthentication(Options =>
{
    Options.DefaultChallengeScheme = "JwtBearer";
    Options.DefaultAuthenticateScheme = "JwtBearer"; //deu erro antes pq eu errei a escrita o "Jwt" estava "JWT" erro de ESCRITA!!

})
    //Define os parâmetros de validação do token
    .AddJwtBearer("JwtBearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //Valida quem está solicitando
            ValidateIssuer = true,

            //Valida quem está recebendo
            ValidateAudience = true,

            //Define se o tempo de expiração do token será validado
            ValidateLifetime = true,

            //Forma de criptografa e ainda validação da chave de autentificação
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("aaaaaaaaaaaaa-maior-autenticacao-tarde-eventplus-key-webapi")),

            //Valida o tempo de expiração do token
            ClockSkew = TimeSpan.FromMinutes(3),

            //De onde está vindo (issuer)
            ValidIssuer = "webapi-event",

            //Para onde está indo (audience)
            ValidAudience = "webapi-event"
        };
    });


builder.Services.AddEndpointsApiExplorer();



builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Api Event+",
        Description = "API para gerenciar eventos e usuários",
        Contact = new OpenApiContact
        {
            Name = "EventPlus+",
            Url = new Uri("https://github.com/Vinicius-Vieira-Andrade")
        }
    });




    //var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Value: Bearer TokenJWT"
    });



    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                }
            },
            new string[]{}
        }
    });

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});



app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.Run();
