using System.Linq.Expressions;
using GrpcShared.Data;
using GrpcShared.Model;
using MongoDB.Driver;

namespace GrpcShared.Repositories.MongoRepos;
public class AuthorRepository : IAuthorRepository
{
    private readonly BookDbContext _db;

    public AuthorRepository(BookDbContext db)
    {
        _db = db;
    }

    public async Task<IReadOnlyCollection<Author>> GetAllAsync(Expression<Func<Author, bool>> filter = null)
    {
        if (filter is null)
            return await _db.Authors.Find(_ => true).ToListAsync();
        return await _db.Authors.Find(filter).ToListAsync();
    }

    public async Task<Author> GetByAsync(Expression<Func<Author, bool>> filter)
    {
        return await _db.Authors.Find(filter).FirstOrDefaultAsync();
    }

    public async Task<Author> GetByIdAsync(string id)
    {
        var filter = Builders<Author>.Filter.Eq(c => c.Id, id);
        var Author = await _db.Authors.Find(filter).FirstOrDefaultAsync();
        return Author;
    }

    public async Task<string> AddAsync(Author entity)
    {
        await _db.Authors.InsertOneAsync(entity);
        return entity.Id;
    }

    public async Task<bool> UpdateAsync(Author entity)
    {
        var filter = Builders<Author>.Filter.Eq(c => c.Id, entity.Id);
        var result = await _db.Authors.ReplaceOneAsync(filter, entity);
        return result.ModifiedCount == 1;
    }

    public async Task<bool> DeleteAsync(string id)
    {
        var filterAuthor = Builders<Author>.Filter.Eq(c => c.Id, id);
        if (filterAuthor != null)
        {
            var filterBooks = Builders<Book>.Filter.Eq(c => c.Id, id);
            if (filterBooks != null)
                await _db.Books.DeleteManyAsync(filterBooks);

            var res = await _db.Authors.DeleteOneAsync(filterAuthor);
            return res.DeletedCount == 1;
        }
        return false;
    }


}