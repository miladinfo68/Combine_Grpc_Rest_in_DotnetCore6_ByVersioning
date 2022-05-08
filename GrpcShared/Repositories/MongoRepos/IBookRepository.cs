using GrpcShared.Model;

namespace GrpcShared.Repositories.MongoRepos;
public interface IBookRepository:IMongoBaseRepo<Book>
{
}

public interface IAuthorRepository:IMongoBaseRepo<Author>
{
}

