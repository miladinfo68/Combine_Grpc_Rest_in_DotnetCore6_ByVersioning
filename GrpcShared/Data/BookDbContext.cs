using GrpcShared.Model;
using MongoDB.Driver;

namespace GrpcShared.Data;
public interface IAppDbContext
{
    IMongoCollection<Book> Books { get; }
    IMongoCollection<Author> Authors { get; }
}


public class BookDbContext : IAppDbContext
{
    private readonly IMongoDatabase _db;
    public BookDbContext(IMongoClient client)
    {
        
        _db = client.GetDatabase("BookDb");
    }
    public IMongoCollection<Book> Books => _db.GetCollection<Book>("Books");
    public IMongoCollection<Author> Authors => _db.GetCollection<Author>("Authors");
}

