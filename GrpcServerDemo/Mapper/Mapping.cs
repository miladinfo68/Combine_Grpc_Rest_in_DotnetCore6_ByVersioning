using GrpcShared.Dtos;

namespace GrpcShared.Mapper;
public static class Mapping
{
    public static AuthorModel AsAuthorModel(this GetAuthorDto authorDto)
    {
        return new AuthorModel
        {
            Id = authorDto.Id,
            Name = authorDto.Name
        };
    }

    public static AddAuthorDto AsAddAuthorDto(this AuthorModel author)
    {
        return new AddAuthorDto
        {
            Name = author.Name
        };
    }

    public static AddBookRequest ToAddBookRequest(this AddBookDto bookDto)
    {
        return new AddBookRequest
        {
            Name = bookDto.Name,
            Subject = bookDto?.Subject,
            Genre = bookDto?.Genre,
            Isbn = bookDto?.ISBN,
            Description = bookDto?.Description,
            AuthorId = bookDto?.Author
        };
    }

    public static EditBookRequest ToEditBookRequest(this EditBookDto bookDto)
    {
        return new EditBookRequest
        {
            Id = bookDto.Id,
            Name = bookDto.Name,
            Subject = bookDto?.Subject,
            Genre = bookDto?.Genre,
            Isbn = bookDto?.ISBN,
            Description = bookDto?.Description,
            AuthorId = bookDto?.Author
        };
    }

    public static EditAuthorDto AsEditAuthorDto(this AuthorModel author)
    {
        return new EditAuthorDto
        {
            Id = author.Id,
            Name = author.Name
        };
    }

    //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

    public static BookModelDisplay AsBookModel(this GetBookDtoInfo book)
    {
        return new BookModelDisplay
        {
            Id = book.Id,
            Name = book.Name,
            Subject = book.Subject,
            Isbn = book.ISBN,
            Genre = book.Genre,
            Description = book.Description,
            Author = new AuthorMiniModel
            {
                Id = book.Author?.Id,
                Name = book.Author?.Name,
            }
        };
    }

    public static AddBookDto AsAddBookDto(this AddBookRequest req)
    {
        return new AddBookDto
        {
            Name = req.Name,
            Subject = req.Subject,
            ISBN = req.Isbn,
            Genre = req.Genre,
            Description = req.Description,
            Author = req.AuthorId
        };
    }

    public static BookModel AsAddBookResponse(this AddBookRequest req, string id)
    {
        return new BookModel
        {
            Id = id,
            Name = req.Name,
            Subject = req.Subject,
            Isbn = req.Isbn,
            Genre = req.Genre,
            Description = req.Description,
            AuthorId = req.AuthorId,
        };
    }

    public static BookModel AsEditBookResponse(this EditBookRequest req)
    {
        return new BookModel
        {
            Id = req.Id,
            Name = req.Name,
            Subject = req.Subject,
            Isbn = req.Isbn,
            Genre = req.Genre,
            Description = req.Description,
            AuthorId = req.AuthorId,
        };
    }

    public static EditBookDto AsEditBookDto(this EditBookRequest req)
    {
        return new EditBookDto
        {
            Id = req.Id,
            Name = req.Name,
            Subject = req.Subject,
            ISBN = req.Isbn,
            Genre = req.Genre,
            Description = req.Description,
            Author = req.AuthorId
        };
    }



}