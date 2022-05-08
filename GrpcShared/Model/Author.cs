using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GrpcShared.Model;
public class Author //: EntityBase<Guid>
{
    [BsonId]//pk
    [BsonRepresentation(BsonType.ObjectId)]//only for database
    public string Id { get; set; }
    public string Name { get; set; } = null!;

    // [BsonRepresentation(BsonType.ObjectId)]
    // public List<string>? BookIDs { get; set; }
}