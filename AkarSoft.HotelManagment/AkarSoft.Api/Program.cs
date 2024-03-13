using AkarSoft.Managers.Concrete.DependencyResolves.MicrosoftIOC;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using AkarSoft.Managers.Concrete.DependencyResolves.AutoFac;
using AkarSoft.Repositories.EntityFramework.Concrete.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region Services 

// Autofac için ilgili container tanıtıldı 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new AutoFacModule(builder.Configuration, builder.Environment)));

// Api için Controller Yapısı Eklendi 
builder.Services.AddControllers();

// İstege bagli olarak Microsoft IOC için ilgili IOC Container eklendi ve açıklama satırına alındı
//builder.Services.AddCostumeServicesMicrosoftIOC(); // Autofac kullanılacak ama öncesinde test amaçlı eklendi.

// Swagger İmplementasyonu tamamlandı 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();

#region Middlewares

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
#endregion

app.Run();
