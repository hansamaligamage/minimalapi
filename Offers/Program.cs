var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/offers", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
       new Offer
       (
           $"Offer {index}",
           $"This is a great offer {index}",
           DateTime.Now.AddDays(index)
       ))
        .ToArray();
    return forecast;
})
.WithName("GetOffers");

app.Run();

internal record Offer(string OfferName, string Value, DateTime DueOn);