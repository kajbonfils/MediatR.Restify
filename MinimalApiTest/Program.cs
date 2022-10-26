using MediatR;
using Microsoft.AspNetCore.Mvc;
using MinimalApiTest.MediatR;
using MinimalApiTest.Repo;
using MinimalApiTest.Request;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
// builder.Services.AddRestify(TypeOf(Program)) // - will fetch and configure all restformatters in the 
builder.Services.AddSingleton<ICarModelRepository, CarModelRepository>();
var app = builder.Build();

var mediator = app.Services.GetService<IMediator>() ?? throw new Exception("MediatR not registered");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("/",  () => mediator.Send(new GetCarModelsRequest()).ToRest());
app.MapGet("/{id:int}",  (int id) => mediator.Send(new GetSpecificCarModelRequest(id)).ToRest())
    .WithName("GetCarModel");
app.MapPost("/", (CreateCarModelRequest request) => mediator.Send(request).ToRest());
app.MapGet("/foo", ([FromBody]SecretRequest request) => mediator.Send(request).ToRest()); // GET with body

app.MapRazorPages();


app.Run();
