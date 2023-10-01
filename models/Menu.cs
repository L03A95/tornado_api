using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Menu
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id {get; set;}

    [BsonElement("name")]
    public required string Name {get; set;}

    [BsonElement("description")]
    public string? Description {get; set;}

    [BsonElement("image")]
    public string? Image {get; set;}

    [BsonElement("price")]
    public required int Price {get; set;}
}