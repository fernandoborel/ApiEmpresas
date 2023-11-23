using ApiEmpresas.Services.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Configurando os controllers da aplicação
builder.Services.AddControllers();

//Adicionar a configuração do Swagger
SwaggerConfiguration.AddSwagger(builder);

//Adicionar a configuração do EntityFramework
EntityFrameworkConfiguration.AddEntityFramework(builder);

//Adicionar a configuração do AutoMapper
AutoMapperConfiguration.AddAutoMapper(builder);

//Adicionar a configuração do JWT
JwtConfiguration.AddJwt(builder);

//configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", builder =>
    {
        builder.AllowAnyOrigin() //qualquer origem pode acessar a API
               .AllowAnyMethod() //qualquer método pode ser utilizado
               .AllowAnyHeader(); //qualquer cabeçalho pode ser utilizado
    });
});

// Add services to the container.
var app = builder.Build();

// Habilitar as rotas e endpoints da API
app.UseRouting();

// Habilitar a autenticação
app.UseAuthentication();
app.UseAuthorization();


//Configurando o descritor da API
app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetoAPI");
});

app.UseCors("DefaultPolicy");

//Executar os serviços
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();