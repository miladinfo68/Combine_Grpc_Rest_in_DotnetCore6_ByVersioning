using System.Linq.Expressions;
using GrpcShared.Data;
using GrpcShared.Model;
using MongoDB.Driver;

namespace GrpcShared.Repositories.MongoRepos;
public class BookRepository : IBookRepository
{
    //https://mongodb.github.io/mongo-csharp-driver/2.14/getting_started/quick_tour/
    private readonly BookDbContext _db;
    private readonly FilterDefinitionBuilder<Book> filterBuilder = Builders<Book>.Filter;

    public BookRepository(BookDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyCollection<Book>> GetAllAsync(Expression<Func<Book, bool>> filter = null)
    {
        if (filter is null)
            // return await _db.Books.Find(_ => true).ToListAsync();
            return await _db.Books.Find(filterBuilder.Empty).ToListAsync();
        return await _db.Books.Find(filter).ToListAsync();
    }

    public async Task<Book> GetByAsync(Expression<Func<Book, bool>> filter)
    {
        return await _db.Books.Find(filter).FirstOrDefaultAsync();
    }
    public Task<Book> GetByIdAsync(string id)
    {
        var filter = Builders<Book>.Filter.Eq(c => c.Id, id);
        var Book = _db.Books.Find(filter).FirstOrDefaultAsync();
        return Book;
    }

    public async Task<string> AddAsync(Book entity)
    {
        await _db.Books.InsertOneAsync(entity);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Book entity)
    {
        var filter = Builders<Book>.Filter.Eq(c=>c.Id, entity.Id);
        
        var result2 =await _db.Books.ReplaceOneAsync(filter, entity);
        return  result2.ModifiedCount == 1;

        // var update = Builders<Book>.Update
        //     .Set(s => s.Name, entity.Name)
        //     .Set(s => s.Subject, entity.Subject)
        //     .Set(s => s.Genre, entity.Genre)
        //     .Set(s => s.ISBN, entity.ISBN)
        //     .Set(s => s.Description, entity.Description)
        //     .Set(s => s.AuthorId, entity.AuthorId);
        // var result = await _db.Books.UpdateOneAsync(filter, update);
        // return  result.ModifiedCount == 1;
    }
    public async Task<bool> DeleteAsync(string id)
    {
        var filter = Builders<Book>.Filter.Eq(c => c.Id, id);
        var res = await _db.Books.DeleteOneAsync(filter);
        return res.DeletedCount == 1;
    }

}