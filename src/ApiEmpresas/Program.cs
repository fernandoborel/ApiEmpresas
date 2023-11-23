using ApiEmpresas.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Configurando os controllers da aplica��o
builder.Services.AddControllers();

//Adicionar a configura��o do Swagger
SwaggerConfiguration.AddSwagger(builder);

//Adicionar a configura��o do EntityFramework
EntityFrameworkConfiguration.AddEntityFramework(builder);

//Adicionar a configura��o do AutoMapper
AutoMapperConfiguration.AddAutoMapper(builder);

//Adicionar a configura��o do JWT
JwtConfiguration.AddJwt(builder);

//configura��o do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", builder =>
    {
        builder.AllowAnyOrigin() //qualquer origem pode acessar a API
               .AllowAnyMethod() //qualquer m�todo pode ser utilizado
               .AllowAnyHeader(); //qualquer cabe�alho pode ser utilizado
    });
});

// Add services to the container.
var app = builder.Build();

// Habilitar as rotas e endpoints da API
app.UseRouting();

// Habilitar a autentica��o
app.UseAuthentication();
app.UseAuthorization();


//Configurando o descritor da API
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI");
});

app.UseCors("DefaultPolicy");

//Executar os servi�os
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();