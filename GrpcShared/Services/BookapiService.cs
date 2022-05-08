using GrpcShared.Dtos;
using GrpcShared.Mapper;
using GrpcShared.Repositories.MongoRepos;

namespace GrpcShared.Services;

public interface IBookapiService : IBaseService<GetBookDtoInfo, AddBookDto, EditBookDto> { }

public class BookapiService : IBookapiService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRepository _bookRepository;
    public BookapiService(IAuthorRepository authorRepository, IBookRepository bookRepository)
    {
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;

    }

    public async Task<IReadOnlyCollection<GetBookDtoInfo>> GetAllAsync()
    {
        var authors = await _authorRepository.GetAllAsync();
        var res = (from bk in await _bookRepository.GetAllAsync()
                   select new GetBookDtoInfo
                   {
                       Id = bk.Id,
                       Name = bk.Name,
                       Subject = bk.Subject,
                       Genre = bk.Genre,
                       ISBN = bk.ISBN,
                       Description = bk.Description,
                       Author = authors.Where(w => w.Id == bk.AuthorId).Select(s => new GetAuthorInfoDto { Id = s.Id, Name = s.Name }).FirstOrDefault()
                   }).ToList();
        return res;
    }

    public async Task<GetBookDtoInfo> GetByIdAsync(string id)
    {
        var bk = await _bookRepository.GetByAsync(w => w.Id == id);
        var auth = await _authorRepository.GetByIdAsync(bk.AuthorId);
        var res = new GetBookDtoInfo
        {
            Id = bk.Id,
            Name = bk.Name,
            Subject = bk.Subject,
            Genre = bk.Genre,
            ISBN = bk.ISBN,
            Description = bk.Description,
            Author = auth == null ? null : new GetAuthorInfoDto { Id = auth.Id, Name = auth.Name }
        };
        return res;
    }

    public async Task<string> AddAsync(AddBookDto entity)
    {
        var book = entity.ToAddBook();
        var bookId = await _bookRepository.AddAsync(book);
        return bookId;
    }

    public async Task<bool> UpdateAsync(EditBookDto entity)
    {
        return await _bookRepository.UpdateAsync(entity.ToEditBook());
    }
    public async Task<bool> DeleteAsync(string objectId)
    {
        return await _bookRepository.DeleteAsync(objectId);
    }
}