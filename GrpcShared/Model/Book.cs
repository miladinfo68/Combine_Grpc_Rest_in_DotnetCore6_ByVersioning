using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GrpcShared.Model;
public class Book //: EntityBase<Guid>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Subject { get; set; }
    public string? ISBN { get; set; }
    public string? Genre { get; set; }
    public string? Description { get; set; }


    [BsonRepresentation(BsonType.ObjectId)]
    public string? AuthorId { get; set; }


}