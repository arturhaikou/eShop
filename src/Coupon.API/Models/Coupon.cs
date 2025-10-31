using MongoDB.Bson.Serialization.Attributes;

namespace Coupon.API.Models;

public class Coupon
{
    [BsonId]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    [BsonElement("code")]
    public string? Code { get; set; }
    [BsonElement("discount")]
    public decimal Discount { get; set; }
    [BsonElement("expirationDate")]
    public DateTime ExpirationDate { get; set; }
}