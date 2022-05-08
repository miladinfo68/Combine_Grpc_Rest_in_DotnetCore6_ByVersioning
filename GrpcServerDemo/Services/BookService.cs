using Grpc.Core;
using GrpcShared;
using GrpcShared.Mapper;
using GrpcShared.Services;

namespace GrpcServerDemo.Services;


public class BookService : BookProtoService.BookProtoServiceBase
{
    private readonly ILogger<BookService> _logger;
    private readonly IBookapiService _bookapiService;

    public BookService(ILogger<BookService> logger, IBookapiService BookapiService)
    {
        _logger = logger;
        _bookapiService = BookapiService;
    }


    public override async Task<GetAllBooksResponse> GetAll(GetAllBooksRequest request, ServerCallContext context)
    {
        var booksList = new GetAllBooksResponse();
        var books = (await _bookapiService.GetAllAsync()).ToList().Select(s => s.AsBookModel());
        booksList.Books.AddRange(books);
        return await Task.FromResult(booksList);
    }


    public async override Task<GetBookResponse> GetById(GetBookRequest request, ServerCallContext context)
    {
        var book = (await _bookapiService.GetByIdAsync(request.Id))?.AsBookModel();
        return await Task.FromResult(new GetBookResponse { Book = book });
    }

    public override async Task<AddBookResponse> Add(AddBookRequest request, ServerCallContext context)
    {
        var id = await _bookapiService.AddAsync(request.AsAddBookDto());
        return await Task.FromResult(new AddBookResponse { Book = request.AsAddBookResponse(id) });
    }

    public override async Task<EditBookResponse> Update(EditBookRequest request, ServerCallContext context)
    {
        var book = (await _bookapiService.GetByIdAsync(request.Id))?.AsBookModel();
        if (book == null)
            return await Task.FromException<EditBookResponse>(new EntryPointNotFoundException());

        var result = await _bookapiService.UpdateAsync(request.AsEditBookDto());
        var res = result ? request.AsEditBookResponse() : null;
        return await Task.FromResult(new EditBookResponse { Book = res });

    }

    public override async Task<DeleteBookResponse> Delete(DeleteBookRequest request, ServerCallContext context)
    {
        var Book = (await _bookapiService.GetByIdAsync(request.Id))?.AsBookModel();
        if (Book == null)
            return await Task.FromException<DeleteBookResponse>(new EntryPointNotFoundException());
        var isOk = await _bookapiService.DeleteAsync(request.Id);
        return await Task.FromResult(new DeleteBookResponse { Result = isOk }); ;
    }
}

