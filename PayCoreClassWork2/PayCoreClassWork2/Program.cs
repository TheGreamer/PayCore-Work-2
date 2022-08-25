using FluentValidation.AspNetCore;
using PayCoreClassWork2.Utilities;
using PayCoreClassWork2.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                .AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<StaffValidator>()) // Personel validasyon kurallar� sisteme dahil edilir.
                .AddJsonOptions(j => j.JsonSerializerOptions.Converters.Add(new DateTimeConverter())); // �zelle�tirilmi� json tarih format bi�imi sisteme dahil edilir.

builder.Services.AddEndpointsApiExplorer().AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwagger().UseSwaggerUI();

app.UseHttpsRedirection().UseAuthorization();
app.MapControllers();
app.Run();