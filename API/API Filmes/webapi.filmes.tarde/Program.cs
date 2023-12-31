using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//Adiciona o servi�o de Controllers
builder.Services.AddControllers();


//Adiciona servi�o de autentica��o JWT Bearer
builder.Services.AddAuthentication(Options =>
{
    Options.DefaultChallengeScheme = "JwtBearer";
    Options.DefaultAuthenticateScheme = "JwtBearer"; //deu erro antes pq eu errei a escrita o "Jwt" estava "JWT" erro de ESCRITA!!

})
    //Define os par�metros de valida��o do token
    .AddJwtBearer("JwtBearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //Valida quem est� solicitando
        ValidateIssuer = true,

        //Valida quem est� recebendo
        ValidateAudience = true,

        //Define se o tempo de expira��o do token ser� validado
        ValidateLifetime = true,

        //Forma de criptografa e ainda valida��o da chave de autentifica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev")),

        //Valida o tempo de expira��o do token
        ClockSkew = TimeSpan.FromMinutes(5),

        //De onde est� vindo (issuer)
        ValidIssuer = "webapi.filmes.tarde",

        //Para onde est� indo (audience)
        ValidAudience = "webapi.filmes.tarde"
    };
});







//Adiciona o gerador do Swagger � cole��o de servi�os no Program.cs:
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Filmes",
        Description = "API para gerenciamento de filmes - Introdu��o a Sprint 2 BackEnd API",
        Contact = new OpenApiContact
        {
            Name = "Vinicius Vieira",
            Url = new Uri("https://github.com/Vinicius-Vieira-Andrade")
        }
    });


    //Configura o swagger para usar arquivos XML
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


    //Usando a autentica��o no swagger
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


//Habilita o middleware para atender ao documento JSON gerado e � interface do usu�rio do Swagger, tamb�m em Program.cs:
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




//Para atender � interface do usu�rio do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


//Usar autentica��o
app.UseAuthentication();

//Usar autoriza��o
app.UseAuthorization();




//Mapear os controllers
app.MapControllers();

app.Run();
