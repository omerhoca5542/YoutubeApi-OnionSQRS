using YotubeApi.Persistence;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    var env = builder.Environment;// burdan bu ayar� yapt���m�zda environmet yani ortam olarak launc settings teki devolopment ya da production ortamlar�ndan hangisi se�ildiyse orda i�lem yap�lacak
builder.Configuration.SetBasePath(env.ContentRootPath)// burda dosyalar�n yolu tutuluyor b�ylece ister local ister internet sunucu ortam�nda �al��al�m sonu� olarak bu yolu g�ncelleyecektir
    .AddJsonFile("appsettings.json", optional: false)
    // her t�rl� bu appsettings.json dosyas�na ba�vuracak
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
builder.Services.AddPersistence(builder.Configuration);// YotubeApi.Persistence katman�n�n �al��mas� i�in bu d�zenlemeyi yapt�k. en �stte de  using YotubeApi.Persistence;ile  AddPersistence metodunun �al��mas�n� sa�lad�k
var app = builder.Build(); 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
