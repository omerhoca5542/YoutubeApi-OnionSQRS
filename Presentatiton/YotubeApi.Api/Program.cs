using YotubeApi.Persistence;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

    var env = builder.Environment;// burdan bu ayarý yaptýðýmýzda environmet yani ortam olarak launc settings teki devolopment ya da production ortamlarýndan hangisi seçildiyse orda iþlem yapýlacak
builder.Configuration.SetBasePath(env.ContentRootPath)// burda dosyalarýn yolu tutuluyor böylece ister local ister internet sunucu ortamýnda çalýþalým sonuç olarak bu yolu güncelleyecektir
    .AddJsonFile("appsettings.json", optional: false)
    // her türlü bu appsettings.json dosyasýna baþvuracak
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
builder.Services.AddPersistence(builder.Configuration);// YotubeApi.Persistence katmanýnýn çalýþmasý için bu düzenlemeyi yaptýk. en üstte de  using YotubeApi.Persistence;ile  AddPersistence metodunun çalýþmasýný saðladýk
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
