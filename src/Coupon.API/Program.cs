using eShop.ServiceDefaults;
using MongoDB.Driver;
using Coupon.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddMongoDBClient("mongodb");

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var coupons = app.MapGroup("/coupons");

coupons.MapGet("/", async (IMongoDatabase db) =>
{
    var collection = db.GetCollection<Coupon.API.Models.Coupon>("coupons");
    var allCoupons = await collection.Find(_ => true).ToListAsync();
    return Results.Ok(allCoupons);
});

coupons.MapGet("/{id}", async (IMongoDatabase db, string id) =>
{
    var collection = db.GetCollection<Coupon.API.Models.Coupon>("coupons");
    var coupon = await collection.Find(c => c.Id == id).FirstOrDefaultAsync();
    return coupon is not null ? Results.Ok(coupon) : Results.NotFound();
});

coupons.MapPost("/", async (IMongoDatabase db, Coupon.API.Models.Coupon coupon) =>
{
    var collection = db.GetCollection<Coupon.API.Models.Coupon>("coupons");
    await collection.InsertOneAsync(coupon);
    return Results.Created($"/coupons/{coupon.Id}", coupon);
});

coupons.MapPut("/{id}", async (IMongoDatabase db, string id, Coupon.API.Models.Coupon updatedCoupon) =>
{
    var collection = db.GetCollection<Coupon.API.Models.Coupon>("coupons");
    var result = await collection.ReplaceOneAsync(c => c.Id == id, updatedCoupon);
    return result.ModifiedCount > 0 ? Results.NoContent() : Results.NotFound();
});

coupons.MapDelete("/{id}", async (IMongoDatabase db, string id) =>
{
    var collection = db.GetCollection<Coupon.API.Models.Coupon>("coupons");
    var result = await collection.DeleteOneAsync(c => c.Id == id);
    return result.DeletedCount > 0 ? Results.NoContent() : Results.NotFound();
});

app.Run();
