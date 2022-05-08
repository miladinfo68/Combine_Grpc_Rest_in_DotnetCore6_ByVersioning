using System.Linq.Expressions;
using GrpcShared.Dtos;
using GrpcShared.Mapper;
using GrpcShared.Repositories.MongoRepos;

namespace GrpcShared.Services;

public interface IAuthorapiService : IBaseService<GetAuthorDto, AddAuthorDto, EditAuthorDto> { }

public class AuthorapiService : IAuthorapiService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookRepository _bookRepository;
    public AuthorapiService(IAuthorRepository authorRepository, IBookRepository bookRepository)
    {
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;

    }


    public async Task<IReadOnlyCollection<GetAuthorDto>> GetAllAsync()
    {
        var AllBooks = await _bookRepository.GetAllAsync();
        var res = (from auth in await _authorRepository.GetAllAsync()
                   let books = AllBooks.Where(w => w.AuthorId == auth.Id)
                   select new GetAuthorDto
                   {
                       Id = auth.Id,
                       Name = auth.Name,
                       Books = books.Select(s => new GetBookDto { Id = s.Id, Name = s.Name })
                   }).ToList();
        return res;

    }

    public async Task<GetAuthorDto> GetByIdAsync(string id)
    {
        var AllBooks = await _bookRepository.GetAllAsync(bk => bk.AuthorId == id);
        var res = (from auth in await _authorRepository.GetAllAsync(w => w.Id == id)
                   select new GetAuthorDto
                   {
                       Id = auth.Id,
                       Name = auth.Name,
                       Books = AllBooks.Select(s => new GetBookDto { Id = s.Id, Name = s.Name })
                   }).SingleOrDefault();
        return res;
    }

    public async Task<string> AddAsync(AddAuthorDto entity)
    {
        var author = entity.ToAddAuthor();
        var authorId = await _authorRepository.AddAsync(author);
        return authorId;
    }

    public async Task<bool> UpdateAsync( EditAuthorDto entity)
    {
        return await _authorRepository.UpdateAsync(entity.ToEditAuthor());
    }

    public async Task<bool> DeleteAsync(string objectId)
    {
        return await _authorRepository.DeleteAsync(objectId);
    }

  
}