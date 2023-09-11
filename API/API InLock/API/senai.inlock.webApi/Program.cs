using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);




//Adiciona o serviço de Controllers
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
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao-webapi-dev")),

            //Valida o tempo de expiração do token
            ClockSkew = TimeSpan.FromMinutes(5),

            //De onde está vindo (issuer)
            ValidIssuer = "webapi.jogos.inlock",

            //Para onde está indo (audience)
            ValidAudience = "webapi.jogos.inlock"
        };
    });







//Adiciona o gerador do Swagger à coleção de serviços no Program.cs:
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Jogos",
        Description = "API para gerenciamento de jogos",
        Contact = new OpenApiContact
        {
            Name = "InlockGames",
            Url = new Uri("https://github.com/Vinicius-Vieira-Andrade")
        }
    });


    //Configura o swagger para usar arquivos XML
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));


    //Usando a autenticação no swagger
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


//Habilita o middleware para atender ao documento JSON gerado e à interface do usuário do Swagger, também em Program.cs:
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




//Para atender à interface do usuário do Swagger na raiz do aplicativo
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});


//Usar autenticação
app.UseAuthentication();

//Usar autorização
app.UseAuthorization();




//Mapear os controllers
app.MapControllers();



app.Run();
