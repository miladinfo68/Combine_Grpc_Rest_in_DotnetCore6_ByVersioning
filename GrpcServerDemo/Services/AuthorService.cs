using Grpc.Core;
using GrpcShared;
using GrpcShared.Mapper;
using GrpcShared.Services;

namespace GrpcServerDemo.Services;


public class AuthorService : AuthorProtoService.AuthorProtoServiceBase
{
    private readonly ILogger<AuthorService> _logger;
    private readonly IAuthorapiService _authorapiService;

    public AuthorService(ILogger<AuthorService> logger, IAuthorapiService authorapiService)
    {
        _logger = logger;
        _authorapiService = authorapiService;
    }


    public override async Task<GetAllAuthorsResponse> GetAll(GetAllAuthorsRequest request, ServerCallContext context)
    {
        var authorsList = new GetAllAuthorsResponse();
        var authors = (await _authorapiService.GetAllAsync()).ToList().Select(s => s.AsAuthorModel());
        authorsList.Authors.AddRange(authors);
        return await Task.FromResult(authorsList);
    }


    public async override Task<GetAuthorResponse> GetById(GetAuthorRequest request, ServerCallContext context)
    {
        var author = (await _authorapiService.GetByIdAsync(request.Id))?.AsAuthorModel();
        return await Task.FromResult(new GetAuthorResponse { Author = author });
    }

    public override async Task<AddAuthorResponse> Add(AddAuthorRequest request, ServerCallContext context)
    {
        var newAuthor = new AuthorModel { Name = request.Name };
        var id=await _authorapiService.AddAsync(newAuthor.AsAddAuthorDto());
        return await Task.FromResult(new AddAuthorResponse { Id = id });
    }

    public override async Task<EditAuthorResponse> Update(EditAuthorRequest request, ServerCallContext context)
    {
        var author = (await _authorapiService.GetByIdAsync(request.Id))?.AsAuthorModel();
        if (author == null)
            return await Task.FromException<EditAuthorResponse>(new EntryPointNotFoundException());

        author.Name = request.Name;
        await _authorapiService.UpdateAsync(author.AsEditAuthorDto());

        return await Task.FromResult(new EditAuthorResponse { Author = author });
    }

    public override async Task<DeleteAuthorResponse> Delete(DeleteAuthorRequest request, ServerCallContext context)
    {
        var author = (await _authorapiService.GetByIdAsync(request.Id))?.AsAuthorModel();
        if (author == null)
            return await Task.FromException<DeleteAuthorResponse>(new EntryPointNotFoundException());
        var isOk = await _authorapiService.DeleteAsync(request.Id);
        return await Task.FromResult(new DeleteAuthorResponse { Result = isOk }); ;
    }
}

